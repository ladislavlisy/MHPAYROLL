using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneQueryFilterDefInfo : ICloneable
    {
        QueryFilterDefInfo m_source;
        QueryFilterDefInfo m_target;
        public CloneQueryFilterDefInfo(QueryFilterDefInfo fieldInfo)
        {
            m_source = (QueryFilterDefInfo)fieldInfo.Clone();
            m_target = (QueryFilterDefInfo)fieldInfo.Clone();
        }

        public QueryFilterDefInfo GetSourceInfo()
        {
            return (QueryFilterDefInfo)m_source.Clone();
        }
        public QueryFilterDefInfo GetTargetInfo()
        {
            return (QueryFilterDefInfo)m_target.Clone();
        }
        #region ICloneable Members

        public object Clone()
        {
            CloneQueryFilterDefInfo other = (CloneQueryFilterDefInfo)this.MemberwiseClone();
            other.m_source = (QueryFilterDefInfo)this.m_source.Clone();
            other.m_target = (QueryFilterDefInfo)this.m_target.Clone();

            return other;
        }

        #endregion
    }
}
