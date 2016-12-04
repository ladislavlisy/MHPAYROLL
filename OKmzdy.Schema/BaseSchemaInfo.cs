using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public abstract class BaseSchemaInfo
    {
        protected IDictionary<string, TableDefInfo> ALL_TABLE_DICT = null;
        protected IDictionary<string, TableDefInfo> X01_TABLE_DICT = null;
        protected IDictionary<string, TableDefInfo> I02_TABLE_DICT = null;
        protected IDictionary<string, TableDefInfo> Z02_TABLE_DICT = null;
        protected IDictionary<string, QueryDefInfo> ALL_QUERY_DICT = null;
        public string m_strOwnerName { get; protected set; }
        public string m_strUsersName { get; protected set; }
        public BaseSchemaInfo(string lpszOwnerName, string lpszUsersName)
        {
            m_strOwnerName = lpszOwnerName;
            m_strUsersName = lpszUsersName;

            ALL_TABLE_DICT = CreateTableDictionary();
            X01_TABLE_DICT = CreateSubXTableDictionary();
            I02_TABLE_DICT = CreateSubITableDictionary();
            Z02_TABLE_DICT = CreateSubZTableDictionary();
            ALL_QUERY_DICT = CreateQueryDictionary();
        }

        public IList<TableDefInfo> CreateFilteredTableList(IList<string> filterList)
        {
            return ALL_TABLE_DICT.Where((f) => (!filterList.Contains(f.Key))).Select((s) => (s.Value)).ToList();
        }

        public IList<TableDefInfo> CreateFilteredTableCloneList(IList<string> filterList)
        {
            return ALL_TABLE_DICT.Where((f) => (!filterList.Contains(f.Key))).Select((s) => (TableDefInfo)(s.Value.Clone())).ToList();
        }

        public IList<TableDefInfo> CreateSubsetTableList(IList<string> filterList)
        {
            return filterList.Select((f) => (ALL_TABLE_DICT.Single((k) => (k.Key.Equals(f))).Value)).ToList();
        }

        public IList<TableDefInfo> CreateSubsetTableCloneList(IList<string> filterList)
        {
            return filterList.Select((f) => (TableDefInfo)(ALL_TABLE_DICT.Single((k) => (k.Key.Equals(f))).Value.Clone())).ToList();
        }

        public IList<QueryDefInfo> CreateFilteredQueryList(IList<string> filterList)
        {
            return ALL_QUERY_DICT.Where((f) => (!filterList.Contains(f.Key))).Select((s) => (s.Value)).ToList();
        }

        public IList<QueryDefInfo> CreateFilteredQueryCloneList(IList<string> filterList)
        {
            return ALL_QUERY_DICT.Where((f) => (!filterList.Contains(f.Key))).Select((s) => (QueryDefInfo)(s.Value.Clone())).ToList();
        }

        public IList<QueryDefInfo> CreateSubsetQueryList(IList<string> filterList)
        {
            return filterList.Select((f) => (ALL_QUERY_DICT.Single((k) => (k.Key.Equals(f))).Value)).ToList();
        }

        public IList<QueryDefInfo> CreateSubsetQueryCloneList(IList<string> filterList)
        {
            return filterList.Select((f) => (QueryDefInfo)(ALL_QUERY_DICT.Single((k) => (k.Key.Equals(f))).Value.Clone())).ToList();
        }

        public abstract IDictionary<string, TableDefInfo> CreateTableDictionary();
        public abstract IDictionary<string, TableDefInfo> CreateSubZTableDictionary();
        public abstract IDictionary<string, TableDefInfo> CreateSubITableDictionary();
        public abstract IDictionary<string, TableDefInfo> CreateSubXTableDictionary();
        public abstract IDictionary<string, QueryDefInfo> CreateQueryDictionary();
    }
}
