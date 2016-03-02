using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyFrameWork.Wechat
{
    /// <summary>
    /// 网页服务
    /// </summary>
    public class WebService
    {
        const string GETUSERCODE = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state={2}#wechat_redirect";
        const string GETUSERACCESSTOKEN = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
        const string REFRESHUSERACCESSTOKEN = "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}";
        const string CHECKUSERACCESSTOKEN = "https://api.weixin.qq.com/sns/auth?access_token={0}&openid={1}";
        const string GETTICKETAPI = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";
        const string DOWNLOADFILE = "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";

        #region 网页账号
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <returns></returns>
        public static WebResponse DownLoadImgMedia(string token, string mediaID)
        {
            var url = string.Format(DOWNLOADFILE, token, mediaID);
            return WXHelper.GetWebResponseByGet(url);
        }
        /// <summary>
        /// 通过地址跳转 取用户CODE
        /// 以snsapi_base为scope的网页授权，就静默授权的，用户无感知
        /// CODE只有5分钟有效时间
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUserCodeBySnsapi_base(string getCodeUrl, string state = "state")
        {
            return string.Format(GETUSERCODE, Config.APPID, HttpUtility.UrlEncode(getCodeUrl), state);
        }
        /// <summary>
        /// 通过code换取网页授权access_token
        /// </summary>
        /// <returns></returns>
        public static WX_UserAccessToken GetUserAccessToken(string code)
        {
            var url = string.Format(GETUSERACCESSTOKEN, Config.APPID, Config.APPSECRET, code);
            return WXHelper.GetWebContentByGet<WX_UserAccessToken>(url);
        }
        /// <summary>
        /// 刷新access_token（如果需要）
        /// </summary>
        /// <returns></returns>
        public static WX_UserAccessToken RefreshUserAccessToken(string refreshToken)
        {
            var url = string.Format(REFRESHUSERACCESSTOKEN, Config.APPID, refreshToken);
            return WXHelper.GetWebContentByGet<WX_UserAccessToken>(url);
        }
        /// <summary>
        /// 检验授权凭证（access_token）是否有效
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public static WX_Base CheckUserAccessToken(string userToken)
        {
            var url = string.Format(REFRESHUSERACCESSTOKEN, userToken, Config.APPID);
            return WXHelper.GetWebContentByGet<WX_Base>(url);
        }
        /// <summary>
        /// 获得jsapi_ticket
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static WX_TicketToken GetTicketToken()
        {
            var url = string.Format(GETTICKETAPI, Config.APPToken);
            return WXHelper.GetWebContentByGet<WX_TicketToken>(url);
        }
        #endregion
    }
}
