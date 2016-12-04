using OKmzdy.AppParams;
using OKmzdy.Schema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.SqlAdapter
{
    public abstract class SqlBaseAdapter : IDisposable
    {
        protected DbConnection m_conn;

        protected int m_platformType;

        protected string m_connString;

        protected string m_databaseName;
        public SqlBaseAdapter(DbsDataConfig node)
        {
            m_platformType = node.DataType();

            m_databaseName = node.DbsFileName;
        }

        protected abstract string GetConnectString(DbsDataConfig node);

        public int PlatformType()
        {
            return m_platformType;
        }

        public DbConnection DbConnection()
        {
            return m_conn;
        }

        public void OpenConnection()
        {
            m_conn.Open();
        }

        public void CloseConnection()
        {
            m_conn.Close();
        }

        public abstract void CreateDatabase();
        public abstract DbConnection CreateConnection();
        public abstract DbDataAdapter GetAdapter(string dataFilter);
        public abstract DbCommand GetCommand(string commandSql);
        public string SelectRowCountTableData(TableDefInfo tableDef)
        {
            DbDataAdapter countDA = GetAdapter(tableDef.CreateSelectCountTableRow());
            
            string TABLE_NAME = tableDef.TableName();

            string commandResult = "";

            DataSet tableDS = new DataSet();

            countDA.Fill(tableDS, TABLE_NAME);

            foreach (DataRow rowCount in tableDS.Tables[TABLE_NAME].Rows)
            {
                commandResult = rowCount["POCET"].ToString();
            }

            return commandResult;
        }

        public void Dispose()
        {
            if (m_conn != null)
            {
                m_conn.Close();

                m_conn.Dispose();
            }
        }

    }
}
