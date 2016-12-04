using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneRelationFieldDef : ICloneable
    {
        RelationFieldDef m_source;
        RelationFieldDef m_target;
        public CloneRelationFieldDef(RelationFieldDef fieldInfo)
        {
            m_source = (RelationFieldDef)fieldInfo.Clone();
            m_target = (RelationFieldDef)fieldInfo.Clone();
        }
        public CloneRelationFieldDef(RelationFieldDef sourceField, RelationFieldDef targetField)
        {
            m_source = null;
            m_target = null;
            if (sourceField != null)
            {
                m_source = (RelationFieldDef)sourceField.Clone();
            }
            if (targetField != null)
            {
                m_target = (RelationFieldDef)targetField.Clone();
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
        public string SourceForeignName()
        {
            if (m_source != null)
            {
                return m_source.m_strForeignName;
            }
            return DBConstants.EMPTY_STRING;
        }
        public string TargetForeignName()
        {
            if (m_target != null)
            {
                return m_target.m_strForeignName;
            }
            return DBConstants.EMPTY_STRING;
        }
        public RelationFieldDef GetSourceInfo()
        {
            return (RelationFieldDef)m_source.Clone();
        }
        public RelationFieldDef GetTargetInfo()
        {
            return (RelationFieldDef)m_target.Clone();
        }
        public void SetTargetName(string newColumnName)
        {
            m_target.m_strName = newColumnName;
        }

        public object Clone()
        {
            CloneRelationFieldDef other = (CloneRelationFieldDef)this.MemberwiseClone();
            other.m_source = (RelationFieldDef)this.m_source.Clone();
            other.m_target = (RelationFieldDef)this.m_target.Clone();

            return other;
        }
    }
}
