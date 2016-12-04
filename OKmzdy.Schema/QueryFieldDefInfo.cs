using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class QueryFieldDefInfo : ICloneable
    {
        public QueryFieldDefInfo(TableFieldDefInfo fieldInfo, string alias, string funcFmt)
        {
            m_TableColumnInfo = (TableFieldDefInfo)fieldInfo.Clone();
            m_strAliasName = alias;
            m_strFuncFormat = funcFmt;
        }

        public TableFieldDefInfo m_TableColumnInfo;
        public string m_strAliasName;
        public string m_strFuncFormat;

        public bool IsValidInVersion(UInt32 versCreate)
        {
            if (m_TableColumnInfo == null)
            {
                return false;
            }
            return (m_TableColumnInfo.IsValidInVersion(versCreate));
        }
        public string QueryColumnName()
        {
            if (m_TableColumnInfo == null)
            {
                return "";
            }
            return m_TableColumnInfo.m_strName;
        }

        public TableFieldDefInfo QueryColumnInfo()
        {
            TableFieldDefInfo queryColumnInfo = (TableFieldDefInfo)m_TableColumnInfo.Clone();

            queryColumnInfo.m_strName = m_strAliasName;

            return queryColumnInfo;
        }

        public string QueryColumnAlias()
        {
            return m_strAliasName;
        }

        public string ColumnInfoSource(string tableAlias)
        {
            string columnFmtx = "";
            string columnName = tableAlias;
            columnName += ".";
            columnName += QueryColumnName();

            if (m_strFuncFormat == "")
            {
                columnFmtx = columnName;
            }
            else
            {
                columnFmtx = string.Format(m_strFuncFormat, columnName);
            }
            columnFmtx += " AS ";
            columnFmtx += QueryColumnAlias();
            return columnFmtx;
        }

        public object Clone()
        {
            QueryFieldDefInfo other = (QueryFieldDefInfo)this.MemberwiseClone();
            other.m_TableColumnInfo = (TableFieldDefInfo)this.m_TableColumnInfo.Clone();
            other.m_strAliasName = (string)this.m_strAliasName.Clone();
            other.m_strFuncFormat = (string)this.m_strFuncFormat.Clone();

            return other;
        }
    }
}
