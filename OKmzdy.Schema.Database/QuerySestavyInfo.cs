using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    class QuerySocialInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VSEST_SOCIAL";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QuerySocialInfo(lpszOwnerName, lpszUsersName);
        }
        public QuerySocialInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PRAC", TableZsestSocialInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    AliasName.Create("druh_cinnosti", "max_vymzakl"),
                    AliasName.Create("zap_prijem", "sum_prijem"),
                    AliasName.Create("pojist_org", "pojsum_org"),
                    AliasName.Create("pojistne_zam", "pojsum_zam")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("PPOM", TableZsestSocialInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("kod_data"),
                    SimpleName.Create("pracovnik_id"),
                    SimpleName.Create("cislo_pp"),
                    SimpleName.Create("socsprava_id"),
                    SimpleName.Create("info_org"),
                    SimpleName.Create("uplne_jmeno"),
                    SimpleName.Create("rodne_cislo"),
                    SimpleName.Create("ucast_poj"),
                    SimpleName.Create("ppom_stav"),
                    SimpleName.Create("koef_poj"),
                    SimpleName.Create("druh_cinnosti"),
                    SimpleName.Create("zap_prijem"),
                    SimpleName.Create("pojist_org"),
                    SimpleName.Create("pojistne_zam"),
                    SimpleName.Create("vyl_doby"),
                    SimpleName.Create("absence"),
                    SimpleName.Create("nemoc_dny"),
                    SimpleName.Create("nemoc_kc"),
                    SimpleName.Create("osetrovani_dny"),
                    SimpleName.Create("osetrovani_kc"),
                    SimpleName.Create("materstvi_kc"),
                    SimpleName.Create("materstvi_n"),
                    SimpleName.Create("vyrovnani_n"),
                    SimpleName.Create("vyrovnani_kc"),
                    SimpleName.Create("davka_e_kod"),
                    SimpleName.Create("davka_e_kc"),
                    SimpleName.Create("davka_f_kod"),
                    SimpleName.Create("davka_f_kc")
                ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("PRAC", "PPOM").
                AddColumn("firma_id", "firma_id").
                AddColumn("uzivatel_id", "uzivatel_id").
                AddColumn("kod_data", "kod_data").
                AddColumn("pracovnik_id", "pracovnik_id").
                AddColumn("socsprava_id", "socsprava_id").
                AddLeftColumn("cislo_pp", "=", "0").
                AddRightColumn("cislo_pp", "<>", "0"));

        }
    }
    class QueryVyplListkySortInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VSEST_VYPL_LISTKY_SORT";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyplListkySortInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyplListkySortInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("ZSEST_VYPL_LISTKY", TableZsestVyplListkyInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("uzivatel_id"),
                    SimpleName.Create("pracovnik_id"),
                    SimpleName.Create("vlist_info"),
                    SimpleName.Create("radek"),
                    SimpleName.Create("typ"),
                    SimpleName.Create("radtext"),
                    SimpleName.Create("engtext")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("LISTKYP", TableZsestVyplListkyInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    AliasName.Create("typ", "typ_pr"),
                    AliasName.Create("radtext", "text_pr")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("LISTKYU", TableZsestVyplListkyInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    AliasName.Create("typ", "typ_ut"),
                    AliasName.Create("radtext", "text_ut")
                ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("ZSEST_VYPL_LISTKY", "LISTKYP").
                AddColumn("firma_id", "firma_id").
                AddColumn("uzivatel_id", "uzivatel_id").
                AddColumn("pracovnik_id", "pracovnik_id").
                AddRightColumn("typ", "=", "2"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("ZSEST_VYPL_LISTKY", "LISTKYU").
                AddColumn("firma_id", "firma_id").
                AddColumn("uzivatel_id", "uzivatel_id").
                AddColumn("pracovnik_id", "pracovnik_id").
                AddRightColumn("typ", "=", "1"));

        }
    }
    class QueryMzvIIsspPredpisyInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VMZV_IISSP_PREDPISY";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryMzvIIsspPredpisyInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryMzvIIsspPredpisyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("MP", TableMzvIisspPredpisyInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("uzivatel_id"), 
                    SimpleName.Create("vtrideni"),
                    SimpleName.Create("davka_id"), 
                    SimpleName.Create("rok"), 
                    SimpleName.Create("mesic"), 
                    SimpleName.Create("vyuct_cast"), 
                    SimpleName.Create("mena"),
                    SimpleName.Create("castkakc"), 
                    SimpleName.Create("castka_mena"), 
                    SimpleName.Create("kurz_mena"),
                    SimpleName.Create("datum_kurz"), 
                    SimpleName.Create("datum_vypl"), 
                    SimpleName.Create("datum_exp"),
                    SimpleName.Create("id_koruny"), 
                    SimpleName.Create("id_syntet"), 
                    SimpleName.Create("id_paragraf"),
                    SimpleName.Create("id_polozka"), 
                    SimpleName.Create("id_analyt"), 
                    SimpleName.Create("stredisko"), 
                    SimpleName.Create("popis_koruny")
                ));
        }
    }
}
