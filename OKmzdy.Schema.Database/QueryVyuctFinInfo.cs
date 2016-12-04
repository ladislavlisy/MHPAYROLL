using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    class QueryHodnVyuctFinInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VSEST_HODNVYUCTFIN";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryHodnVyuctFinInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryHodnVyuctFinInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("VFIN", TableZsestPrehvyuctfinInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("kod_data"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("skupina"),
                    SimpleName.Create("kod"),
                    AliasName.Create("hodnota_numb", "hodnota_numb", "SUM({0})")
                ));

            AddFiltr(QueryWhereDefInfo.GetQueryWhereDefInfo("VFIN", TableZsestPrehvyuctfinInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddConstraints(
                    QueryFilterDefInfo.Create("mesic", "<>", "0"),
                    QueryFilterDefInfo.Create("poradi", "=", "0")
                ));

            AddClause("GROUP BY firma_id, kod_data, uzivatel_id, skupina, kod");
        }
    }
    class QueryCelkVyuctFinInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VSEST_CELKVYUCTFIN";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryCelkVyuctFinInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryCelkVyuctFinInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("VFIN", TableZsestPrehvyuctfinInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("kod_data"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("kod"),
                    AliasName.Create("hodnota_numb", "hodnota_numb", "SUM({0})")
                ));

            AddFiltr(QueryWhereDefInfo.GetQueryWhereDefInfo("VFIN", TableZsestPrehvyuctfinInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddConstraints(
                    QueryFilterDefInfo.Create("mesic", "<>", "0"),
                    QueryFilterDefInfo.Create("poradi", "=", "0")
                ));

            AddClause("GROUP BY firma_id, kod_data, uzivatel_id, kod");
        }
    }
}
