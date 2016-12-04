using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    class QueryVyberReldp09DavkaInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERRELDP09DAVKA";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberReldp09DavkaInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberReldp09DavkaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UD", TableUzivReldpDavkaInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    AliasName.Create("ddavka_reldp_id", "davka_reldp_id"),
                    SimpleName.Create("uzivatel_id"),
                    AliasName.Create("vydano_dat", "vydano_dat", "MAX({0})"),
                    AliasName.Create("info_davka", "info_davka", "MAX({0})")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PP", TablePracReldp09DataPracInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    AliasName.Create("eldp_rok", "eldp_rok", "MAX({0})")
                ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("UD", "PP").
                AddColumn("firma_id", "firma_id").
                AddColumn("ddavka_reldp_id", "davka_reldp_id").
                AddColumn("uzivatel_id", "uzivatel_id"));

            AddClause("GROUP BY UD.firma_id, UD.ddavka_reldp_id, UD.uzivatel_id");
        }
    }
    class QueryVyberReldp09DataInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERRELDP09DATA";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberReldp09DataInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberReldp09DataInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UD", TableUzivReldpDavkaInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("ddavka_reldp_id"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("vydano_dat"),
                    SimpleName.Create("info_davka")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("EPRAC", TablePracReldp09DataPracInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("pracovnik_id"),
                    SimpleName.Create("sprava_id"),
                    SimpleName.Create("eldp_rok"),
                    SimpleName.Create("eldp_oprava"),
                    SimpleName.Create("prijmeni"),
                    SimpleName.Create("jmeno"),
                    SimpleName.Create("titul"),
                    SimpleName.Create("rodne_prijmeni"),
                    SimpleName.Create("datum_narozeni"),
                    SimpleName.Create("rodne_cislo"),
                    SimpleName.Create("ulice"),
                    SimpleName.Create("cislo_domu"),
                    SimpleName.Create("obec"),
                    SimpleName.Create("posta"),
                    SimpleName.Create("psc"),
                    SimpleName.Create("stat"),
                    SimpleName.Create("misto_narozeni")
                   ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("EPOJ", TablePracReldp09DataPojInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("pomer_id"),
                    SimpleName.Create("eldp_typ"),
                    SimpleName.Create("stranka"),
                    SimpleName.Create("radek"),
                    SimpleName.Create("kod"),
                    SimpleName.Create("maly_rozsah"),
                    SimpleName.Create("cinn_od"),
                    SimpleName.Create("cinn_do"),
                    SimpleName.Create("dny"),
                    SimpleName.Create("vyd_cinn_od"),
                    SimpleName.Create("s1"),
                    SimpleName.Create("s2"),
                    SimpleName.Create("s3"),
                    SimpleName.Create("s4"),
                    SimpleName.Create("s5"),
                    SimpleName.Create("s6"),
                    SimpleName.Create("s7"),
                    SimpleName.Create("s8"),
                    SimpleName.Create("s9"),
                    SimpleName.Create("s10"),
                    SimpleName.Create("s11"),
                    SimpleName.Create("s12"),
                    SimpleName.Create("s1_12"),
                    SimpleName.Create("vylouc_doby1"),
                    SimpleName.Create("vymer_zaklad1"),
                    SimpleName.Create("doby_odecet1"),
                    SimpleName.Create("vylouc_doby2"),
                    SimpleName.Create("vymer_zaklad2"),
                    SimpleName.Create("doby_odecet2"),
                    SimpleName.Create("vylouc_doby3"),
                    SimpleName.Create("vymer_zaklad3"),
                    SimpleName.Create("doby_odecet3"),
                    SimpleName.Create("vylouc_doby4"),
                    SimpleName.Create("vymer_zaklad4"),
                    SimpleName.Create("doby_odecet4"),
                    SimpleName.Create("vylouc_doby5"),
                    SimpleName.Create("vymer_zaklad5"),
                    SimpleName.Create("doby_odecet5"),
                    SimpleName.Create("vylouc_doby6"),
                    SimpleName.Create("vymer_zaklad6"),
                    SimpleName.Create("doby_odecet6"),
                    SimpleName.Create("vylouc_doby7"),
                    SimpleName.Create("vymer_zaklad7"),
                    SimpleName.Create("doby_odecet7"),
                    SimpleName.Create("vylouc_doby8"),
                    SimpleName.Create("vymer_zaklad8"),
                    SimpleName.Create("doby_odecet8"),
                    SimpleName.Create("vylouc_doby9"),
                    SimpleName.Create("vymer_zaklad9"),
                    SimpleName.Create("doby_odecet9"),
                    SimpleName.Create("vylouc_doby10"),
                    SimpleName.Create("vymer_zaklad10"),
                    SimpleName.Create("doby_odecet10"),
                    SimpleName.Create("vylouc_doby11"),
                    SimpleName.Create("vymer_zaklad11"),
                    SimpleName.Create("doby_odecet11"),
                    SimpleName.Create("vylouc_doby12"),
                    SimpleName.Create("vymer_zaklad12"),
                    SimpleName.Create("doby_odecet12")
                ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("UD", "EPRAC").
                AddColumn("firma_id", "firma_id").
                AddColumn("ddavka_reldp_id", "davka_reldp_id").
                AddColumn("uzivatel_id", "uzivatel_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("EPRAC", "EPOJ").
                AddColumn("firma_id", "firma_id").
                AddColumn("davka_reldp_id", "davka_reldp_id").
                AddColumn("uzivatel_id", "uzivatel_id").
                AddColumn("pracovnik_id", "pracovnik_id").
                AddColumn("sprava_id", "sprava_id"));

        }
    }
    class QueryVyberReldpDavkaInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERRELDPDAVKA";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberReldpDavkaInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberReldpDavkaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UD", TableUzivReldpDavkaInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    AliasName.Create("ddavka_reldp_id", "davka_reldp_id"),
                    SimpleName.Create("uzivatel_id"),
                    AliasName.Create("vydano_dat", "vydano_dat", "MAX({0})"),
                    AliasName.Create("info_davka", "info_davka", "MAX({0})")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PL", TablePracReldpListekInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    AliasName.Create("eldprok", "eldprok", "MAX({0})")
                 ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("UD", "PL").
                AddColumn("firma_id", "firma_id").
                AddColumn("ddavka_reldp_id", "davka_reldp_id").
                AddColumn("uzivatel_id", "uzivatel_id"));

            AddClause("GROUP BY UD.firma_id, UD.ddavka_reldp_id, UD.uzivatel_id");
        }
    }
    class QueryVyberReldpDataInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERRELDPDATA";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberReldpDataInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberReldpDataInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UD", TableUzivReldpDavkaInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("vydano_dat"),
                    SimpleName.Create("neprijata"),
                    SimpleName.Create("info_davka")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PL", TablePracReldpListekInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("pracovnik_id"),
                    SimpleName.Create("davka_reldp_id"),
                    SimpleName.Create("eldppgn"),
                    SimpleName.Create("logicky_zrusen"),
                    SimpleName.Create("info_eldp"),
                    SimpleName.Create("eldprok"),
                    SimpleName.Create("datum_narozeni"),
                    SimpleName.Create("rodne_cislo"),
                    SimpleName.Create("rodne_prijmeni"),
                    SimpleName.Create("uplne_jmeno"),
                    SimpleName.Create("misto_narozeni"),
                    SimpleName.Create("posledni_prijmeni"),
                    SimpleName.Create("adresa1_3"),
                    SimpleName.Create("eldptyp"),
                    SimpleName.Create("zacatek"),
                    SimpleName.Create("eldpvydzedne"),
                    SimpleName.Create("eldpoprzedne")
                    ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PD", TablePracReldpDataInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("listek_reldp_id"),
                    SimpleName.Create("pomer_id"),
                    SimpleName.Create("eldpkod"),
                    SimpleName.Create("eldpod"),
                    SimpleName.Create("eldpdo"),
                    SimpleName.Create("eldppoj"),
                    SimpleName.Create("eldpdnym01"),
                    SimpleName.Create("eldpdnym02"),
                    SimpleName.Create("eldpdnym03"),
                    SimpleName.Create("eldpdnym04"),
                    SimpleName.Create("eldpdnym05"),
                    SimpleName.Create("eldpdnym06"),
                    SimpleName.Create("eldpdnym07"),
                    SimpleName.Create("eldpdnym08"),
                    SimpleName.Create("eldpdnym09"),
                    SimpleName.Create("eldpdnym10"),
                    SimpleName.Create("eldpdnym11"),
                    SimpleName.Create("eldpdnym12"),
                    SimpleName.Create("zaklvym01"),
                    SimpleName.Create("zaklvym02"),
                    SimpleName.Create("zaklvym03"),
                    SimpleName.Create("zaklvym04"),
                    SimpleName.Create("zaklvym05"),
                    SimpleName.Create("zaklvym06"),
                    SimpleName.Create("zaklvym07"),
                    SimpleName.Create("zaklvym08"),
                    SimpleName.Create("zaklvym09"),
                    SimpleName.Create("zaklvym10"),
                    SimpleName.Create("zaklvym11"),
                    SimpleName.Create("zaklvym12"),
                    SimpleName.Create("eldpvcm")
                ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("UD", "PL").
                AddColumn("firma_id", "firma_id").
                AddColumn("ddavka_reldp_id", "davka_reldp_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("PL", "PD").
                AddColumn("firma_id", "firma_id").
                AddColumn("llistek_reldp_id", "listek_reldp_id").
                AddColumn("eldpPgn", "eldpPgn"));

        }
    }
}
