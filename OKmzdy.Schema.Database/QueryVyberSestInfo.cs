using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    class QueryVyberSestavyInfo : QueryDefInfo
    {
        const string TABLE_NAME = "VYBERSESTAVY";

        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static QueryDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new QueryVyberSestavyInfo(lpszOwnerName, lpszUsersName);
        }
        public QueryVyberSestavyInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME, 1600)
        {
            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("SLST", TableSestavyLstInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("firma_id"),
                    SimpleName.Create("kod_lst"),
                    SimpleName.Create("kod_data"),
                    SimpleName.Create("druh"),
                    SimpleName.Create("typ_lst"),
                    SimpleName.Create("trideni"),
                    SimpleName.Create("nazev"),
                    SimpleName.Create("soubor"),
                    SimpleName.Create("skupina"),
                    SimpleName.Create("subjekt_id"),
                    SimpleName.Create("informace")
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UDATA", TableSestavyUdataInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("vytvor_vyuc"),
                    SimpleName.Create("vyuct_dat"),
                    SimpleName.Create("mesic_od"),
                    SimpleName.Create("mesic_do"),
                    SimpleName.Create("rok"),
                    SimpleName.Create("vytvor_txt"),
                    SimpleName.Create("vytvor_dat")
                 ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("ULST", TableSestavyUlstInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                   SimpleName.Create("tisknout"),
                   SimpleName.Create("sestavy_id"),
                   SimpleName.Create("pg_margins"),
                   SimpleName.Create("papir"),
                   SimpleName.Create("tridit"),
                   SimpleName.Create("exp_cesta"),
                   SimpleName.Create("lst_param"),
                   SimpleName.Create("txt_param"),
                   SimpleName.Create("msg_param"),
                   SimpleName.Create("filtr_zobr")     
                ));

            AddTable(QueryTableDefInfo.GetQueryAliasDefInfo("UZ", TableUzivatelInfo.GetDictValue(lpszOwnerName, lpszUsersName)).
                AddColumns(
                    SimpleName.Create("uuzivatel_id"),
                    AliasName.Create("sestavy_id", "usestavy_id")
                ));

            AddTableJoin(QueryJoinDefInfo.GetQueryFirstJoinDefInfo("SLST", "UDATA").
                AddColumn("firma_id", "firma_id").
                AddColumn("kod_data", "kod_data"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("SLST", "ULST").
                AddColumn("firma_id", "firma_id").
                AddColumn("kod_lst", "kod_lst").
                AddRightColumn("uzivatel_id", "=", "UDATA.uzivatel_id"));

            AddTableJoin(QueryJoinDefInfo.GetQueryJoinDefInfo("ULST", "UZ").
                AddColumn("firma_id", "firma_id").
                AddColumn("uzivatel_id", "uuzivatel_id"));

        }
    }
}
