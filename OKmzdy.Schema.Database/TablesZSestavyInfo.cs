using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    public class TableZsestSoczdrPaymsInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_SOCZDR_PAYMS";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestSoczdrPaymsInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestSoczdrPaymsInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, "ZSEST_SOCZDR_PAYMS", 1504)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zdrpojist_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("zdrpojist_kod", DB_TEXT, 80, dbNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("socpojist_kod", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 11, dbNullFieldOption);
            CreateField("druh_cinnosti", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("popis_prac_pom", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("osobni_cislo", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("ppdruh_pcinn", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("z_duvody_znula", DB_TEXT, 255, dbNullFieldOption);
            CreateField("z_ucast_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("z_zdr_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("z_zdr_ucast", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("z_max_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("z_maldoh", DB_BYTE, dbNotNullFieldOption);
            CreateField("z_platiStat", DB_LONG, dbNotNullFieldOption);
            CreateField("z_ppom_stav", DB_INTEGER, dbNotNullFieldOption);
            CreateField("z_koef_poj", DB_BYTE, dbNotNullFieldOption);
            CreateField("z_koef_den", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("s_duvody_znula", DB_TEXT, 255, dbNullFieldOption);
            CreateField("s_ucast_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s_nem_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s_duch_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s_soc_ucast", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s_max_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s_mal_krat", DB_BYTE, dbNotNullFieldOption);
            CreateField("s_ppom_stav", DB_INTEGER, dbNotNullFieldOption);
            CreateField("s_koef_poj", DB_BYTE, dbNotNullFieldOption);
            CreateField("s_koef_den", DB_BYTE, dbNotNullFieldOption);
            CreateField("z_zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("z_pojist_org", DB_LONG, dbNotNullFieldOption);
            CreateField("z_pojist_zam", DB_LONG, dbNotNullFieldOption);
            CreateField("z_vymz_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("z_vymz_prac", DB_LONG, dbNotNullFieldOption);
            CreateField("z_vymz_firm", DB_LONG, dbNotNullFieldOption);
            CreateField("s_sp_zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("s_sp_pojist_org", DB_LONG, dbNotNullFieldOption);
            CreateField("s_np_pojist_zam", DB_LONG, dbNotNullFieldOption);
            CreateField("s_dp_pojist_zam", DB_LONG, dbNotNullFieldOption);
            CreateField("s_dp_sporen_zam", DB_LONG, dbNotNullFieldOption);
            CreateField("s_sp_vymz_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("s_np_vymz_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("s_dp_vymz_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("income_gross", DB_LONG, dbNotNullFieldOption);
            CreateField("income_total", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("trideni", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestDanZvyhodneInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DAN_ZVYHODNE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDanZvyhodneInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDanZvyhodneInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, "ZSEST_DAN_ZVYHODNE", 1502)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("poradi_cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("adresa_psc", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("tabulka_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("tabulka_prijm", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("tabulka_rodcs", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("tabulka_porad", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("tabulka_odmes", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("trideni", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestDanOznameniInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DAN_OZNAMENI";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDanOznameniInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDanOznameniInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, "ZSEST_DAN_OZNAMENI", 1502)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("adresa_psc", DB_TEXT, 255, dbNullFieldOption);
            CreateField("castka_dan", DB_LONG, dbNotNullFieldOption);
            CreateField("castka_bon", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("datum_zjis", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("trideni", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestExtMzdlistInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_EXT_MZDLIST";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestExtMzdlistInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestExtMzdlistInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, "ZSEST_EXT_MZDLIST", 1500)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic_opr", DB_INTEGER, dbNotNullFieldOption);
            CreateField("skupina", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poradi", DB_LONG, dbNotNullFieldOption);
            CreateField("format_hod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("format_rad", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("popis_text", DB_TEXT, 255, dbNullFieldOption);
            CreateField("hodnota_numb", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("hodnota_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("ucetmad_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("ucetdal_text", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestDanPrijmyInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DAN_PRIJMY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDanPrijmyInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDanPrijmyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNotNullFieldOption, 1602);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("obdobi", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("popl_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod1_5", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod6", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod7", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod8", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod9_10", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("adresa", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("dic", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("vyhotovil", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("telefon", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("dne", DB_TEXT, 80, dbNullFieldOption);
        }

    }

    public class TableZsestDanPotvr1500Info : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DAN_POTVR1500";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDanPotvr1500Info(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDanPotvr1500Info(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1602)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNotNullFieldOption, 1602);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("obdobi", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("popl_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod1_5", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod6", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod7", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod8", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod9_10", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("adresa", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("dic", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("vyhotovil", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("telefon", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("dne", DB_TEXT, 80, dbNullFieldOption);
        }

    }

    public class TableZsestDanPotvrzeniInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DAN_POTVRZENI";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDanPotvrzeniInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDanPotvrzeniInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("obdobi", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("popl_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod1_5", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod6", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod7", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod8", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("bod9_10", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("adresa", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("dic", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("vyhotovil", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("telefon", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("dne", DB_TEXT, 80, dbNullFieldOption);
        }

    }

    public class TableZsestDanHlaseni5478Info : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DAN_HLASENI_5478";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDanHlaseni5478Info(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDanHlaseni5478Info(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("hlaseni_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poplat_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poplat_adresa", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("prijmy_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("povinnost_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poznamka_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("danuhrada_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("vyhotovil", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("telefon", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("dne", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("opravnena_osoba", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestDavkaUcetniInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DAVKA_UCETNI";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDavkaUcetniInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDavkaUcetniInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("umedium_id", DB_LONG, dbNotNullFieldOption);
            CreateField("ucetni_mes", DB_BYTE, dbNotNullFieldOption);
            CreateField("ucetni_rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("gener_mes", DB_BYTE, dbNotNullFieldOption);
            CreateField("gener_rok", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("doklad_text", DB_TEXT, 255, dbNullFieldOption);
            CreateField("doklad_cislo", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("doklad_druh", DB_TEXT, 255, dbNullFieldOption);
            CreateField("doklad_den", DB_DATE, dbNullFieldOption);
            CreateField("splatnost", DB_DATE, dbNullFieldOption);
            CreateFTEXT("uctovani_klic", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("ukontace_typ", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mducet_skup", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mducet_synt", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mducet_anal", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("dalucet_skup", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("dalucet_synt", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("dalucet_anal", DB_TEXT, 255, dbNullFieldOption);
            CreateField("castka_mddal", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("znam_mddal", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mena_kod", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rozp_kapitola", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rozp_paragraf", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rozp_polozka", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rozp_podpoloz", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rozp_zazpoloz", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rozp_ucelzdroj", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rozp_kompetent", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rozp_akce", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("zdroj", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("stredisko", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cinnost", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("zakazka", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("divize", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("prac_usek", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("osobni_cislo", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("evid_cislo", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("radek_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("banka_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("uhrada_typ", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestEldp2004Info : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_ELDP2004";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestEldp2004Info(lpszOwnerName, lpszUsersName);
        }
        public TableZsestEldp2004Info(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("eldppgn", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("datum_narozeni", DB_DATE, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNotNullFieldOption);
            CreateFTEXT("rodne_prijmeni", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("misto_narozeni", DB_TEXT, 70, dbNullFieldOption);
            CreateFTEXT("posledni_prijmeni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("adresa1_3", DB_TEXT, 255, dbNullFieldOption);
            CreateField("zacatek", DB_DATE, dbNullFieldOption);
            CreateField("eldprok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("eldptyp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("eldpoprzedne", DB_DATE, dbNullFieldOption);
            CreateField("eldpkod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("eldpod", DB_DATE, dbNullFieldOption);
            CreateField("eldpdo", DB_DATE, dbNullFieldOption);
            CreateFTEXT("eldppoj", DB_TEXT, 62, dbNullFieldOption);
            CreateFTEXT("eldpdnym01", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("eldpdnym02", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("eldpdnym03", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("eldpdnym04", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("eldpdnym05", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("eldpdnym06", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("eldpdnym07", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("eldpdnym08", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("eldpdnym09", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("eldpdnym10", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("eldpdnym11", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("eldpdnym12", DB_TEXT, 255, dbNullFieldOption);
            CreateField("zaklvym01", DB_LONG, dbNotNullFieldOption);
            CreateField("zaklvym02", DB_LONG, dbNotNullFieldOption);
            CreateField("zaklvym03", DB_LONG, dbNotNullFieldOption);
            CreateField("zaklvym04", DB_LONG, dbNotNullFieldOption);
            CreateField("zaklvym05", DB_LONG, dbNotNullFieldOption);
            CreateField("zaklvym06", DB_LONG, dbNotNullFieldOption);
            CreateField("zaklvym07", DB_LONG, dbNotNullFieldOption);
            CreateField("zaklvym08", DB_LONG, dbNotNullFieldOption);
            CreateField("zaklvym09", DB_LONG, dbNotNullFieldOption);
            CreateField("zaklvym10", DB_LONG, dbNotNullFieldOption);
            CreateField("zaklvym11", DB_LONG, dbNotNullFieldOption);
            CreateField("zaklvym12", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("eldpvcm", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestMlmesiceInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_MLMESICE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestMlmesiceInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestMlmesiceInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("oprava", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes1", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes2", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes3", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes4", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes5", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes6", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes7", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes8", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes9", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes10", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes11", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mes12", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("celkem", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestMlnepritInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_MLNEPRIT";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestMlnepritInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestMlnepritInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("doklad", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("sazba", DB_TEXT, 20, dbNullFieldOption);
            CreateField("datum_od", DB_DATE, dbNullFieldOption);
            CreateField("datum_do", DB_DATE, dbNullFieldOption);
            CreateFTEXT("dny", DB_TEXT, 20, dbNullFieldOption);
            CreateField("dny_pdoba", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dny_plocr", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("minuty", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("castka", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("zap_vydelek", DB_TEXT, 20, dbNullFieldOption);
        }

    }

    public class TableZsestMlnezdanInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_MLNEZDAN";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestMlnezdanInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestMlnezdanInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("duvod", DB_TEXT, 25, dbNullFieldOption);
            CreateFTEXT("sniz_do", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("castka", DB_TEXT, 12, dbNullFieldOption);
        }

    }

    public class TableZsestMlpomeryInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_MLPOMERY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestMlpomeryInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestMlpomeryInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("popis", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("druh", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("funkce", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("praxe", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("plat_trida", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("plat_stupen", DB_TEXT, 15, dbNullFieldOption);
            CreateField("zacatek", DB_DATE, dbNullFieldOption);
            CreateField("ucast_nem_poj", DB_DATE, dbNullFieldOption);
            CreateField("konec", DB_DATE, dbNullFieldOption);
            CreateField("dny_neodprac", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dov_narok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dov_dodat", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dov_letos", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dov_loni", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dov_predl", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dov_jina", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dov_kraceno", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dov_cerpano", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dov_placeno", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dov_zbyva", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("kzam", DB_TEXT, 8, dbNullFieldOption);
            CreateFTEXT("prac_pravni_vztah", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("d_nastupu", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("d_ukonceni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t_doba", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("kvalif", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestMlpracovInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_MLPRACOV";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestMlpracovInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestMlpracovInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("osobni_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("evid_cislo", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("utvar_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNotNullFieldOption);
            CreateFTEXT("rodne_prijmeni", DB_TEXT, 35, dbNotNullFieldOption);
            CreateFTEXT("misto_narozeni", DB_TEXT, 48, dbNullFieldOption);
            CreateField("datum_narozeni", DB_DATE, dbNullFieldOption);
            CreateField("zapocet_datum", DB_DATE, dbNullFieldOption);
            CreateFTEXT("zapocet_roku", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("adresa_cast1", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("adresa_cast2", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("prech_adresa_cast1", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("prech_adresa_cast2", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("rezid_stat", DB_TEXT, 40, dbNullFieldOption);
            CreateFTEXT("rezid_dic", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("rezid_adresa_cast1", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("rezid_adresa_cast2", DB_TEXT, 80, dbNullFieldOption);
            CreateField("duchod_narok", DB_DATE, dbNullFieldOption);
            CreateField("duchod_splnil", DB_DATE, dbNullFieldOption);
            CreateField("duchod_pobira", DB_DATE, dbNullFieldOption);
            CreateField("deti", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("stav", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("nejv_vzdel", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("obcanstvi", DB_TEXT, 40, dbNullFieldOption);
            CreateFTEXT("c_prukaz", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("c_pasu", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("cizin_rc", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("osobni_data", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestNemDavkyInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_NEM_DAVKY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestNemDavkyInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestNemDavkyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("utvar_id", DB_LONG, dbNotNullFieldOption);
            CreateField("doklad", DB_LONG, dbNotNullFieldOption);
            CreateField("nepr_od", DB_DATE, dbNullFieldOption);
            CreateField("nepr_do", DB_DATE, dbNullFieldOption);
            CreateField("dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dny_prac", DB_INTEGER, dbNotNullFieldOption);
            CreateField("minuty", DB_LONG, dbNotNullFieldOption);
            CreateField("zap_vyd", DB_LONG, dbNotNullFieldOption);
            CreateField("zap_des", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sazba", DB_LONG, dbNotNullFieldOption);
            CreateField("castka", DB_LONG, dbNotNullFieldOption);
            CreateField("cast14", DB_INTEGER, dbNotNullFieldOption);
            CreateField("redu90", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("osobni_cislo", DB_TEXT, 12, dbNullFieldOption);
        }

    }

    public class TableZsestPlatbyCrInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_PLATBY_CR";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPlatbyCrInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPlatbyCrInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("osobni_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("evid_cislo", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("utvar_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("stred_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("office_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateField("kod", DB_LONG, dbNotNullFieldOption);
            CreateField("zpusob", DB_BYTE, dbNotNullFieldOption);
            CreateField("sbmedium", DB_LONG, dbNotNullFieldOption);
            CreateField("bkmedium", DB_LONG, dbNotNullFieldOption);
            CreateField("platba", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("mena", DB_TEXT, 3, dbNullFieldOption);
            CreateField("priorita", DB_INTEGER, dbNotNullFieldOption);
            CreateField("datum", DB_DATE, dbNullFieldOption);
            CreateField("splatnost", DB_DATE, dbNullFieldOption);
            CreateField("castka", DB_LONG, dbNotNullFieldOption);
            CreateField("zbyva", DB_LONG, dbNotNullFieldOption);
            CreateField("minule", DB_LONG, dbNotNullFieldOption);
            CreateField("poplatky", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("pobocka", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("ucetni_klic", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("ppo_skupina", DB_TEXT, 255, dbNullFieldOption);
            CreateField("poz_vse", DB_LONG, dbNotNullFieldOption);
            CreateField("poz_prikazy", DB_LONG, dbNotNullFieldOption);
            CreateField("group_hprikazy", DB_LONG, dbNotNullFieldOption);
            CreateField("poz_kontr_sez", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("d_kratce", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("d_bankakod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("d_bankabic", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("d_bankaadr", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("d_zadany_ucet", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("d_pred", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("d_ucet", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("d_iban_ucet", DB_TEXT, 40, dbNullFieldOption);
            CreateFTEXT("d_spec_symbol", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("d_var_symbol", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("d_nazev1_4", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("c_kratce", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("c_bankakod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("c_bankabic", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("c_bankaadr", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("c_zadany_ucet", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("c_pred", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("c_ucet", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("c_iban_ucet", DB_TEXT, 40, dbNullFieldOption);
            CreateFTEXT("c_spec_symbol", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("c_var_symbol", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("c_nazev1_4", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("c_konst_symbol", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("c_dom_cislo", DB_TEXT, 8, dbNullFieldOption);
            CreateFTEXT("c_psc", DB_TEXT, 11, dbNullFieldOption);
            CreateFTEXT("avizo1_4", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestPlatbyEuroInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_PLATBY_EURO";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPlatbyEuroInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPlatbyEuroInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("osobni_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("evid_cislo", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("utvar_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("stred_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("office_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateField("kod", DB_LONG, dbNotNullFieldOption);
            CreateField("zpusob", DB_BYTE, dbNotNullFieldOption);
            CreateField("sbmedium", DB_LONG, dbNotNullFieldOption);
            CreateField("bkmedium", DB_LONG, dbNotNullFieldOption);
            CreateField("platba", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("mena", DB_TEXT, 3, dbNullFieldOption);
            CreateField("priorita", DB_INTEGER, dbNotNullFieldOption);
            CreateField("datum", DB_DATE, dbNullFieldOption);
            CreateField("splatnost", DB_DATE, dbNullFieldOption);
            CreateField("castka", DB_LONG, dbNotNullFieldOption);
            CreateField("zbyva", DB_LONG, dbNotNullFieldOption);
            CreateField("minule", DB_LONG, dbNotNullFieldOption);
            CreateField("poplatky", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("pobocka", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("ucetni_klic", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("ppo_skupina", DB_TEXT, 255, dbNullFieldOption);
            CreateField("poz_vse", DB_LONG, dbNotNullFieldOption);
            CreateField("poz_prikazy", DB_LONG, dbNotNullFieldOption);
            CreateField("group_hprikazy", DB_LONG, dbNotNullFieldOption);
            CreateField("poz_kontr_sez", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("d_kratce", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("d_bankakod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("d_bankabic", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("d_bankaadr", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("d_zadany_ucet", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("d_pred", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("d_ucet", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("d_iban_ucet", DB_TEXT, 40, dbNullFieldOption);
            CreateFTEXT("d_spec_symbol", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("d_var_symbol", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("d_nazev1_4", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("c_kratce", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("c_bankakod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("c_bankabic", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("c_bankaadr", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("c_zadany_ucet", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("c_pred", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("c_ucet", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("c_iban_ucet", DB_TEXT, 40, dbNullFieldOption);
            CreateFTEXT("c_spec_symbol", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("c_var_symbol", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("c_nazev1_4", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("c_konst_symbol", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("c_dom_cislo", DB_TEXT, 8, dbNullFieldOption);
            CreateFTEXT("c_psc", DB_TEXT, 11, dbNullFieldOption);
            CreateFTEXT("avizo1_4", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestPrijemSspInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_PRIJEM_SSP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPrijemSspInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPrijemSspInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("ctvrtleti", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("texty", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("utvar_nazev", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("pomer_text", DB_TEXT, 255, dbNullFieldOption);
            CreateField("prijem_hrmes", DB_LONG, dbNotNullFieldOption);
            CreateField("prijem_dalsi", DB_LONG, dbNotNullFieldOption);
            CreateField("prijem_cistmes", DB_LONG, dbNotNullFieldOption);
            CreateField("dnp_pohyblive", DB_LONG, dbNotNullFieldOption);
            CreateField("nahrzp", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestRekapitInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_REKAPIT";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestRekapitInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestRekapitInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("skupina", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod", DB_LONG, dbNotNullFieldOption);
            CreateField("poradi", DB_LONG, dbNotNullFieldOption);
            CreateField("vyska", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("radtext", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestSocialInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_SOCIAL";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestSocialInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestSocialInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("info_org", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("ucast_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("ppom_stav", DB_INTEGER, dbNotNullFieldOption);
            CreateField("koef_poj", DB_BYTE, dbNotNullFieldOption);
            CreateField("druh_cinnosti", DB_BYTE, dbNotNullFieldOption);
            CreateField("zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("pojist_org", DB_LONG, dbNotNullFieldOption);
            CreateField("pojistne_zam", DB_LONG, dbNotNullFieldOption);
            CreateField("vyl_doby", DB_INTEGER, dbNotNullFieldOption);
            CreateField("absence", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nemoc_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nemoc_kc", DB_LONG, dbNotNullFieldOption);
            CreateField("osetrovani_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("osetrovani_kc", DB_LONG, dbNotNullFieldOption);
            CreateField("materstvi_n", DB_INTEGER, dbNotNullFieldOption);
            CreateField("materstvi_kc", DB_LONG, dbNotNullFieldOption);
            CreateField("vyrovnani_n", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyrovnani_kc", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_e_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("davka_e_kc", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_f_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("davka_f_kc", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestDsporHlascaInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DSPOR_HLASCA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDsporHlascaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDsporHlascaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("cislo_radku", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_pojpreplcelk", DB_LONG, dbNotNullFieldOption);
            CreateField("prepl_typ", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("prepl_dic", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestDsporHlasnaInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DSPOR_HLASNA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDsporHlasnaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDsporHlasnaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("cislo_radku", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_pojrozdil", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestDsporVyuctInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DSPOR_VYUCT";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDsporVyuctInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDsporVyuctInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("kal_mesice", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("cislo_radku", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes01_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes01_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes02_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes02_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes03_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes03_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes04_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes04_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes05_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes05_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes06_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes06_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes07_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes07_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes08_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes08_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes09_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes09_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes10_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes10_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes11_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes11_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("mes12_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("mes12_dodzuctov", DB_LONG, dbNotNullFieldOption);
            CreateField("zuctovani_opravy", DB_LONG, dbNotNullFieldOption);
            CreateField("op01_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op01_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op01_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op02_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op02_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op02_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op03_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op03_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op03_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op04_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op04_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op04_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op05_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op05_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op05_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op06_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op06_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op06_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op07_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op07_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op07_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op08_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op08_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op08_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op09_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op09_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op09_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op10_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op10_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op10_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op11_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op11_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op11_srazaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op12_pojzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("op12_pojzaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("op12_srazaloha", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestPotvrzDpInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_POTVRZ_DP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPotvrzDpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPotvrzDpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pomer_pg", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("soc_kod", DB_TEXT, 255, dbNullFieldOption);
            CreateField("soc_zak", DB_LONG, dbNotNullFieldOption);
            CreateField("soc_poj", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableMzvIisspPredpisyInfo : TableDefInfo
    {
        const string TABLE_NAME = "MZV_IISSP_PREDPISY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableMzvIisspPredpisyInfo(lpszOwnerName, lpszUsersName);
        }
        public TableMzvIisspPredpisyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNullFieldOption);
            CreateField("davka_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_BYTE, dbNotNullFieldOption);
            CreateField("vyuct_cast", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("mena", DB_TEXT, 10, dbNullFieldOption);
            CreateField("castkakc", DB_LONG, dbNotNullFieldOption);
            CreateField("castka_mena", DB_LONG, dbNotNullFieldOption);
            CreateField("kurz_mena", DB_LONG, dbNotNullFieldOption);
            CreateField("datum_kurz", DB_DATE, dbNullFieldOption);
            CreateField("datum_vypl", DB_DATE, dbNullFieldOption);
            CreateField("datum_exp", DB_DATE, dbNullFieldOption);
            CreateFTEXT("id_koruny", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("id_syntet", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("id_paragraf", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("id_polozka", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("id_analyt", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("stredisko", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("popis_koruny", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestUzivSestInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_UZIV_SEST";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestUzivSestInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestUzivSestInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_radku", DB_LONG, dbNotNullFieldOption);
            CreateField("typ_radku", DB_BYTE, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t1", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t2", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t3", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t4", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t5", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t6", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t7", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t8", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t9", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t10", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t11", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t12", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t13", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t14", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t15", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t16", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t17", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t18", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t19", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t20", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t21", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t22", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t23", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t24", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t25", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t26", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t27", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t28", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t29", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t30", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t31", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t32", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t33", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t34", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t35", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t36", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t37", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t38", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t39", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t40", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t41", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t42", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t43", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t44", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t45", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t46", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t47", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t48", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t49", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t50", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t51", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t52", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t53", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t54", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t55", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t56", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t57", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t58", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t59", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t60", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t61", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t62", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t63", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t64", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t65", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t66", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t67", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t68", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t69", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t70", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t71", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t72", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t73", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t74", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t75", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t76", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t77", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t78", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t79", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("t80", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1ZSEST_UZIV_SEST");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("uzivatel_id");
            TableIndex.AppendField("kod_lst");
            TableIndex.AppendField("cislo_radku");
            TableIndex = CreateIndex("XIF2ZSEST_UZIV_SEST");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("uzivatel_id");
            TableIndex.AppendField("kod_lst");
            TableIndex.AppendField("typ_radku");
            TableIndex = CreateIndex("XIF3ZSEST_UZIV_SEST");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("uzivatel_id");
            TableIndex.AppendField("kod_lst");
            TableIndex.AppendField("pracovnik_id");
        }

    }

    public class TableZsestVypDaneInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_VYP_DANE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestVypDaneInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestVypDaneInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("obdobi", DB_TEXT, 4, dbNullFieldOption);
            CreateField("zuctovani", DB_DATE, dbNullFieldOption);
            CreateFTEXT("text_popl", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("text_castky", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestVyplListinyInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_VYPL_LISTINY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestVyplListinyInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestVyplListinyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("utvar_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("castka", DB_LONG, dbNotNullFieldOption);
            CreateField("datum", DB_DATE, dbNullFieldOption);
            CreateField("zpusob", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestVyplListkyInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_VYPL_LISTKY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestVyplListkyInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestVyplListkyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("vlist_info", DB_LONG, dbNotNullFieldOption);
            CreateField("radek", DB_BYTE, dbNotNullFieldOption);
            CreateField("typ", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("radtext", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("engtext", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestVyuctZmenyInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_VYUCT_ZMENY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestVyuctZmenyInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestVyuctZmenyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("zmena_od", DB_DATE, dbNullFieldOption);
            CreateFTEXT("radtext", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestZdravInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_ZDRAV";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestZdravInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestZdravInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("ucast_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("ppom_stav", DB_INTEGER, dbNotNullFieldOption);
            CreateField("koef_poj", DB_BYTE, dbNotNullFieldOption);
            CreateField("zdravpoj_id", DB_LONG, dbNotNullFieldOption);
            CreateField("info_org", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNotNullFieldOption);
            CreateFTEXT("duvod", DB_TEXT, 70, dbNullFieldOption);
            CreateField("zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("plati_stat", DB_LONG, dbNotNullFieldOption);
            CreateField("pojist_org", DB_LONG, dbNotNullFieldOption);
            CreateField("pojistne_zam", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestZmenyZpInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_ZMENY_ZP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestZmenyZpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestZmenyZpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("zdravpoj_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("kod_zmeny", DB_TEXT, 2, dbNullFieldOption);
            CreateField("datum", DB_DATE, dbNullFieldOption);
        }

    }

    public class TableZsestDpzvd2VetadInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DPZVD2_VETAD";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDpzvd2VetadInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDpzvd2VetadInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("zdobd_od", DB_DATE, dbNotNullFieldOption);
            CreateField("zdobd_do", DB_DATE, dbNotNullFieldOption);
            CreateField("poc_zam1", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poc_zam2", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poc_zam3", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poc_zam4", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poc_zam5", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poc_zam6", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poc_zam7", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poc_zam8", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poc_zam9", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poc_zam10", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poc_zam11", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poc_zam12", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kc_dpzi04", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi4a", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestDpzvd2VetaoInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DPZVD2_VETAO";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDpzvd2VetaoInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDpzvd2VetaoInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("d_srazeno", DB_DATE, dbNotNullFieldOption);
            CreateField("kc_dpzi02", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi03", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi04", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi05", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi05a", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi05b", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi06", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi07", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi08", DB_LONG, dbNotNullFieldOption);
            CreateField("d_odvedeno", DB_DATE, dbNotNullFieldOption);
            CreateField("kc_odvedeno", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestDpzvs2VetaoInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DPZVS2_VETAO";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDpzvs2VetaoInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDpzvs2VetaoInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kc_dpzi01", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi02", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi03", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi04", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi05", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi06", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi07", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi08", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_dpzi09", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestDpzvd2VetaeInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DPZVD2_VETAE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDpzvd2VetaeInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDpzvd2VetaeInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pr_opr", DB_BYTE, dbNotNullFieldOption);
            CreateField("mesic_nespr", DB_INTEGER, dbNotNullFieldOption);
            CreateField("d_puvsraz", DB_DATE, dbNullFieldOption);
            CreateField("mesic_opr", DB_INTEGER, dbNotNullFieldOption);
            CreateField("d_dodsraz", DB_DATE, dbNullFieldOption);
            CreateField("kc_castka", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestDpzvs2VetaeInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DPZVS2_VETAE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDpzvs2VetaeInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDpzvs2VetaeInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pr_opr", DB_BYTE, dbNotNullFieldOption);
            CreateField("mesic_nespr", DB_INTEGER, dbNotNullFieldOption);
            CreateField("d_puvsraz", DB_DATE, dbNullFieldOption);
            CreateField("mesic_opr", DB_INTEGER, dbNotNullFieldOption);
            CreateField("d_dodsraz", DB_DATE, dbNullFieldOption);
            CreateField("kc_castka", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestDpzvd2VetafInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DPZVD2_VETAF";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDpzvd2VetafInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDpzvd2VetafInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("b_pr_opr", DB_BYTE, dbNotNullFieldOption);
            CreateField("b_mesic_nespr", DB_INTEGER, dbNotNullFieldOption);
            CreateField("b_d_puvsraz", DB_DATE, dbNullFieldOption);
            CreateField("b_mesic_opr", DB_INTEGER, dbNotNullFieldOption);
            CreateField("b_d_dodsraz", DB_DATE, dbNullFieldOption);
            CreateField("b_d_zadosti", DB_DATE, dbNullFieldOption);
            CreateField("b_kc_castka", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestDpzvd2VetagInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DPZVD2_VETAG";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDpzvd2VetagInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDpzvd2VetagInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic_06", DB_INTEGER, dbNotNullFieldOption);
            CreateField("uhrnprepl_s", DB_LONG, dbNotNullFieldOption);
            CreateField("uhrnprepl_b", DB_LONG, dbNotNullFieldOption);
            CreateField("uhrnprepl_z", DB_LONG, dbNotNullFieldOption);
            CreateField("d_zadosti_06", DB_DATE, dbNullFieldOption);
        }

    }

    public class TableZsestDpzvd2VetabInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DPZVD2_VETAB";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDpzvd2VetabInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDpzvd2VetabInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("naz_vykonu", DB_TEXT, 40, dbNullFieldOption);
            CreateField("poc_zam", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("naz_obce_zuj", DB_TEXT, 40, dbNullFieldOption);
            CreateFTEXT("c_obce_zuj", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("naz_zko", DB_TEXT, 23, dbNullFieldOption);
            CreateFTEXT("c_zko", DB_TEXT, 20, dbNullFieldOption);
        }

    }

    public class TableZsestDpzvd2VetacInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_DPZVD2_VETAC";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestDpzvd2VetacInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestDpzvd2VetacInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("k_stat", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("naz_obce", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("ulice", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("c_pop_or", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("psc", DB_TEXT, 20, dbNullFieldOption);
            CreateField("d_naroz", DB_DATE, dbNullFieldOption);
            CreateFTEXT("dic", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("rod_c", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("c_pasu", DB_TEXT, 50, dbNullFieldOption);
            CreateField("mes_zuct1", DB_BYTE, dbNotNullFieldOption);
            CreateField("mes_zuct2", DB_BYTE, dbNotNullFieldOption);
            CreateField("mes_zuct3", DB_BYTE, dbNotNullFieldOption);
            CreateField("mes_zuct4", DB_BYTE, dbNotNullFieldOption);
            CreateField("mes_zuct5", DB_BYTE, dbNotNullFieldOption);
            CreateField("mes_zuct6", DB_BYTE, dbNotNullFieldOption);
            CreateField("mes_zuct7", DB_BYTE, dbNotNullFieldOption);
            CreateField("mes_zuct8", DB_BYTE, dbNotNullFieldOption);
            CreateField("mes_zuct9", DB_BYTE, dbNotNullFieldOption);
            CreateField("mes_zuct10", DB_BYTE, dbNotNullFieldOption);
            CreateField("mes_zuct11", DB_BYTE, dbNotNullFieldOption);
            CreateField("mes_zuct12", DB_BYTE, dbNotNullFieldOption);
            CreateField("kc_prijmy", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_zakldane", DB_LONG, dbNotNullFieldOption);
            CreateField("kc_zalohy", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestPpomerPraxeInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_PPOMER_PRAXE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPpomerPraxeInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPpomerPraxeInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poradi", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("radek_text", DB_TEXT, 255, dbNullFieldOption);
            CreateField("praxe_zac", DB_DATE, dbNotNullFieldOption);
            CreateField("praxe_kon", DB_DATE, dbNotNullFieldOption);
            CreateField("kraceni_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("delka_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kratit_vzdel", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("trideni", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestPotvrzHlavInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_POTVRZ_HLAV";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPotvrzHlavInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPotvrzHlavInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zamest_od", DB_DATE, dbNullFieldOption);
            CreateField("zamest_do", DB_DATE, dbNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cislo_prukaz", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNotNullFieldOption);
            CreateFTEXT("nazev_utvaru", DB_TEXT, 255, dbNullFieldOption);
            CreateField("datum_narozeni", DB_DATE, dbNotNullFieldOption);
            CreateFTEXT("adresa_cast1", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("adresa_cast2", DB_TEXT, 80, dbNullFieldOption);
        }

    }

    public class TableZsestPot313VedlInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_POT313_VEDL";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPot313VedlInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPot313VedlInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("zdrav_poj", DB_TEXT, 255, dbNullFieldOption);
            CreateField("pomer", DB_INTEGER, dbNotNullFieldOption);
            CreateField("ukonceni", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("zamestnani", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("kvalifikace", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("vzdelani", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestPot313NeschInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_POT313_NESCH";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPot313NeschInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPot313NeschInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nesch_od", DB_DATE, dbNullFieldOption);
            CreateField("nesch_do", DB_DATE, dbNullFieldOption);
            CreateField("pocet_dnu", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("druh", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestPot313PohlInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_POT313_POHL";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPot313PohlInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPot313PohlInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("tabulka", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("poradi", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("druh", DB_TEXT, 255, dbNullFieldOption);
            CreateField("bezne_mesicni", DB_LONG, dbNotNullFieldOption);
            CreateField("dluzne", DB_LONG, dbNotNullFieldOption);
            CreateField("srazeno", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("ve_prospech", DB_TEXT, 255, dbNullFieldOption);
            CreateField("celkem", DB_LONG, dbNotNullFieldOption);
            CreateField("splatka", DB_LONG, dbNotNullFieldOption);
            CreateField("splaceno", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("rozhodnuti", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestPotvrzZpInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_POTVRZ_ZP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPotvrzZpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPotvrzZpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pomer_pg", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("zdravA_kod", DB_TEXT, 255, dbNullFieldOption);
            CreateField("zdravA_zak", DB_LONG, dbNotNullFieldOption);
            CreateField("zdravA_poj", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("zdravB_kod", DB_TEXT, 255, dbNullFieldOption);
            CreateField("zdravB_zak", DB_LONG, dbNotNullFieldOption);
            CreateField("zdravB_poj", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestPotvrzSpInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_POTVRZ_SP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPotvrzSpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPotvrzSpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pomer_pg", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("soc_kod", DB_TEXT, 255, dbNullFieldOption);
            CreateField("soc_zak", DB_LONG, dbNotNullFieldOption);
            CreateField("soc_poj", DB_LONG, dbNotNullFieldOption);
            CreateField("pen_zak", DB_LONG, dbNotNullFieldOption);
            CreateField("pen_poj", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestKontrZdrpInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_KONTR_ZDRP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestKontrZdrpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestKontrZdrpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zdrpojist_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("zdrpojist_kod", DB_TEXT, 80, dbNullFieldOption);
            CreateField("info_org", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 11, dbNullFieldOption);
            CreateField("druh_cinnosti", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("popis_prac_pom", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("osobni_cislo", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("ppdruh_pcinn", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("duvody_znula", DB_TEXT, 255, dbNullFieldOption);
            CreateField("ucast_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("zdr_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("zdr_ucast", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("max_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("maldoh", DB_BYTE, dbNotNullFieldOption);
            CreateField("platiStat", DB_LONG, dbNotNullFieldOption);
            CreateField("ppom_stav", DB_INTEGER, dbNotNullFieldOption);
            CreateField("koef_poj", DB_BYTE, dbNotNullFieldOption);
            CreateField("koef_den", DB_BYTE, dbNotNullFieldOption);
            CreateField("zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("pojist_org", DB_LONG, dbNotNullFieldOption);
            CreateField("pojist_zam", DB_LONG, dbNotNullFieldOption);
            CreateField("vymz_pres", DB_LONG, dbNotNullFieldOption);
            CreateField("vymz_pdal", DB_LONG, dbNotNullFieldOption);
            CreateField("vymz_pred", DB_LONG, dbNotNullFieldOption);
            CreateField("vymz_pvyp", DB_LONG, dbNotNullFieldOption);
            CreateField("vymz_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("vymz_prac", DB_LONG, dbNotNullFieldOption);
            CreateField("vymz_firm", DB_LONG, dbNotNullFieldOption);
            CreateField("oprz_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("oprz_prac", DB_LONG, dbNotNullFieldOption);
            CreateField("oprz_firm", DB_LONG, dbNotNullFieldOption);
            CreateField("oprp_prac", DB_LONG, dbNotNullFieldOption);
            CreateField("oprp_firm", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestKontrSocpInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_KONTR_SOCP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestKontrSocpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestKontrSocpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("socpojist_kod", DB_TEXT, 80, dbNullFieldOption);
            CreateField("info_org", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 11, dbNullFieldOption);
            CreateField("druh_cinnosti", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("popis_prac_pom", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("osobni_cislo", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("ppdruh_pcinn", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("duvody_znula", DB_TEXT, 255, dbNullFieldOption);
            CreateField("ucast_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("nem_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("duch_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("soc_ucast", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("max_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("mal_krat", DB_BYTE, dbNotNullFieldOption);
            CreateField("ppom_stav", DB_INTEGER, dbNotNullFieldOption);
            CreateField("koef_poj", DB_BYTE, dbNotNullFieldOption);
            CreateField("koef_den", DB_BYTE, dbNotNullFieldOption);
            CreateField("nemppoj_zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_pojist_org", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_pojist_zam", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_pojist_org", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_pojist_zam", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_prij_pred", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_prij_pdal", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_prij_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_vymz_prok", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_vymz_pres", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_vymz_pvyp", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_oprz_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_vymz_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_oprp_prac", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_oprp_orgs", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_prij_pred", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_prij_pdal", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_prij_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_vymz_prok", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_vymz_pres", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_vymz_pvyp", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_oprz_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_vymz_celk", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_oprp_prac", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_oprp_orgs", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestOznamSocpInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_OZNAM_SOCP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestOznamSocpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestOznamSocpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("dep_okres_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("ossznazev", DB_TEXT, 255, dbNullFieldOption);
            CreateField("act_akce_kod", DB_BYTE, dbNotNullFieldOption);
            CreateField("fro_datum_platnosti", DB_DATE, dbNullFieldOption);
            CreateField("dat_datum_vyplneni", DB_DATE, dbNullFieldOption);
            CreateField("job_fro", DB_DATE, dbNullFieldOption);
            CreateField("job_to", DB_DATE, dbNullFieldOption);
            CreateFTEXT("sur_prijmeni", DB_TEXT, 50, dbNotNullFieldOption);
            CreateFTEXT("ona_predchozi", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("fir_jmeno", DB_TEXT, 50, dbNotNullFieldOption);
            CreateFTEXT("tit_titul", DB_TEXT, 30, dbNullFieldOption);
            CreateField("dat_narozeni", DB_DATE, dbNullFieldOption);
            CreateFTEXT("bno_rodne_cislo", DB_TEXT, 10, dbNotNullFieldOption);
            CreateFTEXT("nam_rodne_prijmeni", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("cit_misto_narozeni", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("mal_pohlavi_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("cnt_obcan_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("str_tp_ulice", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("num_tp_cisdom", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("cit_tp_obec", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("pos_tp_posta", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("pnu_tp_psc", DB_TEXT, 11, dbNullFieldOption);
            CreateFTEXT("cnt_tp_stat_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("str_ka_ulice", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("num_ka_cisdom", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("cit_ka_obec", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("pos_ka_posta", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("pnu_ka_psc", DB_TEXT, 11, dbNullFieldOption);
            CreateFTEXT("cnt_ka_stat_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("str_tpcr_ulice", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("num_tpcr_cisdom", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("cit_tpcr_obec", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("pos_tpcr_posta", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("pnu_tpcr_psc", DB_TEXT, 11, dbNullFieldOption);
            CreateFTEXT("vs_varsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("nvs_novy_varsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("id_ico", DB_TEXT, 35, dbNullFieldOption);
            CreateFTEXT("nam_nazev_zam", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("rel_druhcin_kod", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("per_stat_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateField("sme_zam_maly_rozsah", DB_BYTE, dbNotNullFieldOption);
            CreateField("typ_duchod_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("tak_duchod_pob_od", DB_DATE, dbNullFieldOption);
            CreateField("cur_specifikace", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("nam_cizpoj_nazev", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("str_cizpoj_ulice", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("num_cizpoj_cisdom", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("cit_cizpoj_obec", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("pnu_cizpoj_psc", DB_TEXT, 11, dbNullFieldOption);
            CreateFTEXT("cnt_cizpoj_stat_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("id_cizpoj", DB_TEXT, 25, dbNullFieldOption);
            CreateFTEXT("cnr_kod_zdrpoj", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("nam_predchorg_nempoj", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("nam_soucorg_nempoj", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestPrehlSocpInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_PREHL_SOCP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPrehlSocpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPrehlSocpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("info_org", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 11, dbNullFieldOption);
            CreateField("druh_cinnosti", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("popis_prac_pom", DB_TEXT, 255, dbNullFieldOption);
            CreateField("ucast_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("nem_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("duch_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("max_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("malkrat", DB_BYTE, dbNotNullFieldOption);
            CreateField("ppom_stav", DB_INTEGER, dbNotNullFieldOption);
            CreateField("koef_poj", DB_BYTE, dbNotNullFieldOption);
            CreateField("koef_den", DB_BYTE, dbNotNullFieldOption);
            CreateField("nemppoj_zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_pojist_org", DB_LONG, dbNotNullFieldOption);
            CreateField("nemppoj_pojist_zam", DB_LONG, dbNotNullFieldOption);
            CreateField("nempmes_pojist_slv", DB_LONG, dbNotNullFieldOption);
            CreateField("nempmim_pojist_slv", DB_LONG, dbNotNullFieldOption);
            CreateField("nempmes_oprava_slv", DB_LONG, dbNotNullFieldOption);
            CreateField("nempmim_oprava_slv", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_pojist_org", DB_LONG, dbNotNullFieldOption);
            CreateField("duchpoj_pojist_zam", DB_LONG, dbNotNullFieldOption);
            CreateField("nahrmzdy_kc", DB_LONG, dbNotNullFieldOption);
            CreateField("vyl_doby", DB_INTEGER, dbNotNullFieldOption);
            CreateField("absence", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nemoc_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nemoc_kc", DB_LONG, dbNotNullFieldOption);
            CreateField("osetrovani_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("osetrovani_kc", DB_LONG, dbNotNullFieldOption);
            CreateField("materstvi_kc", DB_LONG, dbNotNullFieldOption);
            CreateField("materstvi_n", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyrovnani_kc", DB_LONG, dbNotNullFieldOption);
            CreateField("vyrovnani_n", DB_INTEGER, dbNotNullFieldOption);
        }

    }

    public class TableZsestPrilohaSocpInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_PRILOHA_SOCP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPrilohaSocpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPrilohaSocpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("info_org", DB_LONG, dbNotNullFieldOption);
            CreateField("mim_obdobi_slv", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mim_pocetz_slv", DB_LONG, dbNotNullFieldOption);
            CreateField("mim_pojist_slv", DB_LONG, dbNotNullFieldOption);
            CreateField("mim_oprava_slv", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestSlevySocpInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_SLEVY_SOCP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestSlevySocpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestSlevySocpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("vtrideni", DB_TEXT, 255, dbNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 11, dbNullFieldOption);
            CreateField("pocet_zzamest", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pocet_zames25", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pocet_zames33", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pocet_bezslev", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sumar_poznvse", DB_LONG, dbNotNullFieldOption);
            CreateField("sumar_poznjed", DB_LONG, dbNotNullFieldOption);
            CreateField("sumar_vymzakl", DB_LONG, dbNotNullFieldOption);
            CreateField("vypoc_rzaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("maxim_slevasp", DB_LONG, dbNotNullFieldOption);
            CreateField("uplat_slevasp", DB_LONG, dbNotNullFieldOption);
            CreateField("oprav_slevasp", DB_LONG, dbNotNullFieldOption);
            CreateField("vypoc_sleva25", DB_LONG, dbNotNullFieldOption);
            CreateField("vypoc_sleva33", DB_LONG, dbNotNullFieldOption);
            CreateField("vzakl_sleva25", DB_LONG, dbNotNullFieldOption);
            CreateField("vzakl_sleva33", DB_LONG, dbNotNullFieldOption);
            CreateField("sleva_sleva25", DB_LONG, dbNotNullFieldOption);
            CreateField("sleva_sleva33", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestNemDavky09Info : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_NEM_DAVKY_09";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestNemDavky09Info(lpszOwnerName, lpszUsersName);
        }
        public TableZsestNemDavky09Info(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("nazev_utvaru", DB_TEXT, 255, dbNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("utvar_id", DB_LONG, dbNotNullFieldOption);
            CreateField("stred_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("doklad", DB_TEXT, 255, dbNullFieldOption);
            CreateField("nepr_od", DB_DATE, dbNullFieldOption);
            CreateField("nepr_do", DB_DATE, dbNullFieldOption);
            CreateField("dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dny_prac", DB_INTEGER, dbNotNullFieldOption);
            CreateField("minuty", DB_LONG, dbNotNullFieldOption);
            CreateField("minzac", DB_LONG, dbNotNullFieldOption);
            CreateField("minkon", DB_LONG, dbNotNullFieldOption);
            CreateField("zap_vyd", DB_LONG, dbNotNullFieldOption);
            CreateField("zap_des", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sazba", DB_LONG, dbNotNullFieldOption);
            CreateField("castka", DB_LONG, dbNotNullFieldOption);
            CreateField("vym_zaklad", DB_LONG, dbNotNullFieldOption);
            CreateField("kod", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("osobni_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("varsymb", DB_TEXT, 12, dbNullFieldOption);
            CreateField("skupina", DB_BYTE, dbNotNullFieldOption);
        }

    }

    public class TableZsestZadNemInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_ZAD_NEM";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestZadNemInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestZadNemInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cislo_socpoj", DB_TEXT, 50, dbNullFieldOption);
            CreateField("druh_duchodu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dat_duchod_pob", DB_DATETIME, dbNullFieldOption);
            CreateField("dat_zacatek_nesch", DB_DATETIME, dbNullFieldOption);
            CreateField("dat_zamest_zac", DB_DATETIME, dbNullFieldOption);
            CreateField("dat_zamest_kon", DB_DATETIME, dbNullFieldOption);
            CreateField("kod_zamest_cinn", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod_neprit", DB_INTEGER, dbNotNullFieldOption);
            CreateField("prac_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zbyva_zac", DB_INTEGER, dbNotNullFieldOption);
            CreateField("smena_zac", DB_INTEGER, dbNotNullFieldOption);
            CreateField("obdobi_zac", DB_DATETIME, dbNullFieldOption);
            CreateField("obdobi_kon", DB_DATETIME, dbNullFieldOption);
            CreateFTEXT("trideni", DB_TEXT, 255, dbNullFieldOption);
            CreateField("cinn_mr", DB_INTEGER, dbNotNullFieldOption);
            CreateField("prij_mr", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("cis_rozhod", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("pril_a", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_b", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_c", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_d", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_e", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_f", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_g", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_h", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_i", DB_TEXT, 100, dbNullFieldOption);
        }

    }

    public class TableZsestZadNemNeschInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_ZAD_NEM_NESCH";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestZadNemNeschInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestZadNemNeschInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nesch_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("nesch_druh", DB_TEXT, 255, dbNullFieldOption);
            CreateField("nesch_zacatek", DB_DATE, dbNullFieldOption);
            CreateField("nesch_konec", DB_DATE, dbNullFieldOption);
            CreateField("poc_kaldnu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poradi", DB_INTEGER, dbNotNullFieldOption);
        }

    }

    public class TableZsestZadNemRozhobdInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_ZAD_NEM_ROZHOBD";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestZadNemRozhobdInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestZadNemRozhobdInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("obd_rozhod_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby_01", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby_02", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby_03", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mes_ulozeni", DB_INTEGER, dbNotNullFieldOption);
        }

    }

    public class TableZsestZadMatInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_ZAD_MAT";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestZadMatInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestZadMatInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cislo_socpoj", DB_TEXT, 50, dbNullFieldOption);
            CreateField("druh_duchodu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dat_duchod_pob", DB_DATE, dbNullFieldOption);
            CreateField("dat_zacatek_nesch", DB_DATE, dbNullFieldOption);
            CreateField("dat_zamest_zac", DB_DATE, dbNullFieldOption);
            CreateField("dat_zamest_kon", DB_DATE, dbNullFieldOption);
            CreateField("kod_zamest_cinn", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod_neprit", DB_INTEGER, dbNotNullFieldOption);
            CreateField("prac_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zbyva_zac", DB_INTEGER, dbNotNullFieldOption);
            CreateField("smena_zac", DB_INTEGER, dbNotNullFieldOption);
            CreateField("obdobi_zac", DB_DATE, dbNullFieldOption);
            CreateField("obdobi_kon", DB_DATE, dbNullFieldOption);
            CreateFTEXT("trideni", DB_TEXT, 255, dbNullFieldOption);
            CreateField("cinn_mr", DB_INTEGER, dbNotNullFieldOption);
            CreateField("prij_mr", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("cis_rozhod", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("pril_a", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_b", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_c", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_d", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_e", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_f", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_g", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_h", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_i", DB_TEXT, 100, dbNullFieldOption);
        }

    }

    public class TableZsestZadMatNeschInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_ZAD_MAT_NESCH";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestZadMatNeschInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestZadMatNeschInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nesch_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("nesch_druh", DB_TEXT, 255, dbNullFieldOption);
            CreateField("nesch_zacatek", DB_DATE, dbNullFieldOption);
            CreateField("nesch_konec", DB_DATE, dbNullFieldOption);
            CreateField("poc_kaldnu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poradi", DB_INTEGER, dbNotNullFieldOption);
        }

    }

    public class TableZsestZadMatRozhobdInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_ZAD_MAT_ROZHOBD";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestZadMatRozhobdInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestZadMatRozhobdInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("obd_rozhod_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby_01", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby_02", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby_03", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mes_ulozeni", DB_INTEGER, dbNotNullFieldOption);
        }

    }

    public class TableZsestPotvdavSspInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_POTVDAV_SSP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPotvdavSspInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPotvdavSspInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rod_prijm", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("titul", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateField("dateOd", DB_DATE, dbNullFieldOption);
            CreateField("dateDo", DB_DATE, dbNullFieldOption);
            CreateField("ctvrtleti", DB_BYTE, dbNotNullFieldOption);
            CreateField("zdanit_prij_zavcin", DB_LONG, dbNotNullFieldOption);
            CreateField("prij_uziv_vozidla", DB_LONG, dbNotNullFieldOption);
            CreateField("nahrada_mzdy", DB_LONG, dbNotNullFieldOption);
            CreateField("prij_pracnesch", DB_LONG, dbNotNullFieldOption);
            CreateField("davky_nempoj", DB_LONG, dbNotNullFieldOption);
            CreateField("odpocet_soczab", DB_LONG, dbNotNullFieldOption);
            CreateField("odpocet_dane_zprijmu", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestReldp09PracInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_RELDP09_PRAC";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestReldp09PracInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestReldp09PracInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("sprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("eldp_rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("eldp_oprava", DB_DATE, dbNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("titul", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("rodne_prijmeni", DB_TEXT, 255, dbNullFieldOption);
            CreateField("datum_narozeni", DB_DATE, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("ulice", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cislo_domu", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("obec", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("posta", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("psc", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("stat", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("misto_narozeni", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestReldp09PojInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_RELDP09_POJ";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestReldp09PojInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestReldp09PojInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_LONG, dbNotNullFieldOption);
            CreateField("sprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("eldp_typ", DB_INTEGER, dbNotNullFieldOption);
            CreateField("stranka", DB_LONG, dbNotNullFieldOption);
            CreateField("radek", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("kod", DB_TEXT, 3, dbNullFieldOption);
            CreateField("maly_rozsah", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("cinn_od", DB_DATE, dbNullFieldOption);
            CreateField("cinn_do", DB_DATE, dbNullFieldOption);
            CreateField("dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyd_cinn_od", DB_DATE, dbNullFieldOption);
            CreateField("s1", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s2", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s3", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s4", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s5", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s6", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s7", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s8", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s9", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s10", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s11", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s12", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("s1_12", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("vylouc_doby1", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad1", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet1", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby2", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad2", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet2", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby3", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad3", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet3", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby4", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad4", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet4", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby5", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad5", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet5", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby6", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad6", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet6", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby7", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad7", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet7", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby8", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad8", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet8", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby9", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad9", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet9", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby10", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad10", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet10", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby11", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad11", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet11", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby12", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vymer_zaklad12", DB_LONG, dbNotNullFieldOption);
            CreateField("doby_odecet12", DB_INTEGER, dbNotNullFieldOption);
        }

    }

    public class TableZsestPrehvyuctfinInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_PREHVYUCTFIN";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPrehvyuctfinInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPrehvyuctfinInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("skupina", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poradi", DB_LONG, dbNotNullFieldOption);
            CreateField("format_hod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("format_rad", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("popis_text", DB_TEXT, 255, dbNullFieldOption);
            CreateField("hodnota_numb", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("hodnota_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("ucetmad_text", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("ucetdal_text", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestPotVptInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_POT_VPT";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPotVptInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPotVptInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("socsprava_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cislo_socpoj", DB_TEXT, 50, dbNullFieldOption);
            CreateField("dat_zacatek_nesch", DB_DATE, dbNullFieldOption);
            CreateField("dat_zamest_zac", DB_DATE, dbNullFieldOption);
            CreateField("dat_zamest_kon", DB_DATE, dbNullFieldOption);
            CreateField("kod_zamest_cinn", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod_neprit", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("cis_rozhod", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("trideni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("pril_a", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_b", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_c", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_d", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_e", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_f", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_g", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_h", DB_TEXT, 100, dbNullFieldOption);
            CreateFTEXT("pril_i", DB_TEXT, 100, dbNullFieldOption);
        }

    }

    public class TableZsestPotVptRozhobdInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_POT_VPT_ROZHOBD";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPotVptRozhobdInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPotVptRozhobdInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("obd_rozhod_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby_01", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby_02", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vylouc_doby_03", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mes_ulozeni", DB_INTEGER, dbNotNullFieldOption);
        }

    }

    public class TableZsestPrehlZdrpInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_PREHL_ZDRP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPrehlZdrpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPrehlZdrpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zdrpojist_id", DB_LONG, dbNotNullFieldOption);
            CreateField("info_org", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 11, dbNullFieldOption);
            CreateField("druh_cinnosti", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("popis_prac_pom", DB_TEXT, 255, dbNullFieldOption);
            CreateField("ucast_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("zdr_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("max_poj", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("maldoh", DB_BYTE, dbNotNullFieldOption);
            CreateField("platiStat", DB_LONG, dbNotNullFieldOption);
            CreateField("ppom_stav", DB_INTEGER, dbNotNullFieldOption);
            CreateField("koef_poj", DB_BYTE, dbNotNullFieldOption);
            CreateField("koef_den", DB_BYTE, dbNotNullFieldOption);
            CreateField("zap_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("pojist_org", DB_LONG, dbNotNullFieldOption);
            CreateField("pojist_zam", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestZadostBonusmrInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_ZADOST_BONUSMR";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestZadostBonusmrInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestZadostBonusmrInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zal_prep_sl", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_preplat", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_prep_zc", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_prep_ms", DB_LONG, dbNotNullFieldOption);
            CreateField("sra_preplat", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_vrac_sl", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_vraceno", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_vrac_zc", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_vrac_ms", DB_LONG, dbNotNullFieldOption);
            CreateField("sra_vraceno", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_predb_r", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_bonus_r", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_predb_m", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_bonus_m", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_dat_vyp", DB_DATE, dbNullFieldOption);
            CreateField("sra_dat_vyp", DB_DATE, dbNullFieldOption);
        }

    }

    public class TableZsestPotvvrzOsr111Info : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_POTVVRZ_OSR111";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestPotvvrzOsr111Info(lpszOwnerName, lpszUsersName);
        }
        public TableZsestPotvvrzOsr111Info(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("ppomer_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pocdnu_odpr2", DB_LONG, dbNotNullFieldOption);
            CreateField("pocdnu_neo3n", DB_LONG, dbNotNullFieldOption);
            CreateField("pocdnu_neo3d", DB_LONG, dbNotNullFieldOption);
            CreateField("pocdnu_neo3a", DB_LONG, dbNotNullFieldOption);
            CreateField("pocdnu_neo3z", DB_LONG, dbNotNullFieldOption);
            CreateField("pochod_pres4", DB_LONG, dbNotNullFieldOption);
            CreateField("hrmzda_zakl5", DB_LONG, dbNotNullFieldOption);
            CreateField("hrmzda_prip6", DB_LONG, dbNotNullFieldOption);
            CreateField("hrmzda_osts7", DB_LONG, dbNotNullFieldOption);
            CreateField("hrnahr_mzdy8", DB_LONG, dbNotNullFieldOption);
            CreateField("odmena_ppoh9", DB_LONG, dbNotNullFieldOption);
            CreateField("davnem_poj11", DB_LONG, dbNotNullFieldOption);
            CreateField("dan_zaloha12", DB_LONG, dbNotNullFieldOption);
            CreateField("poj_socpoj13", DB_LONG, dbNotNullFieldOption);
            CreateField("poj_zdrpoj14", DB_LONG, dbNotNullFieldOption);
            CreateField("prum_cistm16", DB_LONG, dbNotNullFieldOption);
            CreateField("sloz_delsi17", DB_LONG, dbNotNullFieldOption);
            CreateField("cest_nahrd18", DB_LONG, dbNotNullFieldOption);
            CreateField("ostatni_pl19", DB_LONG, dbNotNullFieldOption);
            CreateField("ostatni_sr20", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestKartazZaklInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_KARTAZ_ZAKL";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestKartazZaklInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestKartazZaklInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("identif_zam", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("oscislo", DB_TEXT, 255, dbNullFieldOption);
            CreateField("pohlavi", DB_BYTE, dbNotNullFieldOption);
            CreateField("rok_narozeni", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod_vzdelani", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pocet_letpraxe", DB_LONG, dbNotNullFieldOption);
            CreateField("pocet_dnupraxe", DB_LONG, dbNotNullFieldOption);
            CreateField("pocet_letvorg", DB_LONG, dbNotNullFieldOption);
            CreateField("pocet_dnuvorg", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestKartazPpozInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_KARTAZ_PPOZ";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestKartazPpozInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestKartazPpozInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("identif_zam", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("oscislo", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("identif_sluz", DB_TEXT, 255, dbNullFieldOption);
            CreateField("kod_pracpozice", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod_pracpomeru", DB_INTEGER, dbNotNullFieldOption);
            CreateField("koef_uvazek", DB_LONG, dbNotNullFieldOption);
            CreateField("rozsah_hodin", DB_LONG, dbNotNullFieldOption);
            CreateField("obdobi_od", DB_DATE, dbNullFieldOption);
            CreateField("obdobi_do", DB_DATE, dbNullFieldOption);
            CreateFTEXT("identif_ppom", DB_TEXT, 255, dbNullFieldOption);
        }

    }

    public class TableZsestKartazVzdvInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_KARTAZ_VZDV";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestKartazVzdvInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestKartazVzdvInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("identif_zam", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("oscislo", DB_TEXT, 255, dbNullFieldOption);
            CreateField("kod_vzdelavani", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pocet_hodin", DB_LONG, dbNotNullFieldOption);
        }

    }

    public class TableZsestKartazPpomInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZSEST_KARTAZ_PPOM";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZsestKartazPpomInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZsestKartazPpomInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("identif_zam", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("oscislo", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("identif_sluz", DB_TEXT, 255, dbNullFieldOption);
            CreateField("pocet_letvpp", DB_LONG, dbNotNullFieldOption);
            CreateField("pocet_dnuvpp", DB_LONG, dbNotNullFieldOption);
        }

    }

}
