using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.AppParams
{
    public class SoftwareUserData : DbsDataConfig
    {
        public Int32 AppUIcolors {get; set;}
        public Int32 DbsProvVers {get; set;}
        public Int32 DbsExclusiv {get; set;}
        public Int32 DbsSysDBShr {get; set;}

        public Int32 BitmapyTisk { get; set; }

        public string DbsDSrcName { get; set; }
        public string SouboryArch { get; set; }
        public string SouboryBkup { get; set; }
        public string SouboryTisk { get; set; }
        public string SouboryTXML { get; set; }
        public string SouboryTPDF { get; set; }
        public string SouboryTXLS { get; set; }
        public string CmdLineExpt { get; set; }
        public string CmdLineImpt { get; set; }
        public string DbfDrivImpt { get; set; }
        public string ExpUMuvozov { get; set; }

        public Int32 DbsHRLink { get; set; }
        public Int32 RemovePrac { get; set; }

        public SoftwareUserData()
        {
            Init();
        }

        public new void Init()
        {
            base.Init();

            AppUIcolors = 0;
            DbsProvVers = 0;
            DbsExclusiv = 1;
            DbsSysDBShr = -1;
            BitmapyTisk = 0;

            DbsDSrcName = SoftwareDataKeys.EMPTY_STRING;
            SouboryArch = SoftwareDataKeys.EMPTY_STRING;
            SouboryBkup = SoftwareDataKeys.EMPTY_STRING;
            SouboryTisk = SoftwareDataKeys.EMPTY_STRING;
            SouboryTXML = SoftwareDataKeys.EMPTY_STRING;
            SouboryTPDF = SoftwareDataKeys.EMPTY_STRING;
            SouboryTXLS = SoftwareDataKeys.EMPTY_STRING;
            CmdLineExpt = SoftwareDataKeys.EMPTY_STRING;
            CmdLineImpt = SoftwareDataKeys.EMPTY_STRING;
            DbfDrivImpt = SoftwareDataKeys.FOXBASE_DRIVER;
            ExpUMuvozov = SoftwareDataKeys.QUOTES;

            DbsHRLink = 0;
            RemovePrac = 0;
        }
    }
}
