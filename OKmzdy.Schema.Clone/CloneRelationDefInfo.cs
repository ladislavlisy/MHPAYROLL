using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneRelationDefInfo : ICloneable
    {
        private IList<CloneRelationFieldDef> m_RelationFields;
        public string m_strName;
        public string m_strTable;
        public string m_strColumn;
        public string m_strForeignTable;
        public int m_lAttributes;
        public int m_nFields;
        public CloneRelationDefInfo(RelationDefInfo defInfo)
        {
            this.m_RelationFields = defInfo.RelationFields().Select((rf) => new CloneRelationFieldDef(rf)).ToList();
            this.m_strName = defInfo.m_strName;
            this.m_strTable = defInfo.m_strTable;
            this.m_strColumn = defInfo.m_strColumn;
            this.m_strForeignTable = defInfo.m_strForeignTable;
            this.m_lAttributes = defInfo.m_lAttributes;
            this.m_nFields = defInfo.m_nFields;
        }
        public RelationDefInfo GetSourceInfo()
        {
            RelationDefInfo defInfo = new RelationDefInfo(this.m_strName, this.m_strForeignTable, this.m_strTable, this.m_strColumn);
            defInfo.SetRelationField(this.m_RelationFields.Select((rf) => (rf.GetSourceInfo())).ToList());
            defInfo.SetAttributes(this.m_lAttributes);
            defInfo.SetFields(this.m_nFields);

            return defInfo;
        }

        public RelationDefInfo GetTargetInfo()
        {
            RelationDefInfo defInfo = new RelationDefInfo(this.m_strName, this.m_strForeignTable, this.m_strTable, this.m_strColumn);
            defInfo.SetRelationField(this.m_RelationFields.Select((rf) => (rf.GetTargetInfo())).ToList());
            defInfo.SetAttributes(this.m_lAttributes);
            defInfo.SetFields(this.m_nFields);

            return defInfo;
        }

        public string TargetForeignNamestAllUnique()
        {
            return m_strForeignTable + "." + string.Join(".", m_RelationFields.Select((f) => (f.TargetForeignName())).ToList());
        }
        public string TargetNamestAllUnique()
        {
            return m_strTable + "." + string.Join(".", m_RelationFields.Select((f) => (f.TargetName())).ToList());
        }


        public void ReNameTableColumn(string oldAuroName, string newName)
        {
            CloneRelationFieldDef relationField = m_RelationFields.SingleOrDefault((f) => (f.TargetName().CompareTo(oldAuroName) == 0));
            if (relationField != null)
            {
                relationField.SetTargetName(newName);
            }
        }

        public void MakeTargetRelationOrmReady(string relForeignColumnName, string relColumnName)
        {
            m_RelationFields = new List<CloneRelationFieldDef>();
            m_strColumn = relForeignColumnName;
            m_nFields = 0;
            m_lAttributes = 0;
            AppendForeignField(relForeignColumnName, relColumnName);

            string newRelationName = relForeignColumnName.Replace("_refid", "").Replace("_id", "");
            m_strName = newRelationName + "_" + m_strForeignTable.ToLower();
        }

        public RelationFieldDef AppendForeignField(string lpszForeignName, string lpszRelName)
        {
            RelationFieldDef fieldInfo = new RelationFieldDef(lpszForeignName, lpszRelName);

            CloneRelationFieldDef fieldClone = new CloneRelationFieldDef(null, fieldInfo);

            m_RelationFields.Add(fieldClone);
            m_nFields++;

            return fieldInfo;
        }

        public object Clone()
        {
            CloneRelationDefInfo other = (CloneRelationDefInfo)this.MemberwiseClone();
            other.m_RelationFields = this.m_RelationFields.Select((rf) => ((CloneRelationFieldDef)rf.Clone())).ToList();
            other.m_strName = this.m_strName;
            other.m_strTable = this.m_strTable;
            other.m_strColumn = this.m_strColumn;
            other.m_strForeignTable = this.m_strForeignTable;
            other.m_lAttributes = this.m_lAttributes;
            other.m_nFields = this.m_nFields;

            return other;
        }
    }
}
