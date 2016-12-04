using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneQueryFieldDefInfo : ICloneable
    {
        QueryFieldDefInfo m_source;
        QueryFieldDefInfo m_target;
        public CloneQueryFieldDefInfo(QueryFieldDefInfo fieldInfo)
        {
            m_source = (QueryFieldDefInfo)fieldInfo.Clone();
            m_target = (QueryFieldDefInfo)fieldInfo.Clone();
        }

        public QueryFieldDefInfo GetSourceInfo()
        {
            return (QueryFieldDefInfo)m_source.Clone();
        }
        public QueryFieldDefInfo GetTargetInfo()
        {
            return (QueryFieldDefInfo)m_target.Clone();
        }
        #region ICloneable Members

        public object Clone()
        {
            CloneQueryFieldDefInfo other = (CloneQueryFieldDefInfo)this.MemberwiseClone();
            other.m_source = (QueryFieldDefInfo)this.m_source.Clone();
            other.m_target = (QueryFieldDefInfo)this.m_target.Clone();

            return other;
        }

        #endregion
    }
}
