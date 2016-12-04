using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneQueryWhereDefInfo : ICloneable
    {
        private CloneTableDefInfo m_QueryTableInfo;
        public IList<CloneQueryFilterDefInfo> m_QueryFilters;
        public string m_strAliasName;
        public string m_strName;

        public CloneQueryWhereDefInfo(QueryWhereDefInfo defInfo, UInt32 versCreate)
        {
            this.m_QueryTableInfo = new CloneTableDefInfo(defInfo.QueryTableInfo(), versCreate);
            this.m_QueryFilters = defInfo.QueryFilters().Select((qf) => new CloneQueryFilterDefInfo(qf)).ToList();
            this.m_strAliasName = defInfo.AliasName();
            this.m_strName = defInfo.TableName();
        }

        public QueryWhereDefInfo GetSourceInfo()
        {
            QueryWhereDefInfo defInfo = new QueryWhereDefInfo(this.m_strAliasName, this.m_QueryTableInfo.GetSourceInfo());
            defInfo.SetQueryFiltersList(this.m_QueryFilters.Select((qf) => (qf.GetSourceInfo())).ToList());

            return defInfo;
        }

        public QueryWhereDefInfo GetTargetInfo()
        {
            QueryWhereDefInfo defInfo = new QueryWhereDefInfo(this.m_strAliasName, this.m_QueryTableInfo.GetTargetInfo());
            defInfo.SetQueryFiltersList(this.m_QueryFilters.Select((qf) => (qf.GetTargetInfo())).ToList());

            return defInfo;
        }

        #region ICloneable Members

        public object Clone()
        {
            CloneQueryWhereDefInfo other = (CloneQueryWhereDefInfo)this.MemberwiseClone();

            return other;
        }

        #endregion
    }
}
