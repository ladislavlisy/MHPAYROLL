using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class RelationFieldDef : ICloneable
    {
        public string m_strForeignName;
        public string m_strName;

        public RelationFieldDef(string lpszForeignName, string lpszName)
        {
            m_strForeignName = lpszForeignName;
            m_strName = lpszName;
        }

        public void ForeignName(string lpszName)
        {
            m_strForeignName = lpszName;
        }
        public object Clone()
        {
            RelationFieldDef other = (RelationFieldDef)this.MemberwiseClone();
            other.m_strForeignName = this.m_strForeignName;
            other.m_strName = this.m_strName;
            return other;
        }

    }
}
