using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.AppParams
{
    public class SoftwareMainData
    {
        public Int32 ShortcutDesktop { get; set; }
        public Int32 AccessAceVers { get; set; }

        public string ArchivFolder { get; set; }
        public string DatabaseFolder { get; set; }
        public string DatabaseName { get; set; }
        public string ParentFolder { get; set; }
        public string ShortcutFolder { get; set; }
        public string SystemDB { get; set; }
        public string TiskyFolder { get; set; }
        public string MsSqlServ { get; set; }
        public string MsSqlUser { get; set; }
        public string MsSqlUserPsw { get; set; }
        public string MsSqlOwnr { get; set; }
        public string MsSqlOwnrPsw { get; set; }
        public string MsSqlSdba { get; set; }
        public string MsSqlSdbaPsw { get; set; }
        public string MsSqlWksArch { get; set; }
        public string MsSqlSrvArch { get; set; }

        public SoftwareMainData()
        {
            Init();
        }

        public void Init()
        {
            ShortcutDesktop = 0;
            AccessAceVers = 0;

            ArchivFolder = SoftwareDataKeys.EMPTY_STRING;
            DatabaseFolder = SoftwareDataKeys.EMPTY_STRING;
            DatabaseName = SoftwareDataKeys.EMPTY_STRING;
            ParentFolder = SoftwareDataKeys.EMPTY_STRING;
            ShortcutFolder = SoftwareDataKeys.EMPTY_STRING;
            SystemDB = SoftwareDataKeys.EMPTY_STRING;
            TiskyFolder = SoftwareDataKeys.EMPTY_STRING;
            MsSqlServ = SoftwareDataKeys.EMPTY_STRING;
            MsSqlUser = SoftwareDataKeys.EMPTY_STRING;
            MsSqlUserPsw = SoftwareDataKeys.EMPTY_STRING;
            MsSqlOwnr = SoftwareDataKeys.EMPTY_STRING;
            MsSqlOwnrPsw = SoftwareDataKeys.EMPTY_STRING;
            MsSqlSdba = SoftwareDataKeys.EMPTY_STRING;
            MsSqlSdbaPsw = SoftwareDataKeys.EMPTY_STRING;
            MsSqlWksArch = SoftwareDataKeys.EMPTY_STRING;
            MsSqlSrvArch = SoftwareDataKeys.EMPTY_STRING;
        }

    }
}
