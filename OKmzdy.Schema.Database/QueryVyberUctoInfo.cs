using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    class QueryVyberUcetPrPolozkyInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERUCET_PRPOLOZKY";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberUcetPrPolozkyInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberUcetPrPolozkyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UCPREDP", TableUcetniPredpisyInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    AliasName.Create("ppredpis_id", "predpis_id"),
                    SimpleName.Create("predpis_uckod"),
                    SimpleName.Create("predpis_nazev"),
                    SimpleName.Create("predpis_druh")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UCPOLOZ", TableUcetniPolozkyInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("cislo"),
                    SimpleName.Create("poloz_nazev"),
                    SimpleName.Create("poloz_druh"),
                    SimpleName.Create("poloz_skup"),
                    SimpleName.Create("poloz_synt"),
                    SimpleName.Create("poloz_anal"),
                    SimpleName.Create("poloz_text1"),
                    SimpleName.Create("poloz_inf1"),
                    SimpleName.Create("poloz_delka1"),
                    SimpleName.Create("poloz_fmt1"),
                    SimpleName.Create("poloz_text2"),
                    SimpleName.Create("poloz_inf2"),
                    SimpleName.Create("poloz_delka2"),
                    SimpleName.Create("poloz_fmt2"),
                    SimpleName.Create("poloz_text3"),
                    SimpleName.Create("poloz_inf3"),
                    SimpleName.Create("poloz_delka3"),
                    SimpleName.Create("poloz_fmt3"),
                    SimpleName.Create("poloz_text4"),
                    SimpleName.Create("poloz_inf4"),
                    SimpleName.Create("poloz_delka4"),
                    SimpleName.Create("poloz_fmt4"),
                    SimpleName.Create("poloz_text5"),
                    SimpleName.Create("poloz_inf5"),
                    SimpleName.Create("poloz_delka5"),
                    SimpleName.Create("poloz_fmt5")
                ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("UCPREDP", "UCPOLOZ").
                AddColumn("firma_id", "firma_id").
                AddColumn("ppredpis_id", "predpis_id"));

        }
    }
}
