using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class IndexDefInfo : ICloneable
    {
        private IList<IndexFieldDefInfo> m_IndexFields;
        public string m_strName;
        public string m_strTable;
        private int m_nFields;
        public bool m_bUnique;
        public bool m_bPrimary;

        public IndexDefInfo()
        {
            m_IndexFields = new List<IndexFieldDefInfo>();
            m_strName = "";
            m_strTable = "";
            m_nFields = 0;
            m_bPrimary = false;
            m_bUnique = false;
        }

        public IndexDefInfo(string lpszName, string lpszTable, bool primary = false)
        {
            m_IndexFields = new List<IndexFieldDefInfo>();
            m_strName = lpszName;
            m_strTable = lpszTable;
            m_nFields = 0;
            m_bPrimary = primary;
            m_bUnique = false;
        }
        public IList<IndexFieldDefInfo> IndexFields()
        {
            return m_IndexFields;
        }

        public void AppendField(string lpszName, bool descending = false)
        {
            IndexFieldDefInfo fieldInfo = new IndexFieldDefInfo(lpszName, descending);

            m_IndexFields.Add(fieldInfo);
            m_nFields++;
        }

        public int FieldsCount()
        {
            return m_nFields;
        }
        public string CreateFieldsNameList()
        {
            string strNames = "";

            foreach (var field in m_IndexFields)
            {
                strNames += field.FieldInfo(m_bPrimary);
                strNames += (",");
            }
            return strNames.TrimEnd(DBConstants.TRIM_CHARS);
        }
        public string CreateFieldsNameLnList()
        {
            string strNames = "";

            foreach (var field in m_IndexFields)
            {
                strNames += field.FieldInfo(m_bPrimary);
                strNames += (",\n");
            }
            return strNames.TrimEnd(DBConstants.TRIM_CHARS);
        }

        public string[] CreateFieldsNamesArray()
        {
            List<string> strNames = new List<string>();
            foreach (var field in m_IndexFields)
            {
                strNames.Add(field.m_strName);
            }
            return strNames.ToArray();
        }

        public void Delete()
        {
            m_IndexFields.Clear();
        }


        public string InfoName()
        {
            return m_strTable + "::" + m_strName;
        }

        public void ReNameColumn(string oldColumnName, string newColumnName)
        {
            IndexFieldDefInfo indexField = m_IndexFields.SingleOrDefault((f) => (f.m_strName.CompareTo(oldColumnName) == 0));
            if (indexField != null)
            {
                indexField.m_strName = newColumnName;
            }
        }

        public void SetIndexFields(List<IndexFieldDefInfo> fieldList)
        {
            m_IndexFields = fieldList;
        }

        public void SetFields(int fieldCount)
        {
            m_nFields = fieldCount;
        }

        public void SetUnique(bool uniqueIndex)
        {
            m_bUnique = uniqueIndex;
        }

        public object Clone()
        {
            IndexDefInfo other = (IndexDefInfo)this.MemberwiseClone();
            other.m_strName = this.m_strName;
            other.m_strTable = this.m_strTable;
            other.m_nFields = this.m_nFields;
            other.m_bUnique = this.m_bUnique;
            other.m_bPrimary = this.m_bPrimary;

            other.m_IndexFields = this.m_IndexFields.Select((f) => ((IndexFieldDefInfo)f.Clone())).ToList();
            return other;
        }
    }
}
