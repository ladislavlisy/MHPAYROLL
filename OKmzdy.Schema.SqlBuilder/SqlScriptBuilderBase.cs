using OKmzdy.AppParams;
using OKmzdy.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OKmzdy.Schema.SqlBuilder
{
    public abstract class SqlScriptBuilderBase
    {
        protected const string NEW_LINE_STR = DBConstants.NEW_LINE_STR;
        public SqlScriptBuilderBase(DbsDataConfig dataParams)
        {
            this.m_strOwnerName = dataParams.OwnrName();
            this.m_strUsersName = dataParams.UserName();
        }

        protected int PlatformType { get; set; }
        protected string m_strOwnerName;
        protected string m_strUsersName;

        public string CreateTableSQL(TableDefInfo tableInfo, bool createRels, uint versCreate)
        {
            if (tableInfo == null)
            {
                return DBConstants.EMPTY_STRING;
            }

            string strFieldNames = TableColsDefinition(tableInfo, createRels, versCreate);
            string strSQL = ("CREATE TABLE ");
            strSQL += tableInfo.TableName();
            strSQL += " ";
            strSQL += strFieldNames;

            return strSQL;

        }

        private string TableColsDefinition(TableDefInfo tableInfo, bool createRels, uint versCreate)
        {
            if (tableInfo == null)
            {
                return DBConstants.EMPTY_STRING;
            }

            string strFieldNames = "(";
            foreach (var field in tableInfo.TableColumnsForVersion(versCreate))
            {
                string strFieldName = field.m_strName;
                strFieldName += " ";
                strFieldName += DbConvertDataType(field);
                strFieldName += " ";
                strFieldName += DbIdentity(field);
                strFieldName += DbNullAndDefault(field);

                strFieldNames += NEW_LINE_STR;
                strFieldNames += strFieldName.Trim();
                strFieldNames += ",";
            }
            if (createRels && DbRelationInCreateTable())
            {
                strFieldNames = StringUtils.JoinNonEmpty(NEW_LINE_STR, strFieldNames, DbRelsDefinition(tableInfo));
            }
            if (DbXPIndexInCreateTable())
            {
                strFieldNames = StringUtils.JoinNonEmpty(NEW_LINE_STR, strFieldNames, DbPKsDefinition(tableInfo));
            }

            string retTableSql = strFieldNames.TrimEnd(DBConstants.TRIM_CHARS);
            retTableSql += ")";
            retTableSql += NEW_LINE_STR;
            return retTableSql;
        }

        public string CreateTableSEQ(TableDefInfo tableDef)
        {
            return DBConstants.EMPTY_STRING;
        }

        public string CreateSequeSYN(TableDefInfo tableDef, IGeneratorWriter scriptWriter)
        {
            string countsSequeSYN = QuerySynonymCount(tableDef.TableSeqName());

            long nSeqSynonymCount = scriptWriter.GetScriptCount(countsSequeSYN);

            bool bSeqSynonymFound = (nSeqSynonymCount == 1);

            if (bSeqSynonymFound)
            {
                return DBConstants.EMPTY_STRING;
            }

            string createSequeSYN = CreateSequenceSynonym(tableDef);

            return createSequeSYN;
        }

        public string CreateTableSYN(TableDefInfo tableDef, IGeneratorWriter scriptWriter)
        {
            string countsTableSYN = QuerySynonymCount(tableDef.TableName());

            long nTabSynonymCount = scriptWriter.GetScriptCount(countsTableSYN);

            bool bTabSynonymFound = (nTabSynonymCount == 1);

            if (bTabSynonymFound)
            {
                return DBConstants.EMPTY_STRING;
            }

            string createTableSYN = CreateTableSynonym(tableDef);

            return createTableSYN;
        }


        private string DbPKsDefinition(TableDefInfo tableInfo)
        {
            if (tableInfo == null)
            {
                return DBConstants.EMPTY_STRING;
            }

            string strFieldNames = CreateConstraintSQL(tableInfo.IndexPK(), true, true);

            return strFieldNames;
        }

        private string DbAKsDefinition(TableDefInfo tableInfo)
        {
            if (tableInfo == null)
            {
                return DBConstants.EMPTY_STRING;
            }

            string strFieldNames = CreateConstraintSQL(tableInfo.IndexAK(), true, true);

            return strFieldNames;
        }

        private string DbRelsDefinition(TableDefInfo tableInfo)
        {
            if (tableInfo == null)
            {
                return DBConstants.EMPTY_STRING;
            }

            string strFieldNames = DBConstants.EMPTY_STRING;

            foreach (var item in tableInfo.Relations())
            {
                strFieldNames += CreateTableRelationSQL(item, true, true);
            }
            return strFieldNames;
        }

        private string CreateConstraintSQL(IndexDefInfo indexInfo, bool addComma, bool addNewLine)
        {
            if (indexInfo == null)
            {
                return DBConstants.EMPTY_STRING;
            }

            string sqlCommand = DBConstants.EMPTY_STRING;

            string sqlFieldsList = CreateConstraintFiledList(indexInfo.IndexFields(), indexInfo.m_bPrimary);

            sqlCommand = PlatformCreateContraintSQL(sqlFieldsList, indexInfo.m_strName, indexInfo.m_bPrimary);

            if (sqlCommand != DBConstants.EMPTY_STRING)
            {
                if (addComma)
                {
                    sqlCommand += ",";
                }
                if (addNewLine)
                {
                    sqlCommand += DBConstants.NEW_LINE_STR;
                }
            }
            return sqlCommand;
        }

        private string CreateConstraintFiledList(IList<IndexFieldDefInfo> indexFields, bool indexPrimary)
        {
            string strNames = "";

            foreach (var field in indexFields)
            {
                strNames += field.FieldInfo(indexPrimary);
                strNames += (",");
            }
            return strNames.TrimEnd(DBConstants.TRIM_CHARS);
        }

        private string CreateTableRelationSQL(RelationDefInfo relInfo, bool addComma, bool addNewLine)
        {
            if (relInfo == null)
            {
                return DBConstants.EMPTY_STRING;
            }

            string strFieldName = PlatformCreateTableRelationSQL(relInfo);
            if (strFieldName != DBConstants.EMPTY_STRING)
            {
                if (addComma)
                {
                    strFieldName += ",";
                }
                if (addNewLine)
                {
                    strFieldName += DBConstants.NEW_LINE_STR;
                }
            }
            return strFieldName;
        }

        public string CreateQuerySQL(QueryDefInfo queryInfo, uint versCreate)
        {
            if (queryInfo == null)
            {
                return DBConstants.EMPTY_STRING;
            }

            string strTableFieldNames = TableColsDefinition(queryInfo, versCreate);
            string strQueryFieldNames = QueryColsDefinition(queryInfo, versCreate);
            string strConstraintQuote = QueryConstraintDefinition(queryInfo, "\nWHERE ");
            string strEndsClauseQuote = QueryEndClausesDefinition(queryInfo, "\n ");

            string strBegin = ("CREATE VIEW ");
            strBegin += queryInfo.QueryName();
            strBegin += NEW_LINE_STR;
            strBegin += "(";
            strBegin += strQueryFieldNames;
            strBegin += ")";
            strBegin += NEW_LINE_STR;
            strBegin += "AS SELECT";
            strBegin += NEW_LINE_STR;
            strBegin += strTableFieldNames;
            strBegin += NEW_LINE_STR;
            strBegin += "FROM ";
            strBegin += strConstraintQuote;

            string strSQL = StringUtils.JoinNonEmpty(NEW_LINE_STR, strBegin, strEndsClauseQuote);
            strSQL += NEW_LINE_STR;

            return strSQL;
        }

        private string QueryColsDefinition(QueryDefInfo queryInfo, uint versCreate)
        {
            string strFieldNames = "";
            foreach (var field in queryInfo.QueryAliasNamesForVersion(versCreate))
            {
                strFieldNames += field;
                strFieldNames += ",";
                strFieldNames += NEW_LINE_STR;
            }

            string retTableSql = strFieldNames.TrimEnd(DBConstants.TRIM_CHARS);
            return retTableSql;
        }
        private string TableColsDefinition(QueryDefInfo queryInfo, uint versCreate)
        {
            string strFieldNames = "";
            foreach (var field in queryInfo.TableColumnsSourceForVersion(versCreate))
            {
                strFieldNames += field;
                strFieldNames += ",";
                strFieldNames += NEW_LINE_STR;
            }

            string retTableSql = strFieldNames.TrimEnd(DBConstants.TRIM_CHARS);
            return retTableSql;
        }
        private string QueryConstraintDefinition(QueryDefInfo queryInfo, string delimClause)
        {
            var constraintAllArray = new string[] { QueryInnerJoinDefinition(queryInfo), QueryWhereConsDefinition(queryInfo) };
            var constraintNonEmpty = constraintAllArray.Where((s) => (s.CompareNoCase("") == false)).ToList();

            return string.Join(delimClause, constraintNonEmpty);
        }
        private string QueryEndClausesDefinition(QueryDefInfo queryInfo, string delimClause)
        {
            var endClausesAllArray = queryInfo.QueryEndClauses();
            var endClausesNonEmpty = endClausesAllArray.Where((s) => (s.CompareNoCase("") == false)).ToList();

            return string.Join(delimClause, endClausesNonEmpty);
        }

        private string QueryInnerJoinDefinition(QueryDefInfo queryInfo)
        {
            bool bTbJoinConds = true;
            bool bFilterConds = DbJoinWithWhere() == false;

            string strParenthesis = DBConstants.EMPTY_STRING;

            string strFieldNames = "";

            var queryTableJoins = queryInfo.QueryTableJoins();
            if (queryTableJoins.Count == 0)
            {
                var queryTables = queryInfo.QueryTableFroms();
                strFieldNames += string.Join(",", queryTables);

                strFieldNames += NEW_LINE_STR;
            }
            else
            {
                foreach (var tableJoin in queryTableJoins)
                {
                    strParenthesis += DbJoinOpenParenthesis();

                    strFieldNames += tableJoin.QueryTableJoinConditions(queryInfo, bTbJoinConds, bFilterConds);

                    strFieldNames += DbJoinCloseParenthesis();

                    strFieldNames += NEW_LINE_STR;
                }
            }

            string retTableSql = strParenthesis + strFieldNames.TrimEnd(DBConstants.TRIM_CHARS);
            return retTableSql;
        }

        private string QueryWhereConsDefinition(QueryDefInfo queryInfo)
        {
            bool bTbJoinConds = false;
            bool bFilterConds = DbJoinWithWhere() == true;

            var queryWhereJoins = queryInfo.QueryWhereJoins(bFilterConds).Select((t) => (t.QueryTableFilterConditions(bTbJoinConds, bFilterConds))).ToList();
            var queryFiltrJoins = queryInfo.FiltrConsDefinition().ToList();

            string retTableSql = string.Join(" AND \n", queryWhereJoins.Concat(queryFiltrJoins));

            return retTableSql;
        }

        protected string GDateDefault()
        {
            return DBPlatform.GDateDefault(PlatformType);
        }

        protected string NumberDefault()
        {
            return DBPlatform.NumberDefault(PlatformType);
        }

        protected string DbTypeDefault(int nType)
        {
            if (DBPlatform.TypeIsNumber(nType))
            {
                return NumberDefault();
            }
            else if (DBPlatform.TypeIsDate(nType))
            {
                return GDateDefault();
            }
            return DBConstants.EMPTY_STRING;
        }

        protected string DbNullAndDefault(TableFieldDefInfo fieldInfo)
        {
            if (fieldInfo == null)
            {
                return DBConstants.EMPTY_STRING;
            }

            bool bColumnDefault = DbColumnDefault();
            bool bFieldDefault = (fieldInfo.m_strDefaultValue.Length != 0);

            bool bRequiredDefault = DBPlatform.DefaultBindRequired(fieldInfo.m_lAttributes);
            bool bAutoIncremField = ((fieldInfo.m_lAttributes & DBConstants.dbAutoIncrField)!=0);

            string strFieldNames = DBConstants.EMPTY_STRING;

            if (bColumnDefault)
            {
                if (fieldInfo.m_bRequired && bRequiredDefault)
                {
                    strFieldNames = StringUtils.JoinNonEmpty(" ", strFieldNames, DbTypeDefault(fieldInfo.m_nType));
                }
            }
            if (bAutoIncremField == false)
            {
                if (fieldInfo.m_bRequired)
                {
                    strFieldNames = StringUtils.JoinNonEmpty(" ", strFieldNames, "NOT NULL");
                }
                else
                {
                    strFieldNames = StringUtils.JoinNonEmpty(" ", strFieldNames, "NULL");
                }
            }
            return strFieldNames;
        }
        protected string DbIdentity(TableFieldDefInfo fieldInfo)
        {
            bool identityColumn = DBPlatform.AutoIncrField(fieldInfo.m_lAttributes);
            string strDbIdentity = DBConstants.EMPTY_STRING;
            if (identityColumn)
            {
                strDbIdentity = DbIdentitySQL();
            }
            return strDbIdentity;

        }

        public string CreateIndexSQL(IndexDefInfo indexInfo)
        {
            string strNames = indexInfo.CreateFieldsNameLnList();

            string strSQL = ("CREATE INDEX ");
            strSQL += indexInfo.m_strName;
            strSQL += (" ON ");
            strSQL += indexInfo.m_strTable;
            strSQL += (" (");
            strSQL += strNames;
            strSQL += (")");

            return strSQL;
        }

        public string AlterXPKIndexSQL(IndexDefInfo indexInfo)
        {
            string strNames = indexInfo.CreateFieldsNameLnList();

            string strSQL = ("ALTER TABLE ");
            strSQL += indexInfo.m_strTable;
            strSQL += (" ADD ");
            strSQL += PlatformCreateContraintSQL(strNames, indexInfo.m_strName, indexInfo.m_bPrimary);

            return strSQL;
        }

        protected string CreateRelationSQL(RelationDefInfo relInfo, string addBegin, string addClose)
        {
            string strCNames = relInfo.FieldNameColumnLnList();
            string strFNames = relInfo.ForeignFieldNameColumnLnList();

            string strSQL = ("ALTER TABLE ");
            strSQL += relInfo.m_strForeignTable;
            strSQL += (" ADD ");
            strSQL += addBegin;
            strSQL += ("CONSTRAINT ");
            strSQL += relInfo.m_strName;
            strSQL += (" FOREIGN KEY (");
            strSQL += strFNames;
            strSQL += (") REFERENCES ");
            strSQL += relInfo.m_strTable;
            strSQL += (" (");
            strSQL += strCNames;
            strSQL += (")");
            strSQL += addClose;

            return strSQL;
        }

        protected virtual string PlatformCreateTableRelationSQL(RelationDefInfo relInfo)
        {
            return DBConstants.EMPTY_STRING;
        }
        protected abstract string DbConvertDataType(TableFieldDefInfo fieldInfo);
        protected abstract string DbIdentitySQL();
        protected abstract bool DbColumnDefault();
        protected abstract bool DbJoinWithWhere();
        protected abstract string DbJoinOpenParenthesis();
        protected abstract string DbJoinCloseParenthesis();
        public abstract bool DbXPIndexInCreateTable();
        public abstract bool DbRelationInCreateTable();
        public abstract string CreateDefaultSQL(uint versCreate);
        public abstract string CreateDbTriggerUpd(TableDefInfo tableInfo);
        public abstract string CreateDbTriggerIns(TableDefInfo tableInfo);
        public abstract string PlatformCreateContraintSQL(string fieldsList, string indexName, bool indexPrimary);
        public abstract string CreateAlterTableRelationSQL(TableDefInfo tableInfo, RelationDefInfo relInfo);
        public abstract string QuerySynonymCount(string synonymTarget);
        public abstract string CreateSequenceSynonym(TableDefInfo tableDef);
        public abstract string CreateTableSynonym(TableDefInfo tableDef);
        public abstract string CreateTableBND(TableDefInfo tableDef, uint versCreate);
        public abstract string CreateTableSEC(TableDefInfo tableDef);
        public abstract string CreateSequeSEC(TableDefInfo tableDef);

        public abstract string CreateSwitchIndentityInsertOn(TableDefInfo tableDef, bool bIdentityOn, IGeneratorWriter scriptWriter);
        public abstract string CreateSwitchIndentityInsertOff(TableDefInfo tableDef, bool bIdentityOn, IGeneratorWriter scriptWriter);
    }
}
