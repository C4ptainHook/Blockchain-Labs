using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_2102.TB.BBD
{
    public static class StringExtenstions
    {
        public static string GetLastCharacters(this string str, int n)
        {
            if(str.Length < n)
            {
                return str;
            }
            return str[^n..];
        }
    }
}
