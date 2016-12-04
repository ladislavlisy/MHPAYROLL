using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class QueryJoinFieldDefInfo : ICloneable
    {
        public QueryJoinFieldDefInfo(string leftColumnName)
        {
            m_bLeftColumnOpValue = false;
            m_bRightColumnOpValue = false;
            m_strTableLeftColumn = leftColumnName;
            m_strTableRightColumn = leftColumnName;
        }

        public QueryJoinFieldDefInfo(string leftColumnName, string rightColumnName)
        {
            m_bLeftColumnOpValue = false;
            m_strTableLeftColumn = leftColumnName;
            m_strTableRightColumn = rightColumnName;
        }

        public QueryJoinFieldDefInfo(bool bLeftColumn, string columnName, string columnOper, string columnValue)
        {
            m_bLeftColumnOpValue = false;
            m_bRightColumnOpValue = false;
            if (bLeftColumn)
            {
                m_bLeftColumnOpValue = true;
                m_strTableLeftColumn = columnName;
                m_strTableRightColumn = columnOper + columnValue;
            }
            else
            {
                m_bRightColumnOpValue = true;
                m_strTableRightColumn = columnName;
                m_strTableLeftColumn = columnOper + columnValue;
            }
        }

        public bool m_bLeftColumnOpValue;
        public string m_strTableLeftColumn;
        public bool m_bRightColumnOpValue;
        public string m_strTableRightColumn;

        public string LeftColumnName()
        {
            return m_strTableLeftColumn;
        }

        public string RightColumnName()
        {
            return m_strTableRightColumn;
        }

        public string JoinCondition(string leftSourceAlias, string rightSourceAlias, bool bJoinConds, bool bFilterConds)
        {
            string strFieldNames = "";

            if (m_bLeftColumnOpValue)
            {
                if (bFilterConds)
                {
                    strFieldNames += leftSourceAlias;
                    strFieldNames += ".";
                    strFieldNames += m_strTableLeftColumn;
                    strFieldNames += m_strTableRightColumn;
                }
            }
            else if (m_bRightColumnOpValue)
            {
                if (bFilterConds)
                {
                    strFieldNames += rightSourceAlias;
                    strFieldNames += ".";
                    strFieldNames += m_strTableRightColumn;
                    strFieldNames += m_strTableLeftColumn;
                }
            }
            else
            {
                if (bJoinConds)
                {
                    strFieldNames += leftSourceAlias;
                    strFieldNames += ".";
                    strFieldNames += m_strTableLeftColumn;
                    strFieldNames += " = ";
                    strFieldNames += rightSourceAlias;
                    strFieldNames += ".";
                    strFieldNames += m_strTableRightColumn;
                }
            }

            return strFieldNames;
        }
        public object Clone()
        {
            QueryJoinFieldDefInfo other = (QueryJoinFieldDefInfo)this.MemberwiseClone();
            other.m_bLeftColumnOpValue = this.m_bLeftColumnOpValue;
            other.m_strTableLeftColumn = this.m_strTableLeftColumn;
            other.m_bRightColumnOpValue = this.m_bRightColumnOpValue;
            other.m_strTableRightColumn = this.m_strTableRightColumn;

            return other;
        }

    }
}
