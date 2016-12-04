using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    public class TablePlatbyKonfigInfo : TableDefInfo
    {
        const string TABLE_NAME = "PLATBY_KONFIG";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePlatbyKonfigInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePlatbyKonfigInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("platba_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("platba_zpusob", DB_BYTE, dbNotNullFieldOption);
            CreateField("platba_priorita", DB_INTEGER, dbNotNullFieldOption);
            CreateField("splat_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("adresa_id", DB_LONG, dbNullFieldOption);
            CreateField("bspoj_id", DB_LONG, dbNullFieldOption);
            CreateField("org_id", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_str", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_zak", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_cin", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_zdr", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("platba_kod");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PLATBY_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2PLATBY_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("adresa_id");
            TableIndex = CreateIndex("XIF3PLATBY_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("bspoj_id");
            TableIndex = CreateIndex("XIF4PLATBY_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("org_id");
            TableIndex = CreateIndex("XIF5PLATBY_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ucetni_zak");
            TableIndex = CreateIndex("XIF6PLATBY_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ucetni_str");
            TableIndex = CreateIndex("XIF7PLATBY_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ucetni_cin");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_plkonf", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TablePlatbyUtvaryInfo : TableDefInfo
    {
        const string TABLE_NAME = "PLATBY_UTVARY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePlatbyUtvaryInfo(lpszOwnerName, lpszUsersName);
        }
        public TablePlatbyUtvaryInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("utvar_id", DB_LONG, dbNotNullFieldOption);
            CreateField("platba_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("platba_zpusob", DB_BYTE, dbNotNullFieldOption);
            CreateField("platba_priorita", DB_INTEGER, dbNotNullFieldOption);
            CreateField("splat_dny", DB_INTEGER, dbNotNullFieldOption);
            CreateField("adresa_id", DB_LONG, dbNullFieldOption);
            CreateField("bspoj_id", DB_LONG, dbNullFieldOption);
            CreateField("org_id", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_str", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_zak", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_cin", DB_LONG, dbNullFieldOption);
            CreateField("ucetni_zdr", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("utvar_id");
            PKConstraint.AppendField("platba_kod");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1PLATBY_UTVARY");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("utvar_id");
            TableIndex = CreateIndex("XIF2PLATBY_UTVARY");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("adresa_id");
            TableIndex = CreateIndex("XIF3PLATBY_UTVARY");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("bspoj_id");
            TableIndex = CreateIndex("XIF4PLATBY_UTVARY");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("org_id");
            TableIndex = CreateIndex("XIF5PLATBY_UTVARY");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ucetni_zak");
            TableIndex = CreateIndex("XIF6PLATBY_UTVARY");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ucetni_cin");
            TableIndex = CreateIndex("XIF7PLATBY_UTVARY");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ucetni_str");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("uid_pukonf", "UTVAR", "utvar_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("utvar_id", "uutvar_id");
        }

    }

    public class TablePopisSlozkaInfo : TableDefInfo
    {
        const string TABLE_NAME = "POPIS_SLOZKA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePopisSlozkaInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("ppsloz_kod", "kod")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TablePopisSlozkaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("ppsloz_kod", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("ppsloz_kod");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1POPIS_SLOZKA");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_psloz", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");

        }

    }

    public class TablePopisSlozkaHInfo : TableDefInfo
    {
        const string TABLE_NAME = "POPIS_SLOZKA_H";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePopisSlozkaHInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("psloz_kod", "kod")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TablePopisSlozkaHInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("psloz_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("vypocet", DB_BYTE, dbNotNullFieldOption);
            CreateField("danzapocet", DB_BYTE, dbNotNullFieldOption);
            CreateField("sazbaproc", DB_INTEGER, dbNotNullFieldOption);
            CreateField("informace", DB_INTEGER, dbNotNullFieldOption);
            CreateField("infsumace", DB_LONG, dbNotNullFieldOption);
            CreateField("infstatist", DB_LONG, dbNotNullFieldOption);
            CreateField("infstat104", DB_LONG, dbNotNullFieldOption);
            CreateField("infstatisp", DB_LONG, dbNotNullFieldOption);
            CreateField("infkategor", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("rozp_kapitola", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_paragraf", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_polozka", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_podpoloz", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_zazpoloz", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_ucelzdroj", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_kompetent", DB_TEXT, 24, dbNullFieldOption);
            CreateFTEXT("rozp_akce", DB_TEXT, 48, dbNullFieldOption);
            CreateField("default_sazba", DB_LONG, dbNotNullFieldOption);
            CreateField("default_pocjed", DB_LONG, dbNotNullFieldOption);
            CreateField("default_str", DB_LONG, dbNotNullFieldOption);
            CreateField("default_cin", DB_LONG, dbNotNullFieldOption);
            CreateField("default_zak", DB_LONG, dbNotNullFieldOption);
            CreateField("default_info", DB_LONG, dbNotNullFieldOption);
            CreateField("default_org", DB_LONG, dbNotNullFieldOption);
            CreateField("dal_ucet_kod", DB_LONG, dbNullFieldOption);
            CreateField("dat_ucet_kod", DB_LONG, dbNullFieldOption);
            CreateField("ispre_predpis", DB_LONG, dbNullFieldOption);
            CreateField("kontrola_info", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("psloz_kod");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF2POPIS_SLOZKA_H");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("dal_ucet_kod");
            TableIndex = CreateIndex("XIF3POPIS_SLOZKA_H");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("dat_ucet_kod");
            TableIndex = CreateIndex("XIF4POPIS_SLOZKA_H");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("ispre_predpis");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("psloz_h", "POPIS_SLOZKA", "psloz_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("psloz_kod", "ppsloz_kod");
        }

    }

    public class TablePopisSlozkaTInfo : TableDefInfo
    {
        const string TABLE_NAME = "POPIS_SLOZKA_T";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TablePopisSlozkaTInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("psloz_kod", "kod")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TablePopisSlozkaTInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("psloz_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("jazyk", DB_BYTE, dbNotNullFieldOption);
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("nazev", DB_TEXT, 70, dbNotNullFieldOption);
            CreateFTEXT("zkratka", DB_TEXT, 35, dbNotNullFieldOption);
            CreateFTEXT("zkrklav", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("mnemo", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("popis", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("psloz_kod");
            PKConstraint.AppendField("jazyk");
            PKConstraint.AppendField("firma_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1POPIS_SLOZKA_T");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("psloz_kod");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("psloz_t", "POPIS_SLOZKA", "psloz_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("psloz_kod", "ppsloz_kod");
        }

    }

    public class TableTarifniTridaInfo : TableDefInfo
    {
        const string TABLE_NAME = "TARIFNI_TRIDA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableTarifniTridaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableTarifniTridaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("ttrida_id", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("ttrida_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1TARIFNI_TRIDA");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_tar", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableTarifniTridaHInfo : TableDefInfo
    {
        const string TABLE_NAME = "TARIFNI_TRIDA_H";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableTarifniTridaHInfo(lpszOwnerName, lpszUsersName);
        }
        public TableTarifniTridaHInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("trida_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("trida_zvys", DB_BYTE, dbNotNullFieldOption);
            CreateField("platnost_od", DB_DATE, dbNotNullFieldOption);
            CreateField("platnost_do", DB_DATE, dbNullFieldOption);
            CreateField("trida_typ", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stupen01", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen02", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen03", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen04", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen05", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen06", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen07", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen08", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen09", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen10", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen11", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen12", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen13", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen14", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen15", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stupen16", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_stpraxe01", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe02", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe03", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe04", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe05", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe06", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe07", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe08", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe09", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe10", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe11", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe12", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe13", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe14", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe15", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_stpraxe16", DB_BYTE, dbNotNullFieldOption);
            CreateField("tt_minimMES", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_minimHOD", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_minivMES", DB_LONG, dbNotNullFieldOption);
            CreateField("tt_minivHOD", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("trida_id");
            PKConstraint.AppendField("trida_zvys");
            PKConstraint.AppendField("platnost_od");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1TARIFNI_TRIDA_H");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("trida_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("tart_h", "TARIFNI_TRIDA", "trida_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("trida_id", "ttrida_id");
        }

    }

    public class TableTarifniTridaTInfo : TableDefInfo
    {
        const string TABLE_NAME = "TARIFNI_TRIDA_T";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableTarifniTridaTInfo(lpszOwnerName, lpszUsersName);
        }
        public TableTarifniTridaTInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("trida_id", DB_INTEGER, dbNotNullFieldOption);
            CreateField("jazyk", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("tt_nazev", DB_TEXT, 6, dbNotNullFieldOption);
            CreateFTEXT("tt_stupen", DB_TEXT, 6, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("trida_id");
            PKConstraint.AppendField("jazyk");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1TARIFNI_TRIDA_T");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("trida_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("tart_t", "TARIFNI_TRIDA", "trida_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("trida_id", "ttrida_id");
        }

    }

    public class TableUcetniOsnovaInfo : TableDefInfo
    {
        const string TABLE_NAME = "UCETNI_OSNOVA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableUcetniOsnovaInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("druh_uctu", "ucet_druh")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TableUcetniOsnovaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("ucet_kod", DB_LONG);
            CreateField("druh_uctu", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("ucet_skup", DB_TEXT, 3, dbNullFieldOption);
            CreateFTEXT("ucet_synt", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("ucet_anal", DB_TEXT, 15, dbNullFieldOption);
            CreateField("ucet_inf1", DB_BYTE, dbNotNullFieldOption);
            CreateField("ucet_inf2", DB_BYTE, dbNotNullFieldOption);
            CreateField("ucet_inf3", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("ucet_syn1", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("ucet_syn2", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("ucet_syn3", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("ucet_ana1", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("ucet_ana2", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("ucet_ana3", DB_TEXT, 15, dbNullFieldOption);
            CreateFTEXT("ucet_text", DB_TEXT, 255, dbNullFieldOption);
            CreateField("ucet_infow", DB_INTEGER, dbNotNullFieldOption);
            CreateField("ucet_infor", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("ucet_kod");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1UCETNI_OSNOVA");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_uosn", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableUcetniPredpisyInfo : TableDefInfo
    {
        const string TABLE_NAME = "UCETNI_PREDPISY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableUcetniPredpisyInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("ppredpis_id", "predpis_id")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TableUcetniPredpisyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("ppredpis_id", DB_LONG);
            CreateFTEXT("predpis_uckod", DB_TEXT, 50, dbNotNullFieldOption);
            CreateFTEXT("predpis_nazev", DB_TEXT, 255, dbNotNullFieldOption);
            CreateField("predpis_druh", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("ppredpis_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_upred", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableUcetniPolozkyInfo : TableDefInfo
    {
        const string TABLE_NAME = "UCETNI_POLOZKY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableUcetniPolozkyInfo(lpszOwnerName, lpszUsersName);
        }
        public TableUcetniPolozkyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("predpis_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("poloz_nazev", DB_TEXT, 255, false);
            CreateField("poloz_druh", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_inf1", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_delka1", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_fmt1", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_inf2", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_delka2", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_fmt2", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_inf3", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_delka3", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_fmt3", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_inf4", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_delka4", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_fmt4", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_inf5", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_delka5", DB_INTEGER, dbNotNullFieldOption);
            CreateField("poloz_fmt5", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("poloz_skup", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("poloz_synt", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poloz_anal", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poloz_text1", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poloz_text2", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poloz_text3", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poloz_text4", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poloz_text5", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("predpis_id");
            PKConstraint.AppendField("cislo");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("ucpredp_polozky", "UCETNI_PREDPISY", "predpis_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("predpis_id", "ppredpis_id");
        }

    }

    public class TableUzivCiselnikInfo : TableDefInfo
    {
        const string TABLE_NAME = "UZIV_CISELNIK";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableUzivCiselnikInfo(lpszOwnerName, lpszUsersName);
        }
        public TableUzivCiselnikInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("uzc_kod", DB_INTEGER, dbNotNullFieldOption);
            CreateField("uzc_ciselnik", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("uzc_text", DB_TEXT, 255, dbNotNullFieldOption);
            CreateFTEXT("uzc_stat", DB_TEXT, 20, dbNullFieldOption);
            CreateField("zruseno", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("czm_vkod", DB_TEXT, 20, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("uzc_kod");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1UZIV_CISELNIK");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_uzc", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableValutaKurzInfo : TableDefInfo
    {
        const string TABLE_NAME = "VALUTA_KURZ";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableValutaKurzInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("vvaluta_cislo", "valuta_cislo")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TableValutaKurzInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("vvaluta_cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("valuta_nazev", DB_TEXT, 20, dbNotNullFieldOption);
            CreateFTEXT("valuta_zkod", DB_TEXT, 6, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("vvaluta_cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1VALUTA_KURZ");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_val", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableValutaKurzMesInfo : TableDefInfo
    {
        const string TABLE_NAME = "VALUTA_KURZ_MES";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableValutaKurzMesInfo(lpszOwnerName, lpszUsersName);
        }
        public TableValutaKurzMesInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("valuta_cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("valuta_jedn", DB_BYTE, dbNotNullFieldOption);
            CreateField("valuta_kurz", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("valuta_cislo");
            PKConstraint.AppendField("mesic");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1VALUTA_KURZ_MES");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("valuta_cislo");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("valid_vmes", "VALUTA_KURZ", "valuta_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("valuta_cislo", "vvaluta_cislo");
        }

    }

    public class TableZemePlatkoefInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZEME_PLATKOEF";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZemePlatkoefInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("zzeme_cislo", "zeme_cislo")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TableZemePlatkoefInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("zzeme_cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("zeme_nazev", DB_TEXT, 50, dbNotNullFieldOption);
            CreateFTEXT("mesto_nazev", DB_TEXT, 50, dbNotNullFieldOption);
            CreateField("valuta_cislo", DB_INTEGER, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("zzeme_cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1ZEME_PLATKOEF");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2ZEME_PLATKOEF");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("valuta_cislo");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_zeme", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableZemePlatkoefMesInfo : TableDefInfo
    {
        const string TABLE_NAME = "ZEME_PLATKOEF_MES";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableZemePlatkoefMesInfo(lpszOwnerName, lpszUsersName);
        }
        public TableZemePlatkoefMesInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("zeme_cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("plat_koef", DB_DOUBLE, dbNotNullFieldOption);
            CreateField("plat_relace", DB_DOUBLE, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("zeme_cislo");
            PKConstraint.AppendField("mesic");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1ZEME_PLATKOEF_MES");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("zeme_cislo");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("zemid_zmes", "ZEME_PLATKOEF", "zeme_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("zeme_cislo", "zzeme_cislo");
        }

    }

    public class TableStavKonfigInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_KONFIG";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavKonfigInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStavKonfigInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("informace", DB_LONG, dbNotNullFieldOption);
            CreateField("meszacatek", DB_BYTE, dbNotNullFieldOption);
            CreateField("rokzacatek", DB_INTEGER, dbNotNullFieldOption);
            CreateField("mesdatazac", DB_BYTE, dbNotNullFieldOption);
            CreateField("rokdatazac", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pocitanymes", DB_BYTE, dbNotNullFieldOption);
            CreateField("pocitanyrok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("uzavrenrok", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("denvyplaty", DB_BYTE, dbNotNullFieldOption);
            CreateField("denvyplpred", DB_BYTE, dbNotNullFieldOption);
            CreateField("vpocmesv", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("vpocmesvpred", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("denzaloh", DB_BYTE, dbNotNullFieldOption);
            CreateField("zpusodmen", DB_BYTE, dbNotNullFieldOption);
            CreateField("pracuvazek", DB_BYTE, dbNotNullFieldOption);
            CreateField("zpusvyplaty", DB_BYTE, dbNotNullFieldOption);
            CreateField("dovjenodpr", DB_BYTE, dbNotNullFieldOption);
            CreateField("narokdovol", DB_BYTE, dbNotNullFieldOption);
            CreateField("zaklddovol", DB_BYTE, dbNotNullFieldOption);
            CreateField("zvysdovol", DB_BYTE, dbNotNullFieldOption);
            CreateField("vyuctmzdl", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("jazyk", DB_BYTE, dbNotNullFieldOption);
            CreateField("slozka_mkod", DB_BYTE, dbNotNullFieldOption);
            CreateField("fin_urad", DB_LONG, dbNullFieldOption);
            CreateField("soc_sprava", DB_LONG, dbNullFieldOption);
            CreateField("zdr_pojist", DB_LONG, dbNullFieldOption);
            CreateField("zps_odvody", DB_LONG, dbNullFieldOption);
            CreateField("poj_kooper", DB_LONG, dbNullFieldOption);
            CreateField("vyuctkde", DB_BYTE, dbNotNullFieldOption);
            CreateField("vyuctprac", DB_LONG, dbNullFieldOption);
            CreateField("konvpkde", DB_BYTE, dbNotNullFieldOption);
            CreateField("konvpprac", DB_LONG, dbNotNullFieldOption);
            CreateField("org_plfksp", DB_LONG, dbNotNullFieldOption);
            CreateField("nekratit_pvq", DB_BYTE, dbNotNullFieldOption);
            CreateField("skutecne_ppv", DB_BYTE, dbNotNullFieldOption);
            CreateField("neprepoc_ppv", DB_BYTE, dbNotNullFieldOption);
            CreateField("kontrola_dob", DB_BYTE, dbNotNullFieldOption);
            CreateField("rozobdob_ppv", DB_BYTE, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF2STAV_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("zps_odvody");
            TableIndex = CreateIndex("XIF3STAV_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("zdr_pojist");
            TableIndex = CreateIndex("XIF4STAV_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("poj_kooper");
            TableIndex = CreateIndex("XIF5STAV_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("fin_urad");
            TableIndex = CreateIndex("XIF6STAV_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("soc_sprava");
            TableIndex = CreateIndex("XIF7STAV_KONFIG");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("vyuctprac");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_stavk", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableStavKonfigUcertInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_KONFIG_UCERT";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavKonfigUcertInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStavKonfigUcertInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("outl_version", DB_LONG, dbNotNullFieldOption);
            CreateField("outl_folder", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("folder_path", DB_TEXT, 255, dbNullFieldOption);
            CreateField("ssl_connect", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("qry_server", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("qry_base", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("qry_filter", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("fld_certif", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("fld_email", DB_TEXT, 255, dbNullFieldOption);
            CreateField("def_creden", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("cred_user", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cred_pssw", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fir_konfucert", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableStavKonfigSmtpInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_KONFIG_SMTP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavKonfigSmtpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStavKonfigSmtpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("server_name", DB_TEXT, 255, dbNullFieldOption);
            CreateField("server_port", DB_BYTE, dbNotNullFieldOption);
            CreateField("server_ssl", DB_BYTE, dbNotNullFieldOption);
            CreateField("def_creden", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("cred_user", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cred_pssw", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fir_konfsmtp", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableStavKonfigVrepInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_KONFIG_VREP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavKonfigVrepInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStavKonfigVrepInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("vreps_info", DB_LONG, dbNotNullFieldOption);
            CreateField("message_info", DB_LONG, dbNotNullFieldOption);
            CreateField("proxy_info", DB_LONG, dbNotNullFieldOption);
            CreateField("uitheme_info", DB_LONG, dbNotNullFieldOption);
            CreateField("logger_info", DB_LONG, dbNotNullFieldOption);
            CreateField("protokol_typ", DB_INTEGER, dbNotNullFieldOption);
            CreateField("protokol_def", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("addrpox_url1", DB_TEXT, 120, dbNullFieldOption);
            CreateFTEXT("addrpox_url2", DB_TEXT, 120, dbNullFieldOption);
            CreateFTEXT("addrwss_svc1", DB_TEXT, 120, dbNullFieldOption);
            CreateFTEXT("addrwss_svc2", DB_TEXT, 120, dbNullFieldOption);
            CreateFTEXT("proxy_name", DB_TEXT, 255, dbNullFieldOption);
            CreateField("proxy_port", DB_INTEGER, dbNotNullFieldOption);
            CreateFTEXT("proxy_user", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("proxy_pssw", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("cert_tlssl", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");

            //RelationDefInfo TableRelation = null;
            //TableRelation = CreateRelation("fir_konfvrep", "FIRMA", "firma_id");
            //TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }
    public class TableSestavyHtmlInfo : TableDefInfo
    {
        const string TABLE_NAME = "SESTAVY_HTML";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableSestavyHtmlInfo(lpszOwnerName, lpszUsersName);
        }
        public TableSestavyHtmlInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("kod_lst", DB_INTEGER, dbNotNullFieldOption);
            CreateField("email_type", DB_BYTE, dbNotNullFieldOption);
            CreateField("email_body", DB_BYTE, dbNotNullFieldOption);
            CreateField("email_subject", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("format_subject", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("html_xsltfull", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("html_xsltshort", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("text_xsltfull", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("text_xsltshort", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach1_contype", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach1_conname", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach1_filepath", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach2_contype", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach2_conname", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach2_filepath", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach3_contype", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach3_conname", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach3_filepath", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach4_contype", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach4_conname", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach4_filepath", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach5_contype", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach5_conname", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("attach5_filepath", DB_TEXT, 255, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("kod_lst");

            RelationDefInfo TableRelation = null;
            TableRelation = CreateRelation("slst_sesthtml", "SESTAVY_LST", "sestava_lst_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("kod_lst", "kod_lst");
        }

    }

    public class TableStavMesInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_MES";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavMesInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStavMesInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("informace", DB_LONG, dbNotNullFieldOption);
            CreateField("vypzal", DB_DATE, dbNullFieldOption);
            CreateField("vyuctpred", DB_DATE, dbNullFieldOption);
            CreateField("vyuct", DB_DATE, dbNullFieldOption);
            CreateField("uzav_dan", DB_BYTE, dbNotNullFieldOption);
            CreateField("proczivnakl_sml", DB_INTEGER, dbNotNullFieldOption);
            CreateField("proczivnakl_norm", DB_INTEGER, dbNotNullFieldOption);
            CreateField("proczivsluz_sml", DB_INTEGER, dbNotNullFieldOption, 1600);
            CreateField("proczivsluz_norm", DB_INTEGER, dbNotNullFieldOption, 1600);
            CreateFTEXT("iissp_pred", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("iissp", DB_TEXT, 50, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("mesic");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1STAV_MES");
            TableIndex.AppendField("firma_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fid_stavm", "STAV_KONFIG", "firma_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
        }

    }

    public class TableStavMesDanInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_MES_DAN";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavMesDanInfo(lpszOwnerName, lpszUsersName);
        }
        override public string ClassColumnName(string columnName)
        {
            Tuple<string, string>[] changeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("vraceno_dansr", "vraceno_srz"),
                new Tuple<string, string>("prepldansr", "preplsrz"),
                new Tuple<string, string>("vracdat_dansr", "vracdat_srz"),
                new Tuple<string, string>("prepldansrpo1", "preplsrzpo1")
            };
            return NameConversions.TransformName(changeNames, columnName);
        }

        public TableStavMesDanInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("mesic", DB_INTEGER, dbNotNullFieldOption);
            CreateField("fuorg_id", DB_LONG, dbNotNullFieldOption);
            CreateField("vraceno_dan", DB_LONG, dbNotNullFieldOption);
            CreateField("vraceno_dansr", DB_LONG, dbNotNullFieldOption);
            CreateField("prepldan", DB_LONG, dbNotNullFieldOption);
            CreateField("prepldanpo1", DB_LONG, dbNotNullFieldOption);
            CreateField("prepldansr", DB_LONG, dbNotNullFieldOption);
            CreateField("prepldansrpo1", DB_LONG, dbNotNullFieldOption);
            CreateField("druh_org", DB_BYTE, dbNotNullFieldOption);
            CreateField("vraceno_rok", DB_LONG, dbNotNullFieldOption);
            CreateField("preplrok", DB_LONG, dbNotNullFieldOption);
            CreateField("preplrokpo1", DB_LONG, dbNotNullFieldOption);
            CreateField("vraceno_slv", DB_LONG, dbNotNullFieldOption);
            CreateField("preplslv", DB_LONG, dbNotNullFieldOption);
            CreateField("preplslvpo1", DB_LONG, dbNotNullFieldOption);
            CreateField("vraceno_mes", DB_LONG, dbNotNullFieldOption);
            CreateField("preplmes", DB_LONG, dbNotNullFieldOption);
            CreateField("preplmespo1", DB_LONG, dbNotNullFieldOption);
            CreateField("vracdat_slv", DB_DATE, dbNullFieldOption);
            CreateField("vracdat_dan", DB_DATE, dbNullFieldOption);
            CreateField("vracdat_rok", DB_DATE, dbNullFieldOption);
            CreateField("vracdat_mes", DB_DATE, dbNullFieldOption);
            CreateField("vracdat_dansr", DB_DATE, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("mesic");
            PKConstraint.AppendField("fuorg_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1STAV_MES_DAN");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("mesic");
            TableIndex = CreateIndex("XIF2STAV_MES_DAN");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("fuorg_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("oid_stavmesdan", "ORGANIZACE", "fuorg_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("fuorg_id", "org_id");
			TableRelation = CreateRelation("stavm_mesdan", "STAV_MES", "stav_mes_id");
            TableRelation.AppendForeignField("firma_id", "firma_id");
            TableRelation.AppendForeignField("mesic", "mesic");
        }

    }

    public class TableStavStatInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_STAT";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavStatInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStavStatInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("stat_limd", DB_BYTE, dbNullFieldOption);
            CreateFTEXT("stat_icz", DB_TEXT, 10, dbNullFieldOption);
            CreateField("stat_mzak", DB_BYTE, dbNullFieldOption);
            CreateFTEXT("stat_okec", DB_TEXT, 6, dbNullFieldOption, 0, 1604);
            CreateFTEXT("stat_okec20", DB_TEXT, 20, dbNullFieldOption, 1604);
            CreateFTEXT("stat_nace", DB_TEXT, 10, dbNullFieldOption);
            CreateField("stat_okres", DB_INTEGER, dbNullFieldOption);
            CreateFTEXT("stat_nuts", DB_TEXT, 10, dbNullFieldOption);
            CreateField("stat_prfor", DB_INTEGER, dbNullFieldOption);
            CreateFTEXT("stat_utvar", DB_TEXT, 6, dbNullFieldOption);
            CreateField("stat_vlast", DB_BYTE, dbNullFieldOption);
            CreateField("stat_ksml", DB_LONG, dbNotNullFieldOption);
            CreateField("rozpoc_zam", DB_LONG, dbNotNullFieldOption);
            CreateField("rozpoc_plat", DB_LONG, dbNotNullFieldOption);
            CreateField("rozpoc_mimo", DB_LONG, dbNotNullFieldOption);
            CreateField("stat_kzam5", DB_INTEGER, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("rok");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("FIRMA_STAVSTAT", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableStavDefaultInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_DEFAULT";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavDefaultInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStavDefaultInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("velkaorg", DB_BOOLEAN, dbNotNullFieldOption);
            CreateField("socpojtyp", DB_BYTE, dbNotNullFieldOption);
            CreateField("pracdoba", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracden", DB_INTEGER, dbNotNullFieldOption);
            CreateField("pracmesic", DB_LONG, dbNotNullFieldOption);
            CreateField("procnahrsv", DB_INTEGER, dbNotNullFieldOption);
            CreateField("procprekorg", DB_INTEGER, dbNotNullFieldOption);
            CreateField("prockooper", DB_INTEGER, dbNotNullFieldOption);
            CreateField("procplfksp", DB_INTEGER, dbNotNullFieldOption);
            CreateField("procdalsip", DB_LONG, dbNotNullFieldOption);
            CreateField("smena_minut", DB_INTEGER, dbNotNullFieldOption);
            CreateField("smena_procent", DB_INTEGER, dbNotNullFieldOption);
            CreateField("limit_presc1", DB_LONG, dbNotNullFieldOption);
            CreateField("limit_presc2", DB_LONG, dbNotNullFieldOption);
            CreateField("limit_pohmimo", DB_LONG, dbNotNullFieldOption);
            CreateField("limit_pohotna", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("rok");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("FIRMA_STAVDEFAULT", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableStavOzpInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_OZP";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavOzpInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStavOzpInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("rok", DB_INTEGER, dbNotNullFieldOption);
            CreateField("stan_pdoba", DB_LONG, dbNotNullFieldOption);
            CreateField("meszacat", DB_BYTE, dbNotNullFieldOption);
            CreateField("meskonec", DB_BYTE, dbNotNullFieldOption);
            CreateField("mzda1az3q_pm", DB_LONG, dbNotNullFieldOption);
            CreateField("rplatbakc_kc", DB_LONG, dbNotNullFieldOption);
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
            CreateField("pocetzame_ppz", DB_LONG, dbNotNullFieldOption);
            CreateField("pocetzzps_ppz", DB_LONG, dbNotNullFieldOption);
            CreateField("pocetzztp_ppz", DB_LONG, dbNotNullFieldOption);
            CreateField("pocetboda_bod", DB_LONG, dbNotNullFieldOption);
            CreateField("pocetbodb_bod", DB_LONG, dbNotNullFieldOption);
            CreateField("pocetbodc_bod", DB_LONG, dbNotNullFieldOption);
            CreateField("pocetkcsb_bod", DB_LONG, dbNotNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("rok");
            PKConstraint.AppendField("stan_pdoba");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("firma_stavozp", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableStavMessageInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_MESSAGE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavMessageInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStavMessageInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo", DB_INTEGER, dbNotNullFieldOption);
            CreateField("typ_mssg", DB_INTEGER, dbNotNullFieldOption);
            CreateField("platnost", DB_INTEGER, dbNotNullFieldOption);
            CreateField("plati_od", DB_DATE, dbNullFieldOption);
            CreateField("plati_do", DB_DATE, dbNullFieldOption);
            CreateFTEXT("msg_title", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("msg_text", DB_TEXT, 255, dbNullFieldOption);
            CreateField("uzivatel_id", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("cislo");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1STAV_MESSAGE");
            TableIndex.AppendField("firma_id");
            TableIndex = CreateIndex("XIF2STAV_MESSAGE");
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("uzivatel_id");
        }

    }

}
