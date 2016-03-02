using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace MyFrameWork.Common
{
    public static class ParameterHelper
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
    public class CookieHelper
    {
        private static object syncRoot = new object();
        private static CookieHelper instance;
        public static CookieHelper Current
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CookieHelper();
                    }
                }
                return instance;
            }
        }
        public void ClearTicketCookie(string userName, string domain = "")
        {
            SaveTicketCookie(userName, FormsAuthentication.FormsCookieName, string.Empty, -1, domain);
        }
        public void ClearTicketCookie(string userName, string cookieName, string domain = "")
        {
            SaveTicketCookie(userName, cookieName, string.Empty, -1, domain);
        }
        public void SaveTicketCookie(string userName, string userData, int expiresMinutes)
        {
            SaveTicketCookie(userName, FormsAuthentication.FormsCookieName, userData, expiresMinutes);
        }
        public void SaveTicketCookie(string userName, string cookieName, string userData, int expiresMinutes)
        {
            SaveTicketCookie(userName, cookieName, userData, expiresMinutes, "");
        }

        public void SaveTicketCookie(string userName, string cookieName, string userData, int expiresMinutes, string domain)
        {
            bool isMe = expiresMinutes != 0;
            FormsAuthentication.SetAuthCookie(userName, isMe, FormsAuthentication.FormsCookiePath);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1,
            userName,
            DateTime.Now,
            DateTime.Now.AddYears(1),
            isMe,
            userData, FormsAuthentication.FormsCookiePath);
            string cookieStr = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(cookieName, cookieStr);
            cookie.HttpOnly = true;
            if (isMe)
                cookie.Expires = DateTime.Now.AddMinutes(expiresMinutes);
            if (!domain.IsNullOrEmpty())
                cookie.Domain = domain;
            else
                cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = ticket.CookiePath;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public string GetTicketFromCookie()
        {
            return GetTicketFromCookie(FormsAuthentication.FormsCookieName);
        }

        public string GetTicketFromCookie(string cookieName)
        {
            var cookies = HttpContext.Current.Request.Cookies[cookieName];
            if (cookies != null && !cookies.Value.IsNullOrEmpty())
            {
                return GetTicketData(cookies.Value);
            }

            return string.Empty;
        }

        private string GetTicketData(string data)
        {
            if (!data.IsNullOrEmpty())
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(data);
                return ticket.UserData;
            }

            return string.Empty;
        }

        public void SaveCookie(string key, string value, string domain, DateTime? expires)
        {
            HttpCookie cookie = new HttpCookie(key, value);
            if (expires.HasValue)
                cookie.Expires = expires.Value;
            cookie.HttpOnly = true;
            if (!domain.IsNullOrEmpty())
                cookie.Domain = domain;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public string GetCookie(string cookieKey)
        {
            var cookies = HttpContext.Current.Request.Cookies[cookieKey];
            if (cookies != null && !cookies.Value.IsNullOrEmpty())
            {
                return cookies.Value;
            }

            return string.Empty;
        }

        public void ClearCookie(string cookieKey)
        {
            var cookies = HttpContext.Current.Request.Cookies[cookieKey];
            if (cookies == null)
            {
                cookies = new HttpCookie(cookieKey, "");
            }
            cookies.Expires = DateTime.Today.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookies);
            //HttpContext.Current.Request.Cookies.Remove(cookieKey);
        }
    }
}
