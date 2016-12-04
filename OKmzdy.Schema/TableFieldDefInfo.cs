using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class TableFieldDefInfo : ICloneable
    {
        public TableFieldDefInfo(UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            m_strName = "";
            m_nType = 0;

            m_lCollatingOrder = 0;
            m_nOrdinalPosition = 0;
            m_strDefaultValue = "";
            m_strValidationRule = "";
            m_strValidationText = "";
            m_lAttributes = DBConstants.dbFixedField | DBConstants.dbUpdatableField;
            m_lSize = 0;
            m_bRequired = false;
            m_bAllowZeroLength = false;
            m_VersFrom = versFrom;
            m_VersDrop = versDrop;
        }

        public string m_strName;
        public int m_nType;

        public int m_lCollatingOrder;
        public int m_nOrdinalPosition;
        public string m_strDefaultValue;
        public string m_strValidationRule;
        public string m_strValidationText;
        public int m_lAttributes;
        public int m_lSize;
        public bool m_bRequired;
        public bool m_bAllowZeroLength;
        protected UInt32 m_VersFrom = 0;
        protected UInt32 m_VersDrop = 9999;

        public bool IsValidInVersion(UInt32 versCreate)
        {
            return (m_VersFrom <= versCreate && versCreate < m_VersDrop);
        }

        public string ColumnName()
        {
            return m_strName;
        }

        public string ColumnCamelName()
        {
            return NameConversions.CamelName(m_strName);
        }

        public void ReNameColumn(string newName)
        {
            m_strName = newName;
        }

        public bool IsAutoIncrement()
        {
            return DBPlatform.AutoIncrField(m_lAttributes);
        }

        public int DbColumnSize()
        {
            return DBPlatform.DataTypeSize(m_nType, m_lSize);
        }

        public bool DbColumnNull()
        {
            return !m_bRequired;
        }

        public bool IncludeColumnType()
        {
            bool bColumnTypeEx = true;
            switch (m_nType)
            {
                case DBConstants.DB_BOOLEAN:
                case DBConstants.DB_BYTE:
                case DBConstants.DB_INTEGER:
                case DBConstants.DB_LONG:
                case DBConstants.DB_TEXT:
                case DBConstants.DB_DATE:
                case DBConstants.DB_SINGLE:
                case DBConstants.DB_DOUBLE:
                    bColumnTypeEx = true;
                    break;
                case DBConstants.DB_CURRENCY:
                case DBConstants.DB_LONGBINARY:
                case DBConstants.DB_MEMO:
                case DBConstants.DB_GUID:
                    bColumnTypeEx = false;
                    break;
                default:
                    break;
            }
            return (bColumnTypeEx);
        }

        public object Clone()
        {
            TableFieldDefInfo other = (TableFieldDefInfo)this.MemberwiseClone();
            other.m_strName = this.m_strName;
            other.m_nType = this.m_nType;

            other.m_lCollatingOrder = this.m_lCollatingOrder;
            other.m_nOrdinalPosition = this.m_nOrdinalPosition;
            other.m_strDefaultValue = this.m_strDefaultValue;
            other.m_strValidationRule = this.m_strValidationRule;
            other.m_strValidationText = this.m_strValidationText;
            other.m_lAttributes = this.m_lAttributes;
            other.m_lSize = this.m_lSize;
            other.m_bRequired = this.m_bRequired;
            other.m_bAllowZeroLength = this.m_bAllowZeroLength;
            other.m_VersFrom = this.m_VersFrom;
            other.m_VersDrop = this.m_VersDrop;

            return other;
        }
    }
}
