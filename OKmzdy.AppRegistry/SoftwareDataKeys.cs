using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.AppParams
{
    public static class SoftwareDataKeys
    {
        public const int DATA_PROVIDER_JET3 = 1;
        public const int DATA_PROVIDER_SQLITE = 2;
        public const int DATA_PROVIDER_XDBF = 3;
        public const int DATA_PROVIDER_ODBC_ORACLE = 6;
        public const int DATA_PROVIDER_ODBC_MSSQL = 10;
        public const int DATA_PROVIDER_ODBC_IMSSQL = 18;

        public const string REG_ITEM_REMPRAC = "remove_prac";
        public const string REG_ITEM_UICOLOR = "App UI colors";
        public const string REG_ITEM_DBSPROV = "Database Provider";
        public const string REG_ITEM_DBSHRMG = "Database HRLink";
        public const string REG_ITEM_ACEVERS = "Access ACE Version";
        public const string REG_ITEM_DBSNAME = "Database Name";
        public const string REG_ITEM_ODBCDSN = "Database DSN";
        public const string REG_ITEM_ODBCSRV = "Database Server";
        public const string REG_ITEM_DBEXCLS = "Database Exclusive";
        public const string REG_ITEM_DBSARCH = "Database Archiv";
        public const string REG_ITEM_DBSBKUP = "Database Backup";
        public const string REG_ITEM_PRNFILE = "Tiskove Soubory";
        public const string REG_ITEM_XMLFILE = "XML Soubory";
        public const string REG_ITEM_PDFFILE = "PDF Soubory";
        public const string REG_ITEM_XLSFILE = "XLS Soubory";
        public const string REG_ITEM_DBSUSER = "Database User";
        public const string REG_ITEM_DBSUPSW = "Database Psw";
        public const string REG_ITEM_DBSOWNR = "Database Owner";
        public const string REG_ITEM_DBSOPSW = "Database Owner Psw";
        public const string REG_ITEM_DBSCMDE = "Database CmdExp";
        public const string REG_ITEM_DBSCMDI = "Database CmdImp";
        public const string REG_ITEM_ODBCDBF = "ODBC Driver Dbf";
        public const string REG_ITEM_EXUMUVZ = "ExportUM uvozovky";
        public const string REG_ITEM_ENSHARE = "SystemDB Shared";
        public const string REG_ITEM_ENGINES = "Engines";
        public const string REG_ITEM_DBSSYST = "SystemDB";
        public const string REG_ITEM_TISKBMP = "Tisknout Bitmapy";
        public const string REG_ITEM_PARFLDR = "App Parent Folder";
        public const string REG_ITEM_DBSFLDR = "App Database Folder";
        public const string REG_ITEM_ARCFLDR = "App Archiv Folder";
        public const string REG_ITEM_BAKFLDR = "App Backup Folder";
        public const string REG_ITEM_TISFLDR = "App Tiskovy Folder";
        public const string REG_ITEM_LNKFLDR = "Shortcut Folder";
        public const string REG_ITEM_LNKDESK = "Shortcut Desktop";
        public const string REG_ITEM_SDBUSER = "SQL server User";
        public const string REG_ITEM_SDBPSSW = "SQL server User Psw";
        public const string REG_ITEM_WKSARCH = "SQL archiv wks";
        public const string REG_ITEM_SRVARCH = "SQL archiv srv";
        public const string REG_ITEM_XMLRECENT = "Recent_XML_%d";
        public const string REG_ITEM_PDFRECENT = "Recent_PDF_%d";
        public const string REG_ITEM_XLSRECENT = "Recent_XLS_%d";
        public const string REG_ITEM_TXTRECENT = "Recent_TXT_%d";

        public const string EMPTY_STRING = "";
        public const string QUOTES = "\"";
        public const string USER_NAME = "okmzdy";
        public const string OWNER_NAME = "oksystem";
        public const string FOXBASE_DRIVER = "FoxPro 2.0;";
    }
}
