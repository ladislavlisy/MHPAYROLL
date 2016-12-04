using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKmzdy.AppParams;

namespace OKmzdy.Schema.SqlBuilder
{
    public class ScriptBuilderMsSql : SqlScriptBuilderBase
    {
        public ScriptBuilderMsSql(DbsDataConfig dataParams) : base(dataParams)
        {
            this.PlatformType = DBPlatform.DATA_PROVIDER_ODBC_MSSQL;
        }

        protected override string DbConvertDataType(TableFieldDefInfo fieldInfo)
        {
            string strFieldType = DBPlatform.MsSQLConvertDataType(fieldInfo.m_nType, fieldInfo.m_lSize);

            return strFieldType;
        }

        protected override string DbIdentitySQL()
        {
            string strDbIdentity = "IDENTITY(1,1) ";
            
            return strDbIdentity;
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
            return false;
        }

        public override string CreateDefaultSQL(uint versCreate)
        {
            return "CREATE DEFAULT Cislo_Nula AS 0";
        }

        public override string CreateDbTriggerUpd(TableDefInfo tableInfo)
        {
            StringBuilder strTriggerSql = new StringBuilder("CREATE TRIGGER ");
            strTriggerSql.AppendFormat("UI_{0} ON {0}", tableInfo.TableName()).
                Append(" AFTER UPDATE AS\n").
                Append("DELETE AS\n").
                Append("DECLARE inserted_cursor CURSOR FOR SELECT firma_id,\n").
                Append("davka_id,\n").
                Append("zpracovano\n").
                Append("FROM INSERTED\n").
                Append("DECLARE deleted_cursor  CURSOR FOR SELECT firma_id,\n").
                Append("davka_id,\n").
                Append("zpracovano\n").
                Append("FROM DELETED\n").
                Append("DECLARE @xZpracov tinyint\n").
                Append("DECLARE @iFirmaID int\n").
                Append("DECLARE @iDavkaID int\n").
                Append("BEGIN\n").
                Append("SET NOCOUNT ON\n").
                Append("IF(COLUMNS_UPDATED() > 0)\n").
                Append("BEGIN\n").
                Append("OPEN inserted_cursor\n").
                Append("FETCH NEXT\n").
                Append("FROM inserted_cursor INTO @iFirmaID,\n").
                Append("@iDavkaID,\n").
                Append("@xZpracov\n").
                Append("WHILE @@fetch_status = 0\n").
                Append("BEGIN\n").
                Append("IF(UPDATE(zpracovano) AND\n").
                Append("@xZpracov is not null)\n").
                Append("BEGIN\n").
                Append("UPDATE imp_01_prac set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_02_zp_vyplaty   set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_03_osdata       set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_31_pr_adresa    set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_05_zdr_poj      set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_06_soc_poj      set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_07_prijmy_prohl set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_08_prohl_mes    set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_09_dite         set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_17_pomer        set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_18_uvazek       set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_19_mzda         set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_20_neprit       set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_21_srazka       set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_101_utvar       set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("UPDATE imp_102_strcz       set zpracovano = @xZpracov where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("END\n").
                Append("FETCH NEXT\n").
                Append("FROM inserted_cursor INTO @iFirmaID,\n").
                Append("@iDavkaID,\n").
                Append("@xZpracov\n").
                Append("END\n").
                Append("CLOSE inserted_cursor\n").
                Append("DEALLOCATE inserted_cursor\n").
                Append("END\n").
                Append("ELSE\n").
                Append("BEGIN\n").
                Append("OPEN deleted_cursor\n").
                Append("FETCH NEXT\n").
                Append("FROM deleted_cursor INTO @iFirmaID,\n").
                Append("@iDavkaID,\n").
                Append("@xZpracov\n").
                Append("WHILE @@fetch_status = 0\n").
                Append("BEGIN\n").
                Append("delete from imp_01_prac         where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_02_zp_vyplaty where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_03_osdata where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_31_pr_adresa where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_05_zdr_poj where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_06_soc_poj where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_07_prijmy_prohl where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_08_prohl_mes where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_09_dite where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_17_pomer where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_18_uvazek where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_19_mzda where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_20_neprit where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_21_srazka where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_101_utvar where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("delete from imp_102_strcz where firma_id = @iFirmaID and davka_id = @iDavkaID\n").
                Append("FETCH NEXT\n").
                Append("FROM deleted_cursor INTO @iFirmaID,\n").
                Append("@iDavkaID,\n").
                Append("@xZpracov\n").
                Append("END\n").
                Append("CLOSE deleted_cursor\n").
                Append("DEALLOCATE deleted_cursor\n").
                Append("END\n").
                Append("END\n");

            return strTriggerSql.ToString();
        }

        public override string CreateDbTriggerIns(TableDefInfo tableInfo)
        {
            StringBuilder strTriggerSql = new StringBuilder("CREATE TRIGGER ");
            strTriggerSql.AppendFormat("UI_{0} ON {0}", tableInfo.TableName()).
                Append(" AFTER INSERT AS\n").
                Append("DECLARE inserted_cursor CURSOR FOR SELECT \n").
                Append("firma_id,\n").
                Append("davka_id\n").
                Append("FROM inserted\n").
                Append("DECLARE @xDavkaID int\n").
                Append("DECLARE @iFirmaID int\n").
                Append("DECLARE @iDavkaID int\n").
                Append("DECLARE @iDavkaTX VARCHAR(50)\n").
                Append("BEGIN\n").
                Append("SET NOCOUNT ON\n").
                Append("OPEN inserted_cursor\n").
                Append("FETCH NEXT\n").
                Append("FROM inserted_cursor INTO @iFirmaID,\n").
                Append("@iDavkaID\n").
                Append("WHILE @@fetch_status = 0\n").
                Append("BEGIN\n").
                Append("SET @iDavkaTX = ('Dávka č. ' + CONVERT(varchar(50),\n").
                Append("@iDavkaID))\n").
                Append("SET @xDavkaID = null\n").
                Append("SELECT @xDavkaID = davka_id\n").
                Append("FROM IMP_DAVKA\n").
                Append("WHERE firma_id = @iFirmaID AND\n").
                Append("davka_id = @iDavkaID\n").
                Append("IF(@xDavkaID is null)\n").
                Append("BEGIN\n").
                Append("SET IDENTITY_INSERT IMP_DAVKA ON\n").
                Append("INSERT INTO IMP_DAVKA(FIRMA_ID,\n").
                Append("DAVKA_ID,\n").
                Append("NAZEV,\n").
                Append("ZPRACOVANO,\n").
                Append("SAPHR)\n").
                Append("VALUES(@iFirmaID,\n").
                Append("@iDavkaID,\n").
                Append("@iDavkaTX,\n").
                Append("0,\n").
                Append("0)\n").
                Append("SET IDENTITY_INSERT IMP_DAVKA OFF\n").
                Append("END\n").
                Append("FETCH NEXT\n").
                Append("FROM inserted_cursor INTO @iFirmaID,\n").
                Append("@iDavkaID\n").
                Append("END\n").
                Append("CLOSE inserted_cursor\n").
                Append("DEALLOCATE inserted_cursor\n").
                Append("END\n");

            return strTriggerSql.ToString();
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

            return CreateRelationSQL(relInfo, addBegin, addClose);
        }

        public override string CreateTableBND(TableDefInfo tableDef, uint versCreate)
        {
            string strSQL = "";
            var tableFields = tableDef.TableColumnsForVersion(versCreate);

            foreach (var field in tableFields)
            {
                string strDefaultSQL;
                bool bRequiredDefault = DBPlatform.DefaultBindRequired(field.m_lAttributes);

                if (field.m_bRequired && bRequiredDefault)
                {
                    if (DBPlatform.DefaultBindDataType(field.m_nType))
                    {
                        strDefaultSQL = BindDefaultDataTypeSql(tableDef.TableName(), field.m_strName);
                        strSQL += (strDefaultSQL);
                        strSQL += DBConstants.NEW_LINE_STR;
                        strSQL += DBConstants.NEW_LINE_STR;
                    }
                }
            }

            return strSQL;
        }

        private string BindDefaultDataTypeSql(string tableName, string fieldName)
        {
            string strDefaultSQL = "exec sp_bindefault Cislo_Nula, '";

            strDefaultSQL += tableName;
            strDefaultSQL += (".");
            strDefaultSQL += fieldName;
            strDefaultSQL += ("'");

            return strDefaultSQL;
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
            if (bIdentityOn)
            {
                string strSwitchSQL = ("SET IDENTITY_INSERT " + tableDef.TableName() + " ON");
                scriptWriter.DefaultCodeLine(strSwitchSQL, tableDef.TableName());
                return strSwitchSQL;
            }
            return DBConstants.EMPTY_STRING;
        }

        public override string CreateSwitchIndentityInsertOff(TableDefInfo tableDef, bool bIdentityOn, IGeneratorWriter scriptWriter)
        {
            if (bIdentityOn)
            {
                string strSwitchSQL = ("SET IDENTITY_INSERT " + tableDef.TableName() + " OFF");
                scriptWriter.DefaultCodeLine(strSwitchSQL, tableDef.TableName());
                return strSwitchSQL;
            }
            return DBConstants.EMPTY_STRING;
        }
    }
}
