using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MyFrameWork.Common
{
    public static class StringHelper
    {
        /// <summary>
        /// 把时间戳转化成时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this int timeStamp)
        {
            var baseTime = Convert.ToDateTime("1970-1-1 8:00:00");
            return baseTime.AddSeconds(timeStamp);
        }
        /// <summary>
        /// 将时间转为时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime time)
        {
            var result = time - new DateTime(1970, 1, 1, 8, 0, 0, 0);

            return Convert.ToInt64(result.TotalSeconds);
        }
        public static string ToCommonString(this DateTime? time,string format="yyyy-MM-dd hh:mm:ss")
        {
            if (time == null)
                return "";

            return time.Value.ToString(format);
        }
        public static int GetStringLength(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return Encoding.Default.GetBytes(s).Length;
            }
            return 0;
        }

        public static int IndexOf(string s, int order)
        {
            return IndexOf(s, '-', order);
        }

        public static int IndexOf(string s, char c, int order)
        {
            int length = s.Length;
            for (int i = 0; i < length; i++)
            {
                if (c == s[i])
                {
                    if (order == 1)
                    {
                        return i;
                    }
                    order--;
                }
            }
            return -1;
        }

        public static string[] SplitString(string sourceStr)
        {
            return SplitString(sourceStr, ",");
        }

        public static string[] SplitString(string sourceStr, string splitStr)
        {
            if (string.IsNullOrEmpty(sourceStr) || string.IsNullOrEmpty(splitStr))
            {
                return new string[0];
            }
            if (sourceStr.IndexOf(splitStr) == -1)
            {
                return new string[] { sourceStr };
            }
            if (splitStr.Length == 1)
            {
                return sourceStr.Split(new char[] { splitStr[0] });
            }
            return Regex.Split(sourceStr, Regex.Escape(splitStr), RegexOptions.IgnoreCase);
        }

        public static string SubString(string sourceStr, int length)
        {
            return SubString(sourceStr, 0, length);
        }

        public static string SubString(string sourceStr, int startIndex, int length)
        {
            if (!string.IsNullOrEmpty(sourceStr))
            {
                if (sourceStr.Length >= (startIndex + length))
                {
                    return sourceStr.Substring(startIndex, length);
                }
                return sourceStr.Substring(startIndex);
            }
            return "";
        }

        public static string Trim(string sourceStr, string trimStr)
        {
            return Trim(sourceStr, trimStr, true);
        }

        public static string Trim(string sourceStr, string trimStr, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(sourceStr))
            {
                return string.Empty;
            }
            if (!string.IsNullOrEmpty(trimStr))
            {
                if (sourceStr.StartsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                {
                    sourceStr = sourceStr.Remove(0, trimStr.Length);
                }
                if (sourceStr.EndsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                {
                    sourceStr = sourceStr.Substring(0, sourceStr.Length - trimStr.Length);
                }
            }
            return sourceStr;
        }

        public static string TrimEnd(string sourceStr, string trimStr)
        {
            return TrimEnd(sourceStr, trimStr, true);
        }

        public static string TrimEnd(string sourceStr, string trimStr, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(sourceStr))
            {
                return string.Empty;
            }
            if (!(!string.IsNullOrEmpty(trimStr) && sourceStr.EndsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture)))
            {
                return sourceStr;
            }
            return sourceStr.Substring(0, sourceStr.Length - trimStr.Length);
        }

        public static string TrimStart(string sourceStr, string trimStr)
        {
            return TrimStart(sourceStr, trimStr, true);
        }

        public static string TrimStart(string sourceStr, string trimStr, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(sourceStr))
            {
                return string.Empty;
            }
            if (!(!string.IsNullOrEmpty(trimStr) && sourceStr.StartsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture)))
            {
                return sourceStr;
            }
            return sourceStr.Remove(0, trimStr.Length);
        }
        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = Regex.Replace(html, "<[^>]+>", "");
            strText = Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }
    }
}
