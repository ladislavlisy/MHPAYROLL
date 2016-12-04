using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    class QuerySumaDanInfo : QueryDefInfo
    {
        const string TABLE_NAME = "SUMA_DAN";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QuerySumaDanInfo(lpszOwnerName, lpszUsersName);
        }
        public QuerySumaDanInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("DAN", TableDanInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("mesic"),
                    SimpleName.Create("odkud"),
                    SimpleName.Create("kod"),
                    AliasName.Create("hodnota", "hodnota", "SUM({0})"),
                    AliasName.Create("pocjed", "pocjed", "SUM({0})"),
                    AliasName.Create("pocdal", "pocdal", "SUM({0})"),
                    AliasName.Create("sazba", "sazba", "SUM({0})")
               ));

            AddClause("GROUP BY firma_id, mesic, odkud, kod");
        }
    }
}
