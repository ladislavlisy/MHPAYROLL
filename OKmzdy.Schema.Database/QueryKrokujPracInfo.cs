using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    class QueryKrokujPracPocitanyInfo : QueryDefInfo
    {
        const string TABLE_NAME = "KROKUJPRAC_POCITANY";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryKrokujPracPocitanyInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryKrokujPracPocitanyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PRAC", TablePracVyberAggrInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("pracovnik_id"),
                    SimpleName.Create("logicky_zrusen"),
                    SimpleName.Create("logicky_neuplny"),
                    SimpleName.Create("pocitane_obdobi"),
                    SimpleName.Create("osobni_cislo"),
                    SimpleName.Create("datum_narozeni"),
                    SimpleName.Create("rodne_cislo"),
                    SimpleName.Create("prijmeni"),
                    SimpleName.Create("jmeno"),
                    SimpleName.Create("titul_pred"),
                    SimpleName.Create("titul_za"),
                    AliasName.Create("zar_mesic", "mesic"),
                    SimpleName.Create("vyuct_cast")
                    ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UTVAR", TableUtvarInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("uutvar_id"),
                    SimpleName.Create("utvnazev"),
                    SimpleName.Create("vyuctgr"),
                    SimpleName.Create("zeme_cislo"),
                    SimpleName.Create("uzivatel_id")
                    ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("PRAC", "UTVAR").
                AddColumn("firma_id", "firma_id").
                AddColumn("uutvar_id", "uutvar_id"));
        }
    }
    class QueryKrokujPracovnikyInfo : QueryDefInfo
    {
        const string TABLE_NAME = "KROKUJPRACOVNIKY";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryKrokujPracovnikyInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryKrokujPracovnikyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PRAC", TablePracInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    AliasName.Create("ppracovnik_id", "pracovnik_id"),
                    SimpleName.Create("logicky_zrusen"),
                    SimpleName.Create("logicky_neuplny"),
                    SimpleName.Create("pocitane_obdobi"),
                    SimpleName.Create("osobni_cislo"),
                    SimpleName.Create("datum_narozeni"),
                    SimpleName.Create("rodne_cislo"),
                    SimpleName.Create("prijmeni"),
                    SimpleName.Create("jmeno"),
                    SimpleName.Create("titul_pred"),
                    SimpleName.Create("titul_za")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UTVAR", TableUtvarInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("uutvar_id"),
                    SimpleName.Create("utvnazev"),
                    SimpleName.Create("vyuctgr"),
                    SimpleName.Create("zeme_cislo"),
                    SimpleName.Create("uzivatel_id")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("DAN", TableDanInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("mesic"),
                    AliasName.Create("informace", "vyuct_cast")
                ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("PRAC", "DAN").
                AddColumn("firma_id", "firma_id").
                AddColumn("ppracovnik_id", "pracovnik_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("DAN", "UTVAR").
                AddColumn("firma_id", "firma_id").
                AddColumn("sazba", "uutvar_id").
                AddLeftColumn("odkud", "=", "0").
                AddLeftColumn("kod", "=", "6100").
                AddLeftColumn("cislo", "=", "1"));
        }
    }
}
