using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    enum DataTypeEnum
    {
        dbBoolean = 1,
        dbByte = 2,
        dbInteger = 3,
        dbLong = 4,
        dbCurrency = 5,
        dbSingle = 6,
        dbDouble = 7,
        dbDate = 8,
        dbBinary = 9,
        dbText = 10,
        dbLongBinary = 11,
        dbMemo = 12,
        dbGUID = 15,
        dbBigInt = 16,
        dbVarBinary = 17,
        dbChar = 18,
        dbNumeric = 19,
        dbDecimal = 20,
        dbFloat = 21,
        dbTime = 22,
        dbTimeStamp = 23
    };

    enum RelationAttributeEnum
    {
        dbRelationUnique = 0x1,
        dbRelationDontEnforce = 0x2,
        dbRelationInherited = 0x4,
        dbRelationUpdateCascade = 0x100,
        dbRelationDeleteCascade = 0x1000,
        dbRelationLeft = 0x1000000,
        dbRelationRight = 0x2000000
    };

    enum FieldAttributeEnum
    {
        dbFixedField = 0x1,
        dbVariableField = 0x2,
        dbAutoIncrField = 0x10,
        dbUpdatableField = 0x20,
        dbSystemField = 0x2000,
        dbHyperlinkField = 0x8000,
        dbDescending = 0x1
    };

    public static class DBConstants
    {
        public static readonly char[] TRIM_CHARS = { '\r', '\n', '\t', ' ', ',' };
        public static readonly char[] SPLIT_CHARS = { '\n' };
        public static readonly string SPLIT_STRC = "\n";

        public const string EMPTY_STRING = "";
        public const string NEW_LINE_STR = "\n";
        public const int MAX_DB_TEXT = 255;
        public const int DB_SINGLE = (int)DataTypeEnum.dbSingle;
        public const int DB_TEXT = (int)DataTypeEnum.dbText;
        public const int DB_BOOLEAN = (int)DataTypeEnum.dbBoolean;
        public const int DB_BYTE = (int)DataTypeEnum.dbByte;
        public const int DB_CURRENCY = (int)DataTypeEnum.dbCurrency;
        public const int DB_DATE = (int)DataTypeEnum.dbDate;
        public const int DB_DATETIME = (int)DataTypeEnum.dbDate;
        public const int DB_DOUBLE = (int)DataTypeEnum.dbDouble;
        public const int DB_INTEGER = (int)DataTypeEnum.dbInteger;
        public const int DB_LONG = (int)DataTypeEnum.dbLong;
        public const int DB_LONGBINARY = (int)DataTypeEnum.dbLongBinary;
        public const int DB_MEMO = (int)DataTypeEnum.dbMemo;
        public const int DB_GUID = (int)DataTypeEnum.dbGUID;
        public const int DB_RELATIONDELETECASCADE = (int)RelationAttributeEnum.dbRelationDeleteCascade;
        public const int DB_RELATIONDONTENFORCE = (int)RelationAttributeEnum.dbRelationDontEnforce;
        public const int DB_RELATIONINHERITED = (int)RelationAttributeEnum.dbRelationInherited;
        public const bool dbNotNullFieldOption = false;
        public const bool dbNullFieldOption = true;
        public const int dbFixedField = (int)FieldAttributeEnum.dbFixedField;
        public const int dbUpdatableField = (int)FieldAttributeEnum.dbUpdatableField;
        public const int dbAutoIncrField = (int)FieldAttributeEnum.dbAutoIncrField;
        public const string COLUMN_NAME_AUTOID = "id";

    }
    public static class NameConversions
    {
        public static string TransformName(Tuple<string, string>[] transformations, string name)
        {
            return transformations.Aggregate(name, (agr, x) => agr.Replace(x.Item1, x.Item2));
        }

        public static string CamelName(string name)
        {
            return name.Underscore().Camelize();
        }
        public static string ConvertCamelName(string name)
        {
            return name.ConvertNameToCamel();
        }
    }
    public static class DBPlatform
    {
        public const int DATA_PROVIDER_JET35 = 1;
        public const int DATA_PROVIDER_SQLITE = 2;
        public const int DATA_PROVIDER_ODBC_ORACLE = 6;
        public const int DATA_PROVIDER_ODBC_MSSQL = 10;
        public const int DATA_PROVIDER_ODBC_IMSSQL = 18;

        public static bool IsMsJetType(int type)
        {
            return (type == DATA_PROVIDER_JET35);
        }

        public static bool IsOracleType(int type)
        {
            return (type == DATA_PROVIDER_ODBC_ORACLE);
        }

        public static bool IsMsSQLType(int type)
        {
            return (type == DATA_PROVIDER_ODBC_MSSQL || type == DATA_PROVIDER_ODBC_IMSSQL);
        }

        public static bool IsSQLiteType(int type)
        {
            return (type == DATA_PROVIDER_SQLITE);
        }

        public static string GDateDefault(int type)
        {
            if (IsMsJetType(type))
            {
                return ""; // "DEFAULT GETDATE()";
            }
            else if (IsMsSQLType(type))
            {
                return "DEFAULT GETDATE()";
            }
            else if (IsOracleType(type))
            {
                return "DEFAULT SYSDATE";
            }
            else if (IsSQLiteType(type))
            {
                return "DEFAULT CURRENT_TIMESTAMP";
            }
            return DBConstants.EMPTY_STRING;
        }

        public static string GDateValue(int type, DateTime? value)
        {
            string dataColumn = DBConstants.EMPTY_STRING;
            if (value.HasValue)
            {
                if (IsMsJetType(type))
                {
                    dataColumn += "DateValue('";
                    dataColumn += value.Value.ToString("yyyy-MM-dd"); //String.Format("{0:YYYY-MM-DD}", datum.Value)
                    dataColumn += "')";
                }
                else if (IsMsSQLType(type))
                {
                    dataColumn += "PARSE('";
                    dataColumn += value.Value.ToString("yyyy-MM-dd"); //String.Format("{0:YYYY-MM-DD}", datum.Value)
                    dataColumn += "' AS date USING 'en-US')";
                }
                else if (IsOracleType(type))
                {
                    dataColumn += "TO_DATE('";
                    dataColumn += value.Value.ToString("dd.MM.yyyy");
                    dataColumn += "')";
                }
                else if (IsSQLiteType(type))
                {
                    dataColumn += "datetime('";
                    dataColumn += value.Value.ToString("yyyy-MM-dd"); //String.Format("{0:YYYY-MM-DD}", datum.Value)
                    dataColumn += "')";
                }
            }
            else
            {
                dataColumn += "NULL";
            }
            return dataColumn;
        }

        public static string NumberDefault(int type)
        {
            if (IsMsJetType(type))
            {
                return "DEFAULT 0";
            }
            else if (IsMsSQLType(type))
            {
                return "DEFAULT (0)";
            }
            else if (IsOracleType(type))
            {
                return "DEFAULT (0)";
            }
            else if (IsSQLiteType(type))
            {
                return "DEFAULT (0)";
            }
            return DBConstants.EMPTY_STRING;
        }

        public static bool DefaultBindRequired(int lAttributes)
        {
            int lAutoIncrField = (lAttributes & DBConstants.dbAutoIncrField);

            return (lAutoIncrField == 0);
        }

        public static bool DefaultBindDataType(int nType)
        {
            bool bBindDefault = false;
            switch (nType)
            {
                case DBConstants.DB_BOOLEAN:
                case DBConstants.DB_BYTE:
                case DBConstants.DB_INTEGER:
                case DBConstants.DB_LONG:
                    bBindDefault = true;
                    break;
            }
            return (bBindDefault);
        }

        public static bool AutoIncrField(int lAttributes)
        {
            int lAutoIncrField = (lAttributes & DBConstants.dbAutoIncrField);

            return (lAutoIncrField == DBConstants.dbAutoIncrField);
        }

        public static string OracleConvertDataType(int nType, int nSize)
        {
            string strFieldType = "";
            string strFieldTempl;
            string strFieldS2Add;

            switch (nType)
            {
                case DBConstants.DB_BOOLEAN:
                    strFieldType = "NUMBER(1)";
                    break;
                case DBConstants.DB_BYTE:
                    strFieldType = "NUMBER(3)";
                    break;
                case DBConstants.DB_INTEGER:
                    strFieldType = "NUMBER(5)";
                    break;
                case DBConstants.DB_LONG:
                    strFieldType = "NUMBER(11)";
                    break;
                case DBConstants.DB_TEXT:
                    strFieldTempl = "varchar2({{0} CHAR)";
                    strFieldS2Add = String.Format(strFieldTempl, nSize);
                    strFieldType += strFieldS2Add;
                    break;
                case DBConstants.DB_DATE:
                    strFieldType = "DATE";
                    break;
                case DBConstants.DB_CURRENCY:
                    break;
                case DBConstants.DB_SINGLE:
                    strFieldType = "float";
                    break;
                case DBConstants.DB_DOUBLE:
                    strFieldType = "float";
                    break;
                case DBConstants.DB_LONGBINARY:
                    strFieldType = "BLOB";
                    break;
                case DBConstants.DB_MEMO:
                    break;
                case DBConstants.DB_GUID:
                    break;
                default:
                    break;
            }
            return strFieldType;
        }

        public static string MsSQLConvertDataType(int nType, int nSize)
        {
            string strFieldType = "";
            string strFieldTempl;
            string strFieldS2Add;

            switch (nType)
            {
                case DBConstants.DB_BOOLEAN:
                    strFieldType = "bit";
                    break;
                case DBConstants.DB_BYTE:
                    strFieldType = "tinyint";
                    break;
                case DBConstants.DB_INTEGER:
                    strFieldType = "smallint";
                    break;
                case DBConstants.DB_LONG:
                    strFieldType = "int";
                    break;
                case DBConstants.DB_TEXT:
                    strFieldTempl = "varchar({0})";
                    strFieldS2Add = String.Format(strFieldTempl, nSize);
                    strFieldType = strFieldS2Add;
                    break;
                case DBConstants.DB_DATE:
                    strFieldType = "datetime";
                    break;
                case DBConstants.DB_CURRENCY:
                    break;
                case DBConstants.DB_SINGLE:
                    strFieldType = "float";
                    break;
                case DBConstants.DB_DOUBLE:
                    strFieldType = "float";
                    break;
                case DBConstants.DB_LONGBINARY:
                    strFieldType = "varbinary(MAX)";
                    break;
                case DBConstants.DB_MEMO:
                    break;
                case DBConstants.DB_GUID:
                    break;
                default:
                    break;
            }
            return strFieldType;
        }

        public static string MsJetConvertDataType(int nType, int nSize)
        {
            string strFieldType = "";
            string strFieldTempl;
            string strFieldS2Add;

            switch (nType)
            {
                case DBConstants.DB_BOOLEAN:
                    strFieldType = "BIT";
                    break;
                case DBConstants.DB_BYTE:
                    strFieldType = "BYTE";
                    break;
                case DBConstants.DB_INTEGER:
                    strFieldType = "SHORT";
                    break;
                case DBConstants.DB_LONG:
                    strFieldType = "LONG";
                    break;
                case DBConstants.DB_TEXT:
                    strFieldTempl = "VARCHAR({0})";
                    strFieldS2Add = String.Format(strFieldTempl, nSize);
                    strFieldType = strFieldS2Add;
                    break;
                case DBConstants.DB_DATE:
                    strFieldType = "DATETIME";
                    break;
                case DBConstants.DB_CURRENCY:
                    break;
                case DBConstants.DB_SINGLE:
                    strFieldType = "SINGLE";
                    break;
                case DBConstants.DB_DOUBLE:
                    strFieldType = "DOUBLE";
                    break;
                case DBConstants.DB_LONGBINARY:
                    strFieldType = "LONGBINARY";
                    break;
                case DBConstants.DB_MEMO:
                    break;
                case DBConstants.DB_GUID:
                    break;
                default:
                    break;
            }
            return strFieldType;
        }

        public static string SqliteConvertDataType(int nType, int nSize)
        {
            string strFieldType = "";
            string strFieldTempl;
            string strFieldS2Add;

            switch (nType)
            {
                case DBConstants.DB_BOOLEAN:
                    strFieldType = "INT2";
                    break;
                case DBConstants.DB_BYTE:
                    strFieldType = "TINYINT";
                    break;
                case DBConstants.DB_INTEGER:
                    strFieldType = "SMALLINT";
                    break;
                case DBConstants.DB_LONG:
                    strFieldType = "INT";
                    break;
                case DBConstants.DB_TEXT:
                    strFieldTempl = "VARCHAR({0})";
                    strFieldS2Add = String.Format(strFieldTempl, nSize);
                    strFieldType = strFieldS2Add;
                    break;
                case DBConstants.DB_DATE:
                    strFieldType = "DATETIME";
                    break;
                case DBConstants.DB_CURRENCY:
                    break;
                case DBConstants.DB_SINGLE:
                    strFieldType = "FLOAT";
                    break;
                case DBConstants.DB_DOUBLE:
                    strFieldType = "FLOAT";
                    break;
                case DBConstants.DB_LONGBINARY:
                    strFieldType = "BLOB";
                    break;
                case DBConstants.DB_MEMO:
                    break;
                case DBConstants.DB_GUID:
                    break;
                default:
                    break;
            }
            return strFieldType;
        }

        public static string EntityConvertDataType(int nType, int nSize, bool bRequired)
        {
            string strFieldType = "";

            switch (nType)
            {
                case DBConstants.DB_BOOLEAN:
                    strFieldType = "bool";
                    break;
                case DBConstants.DB_BYTE:
                    strFieldType = "byte";
                    break;
                case DBConstants.DB_INTEGER:
                    strFieldType = "Int16";
                    break;
                case DBConstants.DB_LONG:
                    strFieldType = "Int32";
                    break;
                case DBConstants.DB_TEXT:
                    strFieldType = "string";
                    break;
                case DBConstants.DB_DATE:
                    strFieldType = "DateTime";
                    break;
                case DBConstants.DB_CURRENCY:
                    break;
                case DBConstants.DB_SINGLE:
                    strFieldType = "double";
                    break;
                case DBConstants.DB_DOUBLE:
                    strFieldType = "double";
                    break;
                case DBConstants.DB_LONGBINARY:
                    strFieldType = "byte[]";
                    break;
                case DBConstants.DB_MEMO:
                    break;
                case DBConstants.DB_GUID:
                    break;
                default:
                    break;
            }
            return strFieldType;
        }

        public static string ModelConvertDataType(int nType, int nSize, bool bRequired)
        {
            string strFieldType = "";

            switch (nType)
            {
                case DBConstants.DB_BOOLEAN:
                    strFieldType = "boolean";
                    break;
                case DBConstants.DB_BYTE:
                    strFieldType = "integer";
                    break;
                case DBConstants.DB_INTEGER:
                    strFieldType = "integer";
                    break;
                case DBConstants.DB_LONG:
                    strFieldType = "integer";
                    break;
                case DBConstants.DB_TEXT:
                    strFieldType = "string";
                    break;
                case DBConstants.DB_DATE:
                    strFieldType = "datetime";
                    break;
                case DBConstants.DB_CURRENCY:
                    break;
                case DBConstants.DB_SINGLE:
                    strFieldType = "float";
                    break;
                case DBConstants.DB_DOUBLE:
                    strFieldType = "float";
                    break;
                case DBConstants.DB_LONGBINARY:
                    strFieldType = "byte[]";
                    break;
                case DBConstants.DB_MEMO:
                    break;
                case DBConstants.DB_GUID:
                    break;
                default:
                    break;
            }
            return strFieldType;
        }


        public static int DataTypeSize(int nType, int columnSize)
        {
            int nDbTypeSize = 0;
            switch (nType)
            {
                case DBConstants.DB_BOOLEAN:
                    nDbTypeSize = 1;
                    break;
                case DBConstants.DB_BYTE:
                    nDbTypeSize = 1;
                    break;
                case DBConstants.DB_INTEGER:
                    nDbTypeSize = 8;
                    break;
                case DBConstants.DB_LONG:
                    nDbTypeSize = 8;
                    break;
                case DBConstants.DB_TEXT:
                    nDbTypeSize = columnSize;
                    break;
                case DBConstants.DB_DATE:
                    nDbTypeSize = 8;
                    break;
                case DBConstants.DB_CURRENCY:
                    break;
                case DBConstants.DB_SINGLE:
                    nDbTypeSize = 4;
                    break;
                case DBConstants.DB_DOUBLE:
                    nDbTypeSize = 8;
                    break;
                case DBConstants.DB_LONGBINARY:
                    nDbTypeSize = columnSize;
                    break;
                case DBConstants.DB_MEMO:
                    break;
                case DBConstants.DB_GUID:
                    break;
                default:
                    break;
            }
            return nDbTypeSize;
        }
        public static bool TypeIsNumber(int nType)
        {
            switch (nType)
            {
                case DBConstants.DB_BOOLEAN:
                case DBConstants.DB_BYTE:
                case DBConstants.DB_INTEGER:
                case DBConstants.DB_LONG:
                    return true;
                default:
                    break;
            }
            return false;
        }
        public static bool TypeIsDate(int nType)
        {
            if (nType == DBConstants.DB_DATE)
            {
                return true;
            }
            return false;
        }
    }
}
