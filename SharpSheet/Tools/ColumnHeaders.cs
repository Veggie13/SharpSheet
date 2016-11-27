using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSheet.Tools
{
    static class ColumnHeaders
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string[] Get(int count)
        {
            return Enumerable.Range(0, count).Select(i => GetCode(i)).ToArray();
        }

        public static string GetCode(int index)
        {
            return getSuperCode(index / Alphabet.Length) + Alphabet[index % Alphabet.Length].ToString();
        }

        private static string getSuperCode(int index)
        {
            if (index == 0)
            {
                return "";
            }
            return getSuperCode(index / Alphabet.Length) + Alphabet[index % Alphabet.Length].ToString();
        }
    }
}
