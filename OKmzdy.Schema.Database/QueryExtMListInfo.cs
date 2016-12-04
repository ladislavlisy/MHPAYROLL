using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    class QueryHodnExtMListInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VSEST_HODNEXTMLIST";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryHodnExtMListInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryHodnExtMListInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("EXTML", TableZsestExtMzdlistInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("kod_data"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("pracovnik_id"),
                    SimpleName.Create("pomer_id"),
                    SimpleName.Create("mesic_opr"),
                    SimpleName.Create("skupina"),
                    SimpleName.Create("kod"),
                    SimpleName.Create("hodnota_numb"),
                    SimpleName.Create("hodnota_text")));

            AddFiltr(QueryWhereDefInfo.GetQueryWhereDefInfo("EXTML", TableZsestExtMzdlistInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddConstraints(
                    QueryFilterDefInfo.Create("mesic", "<>", "0"),
                    QueryFilterDefInfo.Create("poradi", "=", "0")));
        }
    }
    class QueryCelkExtMListInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VSEST_CELKEXTMLIST";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryCelkExtMListInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryCelkExtMListInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("EXTML", TableZsestExtMzdlistInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("kod_data"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("pracovnik_id"),
                    SimpleName.Create("pomer_id"),
                    SimpleName.Create("mesic_opr"),
                    SimpleName.Create("kod"),
                    SimpleName.Create("hodnota_numb", "SUM({0})")));

            AddFiltr(QueryWhereDefInfo.GetQueryWhereDefInfo("EXTML", TableZsestExtMzdlistInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddConstraints(
                    QueryFilterDefInfo.Create("mesic", "<>", "0"),
                    QueryFilterDefInfo.Create("poradi", "=", "0")));

            AddClause("GROUP BY firma_id, kod_data, uzivatel_id, pracovnik_id, pomer_id, mesic_opr, kod");
        }
    }
}
