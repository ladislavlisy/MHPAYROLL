using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKmzdy.AppParams;

namespace OKmzdy.Schema.SqlBuilder
{
    public class ScriptBuilderSqlite : SqlScriptBuilderBase
    {
        public ScriptBuilderSqlite(DbsDataConfig dataParams) : base(dataParams)
        {
            this.PlatformType = DBPlatform.DATA_PROVIDER_SQLITE;
        }

        protected override string DbConvertDataType(TableFieldDefInfo fieldInfo)
        {
            string strFieldType = DBPlatform.SqliteConvertDataType(fieldInfo.m_nType, fieldInfo.m_lSize);

            return strFieldType;
        }

        protected override string DbIdentitySQL()
        {
            return DBConstants.EMPTY_STRING;
        }

        protected override bool DbJoinWithWhere()
        {
            return false;
        }
        protected override string DbJoinOpenParenthesis()
        {
            return DBConstants.EMPTY_STRING;
        }
        protected override string DbJoinCloseParenthesis()
        {
            return DBConstants.EMPTY_STRING;
        }
        protected override bool DbColumnDefault()
        {
            return true;
        }

        public override string CreateDefaultSQL(uint versCreate)
        {
            return DBConstants.EMPTY_STRING;
        }

        public override string CreateDbTriggerUpd(TableDefInfo tableInfo)
        {
            return DBConstants.EMPTY_STRING;
        }

        public override string CreateDbTriggerIns(TableDefInfo tableInfo)
        {
            return DBConstants.EMPTY_STRING;
        }

        public override string PlatformCreateContraintSQL(string fieldsList, string indexName, bool indexPrimary)
        {
            string strSQL = DBConstants.EMPTY_STRING;
            if (indexPrimary)
            {
                strSQL = ("CONSTRAINT ");
                strSQL += indexName;
                strSQL += (" PRIMARY KEY (");
                strSQL += fieldsList;
                strSQL += (")");
            }
            return strSQL;
        }

        protected override string PlatformCreateTableRelationSQL(RelationDefInfo relInfo)
        {
            string strCNames = relInfo.FieldNameColumnLnList();
            string strFNames = relInfo.ForeignFieldNameColumnLnList();

            string strSQL = ("");
            strSQL += ("FOREIGN KEY(");
            strSQL += strFNames;
            strSQL += (") REFERENCES ");
            strSQL += relInfo.m_strTable;
            strSQL += ("(");
            strSQL += strCNames;
            strSQL += (")");
            return strSQL;
        }


        public override string CreateAlterTableRelationSQL(TableDefInfo tableInfo, RelationDefInfo relInfo)
        {
            return DBConstants.EMPTY_STRING;
        }

        public override string CreateTableBND(TableDefInfo tableDef, uint versCreate)
        {
            return DBConstants.EMPTY_STRING;
        }

        public override bool DbXPIndexInCreateTable()
        {
            return true;
        }

        public override bool DbRelationInCreateTable()
        {
            return true;
        }

        public override string CreateSequenceSynonym(TableDefInfo tableDef)
        {
            return DBConstants.EMPTY_STRING;
        }

        public override string CreateTableSynonym(TableDefInfo tableDef)
        {
            return DBConstants.EMPTY_STRING;
        }

        public override string QuerySynonymCount(string synonymTarget)
        {
            return DBConstants.EMPTY_STRING;
        }
        public override string CreateTableSEC(TableDefInfo tableDef)
        {
            return DBConstants.EMPTY_STRING;
        }

        public override string CreateSequeSEC(TableDefInfo tableDef)
        {
            return DBConstants.EMPTY_STRING;
        }

        public override string CreateSwitchIndentityInsertOn(TableDefInfo tableDef, bool bIdentityOn, IGeneratorWriter scriptWriter)
        {
            return DBConstants.EMPTY_STRING;
        }

        public override string CreateSwitchIndentityInsertOff(TableDefInfo tableDef, bool bIdentityOn, IGeneratorWriter scriptWriter)
        {
            return DBConstants.EMPTY_STRING;
        }
    }
}
