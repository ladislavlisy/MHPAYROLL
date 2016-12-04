using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class QueryJoinDefInfo : ICloneable
    {
        public static QueryJoinDefInfo GetQueryFirstJoinDefInfo(string leftAlias, string rightAlias)
        {
            return new QueryJoinDefInfo(leftAlias, rightAlias, true, true);
        }
        public static QueryJoinDefInfo GetQueryJoinDefInfo(string leftAlias, string rightAlias)
        {
            return new QueryJoinDefInfo(leftAlias, rightAlias, true, false);
        }
        public static QueryJoinDefInfo GetWhereJoinDefInfo(string leftAlias, string rightAlias)
        {
            return new QueryJoinDefInfo(leftAlias, rightAlias, false, false);
        }
        public QueryJoinDefInfo AddColumn(string leftColumnName, string rightColumnName)
        {
            QueryJoinDefInfo other = (QueryJoinDefInfo)this.MemberwiseClone();
            other.m_strLeftAliasName = this.m_strLeftAliasName;
            other.m_strRightAliasName = this.m_strRightAliasName;
            QueryJoinFieldDefInfo addJoinColumns = new QueryJoinFieldDefInfo(leftColumnName, rightColumnName);
            other.m_QueryJoinFieldInfo = this.m_QueryJoinFieldInfo.Concat(new List<QueryJoinFieldDefInfo>() { addJoinColumns }).ToList();

            return other;
        }
        public QueryJoinDefInfo AddLeftColumn(string leftColumnName, string leftOp, string leftValue)
        {
            QueryJoinDefInfo other = (QueryJoinDefInfo)this.MemberwiseClone();
            other.m_strLeftAliasName = this.m_strLeftAliasName;
            other.m_strRightAliasName = this.m_strRightAliasName;
            QueryJoinFieldDefInfo addJoinColumns = new QueryJoinFieldDefInfo(true, leftColumnName, leftOp, leftValue);
            other.m_QueryJoinFieldInfo = this.m_QueryJoinFieldInfo.Concat(new List<QueryJoinFieldDefInfo>() { addJoinColumns }).ToList();

            return other;
        }
        public QueryJoinDefInfo AddRightColumn(string rightColumnName, string rightOp, string rightValue)
        {
            QueryJoinDefInfo other = (QueryJoinDefInfo)this.MemberwiseClone();
            other.m_strLeftAliasName = this.m_strLeftAliasName;
            other.m_strRightAliasName = this.m_strRightAliasName;
            QueryJoinFieldDefInfo addJoinColumns = new QueryJoinFieldDefInfo(false, rightColumnName, rightOp, rightValue);
            other.m_QueryJoinFieldInfo = this.m_QueryJoinFieldInfo.Concat(new List<QueryJoinFieldDefInfo>() { addJoinColumns }).ToList();

            return other;
        }
        public QueryJoinDefInfo(string leftAlias, string rightAlias, bool joinCondition, bool leftCondition)
        {
            m_QueryJoinFieldInfo = new List<QueryJoinFieldDefInfo>();
            m_bJoinCondition = joinCondition;
            m_bLeftCondition = leftCondition;
            m_strLeftAliasName = leftAlias;
            m_strRightAliasName = rightAlias;
        }

        private IList<QueryJoinFieldDefInfo> m_QueryJoinFieldInfo;
        public bool m_bJoinCondition;
        public bool m_bLeftCondition;
        public string m_strLeftAliasName;
        public string m_strRightAliasName;

        public IList<QueryJoinFieldDefInfo> QueryTableJoinFields()
        {
            IList<QueryJoinFieldDefInfo> joinFieldList = m_QueryJoinFieldInfo.ToList();

            return joinFieldList;
        }

        public void SetQueryJoinFieldList(IList<QueryJoinFieldDefInfo> fieldList)
        {
            m_QueryJoinFieldInfo = fieldList;
        }
        public bool QueryTableJoinOpConds(bool bFilterConds)
        {
            bool bOperatorConds = m_QueryJoinFieldInfo.Any((f) => (f.m_bLeftColumnOpValue || f.m_bRightColumnOpValue));

            return (m_bJoinCondition == false) || (bFilterConds && bOperatorConds);
        }

        public string QueryTableJoinConditions(QueryDefInfo queryInfo, bool bTbJoinConds, bool bFilterConds)
        {
            string strFieldNames = "";

            QueryTableDefInfo rightTableInfo = queryInfo.QueryTableByAlias(m_strRightAliasName);

            if (m_bLeftCondition)
            {
                QueryTableDefInfo leftTableInfo = queryInfo.QueryTableByAlias(m_strLeftAliasName);
                strFieldNames += leftTableInfo.TableSourceName();
                strFieldNames += " ";
            }

            strFieldNames += "INNER JOIN ";
            strFieldNames += rightTableInfo.TableSourceName();
            strFieldNames += " ON ";
            strFieldNames += QueryFieldJoinConditions(bTbJoinConds, bFilterConds);

            return strFieldNames;
        }

        public string QueryFieldJoinConditions(bool bTbJoinConds, bool bFilterConds)
        {
            IList<string> joinConditions = m_QueryJoinFieldInfo.Select((f) => f.JoinCondition(m_strLeftAliasName, m_strRightAliasName, bTbJoinConds, bFilterConds)).ToList();

            return string.Join(" AND ", joinConditions.Where((s) => (s.CompareNoCase("") == false)));
        }
        public string QueryTableFilterConditions(bool bTbJoinConds, bool bFilterConds)
        {
            IList<string> joinConditions = m_QueryJoinFieldInfo.Select((f) => f.JoinCondition(m_strLeftAliasName, m_strRightAliasName, bTbJoinConds, bFilterConds)).ToList();

            return string.Join(" AND ", joinConditions.Where((s) => (s.CompareNoCase("") == false)));
        }
        public object Clone()
        {
            QueryJoinDefInfo other = (QueryJoinDefInfo)this.MemberwiseClone();
            other.m_bJoinCondition = this.m_bJoinCondition;
            other.m_bLeftCondition = this.m_bLeftCondition;
            other.m_strLeftAliasName = this.m_strLeftAliasName;
            other.m_strRightAliasName = this.m_strRightAliasName;

            return other;
        }

    }
}
