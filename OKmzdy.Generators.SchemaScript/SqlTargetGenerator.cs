using OKmzdy.AppParams;
using OKmzdy.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OKmzdy.Schema.SqlBuilder;

namespace OKmzdy.Schema.ScriptGenerator
{
    public class SqlTargetGenerator : BaseSchemaGenerator
    {
        private SqlScriptBuilderBase m_scriptBuilder;

        private UInt32 m_createVersion = 0;

        public SqlTargetGenerator(BaseSchemaInfo schemaInfo, SoftwareUserData dataParams, SqlScriptBuilderBase scriptBuilder, UInt32 createVersion) : base(schemaInfo, dataParams)
        {
            this.m_scriptBuilder = scriptBuilder;

            this.m_createVersion = createVersion;
        }

        protected override void TryProcessStartCreate(IGeneratorWriter scriptWriter)
        {
        }

        protected override void TryProcessCast1InitDb(IGeneratorWriter scriptWriter)
        {
            string scriptPart = m_scriptBuilder.CreateDefaultSQL(m_createVersion);

            scriptWriter.DefaultCodeLine(scriptPart, "Database Defaults");
        }

        protected override void TryProcessCast2Tables(IList<TableDefInfo> tableList, bool createRels, IGeneratorWriter scriptWriter)
        {
            foreach (TableDefInfo tableInfo in tableList)
            {
                string scriptPartTbl = m_scriptBuilder.CreateTableSQL(tableInfo, createRels, m_createVersion);

                scriptWriter.DefaultCodeLine(scriptPartTbl, tableInfo.InfoName());

                string scriptPartSeq = m_scriptBuilder.CreateTableSEQ(tableInfo);

                scriptWriter.DefaultCodeLine(scriptPartSeq, tableInfo.InfoName());

                string scriptSynsSeq = m_scriptBuilder.CreateSequeSYN(tableInfo, scriptWriter);

                scriptWriter.DefaultCodeLine(scriptSynsSeq, tableInfo.InfoName());

                string scriptSynsTab = m_scriptBuilder.CreateTableSYN(tableInfo, scriptWriter);

                scriptWriter.DefaultCodeLine(scriptSynsTab, tableInfo.InfoName());

                string scriptSeqsSEC = m_scriptBuilder.CreateSequeSEC(tableInfo);

                scriptWriter.DefaultCodeLine(scriptSeqsSEC, tableInfo.InfoName());

                string scriptPartSec = m_scriptBuilder.CreateTableSEC(tableInfo);

                scriptWriter.DefaultCodeLine(scriptPartSec, tableInfo.InfoName());

                string scriptPartBnd = m_scriptBuilder.CreateTableBND(tableInfo, m_createVersion);

                scriptWriter.DefaultCodeLine(scriptPartBnd, tableInfo.InfoName());

            }
        }

        protected override void TryProcessCast3Indexs(IList<TableDefInfo> tableList, IGeneratorWriter scriptWriter)
        {
            bool bCreatePKs = (m_scriptBuilder.DbXPIndexInCreateTable() == false);
            foreach (TableDefInfo tableDef in tableList)
            {
                if (bCreatePKs)
                {
                    IndexDefInfo indexPK = tableDef.IndexPK();
                    if (indexPK != null)
                    {
                        string scriptPart = m_scriptBuilder.AlterXPKIndexSQL(indexPK);

                        scriptPart += DBConstants.NEW_LINE_STR;

                        scriptWriter.DefaultCodeLine(scriptPart, indexPK.InfoName());
                    }
                }

                IList<IndexDefInfo> indexes = tableDef.IndexesNonPK();
                foreach (var indexIF in indexes)
                {
                    string scriptPart = m_scriptBuilder.CreateIndexSQL(indexIF);

                    scriptPart += DBConstants.NEW_LINE_STR;

                    scriptWriter.DefaultCodeLine(scriptPart, indexIF.InfoName());
                }
            }
        }

        protected override void TryProcessCast4Trigger(IList<TableDefInfo> trigUList, IList<TableDefInfo> trigIList, IGeneratorWriter scriptWriter)
        {
            string scriptPart = DBConstants.EMPTY_STRING;

            foreach (TableDefInfo tableDef in trigUList)
            {
                scriptPart = m_scriptBuilder.CreateDbTriggerUpd(tableDef);
                scriptWriter.DefaultCodeLine(scriptPart, tableDef.InfoName());
            }
            foreach (TableDefInfo tableDef in trigIList)
            {
                scriptPart = m_scriptBuilder.CreateDbTriggerIns(tableDef);
                scriptWriter.DefaultCodeLine(scriptPart, tableDef.InfoName());
            }
        }

        protected override void TryProcessCast5Tviews(IList<QueryDefInfo> queryList, IGeneratorWriter scriptWriter)
        {
            foreach (QueryDefInfo queryInfo in queryList)
            {
                string scriptPartTbl = m_scriptBuilder.CreateQuerySQL(queryInfo, m_createVersion);

                scriptWriter.DefaultCodeLine(scriptPartTbl, queryInfo.InfoName());
            }
        }

        protected override void TryProcessCast6Insert(IGeneratorWriter scriptWriter)
        {
            string scriptTemp = "INSERT INTO STAV_DATABAZE (verze, heslo) VALUES ({0}, \'2C1A313A0F528234\')";

            string scriptPart = string.Format(scriptTemp, m_createVersion);

            scriptWriter.DefaultCodeLine(scriptPart, "STAV_DATABAZE");
        }

        protected override void TryProcessCast7Refint(IList<TableDefInfo> tableList, IGeneratorWriter scriptWriter)
        {
            foreach (TableDefInfo tableDef in tableList)
            {
                IList<RelationDefInfo> relations = tableDef.Relations();
                foreach (var relation in relations)
                {
                    string scriptPart = m_scriptBuilder.CreateAlterTableRelationSQL(tableDef, relation);

                    scriptWriter.DefaultCodeLine(scriptPart, relation.InfoName());
                }
            }
        }

        protected override void TryProcessStopsCreate(IGeneratorWriter scriptWriter)
        {
        }
        public override void PrepareSchema()
        {
            IList<CloneTableDefInfo> cloneTableList = m_TableList.Select((t) => (new CloneTableDefInfo(t, m_createVersion))).ToList();
            CloneSchemaTransformation.ConvertTablesAutoIdFieldToId(cloneTableList);
            CloneSchemaTransformation.ConvertTablesRelationsMxToId(cloneTableList);

            m_TableList = cloneTableList.Select((t) => (t.GetTargetInfo())).ToList();

            IList<CloneTableDefInfo> cloneTrigUList = m_TrigUList.Select((t) => (new CloneTableDefInfo(t, m_createVersion))).ToList();
            m_TrigUList = cloneTrigUList.Select((t) => (t.GetTargetInfo())).ToList();

            IList<CloneTableDefInfo> cloneTrigIList = m_TrigIList.Select((t) => (new CloneTableDefInfo(t, m_createVersion))).ToList();
            m_TrigIList = cloneTrigIList.Select((t) => (t.GetTargetInfo())).ToList();

            IList<CloneTableDefInfo> cloneIndexList = m_IndexList.Select((t) => (new CloneTableDefInfo(t, m_createVersion))).ToList();
            m_IndexList = cloneIndexList.Select((t) => (t.GetTargetInfo())).ToList();

            IList<CloneTableDefInfo> cloneRelatList = m_RelatList.Select((t) => (new CloneTableDefInfo(t, m_createVersion))).ToList();
            m_RelatList = cloneRelatList.Select((t) => (t.GetTargetInfo())).ToList();

            IList<CloneQueryDefInfo> cloneQueryList = m_QueryList.Select((t) => (new CloneQueryDefInfo(t, m_createVersion))).ToList();
            m_QueryList = cloneQueryList.Select((t) => (t.GetTargetInfo())).ToList();
        }

    }
}
