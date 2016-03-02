using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Common
{
    public class RequestHelper
    {
        public static string GetIP()
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            if (string.IsNullOrEmpty(ip))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            return ip;
        }

        //普通的HttpGet请求
        public static string HttpGet(string Url, string postDataStr, CookieContainer cookie)
        {
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.CookieContainer = cookie;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //普通的HttpPost请求
        public static string HttpPost(string Url, string postDataStr, CookieContainer cookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            var myEncoding = Encoding.GetEncoding("utf-8");

            if (postDataStr == null)
            {
                postDataStr = "";
            }

            var postBytes = Encoding.UTF8.GetBytes(postDataStr);

            request.ContentLength = postBytes.Length;
            request.CookieContainer = cookie;
            using (Stream myRequestStream = request.GetRequestStream())
            {
                myRequestStream.Write(postBytes, 0, postBytes.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, myEncoding);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }


        public static string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=gbk";

            var myEncoding = Encoding.GetEncoding("gbk");

            if (postDataStr == null)
            {
                postDataStr = "";
            }


            var postBytes = Encoding.UTF8.GetBytes(postDataStr);

            //byte[] postBytes = Encoding.ASCII.GetBytes(postDataStr);

            request.ContentLength = postBytes.Length;
            using (Stream myRequestStream = request.GetRequestStream())
            {
                myRequestStream.Write(postBytes, 0, postBytes.Length);
            }
            //StreamWriter myStreamWriter = new StreamWriter(myRequestStream, myEncoding);
            //myStreamWriter.Write(postDataStr);
            //myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, myEncoding);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
    }
}
