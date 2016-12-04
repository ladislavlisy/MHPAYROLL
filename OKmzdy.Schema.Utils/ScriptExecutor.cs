using OKmzdy.AppParams;
using OKmzdy.Schema.SqlAdapter;
using OKmzdy.Schema.SqlFactory;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Utils
{
    public class ScriptExecutor : IGeneratorWriter, IDisposable
    {
        public ScriptExecutor(string outputFilePath, string infoFileName, string codeFileName, DbsDataConfig targetNode)
        {
            m_InfoFileName = infoFileName;
            m_InfoFilePath = System.IO.Path.Combine(outputFilePath, infoFileName);

            m_InfoWriter = File.CreateText(m_InfoFilePath);

            m_CodeFileName = codeFileName;
            m_CodeFilePath = System.IO.Path.Combine(outputFilePath, codeFileName);

            m_CodeWriter = File.CreateText(m_CodeFilePath);

            m_TargetAdapter = SqlAdapterFactory.CreateSqlAdapter(targetNode);

            try
            {
                m_TargetAdapter.CreateDatabase();

                m_TargetAdapter.CreateConnection();

                m_TargetAdapter.OpenConnection();
            }
            catch (Exception ex)
            {
                WriteInfoLine("Database Exception: {0}", ex.ToString());
            }
        }

        protected string m_InfoFileName = "unknown";
        protected string m_InfoFilePath = "unknown";
        protected string m_CodeFileName = "unknown";
        protected string m_CodeFilePath = "unknown";

        protected TextWriter m_InfoWriter;

        protected TextWriter m_CodeWriter;

        protected SqlBaseAdapter m_TargetAdapter;
        public int PlatformType()
        {
            if (m_TargetAdapter == null)
            {
                return DBPlatform.DATA_PROVIDER_ODBC_MSSQL;
            }
            return m_TargetAdapter.PlatformType();
        } 
        public string InfoFileName()
        {
            return m_InfoFileName;
        }
        public string InfoFilePath()
        {
            return m_InfoFilePath;
        }
        public string CodeFileName()
        {
            return m_CodeFileName;
        }
        public string CodeFilePath()
        {
            return m_CodeFilePath;
        }
        public void DefaultCodeLine(string codeText, string infoName)
        {
            ExecuteCodeLine(codeText, infoName);
        }

        public void ExecuteCodeLine(string codeText, string infoName)
        {
            if (codeText != DBConstants.EMPTY_STRING)
            {
                WriteCodeLine(codeText);

                try
                {
                    DbCommand command = m_TargetAdapter.GetCommand(codeText + ";");

                    command.ExecuteNonQuery();
                }
                catch (OleDbException dbex)
                {
                    WriteInfoLine("Database Exception: {0}", infoName);
                    WriteInfoLine("Message: {0}", dbex.ToString());

                    for (int i = 0; i < dbex.Errors.Count; i++)
                    {
                        WriteInfoLine("----------------------------------------------------");
                        WriteInfoLine("Index #{0}", i);
                        WriteInfoLine("Message: {0}", dbex.Errors[i].Message);
                        WriteInfoLine("NativeError: {0}", dbex.Errors[i].NativeError);
                        WriteInfoLine("Source: {0}", dbex.Errors[i].Source);
                        WriteInfoLine("SQLState: {0}", dbex.Errors[i].SQLState);
                        WriteInfoLine("----------------------------------------------------");
                    }
                }
                catch (Exception ex)
                {
                    WriteInfoLine("Database Exception: {0}", infoName);
                    WriteInfoLine("Message: {0}", ex.ToString());
                }
            }
        }

        public void WriteInfoLine(string infoText)
        {
            if (infoText != DBConstants.EMPTY_STRING)
            {
                m_InfoWriter.WriteLine(infoText);
            }
        }

        public void WriteInfoLine(string format, params object[] args)
        {
            if (format != DBConstants.EMPTY_STRING)
            {
                m_InfoWriter.WriteLine(format, args);
            }
        }

        public void WriteCodeLine(string codeText)
        {
            if (codeText != DBConstants.EMPTY_STRING)
            {
                m_CodeWriter.WriteLine(codeText);
            }
        }
        public void WriteCodeInBase64Line(string codeText)
        {
            if (codeText != DBConstants.EMPTY_STRING)
            {
                m_CodeWriter.WriteLine(Base64Encode(codeText));
            }
        }
        public long GetScriptCount(string countQuery)
        {
            return 0;
        }

        public void Dispose()
        {
            m_InfoWriter.Dispose();

            m_CodeWriter.Dispose();

            m_TargetAdapter.Dispose();
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
