using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Domain;
using MyFrameWork.Common;
using DataService;

namespace WanTaiWeb.Areas.Web.Models
{
    public class UserCookieEncryptHelper
    {
        public static int Decrypt(string userIdCookie, string controllerName)
        {
            string userCookieKey = MyFrameWork.Ioc.ServiceLocator.Instance.Resolve<ISiteSettingsService>().GetSiteSettings("UserCookieKey").Value;
            if (string.IsNullOrEmpty(userCookieKey))
            {
                userCookieKey = SecureHelper.MD5(Guid.NewGuid().ToString());
                MyFrameWork.Ioc.ServiceLocator.Instance.Resolve<ISiteSettingsService>().SaveSetting(new SiteSettings { Key = "UserCookieKey", Value = userCookieKey });
            }
            string s = string.Empty;
            try
            {
                if (!string.IsNullOrWhiteSpace(userIdCookie))
                {
                    userIdCookie = HttpUtility.UrlDecode(userIdCookie);
                    userIdCookie = SecureHelper.DecodeBase64(userIdCookie);
                    s = SecureHelper.AESDecrypt(userIdCookie, userCookieKey);
                    s = s.Replace(controllerName + ",", "");
                }
            }
            catch (Exception exception)
            {
                //Log.Error(string.Format("解密用户标识Cookie出错，Cookie密文：{0}", userIdCookie), exception);
            }
            int result = 0;
            int.TryParse(s, out result);
            return result;
        }

        public static string Encrypt(long userId, string controllerName)
        {
            string str4;
            string userCookieKey = MyFrameWork.Ioc.ServiceLocator.Instance.Resolve<ISiteSettingsService>().GetSiteSettings("UserCookieKey").Value;
            if (string.IsNullOrEmpty(userCookieKey))
            {
                userCookieKey = SecureHelper.MD5(Guid.NewGuid().ToString());
                MyFrameWork.Ioc.ServiceLocator.Instance.Resolve<ISiteSettingsService>().SaveSetting(new SiteSettings { Key = "UserCookieKey", Value = userCookieKey });
            }
            string source = string.Empty;
            try
            {
                source = SecureHelper.AESEncrypt(controllerName + "," + userId.ToString(), userCookieKey);
                source = SecureHelper.EncodeBase64(source);
                str4 = source;
            }
            catch (Exception exception)
            {
                //Log.Error(string.Format("加密用户标识Cookie出错", source), exception);
                throw;
            }
            return str4;
        }
    }
}