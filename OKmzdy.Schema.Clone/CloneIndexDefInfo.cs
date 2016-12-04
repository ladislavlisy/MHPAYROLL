using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneIndexDefInfo : ICloneable
    {
        private IList<CloneIndexFieldDefInfo> m_IndexFields;
        public string m_strName;
        public string m_strTable;
        private int m_nFields;
        public bool m_bUnique;
        public bool m_bPrimary;
        public CloneIndexDefInfo(IndexDefInfo defInfo)
        {
            this.m_IndexFields = defInfo.IndexFields().Select((idxf) => new CloneIndexFieldDefInfo(idxf)).ToList();
            this.m_strName = defInfo.m_strName;
            this.m_strTable = defInfo.m_strTable;
            this.m_nFields = defInfo.FieldsCount();
            this.m_bUnique = defInfo.m_bUnique;
            this.m_bPrimary = defInfo.m_bPrimary;
        }
        public CloneIndexDefInfo(IndexDefInfo defSource, IndexDefInfo defTarget)
        {
            if (defSource != null)
            {
                this.m_IndexFields = defSource.IndexFields().Select((idxf) => new CloneIndexFieldDefInfo(idxf, null)).ToList();
                this.m_strName = defSource.m_strName;
                this.m_strTable = defSource.m_strTable;
                this.m_nFields = defSource.FieldsCount();
                this.m_bUnique = defSource.m_bUnique;
                this.m_bPrimary = defSource.m_bPrimary;
            }
            else if (defTarget != null)
            {
                this.m_IndexFields = defTarget.IndexFields().Select((idxf) => new CloneIndexFieldDefInfo(null, idxf)).ToList();
                this.m_strName = defTarget.m_strName;
                this.m_strTable = defTarget.m_strTable;
                this.m_nFields = defTarget.FieldsCount();
                this.m_bUnique = defTarget.m_bUnique;
                this.m_bPrimary = defTarget.m_bPrimary;
            }
        }
        public CloneIndexDefInfo(string lpszName, string lpszTable, bool primary = false)
        {
            m_IndexFields = new List<CloneIndexFieldDefInfo>();
            m_strName = lpszName;
            m_strTable = lpszTable;
            m_nFields = 0;
            m_bPrimary = primary;
            m_bUnique = false;
        }
        public IndexDefInfo GetSourceInfo()
        {
            IndexDefInfo defInfo = new IndexDefInfo(this.m_strName, this.m_strTable, this.m_bPrimary);
            defInfo.SetIndexFields(this.m_IndexFields.Select((idxf) => (idxf.GetSourceInfo())).ToList());
            defInfo.SetFields(this.m_nFields);
            defInfo.SetUnique(this.m_bUnique);

            return defInfo;
        }

        public IndexDefInfo GetTargetInfo()
        {
            IndexDefInfo defInfo = new IndexDefInfo(this.m_strName, this.m_strTable, this.m_bPrimary);
            defInfo.SetIndexFields(this.m_IndexFields.Select((idxf) => (idxf.GetTargetInfo())).ToList());
            defInfo.SetFields(this.m_nFields);
            defInfo.SetUnique(this.m_bUnique);

            return defInfo;
        }

        public void AppendTargetField(string lpszName, bool descending = false)
        {
            IndexFieldDefInfo fieldInfo = new IndexFieldDefInfo(lpszName, descending);

            CloneIndexFieldDefInfo fieldClone = new CloneIndexFieldDefInfo(null, fieldInfo);

            m_IndexFields.Add(fieldClone);

            m_nFields++;
        }

        public void ReNameTargetColumn(string oldColumnName, string newColumnName)
        {
            CloneIndexFieldDefInfo indexField = m_IndexFields.SingleOrDefault((f) => (f.SourceName().CompareTo(oldColumnName) == 0));
            if (indexField != null)
            {
                indexField.SetTargetName(newColumnName);
            }
        }

        public IList<CloneIndexFieldDefInfo> IndexFields()
        {
            return m_IndexFields;
        }

        public object Clone()
        {
            CloneIndexDefInfo other = (CloneIndexDefInfo)this.MemberwiseClone();
            other.m_IndexFields = this.m_IndexFields.Select((idxf) => ((CloneIndexFieldDefInfo)idxf.Clone())).ToList();
            other.m_strName = this.m_strName;
            other.m_strTable = this.m_strTable;
            other.m_nFields = this.m_nFields;
            other.m_bUnique = this.m_bUnique;
            other.m_bPrimary = this.m_bPrimary;

            return other;
        }

    }
}
