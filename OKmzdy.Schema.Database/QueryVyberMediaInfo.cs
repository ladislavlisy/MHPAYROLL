using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
   class QueryVyberSbMediaInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERSBMEDIA";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberSbMediaInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberSbMediaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("SM", TableSberneMediumInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("smedium_id"),
                    SimpleName.Create("info_medium"),
                    SimpleName.Create("nazev_klienta"),
                    SimpleName.Create("soubor_start"),
                    SimpleName.Create("soubor_stop"),
                    SimpleName.Create("soubor_next"),
                    SimpleName.Create("soub_cis1"),
                    SimpleName.Create("soub_cis2"),
                    SimpleName.Create("soub_cis3"),
                    SimpleName.Create("soub_txt1"),
                    SimpleName.Create("soub_txt2"),
                    SimpleName.Create("soub_txt3"),
                    SimpleName.Create("datum_predani"),
                    SimpleName.Create("datum_transakce"),
                    SimpleName.Create("datum_splatnosti"),
                    SimpleName.Create("datum_prevodu"),
                    SimpleName.Create("datum_popprev"),
                    SimpleName.Create("bezny_bkspoj_id"),
                    SimpleName.Create("debet_bkspoj_id"),
                    SimpleName.Create("cpopl_bkspoj_id"),
                    SimpleName.Create("dpopl_bkspoj_id"),
                    SimpleName.Create("par_kod_obr11"),
                    SimpleName.Create("par_kod_obr32"),
                    SimpleName.Create("crc"),
                    SimpleName.Create("prior_prevodu"),
                    SimpleName.Create("prior_popprev"),
                    SimpleName.Create("cislo_klienta"),
                    SimpleName.Create("telefon"),
                    SimpleName.Create("ucet_dal"),
                    SimpleName.Create("ucet_md"),
                    SimpleName.Create("ucetni_zdr"),
                    SimpleName.Create("ucetni_str"),
                    SimpleName.Create("ucetni_zak"),
                    SimpleName.Create("ucetni_cin"),
                    SimpleName.Create("prijem_id")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("SLST", TableSestavyLstInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("nazev"),
                    SimpleName.Create("soubor"),
                    SimpleName.Create("trideni"),
                    SimpleName.Create("kod_lst"),
                    SimpleName.Create("kod_data")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("ULST", TableSestavyUlstInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("sestavy_id"),
                    SimpleName.Create("exp_cesta")
                    ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("SM", "SLST").
                AddColumn("firma_id", "firma_id").
                AddColumn("smedium_id", "subjekt_id").
                AddRightColumn("typ_lst", "=", "2"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("SLST", "ULST").
                AddColumn("firma_id", "firma_id").
                AddColumn("kod_lst", "kod_lst"));

        }
    }
    class QueryVyberPlMediaInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERPLMEDIA";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberPlMediaInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberPlMediaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PM", TablePlatebniMediumInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("pmedium_id"),
                    SimpleName.Create("info_medium"), 
                    SimpleName.Create("nazev_klienta"),
                    SimpleName.Create("soubor_start"), 
                    SimpleName.Create("soubor_stop"), 
                    SimpleName.Create("soubor_next"),
                    SimpleName.Create("datum_predani"), 
                    SimpleName.Create("pol_cis1"), 
                    SimpleName.Create("pol_cis2"), 
                    SimpleName.Create("pol_cis3"),
                    SimpleName.Create("pol_txt1"), 
                    SimpleName.Create("pol_txt2"), 
                    SimpleName.Create("pol_txt3"),
                    SimpleName.Create("soub_cis1"), 
                    SimpleName.Create("soub_cis2"), 
                    SimpleName.Create("soub_cis3"),
                    SimpleName.Create("soub_txt1"), 
                    SimpleName.Create("soub_txt2"), 
                    SimpleName.Create("soub_txt3"),
                    SimpleName.Create("mena"), 
                    SimpleName.Create("ustav"), 
                    SimpleName.Create("cislo_pobocky"),
                    SimpleName.Create("prideleny_kod"), 
                    SimpleName.Create("banka_id")
            ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("SLST", TableSestavyLstInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("nazev"),
                    SimpleName.Create("soubor"),
                    SimpleName.Create("trideni"),
                    SimpleName.Create("kod_lst"),
                    SimpleName.Create("kod_data")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("ULST", TableSestavyUlstInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("sestavy_id"),
                    SimpleName.Create("exp_cesta")
                    ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("PM", "SLST").
                AddColumn("firma_id", "firma_id").
                AddColumn("pmedium_id", "subjekt_id").
                AddRightColumn("typ_lst", "=", "3"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("SLST", "ULST").
                AddColumn("firma_id", "firma_id").
                AddColumn("kod_lst", "kod_lst"));

        }
    }
    class QueryVyberUcMediaInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERUCMEDIA";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberUcMediaInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberUcMediaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UM", TableUcetniMediumInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("umedium_id"),
                    SimpleName.Create("info_medium"),
                    SimpleName.Create("doklad_druh"),
                    SimpleName.Create("soub_cis1"),
                    SimpleName.Create("soub_cis2"),
                    SimpleName.Create("soub_cis3"),
                    SimpleName.Create("soub_txt1"),
                    SimpleName.Create("soub_txt2"),
                    SimpleName.Create("soub_txt3"),
                    SimpleName.Create("doklad_cis1"),
                    SimpleName.Create("doklad_cis2"),
                    SimpleName.Create("doklad_cis3"),
                    SimpleName.Create("doklad_txt1"),
                    SimpleName.Create("doklad_txt2"),
                    SimpleName.Create("doklad_txt3"),
                    SimpleName.Create("ucto_klicmd"),
                    SimpleName.Create("ucto_klicdal"),
                    SimpleName.Create("znam_plus"),
                    SimpleName.Create("znam_minus"),
                    SimpleName.Create("domaci_mena"),
                    SimpleName.Create("spoj_ucet_md"),
                    SimpleName.Create("spoj_ucet_dal"),
                    SimpleName.Create("bezny_ucet_md"),
                    SimpleName.Create("bezny_ucet_dal"),
                    SimpleName.Create("korekce_zdr"),
                    SimpleName.Create("korekce_str"),
                    SimpleName.Create("korekce_zak"),
                    SimpleName.Create("korekce_cin")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("SLST", TableSestavyLstInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("nazev"),
                    SimpleName.Create("soubor"),
                    SimpleName.Create("trideni"),
                    SimpleName.Create("kod_lst"),
                    SimpleName.Create("kod_data")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("ULST", TableSestavyUlstInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("sestavy_id"),
                    SimpleName.Create("exp_cesta")
                    ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("UM", "SLST").
                AddColumn("firma_id", "firma_id").
                AddColumn("umedium_id", "subjekt_id").
                AddRightColumn("typ_lst", "=", "1"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("SLST", "ULST").
                AddColumn("firma_id", "firma_id").
                AddColumn("kod_lst", "kod_lst"));
        }
    }
}
