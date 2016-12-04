using OKmzdy.Security.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.AppParams
{
    public class DbsDataConfig
    {

        public string AppNodeName { get; set; }
        public Int32 DbsProvider { get; set; }
        public string DbsFileName { get; set; }
        public string DbsSystemDB { get; set; }
        public string DbsConnServ { get; set; }
        public string DbsConnUser { get; set; }
        public string DbsConnUPsw { get; set; }
        public string DbsDschOwnr { get; set; }
        public string DbsDschOPsw { get; set; }

        public DbsDataConfig()
        {
            Init();
        }

        public void Init()
        {
            DbsProvider = 0;

            AppNodeName = SoftwareDataKeys.EMPTY_STRING;

            DbsFileName = SoftwareDataKeys.EMPTY_STRING;
            DbsSystemDB = SoftwareDataKeys.EMPTY_STRING;
            DbsConnServ = SoftwareDataKeys.EMPTY_STRING;
            DbsConnUser = SoftwareDataKeys.USER_NAME;
            DbsConnUPsw = SoftwareDataKeys.EMPTY_STRING;
            DbsDschOwnr = SoftwareDataKeys.OWNER_NAME;
            DbsDschOPsw = SoftwareDataKeys.EMPTY_STRING;
        }

        public string OwnrName()
        {
            return DbsConnUser;
        }
        public string UserName()
        {
            return DbsDschOwnr;
        }
        public int DataType()
        {
            return DbsProvider;
        }
        public string PlainUsersPsw()
        {
            return CryptoUtils.HashToPlainText(DbsConnUPsw);
        }
        public string PlainOwnerPsw()
        {
            return CryptoUtils.HashToPlainText(DbsDschOPsw);
        }

    }
}
