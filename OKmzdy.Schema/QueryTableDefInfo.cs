using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class QueryTableDefInfo : ICloneable
    {
        public static QueryTableDefInfo GetQueryAliasDefInfo(string alias, TableDefInfo tableDef)
        {
            return new QueryTableDefInfo(alias, tableDef);
        }
        public QueryTableDefInfo AddColumn(NameInfo columnName)
        {
            QueryTableDefInfo other = (QueryTableDefInfo)this.MemberwiseClone();
            other.m_QueryTableInfo = this.m_QueryTableInfo;
            other.m_strName = this.m_strName;
            other.m_strAliasName = this.m_strAliasName;
            TableFieldDefInfo tabColumn = other.m_QueryTableInfo.FieldByName(columnName.Name);
            QueryFieldDefInfo addColumn = new QueryFieldDefInfo(tabColumn, columnName.Alias, columnName.Function);
            other.m_QueryFields = this.m_QueryFields.Concat(new List<QueryFieldDefInfo>() { addColumn }).ToList();

            return other;
        }
        public QueryTableDefInfo AddColumns(params NameInfo[] columnNames)
        {
            QueryTableDefInfo other = (QueryTableDefInfo)this.MemberwiseClone();
            other.m_QueryTableInfo = this.m_QueryTableInfo;
            other.m_strName = this.m_strName;
            other.m_strAliasName = this.m_strAliasName;

            IList<QueryFieldDefInfo> listQueryFields = this.m_QueryFields.ToList();
            foreach (var columnName in columnNames)
            {
                TableFieldDefInfo tabColumn = other.m_QueryTableInfo.FieldByName(columnName.Name);
                QueryFieldDefInfo addColumn = new QueryFieldDefInfo(tabColumn, columnName.Alias, columnName.Function);
                listQueryFields.Add(addColumn);
            }
            other.m_QueryFields = listQueryFields;
            return other;
        }
        public QueryTableDefInfo(string alias, TableDefInfo tableDef)
        {
            m_QueryTableInfo = tableDef;
            m_QueryFields = new List<QueryFieldDefInfo>();
            m_strAliasName = alias;
            m_strName = tableDef.TableName();
        }

        private TableDefInfo m_QueryTableInfo;
        public IList<QueryFieldDefInfo> m_QueryFields;
        public string m_strAliasName;
        public string m_strName;

        public TableDefInfo QueryTableInfo()
        {
            return (TableDefInfo)m_QueryTableInfo.Clone();
        }
        public IList<QueryFieldDefInfo> QueryFields()
        {
            return m_QueryFields.ToList();
        }

        public void SetQueryFieldsList(IList<QueryFieldDefInfo> fieldList)
        {
            m_QueryFields = fieldList;
        }

        public bool IsValidInVersion(UInt32 versCreate)
        {
            if (m_QueryTableInfo == null)
            {
                return false;
            }
            return (m_QueryTableInfo.IsValidInVersion(versCreate));
        }
        public string TableName()
        {
            return m_strName;
        }

        public string AliasName()
        {
            return m_strAliasName;
        }

        public string TableSourceName()
        {
            return string.Join(" ", new string[] { m_strName, m_strAliasName } );
        }

        public object Clone()
        {
            QueryTableDefInfo other = (QueryTableDefInfo)this.MemberwiseClone();
            other.m_strName = this.m_strName;
            other.m_strAliasName = this.m_strAliasName;

            return other;
        }
    }
}
