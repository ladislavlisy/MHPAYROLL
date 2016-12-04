using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class QueryDefInfo : ICloneable
    {
        protected IList<QueryTableDefInfo> m_QueryTableInfo;
        protected IList<QueryJoinDefInfo> m_QueryJoinInfo;
        protected IList<QueryWhereDefInfo> m_TableViewFilters;
        protected IList<string> m_QueryEndClauses;

        protected string m_strOwnerName;
        protected string m_strUsersName;
        protected UInt32 m_VersFrom = 0;
        protected UInt32 m_VersDrop = 9999;
        public string m_strName;

        public bool IsValidInVersion(UInt32 versCreate)
        {
            return (m_VersFrom <= versCreate && versCreate < m_VersDrop);
        }
        public string OwnerName()
        {
            return m_strOwnerName;
        }

        public string UsersName()
        {
            return m_strUsersName;
        }
        public string QueryName()
        {
            return m_strName;
        }

        public UInt32 VersFrom()
        {
            return m_VersFrom;
        }

        public UInt32 VersDrop()
        {
            return m_VersDrop;
        }

        public QueryDefInfo(string lpszOwnerName, string lpszUsersName, string lpszTableName, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            this.m_strOwnerName = lpszOwnerName;
            this.m_strUsersName = lpszUsersName;
            this.m_strName = lpszTableName;
            this.m_VersFrom = versFrom;
            this.m_VersDrop = versDrop;

            this.m_QueryTableInfo = new List<QueryTableDefInfo>();
            this.m_QueryJoinInfo = new List<QueryJoinDefInfo>();
            this.m_TableViewFilters = new List<QueryWhereDefInfo>();
            this.m_QueryEndClauses = new List<string>();
        }
        public void SetQueryTableInfo(IList<QueryTableDefInfo> tableList)
        {
            m_QueryTableInfo = tableList;
        }

        public void SetQueryJoinInfo(IList<QueryJoinDefInfo> joinsList)
        {
            m_QueryJoinInfo = joinsList;
        }

        public void SetTableViewFilters(IList<QueryWhereDefInfo> filterList)
        {
            m_TableViewFilters = filterList;
        }

        public void SetQueryEndClauses(IList<string> clauseList)
        {
            m_QueryEndClauses = clauseList;
        }

        public void AddTable(QueryTableDefInfo tableAliasInfo)
        {
            this.m_QueryTableInfo.Add(tableAliasInfo);
        }
        public void AddTableJoin(QueryJoinDefInfo tableJoinInfo)
        {
            this.m_QueryJoinInfo.Add(tableJoinInfo);
        }

        public void AddFiltr(QueryWhereDefInfo tableWhereInfo)
        {
            this.m_TableViewFilters.Add(tableWhereInfo);
        }

        public void AddClause(string queryClause)
        {
            this.m_QueryEndClauses.Add(queryClause);
        }

        public IList<QueryTableDefInfo> QueryTableInfo()
        {
            return m_QueryTableInfo.ToList();
        }

        public IList<QueryJoinDefInfo> QueryJoinInfo()
        {
            return m_QueryJoinInfo.ToList();
        }
        public IList<QueryWhereDefInfo> TableViewFilters()
        {
            return m_TableViewFilters.ToList();
        }
        public IList<string> QueryEndClauses()
        {
            return m_QueryEndClauses.ToList();
        }

        public TableDefInfo GetTableDef()
        {
            TableDefInfo queryTableInfo = new TableDefInfo(m_strOwnerName, m_strUsersName, m_strName, m_VersFrom, m_VersDrop);

            IList<TableFieldDefInfo> queryColumnList = m_QueryTableInfo.SelectMany((t) => (t.m_QueryFields.Select((f) => f.QueryColumnInfo()))).ToList();
            foreach (var columnInfo in queryColumnList)
            {
                queryTableInfo.FieldAppend(columnInfo);
            }
            return queryTableInfo;  
        }

        public IList<string> QueryColumnsNamesForVersion(uint versCreate)
        {
            IList<QueryFieldDefInfo> tableColumnList = m_QueryTableInfo.SelectMany((t) => (t.m_QueryFields.Where((f) => f.IsValidInVersion(versCreate)))).ToList();
            IList<string> queryColumnList = tableColumnList.Select((s) => (s.QueryColumnName())).ToList();

            return queryColumnList;
        }
        public IList<string> QueryAliasNamesForVersion(uint versCreate)
        {
            IList<QueryFieldDefInfo> tableColumnList = m_QueryTableInfo.SelectMany((t) => (t.m_QueryFields.Where((f) => f.IsValidInVersion(versCreate)))).ToList();
            IList<string> queryColumnList = tableColumnList.Select((s) => (s.QueryColumnAlias())).ToList();

            return queryColumnList;
        }

        public IList<string> TableColumnsSourceForVersion(uint versCreate)
        {
            IList<string> columnList = m_QueryTableInfo.SelectMany((t) => (t.m_QueryFields.Where((f) => f.IsValidInVersion(versCreate)).
                Select((s) => (s.ColumnInfoSource(t.AliasName()))))).ToList();

            return columnList;
        }

        public QueryTableDefInfo QueryTableByAlias(string tableAlias)
        {
            QueryTableDefInfo queryTable = m_QueryTableInfo.Where((c) => (c.m_strAliasName.Equals(tableAlias))).SingleOrDefault();

            return queryTable;
        }

        public IList<QueryJoinDefInfo> QueryTableJoins()
        {
            IList<QueryJoinDefInfo> tableJoinList = m_QueryJoinInfo.Where((t) => (t.m_bJoinCondition == true)).ToList();

            return tableJoinList;
        }
        public IList<string> QueryTableFroms()
        {
            return m_QueryTableInfo.Select((t) => (t.TableSourceName())).ToList();
        }
        public IList<QueryJoinDefInfo> QueryWhereJoins(bool bFilterConds)
        {
            IList<QueryJoinDefInfo> tableJoinList = m_QueryJoinInfo.Where((t) => (t.QueryTableJoinOpConds(bFilterConds))).ToList();

            return tableJoinList;
        }

        public IList<string> FiltrConsDefinition()
        {
            var tableFiltrList = m_TableViewFilters.SelectMany((t) => t.QueryFilterCondition()).ToList();

            return tableFiltrList;
        }

        public string InfoName()
        {
            return m_strName;
        }

        #region ICloneable Members

        public object Clone()
        {
            QueryDefInfo other = (QueryDefInfo)this.MemberwiseClone();
            other.m_VersFrom = this.m_VersFrom;
            other.m_VersDrop = this.m_VersDrop;
            other.m_strName = this.m_strName;
            other.m_QueryTableInfo = this.m_QueryTableInfo.ToList();
            other.m_QueryJoinInfo = this.m_QueryJoinInfo.ToList();
            other.m_TableViewFilters = this.m_TableViewFilters.ToList();
            other.m_QueryEndClauses = this.m_QueryEndClauses.ToList();

            return other;
        }

        #endregion
    }
}