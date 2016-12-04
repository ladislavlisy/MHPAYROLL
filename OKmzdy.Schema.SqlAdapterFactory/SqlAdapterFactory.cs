using OKmzdy.AppParams;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKmzdy.Schema.SqlAdapter;
#if WINDOWS_API
using OKmzdy.Schema.SqlMsJet;
using OKmzdy.Schema.SqlMsSql;
using OKmzdy.Schema.SqlSqlite;
#endif

namespace OKmzdy.Schema.SqlFactory
{
    public static class SqlAdapterFactory
    {
        public static SqlBaseAdapter CreateSqlAdapter(DbsDataConfig node)
        {
#if WINDOWS_API

            if (node.DataType() == SoftwareDataKeys.DATA_PROVIDER_ODBC_MSSQL || node.DataType() == SoftwareDataKeys.DATA_PROVIDER_ODBC_IMSSQL)
            {
                return new SqlMsSqlAdapter(node) as SqlBaseAdapter;
            }
            else if (node.DataType() == SoftwareDataKeys.DATA_PROVIDER_JET3)
            {
                return new SqlMsJetAdapter(node) as SqlBaseAdapter;

            }
            else if (node.DataType() == SoftwareDataKeys.DATA_PROVIDER_SQLITE)
            {
                return new SqlSqliteAdapter(node) as SqlBaseAdapter;

            }
            else
            {
                throw new NotImplementedException();
            }
#else
			return null;
#endif
        }
    }
}
