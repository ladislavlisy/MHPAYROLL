using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    class CloneQueryJoinFieldDefInfo : ICloneable
    {
        QueryJoinFieldDefInfo m_source;
        QueryJoinFieldDefInfo m_target;
        public CloneQueryJoinFieldDefInfo(QueryJoinFieldDefInfo fieldInfo)
        {
            m_source = (QueryJoinFieldDefInfo)fieldInfo.Clone();
            m_target = (QueryJoinFieldDefInfo)fieldInfo.Clone();
        }

        public QueryJoinFieldDefInfo GetSourceInfo()
        {
            return (QueryJoinFieldDefInfo)m_source.Clone();
        }
        public QueryJoinFieldDefInfo GetTargetInfo()
        {
            return (QueryJoinFieldDefInfo)m_target.Clone();
        }
        #region ICloneable Members

        public object Clone()
        {
            CloneQueryJoinFieldDefInfo other = (CloneQueryJoinFieldDefInfo)this.MemberwiseClone();
            other.m_source = (QueryJoinFieldDefInfo)this.m_source.Clone();
            other.m_target = (QueryJoinFieldDefInfo)this.m_target.Clone();

            return other;
        }

        #endregion
    }
}
