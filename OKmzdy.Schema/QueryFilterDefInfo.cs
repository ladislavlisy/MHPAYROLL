using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class QueryFilterDefInfo : ICloneable
    {
        public static QueryFilterDefInfo Create(string column, string constOp, string constValue)
        {
            return new QueryFilterDefInfo(column, constOp, constValue);
        }

        private QueryFilterDefInfo(string column, string constOp, string constValue)
        {
            m_strTableColumn = column;
            m_strConstOper = constOp;
            m_strConstValue = constValue;
        }

        public string m_strTableColumn;
        public string m_strConstOper;
        public string m_strConstValue;

        public string TableColumn()
        {
            return m_strTableColumn;
        }

        public string Constraint()
        {
            return m_strConstOper + m_strConstValue;
        }

        public string ConstOper()
        {
            return m_strConstOper;
        }

        public string ConstValue()
        {
            return m_strConstValue;
        }

        public string QueryFilterCondition(string tableAliasName)
        {
            string strFieldNames = "";

            strFieldNames += tableAliasName;
            strFieldNames += ".";
            strFieldNames += m_strTableColumn;
            strFieldNames += m_strConstOper;
            strFieldNames += m_strConstValue;

            return strFieldNames;
        }

        public object Clone()
        {
            QueryFilterDefInfo other = (QueryFilterDefInfo)this.MemberwiseClone();
            other.m_strTableColumn = this.m_strTableColumn;
            other.m_strConstOper = this.m_strConstOper;
            other.m_strConstValue = this.m_strConstValue;

            return other;
        }
    }
}
