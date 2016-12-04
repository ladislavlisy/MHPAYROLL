using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneTableDefInfo : ICloneable
    {
        protected const int DB_SINGLE = DBConstants.DB_SINGLE;
        protected const int DB_TEXT = DBConstants.DB_TEXT;
        protected const int DB_BOOLEAN = DBConstants.DB_BOOLEAN;
        protected const int DB_BYTE = DBConstants.DB_BYTE;
        protected const int DB_CURRENCY = DBConstants.DB_CURRENCY;
        protected const int DB_DATE = DBConstants.DB_DATE;
        protected const int DB_DATETIME = DBConstants.DB_DATETIME;
        protected const int DB_DOUBLE = DBConstants.DB_DOUBLE;
        protected const int DB_INTEGER = DBConstants.DB_INTEGER;

        protected const int DB_LONG = DBConstants.DB_LONG;
        protected const int DB_LONGBINARY = DBConstants.DB_LONGBINARY;
        protected const int DB_MEMO = DBConstants.DB_MEMO;
        protected const int DB_GUID = DBConstants.DB_GUID;

        protected static bool dbNotNullFieldOption = DBConstants.dbNotNullFieldOption;
        protected static bool dbNullFieldOption = DBConstants.dbNullFieldOption;

        protected static int dbFixedField = DBConstants.dbFixedField;
        protected static int dbUpdatableField = DBConstants.dbUpdatableField;
        protected static int dbAutoIncrField = DBConstants.dbAutoIncrField;

        protected IList<CloneTableFieldDefInfo> m_TableFields;
        protected CloneIndexDefInfo m_PKConstraint;
        protected CloneIndexDefInfo m_AKConstraint;
        protected IList<CloneIndexDefInfo> m_TableIndexs;
        protected IList<CloneRelationDefInfo> m_TableRelations;
        protected int m_nFields;
        protected string m_strOwnerName;
        protected string m_strUsersName;
        protected string m_strName;
        protected UInt32 m_VersFrom = 0;
        protected UInt32 m_VersDrop = 9999;
        protected UInt32 m_VersCreate = 0;

        public bool IsValidInVersion(UInt32 versCreate)
        {
            return (m_VersFrom <= versCreate && versCreate < m_VersDrop);
        }

        public string TableName()
        {
            return m_strName;
        }
        public CloneTableDefInfo(TableDefInfo defInfo, UInt32 versCreate)
        {
            this.m_TableFields = defInfo.TableColumns().Select((tf) => new CloneTableFieldDefInfo(tf)).ToList();
            this.m_PKConstraint = CloneIndex(defInfo.IndexPK());
            this.m_AKConstraint = CloneIndex(defInfo.IndexAK());
            this.m_TableIndexs = defInfo.IndexesNonPK().Select((idx) => new CloneIndexDefInfo(idx)).ToList();
            this.m_TableRelations = defInfo.Relations().Select((rel) => new CloneRelationDefInfo(rel)).ToList();
            this.m_nFields = defInfo.FieldsCount();
            this.m_strOwnerName = defInfo.OwnerName();
            this.m_strUsersName = defInfo.UsersName();
            this.m_strName = defInfo.TableName();
            this.m_VersFrom = defInfo.VersFrom();
            this.m_VersDrop = defInfo.VersDrop();
            this.m_VersCreate = versCreate;
        }
        private CloneIndexDefInfo CloneIndex(IndexDefInfo defInfo)
        {
            if (defInfo == null)
            {
                return null;
            }
            return new CloneIndexDefInfo(defInfo);
        }

        private IndexDefInfo CloneSourceIndex(CloneIndexDefInfo defInfo)
        {
            if (defInfo == null)
            {
                return null;
            }
            return defInfo.GetSourceInfo();
        }

        private IndexDefInfo CloneTargetIndex(CloneIndexDefInfo defInfo)
        {
            if (defInfo == null)
            {
                return null;
            }
            return defInfo.GetTargetInfo();
        }


        public TableDefInfo GetSourceInfo()
        {
            TableDefInfo defInfo = new TableDefInfo(this.m_strOwnerName, this.m_strUsersName, this.m_strName, this.m_VersFrom, this.m_VersDrop);
            defInfo.SetTableFields(this.m_TableFields.Select((tbf) => (tbf.GetSourceInfo())).ToList());
            defInfo.SetIndexPK(CloneSourceIndex(this.m_PKConstraint));
            defInfo.SetIndexAK(CloneSourceIndex(this.m_AKConstraint));
            defInfo.SetIndexesNonPK(this.m_TableIndexs.Select((idx) => (idx.GetSourceInfo())).ToList());
            defInfo.SetRelations(this.m_TableRelations.Select((rel) => (rel.GetSourceInfo())).ToList());
            defInfo.SetFields(this.m_nFields);

            return defInfo;
        }

        public TableDefInfo GetTargetInfo()
        {
            TableDefInfo defInfo = new TableDefInfo(this.m_strOwnerName, this.m_strUsersName, this.m_strName, this.m_VersFrom, this.m_VersDrop);
            defInfo.SetTableFields(this.m_TableFields.Select((tbf) => (tbf.GetTargetInfo())).ToList());
            defInfo.SetIndexPK(CloneTargetIndex(this.m_PKConstraint));
            defInfo.SetIndexAK(CloneTargetIndex(this.m_AKConstraint));
            defInfo.SetIndexesNonPK(this.m_TableIndexs.Select((idx) => (idx.GetTargetInfo())).ToList());
            defInfo.SetRelations(this.m_TableRelations.Select((rel) => (rel.GetTargetInfo())).ToList());
            defInfo.SetFields(this.m_nFields);

            return defInfo;
        }
        public IList<CloneTableFieldDefInfo> TableColumnsForVersion(UInt32 versCreate)
        {
            IList<CloneTableFieldDefInfo> columnList = m_TableFields.Where((c) => (c.IsValidInVersion(versCreate))).ToList();

            return columnList;
        }
        public CloneTableFieldDefInfo SourceFieldByName(string columnName)
        {
            IList<CloneTableFieldDefInfo> columnList = m_TableFields.Where((c) => (c.IsValidInVersion(m_VersCreate))).ToList();

            CloneTableFieldDefInfo column = columnList.Where((c) => (c.SourceName().CompareNoCase(columnName))).SingleOrDefault();

            return column;
        }

        public CloneTableFieldDefInfo TargetFieldByName(string columnName)
        {
            IList<CloneTableFieldDefInfo> columnList = m_TableFields.Where((c) => (c.IsValidInVersion(m_VersCreate))).ToList();

            CloneTableFieldDefInfo column = columnList.Where((c) => (c.TargetName().CompareNoCase(columnName))).SingleOrDefault();

            return column;
        }

        public string TargetPKUniqueAllNames()
        {
            return m_strName + "." + string.Join(".", m_PKConstraint.IndexFields().Select((f) => (f.TargetName())).ToList());
        }
        public string TargetAKUniqueAllNames()
        {
            return m_strName + "." + string.Join(".", m_AKConstraint.IndexFields().Select((f) => (f.TargetName())).ToList());
        }

        public CloneTableFieldDefInfo AutoIncrementColumn()
        {
            return m_TableFields.Where((c) => (c.IsAutoIncrement())).SingleOrDefault();
        }

        public CloneIndexDefInfo IndexPK()
        {
            return m_PKConstraint;
        }
        public IList<CloneRelationDefInfo> Relations()
        {
            return m_TableRelations;
        }
        public IList<CloneRelationDefInfo> ForeignRelations(IList<CloneTableDefInfo> tables)
        {
            return tables.SelectMany((m) => (m.Relations().Where((r) => (r.m_strTable.CompareTo(m_strName) == 0)))).ToList();
        }

        public CloneTableFieldDefInfo CreateTargetFAUTO(string lpszName, int nType, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            TableFieldDefInfo fieldInfo = TableDefInfo.CreateFAUTOInfo(lpszName, nType, versFrom, versDrop);

            CloneTableFieldDefInfo fieldClone  = new CloneTableFieldDefInfo(null, fieldInfo);

            return FieldInsertBeg(fieldClone);
        }
        public CloneTableFieldDefInfo CreateTargetField(string lpszName, int nType, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            TableFieldDefInfo fieldInfo = TableDefInfo.CreateFieldInfo(lpszName, nType, bNullOption, versFrom, versDrop);

            CloneTableFieldDefInfo fieldClone  = new CloneTableFieldDefInfo(null, fieldInfo);

            return FieldAppend(fieldClone);
        }

        private CloneTableFieldDefInfo FieldInsertBeg(CloneTableFieldDefInfo fieldInfo)
        {
            m_TableFields.Insert(0, fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        public CloneTableFieldDefInfo FieldAppend(CloneTableFieldDefInfo fieldInfo)
        {
            m_TableFields.Add(fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        public void CreateTargetIndexFromXPK(CloneIndexDefInfo primaryKey)
        {
            if (primaryKey != null)
            {
                IndexDefInfo indexInfo = (IndexDefInfo)primaryKey.GetTargetInfo();

                string indexName = indexInfo.m_strName.Replace("XPK", "XAK");

                indexInfo.m_strName = indexName;

                indexInfo.m_bPrimary = false;

                indexInfo.m_bUnique = true;

                CloneIndexDefInfo indexClone = new CloneIndexDefInfo(null, indexInfo);

                IndexAppend(indexClone);
            }
        }

        public CloneIndexDefInfo CreateTargetIndexFromXPK(CloneIndexDefInfo pkConstraint, string oldAutoName, string newAutoName)
        {
            m_AKConstraint = null;

            if (pkConstraint != null)
            {
                IndexDefInfo indexInfo = (IndexDefInfo)pkConstraint.GetTargetInfo();

                m_AKConstraint = new CloneIndexDefInfo(null, indexInfo);

                string indexName = m_AKConstraint.m_strName.Replace("XPK", "XAK");

                m_AKConstraint.m_strName = indexName;

                m_AKConstraint.m_bPrimary = false;

                m_AKConstraint.m_bUnique = true;

                m_AKConstraint.ReNameTargetColumn(oldAutoName, newAutoName);
            }
            return m_AKConstraint;
        }

        public CloneIndexDefInfo CreatePKAutoConstraint(string lpszName, string lpszIdName)
        {
            string constraintName = lpszName + m_strName;

            m_PKConstraint = new CloneIndexDefInfo(constraintName, m_strName, true);
            m_PKConstraint.AppendTargetField(lpszIdName);

            return m_PKConstraint;
        }

        public CloneIndexDefInfo IndexAppend(CloneIndexDefInfo indexInfo)
        {
            m_TableIndexs.Add(indexInfo);

            return indexInfo;
        }

        public IList<CloneIndexDefInfo> IndexesNonPK()
        {
            return m_TableIndexs;
        }
        public object Clone()
        {
            CloneTableDefInfo other = (CloneTableDefInfo)this.MemberwiseClone();
            other.m_TableFields = this.m_TableFields.Select((tf) => ((CloneTableFieldDefInfo)tf.Clone())).ToList();
            other.m_PKConstraint = (CloneIndexDefInfo)(this.m_PKConstraint.Clone());
            other.m_AKConstraint = (CloneIndexDefInfo)(this.m_AKConstraint.Clone());
            other.m_TableIndexs = this.m_TableIndexs.Select((idx) => ((CloneIndexDefInfo)idx.Clone())).ToList();
            other.m_TableRelations = this.m_TableRelations.Select((rel) => ((CloneRelationDefInfo)rel.Clone())).ToList();
            other.m_nFields = this.m_nFields;
            other.m_strOwnerName = this.m_strOwnerName;
            other.m_strUsersName = this.m_strUsersName;
            other.m_strName = this.m_strName;
            other.m_VersFrom = this.m_VersFrom;
            other.m_VersDrop = this.m_VersDrop;

            return other;
        }
    }
}
