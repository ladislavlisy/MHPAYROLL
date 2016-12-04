using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class TableDefInfo : ICloneable
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

        protected IList<TableFieldDefInfo> m_TableFields;
        protected IndexDefInfo m_PKConstraint;
        protected IndexDefInfo m_AKConstraint;
        protected IList<IndexDefInfo> m_TableIndexs;
        protected IList<RelationDefInfo> m_TableRelations;
        protected int m_nFields;
        protected string m_strOwnerName;
        protected string m_strUsersName;
        protected string m_strName;
        protected UInt32 m_VersFrom = 0;
        protected UInt32 m_VersDrop = 9999;

        public bool IsValidInVersion(UInt32 versCreate)
        {
            return (m_VersFrom <= versCreate && versCreate < m_VersDrop);
        }

        public string OwnerName()
        {
            return m_strOwnerName;
        }

        public string UsersName()
        {
            return m_strUsersName;
        }

        public string TableName()
        {
            return m_strName;
        }

        public UInt32 VersFrom()
        {
            return m_VersFrom;
        }

        public UInt32 VersDrop()
        {
            return m_VersDrop;
        }


        public string TableSeqName()
        {
            return ("SEQ_") + m_strName;
        }

        public string TableCamelName()
        {
            return m_strName.Underscore().Camelize();
        }

        public string ConvertTableNameToCamel()
        {
            return m_strName.ConvertNameToCamel();
        }

        public bool EnforceRelation(RelationDefInfo relInfo)
        {
            var relationFields = m_TableFields.Where((f) => relInfo.RelationFieldByName(f.m_strName)!= null);

            return relationFields.Any((rf) => (rf.DbColumnNull()))==false;
        }

        public void ReNameTable(string tableName)
        {
            m_strName = tableName;
        }

        public void ReNameTableColumn(string oldName, string newName)
        {
            foreach (var column in m_TableFields)
            {
                if (column.ColumnName().Equals(oldName))
                {
                    column.ReNameColumn(newName);
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            TableDefInfo objAsDef = obj as TableDefInfo;
            if (objAsDef == null) return false;
            else return Equals(objAsDef);
        }
        public int SortByNameAscending(string name1, string name2)
        {
            return name1.CompareTo(name2);
        }

        public void CreateIndexFromXPK(IndexDefInfo primaryKey)
        {
            if (primaryKey != null)
            {
                IndexDefInfo indexInfo = (IndexDefInfo)primaryKey.Clone();

                string indexName = indexInfo.m_strName.Replace("XPK", "XAK");

                indexInfo.m_strName = indexName;

                indexInfo.m_bPrimary = false;

                indexInfo.m_bUnique = true;

                IndexAppend(indexInfo);
            }
        }

        public IndexDefInfo CreateIndexFromXPK(IndexDefInfo pkConstraint, string oldAutoName, string newAutoName)
        {
            m_AKConstraint = null;

            if (pkConstraint != null)
            {
                m_AKConstraint = (IndexDefInfo)pkConstraint.Clone();

                string indexName = m_AKConstraint.m_strName.Replace("XPK", "XAK");

                m_AKConstraint.m_strName = indexName;

                m_AKConstraint.m_bPrimary = false;

                m_AKConstraint.m_bUnique = true;

                m_AKConstraint.ReNameColumn(oldAutoName, newAutoName);
            }
            return m_AKConstraint;
        }

        // Default comparer for Part type.
        public int CompareTo(TableDefInfo compareDef)
        {
            // A null value means that this object is greater.
            if (compareDef == null)
                return 1;

            else
                return this.m_strName.CompareTo(compareDef.m_strName);
        }
        public override int GetHashCode()
        {
            return m_strName.GetHashCode();
        }
        public bool Equals(TableDefInfo other)
        {
            if (other == null) return false;
            return (this.m_strName.Equals(other.m_strName));
        }

        public string InfoName()
        {
            return m_strName;
        }

        public TableDefInfo(string lpszOwnerName, string lpszUsersName, string lpszTableName, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            this.m_strOwnerName = lpszOwnerName;
            this.m_strUsersName = lpszUsersName;
            this.m_TableFields = new List<TableFieldDefInfo>();
            m_PKConstraint = null;
            m_AKConstraint = null;
            this.m_TableIndexs = new List<IndexDefInfo>();
            this.m_TableRelations = new List<RelationDefInfo>();
            this.m_strName = lpszTableName;
            this.m_VersFrom = versFrom;
            this.m_VersDrop = versDrop;
        }

        public bool IsAutoIncrement(string columnName)
        {
            TableFieldDefInfo column = m_TableFields.Where((c) => (c.m_strName.Equals(columnName))).SingleOrDefault();
            if (column != null)
            {
                return column.IsAutoIncrement();
            }
            return false;
        }


        public TableFieldDefInfo GetAutoIncrementColumn()
        {
            return m_TableFields.Where((c) => (c.IsAutoIncrement())).SingleOrDefault();
        }

        public TableFieldDefInfo GetAutoIncrementColumn(UInt32 versCreate)
        {
            IList<TableFieldDefInfo> columnList = m_TableFields.Where((c) => (c.IsValidInVersion(versCreate))).ToList();

            TableFieldDefInfo column = columnList.Where((c) => (c.IsAutoIncrement())).SingleOrDefault();

            return column;
        }
        public IList<TableFieldDefInfo> TableColumnsForVersion(UInt32 versCreate)
        {
            IList<TableFieldDefInfo> columnList = m_TableFields.Where((c) => (c.IsValidInVersion(versCreate))).ToList();

            return columnList;
        }
        public TableFieldDefInfo FieldByName(string columnName)
        {
            TableFieldDefInfo column = m_TableFields.Where((c) => (c.m_strName.Equals(columnName))).SingleOrDefault();

            return column;
        }

        public bool HasAutoIncrementColumn()
        {
            TableFieldDefInfo column = GetAutoIncrementColumn();
            if (column != null)
            {
                return true;
            }
            return false;
        }
        public IList<string> PrimaryKeyColumnList()
        {
            if (m_PKConstraint != null)
            {
                return m_PKConstraint.CreateFieldsNamesArray().Select((x) => NameConversions.CamelName(x)).ToList();
            }
            return new List<string>();
        }
        public IList<string> AlternateKeyColumnList()
        {
            if (m_AKConstraint != null)
            {
                return m_AKConstraint.CreateFieldsNamesArray().Select((x) => NameConversions.CamelName(x)).ToList();
            }
            return new List<string>();
        }
        public IList<string> RelationForeignTables()
        {
            if (m_TableRelations != null)
            {
                return m_TableRelations.Select((x) => (x.m_strTable)).ToList();
            }
            return new List<string>();
        }

        virtual public string ClassColumnName(string columnName)
        {
            return columnName;
        }

        protected static string PropertyName(Tuple<string, string>[] changeNames, string columnName)
        {
            Tuple<string, string> propertyName = changeNames.FirstOrDefault((x) => (x.Item1.Equals(columnName)));
            if (propertyName == null)
            {
                return columnName;
            }
            return propertyName.Item2;
        }

        public IList<TableFieldDefInfo> TableColumns()
        {
            return m_TableFields;
        }
        public int FieldsCount()
        {
            return m_nFields;
        }
        public IndexDefInfo IndexPK()
        {
            return m_PKConstraint;
        }

        public IndexDefInfo IndexAK()
        {
            return m_AKConstraint;
        }

        public string CreatePKFieldsNameList()
        {
            if (m_PKConstraint == null)
            {
                return "";
            }
            return m_PKConstraint.CreateFieldsNameList();
        }
        public string CreateAKFieldsNameList()
        {
            if (m_AKConstraint == null)
            {
                return "";
            }
            return m_AKConstraint.CreateFieldsNameList();
        }
        public string PKUniqueAllNames()
        {
            return m_strName + "." + string.Join(".", m_PKConstraint.IndexFields().Select((f) => (f.m_strName)).ToList());
        }
        public string AKUniqueAllNames()
        {
            return m_strName + "." + string.Join(".", m_AKConstraint.IndexFields().Select((f) => (f.m_strName)).ToList());
        }
        public IList<IndexDefInfo> IndexesNonPK()
        {
            return m_TableIndexs;
        }
        public IList<RelationDefInfo> Relations()
        {
            return m_TableRelations;
        }

        public TableFieldDefInfo FieldAppend(TableFieldDefInfo fieldInfo)
        {
            m_TableFields.Add(fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        private TableFieldDefInfo FieldInsertBeg(TableFieldDefInfo fieldInfo)
        {
            m_TableFields.Insert(0, fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        private TableFieldDefInfo FieldInsertIdx(TableFieldDefInfo fieldInfo, int index)
        {
            m_TableFields.Insert(Math.Min(index, m_nFields), fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        private IndexDefInfo IndexAppend(IndexDefInfo indexInfo)
        {
            m_TableIndexs.Add(indexInfo);

            return indexInfo;
        }

        private RelationDefInfo RelationAppend(RelationDefInfo relationInfo)
        {
            m_TableRelations.Add(relationInfo);

            return relationInfo;
        }

        public static TableFieldDefInfo CreateFieldInfo(string lpszName, int nType, bool bNullOption, UInt32 versFrom, UInt32 versDrop)
        {
            TableFieldDefInfo fieldInfo = new TableFieldDefInfo(versFrom, versDrop);
            fieldInfo.m_strName = lpszName;
            fieldInfo.m_nType = nType;

            fieldInfo.m_bAllowZeroLength = false;
            fieldInfo.m_bRequired = !bNullOption;
            fieldInfo.m_lCollatingOrder = 0;
            fieldInfo.m_nOrdinalPosition = 0;
            fieldInfo.m_strDefaultValue = "";
            fieldInfo.m_strValidationRule = "";
            fieldInfo.m_strValidationText = "";
            fieldInfo.m_lAttributes = DBConstants.dbFixedField | DBConstants.dbUpdatableField;
            fieldInfo.m_lSize = FieldSize(nType);
            fieldInfo.m_strDefaultValue = FieldDefaultValue(nType, bNullOption);
            return (fieldInfo);
        }

        public TableFieldDefInfo CreateField(string lpszName, int nType, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            TableFieldDefInfo fieldInfo = CreateFieldInfo(lpszName, nType, bNullOption, versFrom, versDrop);

            return FieldAppend(fieldInfo);
        }

        public TableFieldDefInfo InsertField(int index, string lpszName, int nType, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            TableFieldDefInfo fieldInfo = CreateFieldInfo(lpszName, nType, bNullOption, versFrom, versDrop);

            return FieldInsertIdx(fieldInfo, index);
        }

        public static TableFieldDefInfo CreateFTEXTInfo(string lpszName, int nType, int size, bool bNullOption, UInt32 versFrom, UInt32 versDrop)
        {
            TableFieldDefInfo fieldInfo = new TableFieldDefInfo(versFrom, versDrop);
            fieldInfo.m_strName = lpszName;
            fieldInfo.m_nType = nType;

            fieldInfo.m_lAttributes = DBConstants.dbUpdatableField;
            fieldInfo.m_bAllowZeroLength = true;
            fieldInfo.m_lSize = size;
            fieldInfo.m_bRequired = !bNullOption;
            fieldInfo.m_lCollatingOrder = 0;
            fieldInfo.m_nOrdinalPosition = 0;
            fieldInfo.m_strDefaultValue = "";
            fieldInfo.m_strValidationRule = "";
            fieldInfo.m_strValidationText = "";

            return (fieldInfo);
        }

        public TableFieldDefInfo CreateFTEXT(string lpszName, int nType, int size, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            TableFieldDefInfo fieldInfo = CreateFTEXTInfo(lpszName, nType, size, bNullOption, versFrom, versDrop);

            return FieldAppend(fieldInfo);
        }

        public TableFieldDefInfo InsertFTEXT(int index, string lpszName, int nType, int size, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            TableFieldDefInfo fieldInfo = CreateFTEXTInfo(lpszName, nType, size, bNullOption, versFrom, versDrop);

            return FieldInsertIdx(fieldInfo, index);
        }

        public static TableFieldDefInfo CreateGDATEInfo(string lpszName, int nType, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            TableFieldDefInfo fieldInfo = new TableFieldDefInfo(versFrom, versDrop);
            fieldInfo.m_strName = lpszName;
            fieldInfo.m_nType = nType;

            fieldInfo.m_bAllowZeroLength = false;
            fieldInfo.m_bRequired = !bNullOption;
            fieldInfo.m_lCollatingOrder = 0;
            fieldInfo.m_nOrdinalPosition = 0;
            fieldInfo.m_strDefaultValue = "";
            fieldInfo.m_strValidationRule = "";
            fieldInfo.m_strValidationText = "";
            fieldInfo.m_lAttributes = DBConstants.dbFixedField | DBConstants.dbUpdatableField;
            fieldInfo.m_lSize = FieldSize(nType);
            if (fieldInfo.m_bRequired)
            {
                fieldInfo.m_strDefaultValue = "*";
            }

            return (fieldInfo);
        }

        public TableFieldDefInfo CreateGDATE(string lpszName, int nType, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            TableFieldDefInfo fieldInfo = CreateGDATEInfo(lpszName, nType, bNullOption, versFrom, versDrop);

            return FieldAppend(fieldInfo);
        }

        public TableFieldDefInfo InsertGDATE(int index, string lpszName, int nType, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            TableFieldDefInfo fieldInfo = CreateGDATEInfo(lpszName, nType, bNullOption, versFrom, versDrop);

            return FieldInsertIdx(fieldInfo, index);
        }

        public static TableFieldDefInfo CreateFAUTOInfo(string lpszName, int nType, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            TableFieldDefInfo fieldInfo = new TableFieldDefInfo(versFrom, versDrop);
            fieldInfo.m_strName = lpszName;
            fieldInfo.m_nType = nType;

            fieldInfo.m_bAllowZeroLength = false;
            fieldInfo.m_bRequired = true;
            fieldInfo.m_lCollatingOrder = 0;
            fieldInfo.m_nOrdinalPosition = 0;
            fieldInfo.m_strDefaultValue = "";
            fieldInfo.m_strValidationRule = "";
            fieldInfo.m_strValidationText = "";
            fieldInfo.m_lAttributes = DBConstants.dbFixedField | DBConstants.dbAutoIncrField | DBConstants.dbUpdatableField;
            fieldInfo.m_lSize = FieldSize(nType);

            return fieldInfo;
        }

        public TableFieldDefInfo CreateFAUTO(string lpszName, int nType)
        {
            TableFieldDefInfo fieldInfo = CreateFAUTOInfo(lpszName, nType);

            return FieldInsertBeg(fieldInfo);
        }

        public IndexDefInfo CreateIndex(string lpszName, bool bUnique = false)
        {
            IndexDefInfo indexInfo = new IndexDefInfo(lpszName, m_strName, false);
            indexInfo.m_bUnique = bUnique;

            return IndexAppend(indexInfo);
        }

        public RelationDefInfo CreateRelation(string lpszName, string lpszRelTable, string lpszRelColumn)
        {
            RelationDefInfo indexInfo = new RelationDefInfo(lpszName, m_strName, lpszRelTable, lpszRelColumn);

            return RelationAppend(indexInfo);
        }

        public IList<RelationDefInfo> ForeignRelations(IList<TableDefInfo> tables)
        {
            return tables.SelectMany((m) => (m.Relations().Where((r) => (r.m_strTable.CompareTo(m_strName) == 0)))).ToList();
        }

        private static string CreateConstraintName(string constraintColl, string keyName, string autoRefId)
        {
            string constraintName;
            string keyNameEx1 = "_" + keyName;
            string keyNameEx2 = keyName + "_";

            if (constraintColl.EndsWith(keyNameEx1))
            {
                constraintName = constraintColl.Replace(keyNameEx1, autoRefId);
            }
            else if (constraintColl.Contains(keyNameEx2))
            {
                constraintName = constraintColl.Replace(keyNameEx2, "") + autoRefId;
            }
            else
            {
                constraintName = constraintColl + autoRefId;
            }

            return constraintName;
        }

        private static int FieldSize(int nType)
        {
            int fieldInfoSize = 0;
            switch (nType)
            {
                case DBConstants.DB_BOOLEAN:
                    fieldInfoSize = 1;
                    break;
                case DBConstants.DB_BYTE:
                    fieldInfoSize = 1;
                    break;
                case DBConstants.DB_INTEGER:
                    fieldInfoSize = 2;
                    break;
                case DBConstants.DB_LONG:
                    fieldInfoSize = 4;
                    break;
                case DBConstants.DB_CURRENCY:
                    fieldInfoSize = 8;
                    break;
                case DBConstants.DB_SINGLE:
                    fieldInfoSize = 4;
                    break;
                case DBConstants.DB_DOUBLE:
                    fieldInfoSize = 8;
                    break;
                case DBConstants.DB_DATE:
                    fieldInfoSize = 8;
                    break;
                case DBConstants.DB_LONGBINARY:
                    fieldInfoSize = 0;
                    break;
                default:
                    fieldInfoSize = 0;
                    break;
            }
            return fieldInfoSize;
        }

        private static string FieldDefaultValue(int nType, bool bNullOption)
        {
            string fieldInfoDefaultValue = "";
            switch (nType)
            {
                case DBConstants.DB_BOOLEAN:
                    if (!bNullOption)
                    {
                        fieldInfoDefaultValue = "0";
                    }
                    break;
                case DBConstants.DB_BYTE:
                    if (!bNullOption)
                    {
                        fieldInfoDefaultValue = "0";
                    }
                    break;
                case DBConstants.DB_INTEGER:
                    if (!bNullOption)
                    {
                        fieldInfoDefaultValue = "0";
                    }
                    break;
                case DBConstants.DB_LONG:
                    if (!bNullOption)
                    {
                        fieldInfoDefaultValue = "0";
                    }
                    break;
                case DBConstants.DB_CURRENCY:
                    break;
                case DBConstants.DB_SINGLE:
                    break;
                case DBConstants.DB_DOUBLE:
                    break;
                case DBConstants.DB_DATE:
                    break;
                case DBConstants.DB_LONGBINARY:
                    break;
                default:
                    break;
            }
            return fieldInfoDefaultValue;
        }

        void Clear()
        {
            m_strName = "";
            m_TableFields.Clear();
            m_nFields = 0;
            m_PKConstraint = null;
            m_AKConstraint = null;
            m_TableIndexs.Clear();
            m_TableRelations.Clear();
        }

        public IndexDefInfo CreatePKConstraint(string lpszName)
        {
            string constraintName = lpszName + m_strName;

            m_PKConstraint = new IndexDefInfo(constraintName, m_strName, true);

            return m_PKConstraint;
        }

        public IndexDefInfo CreateAKConstraint(string lpszName)
        {
            string constraintName = lpszName + m_strName;

            m_AKConstraint = new IndexDefInfo(constraintName, m_strName, true);

            return m_AKConstraint;
        }

        public IndexDefInfo CreateAKAutoConstraint(string lpszName, string lpszIdName)
        {
            string constraintName = lpszName + m_strName;

            m_AKConstraint = new IndexDefInfo(constraintName, m_strName, true);
            m_AKConstraint.AppendField(lpszIdName);

            return m_AKConstraint;
        }

        public IndexDefInfo AddTableIndex(string lpszName)
        {
            IndexDefInfo indexInfo = new IndexDefInfo(lpszName, m_strName, false);

            return indexInfo;
        }

        public string CreateColumnList(UInt32 versCreate)
        {
            string columnsList = "";

            foreach (TableFieldDefInfo field in m_TableFields)
            {
                if (field.IsValidInVersion(versCreate))
                {
                    columnsList += field.m_strName;
                    columnsList += ", ";
                }
            }
            string columnListRet = columnsList.TrimEnd(DBConstants.TRIM_CHARS);

            return columnListRet;
        }

        public IList<string> DeepRelationsList(IList<string> agrList, IList<TableDefInfo> tables, bool addTableName)
        {
            IList<string> retList = agrList.ToList();
            if (addTableName)
            {
                retList = agrList.Concat(new string[] { m_strName }).ToList();
            }

            if (m_TableRelations.Count == 0)
            {
                return retList;
            }

            return m_TableRelations.Aggregate(retList, (agr, r) => r.DeepRelationsList(tables, agr));
        }

        public string CreateSelectCountTableRow()
        {
            string sqlCommand = "SELECT count(*) AS POCET FROM ";

            sqlCommand += TableName();

            return sqlCommand;
        }

        public string CreateSelectCommand(UInt32 versCreate)
        {
            string sqlCommand = "SELECT ";

            sqlCommand += CreateColumnList(versCreate);

            sqlCommand += " FROM ";
            sqlCommand += TableName();

            return sqlCommand;
        }

        #region ICloneable Members

        public object Clone()
        {
            TableDefInfo other = (TableDefInfo)this.MemberwiseClone();
            other.m_VersFrom = this.m_VersFrom;
            other.m_VersDrop = this.m_VersDrop;
            other.m_strName = this.m_strName;
            other.m_strOwnerName = this.m_strOwnerName;
            other.m_strUsersName = this.m_strUsersName;
            other.m_nFields = this.m_nFields;
            if (this.m_PKConstraint != null)
            {
                other.m_PKConstraint = (IndexDefInfo)this.m_PKConstraint.Clone();
            }
            else
            {
                other.m_PKConstraint = this.m_PKConstraint;
            }

            if (this.m_AKConstraint != null)
            {
                other.m_AKConstraint = (IndexDefInfo)this.m_AKConstraint.Clone();
            }
            else
            {
                other.m_AKConstraint = this.m_AKConstraint;
            }

            other.m_TableFields = this.m_TableFields.Select((f) => ((TableFieldDefInfo)f.Clone())).ToList();
            other.m_TableIndexs = this.m_TableIndexs.Select((i) => ((IndexDefInfo)i.Clone())).ToList();
            other.m_TableRelations = this.m_TableRelations.Select((r) => ((RelationDefInfo)r.Clone())).ToList();
            return other;
        }

        #endregion

        public void SetTableFields(IList<TableFieldDefInfo> fieldList)
        {
            m_TableFields = fieldList;
        }
        public void SetIndexPK(IndexDefInfo indexInfo)
        {
            m_PKConstraint = indexInfo;
        }
        public void SetIndexAK(IndexDefInfo indexInfo)
        {
            m_AKConstraint = indexInfo;
        }
        public void SetIndexesNonPK(IList<IndexDefInfo> indexList)
        {
            m_TableIndexs = indexList;
        }

        public void SetRelations(IList<RelationDefInfo> relsList)
        {
            m_TableRelations = relsList;
        }

        public void SetFields(int fieldCount)
        {
            m_nFields = fieldCount;
        }

    }
}
