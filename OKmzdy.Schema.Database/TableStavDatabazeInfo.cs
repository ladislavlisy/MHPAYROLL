using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Database
{
    public class TableStavDatabazeInfo : TableDefInfo
    {
        const string TABLE_NAME = "STAV_DATABAZE";
        public static string GetNameKey()
        {
            return TABLE_NAME;
        }
        public static TableDefInfo GetDictValue(string lpszOwnerName, string lpszUsersName)
        {
            return new TableStavDatabazeInfo(lpszOwnerName, lpszUsersName);
        }
        public TableStavDatabazeInfo(string lpszOwnerName, string lpszUsersName) :
            base(lpszOwnerName, lpszUsersName, TABLE_NAME)
        {
            CreateField("verze", DB_LONG, dbNotNullFieldOption);
            CreateFTEXT("heslo", DB_TEXT, 80, dbNullFieldOption);
        }
    }
}
