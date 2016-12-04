using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public interface IGeneratorWriter
    {
        int PlatformType();
        string InfoFileName();
        string InfoFilePath();
        string CodeFileName();
        string CodeFilePath();
        void WriteInfoLine(string infoText);
        void WriteInfoLine(string format, params object[] args);
        void WriteCodeInBase64Line(string codeText);
        void WriteCodeLine(string codeText);
        void ExecuteCodeLine(string codeText, string infoName);
        long GetScriptCount(string countQuery);
        void DefaultCodeLine(string codeText, string infoName);
    }
}
