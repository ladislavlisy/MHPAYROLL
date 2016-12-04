using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema.Utils
{
    public class ScriptWritter : IGeneratorWriter, IDisposable
    {
        public ScriptWritter(string outputFilePath, string infoFileName, string codeFileName, int platformType, bool outBase64)
        {
            m_InfoFileName = infoFileName;
            m_InfoFilePath = System.IO.Path.Combine(outputFilePath, infoFileName);
            m_CodeFileName = codeFileName;
            m_CodeFilePath = System.IO.Path.Combine(outputFilePath, codeFileName);

            m_InfoWriter = File.CreateText(m_InfoFilePath);

            m_CodeWriter = File.CreateText(m_CodeFilePath);

            m_PlatformType = platformType;
            m_OutputBase64 = outBase64;
        }

        protected int m_PlatformType;
        protected string m_InfoFileName = "unknown";
        protected string m_InfoFilePath = "unknown";
        protected string m_CodeFileName = "unknown";
        protected string m_CodeFilePath = "unknown";
        protected bool m_OutputBase64;

        protected TextWriter m_InfoWriter;

        protected TextWriter m_CodeWriter;

        public int PlatformType()
        {
            return m_PlatformType;
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

        public void ExecuteCodeLine(string codeText, string infoName)
        {
            if (codeText != DBConstants.EMPTY_STRING)
            {
            }
        }

        public void DefaultCodeLine(string codeText, string infoName)
        {
            if (m_OutputBase64)
            {
                WriteCodeInBase64Line(codeText);
            }
            else
            {
                WriteCodeLine(codeText);
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
