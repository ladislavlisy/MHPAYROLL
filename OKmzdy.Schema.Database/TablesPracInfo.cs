using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    public class TablePracInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRAC";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePracInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("ppracovnik_id", "id")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TablePracInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("ppracovnik_id", DB_LONG);
            CreateField("person_info", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 10, dbNotNullFieldOption);
            CreateFTEXT("rodne_prijmeni", DB_TEXT, 35, dbNotNullFieldOption);
            CreateField("pocitane_obdobi", DB_INTEGER, dbNotNullFieldOption);
            CreateField("logicky_neuplny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("logicky_zrusen", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("osobni_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("evid_cislo", DB_TEXT, 50, dbNullFieldOption);
            CreateField("nema_rodcis", DB_BYTE, dbNotNullFieldOption);
            CreateField("pohlavi", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 35, dbNotNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 30, dbNotNullFieldOption);
            CreateFTEXT("titul_pred", DB_TEXT, 35, dbNullFieldOption);
            CreateFTEXT("titul_za", DB_TEXT, 10, dbNullFieldOption);
            CreateField("datum_narozeni", DB_DATE, dbNotNullFieldOption);
            CreateField("stat_narozeni", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("misto_narozeni", DB_TEXT, 48, dbNullFieldOption);
            CreateField("zap_puv_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("zap_puv_roku", DB_BYTE, dbNotNullFieldOption);
            CreateField("zap_puv_dnu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zapocet_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("zapocet_roku", DB_BYTE, dbNotNullFieldOption);
            CreateField("zapocet_dnu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dovjenodpr", DB_BYTE, dbNotNullFieldOption);
            CreateField("vychov_deti", DB_INTEGER, dbNotNullFieldOption);
            CreateField("duchod_vyp", DB_BYTE, dbNotNullFieldOption);
            CreateField("duchod_vek", DB_INTEGER, dbNotNullFieldOption);
            CreateField("duchod_pos", DB_INTEGER, dbNotNullFieldOption);
            CreateField("duchod_nar", DB_DATE, dbNullFieldOption);
            CreateField("duchod_spl", DB_DATE, dbNullFieldOption);
            CreateField("duchod_pob", DB_DATE, dbNullFieldOption);
            CreateField("duchod_pobn", DB_DATE, dbNullFieldOption);
            CreateFTEXT("prukaz_obc", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("prukaz_pas", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("cizinec_rc", DB_TEXT, 20, dbNullFieldOption);
            CreateField("osamel_ziv", DB_BYTE, dbNotNullFieldOption);
            CreateField("rodst_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("duchod_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("obcan_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("zdrav_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("zpsst_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("duchod_eld", DB_BYTE, dbNotNullFieldOption);
            CreateField("vyplatakcs_id", DB_LONG, dbNotNullFieldOption);
            CreateField("vyplataval_id", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("ppracovnik_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PRAC");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2PRAC");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("rodst_kod");
            TableIndex = CreateIndex("XIF3PRAC");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("duchod_kod");
            TableIndex = CreateIndex("XIF4PRAC");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("obcan_kod");
            TableIndex = CreateIndex("XIF5PRAC");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("zdrav_kod");
            TableIndex = CreateIndex("XIF6PRAC");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("zpsst_kod");
            TableIndex = CreateIndex("XIF7PRAC");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("stat_narozeni");
            TableIndex = CreateIndex("XIF0VYBPRAC");
            TableIndex.AppendField("prijmeni");
            TableIndex = CreateIndex("XIF1VYBPRAC");
            TableIndex.AppendField("prijmeni");
            TableIndex.AppendField("jmeno");
            TableIndex.AppendField("titul_pred");
            TableIndex.AppendField("titul_za");
            TableIndex.AppendField("rodne_cislo");
            TableIndex = CreateIndex("XIF2VYBPRAC");
            TableIndex.AppendField("osobni_cislo");
            TableIndex = CreateIndex("XIF3VYBPRAC");
            TableIndex.AppendField("osobni_cislo");
            TableIndex.AppendField("prijmeni");
            TableIndex.AppendField("jmeno");
            TableIndex.AppendField("titul_pred");
            TableIndex.AppendField("titul_za");
            TableIndex.AppendField("rodne_cislo");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_prac", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
			TableRelation = CreateRelation("statnar", "UZIV_CISELNIK", "stat_narozeni_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("stat_narozeni", "uzc_kod");
        }

    }

    public class TableOsdataInfo : TableDefInfo
    {
        const string TABLE_NAME = "OSDATA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableOsdataInfo(lpszOwnerName, lpszUsersName);
        }
        public TableOsdataInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("osd_jkov", DB_TEXT, 7, dbNullFieldOption);
            CreateField("osd_skup_ridic", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("osd_telefon1", DB_TEXT, 50, dbNullFieldOption);
            CreateField("osd_telefon1_typ", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("osd_telefon2", DB_TEXT, 50, dbNullFieldOption);
            CreateField("osd_telefon2_typ", DB_BYTE, dbNotNullFieldOption);
            CreateField("osd_vojak", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("predchozi", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("osdata", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
            CreateField("osd_vzdel_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("osd_oborv_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("prech_adr", DB_LONG, dbNullFieldOption);
            CreateField("prech_adr_eldp", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("pracemail", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("praccertp", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("pracpdfpw", DB_TEXT, 255, dbNullFieldOption);
            CreateField("mat_naroz_d1", DB_DATE, dbNullFieldOption);
            CreateField("mat_ndvzk_d1", DB_LONG, dbNotNullFieldOption);
            CreateField("mat_naroz_d2", DB_DATE, dbNullFieldOption);
            CreateField("mat_ndvzk_d2", DB_LONG, dbNotNullFieldOption);
            CreateField("person_info", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF2OSDATA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("osd_oborv_kod");
            TableIndex = CreateIndex("XIF3OSDATA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("osd_vzdel_kod");
            TableIndex = CreateIndex("XIF4OSDATA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("prech_adr");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("pracid_osd", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
        }

    }

    public class TablePojistitelInfo : TableDefInfo
    {
        const string TABLE_NAME = "POJISTITEL";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePojistitelInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePojistitelInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateField("druh_cssz", DB_BYTE, dbNotNullFieldOption);
            CreateField("stat_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("org_id", DB_LONG, dbNullFieldOption);
            CreateField("adresa_id", DB_LONG, dbNullFieldOption);
            CreateField("plati_od", DB_DATE, dbNullFieldOption);
            CreateField("plati_do", DB_DATE, dbNullFieldOption);
            CreateFTEXT("cislo_poj", DB_TEXT, 25, dbNullFieldOption);
            CreateField("info_cssz", DB_LONG, dbNotNullFieldOption);
            CreateField("pocjed", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba", DB_LONG, dbNotNullFieldOption);
            CreateField("hodnota", DB_LONG, dbNotNullFieldOption);
            CreateField("nepritkod", DB_INTEGER, dbNullFieldOption);
            CreateField("zdrav_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zpsst_kod", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1POJISTITEL");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex = CreateIndex("XIF2POJISTITEL");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("adresa_id");
            TableIndex = CreateIndex("XIF3POJISTITEL");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("org_id");
            TableIndex = CreateIndex("XIF4POJISTITEL");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("stat_kod");
            TableIndex = CreateIndex("XIF5POJISTITEL");
            TableIndex.AppendField("zdrav_kod");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF6POJISTITEL");
            TableIndex.AppendField("zpsst_kod");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF7POJISTITEL");
            TableIndex.AppendField("nepritkod");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("prac_pojistitel", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
        }

    }

    public class TableHlaseniZpInfo : TableDefInfo
    {
        const string TABLE_NAME = "HLASENI_ZP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableHlaseniZpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableHlaseniZpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo", DB_BYTE, dbNotNullFieldOption);
            CreateField("plati_od", DB_DATE, dbNullFieldOption);
            CreateField("plati_do", DB_DATE, dbNullFieldOption);
            CreateField("datum", DB_DATE, dbNotNullFieldOption);
            CreateField("kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("informace", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic_zad", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("cislo_pojist", DB_TEXT, 10, dbNullFieldOption);
            CreateField("cizin_pojist", DB_BYTE, dbNotNullFieldOption);
            CreateField("zruseno", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("cislo_pojist1", DB_TEXT, 10, dbNullFieldOption);
            CreateField("cizin_pojist1", DB_BYTE, dbNotNullFieldOption);
            CreateField("zdravpoj_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pocjed", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba", DB_LONG, dbNotNullFieldOption);
            CreateField("hodnota", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("mesic");
            PKConstraint.AppendField("cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1HLASENI_ZP");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex = CreateIndex("XIF2HLASENI_ZP");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("zdravpoj_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("oid_hlas", "ORGANIZACE", "zdravpoj_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("zdravpoj_id", "org_id");
			TableRelation = CreateRelation("pracid_hlaszp", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
        }

    }

    public class TablePracNepritInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRAC_NEPRIT";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePracNepritInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePracNepritInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_ser", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hodnota", DB_LONG, dbNotNullFieldOption);
            CreateField("informace", DB_INTEGER, dbNotNullFieldOption);
            CreateField("inforauto", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zacat", DB_DATE, dbNullFieldOption);
            CreateField("konec", DB_DATE, dbNullFieldOption);
            CreateField("porod", DB_DATE, dbNullFieldOption);
            CreateField("pocet_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("nazev_zam", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("ickod_zam", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cisdoklad", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("prac_pracneprit", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
        }

    }

    public class TableDanInfo : TableDefInfo
    {
        const string TABLE_NAME = "DAN";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableDanInfo(lpszOwnerName, lpszUsersName);
        }
        public TableDanInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("odkud", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo", DB_BYTE, dbNotNullFieldOption);
            CreateField("hodnota", DB_LONG, dbNotNullFieldOption);
            CreateField("pocjed", DB_LONG, dbNotNullFieldOption);
            CreateField("pocdal", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            //CreateField("gross_obj", DB_BYTE, dbNotNullFieldOption, 1608);
            CreateField("informace", DB_INTEGER, dbNotNullFieldOption);
            CreateField("infoauto", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_stred", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_cinnost", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_zakazka", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_zdroj", DB_LONG, dbNotNullFieldOption);
            CreateField("relace_info", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sazba_mes", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_hod", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_ext", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("mesic");
            PKConstraint.AppendField("odkud");
            PKConstraint.AppendField("kod");
            PKConstraint.AppendField("cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1DAN");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("pracid_dan", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
        }

    }

    public class TableSrazkaInfo : TableDefInfo
    {
        const string TABLE_NAME = "SRAZKA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableSrazkaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableSrazkaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("odkud", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo", DB_BYTE, dbNotNullFieldOption);
            CreateField("hodnota", DB_LONG, dbNotNullFieldOption);
            CreateField("pocjed", DB_LONG, dbNotNullFieldOption);
            CreateField("pocdal", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba", DB_LONG, dbNotNullFieldOption);
            CreateField("minhod", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            //CreateField("gross_obj", DB_BYTE, dbNotNullFieldOption, 1608);
            CreateField("informace", DB_INTEGER, dbNotNullFieldOption);
            CreateField("infoauto", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_stred", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_cinnost", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_zakazka", DB_LONG, dbNotNullFieldOption);
            CreateField("zpusob", DB_BYTE, dbNotNullFieldOption);
            CreateField("posledni_rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("posledni_mesic", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
            CreateField("adresa_id", DB_LONG, dbNullFieldOption);
            CreateField("bspoj_id", DB_LONG, dbNullFieldOption);
            CreateField("org_id", DB_LONG, dbNullFieldOption);
            CreateField("cislo_zdroj", DB_LONG, dbNotNullFieldOption);
            CreateField("relace_info", DB_INTEGER, dbNotNullFieldOption);
            CreateField("exthod", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_mes", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_hod", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_ext", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("mesic");
            PKConstraint.AppendField("odkud");
            PKConstraint.AppendField("kod");
            PKConstraint.AppendField("cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1SRAZKA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex = CreateIndex("XIF2SRAZKA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("adresa_id");
            TableIndex = CreateIndex("XIF3SRAZKA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("bspoj_id");
            TableIndex = CreateIndex("XIF4SRAZKA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("org_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("pracid_sraz", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
        }

    }

    public class TablePpomerInfo : TableDefInfo
    {
        const string TABLE_NAME = "PPOMER";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePpomerInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("pompopis", "popis")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TablePpomerInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("ppomer_cislo", DB_TEXT, 12, dbNullFieldOption);
            CreateField("logicky_neuplny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("druh", DB_BYTE, dbNotNullFieldOption);
            CreateField("druh07", DB_BYTE, dbNotNullFieldOption);
            CreateField("zapoc_mesice", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zapoc_trvale", DB_INTEGER, dbNotNullFieldOption);
            CreateField("flg_dovolena", DB_INTEGER, dbNotNullFieldOption);
            CreateField("soc_zdr_dan", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cizi_pojist_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("proc_mm", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nastzac", DB_DATE, dbNullFieldOption);
            CreateField("nastzam", DB_DATE, dbNullFieldOption);
            CreateField("evidzac", DB_DATE, dbNullFieldOption);
            CreateField("praczac", DB_DATE, dbNotNullFieldOption);
            CreateField("pdovzac", DB_DATE, dbNullFieldOption);
            CreateField("nempzac", DB_DATE, dbNullFieldOption);
            CreateField("zdrpzac", DB_DATE, dbNullFieldOption);
            CreateField("prackon", DB_DATE, dbNullFieldOption);
            CreateField("pdovkon", DB_DATE, dbNullFieldOption);
            CreateField("pracvyp", DB_DATE, dbNullFieldOption);
            CreateField("icse", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("pompopis", DB_TEXT, 31, dbNotNullFieldOption);
            CreateFTEXT("kzam", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("isco_zam", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("funkce", DB_TEXT, 255, dbNullFieldOption);
            CreateField("platova_trtyp", DB_BYTE, dbNotNullFieldOption);
            CreateField("platova_trida", DB_INTEGER, dbNullFieldOption);
            CreateField("platovy_stupen", DB_BYTE, dbNotNullFieldOption);
            CreateField("stan_pdoba", DB_LONG, dbNotNullFieldOption);
            CreateField("praxe_roku", DB_BYTE, dbNotNullFieldOption, 0, 1600);
            CreateField("spraxe_roku", DB_INTEGER, dbNotNullFieldOption, 1600);
            CreateField("praxe_dnu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("narokdovol", DB_INTEGER, dbNotNullFieldOption);
            CreateField("narokzakld", DB_INTEGER, dbNotNullFieldOption);
            CreateField("narokdodat", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kracpocmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("proplpocmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vracpocmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vycerppocmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vycerpbudouc", DB_INTEGER, dbNotNullFieldOption);
            CreateField("l_kracpocmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("l_proplpocmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("l_vracpocmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("l_vycerppocmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nastup_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("pprac_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("tdoba_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("konec_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("kvalif_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("rizeni_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("ztizen_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("plzak_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("tarzv_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("prcin_kod", DB_INTEGER, dbNullFieldOption);
            CreateField("predpom", DB_INTEGER, dbNotNullFieldOption);
            CreateField("priorit", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zapoc_mucast", DB_INTEGER, dbNotNullFieldOption);
            CreateField("duchzac", DB_DATE, dbNullFieldOption);
            CreateField("vyj_evstav", DB_DATE, dbNullFieldOption);
            CreateField("rekvol_druh", DB_INTEGER, dbNotNullFieldOption, 1606);
            CreateField("rekvol_zac", DB_DATE, dbNullFieldOption, 1606);
            CreateField("rekvol_kon", DB_DATE, dbNullFieldOption, 1606);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PPOMER");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex = CreateIndex("XIF2PPOMER");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("nastup_kod");
            TableIndex = CreateIndex("XIF3PPOMER");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pprac_kod");
            TableIndex = CreateIndex("XIF4PPOMER");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("tdoba_kod");
            TableIndex = CreateIndex("XIF5PPOMER");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("konec_kod");
            TableIndex = CreateIndex("XIF6PPOMER");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("kvalif_kod");
            TableIndex = CreateIndex("XIF7PPOMER");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("plzak_kod");
            TableIndex = CreateIndex("XIF8PPOMER");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("tarzv_kod");
            TableIndex = CreateIndex("XIF9PPOMER");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("platova_trida");
            TableIndex = CreateIndex("XIF10PPOMER");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("prcin_kod");
            TableIndex = CreateIndex("XIF3VYBPPOMER");
            TableIndex.AppendField("praczac");
            TableIndex = CreateIndex("XIF4VYBPPOMER");
            TableIndex.AppendField("prackon");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("pracid_ppom", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
        }

    }

    public class TablePpomerDovInfo : TableDefInfo
    {
        const string TABLE_NAME = "PPOMER_DOV";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePpomerDovInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePpomerDovInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("letosni", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dletosni", DB_INTEGER, dbNotNullFieldOption);
            CreateField("jina", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kraceno", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kracnep", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nekrnep", DB_INTEGER, dbNotNullFieldOption);
            CreateField("lonska", DB_INTEGER, dbNotNullFieldOption);
            CreateField("predlon", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kracvmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("proplvmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vracevmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vycervmes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dkraceno", DB_INTEGER, dbNotNullFieldOption);
            CreateField("plat_praxe", DB_INTEGER, dbNotNullFieldOption);
            CreateField("plat_pstup", DB_BYTE, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");
            PKConstraint.AppendField("mesic");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PPOMER_DOV");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex.AppendField("cislo_pp");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("ppomid_pdov", "PPOMER", "ppomer_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("cislo_pp", "cislo_pp");
        }

    }

    public class TablePpomerDovRokInfo : TableDefInfo
    {
        const string TABLE_NAME = "PPOMER_DOV_ROK";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePpomerDovRokInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePpomerDovRokInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("flg_dovolena", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pdovzac", DB_DATE, dbNullFieldOption);
            CreateField("pdovkon", DB_DATE, dbNullFieldOption);
            CreateField("uzavreno", DB_BYTE, dbNotNullFieldOption);
            CreateField("jenodpr", DB_BYTE, dbNotNullFieldOption);
            CreateField("dvanact", DB_BYTE, dbNotNullFieldOption);
            CreateField("uvsmrok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("letosni", DB_INTEGER, dbNotNullFieldOption);
            CreateField("letuvaz", DB_INTEGER, dbNotNullFieldOption);
            CreateField("letzakl", DB_INTEGER, dbNotNullFieldOption);
            CreateField("dletuvaz", DB_INTEGER, dbNotNullFieldOption);
            CreateField("lonska", DB_INTEGER, dbNotNullFieldOption);
            CreateField("jina", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kraceno", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kracnep", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nekrnep", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kraczuctov", DB_INTEGER, dbNotNullFieldOption);
            CreateField("proplzuctov", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vraczuctov", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vycerpzuctov", DB_INTEGER, dbNotNullFieldOption);
            CreateField("l_proplzuctov", DB_INTEGER, dbNotNullFieldOption);
            CreateField("l_vraczuctov", DB_INTEGER, dbNotNullFieldOption);
            CreateField("l_vycerpzuctov", DB_INTEGER, dbNotNullFieldOption);
            CreateField("l_kraczuctov", DB_INTEGER, dbNotNullFieldOption);
            CreateField("l_lonspreved", DB_INTEGER, dbNotNullFieldOption);
            CreateField("l_lonsuznana", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pdodzac", DB_DATE, dbNullFieldOption);
            CreateField("pdodkon", DB_DATE, dbNullFieldOption);
            CreateField("ddvanact", DB_BYTE, dbNotNullFieldOption);
            CreateField("dkraceno", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");
            PKConstraint.AppendField("rok");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PPOMER_DOV_ROK");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex.AppendField("cislo_pp");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("ppomer_ref_dov_rok", "PPOMER", "ppomer_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("cislo_pp", "cislo_pp");
        }

    }

    public class TablePpomerMesInfo : TableDefInfo
    {
        const string TABLE_NAME = "PPOMER_MES";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePpomerMesInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePpomerMesInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zapv_rozhoddny", DB_BYTE, dbNotNullFieldOption);
            CreateField("zapv_rozsobned", DB_BYTE, dbNotNullFieldOption);
            CreateField("zapv_vydelek", DB_LONG, dbNotNullFieldOption);
            CreateField("prum_mesicdny", DB_BYTE, dbNotNullFieldOption);
            CreateField("prum_rozhoddny", DB_BYTE, dbNotNullFieldOption);
            CreateField("prum_odpracdny", DB_BYTE, dbNotNullFieldOption);
            CreateField("prum_uvazekhod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("prum_hrezimhod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("prum_rozhodhod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("prum_vydelek", DB_LONG, dbNotNullFieldOption);
            CreateField("prum_sumames", DB_LONG, dbNotNullFieldOption);
            CreateField("prum_sumafix", DB_LONG, dbNotNullFieldOption);
            CreateField("prum_sazbfix", DB_LONG, dbNotNullFieldOption);
            CreateField("prum_plusq1", DB_LONG, dbNotNullFieldOption);
            CreateField("prum_plusq2", DB_LONG, dbNotNullFieldOption);
            CreateField("prum_plusq3", DB_LONG, dbNotNullFieldOption);
            CreateField("prum_plusq4", DB_LONG, dbNotNullFieldOption);
            CreateField("rodd_zapocvydl", DB_LONG, dbNotNullFieldOption);
            CreateField("rodd_zapocvydw", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rodd_posledden", DB_BYTE, dbNotNullFieldOption);
            CreateField("prum_uvazekdny", DB_BYTE, dbNotNullFieldOption);
            CreateField("spoj_sumavzakl", DB_LONG, dbNotNullFieldOption);
            CreateField("dpoj_sumavzakl", DB_LONG, dbNotNullFieldOption);
            CreateField("zpoj_sumavzakl", DB_LONG, dbNotNullFieldOption);
            CreateField("ppoj_sumavzakl", DB_LONG, dbNotNullFieldOption);
            CreateField("spoj_odvodzakl", DB_LONG, dbNotNullFieldOption);
            CreateField("dpoj_odvodzakl", DB_LONG, dbNotNullFieldOption);
            CreateField("zpoj_odvodzakl", DB_LONG, dbNotNullFieldOption);
            CreateField("ppoj_odvodzakl", DB_LONG, dbNotNullFieldOption);
            CreateField("spoj_sumasuper", DB_LONG, dbNotNullFieldOption);
            CreateField("dpoj_sumasuper", DB_LONG, dbNotNullFieldOption);
            CreateField("zpoj_sumasuper", DB_LONG, dbNotNullFieldOption);
            CreateField("prum_rozhodzac", DB_BYTE, dbNotNullFieldOption);
            CreateField("prum_hrubypr", DB_LONG, dbNotNullFieldOption);
            CreateField("prum_cistypr", DB_LONG, dbNotNullFieldOption);
            CreateField("zapv_koopmes", DB_LONG, dbNotNullFieldOption);
            CreateField("sluz_rodmeny", DB_LONG, dbNotNullFieldOption, 1506);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");
            PKConstraint.AppendField("mesic");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PPOMER_MES");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex.AppendField("cislo_pp");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("ppomid_pmes", "PPOMER", "ppomer_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("cislo_pp", "cislo_pp");
        }

    }

    public class TablePpomerSumInfo : TableDefInfo
    {
        const string TABLE_NAME = "PPOMER_SUM";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePpomerSumInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePpomerSumInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rokh_odpracov", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rokh_prescasp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rokh_prescasc", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rokh_pohotnap", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rokh_pohmimop", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rokh_neprplat", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rokd_davkynem", DB_BYTE, dbNotNullFieldOption);
            CreateField("rokd_kratitnh", DB_BYTE, dbNotNullFieldOption);
            CreateField("rokd_lhutaoch", DB_BYTE, dbNotNullFieldOption);
            CreateField("rokd_vyloucene", DB_BYTE, dbNotNullFieldOption);
            CreateField("rokd_odpracdov", DB_BYTE, dbNotNullFieldOption);
            CreateField("rokd_kratitdov", DB_BYTE, dbNotNullFieldOption);
            CreateField("rokd_nekratdov", DB_BYTE, dbNotNullFieldOption);
            CreateField("rokd_odpracdal", DB_BYTE, dbNotNullFieldOption);
            CreateField("rokd_odprstrav", DB_BYTE, dbNotNullFieldOption);
            CreateField("konh_odpracov", DB_INTEGER, dbNotNullFieldOption);
            CreateField("konh_prescasc", DB_INTEGER, dbNotNullFieldOption);
            CreateField("konh_odpracnh", DB_INTEGER, dbNotNullFieldOption);
            CreateField("konh_prescsnh", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mzvd_kratitnh", DB_LONG, dbNotNullFieldOption);
            CreateField("mzvp_kratitnh", DB_LONG, dbNotNullFieldOption);
            CreateField("rokd_uvazhtyd", DB_LONG, dbNotNullFieldOption);
            CreateField("rokd_uvazhmes", DB_LONG, dbNotNullFieldOption);
            CreateField("rokd_uvazdmes", DB_LONG, dbNotNullFieldOption);
            CreateField("rokd_cerphmes", DB_LONG, dbNotNullFieldOption);
            CreateField("rokd_cerpdmes", DB_LONG, dbNotNullFieldOption);
            CreateField("rokd_cerpprum", DB_LONG, dbNotNullFieldOption, 1608);
            CreateField("rokd_pocitmes", DB_BYTE, dbNotNullFieldOption, 1606);
            CreateField("rokd_omluvmes", DB_BYTE, dbNotNullFieldOption, 1606);
            CreateField("rokd_narokmes", DB_BYTE, dbNotNullFieldOption, 1606);
            CreateField("rokd_vycermes", DB_BYTE, dbNotNullFieldOption, 1606);
            CreateField("rokd_zbyv1mes", DB_INTEGER, dbNotNullFieldOption, 1606);
            CreateField("rokd_zbyv2mes", DB_INTEGER, dbNotNullFieldOption, 1606);
            CreateField("rokd_zbyv3mes", DB_INTEGER, dbNotNullFieldOption, 1606);
            CreateField("rokd_zbyv4mes", DB_INTEGER, dbNotNullFieldOption, 1606);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");
            PKConstraint.AppendField("mesic");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PPOMER_SUM");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex.AppendField("cislo_pp");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("ppomid_psum", "PPOMER", "ppomer_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("cislo_pp", "cislo_pp");
        }

    }

    public class TablePpomerOzpInfo : TableDefInfo
    {
        const string TABLE_NAME = "PPOMER_OZP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePpomerOzpInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePpomerOzpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("stan_pdoba", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("fpracdhod_fpd", DB_LONG, dbNotNullFieldOption);
            CreateField("pocetprac_fpd", DB_LONG, dbNotNullFieldOption);
            CreateField("odprachod_ph", DB_LONG, dbNotNullFieldOption);
            CreateField("neodovhod_ph", DB_LONG, dbNotNullFieldOption);
            CreateField("neoprehod_ph", DB_LONG, dbNotNullFieldOption);
            CreateField("neonemhod_ph", DB_LONG, dbNotNullFieldOption);
            CreateField("odpraczps_ph", DB_LONG, dbNotNullFieldOption);
            CreateField("neodovzps_ph", DB_LONG, dbNotNullFieldOption);
            CreateField("neoprezps_ph", DB_LONG, dbNotNullFieldOption);
            CreateField("neonemzps_ph", DB_LONG, dbNotNullFieldOption);
            CreateField("odpracztp_ph", DB_LONG, dbNotNullFieldOption);
            CreateField("neodovztp_ph", DB_LONG, dbNotNullFieldOption);
            CreateField("neopreztp_ph", DB_LONG, dbNotNullFieldOption);
            CreateField("neonemztp_ph", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");
            PKConstraint.AppendField("mesic");
            PKConstraint.AppendField("stan_pdoba");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PPOMER_OZP");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex.AppendField("cislo_pp");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("ppomid_pozp", "PPOMER", "ppomer_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("cislo_pp", "cislo_pp");
        }

    }

    public class TablePpomerPraxeInfo : TableDefInfo
    {
        const string TABLE_NAME = "PPOMER_PRAXE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePpomerPraxeInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePpomerPraxeInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("zamestnavatel", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("pozice", DB_TEXT, 80, dbNullFieldOption);
            CreateFTEXT("kzam", DB_TEXT, 20, dbNullFieldOption);
            CreateField("praxe_zac", DB_DATE, dbNotNullFieldOption);
            CreateField("praxe_kon", DB_DATE, dbNotNullFieldOption);
            CreateField("vzdel_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kraceni_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("delka_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("kratit_vzdel", DB_BYTE, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");
            PKConstraint.AppendField("cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PPOMER_PRAXE");
            TableIndex.AppendField("vzdel_kod");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2PPOMER_PRAXE");
            TableIndex.AppendField("kraceni_kod");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("praxe_ppomer", "PPOMER", "ppomer_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("cislo_pp", "cislo_pp");
			TableRelation = CreateRelation("praxe_vzdel", "UZIV_CISELNIK", "vzdel_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("vzdel_kod", "uzc_kod");
			TableRelation = CreateRelation("praxe_kraceni", "UZIV_CISELNIK", "kraceni_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("kraceni_kod", "uzc_kod");
        }

    }

    public class TablePpomerSluzbaInfo : TableDefInfo
    {
        const string TABLE_NAME = "PPOMER_SLUZBA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePpomerSluzbaInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePpomerSluzbaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sluzba_id", DB_LONG, dbNotNullFieldOption, 0, 1606);
            CreateField("sluzba_id", DB_LONG, dbNullFieldOption, 1608);
            CreateField("info_sluzba", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("identit_pp", DB_TEXT, 255, dbNullFieldOption);
            CreateField("pozice_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("ppomer_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zacat", DB_DATE, dbNullFieldOption);
            CreateField("konec", DB_DATE, dbNullFieldOption);
            CreateField("praxe_roku", DB_LONG, dbNotNullFieldOption);
            CreateField("uvazek_koef", DB_LONG, dbNotNullFieldOption);
            CreateField("odprac_hodin", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");
            PKConstraint.AppendField("cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PPOMER_SLUZBA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex.AppendField("cislo_pp");
            TableIndex = CreateIndex("XIF2PPOMER_SLUZBA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("sluzba_id");
            TableIndex = CreateIndex("XIF3PPOMER_SLUZBA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pozice_kod");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("ppsluzba_uzcsluzba", "STRED_CINZAK", "sluzba_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("sluzba_id", "strcinzak_id");
			TableRelation = CreateRelation("ppom_ppsluzba", "PPOMER", "ppomer_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("cislo_pp", "cislo_pp");
			TableRelation = CreateRelation("ppsluzba_uzcpozice", "UZIV_CISELNIK", "pozice_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pozice_kod", "uzc_kod");
        }

    }

    public class TablePracVzdelavaniInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRAC_VZDELAVANI";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePracVzdelavaniInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePracVzdelavaniInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sluzba_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pozice_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vzdelani_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pocet_hod", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PRAC_VZDELAVANI");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex = CreateIndex("XIF2PRAC_VZDELAVANI");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("sluzba_id");
            TableIndex = CreateIndex("XIF3PRAC_VZDELAVANI");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pozice_kod");
            TableIndex = CreateIndex("XIF4PRAC_VZDELAVANI");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("vzdelani_kod");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("pvzdel_uzcsluzba", "STRED_CINZAK", "sluzba_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("sluzba_id", "strcinzak_id");
			TableRelation = CreateRelation("prac_pvzdelavani", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
			TableRelation = CreateRelation("pvzdel_uzcpozice", "UZIV_CISELNIK", "pozice_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pozice_kod", "uzc_kod");
			TableRelation = CreateRelation("pvzdel_uzcvzdel", "UZIV_CISELNIK", "vzdelani_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("vzdelani_kod", "uzc_kod");
        }

    }

    public class TablePrijmySspInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRIJMY_SSP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePrijmySspInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePrijmySspInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("ctvrtleti", DB_BYTE, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vzspoj", DB_LONG, dbNotNullFieldOption);
            CreateField("prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("dnp", DB_LONG, dbNotNullFieldOption);
            CreateField("nahrzp", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("mesic");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("prac_prijmyssp", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
        }

    }

    public class TablePrijmyInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRIJMY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePrijmyInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePrijmyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_platce", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("platce", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("dic_platce", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("dic_drezid", DB_TEXT, 20, dbNullFieldOption);
            CreateField("stat_rezident", DB_INTEGER, dbNotNullFieldOption);
            CreateField("rezidadr_id", DB_LONG, dbNullFieldOption);
            CreateField("obdobi", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("zah_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("zaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("duchod", DB_LONG, dbNotNullFieldOption);
            CreateField("dar", DB_LONG, dbNotNullFieldOption);
            CreateField("dar_povod", DB_LONG, dbNotNullFieldOption);
            CreateField("odbory", DB_LONG, dbNotNullFieldOption);
            CreateField("hypodpoc", DB_LONG, dbNotNullFieldOption);
            CreateField("penzpoj", DB_LONG, dbNotNullFieldOption);
            CreateField("penzppr", DB_LONG, dbNotNullFieldOption);
            CreateField("penzosv", DB_LONG, dbNotNullFieldOption);
            CreateField("kzivpoj", DB_LONG, dbNotNullFieldOption);
            CreateField("kzivppr", DB_LONG, dbNotNullFieldOption);
            CreateField("kzivosv", DB_LONG, dbNotNullFieldOption);
            CreateField("popl_sleva", DB_LONG, dbNotNullFieldOption);
            CreateField("popl_bonus", DB_LONG, dbNotNullFieldOption);
            CreateField("deti_sleva", DB_LONG, dbNotNullFieldOption);
            CreateField("deti_bonus", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_zuctovat", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("den_zuctovani", DB_BYTE, dbNotNullFieldOption);
            CreateField("mesic_zuctovani", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hypoteka", DB_LONG, dbNotNullFieldOption);
            CreateField("pocmeshyp", DB_BYTE, dbNotNullFieldOption);
            CreateField("pocucasthyp", DB_BYTE, dbNotNullFieldOption);
            CreateField("nez_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("nez_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("sraz_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("sraz_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("srazka", DB_LONG, dbNotNullFieldOption);
            CreateField("zkousky", DB_LONG, dbNotNullFieldOption);
            CreateField("osobaozp", DB_BYTE, dbNotNullFieldOption);
            CreateField("sraz_zuctovat", DB_BOOLEAN, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("rok");
            PKConstraint.AppendField("cislo_platce");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PRIJMY");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex = CreateIndex("XIF2PRIJMY");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("stat_rezident");
            TableIndex = CreateIndex("XIF3PRIJMY");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("rezidadr_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("pracid_prij", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
			TableRelation = CreateRelation("rezid_stat", "UZIV_CISELNIK", "stat_rezident_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("stat_rezident", "uzc_kod");
        }

    }

    public class TablePrijmy1500Info : TableDefInfo
    {
        const string TABLE_NAME = "PRIJMY_1500";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePrijmy1500Info(lpszOwnerName, lpszUsersName);
        }
        public TablePrijmy1500Info(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1602)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_platce", DB_BYTE, dbNotNullFieldOption);
            CreateField("obdobi", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("zah_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("zaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("duchod", DB_LONG, dbNotNullFieldOption);
            CreateField("dar", DB_LONG, dbNotNullFieldOption);
            CreateField("dar_povod", DB_LONG, dbNotNullFieldOption);
            CreateField("odbory", DB_LONG, dbNotNullFieldOption);
            CreateField("hypodpoc", DB_LONG, dbNotNullFieldOption);
            CreateField("penzpoj", DB_LONG, dbNotNullFieldOption);
            CreateField("penzppr", DB_LONG, dbNotNullFieldOption);
            CreateField("penzosv", DB_LONG, dbNotNullFieldOption);
            CreateField("kzivpoj", DB_LONG, dbNotNullFieldOption);
            CreateField("kzivppr", DB_LONG, dbNotNullFieldOption);
            CreateField("kzivosv", DB_LONG, dbNotNullFieldOption);
            CreateField("popl_sleva", DB_LONG, dbNotNullFieldOption);
            CreateField("popl_bonus", DB_LONG, dbNotNullFieldOption);
            CreateField("deti_sleva", DB_LONG, dbNotNullFieldOption);
            CreateField("deti_bonus", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_zuctovat", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("den_zuctovani", DB_BYTE, dbNotNullFieldOption);
            CreateField("mesic_zuctovani", DB_INTEGER, dbNotNullFieldOption);
            CreateField("hypoteka", DB_LONG, dbNotNullFieldOption);
            CreateField("pocmeshyp", DB_BYTE, dbNotNullFieldOption);
            CreateField("pocucasthyp", DB_BYTE, dbNotNullFieldOption);
            CreateField("nez_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("nez_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("sraz_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("sraz_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("srazka", DB_LONG, dbNotNullFieldOption);
            CreateField("zkousky", DB_LONG, dbNotNullFieldOption);
            CreateField("osobaozp", DB_BYTE, dbNotNullFieldOption);
            CreateField("sraz_zuctovat", DB_BOOLEAN, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("rok");
            PKConstraint.AppendField("cislo_platce");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PRIJMY_1500");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
        }

    }

    public class TableProhlaseniInfo : TableDefInfo
    {
        const string TABLE_NAME = "PROHLASENI";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableProhlaseniInfo(lpszOwnerName, lpszUsersName);
        }
        public TableProhlaseniInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo", DB_BYTE, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_platce", DB_BYTE, dbNotNullFieldOption);
            CreateField("obdobi", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_prisl", DB_INTEGER, dbNullFieldOption);
            CreateField("obdobi_cis", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("kod");
            PKConstraint.AppendField("cislo");
            PKConstraint.AppendField("rok");
            PKConstraint.AppendField("cislo_platce");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PROHLASENI");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex.AppendField("rok");
            TableIndex.AppendField("cislo_platce");
            TableIndex = CreateIndex("XIF2PROHLASENI");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("cislo_prisl");
            TableIndex.AppendField("pracovnik_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("prij_prohl", "PRIJMY", "prijmy_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("rok", "rok");
            TableRelation.AppendForeignField("cislo_platce", "cislo_platce");
        }

    }

    public class TableRodinaInfo : TableDefInfo
    {
        const string TABLE_NAME = "RODINA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableRodinaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableRodinaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_prisl", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pomer", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("rodcislo_ico", DB_TEXT, 10, dbNullFieldOption);
            CreateField("nema_rodcis", DB_BYTE, dbNotNullFieldOption);
            CreateField("pohlavi", DB_BYTE, dbNotNullFieldOption);
            CreateField("datum_narozeni", DB_DATE, dbNullFieldOption);
            CreateFTEXT("prijmeni_nazev", DB_TEXT, 35, dbNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 30, dbNullFieldOption);
            CreateFTEXT("titul_pred", DB_TEXT, 35, dbNullFieldOption);
            CreateFTEXT("titul_za", DB_TEXT, 10, dbNullFieldOption);
            CreateField("sniz_urok", DB_LONG, dbNotNullFieldOption);
            CreateField("sniz_danrok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sniz_danmes", DB_BYTE, dbNotNullFieldOption);
            CreateField("sniz_negmaska", DB_LONG, dbNotNullFieldOption);
            CreateField("sniz_danrok_ztp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sniz_danmes_ztp", DB_BYTE, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_prisl");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1RODINA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("pracid_rod", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
        }

    }

    public class TablePrijmyMesInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRIJMY_MES";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePrijmyMesInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePrijmyMesInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_platce", DB_BYTE, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("nez_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("nez_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("zal_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("zah_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("zaloha", DB_LONG, dbNotNullFieldOption);
            CreateField("sraz_prijem", DB_LONG, dbNotNullFieldOption);
            CreateField("sraz_pojistne", DB_LONG, dbNotNullFieldOption);
            CreateField("srazka", DB_LONG, dbNotNullFieldOption);
            CreateField("popl_sleva", DB_LONG, dbNotNullFieldOption);
            CreateField("popl_bonus", DB_LONG, dbNotNullFieldOption);
            CreateField("deti_sleva", DB_LONG, dbNotNullFieldOption);
            CreateField("deti_bonus", DB_LONG, dbNotNullFieldOption);
            CreateField("penzppr", DB_LONG, dbNotNullFieldOption);
            CreateField("penzosv", DB_LONG, dbNotNullFieldOption);
            CreateField("kzivppr", DB_LONG, dbNotNullFieldOption);
            CreateField("kzivosv", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("mesic");
            PKConstraint.AppendField("cislo_platce");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("prac_prijmymes", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
        }

    }

    public class TableMzdaInfo : TableDefInfo
    {
        const string TABLE_NAME = "MZDA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableMzdaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableMzdaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("odkud", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo", DB_BYTE, dbNotNullFieldOption);
            CreateField("hodnota", DB_LONG, dbNotNullFieldOption);
            CreateField("pocjed", DB_LONG, dbNotNullFieldOption);
            CreateField("pocdal", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            //CreateField("gross_obj", DB_BYTE, dbNotNullFieldOption, 1608);
            CreateField("informace", DB_INTEGER, dbNotNullFieldOption);
            CreateField("infoauto", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_stred", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_cinnost", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_zakazka", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_zdroj", DB_LONG, dbNotNullFieldOption);
            CreateField("relace_info", DB_INTEGER, dbNotNullFieldOption);
            CreateField("sazba_mes", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_hod", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_ext", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");
            PKConstraint.AppendField("mesic");
            PKConstraint.AppendField("odkud");
            PKConstraint.AppendField("kod");
            PKConstraint.AppendField("cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1MZDA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex.AppendField("cislo_pp");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("ppomid_mzda", "PPOMER", "ppomer_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("cislo_pp", "cislo_pp");
        }

    }

    public class TableNepritInfo : TableDefInfo
    {
        const string TABLE_NAME = "NEPRIT";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableNepritInfo(lpszOwnerName, lpszUsersName);
        }
        public TableNepritInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("odkud", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo", DB_BYTE, dbNotNullFieldOption);
            CreateField("hodnota", DB_LONG, dbNotNullFieldOption);
            CreateField("pocjed", DB_LONG, dbNotNullFieldOption);
            CreateField("pocdal", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_obj", DB_INTEGER, dbNotNullFieldOption);
            //CreateField("gross_obj", DB_BYTE, dbNotNullFieldOption, 1608);
            CreateField("informace", DB_INTEGER, dbNotNullFieldOption);
            CreateField("infoauto", DB_INTEGER, dbNotNullFieldOption);
            CreateField("infstatis", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_stred", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_cinnost", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_zakazka", DB_LONG, dbNotNullFieldOption);
            CreateField("zacatek", DB_DATE, dbNotNullFieldOption);
            CreateField("minzac", DB_INTEGER, dbNotNullFieldOption);
            CreateField("konec", DB_DATE, dbNotNullFieldOption);
            CreateField("minkon", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zapvyd", DB_LONG, dbNotNullFieldOption);
            CreateField("zapdes", DB_INTEGER, dbNotNullFieldOption);
            CreateField("doklad_cislo", DB_LONG, dbNotNullFieldOption);
            CreateField("kratit", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_zdroj", DB_LONG, dbNotNullFieldOption);
            CreateField("relace_info", DB_INTEGER, dbNotNullFieldOption);
            CreateField("doklad_mater", DB_LONG, dbNotNullFieldOption);
            CreateField("doklad_pravd", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_mes", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_hod", DB_LONG, dbNotNullFieldOption);
            CreateField("sazba_ext", DB_LONG, dbNotNullFieldOption);
            CreateField("proc_kratit", DB_INTEGER, dbNotNullFieldOption);
            CreateField("prac_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("predkal_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("predprac_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("doklad_list", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");
            PKConstraint.AppendField("mesic");
            PKConstraint.AppendField("odkud");
            PKConstraint.AppendField("kod");
            PKConstraint.AppendField("cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1NEPRIT");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex.AppendField("cislo_pp");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("ppomid_nepr", "PPOMER", "ppomer_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("cislo_pp", "cislo_pp");
        }

    }

    public class TableUvazekInfo : TableDefInfo
    {
        const string TABLE_NAME = "UVAZEK";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableUvazekInfo(lpszOwnerName, lpszUsersName);
        }
        public TableUvazekInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("delkatur", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("minsmena", DB_TEXT, 56, dbNotNullFieldOption);
            CreateField("minpronepr", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zactur", DB_BYTE, dbNotNullFieldOption);
            CreateField("delkames", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("minden", DB_TEXT, 62, dbNotNullFieldOption);
            CreateField("odkud", DB_BYTE, dbNotNullFieldOption);
            CreateField("kod", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");
            PKConstraint.AppendField("mesic");
            PKConstraint.AppendField("odkud");
            PKConstraint.AppendField("kod");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1UVAZEK");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");
            TableIndex.AppendField("cislo_pp");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("ppomid_uvaz", "PPOMER", "ppomer_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("cislo_pp", "cislo_pp");
        }

    }

    public class TableUzivDataPpomerInfo : TableDefInfo
    {
        const string TABLE_NAME = "UZIV_DATA_PPOMER";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableUzivDataPpomerInfo(lpszOwnerName, lpszUsersName);
        }
        public TableUzivDataPpomerInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poradi", DB_BYTE, dbNotNullFieldOption);
            CreateField("hodnota", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");
            PKConstraint.AppendField("mesic");
            PKConstraint.AppendField("poradi");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF2UZIV_DATA_PPOMER");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("prac_uziv_data_ppomer", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
        }

    }

    public class TableUzivReldpDavkaInfo : TableDefInfo
    {
        const string TABLE_NAME = "UZIV_RELDP_DAVKA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableUzivReldpDavkaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableUzivReldpDavkaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("ddavka_reldp_id", DB_LONG);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("vydano_dat", DB_DATE, dbNullFieldOption);
            CreateField("neprijata", DB_BYTE, dbNotNullFieldOption);
            CreateField("info_davka", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("ddavka_reldp_id");
            PKConstraint.AppendField("uzivatel_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1UZIV_RELDP_DAVKA");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("uzivatel_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("uziv_ref_reldp_davka", "UZIVATEL", "uzivatel_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("uzivatel_id", "uuzivatel_id");
        }

    }

    public class TablePracReldpDataInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRAC_RELDP_DATA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePracReldpDataInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePracReldpDataInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("listek_reldp_id", DB_LONG, dbNotNullFieldOption);
            CreateField("eldppgn", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pomer_id", DB_INTEGER, dbNotNullFieldOption);
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

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("listek_reldp_id");
            PKConstraint.AppendField("eldppgn");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("prac_reldp_listek_data", "PRAC_RELDP_LISTEK", "listek_reldp_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("listek_reldp_id", "llistek_reldp_id");
            TableRelation.AppendForeignField("eldppgn", "eldppgn");
        }

    }

    public class TablePracReldpListekInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRAC_RELDP_LISTEK";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePracReldpListekInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePracReldpListekInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("llistek_reldp_id", DB_LONG);
            CreateField("eldppgn", DB_INTEGER, dbNotNullFieldOption);
            CreateField("davka_reldp_id", DB_LONG, dbNotNullFieldOption);
            CreateField("logicky_zrusen", DB_BYTE, dbNotNullFieldOption);
            CreateField("eldprok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("datum_narozeni", DB_DATE, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 12, dbNotNullFieldOption);
            CreateFTEXT("rodne_prijmeni", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("uplne_jmeno", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("misto_narozeni", DB_TEXT, 70, dbNullFieldOption);
            CreateFTEXT("posledni_prijmeni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("adresa1_3", DB_TEXT, 255, dbNullFieldOption);
            CreateField("eldptyp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("zacatek", DB_DATE, dbNullFieldOption);
            CreateField("eldpvydzedne", DB_DATE, dbNotNullFieldOption);
            CreateField("eldpoprzedne", DB_DATE, dbNullFieldOption);
            CreateField("info_eldp", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("llistek_reldp_id");
            PKConstraint.AppendField("eldppgn");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF3PRAC_RELDP_LISTEK");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_reldp_id");
            TableIndex.AppendField("uzivatel_id");
            TableIndex = CreateIndex("XIF4PRAC_RELDP_LISTEK");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("uziv_reldp_davka_listek", "UZIV_RELDP_DAVKA", "davka_reldp_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("davka_reldp_id", "ddavka_reldp_id");
            TableRelation.AppendForeignField("uzivatel_id", "uzivatel_id");
        }

    }

    public class TablePracReldp09DataPracInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRAC_RELDP09_DATA_PRAC";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePracReldp09DataPracInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePracReldp09DataPracInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_reldp_id", DB_LONG, dbNotNullFieldOption);
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

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("uzivatel_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("davka_reldp_id");
            PKConstraint.AppendField("sprava_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PRAC_RELDP09_DATA_PRAC");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_reldp_id");
            TableIndex.AppendField("uzivatel_id");
            TableIndex = CreateIndex("XIF2PRAC_RELDP09_DATA_PRAC");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("pracovnik_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("prac_ma_reldp_prac", "PRAC", "pracovnik_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("pracovnik_id", "ppracovnik_id");
			TableRelation = CreateRelation("uziv_reldp_prac", "UZIV_RELDP_DAVKA", "uziv_data_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("davka_reldp_id", "ddavka_reldp_id");
            TableRelation.AppendForeignField("uzivatel_id", "uzivatel_id");
        }

    }

    public class TablePracReldp09DataPojInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRAC_RELDP09_DATA_POJ";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePracReldp09DataPojInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePracReldp09DataPojInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pomer_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_reldp_id", DB_LONG, dbNotNullFieldOption);
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

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("uzivatel_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("davka_reldp_id");
            PKConstraint.AppendField("sprava_id");
            PKConstraint.AppendField("pomer_id");
            PKConstraint.AppendField("stranka");
            PKConstraint.AppendField("radek");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PRAC_RELDP09_DATA_POJ");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("uzivatel_id");
            TableIndex.AppendField("pracovnik_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("prac_reldp_prac_poj", "PRAC_RELDP09_DATA_PRAC", "data_prac_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("uzivatel_id", "uzivatel_id");
            TableRelation.AppendForeignField("pracovnik_id", "pracovnik_id");
            TableRelation.AppendForeignField("davka_reldp_id", "davka_reldp_id");
            TableRelation.AppendForeignField("sprava_id", "sprava_id");
        }

    }

    public class TablePracVyberAggrInfo : TableDefInfo
    {
        const string TABLE_NAME = "PRAC_VYBER_AGGR";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePracVyberAggrInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePracVyberAggrInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, "PRAC_VYBER_AGGR", 1600)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("pracovnik_id", DB_LONG, dbNotNullFieldOption);
            CreateField("logicky_zrusen", DB_BYTE, dbNotNullFieldOption);
            CreateField("logicky_neuplny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pocitane_obdobi", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("osobni_cislo", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 255, dbNullFieldOption);
            CreateField("nema_rodcis", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("titul_pred", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("titul_za", DB_TEXT, 255, dbNullFieldOption);
            CreateField("datum_narozeni", DB_DATE, dbNullFieldOption);
            CreateField("pohlavi", DB_BYTE, dbNotNullFieldOption);
            CreateField("cislo_pp", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("pompopis", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("funkce", DB_TEXT, 255, dbNullFieldOption);
            CreateField("praczac", DB_DATE, dbNullFieldOption);
            CreateField("prackon", DB_DATE, dbNullFieldOption);
            CreateField("druh", DB_BYTE, dbNotNullFieldOption);
            CreateField("druh07", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("ppomer_cislo", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("kzam", DB_TEXT, 255, dbNullFieldOption);
            CreateField("platova_trida", DB_INTEGER, dbNotNullFieldOption);
            CreateField("platovy_stupen", DB_BYTE, dbNotNullFieldOption);
            CreateField("spraxe_roku", DB_INTEGER, dbNotNullFieldOption);
            CreateField("praxe_dnu", DB_INTEGER, dbNotNullFieldOption);
            CreateField("uutvar_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uupres_id", DB_LONG, dbNotNullFieldOption);
            CreateField("vyuct_cast", DB_INTEGER, dbNotNullFieldOption);
            CreateField("cislo_zdrpoj", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_utvar", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_zdroj", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_stred", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_cinnost", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo_zakazka", DB_LONG, dbNotNullFieldOption);
            CreateField("ppomer_zdroj", DB_LONG, dbNotNullFieldOption);
            CreateField("ppomer_stred", DB_LONG, dbNotNullFieldOption);
            CreateField("ppomer_cinnost", DB_LONG, dbNotNullFieldOption);
            CreateField("ppomer_zakazka", DB_LONG, dbNotNullFieldOption);
            CreateField("zar_mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("opr_mesic", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pracovnik_id");
            PKConstraint.AppendField("cislo_pp");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF0PRAC_VYBER_AGGR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("cislo_utvar");

            TableIndex = CreateIndex("XIF1PRAC_VYBER_AGGR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("cislo_zdroj");

            TableIndex = CreateIndex("XIF2PRAC_VYBER_AGGR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("cislo_stred");

            TableIndex = CreateIndex("XIF3PRAC_VYBER_AGGR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("cislo_cinnost");

            TableIndex = CreateIndex("XIF4PRAC_VYBER_AGGR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("cislo_zakazka");

            TableIndex = CreateIndex("XIF5PRAC_VYBER_AGGR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ppomer_zdroj");

            TableIndex = CreateIndex("XIF6PRAC_VYBER_AGGR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ppomer_stred");

            TableIndex = CreateIndex("XIF7PRAC_VYBER_AGGR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ppomer_cinnost");

            TableIndex = CreateIndex("XIF8PRAC_VYBER_AGGR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ppomer_zakazka");

            TableIndex = CreateIndex("XIF9PRAC_VYBER_AGGR");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("cislo_zdrpoj");

            TableIndex = CreateIndex("XIFXPRAC_VYBER_AGGR");
            TableIndex.AppendField("prijmeni");

            TableIndex = CreateIndex("XIF01PRAC_VYBER_AGGR");
            TableIndex.AppendField("rodne_cislo");

            TableIndex = CreateIndex("XIF02PRAC_VYBER_AGGR");
            TableIndex.AppendField("osobni_cislo");

            TableIndex = CreateIndex("XIF03PRAC_VYBER_AGGR");
            TableIndex.AppendField("praczac");

            TableIndex = CreateIndex("XIF04PRAC_VYBER_AGGR");
            TableIndex.AppendField("prackon");

        }

    }
}
