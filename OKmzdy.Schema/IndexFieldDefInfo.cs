using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class IndexFieldDefInfo
    {
        public string m_strName;
        public bool m_bDescending;

        public IndexFieldDefInfo(string lpszName, bool descending = false)
        {
            m_strName = lpszName;
            m_bDescending = descending;
        }

        public string FieldInfo(bool primary)
        {
            string strFieldInfo = m_strName;
            if (!primary)
            {
                if (m_bDescending)
                {
                    strFieldInfo += (" DESC");
                }
                else
                {
                    strFieldInfo += (" ASC");
                }
            }
            return strFieldInfo;
        }
        public object Clone()
        {
            IndexFieldDefInfo other = (IndexFieldDefInfo)this.MemberwiseClone();
            other.m_strName = this.m_strName;
            other.m_bDescending = this.m_bDescending;

            return other;
        }
    }
}
