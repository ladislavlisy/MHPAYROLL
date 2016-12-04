using OKmzdy.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Generators.SchemaSource
{
    public class EFCodeSourceBuilder
    {
        const string CONTEXT_NAME = "MZDY_HRAVE";

        const string CONTEXT_PART = "PAYROLL";

        const string PROJ_NAMESPACE_NAME = "MZDY_HRAVE.SCHEMA";

        const string TAB_INDENT0 = "";
        const string TAB_INDENT1 = "\t";
        const string TAB_INDENT2 = "\t\t";
        const string TAB_INDENT3 = "\t\t\t";

        const string SP_INDENT0 = "";
        const string SP_INDENT1 = "    ";
        const string SP_INDENT2 = "        ";
        const string SP_INDENT3 = "            ";

        private IList<Tuple<string, string>> m_ChangeNames;

        private UInt32 m_createVersion = 0;

        public EFCodeSourceBuilder(UInt32 versCreate)
        {
            m_createVersion = versCreate;

            m_ChangeNames = new Tuple<string, string>[] {
                new Tuple<string, string>("Ppom", "PPom"),
                new Tuple<string, string>("Vrep", "VRep"),
                new Tuple<string, string>("Uimp", "UImp"),
                new Tuple<string, string>("Ulst", "ULst"),
                new Tuple<string, string>("SestavyUdata", "SestavyData"),
                new Tuple<string, string>("Pmedia", "PMedia"),
                new Tuple<string, string>("PrijmySsp", "PrijmySSP"),
                new Tuple<string, string>("HlaseniZp", "HlaseniZP")
            };

        }

        public string ClassName(string tableName)
        {
            return m_ChangeNames.Aggregate(tableName, (agr, x) => agr.Replace(x.Item1, x.Item2));
        }

        public string ClassColumnName(TableFieldDefInfo columnInfo)
        {
            return columnInfo.ColumnName();
        }

        public string EntityName(TableDefInfo tableInfo)
        {
            return tableInfo.TableName().ConvertNameToCamel();
        }

        public void CreateTableListCodeConfigs(IList<TableDefInfo> tableList, IGeneratorWriter scriptWriter)
        {
            string namespaceName = PROJ_NAMESPACE_NAME.ConvertNameToCamel();

            CreateCodeConfigsImports(scriptWriter, namespaceName);

            CreateCodeNamespaceConfigsOpens(scriptWriter, namespaceName);

            foreach (var tableInfo in tableList)
            {
                string className = ClassName(EntityName(tableInfo));

                CreateTableCodeConfigs(tableInfo, scriptWriter);
            }

            CreateCodeNamespaceClose(scriptWriter);
        }

        public void CreateTableListCodeContext(IList<TableDefInfo> tableList, IGeneratorWriter scriptWriter)
        {
            string namespaceName = PROJ_NAMESPACE_NAME.ConvertNameToCamel();

            string contextClassName = CONTEXT_NAME.ConvertNameToCamel();

            string contextPartyName = CONTEXT_PART.ConvertNameToCamel();

            string blokIndent = "";

            CreateCodeContextImports(scriptWriter, namespaceName);

            CreateCodeNamespaceContextOpens(scriptWriter, namespaceName);

            blokIndent = IndentPlus(blokIndent, TAB_INDENT1);

            CreateCodeClassContextOpens(scriptWriter, contextClassName, blokIndent);

            blokIndent = IndentPlus(blokIndent, TAB_INDENT1);

            CreateCodeClassContextBody(scriptWriter, tableList, contextClassName, contextPartyName, blokIndent);

            blokIndent = IndentBack(blokIndent, TAB_INDENT1);

            CreateCodeClassContextClose(scriptWriter, blokIndent);

            blokIndent = IndentBack(blokIndent, TAB_INDENT1);

            CreateCodeNamespaceClose(scriptWriter);
        }
        public void CreateTableListCodeClasses(IList<TableDefInfo> tableList, IGeneratorWriter scriptWriter)
        {
            string namespaceName = PROJ_NAMESPACE_NAME.ConvertNameToCamel();

            CreateCodeClassesImports(scriptWriter);

            CreateCodeNamespaceClassesOpens(scriptWriter, namespaceName);

            foreach (var tableInfo in tableList)
            {
                string className = ClassName(EntityName(tableInfo));

                CreateTableCodeClasses(tableInfo, scriptWriter);
            }

            CreateCodeNamespaceClose(scriptWriter);
        }

        public void CreateTableCodeConfigs(TableDefInfo tableInfo, IGeneratorWriter scriptWriter)
        {
            string blokIndent = "";

            blokIndent = IndentPlus(blokIndent, TAB_INDENT1);

            CreateCodeClassConfigsOpens(scriptWriter, tableInfo, blokIndent);

            blokIndent = IndentPlus(blokIndent, TAB_INDENT1);

            CreateCodeClassConfigsBody(scriptWriter, tableInfo, blokIndent);

            blokIndent = IndentBack(blokIndent, TAB_INDENT1);

            CreateCodeClassConfigsClose(scriptWriter, blokIndent);

            blokIndent = IndentBack(blokIndent, TAB_INDENT1);

        }
        public void CreateTableCodeClasses(TableDefInfo tableInfo, IGeneratorWriter scriptWriter)
        {
            string className = ClassName(EntityName(tableInfo));

            string blokIndent = "";

            blokIndent = IndentPlus(blokIndent, TAB_INDENT1);

            CreateCodeClassDefinitionOpens(scriptWriter, tableInfo, className, blokIndent);

            blokIndent = IndentPlus(blokIndent, TAB_INDENT1);

            CreateCodeClassDefinitionBody(scriptWriter, tableInfo, className, blokIndent);

            blokIndent = IndentBack(blokIndent, TAB_INDENT1);

            CreateCodeClassDefinitionClose(scriptWriter, blokIndent);

            blokIndent = IndentBack(blokIndent, TAB_INDENT1);

        }

        private string IndentPlus(string strBlokIndent, string strIndent)
        {
            string strNewIndent = (strBlokIndent + strIndent);

            return strNewIndent;
        }

        private string IndentBack(string strBlokIndent, string strIndent)
        {
            int blokIndentLen = strBlokIndent.Length;
            int onesIndentLen = strIndent.Length;

            string strNewIndent = strBlokIndent.Substring(0, blokIndentLen - onesIndentLen);

            return strNewIndent;
        }

        private static void CreateCodeClassesImports(IGeneratorWriter scriptWriter)
        {
            scriptWriter.WriteCodeLine("using System;");
            scriptWriter.WriteCodeLine("using System.Linq;");
            scriptWriter.WriteCodeLine("using System.Text;");
            scriptWriter.WriteCodeLine("using System.Threading.Tasks;");
            scriptWriter.WriteCodeLine("using Repository.Pattern.Ef6;");
            scriptWriter.WriteCodeLine("");
        }
        private void CreateCodeNamespaceClassesOpens(IGeneratorWriter scriptWriter, string namespaceName)
        {
            scriptWriter.WriteCodeLine("namespace " + namespaceName + ".EntityModel");
            scriptWriter.WriteCodeLine("{");
        }
        private void CreateCodeClassDefinitionOpens(IGeneratorWriter scriptWriter, TableDefInfo tableInfo, string className, string blokIndent)
        {
            string tableName = tableInfo.TableName();

            scriptWriter.WriteCodeLine(blokIndent + "// " + tableName + " : Declaration of the " + className);
            scriptWriter.WriteCodeLine(blokIndent + "public class " + className + " : Entity");
            scriptWriter.WriteCodeLine(blokIndent + "{");
        }

        private void CreateCodeClassDefinitionClose(IGeneratorWriter scriptWriter, string blokIndent)
        {
            scriptWriter.WriteCodeLine(blokIndent + "}");
            scriptWriter.WriteCodeLine("");
        }

        private void CreateCodeClassDefinitionBody(IGeneratorWriter scriptWriter, TableDefInfo tableInfo, string className, string blokIndent)
        {
            scriptWriter.WriteCodeLine(blokIndent + "public " + className + "()");
            scriptWriter.WriteCodeLine(blokIndent + "{");
            scriptWriter.WriteCodeLine(blokIndent + "}");
            scriptWriter.WriteCodeLine("");

            string tableName = tableInfo.TableName();

            IList<TableFieldDefInfo> columnList = tableInfo.TableColumnsForVersion(m_createVersion);

            foreach (TableFieldDefInfo columnInfo in columnList)
            {
                string columnName = ClassColumnName(columnInfo);

                int columnType = columnInfo.m_nType;

                int columnMaxx = columnInfo.DbColumnSize();

                bool columnNull = columnInfo.DbColumnNull();

                string propertyName = columnName.ConvertNameToCamel();

                string propertyType = DBPlatform.EntityConvertDataType(columnType, columnMaxx, !columnNull);

                scriptWriter.WriteCodeLine(blokIndent + "public " + propertyType + " " + propertyName + " { get; set; }");
            }


        }

        private void CreateCodeContextImports(IGeneratorWriter scriptWriter, string namespaceName)
        {
            scriptWriter.WriteCodeLine("using System;");
            scriptWriter.WriteCodeLine("using System.Linq;");
            scriptWriter.WriteCodeLine("using System.Text;");
            scriptWriter.WriteCodeLine("using System.Threading.Tasks;");
            scriptWriter.WriteCodeLine("using System.Data.Entity;");
            scriptWriter.WriteCodeLine("using " + namespaceName + ".EntityModel;");
            scriptWriter.WriteCodeLine("using " + namespaceName + ".EntityConfiguration;");
            scriptWriter.WriteCodeLine("");
        }
        private void CreateCodeNamespaceContextOpens(IGeneratorWriter scriptWriter, string namespaceName)
        {
            scriptWriter.WriteCodeLine("namespace " + namespaceName + ".EntityContext");
            scriptWriter.WriteCodeLine("{");
        }

        private void CreateCodeClassContextOpens(IGeneratorWriter scriptWriter, string className, string blokIndent)
        {
            scriptWriter.WriteCodeLine(blokIndent + "public class " + className + "Context : DbContext");
            scriptWriter.WriteCodeLine(blokIndent + "{");
        }

        private void CreateCodeClassContextClose(IGeneratorWriter scriptWriter, string blokIndent)
        {
            scriptWriter.WriteCodeLine(blokIndent + "}");
            scriptWriter.WriteCodeLine("");
        }

        private void CreateCodeClassContextBody(IGeneratorWriter scriptWriter, IList<TableDefInfo> tableList, string contextName, string contextPart, string blokIndent)
        {
            scriptWriter.WriteCodeLine(blokIndent + "#region " + contextName + "." + contextPart);

            blokIndent = IndentPlus(blokIndent, TAB_INDENT1);

            foreach (var tableInfo in tableList)
            {
                string tableName = tableInfo.TableName();

                string className = ClassName(EntityName(tableInfo));

                scriptWriter.WriteCodeLine(blokIndent + "public DbSet<" + className + "> " + className + " { get; set; }");
                scriptWriter.WriteCodeLine("");
            }

            scriptWriter.WriteCodeLine(blokIndent + "#endregion");

            scriptWriter.WriteCodeLine(blokIndent + "protected override void OnModelCreating");
            scriptWriter.WriteCodeLine(blokIndent + TAB_INDENT1 + "(DbModelBuilder modelBuilder)");
            scriptWriter.WriteCodeLine(blokIndent + "{");

            scriptWriter.WriteCodeLine(blokIndent + "#region " + contextName + "." + contextPart);

            foreach (TableDefInfo tableInfo in tableList)
            {
                string className = ClassName(EntityName(tableInfo));

                scriptWriter.WriteCodeLine(blokIndent + "modelBuilder.Configurations.Add(new " + className + "Configuration());");
            }

            scriptWriter.WriteCodeLine(blokIndent + "#endregion");

            scriptWriter.WriteCodeLine(blokIndent + "}");
        }

        private void CreateCodeNamespaceClose(IGeneratorWriter scriptWriter)
        {
            scriptWriter.WriteCodeLine("}");
        }

        private void CreateCodeConfigsImports(IGeneratorWriter scriptWriter, string namespaceName)
        {
            scriptWriter.WriteCodeLine("using System;");
            scriptWriter.WriteCodeLine("using System.Linq;");
            scriptWriter.WriteCodeLine("using System.Text;");
            scriptWriter.WriteCodeLine("using System.Threading.Tasks;");
            scriptWriter.WriteCodeLine("using System.Data.Entity;");
            scriptWriter.WriteCodeLine("using System.Data.Entity.ModelConfiguration;");
            scriptWriter.WriteCodeLine("using " + namespaceName + ".EntityModel;");
            scriptWriter.WriteCodeLine("");
        }
        private void CreateCodeNamespaceConfigsOpens(IGeneratorWriter scriptWriter, string namespaceName)
        {
            scriptWriter.WriteCodeLine("namespace " + namespaceName + ".EntityConfiguration");
            scriptWriter.WriteCodeLine("{");
        }

        private void CreateCodeClassConfigsOpens(IGeneratorWriter scriptWriter, TableDefInfo tableInfo, string blokIndent)
        {
            string tableName = tableInfo.TableName();

            string className = ClassName(EntityName(tableInfo));

            scriptWriter.WriteCodeLine(blokIndent + "// " + tableName + " : Declaration of the " + className);
            scriptWriter.WriteCodeLine(blokIndent + "public class " + className + "Configuration : EntityTypeConfiguration<" + className + ">");
            scriptWriter.WriteCodeLine(blokIndent + "{");

            blokIndent = IndentPlus(blokIndent, TAB_INDENT1);

            scriptWriter.WriteCodeLine(blokIndent + "public " + className + "Configuration()");
            scriptWriter.WriteCodeLine(blokIndent + "{");
        }

        private void CreateCodeClassConfigsBody(IGeneratorWriter scriptWriter, TableDefInfo tableInfo, string blokIndent)
        {
            string tableName = tableInfo.TableName();

            blokIndent = IndentPlus(blokIndent, TAB_INDENT1);

            scriptWriter.WriteCodeLine(blokIndent + "ToTable(\"" + tableName + "\");");

            IList<string> xpkcolList = tableInfo.PrimaryKeyColumnList();

            string keyNames = "";

            foreach (string columnName in xpkcolList)
            {
                string propertyName = columnName.ConvertNameToCamel();

                keyNames += "p." + propertyName + ", ";
            }
            scriptWriter.WriteCodeLine(blokIndent + "HasKey(p => new { " + keyNames.TrimEnd(DBConstants.TRIM_CHARS) + " });");

            IList<TableFieldDefInfo> columnList = tableInfo.TableColumnsForVersion(m_createVersion);

            foreach (TableFieldDefInfo columnInfo in columnList)
            {
                string columnName = ClassColumnName(columnInfo);

                int columnType = columnInfo.m_nType;

                int columnMaxx = columnInfo.DbColumnSize();

                string propertyName = columnName.ConvertNameToCamel();

                scriptWriter.WriteCodeLine(blokIndent + "Property(d => d." + propertyName + ").HasColumnName(\"" + columnName + "\");");
            }
        }

        private static void CreateCodeClassConfigsClose(IGeneratorWriter scriptWriter, string blokIndent)
        {
            scriptWriter.WriteCodeLine(blokIndent + "}");
            scriptWriter.WriteCodeLine("");
        }

    }
}
