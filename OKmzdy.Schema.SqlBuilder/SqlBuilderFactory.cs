using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKmzdy.AppParams;

namespace OKmzdy.Schema.SqlBuilder
{
    public static class SqlBuilderFactory
    {
        public static SqlScriptBuilderBase CreateSqlBuilder(DbsDataConfig node)
        {
            if (node.DataType() == SoftwareDataKeys.DATA_PROVIDER_ODBC_MSSQL || node.DataType() == SoftwareDataKeys.DATA_PROVIDER_ODBC_IMSSQL)
            {
                return new ScriptBuilderMsSql(node) as SqlScriptBuilderBase;
            }
            else if (node.DataType() == SoftwareDataKeys.DATA_PROVIDER_JET3)
            {
                return new ScriptBuilderMsJet(node) as SqlScriptBuilderBase;
            }
            else if (node.DataType() == SoftwareDataKeys.DATA_PROVIDER_SQLITE)
            {
                return new ScriptBuilderSqlite(node) as SqlScriptBuilderBase;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
