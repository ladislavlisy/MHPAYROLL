using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    public class TableDetailMediaInfo : TableDefInfo
    {
        const string TABLE_NAME = "DETAIL_MEDIA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableDetailMediaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableDetailMediaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("detail_id", DB_LONG);
            CreateField("poradi", DB_BYTE, dbNotNullFieldOption);
            CreateField("skupina", DB_BYTE, dbNotNullFieldOption);
            CreateField("navesti", DB_LONG, dbNotNullFieldOption);
            CreateField("info", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sirka_exp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sirka_op", DB_INTEGER, dbNotNullFieldOption);
            CreateField("format_typ", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("format_str", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("nadpis", DB_TEXT, 80, dbNullFieldOption);
            CreateField("smedium_id", DB_LONG, dbNullFieldOption);
            CreateField("pmedium_id", DB_LONG, dbNullFieldOption);
            CreateField("umedium_id", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("detail_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1DETAIL_MEDIA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("smedium_id");
            TableIndex = CreateIndex("XIF2DETAIL_MEDIA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pmedium_id");
            TableIndex = CreateIndex("XIF3DETAIL_MEDIA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("umedium_id");
        }

    }

    public class TablePoplatkyInfo : TableDefInfo
    {
        const string TABLE_NAME = "POPLATKY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePoplatkyInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePoplatkyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("smedium_id", DB_LONG, dbNotNullFieldOption);
            CreateField("platnost_od", DB_DATE, dbNotNullFieldOption);
            CreateField("castka_do", DB_LONG, dbNotNullFieldOption);
            CreateField("platnost_do", DB_DATE, dbNullFieldOption);
            CreateField("sazba", DB_LONG, dbNotNullFieldOption);
            CreateField("castka_dalsi", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("smedium_id");
            PKConstraint.AppendField("platnost_od");
            PKConstraint.AppendField("castka_do");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1POPLATKY");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("smedium_id");

            RelationDefInfo TableRelation = null;
            TableRelation = CreateRelation("sid_pop", "SBERNE_MEDIUM", "smedium_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("smedium_id", "smedium_id");
        }

    }

    public class TableFiltrMediaInfo : TableDefInfo
    {
        const string TABLE_NAME = "FILTR_MEDIA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableFiltrMediaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableFiltrMediaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("smedium_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("filtr_id", DB_LONG);
            CreateField("zpusob", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("cislo_uctu", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("varsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("konsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("specsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("popis", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("cislo_pobocky", DB_TEXT, 10, dbNullFieldOption);
            CreateField("sloz_pkod", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("sloz_ukod", DB_TEXT, 10, dbNullFieldOption);
            CreateField("filtr_utvar", DB_LONG, dbNotNullFieldOption);
            CreateField("filtr_divize", DB_LONG, dbNotNullFieldOption);
            CreateField("filtr_str", DB_LONG, dbNotNullFieldOption);
            CreateField("filtr_cin", DB_LONG, dbNotNullFieldOption);
            CreateField("filtr_zak", DB_LONG, dbNotNullFieldOption);
            CreateField("filtr_zdr", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("smedium_id");
            PKConstraint.AppendField("filtr_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1FILTR_MEDIA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("smedium_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("sid_fil", "SBERNE_MEDIUM", "smedium_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("smedium_id", "smedium_id");
        }

    }

    public class TableFiltrPmediaInfo : TableDefInfo
    {
        const string TABLE_NAME = "FILTR_PMEDIA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableFiltrPmediaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableFiltrPmediaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pmedium_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("filtr_id", DB_LONG);
            CreateField("zpusob", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("cislo_uctu", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("varsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("konsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("specsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("popis", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("cislo_pobocky", DB_TEXT, 10, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pmedium_id");
            PKConstraint.AppendField("filtr_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1FILTR_PMEDIA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pmedium_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("pid_pfil", "PLATEBNI_MEDIUM", "pmedium_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pmedium_id", "pmedium_id");
        }

    }

    public class TableFiltrUmediaInfo : TableDefInfo
    {
        const string TABLE_NAME = "FILTR_UMEDIA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableFiltrUmediaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableFiltrUmediaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("umedium_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("filtr_id", DB_LONG);
            CreateFTEXT("ukontace_typ", DB_TEXT, 25, dbNotNullFieldOption);
            CreateFTEXT("mad_ucet_skup", DB_TEXT, 3, dbNullFieldOption);
            CreateFTEXT("mad_ucet_synt", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("mad_ucet_anal", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("dal_ucet_skup", DB_TEXT, 3, dbNullFieldOption);
            CreateFTEXT("dal_ucet_synt", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("dal_ucet_anal", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("rozp_kapitola", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_paragraf", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_polozka", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_podpoloz", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_zazpoloz", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_ucelzdroj", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_kompetent", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_akce", DB_TEXT, 48, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("umedium_id");
            PKConstraint.AppendField("filtr_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1FILTR_UMEDIA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("umedium_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("umedium_filtr", "UCETNI_MEDIUM", "umedium_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("umedium_id", "umedium_id");
        }

    }

    public class TableSestavyFiltrInfo : TableDefInfo
    {
        const string TABLE_NAME = "SESTAVY_FILTR";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableSestavyFiltrInfo(lpszOwnerName, lpszUsersName);
        }
        public TableSestavyFiltrInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("typ_filtru", DB_BYTE, dbNotNullFieldOption);
            CreateField("poradi", DB_BYTE, dbNotNullFieldOption);
            CreateField("typ_vyberu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kategorie", DB_BYTE, dbNotNullFieldOption);
            CreateField("druh", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod_polozky", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod_begin", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod_end", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zapocty", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_pr", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("kod_lst");
            PKConstraint.AppendField("typ_filtru");
            PKConstraint.AppendField("poradi");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1SESTAVY_FILTR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("kod_lst");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("slst_filtr", "SESTAVY_LST", "sestavy_lst_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("kod_lst", "kod_lst");
        }

    }

    public class TableSestavyLstInfo : TableDefInfo
    {
        const string TABLE_NAME = "SESTAVY_LST";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableSestavyLstInfo(lpszOwnerName, lpszUsersName);
        }
        public TableSestavyLstInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("nazev", DB_TEXT, 120, dbNotNullFieldOption);
            CreateField("druh", DB_BYTE, dbNotNullFieldOption);
            CreateField("typ_lst", DB_BYTE, dbNotNullFieldOption);
            CreateField("skupina", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("subjekt_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("soubor", DB_TEXT, 255, dbNullFieldOption);
            CreateField("informace", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("oddelovac_pol", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("oddelovac_rad", DB_TEXT, 5, dbNullFieldOption);
            CreateField("typcrlf_rad", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("trideni", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("kod_lst");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1SESTAVY_LST");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_slst", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableSestavyUdataInfo : TableDefInfo
    {
        const string TABLE_NAME = "SESTAVY_UDATA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableSestavyUdataInfo(lpszOwnerName, lpszUsersName);
        }
        public TableSestavyUdataInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_data", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vytvor_dat", DB_DATE, dbNullFieldOption);
            CreateField("vyuct_dat", DB_DATE, dbNullFieldOption);
            CreateField("mesic_od", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic_do", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("vytvor_txt", DB_TEXT, 255, dbNullFieldOption);
            CreateField("vytvor_vyuc", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("uzivatel_id");
            PKConstraint.AppendField("kod_data");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1SESTAVY_UDATA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("uzivatel_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("uziv_udata", "UZIVATEL", "uzivatel_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("uzivatel_id", "uuzivatel_id");
        }

    }

    public class TableSestavyUlstInfo : TableDefInfo
    {
        const string TABLE_NAME = "SESTAVY_ULST";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableSestavyUlstInfo(lpszOwnerName, lpszUsersName);
        }
        public TableSestavyUlstInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("tisknout", DB_LONG, dbNotNullFieldOption);
            CreateField("papir", DB_BYTE, dbNotNullFieldOption);
            CreateField("tridit", DB_BYTE, dbNotNullFieldOption);
            CreateField("pg_margins", DB_LONG, dbNotNullFieldOption);
            CreateField("sestavy_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("exp_cesta", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("lst_param", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("txt_param", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("msg_param", DB_TEXT, 255, dbNullFieldOption);
            CreateField("filtr_zobr", DB_BYTE, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("uzivatel_id");
            PKConstraint.AppendField("kod_lst");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1SESTAVY_ULST");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("uzivatel_id");
            TableIndex = CreateIndex("XIF2SESTAVY_ULST");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("kod_lst");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("uziv_ulst", "UZIVATEL", "uzivatel_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("uzivatel_id", "uuzivatel_id");
			TableRelation = CreateRelation("slst_ulst", "SESTAVY_LST", "sestavy_lst_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("kod_lst", "kod_lst");
        }

    }

    public class TableSestavyUzivInfo : TableDefInfo
    {
        const string TABLE_NAME = "SESTAVY_UZIV";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableSestavyUzivInfo(lpszOwnerName, lpszUsersName);
        }
        public TableSestavyUzivInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poradi", DB_BYTE, dbNotNullFieldOption);
            CreateField("navesti_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_detail", DB_INTEGER, dbNotNullFieldOption);
            CreateField("info", DB_LONG, dbNotNullFieldOption);
            CreateField("sirka", DB_INTEGER, dbNotNullFieldOption);
            CreateField("format", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("text_nadpisu", DB_TEXT, 80, dbNotNullFieldOption);
            CreateFTEXT("text_obsahu", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("text_xmlnode", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("text_xmlattr", DB_TEXT, 80, dbNullFieldOption);
            CreateField("sirka_exp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hod_mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hod_oprava", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hod_seznam", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("kod_lst");
            PKConstraint.AppendField("poradi");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1SESTAVY_UZIV");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("kod_lst");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("slst_usest", "SESTAVY_LST", "sestavy_lst_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("kod_lst", "kod_lst");
        }

    }

    public class TableSberneMediumInfo : TableDefInfo
    {
        const string TABLE_NAME = "SBERNE_MEDIUM";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableSberneMediumInfo(lpszOwnerName, lpszUsersName);
        }
        public TableSberneMediumInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("smedium_id", DB_LONG);
            CreateField("info_medium", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("nazev_klienta", DB_TEXT, 25, dbNullFieldOption);
            CreateField("soubor_start", DB_BYTE, dbNotNullFieldOption);
            CreateField("soubor_stop", DB_BYTE, dbNotNullFieldOption);
            CreateField("soubor_next", DB_BYTE, dbNotNullFieldOption);
            CreateField("datum_predani", DB_INTEGER, dbNotNullFieldOption);
            CreateField("datum_transakce", DB_INTEGER, dbNotNullFieldOption);
            CreateField("datum_splatnosti", DB_INTEGER, dbNotNullFieldOption);
            CreateField("datum_prevodu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("datum_popprev", DB_INTEGER, dbNotNullFieldOption);
            CreateField("bezny_bkspoj_id", DB_LONG, dbNotNullFieldOption);
            CreateField("debet_bkspoj_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cpopl_bkspoj_id", DB_LONG, dbNotNullFieldOption);
            CreateField("dpopl_bkspoj_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("par_kod_obr11", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("par_kod_obr32", DB_TEXT, 6, dbNullFieldOption);
            CreateField("crc", DB_LONG, dbNotNullFieldOption);
            CreateField("prior_prevodu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("prior_popprev", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("cislo_klienta", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("telefon", DB_TEXT, 20, dbNullFieldOption);
            CreateField("ucet_dal", DB_LONG, dbNullFieldOption);
            CreateField("ucet_md", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_str", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_zak", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_cin", DB_LONG, dbNullFieldOption);
            CreateField("prijem_id", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_zdr", DB_LONG, dbNullFieldOption);
            CreateField("soub_cis1", DB_BYTE, dbNotNullFieldOption);
            CreateField("soub_cis2", DB_BYTE, dbNotNullFieldOption);
            CreateField("soub_cis3", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("soub_txt1", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("soub_txt2", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("soub_txt3", DB_TEXT, 15, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("smedium_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1SBERNE_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2SBERNE_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ucet_dal");
            TableIndex = CreateIndex("XIF3SBERNE_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ucet_md");
            TableIndex = CreateIndex("XIF4SBERNE_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ucetni_zak");
            TableIndex = CreateIndex("XIF5SBERNE_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ucetni_str");
            TableIndex = CreateIndex("XIF6SBERNE_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ucetni_cin");
            TableIndex = CreateIndex("XIF7SBERNE_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("prijem_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_sbm", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TablePlatebniMediumInfo : TableDefInfo
    {
        const string TABLE_NAME = "PLATEBNI_MEDIUM";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePlatebniMediumInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePlatebniMediumInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("pmedium_id", DB_LONG);
            CreateField("info_medium", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("nazev_klienta", DB_TEXT, 25, dbNullFieldOption);
            CreateField("soubor_start", DB_INTEGER, dbNotNullFieldOption);
            CreateField("soubor_stop", DB_INTEGER, dbNotNullFieldOption);
            CreateField("soubor_next", DB_INTEGER, dbNotNullFieldOption);
            CreateField("datum_predani", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pol_cis1", DB_BYTE, dbNotNullFieldOption);
            CreateField("pol_cis2", DB_BYTE, dbNotNullFieldOption);
            CreateField("pol_cis3", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("pol_txt1", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("pol_txt2", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("pol_txt3", DB_TEXT, 15, dbNullFieldOption);
            CreateField("soub_cis1", DB_BYTE, dbNotNullFieldOption);
            CreateField("soub_cis2", DB_BYTE, dbNotNullFieldOption);
            CreateField("soub_cis3", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("soub_txt1", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("soub_txt2", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("soub_txt3", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("mena", DB_TEXT, 3, dbNullFieldOption);
            CreateFTEXT("ustav", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("cislo_pobocky", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("prideleny_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateField("banka_id", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pmedium_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PLATEBNI_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2PLATEBNI_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("banka_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_plm", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableUcetniMediumInfo : TableDefInfo
    {
        const string TABLE_NAME = "UCETNI_MEDIUM";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableUcetniMediumInfo(lpszOwnerName, lpszUsersName);
        }
        public TableUcetniMediumInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("umedium_id", DB_LONG);
            CreateField("info_medium", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("doklad_druh", DB_TEXT, 6, dbNullFieldOption);
            CreateField("soub_cis1", DB_BYTE, dbNotNullFieldOption);
            CreateField("soub_cis2", DB_BYTE, dbNotNullFieldOption);
            CreateField("soub_cis3", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("soub_txt1", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("soub_txt2", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("soub_txt3", DB_TEXT, 15, dbNullFieldOption);
            CreateField("doklad_cis1", DB_BYTE, dbNotNullFieldOption);
            CreateField("doklad_cis2", DB_BYTE, dbNotNullFieldOption);
            CreateField("doklad_cis3", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("doklad_txt1", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("doklad_txt2", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("doklad_txt3", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("ucto_klicmd", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("ucto_klicdal", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("znam_plus", DB_TEXT, 3, dbNullFieldOption);
            CreateFTEXT("znam_minus", DB_TEXT, 3, dbNullFieldOption);
            CreateFTEXT("domaci_mena", DB_TEXT, 3, dbNullFieldOption);
            CreateField("spoj_ucet_md", DB_LONG, dbNullFieldOption);
            CreateField("spoj_ucet_dal", DB_LONG, dbNullFieldOption);
            CreateField("bezny_ucet_md", DB_LONG, dbNullFieldOption);
            CreateField("bezny_ucet_dal", DB_LONG, dbNullFieldOption);
            CreateField("korekce_str", DB_LONG, dbNotNullFieldOption);
            CreateField("korekce_zak", DB_LONG, dbNotNullFieldOption);
            CreateField("korekce_cin", DB_LONG, dbNotNullFieldOption);
            CreateField("korekce_zdr", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("umedium_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1UCETNI_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2UCETNI_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("spoj_ucet_md");
            TableIndex = CreateIndex("XIF3UCETNI_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("spoj_ucet_dal");
            TableIndex = CreateIndex("XIF4UCETNI_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("bezny_ucet_md");
            TableIndex = CreateIndex("XIF5UCETNI_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("bezny_ucet_dal");
            TableIndex = CreateIndex("XIF6UCETNI_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("korekce_zak");
            TableIndex = CreateIndex("XIF7UCETNI_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("korekce_str");
            TableIndex = CreateIndex("XIF8UCETNI_MEDIUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("korekce_cin");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_ucm", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
			TableRelation = CreateRelation("zdr_umed", "STRED_CINZAK", "korekce_zdr");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("korekce_zdr", "strcinzak_id");
			TableRelation = CreateRelation("cin_umed", "STRED_CINZAK", "korekce_cin");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("korekce_cin", "strcinzak_id");
			TableRelation = CreateRelation("str_umed", "STRED_CINZAK", "korekce_str");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("korekce_str", "strcinzak_id");
			TableRelation = CreateRelation("zak_umed", "STRED_CINZAK", "korekce_zak");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("korekce_zak", "strcinzak_id");
        }

    }

    public class TableNavestiFiltrInfo : TableDefInfo
    {
        const string TABLE_NAME = "NAVESTI_FILTR";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableNavestiFiltrInfo(lpszOwnerName, lpszUsersName);
        }
        public TableNavestiFiltrInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_navesti", DB_INTEGER, dbNotNullFieldOption);
            CreateField("typ_filtru", DB_BYTE, dbNotNullFieldOption);
            CreateField("poradi", DB_BYTE, dbNotNullFieldOption);
            CreateField("typ_vyberu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kategorie", DB_BYTE, dbNotNullFieldOption);
            CreateField("druh", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod_polozky", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod_begin", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod_end", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zapocty", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_pr", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("kod_navesti");
            PKConstraint.AppendField("typ_filtru");
            PKConstraint.AppendField("poradi");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("nav_filtr", "NAVESTI_UZIV", "navesti_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("kod_navesti", "kod_navesti");
        }

    }

    public class TableNavestiUzivInfo : TableDefInfo
    {
        const string TABLE_NAME = "NAVESTI_UZIV";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableNavestiUzivInfo(lpszOwnerName, lpszUsersName);
        }
        public TableNavestiUzivInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_navesti", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("nazev", DB_TEXT, 70, dbNotNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("kod_navesti");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1NAVESTI_UZIV");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_nav", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TablePracUkazateleInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRAC_UKAZATELE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePracUkazateleInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePracUkazateleInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("poradi", DB_BYTE, dbNotNullFieldOption);
            CreateField("navesti_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_detail", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("text_nadpisu", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("text_obsahu", DB_TEXT, 255, dbNullFieldOption);
            CreateField("info", DB_LONG, dbNotNullFieldOption);
            CreateField("format", DB_BYTE, dbNotNullFieldOption);
            CreateField("sirka", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sirka_exp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hod_mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hod_oprava", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hod_seznam", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("text_xmlattr", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("text_xmlnode", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("poradi");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fir_pracukaz", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TablePpomUkazateleInfo : TableDefInfo
    {
        const string TABLE_NAME = "PPOM_UKAZATELE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePpomUkazateleInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePpomUkazateleInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("poradi", DB_BYTE, dbNotNullFieldOption);
            CreateField("navesti_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_detail", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("text_nadpisu", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("text_obsahu", DB_TEXT, 255, dbNullFieldOption);
            CreateField("info", DB_LONG, dbNotNullFieldOption);
            CreateField("format", DB_BYTE, dbNotNullFieldOption);
            CreateField("sirka", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sirka_exp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hod_mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hod_oprava", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hod_seznam", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("text_xmlattr", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("text_xmlnode", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("poradi");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fir_ppomukaz", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableVrepPodaniDataInfo : TableDefInfo
    {
        const string TABLE_NAME = "VREP_PODANI_DATA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableVrepPodaniDataInfo(lpszOwnerName, lpszUsersName);
        }
        public TableVrepPodaniDataInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("ppodani_id", DB_LONG);
            CreateFTEXT("correlation_id", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("vars_sign", DB_TEXT, 50, dbNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("podani_type", DB_INTEGER, dbNotNullFieldOption);
            CreateField("podani_state", DB_INTEGER, dbNotNullFieldOption);
            CreateField("podani_date", DB_DATE, dbNullFieldOption);
            CreateFTEXT("cert_sign", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cert_crypt", DB_TEXT, 255, dbNullFieldOption);
            CreateField("xml_data", DB_LONGBINARY, dbNullFieldOption);
            CreateField("xml_error", DB_LONGBINARY, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("ppodani_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1VREP_PODANI_DATA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("uzivatel_id");
            TableIndex.AppendField("ppodani_id");
        }

    }

    public class TableExcelUimpInfo : TableDefInfo
    {
        const string TABLE_NAME = "EXCEL_UIMP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableExcelUimpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableExcelUimpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("excelimp_id", DB_LONG);
            CreateField("radek_start", DB_LONG, dbNotNullFieldOption);
            CreateField("radek_konec", DB_LONG, dbNotNullFieldOption);
            CreateField("typvety_imp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("empty_konec", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("nazev_imp", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("exp_cesta", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cfg_cesta", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("lst_param", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("uzivatel_id");
            PKConstraint.AppendField("excelimp_id");
        }

    }

}
