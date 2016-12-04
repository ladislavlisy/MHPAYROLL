using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    public class TableFirmaInfo : TableDefInfo
    {
        const string TABLE_NAME = "FIRMA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableFirmaInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("ffirma_id", "firma_id"),
                new Tuple<string, string>("firnazev", "nazev")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TableFirmaInfo(string lpszOwnerName, string lpszUsersName) : 
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateFAUTO("ffirma_id", DB_LONG);
            CreateFTEXT("firnazev", DB_TEXT, 20, dbNotNullFieldOption);
            CreateField("verze", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("zap_obchrej", DB_TEXT, 255, dbNullFieldOption);
            CreateField("cislo_prac", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("sest_textoou", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rozp_kapitola", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_paragraf", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_polozka", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_podpoloz", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_zazpoloz", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_ucelzdroj", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_kompetent", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_akce", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("mvprac_nazev", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mvprac_nobec", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("mvprac_kobec", DB_TEXT, 10, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("ffirma_id");
        }
    }

    public class TableSvatekInfo : TableDefInfo
    {
        const string TABLE_NAME = "SVATEK";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableSvatekInfo(lpszOwnerName, lpszUsersName);
        }
        public TableSvatekInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("datum", DB_DATE, dbNotNullFieldOption);
            CreateField("velikonoce", DB_BYTE, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("datum");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1SVATEK");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_svat", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableAdresaInfo : TableDefInfo
    {
        const string TABLE_NAME = "ADRESA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableAdresaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableAdresaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("adresa_id", DB_LONG);
            CreateField("stat_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("obec", DB_TEXT, 48, dbNotNullFieldOption);
            CreateFTEXT("cast_obce", DB_TEXT, 48, dbNullFieldOption);
            CreateField("cisdom_typ", DB_BYTE, dbNotNullFieldOption);
            CreateField("cisdom_hod", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("ulice", DB_TEXT, 48, dbNullFieldOption);
            CreateField("cisor_hod", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("cisor_pis", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("psc", DB_TEXT, 11, dbNullFieldOption);
            CreateFTEXT("nazev_posty", DB_TEXT, 40, dbNullFieldOption);
            CreateField("trv_adr_prac", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("org_id", DB_LONG, dbNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("adresa_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1ADRESA");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2ADRESA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("org_id");
            TableIndex = CreateIndex("XIF3ADRESA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex = CreateIndex("XIF4ADRESA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("stat_kod");

            RelationDefInfo TableRelation = null;
            TableRelation = CreateRelation("fid_adr", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");

			TableRelation = CreateRelation("uzivc_adr_stat", "UZIV_CISELNIK", "stat_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("stat_kod", "uzc_kod");
        }
    }

    public class TableBankSpojInfo : TableDefInfo
    {
        const string TABLE_NAME = "BANK_SPOJ";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableBankSpojInfo(lpszOwnerName, lpszUsersName);
        }
        public TableBankSpojInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("bspoj_id", DB_LONG);
            CreateFTEXT("ucet", DB_TEXT, 18, dbNullFieldOption);
            CreateFTEXT("ustav", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("konsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("varsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("specsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateField("org_id", DB_LONG, dbNullFieldOption);
            CreateField("banka_id", DB_LONG, dbNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNullFieldOption);
            CreateFTEXT("iban", DB_TEXT, 40, dbNullFieldOption);
            CreateField("bspoj_info", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("bspoj_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1BANK_SPOJ");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2BANK_SPOJ");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("org_id");
            TableIndex = CreateIndex("XIF3BANK_SPOJ");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex = CreateIndex("XIF4BANK_SPOJ");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("banka_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_bspoj", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableOrganizaceInfo : TableDefInfo
    {
        const string TABLE_NAME = "ORGANIZACE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableOrganizaceInfo(lpszOwnerName, lpszUsersName);
        }
        public TableOrganizaceInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("org_id", DB_LONG);
            CreateFTEXT("nazev", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("druh", DB_BYTE, dbNotNullFieldOption);
            CreateField("info_org", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("ucetni_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("misto", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("ico_kod", DB_TEXT, 35, dbNullFieldOption);
            CreateFTEXT("dic", DB_TEXT, 35, dbNullFieldOption);
            CreateFTEXT("zkratka", DB_TEXT, 10, dbNullFieldOption);
            CreateField("okres_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("stat_kod", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("org_id");
            
            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1ORGANIZACE");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2ORGANIZACE");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("stat_kod");
            TableIndex = CreateIndex("XIF3ORGANIZACE");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("okres_kod");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_org", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
			TableRelation = CreateRelation("uzivc_org_stat", "UZIV_CISELNIK", "stat_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("stat_kod", "uzc_kod");
        }

    }

    public class TableUtvarInfo : TableDefInfo
    {
        const string TABLE_NAME = "UTVAR";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableUtvarInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("uutvar_id", "utvar_id"),
                new Tuple<string, string>("utvnazev", "nazev")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TableUtvarInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("uutvar_id", DB_LONG);
            CreateField("zeme_cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("utvnazev", DB_TEXT, 50, dbNotNullFieldOption);
            CreateFTEXT("ucetni_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("stat_nuts", DB_TEXT, 10, dbNullFieldOption);
            CreateField("vyuctgr", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
            CreateField("platnost_od", DB_DATE, dbNullFieldOption);
            CreateField("platnost_do", DB_DATE, dbNullFieldOption);
            CreateField("personal_id", DB_LONG, dbNotNullFieldOption);
            CreateField("prohlizet_id", DB_LONG, dbNotNullFieldOption);
            CreateField("omezproh_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNullFieldOption);
            CreateField("zdroj_id", DB_LONG, dbNullFieldOption);
            CreateField("stred_id", DB_LONG, dbNullFieldOption);
            CreateField("cinn_id", DB_LONG, dbNullFieldOption);
            CreateField("zakaz_id", DB_LONG, dbNullFieldOption);
            CreateField("referzp_id", DB_LONG, dbNotNullFieldOption);
            CreateField("druh_zar", DB_INTEGER, dbNotNullFieldOption);
            CreateField("informace", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("mvprac_nazev", DB_TEXT, 255, true);
            CreateFTEXT("mvprac_nobec", DB_TEXT, 255, true);
            CreateFTEXT("mvprac_kobec", DB_TEXT, 10, true);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("uutvar_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1UTVAR");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2UTVAR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("zeme_cislo");
            TableIndex = CreateIndex("XIF3UTVAR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("uzivatel_id");
            TableIndex = CreateIndex("XIF4UTVAR");
            TableIndex.AppendField("zdroj_id");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF5UTVAR");
            TableIndex.AppendField("stred_id");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF6UTVAR");
            TableIndex.AppendField("cinn_id");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF7UTVAR");
            TableIndex.AppendField("zakaz_id");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF8UTVAR");
            TableIndex.AppendField("druh_zar");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF1VYBUTVAR");
            TableIndex.AppendField("utvnazev");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_utv", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
			TableRelation = CreateRelation("zdroj_utvar", "STRED_CINZAK", "zdroj_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("zdroj_id", "strcinzak_id");
			TableRelation = CreateRelation("stred_utvar", "STRED_CINZAK", "stred_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("stred_id", "strcinzak_id");
			TableRelation = CreateRelation("cinn_utvar", "STRED_CINZAK", "cinn_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("cinn_id", "strcinzak_id");
			TableRelation = CreateRelation("zakaz_utvar", "STRED_CINZAK", "zakaz_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("zakaz_id", "strcinzak_id");
			TableRelation = CreateRelation("zariz_utvar", "UZIV_CISELNIK", "druh_zar_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("druh_zar", "uzc_kod");
			TableRelation = CreateRelation("zemid_utvar", "ZEME_PLATKOEF", "zeme_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("zeme_cislo", "zzeme_cislo");
        }

    }

    public class TableDivizeStredInfo : TableDefInfo
    {
        const string TABLE_NAME = "DIVIZE_STRED";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableDivizeStredInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("ddivize_id", "divize_id"),
                new Tuple<string, string>("diviznazev", "nazev")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TableDivizeStredInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("ddivize_id", DB_LONG);
            CreateFTEXT("diviznazev", DB_TEXT, 50, dbNotNullFieldOption);
            CreateFTEXT("ucetni_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("stat_nuts", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
            CreateField("platnost_od", DB_DATE, dbNullFieldOption);
            CreateField("platnost_do", DB_DATE, dbNullFieldOption);
            CreateField("druh_zar", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("mvprac_nazev", DB_TEXT, 255, true);
            CreateFTEXT("mvprac_nobec", DB_TEXT, 255, true);
            CreateFTEXT("mvprac_kobec", DB_TEXT, 10, true);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("ddivize_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1DIVIZE_STRED");
            TableIndex.AppendField("firma_id");      
            TableIndex = CreateIndex("XIF1VYBDIVIZE_STRED");
            TableIndex.AppendField("diviznazev");
            TableIndex = CreateIndex("XIF2DIVIZE_STRED");
            TableIndex.AppendField("druh_zar");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_div", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
			TableRelation = CreateRelation("zariz_diviz", "UZIV_CISELNIK", "druh_zar_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("druh_zar", "uzc_kod");
        }

    }

    public class TableStredCinzakInfo : TableDefInfo
    {
        const string TABLE_NAME = "STRED_CINZAK";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStredCinzakInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStredCinzakInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("strcinzak_id", DB_LONG);
            CreateFTEXT("nazev", DB_TEXT, 50, dbNotNullFieldOption);
            CreateField("druh", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("ucetni_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("stat_nuts", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
            CreateField("platnost_od", DB_DATE, dbNullFieldOption);
            CreateField("platnost_do", DB_DATE, dbNullFieldOption);
            CreateField("divize_id", DB_LONG, dbNullFieldOption);
            CreateField("bezny_md", DB_LONG, dbNotNullFieldOption);
            CreateField("bezny_dal", DB_LONG, dbNotNullFieldOption);
            CreateField("druh_zar", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("mvprac_nazev", DB_TEXT, 255, true);
            CreateFTEXT("mvprac_nobec", DB_TEXT, 255, true);
            CreateFTEXT("mvprac_kobec", DB_TEXT, 10, true);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("strcinzak_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1STRED_CINZAK");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2STRED_CINZAK");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("divize_id");
            TableIndex = CreateIndex("XIF3STRED_CINZAK");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("bezny_md");
            TableIndex = CreateIndex("XIF4STRED_CINZAK");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("bezny_dal");
            TableIndex = CreateIndex("XIF5STRED_CINZAK");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("druh_zar");
            TableIndex = CreateIndex("XIF1VYBSTRED_CINZAK");
            TableIndex.AppendField("druh");
            TableIndex.AppendField("nazev");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_str", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
			TableRelation = CreateRelation("zariz_strcz", "UZIV_CISELNIK", "druh_zar_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("druh_zar", "uzc_kod");
        }

    }

    public class TableStredRozpocetInfo : TableDefInfo
    {
        const string TABLE_NAME = "STRED_ROZPOCET";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStredRozpocetInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStredRozpocetInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("rozpocet_id", DB_LONG);
            CreateField("strcinzak_id", DB_LONG, dbNotNullFieldOption);
            CreateField("strcinzak_druh", DB_BYTE, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("datum", DB_DATE, dbNullFieldOption);
            CreateField("druh", DB_BYTE, dbNotNullFieldOption);
            CreateField("zmena_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rozp_data1", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data2", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data3", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data4", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data5", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data6", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data7", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data8", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data9", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data10", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data11", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data12", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data13", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data14", DB_LONG, dbNotNullFieldOption);
            CreateField("rozp_data15", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("rozpocet_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1STRED_ROZPOCET");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("strcinzak_id");
            TableIndex = CreateIndex("XIF2STRED_ROZPOCET");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("rok_rozpoc_firma", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
			TableRelation = CreateRelation("rok_rozpoc_stred", "STRED_CINZAK", "strcinzak_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("strcinzak_id", "strcinzak_id");
        }

    }

    public class TableStavSemaforInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_SEMAFOR";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavSemaforInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStavSemaforInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("semaf_type", DB_INTEGER, dbNotNullFieldOption);
            CreateField("semaf_flag", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("semaf_guid", DB_TEXT, 64, dbNullFieldOption);
            CreateField("semaf_time", DB_DATE, dbNullFieldOption);
            CreateField("server_sid", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("wwks_name", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("wwks_user", DB_TEXT, 255, dbNullFieldOption);
            CreateField("serial_num", DB_LONG, dbNotNullFieldOption);
            CreateField("pracov_id", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("uzivatel_id");
            PKConstraint.AppendField("semaf_type");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1STAV_SEMAFOR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("uzivatel_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("uid_semaf", "UZIVATEL", "uzivatel_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("uzivatel_id", "uuzivatel_id");
        }

    }

    public class TableUzivatelInfo : TableDefInfo
    {
        const string TABLE_NAME = "UZIVATEL";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableUzivatelInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("uuzivatel_id", "uzivatel_id"),
                new Tuple<string, string>("uzivjmeno", "jmeno"),
                new Tuple<string, string>("uzivfunkce", "funkce"),
                new Tuple<string, string>("uziv_param_info", "uparam_info"),
                new Tuple<string, string>("uzivfunkce_omez", "funkce_omez"),
                new Tuple<string, string>("uzivfunkce_edit", "funkce_edit"),
                new Tuple<string, string>("uzivfuncfg_omez", "funcfg_omez"),
                new Tuple<string, string>("uzivfuncfg_edit", "funcfg_edit"),
                new Tuple<string, string>("uzivfunkce_new", "funkce_new"),
                new Tuple<string, string>("uzivfunkce_del", "funkce_del"),
                new Tuple<string, string>("uzivfuncfg_new", "funcfg_new"),
                new Tuple<string, string>("uzivfuncfg_del", "funcfg_del")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TableUzivatelInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("uuzivatel_id", DB_LONG);
            CreateFTEXT("uzivjmeno", DB_TEXT, 20, dbNotNullFieldOption);
            CreateField("uzivfunkce", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("uzivemail", DB_TEXT, 255, dbNullFieldOption);
            CreateField("uzivsidlo", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("heslo", DB_TEXT, 80, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 40, dbNullFieldOption);
            CreateField("jazyk", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("telefon", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("tel_linka", DB_TEXT, 5, dbNullFieldOption);
            CreateField("sestavy_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("uzivcerts", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("uzivcertp", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("uzivpdfpw", DB_TEXT, 255, dbNullFieldOption);
            CreateField("uziv_param_info", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivfunkce_omez", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivfunkce_edit", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivfuncfg_omez", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivfuncfg_edit", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivfunkce_new", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivfunkce_del", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivfuncfg_new", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivfuncfg_del", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("pjmeno", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("uuzivatel_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1UZIVATEL");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_uziv", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

}
