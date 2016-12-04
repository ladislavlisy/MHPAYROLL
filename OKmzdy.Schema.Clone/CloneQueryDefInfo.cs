using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneQueryDefInfo : ICloneable
    {
        protected IList<CloneQueryTableDefInfo> m_QueryTableInfo;
        protected IList<CloneQueryJoinDefInfo> m_QueryJoinInfo;
        protected IList<CloneQueryWhereDefInfo> m_TableViewFilters;
        protected IList<CloneQueryEndClauses> m_QueryEndClauses;

        protected string m_strOwnerName;
        protected string m_strUsersName;
        protected UInt32 m_VersFrom = 0;
        protected UInt32 m_VersDrop = 9999;
        public string m_strName;

        public bool IsValidInVersion(UInt32 versCreate)
        {
            return (m_VersFrom <= versCreate && versCreate < m_VersDrop);
        }
        public string OwnerName()
        {
            return m_strOwnerName;
        }

        public string UsersName()
        {
            return m_strUsersName;
        }
        public string QueryName()
        {
            return m_strName;
        }

        public UInt32 VersFrom()
        {
            return m_VersFrom;
        }

        public UInt32 VersDrop()
        {
            return m_VersDrop;
        }


        public CloneQueryDefInfo(QueryDefInfo defInfo, UInt32 versCreate)
        {
            this.m_VersFrom = defInfo.VersFrom();
            this.m_VersDrop = defInfo.VersDrop();
            this.m_strName = defInfo.QueryName();
            this.m_QueryTableInfo = defInfo.QueryTableInfo().Select((qt) => (new CloneQueryTableDefInfo(qt, versCreate))).ToList();
            this.m_QueryJoinInfo = defInfo.QueryJoinInfo().Select((qj) => (new CloneQueryJoinDefInfo(qj))).ToList();
            this.m_TableViewFilters = defInfo.TableViewFilters().Select((tv) => (new CloneQueryWhereDefInfo(tv, versCreate))).ToList();
            this.m_QueryEndClauses = defInfo.QueryEndClauses().Select((qe) => (new CloneQueryEndClauses(qe))).ToList();
        }

        public QueryDefInfo GetSourceInfo()
        {
            QueryDefInfo defInfo = new QueryDefInfo(this.m_strOwnerName, this.m_strUsersName, this.m_strName, this.m_VersFrom, this.m_VersDrop);
            defInfo.SetQueryTableInfo(this.m_QueryTableInfo.Select((qt) => (qt.GetSourceInfo())).ToList());
            defInfo.SetQueryJoinInfo(this.m_QueryJoinInfo.Select((qj) => (qj.GetSourceInfo())).ToList());
            defInfo.SetTableViewFilters(this.m_TableViewFilters.Select((tv) => (tv.GetSourceInfo())).ToList());
            defInfo.SetQueryEndClauses(this.m_QueryEndClauses.Select((ec) => (ec.GetSourceInfo())).ToList());

            return defInfo;
        }

        public QueryDefInfo GetTargetInfo()
        {
            QueryDefInfo defInfo = new QueryDefInfo(this.m_strOwnerName, this.m_strUsersName, this.m_strName, this.m_VersFrom, this.m_VersDrop);
            defInfo.SetQueryTableInfo(this.m_QueryTableInfo.Select((qt) => (qt.GetTargetInfo())).ToList());
            defInfo.SetQueryJoinInfo(this.m_QueryJoinInfo.Select((qj) => (qj.GetTargetInfo())).ToList());
            defInfo.SetTableViewFilters(this.m_TableViewFilters.Select((tv) => (tv.GetTargetInfo())).ToList());
            defInfo.SetQueryEndClauses(this.m_QueryEndClauses.Select((ec) => (ec.GetTargetInfo())).ToList());

            return defInfo;
        }
        #region ICloneable Members

        public object Clone()
        {
            CloneQueryDefInfo other = (CloneQueryDefInfo)this.MemberwiseClone();
            other.m_VersFrom = this.m_VersFrom;
            other.m_VersDrop = this.m_VersDrop;
            other.m_strName = this.m_strName;
            other.m_QueryTableInfo = this.m_QueryTableInfo.Select((qt) => ((CloneQueryTableDefInfo)qt.Clone())).ToList();
            other.m_QueryJoinInfo = this.m_QueryJoinInfo.Select((qj) => ((CloneQueryJoinDefInfo)qj.Clone())).ToList();
            other.m_TableViewFilters = this.m_TableViewFilters.Select((tv) => ((CloneQueryWhereDefInfo)tv.Clone())).ToList();
            other.m_QueryEndClauses = this.m_QueryEndClauses.Select((ec) => ((CloneQueryEndClauses)ec.Clone())).ToList();

            return other;
        }

        #endregion
    }
}
