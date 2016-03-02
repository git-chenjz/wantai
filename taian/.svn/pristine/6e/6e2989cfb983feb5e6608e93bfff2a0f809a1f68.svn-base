using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MyFrameWork.Common
{
    public class Md5
    {
        public static string Encode(string text)
        {

            #region version1.0 无法兼容php，MD5加密方法
            //char[] chars = text.ToCharArray();
            //var bytes = Encoding.Unicode.GetBytes(text.ToCharArray());
            //var hash = new MD5CryptoServiceProvider().ComputeHash(bytes);
            //return hash.Aggregate(new StringBuilder(32), (sb, b) => sb.Append(b.ToString("X2"))).ToString(); 
            #endregion

            byte[] b = Encoding.UTF8.GetBytes(text);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = string.Empty;
            for (int i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("x").PadLeft(2, '0');
            }
            return ret;
        }
    }
}
