using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneIndexFieldDefInfo : ICloneable
    {
        IndexFieldDefInfo m_source;
        IndexFieldDefInfo m_target;
        public CloneIndexFieldDefInfo(IndexFieldDefInfo fieldInfo)
        {
            m_source = (IndexFieldDefInfo)fieldInfo.Clone();
            m_target = (IndexFieldDefInfo)fieldInfo.Clone();
        }
        public CloneIndexFieldDefInfo(IndexFieldDefInfo sourceField, IndexFieldDefInfo targetField)
        {
            m_source = null;
            m_target = null;
            if (sourceField != null)
            {
                m_source = (IndexFieldDefInfo)sourceField.Clone();
            }
            if (targetField != null)
            {
                m_target = (IndexFieldDefInfo)targetField.Clone();
            }
        }
        public string SourceName()
        {
            if (m_source != null)
            {
                return m_source.m_strName;
            }
            return DBConstants.EMPTY_STRING;
        }
        public string TargetName()
        {
            if (m_target != null)
            {
                return m_target.m_strName;
            }
            return DBConstants.EMPTY_STRING;
        }
        public IndexFieldDefInfo GetSourceInfo()
        {
            return (IndexFieldDefInfo)m_source.Clone();
        }
        public IndexFieldDefInfo GetTargetInfo()
        {
            return (IndexFieldDefInfo)m_target.Clone();
        }
        public void SetTargetName(string newColumnName)
        {
            m_target.m_strName = newColumnName;
        }

        public object Clone()
        {
            CloneIndexFieldDefInfo other = (CloneIndexFieldDefInfo)this.MemberwiseClone();
            other.m_source = (IndexFieldDefInfo)this.m_source.Clone();
            other.m_target = (IndexFieldDefInfo)this.m_target.Clone();

            return other;
        }
    }
}
