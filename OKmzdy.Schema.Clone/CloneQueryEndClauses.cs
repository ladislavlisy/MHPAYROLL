using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneQueryEndClauses : ICloneable
    {
        string m_source;
        string m_target;
        public CloneQueryEndClauses(string fieldInfo)
        {
            m_source = fieldInfo;
            m_target = fieldInfo;
        }
        public string GetSourceInfo()
        {
            return m_source;
        }
        public string GetTargetInfo()
        {
            return m_target;
        }
        public object Clone()
        {
            CloneQueryEndClauses other = (CloneQueryEndClauses)this.MemberwiseClone();
            other.m_source = this.m_source;
            other.m_target = this.m_target;

            return other;
        }
    }
}