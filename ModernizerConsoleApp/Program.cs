using System;
using System.Collections.Generic;
using System.Linq;
using OKmzdy.AppParams;
using OKmzdy.Generators.SchemaSource;
using OKmzdy.Schema;
using OKmzdy.Schema.Database;
using OKmzdy.Schema.Utils;

class Program
{
	static void Main(string[] args)
	{
		string appExecutableFolder = ExecutableAppFolder();

		UInt32 buildVersion = 1608;

		GenerateCodeClasses (appExecutableFolder, buildVersion);
		
		Console.WriteLine("Finished!");
	}

	private static void GenerateCodeClasses(string appExecutableFolder, UInt32 versCreate)
	{
		EFCodeSourceBuilder builder = new EFCodeSourceBuilder(versCreate);

		IList<string> subsetTable = null;
		IList<string> subsetIndex = null;
		IList<string> subsetRelat = null;
		IList<string> subsetUpdTrigger = null;
		IList<string> subsetInsTrigger = null;
		IList<string> subsetQuery = null;

		SetUpSchemaSubsets(ref subsetTable, ref subsetIndex, ref subsetRelat, ref subsetUpdTrigger, ref subsetInsTrigger, ref subsetQuery);

		string xmlAppParamsFile = "../MSSQL_OKMZDY_DATA.XML";


		SoftwareUserData regItemData = OKmzdy.AppParams.XmlFile.AppParamsUtils.LoadOKmzdyDataRegistry(xmlAppParamsFile, "DATA", "NEW_MSSQL");

		BaseSchemaInfo schemaInfo = new OKmzdySchemaInfo(regItemData.UserName(), regItemData.OwnrName());

		IList<TableDefInfo> tableList = schemaInfo.CreateSubsetTableCloneList(subsetTable);
		IList<CloneTableDefInfo> cloneTableList = tableList.Select((t) => (new CloneTableDefInfo(t, versCreate))).ToList();

		CloneSchemaTransformation.ConvertTablesAutoIdFieldToId(cloneTableList);
		CloneSchemaTransformation.ConvertTablesRelationsMxToId(cloneTableList);

		tableList = cloneTableList.Select((t) => (t.GetTargetInfo())).ToList();

		string infoFileClazz = "NEW_CODESOURCE_CLAZZ.TXT";
		string codeFileClazz = "NEW_CODESOURCE_CLAZZ.cs";

		using (ScriptWritter writer = new ScriptWritter(appExecutableFolder, infoFileClazz, codeFileClazz, regItemData.DataType(), false))
		{
			builder.CreateTableListCodeClasses(tableList, writer);
		}

		string infoFileConfig = "NEW_CODESOURCE_CONFIG.TXT";
		string codeFileConfig = "NEW_CODESOURCE_CONFIG.cs";

		using (ScriptWritter writer = new ScriptWritter(appExecutableFolder, infoFileConfig, codeFileConfig, regItemData.DataType(), false))
		{
			builder.CreateTableListCodeConfigs(tableList, writer);
		}

		string infoFileContext = "NEW_CODESOURCE_CONTEXT.TXT";
		string codeFileContext = "NEW_CODESOURCE_CONTEXT.cs";

		using (ScriptWritter writer = new ScriptWritter(appExecutableFolder, infoFileContext, codeFileContext, regItemData.DataType(), false))
		{
			builder.CreateTableListCodeContext(tableList, writer);
		}
	}

	private static string ExecutableAppFolder()
	{
		string[] args = Environment.GetCommandLineArgs();

		string appExecutableFileNm = args[0];

		return System.IO.Path.GetDirectoryName(appExecutableFileNm);
	}

	private static void SetUpSchemaSubsets(ref IList<string> subsetTable, ref IList<string> subsetIndex, ref IList<string> subsetRelat,
		ref IList<string> subsetUpdTrigger, ref IList<string> subsetInsTrigger, ref IList<string> subsetQuery)
	{
		subsetTable = new string[] {
				"FIRMA",
				"SVATEK",
				"ADRESA",
				"BANK_SPOJ",
				"ORGANIZACE",
				"UTVAR",
				"DIVIZE_STRED",
				"STRED_CINZAK",
				"STRED_ROZPOCET",
				"STAV_SEMAFOR",
				"UZIVATEL",
				"PRAC_VYBER_AGGR",
				"PRAC",
				"OSDATA",
				"POJISTITEL",
				"HLASENI_ZP",
				"PRAC_NEPRIT",
				"DAN",
				"SRAZKA",
				"PPOMER",
				"PPOMER_DOV",
				"PPOMER_DOV_ROK",
				"PPOMER_MES",
				"PPOMER_SUM",
				"PPOMER_OZP",
				"PPOMER_PRAXE",
				"PPOMER_SLUZBA",
				"PRAC_VZDELAVANI",
				"PRIJMY_SSP",
				"PRIJMY",
				"PRIJMY_1500",
				"PROHLASENI",
				"RODINA",
				"PRIJMY_MES",
				"MZDA",
				"NEPRIT",
				"UVAZEK",
				"UZIV_DATA_PPOMER",
				"UZIV_RELDP_DAVKA",
				"PRAC_RELDP_DATA",
				"PRAC_RELDP_LISTEK",
				"PRAC_RELDP09_DATA_PRAC",
				"PRAC_RELDP09_DATA_POJ",
				"PLATBY_KONFIG",
				"PLATBY_UTVARY",
				"POPLATKY",
				"POPIS_SLOZKA",
				"POPIS_SLOZKA_H",
				"POPIS_SLOZKA_T",
				"TARIFNI_TRIDA",
				"TARIFNI_TRIDA_H",
				"TARIFNI_TRIDA_T",
				"UCETNI_OSNOVA",
				"UCETNI_PREDPISY",
				"UCETNI_POLOZKY",
				"UZIV_CISELNIK",
				"VALUTA_KURZ",
				"VALUTA_KURZ_MES",
				"ZEME_PLATKOEF",
				"ZEME_PLATKOEF_MES",
				"STAV_KONFIG",
				"STAV_KONFIG_UCERT",
				"STAV_KONFIG_SMTP",
				"STAV_KONFIG_VREP",
				"STAV_MES",
				"STAV_MES_DAN",
				"STAV_STAT",
				"STAV_DEFAULT",
				"STAV_OZP",
				"STAV_MESSAGE",
				"DETAIL_MEDIA",
				"FILTR_MEDIA",
				"FILTR_PMEDIA",
				"FILTR_UMEDIA",
				"SESTAVY_FILTR",
				"SESTAVY_LST",
				"SESTAVY_UDATA",
				"SESTAVY_ULST",
				"SESTAVY_HTML",
				"SESTAVY_UZIV",
				"SBERNE_MEDIUM",
				"PLATEBNI_MEDIUM",
				"UCETNI_MEDIUM",
				"NAVESTI_FILTR",
				"NAVESTI_UZIV",
				"PRAC_UKAZATELE",
				"PPOM_UKAZATELE",
				"VREP_PODANI_DATA",
				"EXCEL_UIMP",
                //"IMP_PNR",
                //"IMP_DAVKA",
                //"IMP_01_PRAC",
                //"IMP_51_PRAC",
                //"IMP_02_ZP_VYPLATY",
                //"IMP_03_OSDATA",
                //"IMP_31_PR_ADRESA",
                //"IMP_05_ZDR_POJ",
                //"IMP_06_SOC_POJ",
                //"IMP_07_PRIJMY_PROHL",
                //"IMP_08_PROHL_MES",
                //"IMP_09_DITE",
                //"IMP_17_POMER",
                //"IMP_18_UVAZEK",
                //"IMP_19_MZDA",
                //"IMP_20_NEPRIT",
                //"IMP_21_SRAZKA",
                //"IMP_101_UTVAR",
                //"IMP_102_STRCZ",
                //"ZSEST_DAN_PRIJMY",
                //"ZSEST_DAN_POTVR1500",
                //"ZSEST_DAN_POTVRZENI",
                //"ZSEST_DAN_HLASENI_5478",
                //"ZSEST_DAVKA_UCETNI",
                //"ZSEST_ELDP2004",
                //"ZSEST_MLMESICE",
                //"ZSEST_MLNEPRIT",
                //"ZSEST_MLNEZDAN",
                //"ZSEST_MLPOMERY",
                //"ZSEST_MLPRACOV",
                //"ZSEST_NEM_DAVKY",
                //"ZSEST_PLATBY_CR",
                //"ZSEST_PLATBY_EURO",
                //"ZSEST_PRIJEM_SSP",
                //"ZSEST_REKAPIT",
                //"ZSEST_SOCIAL",
                //"ZSEST_DSPOR_HLASCA",
                //"ZSEST_DSPOR_HLASNA",
                //"ZSEST_DSPOR_VYUCT",
                //"ZSEST_POTVRZ_DP",
                //"MZV_IISSP_PREDPISY",
                //"ZSEST_UZIV_SEST",
                //"ZSEST_VYP_DANE",
                //"ZSEST_VYPL_LISTINY",
                //"ZSEST_VYPL_LISTKY",
                //"ZSEST_VYUCT_ZMENY",
                //"ZSEST_ZDRAV",
                //"ZSEST_ZMENY_ZP",
                //"ZSEST_DPZVD2_VETAD",
                //"ZSEST_DPZVD2_VETAO",
                //"ZSEST_DPZVS2_VETAO",
                //"ZSEST_DPZVD2_VETAE",
                //"ZSEST_DPZVS2_VETAE",
                //"ZSEST_DPZVD2_VETAF",
                //"ZSEST_DPZVD2_VETAG",
                //"ZSEST_DPZVD2_VETAB",
                //"ZSEST_DPZVD2_VETAC",
                //"ZSEST_PPOMER_PRAXE",
                //"ZSEST_POTVRZ_HLAV",
                //"ZSEST_POT313_VEDL",
                //"ZSEST_POT313_NESCH",
                //"ZSEST_POT313_POHL",
                //"ZSEST_POTVRZ_ZP",
                //"ZSEST_POTVRZ_SP",
                //"ZSEST_KONTR_ZDRP",
                //"ZSEST_KONTR_SOCP",
                //"ZSEST_OZNAM_SOCP",
                //"ZSEST_PREHL_SOCP",
                //"ZSEST_PRILOHA_SOCP",
                //"ZSEST_SLEVY_SOCP",
                //"ZSEST_NEM_DAVKY_09",
                //"ZSEST_ZAD_NEM",
                //"ZSEST_ZAD_NEM_NESCH",
                //"ZSEST_ZAD_NEM_ROZHOBD",
                //"ZSEST_ZAD_MAT",
                //"ZSEST_ZAD_MAT_NESCH",
                //"ZSEST_ZAD_MAT_ROZHOBD",
                //"ZSEST_POTVDAV_SSP",
                //"ZSEST_RELDP09_PRAC",
                //"ZSEST_RELDP09_POJ",
                //"ZSEST_PREHVYUCTFIN",
                //"ZSEST_POT_VPT",
                //"ZSEST_POT_VPT_ROZHOBD",
                //"ZSEST_PREHL_ZDRP",
                //"ZSEST_ZADOST_BONUSMR",
                //"ZSEST_POTVVRZ_OSR111",
                //"ZSEST_KARTAZ_ZAKL",
                //"ZSEST_KARTAZ_PPOZ",
                //"ZSEST_KARTAZ_VZDV",
                //"ZSEST_KARTAZ_PPOM",
                //"ZSEST_EXT_MZDLIST",
                //"ZSEST_DAN_ZVYHODNE",
                //"ZSEST_DAN_OZNAMENI",
                //"ZSEST_SOCZDR_PAYMS",
                "STAV_DATABAZE"
			};

		subsetIndex = new string[] {
				"PRAC_VYBER_AGGR",
				"ADRESA",
				"BANK_SPOJ",
				"DAN",
				"DETAIL_MEDIA",
				"DIVIZE_STRED",
				"FILTR_MEDIA",
				"FILTR_PMEDIA",
				"FILTR_UMEDIA",
				"FIRMA",
				"HLASENI_ZP",
				"MZDA",
				"NAVESTI_FILTR",
				"NAVESTI_UZIV",
				"NEPRIT",
				"ORGANIZACE",
				"OSDATA",
				"PLATBY_KONFIG",
				"PLATBY_UTVARY",
				"PLATEBNI_MEDIUM",
				"POJISTITEL",
				"POPIS_SLOZKA",
				"POPIS_SLOZKA_H",
				"POPIS_SLOZKA_T",
				"POPLATKY",
				"PRAC_UKAZATELE",
				"PPOMER",
				"PPOMER_DOV",
				"PPOMER_DOV_ROK",
				"PPOMER_MES",
				"PPOMER_SUM",
				"PPOMER_OZP",
				"PPOMER_PRAXE",
				"PRAC",
				"PRAC_RELDP_DATA",
				"PRAC_RELDP_LISTEK",
				"PRAC_RELDP09_DATA_PRAC",
				"PRAC_RELDP09_DATA_POJ",
				"PRIJMY_SSP",
				"PRIJMY",
				"PRIJMY_MES",
				"PROHLASENI",
				"RODINA",
				"SBERNE_MEDIUM",
				"SESTAVY_FILTR",
				"SESTAVY_LST",
				"SESTAVY_UDATA",
				"SESTAVY_ULST",
				"SESTAVY_HTML",
				"SESTAVY_UZIV",
				"SRAZKA",
				"STAV_KONFIG",
				"STAV_KONFIG_UCERT",
				"STAV_KONFIG_SMTP",
				"STAV_KONFIG_VREP",
				"VREP_PODANI_DATA",
				"STAV_MES",
				"STAV_MES_DAN",
				"STAV_STAT",
				"STAV_DEFAULT",
				"STAV_OZP",
				"STAV_MESSAGE",
				"STAV_SEMAFOR",
				"STRED_CINZAK",
				"STRED_ROZPOCET",
				"SVATEK",
				"TARIFNI_TRIDA",
				"TARIFNI_TRIDA_H",
				"TARIFNI_TRIDA_T",
				"UCETNI_MEDIUM",
				"UCETNI_OSNOVA",
				"UCETNI_PREDPISY",
				"UCETNI_POLOZKY",
				"UTVAR",
				"UVAZEK",
				"UZIV_CISELNIK",
				"UZIV_DATA_PPOMER",
				"UZIV_RELDP_DAVKA",
				"UZIVATEL",
				"VALUTA_KURZ",
				"VALUTA_KURZ_MES",
				"ZEME_PLATKOEF",
				"ZEME_PLATKOEF_MES",
				"PPOMER_SLUZBA",
				"PRAC_NEPRIT",
				"PRAC_VZDELAVANI",
                //"ZSEST_UZIV_SEST",
                //"ZSEST_PPOMER_PRAXE",
                //"ZSEST_EXT_MZDLIST",
                //"IMP_PNR",
                //"IMP_DAVKA",
                //"IMP_01_PRAC",
                //"IMP_51_PRAC",
                //"IMP_02_ZP_VYPLATY",
                //"IMP_03_OSDATA",
                //"IMP_31_PR_ADRESA",
                //"IMP_05_ZDR_POJ",
                //"IMP_06_SOC_POJ",
                //"IMP_07_PRIJMY_PROHL",
                //"IMP_08_PROHL_MES",
                //"IMP_09_DITE",
                //"IMP_17_POMER",
                //"IMP_18_UVAZEK",
                //"IMP_19_MZDA",
                //"IMP_20_NEPRIT",
                //"IMP_21_SRAZKA",
                //"IMP_101_UTVAR",
                //"IMP_102_STRCZ",
            };


		subsetRelat = new string[] {
				"FIRMA",
				"UTVAR",
				"UZIVATEL",
				"ORGANIZACE",
				"STAV_KONFIG",
				"STAV_MES",
				"STRED_CINZAK",
				"PRAC",
				"PRIJMY",
				"UZIV_RELDP_DAVKA",
				"PRAC_RELDP_LISTEK",
				"UZIV_RELDP_DAVKA",
				"PRAC_RELDP09_DATA_PRAC",
				"PPOMER",
				"UZIV_CISELNIK",
				"SESTAVY_LST",
				"NAVESTI_UZIV",
				"POPIS_SLOZKA",
				"UCETNI_PREDPISY",
				"TARIFNI_TRIDA",
				"VALUTA_KURZ",
				"ZEME_PLATKOEF",
				"SBERNE_MEDIUM",
				"PLATEBNI_MEDIUM",
				"UCETNI_MEDIUM"
			};

		subsetUpdTrigger = new string[] {
                //"IMP_DAVKA"
            };

		subsetInsTrigger = new string[] {
                //"IMP_01_PRAC",
                //"IMP_51_PRAC",
                //"IMP_02_ZP_VYPLATY",
                //"IMP_03_OSDATA",
                //"IMP_31_PR_ADRESA",
                //"IMP_05_ZDR_POJ",
                //"IMP_06_SOC_POJ",
                //"IMP_07_PRIJMY_PROHL",
                //"IMP_08_PROHL_MES",
                //"IMP_09_DITE",
                //"IMP_17_POMER",
                //"IMP_18_UVAZEK",
                //"IMP_19_MZDA",
                //"IMP_20_NEPRIT",
                //"IMP_21_SRAZKA",
                //"IMP_101_UTVAR",
                //"IMP_102_STRCZ"
            };

		subsetQuery = new string[] {
				"VYBERUTVARY",
				"VYBERPLMEDIA",
				"VYBERSBMEDIA",
				"VYBERUCMEDIA",
				"VYBERUCET_PRPOLOZKY",
				"VYBERSESTAVY",
				"VYBERRELDPDAVKA",
				"VYBERRELDPDATA",
				"VYBERRELDP09DAVKA",
				"VYBERRELDP09DATA",
				"SUMA_DAN",
				"KROKUJPRACOVNIKY",
				"KROKUJPRAC_POCITANY",
				"VYBERPRAC_POCITANY",
				"VYBERPRAC_ZARAZENI",
				"VYBERPPOM_ZARAZENI",
				"VYBERPRAC_OPRAVNENI",
				"VYBERPRACOVNIKY_FILTR_ZP",
				"VYBERPRACOVNIKY_FILTR_XZ",
				"VYBERPRACOVNIKY_FILTR_XP",
				"VYBERPRACOVNIKY_FILTR_XO",
				"VYBERPRACOVNIKY",
			};
	}
}
