using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneTableFieldDefInfo : ICloneable
    {
        TableFieldDefInfo m_source;
        TableFieldDefInfo m_target;

        public CloneTableFieldDefInfo(TableFieldDefInfo fieldInfo)
        {
            m_source = (TableFieldDefInfo)fieldInfo.Clone();
            m_target = (TableFieldDefInfo)fieldInfo.Clone();
        }

        public CloneTableFieldDefInfo(TableFieldDefInfo sourceField, TableFieldDefInfo targetField)
        {
            m_source = null;
            m_target = null;
            if (sourceField != null)
            {
                m_source = (TableFieldDefInfo)sourceField.Clone();
            }
            if (targetField != null)
            {
                m_target = (TableFieldDefInfo)targetField.Clone();
            }
        }

        public bool IsValidInVersion(UInt32 versCreate)
        {
            if (m_source == null)
            {
                return false;
            }
            if (m_target == null)
            {
                return false;
            }
            return (m_source.IsValidInVersion(versCreate) && m_target.IsValidInVersion(versCreate));
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
        public TableFieldDefInfo GetSourceInfo()
        {
            if (m_source != null)
            {
                return (TableFieldDefInfo)m_source.Clone();
            }
            return null;
        }
        public TableFieldDefInfo GetTargetInfo()
        {
            if (m_target != null)
            {
                return (TableFieldDefInfo)m_target.Clone();
            }
            return null;
        }
        public bool IsAutoIncrement()
        {
            return m_source.IsAutoIncrement();
        }

        public void ReNameTargetColumn(string newName)
        {
            m_target.ReNameColumn(newName);
        }

        public object Clone()
        {
            CloneTableFieldDefInfo other = (CloneTableFieldDefInfo)this.MemberwiseClone();
            other.m_source = (TableFieldDefInfo)this.m_source.Clone();
            other.m_target = (TableFieldDefInfo)this.m_target.Clone();

            return other;
        }
    }
}
