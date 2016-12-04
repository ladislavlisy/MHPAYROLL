using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class QueryWhereDefInfo : ICloneable
    {
        public static QueryWhereDefInfo GetQueryWhereDefInfo(string alias, TableDefInfo tableDef)
        {
            return new QueryWhereDefInfo(alias, tableDef);
        }
        public QueryWhereDefInfo AddConstraint(QueryFilterDefInfo constraint)
        {
            QueryWhereDefInfo other = (QueryWhereDefInfo)this.MemberwiseClone();
            other.m_QueryTableInfo = this.m_QueryTableInfo;
            other.m_strName = this.m_strName;
            other.m_strAliasName = this.m_strAliasName;
            other.m_QueryFilters = this.m_QueryFilters.Concat(new List<QueryFilterDefInfo>() { constraint }).ToList();

            return other;
        }
        public QueryWhereDefInfo AddConstraints(params QueryFilterDefInfo[] constraints)
        {
            QueryWhereDefInfo other = (QueryWhereDefInfo)this.MemberwiseClone();
            other.m_QueryTableInfo = this.m_QueryTableInfo;
            other.m_strName = this.m_strName;
            other.m_strAliasName = this.m_strAliasName;

            other.m_QueryFilters = this.m_QueryFilters.Concat(constraints).ToList();
            return other;
        }
        public QueryWhereDefInfo(string alias, TableDefInfo tableDef)
        {
            m_QueryTableInfo = tableDef;
            m_QueryFilters = new List<QueryFilterDefInfo>();
            m_strAliasName = alias;
            m_strName = tableDef.TableName();
        }

        private TableDefInfo m_QueryTableInfo;
        public IList<QueryFilterDefInfo> m_QueryFilters;
        public string m_strAliasName;
        public string m_strName;

        public bool IsValidInVersion(UInt32 versCreate)
        {
            if (m_QueryTableInfo == null)
            {
                return false;
            }
            return (m_QueryTableInfo.IsValidInVersion(versCreate));
        }
        public TableDefInfo QueryTableInfo()
        {
            return (TableDefInfo)m_QueryTableInfo.Clone();
        }

        public IList<QueryFilterDefInfo> QueryFilters()
        {
            return m_QueryFilters.ToList();
        }

        public void SetQueryFiltersList(IList<QueryFilterDefInfo> filterList)
        {
            m_QueryFilters = filterList;
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
            return string.Join(" ", new string[] { m_strName, m_strAliasName });
        }

        public IList<string> QueryFilterCondition()
        {
            return m_QueryFilters.Select((f) => (f.QueryFilterCondition(m_strAliasName))).ToList();
        }

        public object Clone()
        {
            QueryWhereDefInfo other = (QueryWhereDefInfo)this.MemberwiseClone();
            other.m_strName = this.m_strName;
            other.m_strAliasName = this.m_strAliasName;
            other.m_QueryFilters = this.m_QueryFilters.ToList();

            return other;
        }

    }
}
