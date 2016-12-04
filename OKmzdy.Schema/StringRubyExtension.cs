using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public static class StringUtils
    {
        public static string JoinNonEmpty(string delimClause, params string[] values)
        {
            var valuesNonEmpty = values.Where((s) => (s.CompareNoCase("") == false)).ToArray();

            return string.Join(delimClause, valuesNonEmpty);
        }
    }
    public static class StringRubyExtension
    {
        public static string Camelize(this string value, bool firstLetterUppercase = true)
        {
            if (firstLetterUppercase)
            {
                return
                    Regex.Replace(
                        Regex.Replace(value, "/(.?)", p => "::" + p.Groups[1].Value.ToUpperInvariant()),
                        "(?:^|_)(.)", p => p.Groups[1].Value.ToUpperInvariant()
                    );
            }
            else
            {
                return
                    value.Substring(0, 1).ToLowerInvariant() +
                    Camelize(value.Substring(1));
            }
        }

        public static string Underscore(this string value)
        {
            value = value.Replace("::", "/");
            value = Regex.Replace(value, "([A-Z]+)([A-Z][a-z])", p => p.Groups[1].Value + "_" + p.Groups[2].Value);
            value = Regex.Replace(value, "([a-z\\d])([A-Z])", p => p.Groups[1].Value + "_" + p.Groups[2].Value);
            value = value.Replace("-", "_");

            return value.ToLowerInvariant();
        }

        public static string ConvertNameToCamel(this string value)
        {
            char[] delimiters = new char[] { '_' };

            string nameTemplTrim = value.TrimEnd();
            List<string> names = new List<string>(nameTemplTrim.Split(delimiters));
            string[] parttojoin = names.ToArray();
            string newname = "";
            foreach (string part in parttojoin)
            {
                string part0 = part.Substring(0, 1).ToUpper();
                newname += part0 + part.Substring(1).ToLower();
            }
            return newname;
        }
        public static string ConvertNameToRuby(this string value)
        {
            char[] delimiters = new char[] { '_' };

            string nameTemplTrim = value.TrimEnd();
            List<string> names = new List<string>(nameTemplTrim.Split(delimiters));
            string[] parttojoin = names.ToArray();
            string newname = "";
            foreach (string part in parttojoin)
            {
                newname += part.ToLower();
                newname += "_";
            }

            return newname.TrimEnd(delimiters);
        }
        public static string FormatAmount(this string value)
        {
            // .gsub(/(\d)(?=(\d\d\d)+(?!\d))/, "\\1 ")
            return Regex.Replace(value, "(\\d)(?=(\\d\\d\\d)+(?!\\d))", p => p.Groups[1].Value + " ",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }
        public static bool CompareNoCase(this string value, string other)
        {
            return value.ToUpper().CompareTo(other.ToUpper()) == 0;
        }
    }
}
