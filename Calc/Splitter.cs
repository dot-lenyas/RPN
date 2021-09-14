using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Calc
{
    class Splitter
    {
        static string GeneratePattern()
        {
            var str = new StringBuilder();
            const string format = "|({0})";

            foreach (var operation in Operators.Priority.Keys)
                str.Append(string.Format(format, Regex.Escape(operation)));

            return str.Remove(0, 1).ToString();
        }

        public static List<string> SplitSourceStr(string str)
        {
            str = str.Replace(" ", "");
            string pattern = GeneratePattern();
            var regex = new Regex(pattern);

            return regex.Split(str).Where(x => x != string.Empty).ToList();
        }
    }
}
