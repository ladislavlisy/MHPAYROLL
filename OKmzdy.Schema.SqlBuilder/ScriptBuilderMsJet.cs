using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKmzdy.AppParams;

namespace OKmzdy.Schema.SqlBuilder
{
    public class ScriptBuilderMsJet : SqlScriptBuilderBase
    {
        public ScriptBuilderMsJet(DbsDataConfig dataParams) : base(dataParams)
        {
            this.PlatformType = DBPlatform.DATA_PROVIDER_JET35;
        }

        protected override string DbConvertDataType(TableFieldDefInfo fieldInfo)
        {
            string strFieldType = DBPlatform.MsJetConvertDataType(fieldInfo.m_nType, fieldInfo.m_lSize);

            return strFieldType;
        }

        protected override string DbIdentitySQL()
        {
            string strDbIdentity = "IDENTITY(1,1) ";

            return strDbIdentity;
        }

        protected override bool DbColumnDefault()
        {
            return true;
        }

        protected override bool DbJoinWithWhere()
        {
            return true;
        }
        protected override string DbJoinOpenParenthesis()
        {
            return "(";
        }
        protected override string DbJoinCloseParenthesis()
        {
            return ")";
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

        public override string CreateAlterTableRelationSQL(TableDefInfo tableInfo, RelationDefInfo relInfo)
        {
            string addBegin = DBConstants.EMPTY_STRING;
            string addClose = DBConstants.EMPTY_STRING;

            if (tableInfo.EnforceRelation(relInfo))
            {
                return CreateRelationSQL(relInfo, addBegin, addClose);
            }

            return DBConstants.EMPTY_STRING;
        }

        public override string CreateTableBND(TableDefInfo tableDef, uint versCreate)
        {
            return DBConstants.EMPTY_STRING;
        }

        public override bool DbXPIndexInCreateTable()
        {
            return false;
        }

        public override bool DbRelationInCreateTable()
        {
            return false;
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
