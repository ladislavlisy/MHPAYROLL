using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    public class TableImpPnrInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_PNR";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImpPnrInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImpPnrInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateFTEXT("pnr_ok", DB_TEXT, 12, dbNotNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("pnr");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fir_imppnr", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");

        }

    }

    public class TableImpDavkaInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_DAVKA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImpDavkaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImpDavkaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("davka_id", DB_LONG);
            CreateFTEXT("nazev", DB_TEXT, 50, dbNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateField("saphr", DB_BYTE, dbNotNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");

            RelationDefInfo TableRelation = null;
			TableRelation = CreateRelation("fir_impdavka", "FIRMA", "firma_id");
            TableRelation.AppendForeignField("firma_id", "ffirma_id");
        }

    }

    public class TableImp01PracInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_01_PRAC";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp01PracInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp01PracInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("rodne_prijmeni", DB_TEXT, 35, dbNullFieldOption);
            CreateFTEXT("utvar_nazev", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("str_nazev", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("cin_nazev", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("zak_nazev", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 35, dbNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 30, dbNullFieldOption);
            CreateFTEXT("titul_pred", DB_TEXT, 35, dbNullFieldOption);
            CreateFTEXT("titul_za", DB_TEXT, 13, dbNullFieldOption);
            CreateFTEXT("misto_narozeni", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("rodst_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("zapocet_roky", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("zapocet_dny", DB_TEXT, 3, dbNullFieldOption);
            CreateFTEXT("zapocet_datum", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("adr_tr_obec", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_tr_cast_obce", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_tr_cisdom_typ", DB_TEXT, 3, dbNullFieldOption);
            CreateFTEXT("adr_tr_cisdom_hod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("adr_tr_ulice", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_tr_psc", DB_TEXT, 11, dbNullFieldOption);
            CreateFTEXT("adr_tr_nazev_posty", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_tr_cisor_hod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("adr_tr_stat_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("vychov_deti", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("duchod_pob", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("duchod_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("zdrav_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("obcan_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("prukaz_obc", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("prukaz_pas", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("cizinec_rc", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("stat_narozeni_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_01_PRAC", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
        }

    }

    public class TableImp51PracInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_51_PRAC";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp51PracInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp51PracInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("pnr_ok", DB_TEXT, 12, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_51_PRAC", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
        }

    }

    public class TableImp02ZpVyplatyInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_02_ZP_VYPLATY";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp02ZpVyplatyInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp02ZpVyplatyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("zp_vyplaty", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("adr_obec", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_cast_obce", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_cisdom_typ", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("adr_cisdom_hod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("adr_ulice", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_psc", DB_TEXT, 11, dbNullFieldOption);
            CreateFTEXT("adr_nazev_posty", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_cisor_hod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("adr_stat_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("bank_ucet", DB_TEXT, 18, dbNullFieldOption);
            CreateFTEXT("bank_ustav", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("bank_konsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("bank_varsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("bank_specsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_02_ZP_VYPLATY", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
        }

    }

    public class TableImp03OsdataInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_03_OSDATA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp03OsdataInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp03OsdataInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("osd_vzdel_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("osd_oborv_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("osd_jkov", DB_TEXT, 7, dbNullFieldOption);
            CreateFTEXT("osd_skup_ridic", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("osd_telefon1", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("osd_telefon1_typ", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("osd_telefon2", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("osd_telefon2_typ", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("osd_vojak", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("osdata", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("predchozi", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_03_OSDATA", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
        }

    }

    public class TableImp31PrAdresaInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_31_PR_ADRESA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp31PrAdresaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp31PrAdresaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("adr_obec", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_cast_obce", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_cisdom_typ", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("adr_cisdom_hod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("adr_ulice", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_psc", DB_TEXT, 11, dbNullFieldOption);
            CreateFTEXT("adr_nazev_posty", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_cisor_hod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("adr_stat_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_31_PR_ADRESA", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
        }

    }

    public class TableImp05ZdrPojInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_05_ZDR_POJ";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp05ZdrPojInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp05ZdrPojInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("zdr_poj_kod", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("zdr_poj_misto", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("zdr_poj_cislo", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("zdr_poj_cizinec", DB_TEXT, 1, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_05_ZDR_POJ", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
        }

    }

    public class TableImp06SocPojInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_06_SOC_POJ";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp06SocPojInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp06SocPojInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("SOC_POJ_KOD", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("SOC_POJ_MISTO", DB_TEXT, 48, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_06_SOC_POJ", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
        }

    }

    public class TableImp07PrijmyProhlInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_07_PRIJMY_PROHL";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp07PrijmyProhlInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp07PrijmyProhlInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateField("id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("rok", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("obdobi", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("podepsal", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("invalidita1", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("invalidita2", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("invalidita3", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("prijem", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("pojistne", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("zaloha", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("dan_zuctovat", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("slevaB", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("slevaC", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("bonusC", DB_TEXT, 12, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_07_PRIJMY_PROHL", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
            TableIndex.AppendField("id");
        }

    }

    public class TableImp08ProhlMesInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_08_PROHL_MES";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp08ProhlMesInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp08ProhlMesInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("podepsal", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("invalidita1", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("invalidita2", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("invalidita3", DB_TEXT, 1, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_08_PROHL_MES", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
        }

    }

    public class TableImp09DiteInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_09_DITE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp09DiteInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp09DiteInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateField("id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("rok", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("rodne_cislo", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("prijmeni", DB_TEXT, 35, dbNullFieldOption);
            CreateFTEXT("jmeno", DB_TEXT, 30, dbNullFieldOption);
            CreateFTEXT("titul_pred", DB_TEXT, 35, dbNullFieldOption);
            CreateFTEXT("titul_za", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("ztpp", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("sniz_danmes", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("sniz_danrok", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("platnost_obd", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("aktualni_obd", DB_TEXT, 1, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_09_DITE", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
            TableIndex.AppendField("id");
        }

    }

    public class TableImp17PomerInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_17_POMER";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp17PomerInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp17PomerInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateField("cislo", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("pomer_nazev", DB_TEXT, 31, dbNullFieldOption);
            CreateFTEXT("zacatek", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("konec", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("cinnost", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("platce_danpr", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("platce_spoj", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("platce_zpoj", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("min_zp", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("neni_evid", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("neni_dovol", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("kzam", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("praxe_roky", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("praxe_dny", DB_TEXT, 3, dbNullFieldOption);
            CreateFTEXT("tar_trida", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("tar_stupen", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("tar_stupen_auto", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("tar_zvys_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("druh_nastup_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("druh_odchod_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("druh_doba_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("druh_pprav_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("kvalifikace_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("funkce", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("dovol_nar_letos", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("dovol_nar_dodat", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("dovol_jina", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("dovol_letos", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("dovol_lonska", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("dovol_cerpano", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("dovol_proplac", DB_TEXT, 2, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_17_POMER", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
            TableIndex.AppendField("cislo");
        }

    }

    public class TableImp18UvazekInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_18_UVAZEK";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp18UvazekInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp18UvazekInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateField("cislo", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("pomer_nazev", DB_TEXT, 31, dbNullFieldOption);
            CreateFTEXT("druh_odmenovani", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("druh_uvazku", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("uvazek_plny", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("uvazek_skutecny", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("str_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("cin_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("zak_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("turnus_delka", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("turnus_zacatek", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("turnus_smen01", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen02", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen03", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen04", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen05", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen06", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen07", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen08", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen09", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen10", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen11", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen12", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen13", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen14", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen15", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen16", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen17", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen18", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen19", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen20", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen21", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen22", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen23", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen24", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen25", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen26", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen27", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen28", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_smen_zam", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen01", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen02", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen03", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen04", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen05", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen06", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen07", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen08", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen09", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen10", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen11", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen12", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen13", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen14", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen15", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen16", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen17", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen18", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen19", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen20", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen21", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen22", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen23", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen24", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen25", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen26", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen27", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen28", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen29", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen30", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("turnus_kalen31", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("vydel_prum_hod", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("vydel_zap_den", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("zvys_zaklad_q1", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("zvys_zaklad_q2", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("zvys_zaklad_q3", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("zvys_zaklad_q4", DB_TEXT, 12, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_18_UVAZEK", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
            TableIndex.AppendField("cislo");
        }

    }

    public class TableImp19MzdaInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_19_MZDA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp19MzdaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp19MzdaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateField("cislo", DB_LONG, dbNotNullFieldOption);
            CreateField("id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("pomer_nazev", DB_TEXT, 31, dbNullFieldOption);
            CreateFTEXT("kod", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("kod_text", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("minuty", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("minuty_norm", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("jednotky", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("sazba_kc", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("sazba_proc", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("str_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("cin_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("zak_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("trvale", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("tar_trida", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("tar_stupen", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("tar_stupen_auto", DB_TEXT, 1, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_19_MZDA", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
            TableIndex.AppendField("cislo");
            TableIndex.AppendField("id");
        }

    }

    public class TableImp20NepritInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_20_NEPRIT";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp20NepritInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp20NepritInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateField("cislo", DB_LONG, dbNotNullFieldOption);
            CreateField("id", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("pomer_nazev", DB_TEXT, 31, dbNullFieldOption);
            CreateFTEXT("kod", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("kod_text", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("plati_od", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("plati_do", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("min_prvniden", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("min_posledniden", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("sazba_kc", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("sazba_proc", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("zap_vyd", DB_TEXT, 12, dbNullFieldOption);
            CreateFTEXT("doklad", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("platit", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("str_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("cin_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("zak_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("trvale", DB_TEXT, 2, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_20_NEPRIT", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
            TableIndex.AppendField("cislo");
            TableIndex.AppendField("id");
        }

    }

    public class TableImp21SrazkaInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_21_SRAZKA";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp21SrazkaInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp21SrazkaInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateFTEXT("pnr", DB_TEXT, 12, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateField("id", DB_LONG, dbNotNullFieldOption);
            CreateField("cislo", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("kod", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("kod_text", DB_TEXT, 6, dbNullFieldOption);
            CreateFTEXT("celkem_kc", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("mesicne_kc", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("proc_jednotky", DB_TEXT, 5, dbNullFieldOption);
            CreateFTEXT("posledni_kc", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("posledni_den", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("posledni_mesic", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("posledni_rok", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("str_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("cin_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("zak_nazev", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("trvale", DB_TEXT, 2, dbNullFieldOption);
            CreateFTEXT("zp_vyplaty", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("adr_obec", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_cast_obce", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_cisdom_typ", DB_TEXT, 1, dbNullFieldOption);
            CreateFTEXT("adr_cisdom_hod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("adr_ulice", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_psc", DB_TEXT, 11, dbNullFieldOption);
            CreateFTEXT("adr_nazev_posty", DB_TEXT, 48, dbNullFieldOption);
            CreateFTEXT("adr_cisor_hod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("adr_stat_kod", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("bank_ucet", DB_TEXT, 18, dbNullFieldOption);
            CreateFTEXT("bank_ustav", DB_TEXT, 4, dbNullFieldOption);
            CreateFTEXT("bank_konsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("bank_varsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("bank_specsymb", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("opt_valuta_mena", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("opt_zeme_nazev", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("opt_mesto_nazev", DB_TEXT, 50, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_21_SRAZKA", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("pnr");
            TableIndex.AppendField("id");
        }

    }

    public class TableImp101UtvarInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_101_UTVAR";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp101UtvarInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp101UtvarInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("nazev", DB_TEXT, 50, dbNotNullFieldOption);
            CreateFTEXT("ucetni_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("zeme_cislo", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("uzivatel_jmeno", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("plati_od", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("plati_do", DB_TEXT, 10, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_101_UTVAR", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("nazev");
        }

    }
    
    public class TableImp102StrczInfo : TableDefInfo
    {
        const string TABLE_NAME = "IMP_102_STRCZ";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableImp102StrczInfo(lpszOwnerName, lpszUsersName);
        }
        public TableImp102StrczInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("firma_id", DB_LONG, dbNotNullFieldOption);
            CreateField("davka_id", DB_LONG, dbNotNullFieldOption);
            CreateFAUTO("impRadek_id", DB_LONG);
            CreateField("id", DB_LONG, dbNotNullFieldOption);
            CreateField("zpracovano", DB_BYTE, dbNotNullFieldOption);
            CreateFTEXT("nazev", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("ucetni_kod", DB_TEXT, 20, dbNullFieldOption);
            CreateFTEXT("druh", DB_TEXT, 3, dbNullFieldOption);
            CreateFTEXT("poznamka", DB_TEXT, 255, dbNullFieldOption);
            CreateFTEXT("divize_nazev", DB_TEXT, 50, dbNullFieldOption);
            CreateFTEXT("plati_od", DB_TEXT, 10, dbNullFieldOption);
            CreateFTEXT("plati_do", DB_TEXT, 10, dbNullFieldOption);
            CreateGDATE("reg_datum", DB_DATE, dbNotNullFieldOption);
            CreateField("reg_logid", DB_LONG, dbNullFieldOption);

            IndexDefInfo PKConstraint = CreatePKConstraint("XPK");
            PKConstraint.AppendField("firma_id");
            PKConstraint.AppendField("davka_id");
            PKConstraint.AppendField("impRadek_id");

            IndexDefInfo TableIndex = null;
            TableIndex = CreateIndex("XIF1IMP_102_STRCZ", true);
            TableIndex.AppendField("firma_id");
            TableIndex.AppendField("davka_id");
            TableIndex.AppendField("id");
        }

    }

}
