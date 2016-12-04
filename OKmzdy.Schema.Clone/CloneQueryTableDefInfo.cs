using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneQueryTableDefInfo : ICloneable
    {
        private CloneTableDefInfo m_QueryTableInfo;
        public IList<CloneQueryFieldDefInfo> m_QueryFields;
        public string m_strAliasName;
        public string m_strName;
        public CloneQueryTableDefInfo(QueryTableDefInfo defInfo, UInt32 versCreate)
        {
            this.m_QueryTableInfo = new CloneTableDefInfo(defInfo.QueryTableInfo(), versCreate);
            this.m_QueryFields = defInfo.QueryFields().Select((qf) => (new CloneQueryFieldDefInfo(qf))).ToList();
            this.m_strAliasName = defInfo.m_strAliasName;
            this.m_strName = defInfo.m_strName;
        }

        public QueryTableDefInfo GetSourceInfo()
        {
            QueryTableDefInfo defInfo = new QueryTableDefInfo(this.m_strAliasName, this.m_QueryTableInfo.GetSourceInfo());
            defInfo.SetQueryFieldsList(this.m_QueryFields.Select((qf) => (qf.GetSourceInfo())).ToList());

            return defInfo;
        }

        public QueryTableDefInfo GetTargetInfo()
        {
            QueryTableDefInfo defInfo = new QueryTableDefInfo(this.m_strAliasName, this.m_QueryTableInfo.GetTargetInfo());
            defInfo.SetQueryFieldsList(this.m_QueryFields.Select((qf) => (qf.GetTargetInfo())).ToList());

            return defInfo;
        }

        #region ICloneable Members

        public object Clone()
        {
            CloneQueryTableDefInfo other = (CloneQueryTableDefInfo)this.MemberwiseClone();
            other.m_QueryTableInfo = (CloneTableDefInfo)this.m_QueryTableInfo.Clone();
            other.m_QueryFields = this.m_QueryFields.Select((qf) => ((CloneQueryFieldDefInfo)qf.Clone())).ToList();
            other.m_strAliasName = this.m_strAliasName;
            other.m_strName = this.m_strName;

            return other;
        }

        #endregion
    }
}
