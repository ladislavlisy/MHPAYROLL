using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class RelationDefInfo : ICloneable
    {
        private IList<RelationFieldDef> m_RelationFields;
        public string m_strName;
        public string m_strTable;
        public string m_strColumn;
        public string m_strForeignTable;
        public int m_lAttributes;
        public int m_nFields;

        public RelationDefInfo(string lpszName, string lpszForeignTable, string lpszRelTable, string lpszRelColumn)
        {
            m_RelationFields = new List<RelationFieldDef>();
            m_strName = lpszName;
            m_strTable = lpszRelTable;
            m_strColumn = lpszRelColumn;
            m_strForeignTable = lpszForeignTable;
            m_lAttributes = 0;
            m_nFields = 0;
        }
        public IList<RelationFieldDef> RelationFields()
        {
            return m_RelationFields;
        }

        public RelationFieldDef RelationFieldByName(string lpszName)
        {
            return m_RelationFields.SingleOrDefault((f) => f.m_strForeignName.CompareNoCase(lpszName));
        }

        public RelationFieldDef AppendField(string lpszName)
        {
            RelationFieldDef fieldInfo = new RelationFieldDef(lpszName, lpszName);

            m_RelationFields.Add(fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        public RelationFieldDef AppendForeignField(string lpszForeignName, string lpszRelName)
        {
            RelationFieldDef fieldInfo = new RelationFieldDef(lpszForeignName, lpszRelName);

            m_RelationFields.Add(fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        public void ReNameTableColumn(string oldAuroName, string newName)
        {
            RelationFieldDef relationField = m_RelationFields.SingleOrDefault((f) => (f.m_strName.CompareTo(oldAuroName) == 0));
            if (relationField != null)
            {
                relationField.m_strName = newName;
            }
        }

        public void ReNameForeignColumn(string oldAuroName, string newName)
        {
            RelationFieldDef relationField = m_RelationFields.SingleOrDefault((f) => (f.m_strForeignName.CompareTo(oldAuroName) == 0));
            if (relationField != null)
            {
                relationField.m_strForeignName = newName;
            }
        }

        public string FieldNameColumnList()
        {
            string strNames = "";
            foreach (var field in m_RelationFields)
            {
                strNames += field.m_strName;
                strNames += (",");
            }
            string retNames = strNames.TrimEnd(DBConstants.TRIM_CHARS);
            return retNames;
        }

        public string ForeignFieldNameColumnList()
        {
            string strFNames = "";
            foreach (var field in m_RelationFields)
            {
                strFNames += field.m_strForeignName;
                strFNames += (",");
            }
            string retFNames = strFNames.TrimEnd(DBConstants.TRIM_CHARS);
            return retFNames;
        }

        public string FieldNameColumnLnList()
        {
            string strNames = "";
            foreach (var field in m_RelationFields)
            {
                strNames += field.m_strName;
                strNames += (",\n");
            }
            string retNames = strNames.TrimEnd(DBConstants.TRIM_CHARS);
            return retNames;
        }

        public string ForeignFieldNameColumnLnList()
        {
            string strFNames = "";
            foreach (var field in m_RelationFields)
            {
                strFNames += field.m_strForeignName;
                strFNames += (",\n");
            }
            string retFNames = strFNames.TrimEnd(DBConstants.TRIM_CHARS);
            return retFNames;
        }

        public void Delete()
        {
            m_RelationFields.Clear();
        }

        public string TableCamelName()
        {
            return m_strTable.Underscore().Camelize();
        }

        public string ConvertTableNameToCamel()
        {
            return m_strTable.ConvertNameToCamel();
        }
        public string InfoName()
        {
            return m_strTable + "::" + m_strName;
        }

        public string RelationUniqueForeignName(string nameId)
        {
            return m_strForeignTable + "." + m_RelationFields.SingleOrDefault((f) => (f.m_strName.CompareTo(nameId) == 0)).m_strForeignName;
        }

        public string RelationUniqueAllNames()
        {
            return m_strTable + "." + string.Join(".", m_RelationFields.Select((f) => (f.m_strName)).ToList());
        }

        public IList<string> DeepRelationsList(IList<TableDefInfo> tables, IList<string> agrList)
        {
            TableDefInfo tableDef = tables.FirstOrDefault((t) => (t.TableName().Equals(m_strTable)));

            if (tableDef == null)
            {
                return agrList;
            }
            return tableDef.DeepRelationsList(agrList, tables, true);
        }
        public void SetRelationField(List<RelationFieldDef> fieldList)
        {
            m_RelationFields = fieldList;
        }

        public void SetAttributes(int attributes)
        {
            m_lAttributes = attributes;
        }

        public void SetFields(int fieldCount)
        {
            m_nFields = fieldCount;
        }

        public object Clone()
        {
            RelationDefInfo other = (RelationDefInfo)this.MemberwiseClone();
            other.m_strName = this.m_strName;
            other.m_strTable = this.m_strTable;
            other.m_strColumn = this.m_strColumn;
            other.m_strForeignTable = this.m_strForeignTable;
            other.m_lAttributes = this.m_lAttributes;
            other.m_nFields = m_nFields;

            other.m_RelationFields = this.m_RelationFields.Select((r) => ((RelationFieldDef)r.Clone())).ToList();
            return other;
        }
    }
}
