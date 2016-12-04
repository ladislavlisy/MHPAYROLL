using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    class QueryVyberUtvaryInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERUTVARY";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberUtvaryInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberUtvaryInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UTVAR", TableUtvarInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("uutvar_id"),
                    SimpleName.Create("utvnazev"),
                    SimpleName.Create("poznamka"),
                    SimpleName.Create("zeme_cislo"),
                    SimpleName.Create("vyuctgr")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UZIVATEL", TableUzivatelInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("uuzivatel_id"),
                    SimpleName.Create("uzivjmeno"),
                    SimpleName.Create("uzivfunkce"),
                    SimpleName.Create("uplne_jmeno")
                ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("UTVAR", "UZIVATEL").
                AddColumn("firma_id", "firma_id").
                AddColumn("uzivatel_id", "uuzivatel_id"));

        }
    }
    class QueryVyberPracZarazeniInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERPRAC_ZARAZENI";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberPracZarazeniInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberPracZarazeniInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("MDAN_UTVAR", TableDanInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("pracovnik_id"),
                    SimpleName.Create("mesic"),
                    AliasName.Create("sazba", "cislo_utvar"),
                    AliasName.Create("pocjed", "cislo_zdrpoj")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("MDAN_STRCZ", TableDanInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("cislo_zdroj"),
                    SimpleName.Create("cislo_stred"),
                    SimpleName.Create("cislo_cinnost"),
                    SimpleName.Create("cislo_zakazka")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("MUTVAR", TableUtvarInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    AliasName.Create("utvnazev", "nazev_utvar"),
                    AliasName.Create("zeme_cislo", "cislo_zeme")
                ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("MDAN_UTVAR", "MDAN_STRCZ").
                AddColumn("firma_id", "firma_id").
                AddColumn("pracovnik_id", "pracovnik_id").
                AddColumn("mesic", "mesic").
                AddRightColumn("odkud", "=", "0").
                AddRightColumn("kod", "=", "6100").
                AddRightColumn("cislo", "=", "1").
                AddLeftColumn("odkud", "=", "0").
                AddLeftColumn("kod", "=", "6101").
                AddLeftColumn("cislo", "=", "1"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("MDAN_UTVAR", "MUTVAR").
                AddColumn("firma_id", "firma_id").
                AddColumn("sazba", "uutvar_id"));
        }
    }
    class QueryVyberPPomZarazeniInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERPPOM_ZARAZENI";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberPPomZarazeniInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberPPomZarazeniInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("MMZDA_STRCZ", TableMzdaInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("pracovnik_id"),
                    SimpleName.Create("cislo_pp"),
                    SimpleName.Create("mesic"),
                    AliasName.Create("cislo_zdroj", "ppomer_zdroj"),
                    AliasName.Create("cislo_stred", "ppomer_stred"),
                    AliasName.Create("cislo_cinnost", "ppomer_cinnost"),
                    AliasName.Create("cislo_zakazka", "ppomer_zakazka")
                ));

            AddFiltr(QueryWhereDefInfo.GetQueryWhereDefInfo("MMZDA_STRCZ", TableZsestExtMzdlistInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddConstraints(
                    QueryFilterDefInfo.Create("odkud", "=", "0"),
                    QueryFilterDefInfo.Create("kod", "=", "6000"),
                    QueryFilterDefInfo.Create("cislo", "=", "1")
                ));
        }
    }
    class QueryVyberPracOpravneniInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERPRAC_OPRAVNENI";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberPracOpravneniInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberPracOpravneniInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("DAN_UTVAR", TableDanInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("pracovnik_id"),
                    SimpleName.Create("mesic"),
                    AliasName.Create("informace", "vyuct_cast")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UTVAR", TableUtvarInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("vyuctgr"),
                    SimpleName.Create("uutvar_id"),
                    AliasName.Create("utvnazev", "nazev_utvar"),
                    AliasName.Create("zeme_cislo", "cislo_zeme"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("personal_id"),
                    SimpleName.Create("prohlizet_id"),
                    SimpleName.Create("omezproh_id"),
                    SimpleName.Create("referzp_id")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UPRES", TableUtvarInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    AliasName.Create("uutvar_id", "uupres_id"),
                    AliasName.Create("utvnazev", "nazev_upres"),
                    AliasName.Create("uzivatel_id", "uziv_pres"),
                    AliasName.Create("personal_id", "pers_pres"),
                    AliasName.Create("prohlizet_id", "proh_pres"),
                    AliasName.Create("omezproh_id", "omez_pres"),
                    AliasName.Create("referzp_id", "refz_pres")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UZIVATEL", TableUzivatelInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("uzivjmeno")
                ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("DAN_UTVAR", "UTVAR").
                AddColumn("firma_id", "firma_id").
                AddColumn("sazba", "uutvar_id").
                AddLeftColumn("odkud", "=", "0").
                AddLeftColumn("kod", "=", "6100").
                AddLeftColumn("cislo", "=", "1"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("DAN_UTVAR", "UPRES").
                AddColumn("firma_id", "firma_id").
                AddColumn("hodnota", "uutvar_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("UTVAR", "UZIVATEL").
                AddColumn("firma_id", "firma_id").
                AddColumn("uzivatel_id", "uuzivatel_id"));

        }
    }
    class QueryVyberPracovnikyFiltrXOInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERPRACOVNIKY_FILTR_XO";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberPracovnikyFiltrXOInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberPracovnikyFiltrXOInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PRAC", TablePracInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    AliasName.Create("ppracovnik_id", "pracovnik_id"),
                    SimpleName.Create("logicky_zrusen"), 
                    SimpleName.Create("logicky_neuplny"),
                    SimpleName.Create("osobni_cislo"), 
                    SimpleName.Create("rodne_cislo"), 
                    SimpleName.Create("nema_rodcis"),
                    SimpleName.Create("prijmeni"),
                    SimpleName.Create("jmeno"), 
                    SimpleName.Create("titul_pred"), 
                    SimpleName.Create("titul_za"),
                    SimpleName.Create("datum_narozeni"), 
                    SimpleName.Create("pohlavi")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PPOMER", TablePpomerInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("cislo_pp"), 
                    SimpleName.Create("pompopis"), 
                    SimpleName.Create("funkce"),
                    SimpleName.Create("praczac"), 
                    SimpleName.Create("prackon"), 
                    SimpleName.Create("druh"), 
                    SimpleName.Create("druh07"),
                    SimpleName.Create("ppomer_cislo"),
                    SimpleName.Create("kzam"), 
                    SimpleName.Create("platova_trida"), 
                    SimpleName.Create("platovy_stupen"),
                    SimpleName.Create("spraxe_roku"), 
                    SimpleName.Create("praxe_dnu")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("OPR", QueryVyberPracOpravneniInfo.GetDictValue(lpszOwnerName, lpszUsersName).GetTableDef()).
                AddColumns(
                    AliasName.Create("mesic", "zar_mesic"),
                    AliasName.Create("mesic", "opr_mesic"),
                    SimpleName.Create("uzivjmeno"), 
                    SimpleName.Create("nazev_utvar"), 
                    SimpleName.Create("cislo_zeme"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("personal_id"), 
                    SimpleName.Create("prohlizet_id"),
                    SimpleName.Create("omezproh_id"), 
                    SimpleName.Create("referzp_id"),
                    SimpleName.Create("uziv_pres"), 
                    SimpleName.Create("pers_pres"), 
                    SimpleName.Create("proh_pres"),
                    SimpleName.Create("omez_pres"), 
                    SimpleName.Create("refz_pres"),
                    SimpleName.Create("uutvar_id"), 
                    SimpleName.Create("vyuctgr"), 
                    SimpleName.Create("vyuct_cast"),
                    SimpleName.Create("uupres_id"), 
                    SimpleName.Create("nazev_upres")
               ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("PRAC", "PPOMER").
                AddColumn("firma_id", "firma_id").
                AddColumn("ppracovnik_id", "pracovnik_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("PPOMER", "OPR").
                AddColumn("firma_id", "firma_id").
                AddColumn("pracovnik_id", "pracovnik_id"));

        }
    }
    class QueryVyberPracovnikyFiltrXPInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERPRACOVNIKY_FILTR_XP";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberPracovnikyFiltrXPInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberPracovnikyFiltrXPInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PRAC", TablePracInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    AliasName.Create("ppracovnik_id", "pracovnik_id"),
                    SimpleName.Create("logicky_zrusen"),
                    SimpleName.Create("logicky_neuplny"),
                    SimpleName.Create("osobni_cislo"),
                    SimpleName.Create("rodne_cislo"),
                    SimpleName.Create("nema_rodcis"),
                    SimpleName.Create("prijmeni"),
                    SimpleName.Create("jmeno"),
                    SimpleName.Create("titul_pred"),
                    SimpleName.Create("titul_za"),
                    SimpleName.Create("datum_narozeni"),
                    SimpleName.Create("pohlavi")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PPOMER", TablePpomerInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("cislo_pp"),
                    SimpleName.Create("pompopis"),
                    SimpleName.Create("funkce"),
                    SimpleName.Create("praczac"),
                    SimpleName.Create("prackon"),
                    SimpleName.Create("druh"),
                    SimpleName.Create("druh07"),
                    SimpleName.Create("ppomer_cislo"),
                    SimpleName.Create("kzam"),
                    SimpleName.Create("platova_trida"),
                    SimpleName.Create("platovy_stupen"),
                    SimpleName.Create("spraxe_roku"),
                    SimpleName.Create("praxe_dnu")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("OPR", QueryVyberPracOpravneniInfo.GetDictValue(lpszOwnerName, lpszUsersName).GetTableDef()).
                AddColumns(
                    AliasName.Create("mesic", "opr_mesic"),
                    SimpleName.Create("uzivjmeno"),
                    SimpleName.Create("nazev_utvar"),
                    SimpleName.Create("cislo_zeme"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("personal_id"),
                    SimpleName.Create("prohlizet_id"),
                    SimpleName.Create("omezproh_id"),
                    SimpleName.Create("referzp_id"),
                    SimpleName.Create("uziv_pres"),
                    SimpleName.Create("pers_pres"),
                    SimpleName.Create("proh_pres"),
                    SimpleName.Create("omez_pres"),
                    SimpleName.Create("refz_pres"),
                    SimpleName.Create("uutvar_id"),
                    SimpleName.Create("vyuctgr"),
                    SimpleName.Create("vyuct_cast"),
                    SimpleName.Create("uupres_id"),
                    SimpleName.Create("nazev_upres")
               ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PPZ", QueryVyberPPomZarazeniInfo.GetDictValue(lpszOwnerName, lpszUsersName).GetTableDef()).
                AddColumns(
                    AliasName.Create("mesic", "zar_mesic"),
                    SimpleName.Create("ppomer_zdroj"),
                    SimpleName.Create("ppomer_stred"),
                    SimpleName.Create("ppomer_cinnost"),
                    SimpleName.Create("ppomer_zakazka")
               ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("PRAC", "PPOMER").
                AddColumn("firma_id", "firma_id").
                AddColumn("ppracovnik_id", "pracovnik_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("PPOMER", "OPR").
                AddColumn("firma_id", "firma_id").
                AddColumn("pracovnik_id", "pracovnik_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("PPOMER", "PPZ").
                AddColumn("firma_id", "firma_id").
                AddColumn("pracovnik_id", "pracovnik_id").
                AddColumn("cislo_pp", "cislo_pp"));

        }
    }
    class QueryVyberPracovnikyFiltrXZInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERPRACOVNIKY_FILTR_XZ";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberPracovnikyFiltrXZInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberPracovnikyFiltrXZInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PRAC", TablePracInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    AliasName.Create("ppracovnik_id", "pracovnik_id"),
                    SimpleName.Create("logicky_zrusen"),
                    SimpleName.Create("logicky_neuplny"),
                    SimpleName.Create("osobni_cislo"),
                    SimpleName.Create("rodne_cislo"),
                    SimpleName.Create("nema_rodcis"),
                    SimpleName.Create("prijmeni"),
                    SimpleName.Create("jmeno"),
                    SimpleName.Create("titul_pred"),
                    SimpleName.Create("titul_za"),
                    SimpleName.Create("datum_narozeni"),
                    SimpleName.Create("pohlavi")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PPOMER", TablePpomerInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("cislo_pp"),
                    SimpleName.Create("pompopis"),
                    SimpleName.Create("funkce"),
                    SimpleName.Create("praczac"),
                    SimpleName.Create("prackon"),
                    SimpleName.Create("druh"),
                    SimpleName.Create("druh07"),
                    SimpleName.Create("ppomer_cislo"),
                    SimpleName.Create("kzam"),
                    SimpleName.Create("platova_trida"),
                    SimpleName.Create("platovy_stupen"),
                    SimpleName.Create("spraxe_roku"),
                    SimpleName.Create("praxe_dnu")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("OPR", QueryVyberPracOpravneniInfo.GetDictValue(lpszOwnerName, lpszUsersName).GetTableDef()).
                AddColumns(
                    AliasName.Create("mesic", "opr_mesic"),
                    SimpleName.Create("uzivjmeno"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("personal_id"),
                    SimpleName.Create("prohlizet_id"),
                    SimpleName.Create("omezproh_id"),
                    SimpleName.Create("referzp_id"),
                    SimpleName.Create("uziv_pres"),
                    SimpleName.Create("pers_pres"),
                    SimpleName.Create("proh_pres"),
                    SimpleName.Create("omez_pres"),
                    SimpleName.Create("refz_pres"),
                    SimpleName.Create("uutvar_id"),
                    SimpleName.Create("vyuctgr"),
                    SimpleName.Create("vyuct_cast"),
                    SimpleName.Create("uupres_id"),
                    SimpleName.Create("nazev_upres")
               ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("ZAR", QueryVyberPracZarazeniInfo.GetDictValue(lpszOwnerName, lpszUsersName).GetTableDef()).
                AddColumns(
                    AliasName.Create("mesic", "zar_mesic"),
                    SimpleName.Create("nazev_utvar"),
                    SimpleName.Create("cislo_zeme"),
                    SimpleName.Create("cislo_utvar"),
                    SimpleName.Create("cislo_zdrpoj"),
                    SimpleName.Create("cislo_zdroj"),
                    SimpleName.Create("cislo_stred"),
                    SimpleName.Create("cislo_cinnost"),
                    SimpleName.Create("cislo_zakazka")
               ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("PRAC", "PPOMER").
                AddColumn("firma_id", "firma_id").
                AddColumn("ppracovnik_id", "pracovnik_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("PPOMER", "OPR").
                AddColumn("firma_id", "firma_id").
                AddColumn("pracovnik_id", "pracovnik_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("PPOMER", "ZAR").
                AddColumn("firma_id", "firma_id").
                AddColumn("pracovnik_id", "pracovnik_id"));
        }
    }
    class QueryVyberPracovnikyFiltrZPInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERPRACOVNIKY_FILTR_ZP";

        const string QUERY_SQL = "SELECT " +
                    " [PRAC].[firma_id] AS [firma_id], " +
                    " [PRAC].[ppracovnik_id] AS [pracovnik_id],  " +
                    " [ZAR].[mesic] AS [zar_mesic], [OPR].[mesic] AS [opr_mesic], " +
                    " [PRAC].[logicky_zrusen] AS [logicky_zrusen], [PRAC].[logicky_neuplny] AS [logicky_neuplny],  " +
                    " [PRAC].[osobni_cislo] AS [osobni_cislo], [PRAC].[rodne_cislo] AS [rodne_cislo], [PRAC].[nema_rodcis] AS [nema_rodcis], " +
                    " [PRAC].[prijmeni] AS [prijmeni], [PRAC].[jmeno] AS [jmeno], [PRAC].[titul_pred] AS [titul_pred], [PRAC].[titul_za] AS [titul_za], " +
                    " [PPOMER].[cislo_pp] AS [cislo_pp], [PPOMER].[pompopis] AS [pompopis], [PPOMER].[funkce] AS [funkce], " +
                    " [PPOMER].[praczac] AS [praczac], [PPOMER].[prackon] AS [prackon], [PPOMER].[druh] AS [druh], [PPOMER].[druh07] AS [druh07], " +
                    " [OPR].[uzivjmeno] AS [uzivjmeno], [ZAR].[nazev_utvar] AS [nazev_utvar], [ZAR].[cislo_zeme] AS [cislo_zeme], " +
                    " [PRAC].[datum_narozeni] AS [datum_narozeni], [PRAC].[pohlavi] AS [pohlavi], " +
                    " [PPOMER].[ppomer_cislo] AS [ppomer_cislo], " +
                    " [PPOMER].[kzam] AS [kzam], [PPOMER].[platova_trida] AS [platova_trida], [PPOMER].[platovy_stupen] AS [platovy_stupen], " +
                    " [PPOMER].[spraxe_roku] AS [spraxe_roku], [PPOMER].[praxe_dnu] AS [praxe_dnu], " +
                    " [OPR].[uzivatel_id] AS [uzivatel_id], [OPR].[personal_id] AS [personal_id], [OPR].[prohlizet_id] AS [prohlizet_id], " +
                    " [OPR].[omezproh_id] AS [omezproh_id], [OPR].[referzp_id] AS [referzp_id], " +
                    " [OPR].[uziv_pres] AS [uziv_pres], [OPR].[pers_pres] AS [pers_pres], [OPR].[proh_pres] AS [proh_pres], " +
                    " [OPR].[omez_pres] AS [omez_pres], [OPR].[refz_pres] AS [refz_pres], " +
                    " [OPR].[uutvar_id] AS [uutvar_id], [OPR].[vyuctgr] AS [vyuctgr], [OPR].[vyuct_cast] AS [vyuct_cast], " +
                    " [OPR].[uupres_id] AS [uupres_id], [OPR].[nazev_upres] AS [nazev_upres], " +
                    " [ZAR].[cislo_utvar] AS [cislo_utvar], " +
                    " [ZAR].[cislo_zdrpoj] AS [cislo_zdrpoj], " +
                    " [ZAR].[cislo_zdroj] AS [cislo_zdroj], [ZAR].[cislo_stred] AS [cislo_stred], " +
                    " [ZAR].[cislo_cinnost] AS [cislo_cinnost], [ZAR].[cislo_zakazka] AS [cislo_zakazka], " +
                    " [PPZ].[ppomer_zdroj] AS [ppomer_zdroj], [PPZ].[ppomer_stred] AS [ppomer_stred], " +
                    " [PPZ].[ppomer_cinnost] AS [ppomer_cinnost], [PPZ].[ppomer_zakazka] AS [ppomer_zakazka] " +
                    " FROM [PRAC], [PPOMER], [VYBERPRAC_OPRAVNENI] [OPR], [VYBERPRAC_ZARAZENI] [ZAR], [VYBERPPOM_ZARAZENI] [PPZ] " +
                    " WHERE PRAC.firma_id = PPOMER.firma_id " +
                    " AND   OPR.firma_id = PPOMER.firma_id " +
                    " AND   ZAR.firma_id = PPOMER.firma_id " +
                    " AND   PPZ.firma_id = PPOMER.firma_id " +
                    " AND   PRAC.ppracovnik_id = PPOMER.pracovnik_id " +
                    " AND   OPR.pracovnik_id = PPOMER.pracovnik_id " +
                    " AND   ZAR.pracovnik_id = PPOMER.pracovnik_id " +
                    " AND   PPZ.pracovnik_id = PPOMER.pracovnik_id " +
                    " AND   PPZ.cislo_pp = PPOMER.cislo_pp " +
                    " AND   PPZ.mesic = ZAR.mesic ";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberPracovnikyFiltrZPInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberPracovnikyFiltrZPInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PRAC", TablePracInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    AliasName.Create("ppracovnik_id", "pracovnik_id"),
                    SimpleName.Create("logicky_zrusen"),
                    SimpleName.Create("logicky_neuplny"),
                    SimpleName.Create("osobni_cislo"),
                    SimpleName.Create("rodne_cislo"),
                    SimpleName.Create("nema_rodcis"),
                    SimpleName.Create("prijmeni"),
                    SimpleName.Create("jmeno"),
                    SimpleName.Create("titul_pred"),
                    SimpleName.Create("titul_za"),
                    SimpleName.Create("datum_narozeni"),
                    SimpleName.Create("pohlavi")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PPOMER", TablePpomerInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("cislo_pp"),
                    SimpleName.Create("pompopis"),
                    SimpleName.Create("funkce"),
                    SimpleName.Create("praczac"),
                    SimpleName.Create("prackon"),
                    SimpleName.Create("druh"),
                    SimpleName.Create("druh07"),
                    SimpleName.Create("ppomer_cislo"),
                    SimpleName.Create("kzam"),
                    SimpleName.Create("platova_trida"),
                    SimpleName.Create("platovy_stupen"),
                    SimpleName.Create("spraxe_roku"),
                    SimpleName.Create("praxe_dnu")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("OPR", QueryVyberPracOpravneniInfo.GetDictValue(lpszOwnerName, lpszUsersName).GetTableDef()).
                AddColumns(
                    AliasName.Create("mesic", "opr_mesic"),
                    SimpleName.Create("uzivjmeno"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("personal_id"),
                    SimpleName.Create("prohlizet_id"),
                    SimpleName.Create("omezproh_id"),
                    SimpleName.Create("referzp_id"),
                    SimpleName.Create("uziv_pres"),
                    SimpleName.Create("pers_pres"),
                    SimpleName.Create("proh_pres"),
                    SimpleName.Create("omez_pres"),
                    SimpleName.Create("refz_pres"),
                    SimpleName.Create("uutvar_id"),
                    SimpleName.Create("vyuctgr"),
                    SimpleName.Create("vyuct_cast"),
                    SimpleName.Create("uupres_id"),
                    SimpleName.Create("nazev_upres")
               ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("ZAR", QueryVyberPracZarazeniInfo.GetDictValue(lpszOwnerName, lpszUsersName).GetTableDef()).
                AddColumns(
                    AliasName.Create("mesic", "zar_mesic"),
                    SimpleName.Create("nazev_utvar"),
                    SimpleName.Create("cislo_zeme"),
                    SimpleName.Create("cislo_utvar"),
                    SimpleName.Create("cislo_zdrpoj"),
                    SimpleName.Create("cislo_zdroj"),
                    SimpleName.Create("cislo_stred"),
                    SimpleName.Create("cislo_cinnost"),
                    SimpleName.Create("cislo_zakazka")
               ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PPZ", QueryVyberPPomZarazeniInfo.GetDictValue(lpszOwnerName, lpszUsersName).GetTableDef()).
                AddColumns(
                    SimpleName.Create("ppomer_zdroj"),
                    SimpleName.Create("ppomer_stred"),
                    SimpleName.Create("ppomer_cinnost"),
                    SimpleName.Create("ppomer_zakazka")
               ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("PRAC", "PPOMER").
                AddColumn("firma_id", "firma_id").
                AddColumn("ppracovnik_id", "pracovnik_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("PPOMER", "OPR").
                AddColumn("firma_id", "firma_id").
                AddColumn("pracovnik_id", "pracovnik_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("PPOMER", "ZAR").
                AddColumn("firma_id", "firma_id").
                AddColumn("pracovnik_id", "pracovnik_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("PPOMER", "PPZ").
                AddColumn("firma_id", "firma_id").
                AddColumn("pracovnik_id", "pracovnik_id").
                AddColumn("cislo_pp", "cislo_pp").
                AddRightColumn("mesic", "=", "ZAR.mesic"));
        }
    }
    public class QueryVyberPracPocitanyInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERPRAC_POCITANY";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberPracPocitanyInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberPracPocitanyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("VPFZ", TablePracVyberAggrInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("pracovnik_id"),
                    AliasName.Create("zar_mesic", "mesic"),
                    SimpleName.Create("zar_mesic"),
                    SimpleName.Create("opr_mesic"),
                    SimpleName.Create("logicky_zrusen"),
                    SimpleName.Create("logicky_neuplny"),
                    SimpleName.Create("osobni_cislo"),
                    SimpleName.Create("rodne_cislo"),
                    SimpleName.Create("nema_rodcis"),
                    SimpleName.Create("prijmeni"),
                    SimpleName.Create("jmeno"),
                    SimpleName.Create("titul_pred"),
                    SimpleName.Create("titul_za"),
                    SimpleName.Create("cislo_pp"),
                    SimpleName.Create("pompopis"),
                    SimpleName.Create("funkce"),
                    SimpleName.Create("praczac"),
                    SimpleName.Create("prackon"),
                    SimpleName.Create("druh"),
                    SimpleName.Create("druh07"),
                    SimpleName.Create("datum_narozeni"),
                    SimpleName.Create("pohlavi"),
                    SimpleName.Create("ppomer_cislo"),
                    SimpleName.Create("kzam"),
                    SimpleName.Create("platova_trida"),
                    SimpleName.Create("platovy_stupen"),
                    SimpleName.Create("spraxe_roku"),
                    SimpleName.Create("praxe_dnu"),
                    SimpleName.Create("cislo_zdrpoj"),
                    SimpleName.Create("cislo_zdroj"),
                    SimpleName.Create("cislo_stred"),
                    SimpleName.Create("cislo_cinnost"),
                    SimpleName.Create("cislo_zakazka"),
                    SimpleName.Create("ppomer_zdroj"),
                    SimpleName.Create("ppomer_stred"),
                    SimpleName.Create("ppomer_cinnost"),
                    SimpleName.Create("ppomer_zakazka"),
                    SimpleName.Create("cislo_utvar"),
                    SimpleName.Create("uutvar_id"),
                    SimpleName.Create("vyuct_cast"),
                    SimpleName.Create("uupres_id")));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UTVAR", TableUtvarInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    AliasName.Create("utvnazev", "nazev_utvar"),
                    AliasName.Create("zeme_cislo", "cislo_zeme"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("personal_id"),
                    SimpleName.Create("prohlizet_id"),
                    SimpleName.Create("omezproh_id"),
                    SimpleName.Create("referzp_id")));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UPRES", TableUtvarInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    AliasName.Create("utvnazev", "nazev_upres"),
                    AliasName.Create("uzivatel_id", "uziv_pres"),
                    AliasName.Create("personal_id", "pers_pres"),
                    AliasName.Create("prohlizet_id", "proh_pres"),
                    AliasName.Create("omezproh_id", "omez_pres"),
                    AliasName.Create("referzp_id", "refz_pres")));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UZIVATEL", TableUzivatelInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("uzivjmeno")));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("VPFZ", "UTVAR").
                AddColumn("firma_id", "firma_id").
                AddColumn("cislo_utvar", "uutvar_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("VPFZ", "UPRES").
                AddColumn("firma_id", "firma_id").
                AddColumn("uupres_id", "uutvar_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("UTVAR", "UZIVATEL").
                AddColumn("firma_id", "firma_id").
                AddColumn("uzivatel_id", "uuzivatel_id"));
        }

    }

    class QueryVyberPracovnikyInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERPRACOVNIKY";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberPracovnikyInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberPracovnikyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("VPFZ", QueryVyberPracovnikyFiltrZPInfo.GetDictValue(lpszOwnerName, lpszUsersName).GetTableDef()).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("pracovnik_id"),
                    AliasName.Create("zar_mesic", "mesic"),
                    SimpleName.Create("logicky_zrusen"),
                    SimpleName.Create("logicky_neuplny"),
                    SimpleName.Create("osobni_cislo"),
                    SimpleName.Create("rodne_cislo"),
                    SimpleName.Create("nema_rodcis"),
                    SimpleName.Create("prijmeni"),
                    SimpleName.Create("jmeno"),
                    SimpleName.Create("titul_pred"),
                    SimpleName.Create("titul_za"),
                    SimpleName.Create("cislo_pp"),
                    SimpleName.Create("pompopis"),
                    SimpleName.Create("funkce"),
                    SimpleName.Create("praczac"),
                    SimpleName.Create("prackon"),
                    SimpleName.Create("druh"),
                    SimpleName.Create("druh07"),
                    SimpleName.Create("uzivjmeno"),
                    SimpleName.Create("nazev_utvar"),
                    SimpleName.Create("cislo_zeme"),
                    SimpleName.Create("datum_narozeni"),
                    SimpleName.Create("pohlavi"),
                    SimpleName.Create("ppomer_cislo"),
                    SimpleName.Create("kzam"),
                    SimpleName.Create("platova_trida"),
                    SimpleName.Create("platovy_stupen"),
                    SimpleName.Create("spraxe_roku"),
                    SimpleName.Create("praxe_dnu"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("personal_id"),
                    SimpleName.Create("prohlizet_id"),
                    SimpleName.Create("omezproh_id"),
                    SimpleName.Create("referzp_id"),
                    SimpleName.Create("uziv_pres"),
                    SimpleName.Create("pers_pres"),
                    SimpleName.Create("proh_pres"),
                    SimpleName.Create("omez_pres"),
                    SimpleName.Create("refz_pres"),
                    SimpleName.Create("uutvar_id"),
                    SimpleName.Create("vyuctgr"),
                    SimpleName.Create("vyuct_cast"),
                    SimpleName.Create("uupres_id"),
                    SimpleName.Create("nazev_upres"),
                    SimpleName.Create("cislo_utvar"),
                    SimpleName.Create("cislo_zdrpoj"),
                    SimpleName.Create("cislo_zdroj"),
                    SimpleName.Create("cislo_stred"),
                    SimpleName.Create("cislo_cinnost"),
                    SimpleName.Create("cislo_zakazka"),
                    SimpleName.Create("ppomer_zdroj"),
                    SimpleName.Create("ppomer_stred"),
                    SimpleName.Create("ppomer_cinnost"),
                    SimpleName.Create("ppomer_zakazka")
                 ));

            AddFiltr(QueryWhereDefInfo.GetQueryWhereDefInfo("VPFZ", QueryVyberPracovnikyFiltrZPInfo.GetDictValue(lpszOwnerName, lpszUsersName).GetTableDef()).
                AddConstraints(
                    QueryFilterDefInfo.Create("zar_mesic", "=", "opr_mesic")
                ));
        }
    }
}
