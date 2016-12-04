using OKmzdy.AppParams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public abstract class BaseSchemaGenerator
    {
        protected BaseSchemaInfo m_SchemaInfo;

        protected IList<TableDefInfo> m_TableList;

        protected IList<TableDefInfo> m_TrigUList;

        protected IList<TableDefInfo> m_TrigIList;

        protected IList<TableDefInfo> m_IndexList;

        protected IList<TableDefInfo> m_RelatList;

        protected IList<QueryDefInfo> m_QueryList;

        public BaseSchemaGenerator(BaseSchemaInfo schemaInfo, SoftwareUserData dataParams)
        {
            this.m_SchemaInfo = schemaInfo;

            this.m_TableList = new List<TableDefInfo>();

            this.m_TrigUList = new List<TableDefInfo>();

            this.m_TrigIList = new List<TableDefInfo>();

            this.m_IndexList = new List<TableDefInfo>();

            this.m_RelatList = new List<TableDefInfo>();

            this.m_QueryList = new List<QueryDefInfo>();
        }

        public void CreateFilteredTableList(IList<string> filterList)
        {
            if (m_SchemaInfo != null)
            {
                m_TableList = m_SchemaInfo.CreateFilteredTableCloneList(filterList);
            }
        }

        public void CreateFilteredTriggerUpdateList(IList<string> filterList)
        {
            if (m_SchemaInfo != null)
            {
                m_TrigUList = m_SchemaInfo.CreateFilteredTableCloneList(filterList);
            }
        }

        public void CreateFilteredTriggerInsertList(IList<string> filterList)
        {
            if (m_SchemaInfo != null)
            {
                m_TrigIList = m_SchemaInfo.CreateFilteredTableCloneList(filterList);
            }
        }

        public void CreateFilteredIndexList(IList<string> filterList)
        {
            if (m_SchemaInfo != null)
            {
                m_IndexList = m_SchemaInfo.CreateFilteredTableCloneList(filterList);
            }
        }

        public void CreateFilteredQueryList(IList<string> filterList)
        {
            if (m_SchemaInfo != null)
            {
                m_QueryList = m_SchemaInfo.CreateFilteredQueryCloneList(filterList);
            }
        }

        public void CreateSubsetTableList(IList<string> filterList)
        {
            if (m_SchemaInfo != null)
            {
                m_TableList = m_SchemaInfo.CreateSubsetTableCloneList(filterList);
            }
        }

        public void CreateSubsetTriggerUpdateList(IList<string> filterList)
        {
            if (m_SchemaInfo != null)
            {
                m_TrigUList = m_SchemaInfo.CreateSubsetTableCloneList(filterList);
            }
        }

        public void CreateSubsetTriggerInsertList(IList<string> filterList)
        {
            if (m_SchemaInfo != null)
            {
                m_TrigIList = m_SchemaInfo.CreateSubsetTableCloneList(filterList);
            }
        }

        public void CreateSubsetIndexList(IList<string> filterList)
        {
            if (m_SchemaInfo != null)
            {
                m_IndexList = m_SchemaInfo.CreateSubsetTableCloneList(filterList);
            }
        }

        public void CreateSubsetRelatList(IList<string> filterList)
        {
            if (m_SchemaInfo != null)
            {
                m_RelatList = m_SchemaInfo.CreateSubsetTableCloneList(filterList);
            }
        }

        public void CreateSubsetQueryList(IList<string> filterList)
        {
            if (m_SchemaInfo != null)
            {
                m_QueryList = m_SchemaInfo.CreateSubsetQueryCloneList(filterList);
            }
        }

        public TableDefInfo TableDefInfo(string filterName)
        {
            return m_TableList.SingleOrDefault((f) => (f.TableName().CompareNoCase(filterName)));
        }

        public bool CreateSchema(IGeneratorWriter processWriter, bool createBegEnd, bool createInitDb, bool createTable, bool createIndex, bool createTrigger, bool insertData, bool createViews, bool createRelations)
        {
            bool successProcess = false;

            processWriter.WriteInfoLine("Process started ...");

            if (CREATEDB_START_CREATE(processWriter, createBegEnd) == false)
                return successProcess;

            if (CREATEDB_CAST1_INITDB(processWriter, createInitDb) == false)
                return successProcess;

            if (CREATEDB_CAST2_TABLES(m_TableList, processWriter, createTable, createRelations) == false)
                return successProcess;

            if (CREATEDB_CAST2_INDEXS(m_IndexList, processWriter, createIndex) == false)
                return successProcess;

            if (CREATEDB_CAST3_TRIGGER(m_TrigUList, m_TrigIList, processWriter, createTrigger) == false)
                return successProcess;

            if (CREATEDB_CAST3_TVIEWS(m_QueryList, processWriter, createViews) == false)
                return successProcess;

            if (CREATEDB_CAST4_INSERT(processWriter, insertData) == false)
                return successProcess;

            if (CREATEDB_CAST5_REFINT(m_TableList, processWriter, createRelations) == false)
                return successProcess;

            if (CREATEDB_STOPS_CREATE(processWriter, createBegEnd) == false)
                return successProcess;

            processWriter.WriteInfoLine("Process finished ...");

            return true;
        }

        private bool CREATEDB_START_CREATE(IGeneratorWriter processWriter, bool executePart)
        {
            processWriter.WriteInfoLine("Creating of schema started ...");

            if (executePart == false)
            {
                processWriter.WriteInfoLine("- skipped ...");
                return true;
            }
            bool uspesnaCast = true;

            try
            {
                TryProcessStartCreate(processWriter);

                processWriter.WriteInfoLine("- finished successfuly ...");
            }
            catch (Exception ex)
            {
                ExceptionDiagnostics(ex);
                uspesnaCast = false;
            }
            return uspesnaCast;
        }


        private bool CREATEDB_CAST1_INITDB(IGeneratorWriter processWriter, bool executePart)
        {
            processWriter.WriteInfoLine("Creating of DEFAULTS started ...");

            if (executePart == false)
            {
                processWriter.WriteInfoLine("- skipped ...");
                return true;
            }
            bool uspesnaCast = true;

            try
            {
                TryProcessCast1InitDb(processWriter);

                processWriter.WriteInfoLine("- finished successfuly ...");
            }
            catch (Exception ex)
            {
                ExceptionDiagnostics(ex);
                uspesnaCast = false;
            }
            return uspesnaCast;
        }

        private bool CREATEDB_CAST2_TABLES(IList<TableDefInfo> tableList, IGeneratorWriter processWriter, bool executePart, bool createRels)
        {
            processWriter.WriteInfoLine("Creating of TABLES started ...");

            if (executePart == false)
            {
                processWriter.WriteInfoLine("- skipped ...");
                return true;
            }
            bool uspesnaCast = true;

            try
            {
                TryProcessCast2Tables(tableList, createRels, processWriter);

                processWriter.WriteInfoLine("- finished successfuly ...");
            }
            catch (Exception ex)
            {
                ExceptionDiagnostics(ex);
                uspesnaCast = false;
            }
            return uspesnaCast;
        }


        private bool CREATEDB_CAST2_INDEXS(IList<TableDefInfo> tableList, IGeneratorWriter processWriter, bool executePart)
        {
            processWriter.WriteInfoLine("Creating of INDEXES started ...");

            if (executePart == false)
            {
                processWriter.WriteInfoLine("- skipped ...");
                return true;
            }
            bool uspesnaCast = true;

            try
            {
                TryProcessCast3Indexs(tableList, processWriter);

                processWriter.WriteInfoLine("- finished successfuly ...");
            }
            catch (Exception ex)
            {
                ExceptionDiagnostics(ex);
                uspesnaCast = false;
            }
            return uspesnaCast;
        }


        private bool CREATEDB_CAST3_TRIGGER(IList<TableDefInfo> trigUList, IList<TableDefInfo> trigIList, IGeneratorWriter processWriter, bool executePart)
        {
            processWriter.WriteInfoLine("Creating of TRIGGERS started ...");

            if (executePart == false)
            {
                processWriter.WriteInfoLine("- skipped ...");
                return true;
            }
            bool uspesnaCast = true;

            try
            {
                TryProcessCast4Trigger(trigUList, trigIList, processWriter);

                processWriter.WriteInfoLine("- finished successfuly ...");
            }
            catch (Exception ex)
            {
                ExceptionDiagnostics(ex);
                uspesnaCast = false;
            }
            return uspesnaCast;
        }


        private bool CREATEDB_CAST3_TVIEWS(IList<QueryDefInfo> queryList, IGeneratorWriter processWriter, bool executePart)
        {
            processWriter.WriteInfoLine("Creating of VIEWS started ...");

            if (executePart == false)
            {
                processWriter.WriteInfoLine("- skipped ...");
                return true;
            }
            bool uspesnaCast = true;

            try
            {
                TryProcessCast5Tviews(queryList, processWriter);

                processWriter.WriteInfoLine("- finished successfuly ...");
            }
            catch (Exception ex)
            {
                ExceptionDiagnostics(ex);
                uspesnaCast = false;
            }
            return uspesnaCast;
        }


        private bool CREATEDB_CAST4_INSERT(IGeneratorWriter processWriter, bool executePart)
        {
            processWriter.WriteInfoLine("Inserting of INITIAL rows started ...");

            if (executePart == false)
            {
                processWriter.WriteInfoLine("- skipped ...");
                return true;
            }
            bool uspesnaCast = true;

            try
            {
                TryProcessCast6Insert(processWriter);

                processWriter.WriteInfoLine("- finished successfuly ...");
            }
            catch (Exception ex)
            {
                ExceptionDiagnostics(ex);
                uspesnaCast = false;
            }
            return uspesnaCast;
        }


        private bool CREATEDB_CAST5_REFINT(IList<TableDefInfo> tableList, IGeneratorWriter processWriter, bool executePart)
        {
            processWriter.WriteInfoLine("Creating of RELATIONS started ...");

            if (executePart == false)
            {
                processWriter.WriteInfoLine("- skipped ...");
                return true;
            }
            bool uspesnaCast = true;

            try
            {
                TryProcessCast7Refint(tableList, processWriter);

                processWriter.WriteInfoLine("- finished successfuly ...");
            }
            catch (Exception ex)
            {
                ExceptionDiagnostics(ex);
                uspesnaCast = false;
            }
            return uspesnaCast;
        }


        private bool CREATEDB_STOPS_CREATE(IGeneratorWriter processWriter, bool executePart)
        {
            processWriter.WriteInfoLine("Finishing of schema started ...");

            if (executePart == false)
            {
                processWriter.WriteInfoLine("- skipped ...");
                return true;
            }
            bool uspesnaCast = true;

            try
            {
                TryProcessStopsCreate(processWriter);

                processWriter.WriteInfoLine("- finished successfuly ...");
            }
            catch (Exception ex)
            {
                ExceptionDiagnostics(ex);
                uspesnaCast = false;
            }
            return uspesnaCast;
        }

        public abstract void  PrepareSchema();
        protected abstract void TryProcessStartCreate(IGeneratorWriter processWriter);
        protected abstract void TryProcessCast1InitDb(IGeneratorWriter processWriter);
        protected abstract void TryProcessCast2Tables(IList<TableDefInfo> tableList, bool createRels, IGeneratorWriter processWriter);
        protected abstract void TryProcessCast3Indexs(IList<TableDefInfo> tableList, IGeneratorWriter processWriter);
        protected abstract void TryProcessCast4Trigger(IList<TableDefInfo> trigUList, IList<TableDefInfo> trigIList, IGeneratorWriter processWriter);
        protected abstract void TryProcessCast5Tviews(IList<QueryDefInfo> queryList, IGeneratorWriter processWriter);
        protected abstract void TryProcessCast6Insert(IGeneratorWriter processWriter);
        protected abstract void TryProcessCast7Refint(IList<TableDefInfo> tableList, IGeneratorWriter processWriter);
        protected abstract void TryProcessStopsCreate(IGeneratorWriter processWriter);

        private void ExceptionDiagnostics(Exception ex)
        {
            string errorDiagnostics = string.Format("Exception in command: {0}", ex.ToString());
            System.Diagnostics.Debug.Print(errorDiagnostics);
        }
    }
}
