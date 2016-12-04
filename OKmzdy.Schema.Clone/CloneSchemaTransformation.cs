using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public class CloneSchemaTransformation
    {
        public const string COLUMN_NAME_AUTOID = "id";

        public const string NAMEAUTO_REF_ID = "_refid";

        public static void ConvertTablesAutoIdFieldToId(IList<CloneTableDefInfo> tableList)
        {
            foreach (var tableDef in tableList)
            {
                ConvertTableAutoId2Id(tableDef, tableList);
            }
        }

        public static void ConvertTablesRelationsMxToId(IList<CloneTableDefInfo> tableList)
        {
            foreach (var tableDef in tableList)
            {
                ConvertTableRelsMx2Id(tableDef, tableList);
            }
        }

        private static void ConvertTableAutoId2Id(CloneTableDefInfo tableInfo, IList<CloneTableDefInfo> tableList)
        {
            CloneTableFieldDefInfo m_XID = tableInfo.AutoIncrementColumn();
            CloneIndexDefInfo m_XPK = tableInfo.IndexPK();
            IList<CloneRelationDefInfo> tableToRelation = tableInfo.ForeignRelations(tableList);

            if (m_XID == null)
            {
                tableInfo.CreateTargetFAUTO(COLUMN_NAME_AUTOID, DBConstants.DB_LONG);

                tableInfo.CreateTargetIndexFromXPK(m_XPK);

                m_XPK = tableInfo.CreatePKAutoConstraint("XPK", COLUMN_NAME_AUTOID);
            }
            else
            {
                string oldAuroName = m_XID.TargetName();

                m_XID.ReNameTargetColumn(COLUMN_NAME_AUTOID);

                foreach (var index in tableInfo.IndexesNonPK())
                {
                    index.ReNameTargetColumn(oldAuroName, COLUMN_NAME_AUTOID);
                }

                foreach (var relationTable in tableToRelation)
                {
                    relationTable.ReNameTableColumn(oldAuroName, COLUMN_NAME_AUTOID);
                }

                tableInfo.CreateTargetIndexFromXPK(m_XPK, oldAuroName, COLUMN_NAME_AUTOID);

                m_XPK = tableInfo.CreatePKAutoConstraint("XPK", COLUMN_NAME_AUTOID);
            }
        }

        private static void ConvertTableRelsMx2Id(CloneTableDefInfo tableInfo, IList<CloneTableDefInfo> tableList)
        {
            IList<CloneRelationDefInfo> foreignRelations = ForeignRelations(tableInfo, tableList);

            IList<string> foreignNamesOfRelations = foreignRelations.Select((r) => (r.TargetForeignNamestAllUnique())).ToList();

            foreach (var relation in foreignRelations)
            {
                ConvertRelation(tableInfo, relation, foreignNamesOfRelations, tableList);
            }
        }

        private static IList<CloneRelationDefInfo> ForeignRelations(CloneTableDefInfo tableInfo, IList<CloneTableDefInfo> tableList)
        {
            return tableList.SelectMany((m) => (m.Relations().Where((r) => (r.m_strTable.CompareTo(tableInfo.TableName()) == 0)))).ToList();
        }
        public static void ConvertRelation(CloneTableDefInfo tableInfo, CloneRelationDefInfo relation, IList<string> namesOfRelations, IList<CloneTableDefInfo> tableList)
        {
            var relationTable = TableInfoByName(tableList, relation.m_strForeignTable);

            if (relationTable != null)
            {
                string constraintName = CreateRelationNameMxToId(tableInfo, relation, relationTable, namesOfRelations);

                var targetColumn = relationTable.SourceFieldByName(constraintName);

                if (targetColumn == null)
                {
                    relationTable.CreateTargetField(constraintName, DBConstants.DB_LONG, DBConstants.dbNullFieldOption);
                }

                relation.MakeTargetRelationOrmReady(constraintName, COLUMN_NAME_AUTOID);
            }
        }

        private static CloneTableDefInfo TableInfoByName(IList<CloneTableDefInfo> tableList, string name)
        {
            return tableList.SingleOrDefault((t) => (t.TableName().CompareTo(name) == 0));
        }

        private static string CreateRelationNameMxToId(CloneTableDefInfo tableInfo, CloneRelationDefInfo relation, CloneTableDefInfo relationTable, IList<string> relationNames)
        {
            string uniqueXPkName = tableInfo.TargetPKUniqueAllNames();

            string uniqueRPkName = relationTable.TargetPKUniqueAllNames();

            string uniqueForName = relation.TargetForeignNamestAllUnique();

            string uniqueRelName = relation.TargetNamestAllUnique();

            string[] columnsNames = uniqueForName.Split(new char[] { '.' });
            int columnsNamesCount = columnsNames.Length;
            string[] colRelsNames = uniqueRelName.Split(new char[] { '.' });
            int colRelsNamesCount = colRelsNames.Length;
            string uniqueRelXEnds = colRelsNames[colRelsNamesCount - 1];

            int realtionNameCount = relationNames.Count((rn) => (rn.CompareTo(uniqueForName) == 0));

            string constraintName = relation.m_strName.ToLower() + NAMEAUTO_REF_ID;

            if (uniqueXPkName.CompareTo(uniqueRelName) != 0)
            {
                if (uniqueRelXEnds.CompareTo("id") == 0)
                {
                    constraintName = columnsNames[columnsNamesCount - 1];
                }
                else if (uniqueRelXEnds.CompareTo("firma_id") == 0)
                {
                    constraintName = relation.m_strTable.ToLower() + NAMEAUTO_REF_ID;
                }
                else if (uniqueRelXEnds.EndsWith("kod"))
                {
                    string constraintColl = columnsNames[columnsNamesCount - 1];
                    constraintName = CreateConstraintName(constraintColl, "kod", NAMEAUTO_REF_ID);
                }
                else if (uniqueRelXEnds.Contains("kod"))
                {
                    string constraintColl = columnsNames[columnsNamesCount - 1];
                    constraintName = CreateConstraintName(constraintColl, "kod", NAMEAUTO_REF_ID);
                }
                else if (uniqueRelXEnds.EndsWith("cislo"))
                {
                    string constraintColl = columnsNames[columnsNamesCount - 1];
                    constraintName = CreateConstraintName(constraintColl, "cislo", NAMEAUTO_REF_ID);
                }
                else if (uniqueRelXEnds.Contains("cislo"))
                {
                    string constraintColl = columnsNames[columnsNamesCount - 1];
                    constraintName = CreateConstraintName(constraintColl, "cislo", NAMEAUTO_REF_ID);
                }
                else if (uniqueRelXEnds.EndsWith("id"))
                {
                    string constraintColl = columnsNames[columnsNamesCount - 1];
                    constraintName = CreateConstraintName(constraintColl, "id", NAMEAUTO_REF_ID);
                }
                else if (uniqueRelXEnds.Contains("id"))
                {
                    string constraintColl = columnsNames[columnsNamesCount - 1];
                    constraintName = CreateConstraintName(constraintColl, "id", NAMEAUTO_REF_ID);
                }
                else if (uniqueRelXEnds.CompareTo("mesic") == 0)
                {
                    constraintName = relation.m_strTable.ToLower() + NAMEAUTO_REF_ID;
                }
                else
                {
                    string constraintColl = columnsNames[columnsNamesCount - 1];
                    constraintName = constraintColl + NAMEAUTO_REF_ID;
                }
            }
            else
            {
                constraintName = columnsNames[columnsNamesCount - 1];
            }

            return constraintName;
        }
        private static string CreateConstraintName(string constraintColl, string keyName, string autoRefId)
        {
            string constraintName;
            string keyNameEx1 = "_" + keyName;
            string keyNameEx2 = keyName + "_";

            if (constraintColl.EndsWith(keyNameEx1))
            {
                constraintName = constraintColl.Replace(keyNameEx1, autoRefId);
            }
            else if (constraintColl.Contains(keyNameEx2))
            {
                constraintName = constraintColl.Replace(keyNameEx2, "") + autoRefId;
            }
            else
            {
                constraintName = constraintColl + autoRefId;
            }

            return constraintName;
        }
    }
}
