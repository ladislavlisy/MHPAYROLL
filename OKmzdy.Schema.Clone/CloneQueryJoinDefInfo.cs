using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneQueryJoinDefInfo : ICloneable
    {
        private IList<CloneQueryJoinFieldDefInfo> m_QueryJoinFieldInfo;
        public bool m_bJoinCondition;
        public bool m_bLeftCondition;
        public string m_strLeftAliasName;
        public string m_strRightAliasName;
        public CloneQueryJoinDefInfo(QueryJoinDefInfo defInfo)
        {
            this.m_QueryJoinFieldInfo = defInfo.QueryTableJoinFields().Select((jf) => (new CloneQueryJoinFieldDefInfo(jf))).ToList();
            this.m_bJoinCondition = defInfo.m_bJoinCondition;
            this.m_bLeftCondition = defInfo.m_bLeftCondition;
            this.m_strLeftAliasName = defInfo.m_strLeftAliasName;
            this.m_strRightAliasName = defInfo.m_strRightAliasName;
        }

        public QueryJoinDefInfo GetSourceInfo()
        {
            QueryJoinDefInfo defInfo = new QueryJoinDefInfo(this.m_strLeftAliasName, this.m_strRightAliasName, this.m_bJoinCondition, this.m_bLeftCondition);
            defInfo.SetQueryJoinFieldList(this.m_QueryJoinFieldInfo.Select((qj) => (qj.GetSourceInfo())).ToList());

            return defInfo;
        }

        public QueryJoinDefInfo GetTargetInfo()
        {
            QueryJoinDefInfo defInfo = new QueryJoinDefInfo(this.m_strLeftAliasName, this.m_strRightAliasName, this.m_bJoinCondition, this.m_bLeftCondition);
            defInfo.SetQueryJoinFieldList(this.m_QueryJoinFieldInfo.Select((qj) => (qj.GetTargetInfo())).ToList());

            return defInfo;
        }

        #region ICloneable Members

        public object Clone()
        {
            CloneQueryJoinDefInfo other = (CloneQueryJoinDefInfo)this.MemberwiseClone();
            other.m_QueryJoinFieldInfo = this.m_QueryJoinFieldInfo.Select((jf) => ((CloneQueryJoinFieldDefInfo) jf.Clone())).ToList();
            other.m_bJoinCondition = this.m_bJoinCondition;
            other.m_bLeftCondition = this.m_bLeftCondition;
            other.m_strLeftAliasName = this.m_strLeftAliasName;
            other.m_strRightAliasName = this.m_strRightAliasName;

            return other;
        }

        #endregion
    }
}
