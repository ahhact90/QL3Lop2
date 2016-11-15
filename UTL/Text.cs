using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTL
{
    public static class Text
    {
        /// <summary>
        /// Get string between
        /// </summary>
        /// <param name="str">String need to get</param>
        /// <param name="start">String start</param>
        /// <param name="end">String end</param>
        /// <returns>String</returns>
        public static string GetBetween(string str, string start, string end)
        {
            try
            {
                var s = str.IndexOf(start);
                var e = str.IndexOf(end);

                return str.Substring(s, e - s);
            }
            catch { return ""; }
        }

        /// <summary>
        /// Get string between
        /// </summary>
        /// <param name="str">String need to get</param>
        /// <param name="start">Char start</param>
        /// <param name="end">Char end</param>
        /// <returns>String</returns>
        public static string GetBetween(string str, char start, char end)
        {
            try
            {
                var s = str.IndexOf(start);
                var e = str.IndexOf(end);

                return str.Substring(s, e - s);
            }
            catch { return ""; }
        }
    }
}
