using MyFrameWork.Wechat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace WanTaiWeb.Areas.Wechat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //token验证
            var echostr = Request.Params["echostr"];//随机字符串
            var signature = Request.Params["signature"];//微信加密签名
            var timestamp = Request.Params["timestamp"];//时间戳
            var nonce = Request.Params["nonce"];//随机数

            //由管理员在微信后台配置页面输入，这里仅仅是验证而已，可以随意设定，只要保证微信和这里能够一致就可以了
            var token = "wantai2016";


            var tmpArr = new List<string> { token, timestamp, nonce };
            tmpArr.Sort();
            var tmpArrToStr = tmpArr[0] + tmpArr[1] + tmpArr[2];
            var tmpArrToArray = System.Text.Encoding.Default.GetBytes(tmpArrToStr);


            //sha1加密后与签名对比
            var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(tmpArrToArray);


            var strHashData = System.BitConverter.ToString(sha1);
            if (strHashData != null)
            {
                strHashData = strHashData.Replace("-", "").ToLower();
            }


            if (strHashData.Equals(signature))
            {
                ViewBag.echostr = echostr;
            }

            return Content(ViewBag.echostr);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            XElement root = XElement.Load(Request.InputStream);

            var msgType = WeixinHelper.GetWeixinMsgType(root);

            if (msgType == WeixinMsgType.Text)
            {
                #region 文本消息

                #endregion
            }
            else if (msgType == WeixinMsgType.Video)
            {
                #region  视频消息

                #endregion
            }
            else if (msgType == WeixinMsgType.Voice)
            {
                #region  语音消息

                #endregion
            }
            else if (msgType == WeixinMsgType.Event)
            {
                #region 事件消息
                var weixinEvent = WeixinHelper.ParseWeixinEvent(root);

                var rspText = new WeixinResponText();
                rspText.ToUserName = weixinEvent.FromUserName;
                rspText.FromUserName = weixinEvent.ToUserName;
                rspText.CreateTime = DateTime.Now;

                var WeixinEvent = weixinEvent.Event.ToLower();
                if (!string.IsNullOrEmpty(WeixinEvent))
                {
                    WeixinEvent = WeixinEvent.ToLower();
                }
                if (WeixinEvent == "subscribe")//订阅（关注）该公共账号
                {

                }
                else if (WeixinEvent == "scan")//二维码扫描
                {

                }
                else if (WeixinEvent == "unsubscribe")//取消订阅
                {

                }
                else if (WeixinEvent == "click")//自定义菜单点击事件
                {

                }
                else if (WeixinEvent == "location")  //用户上报地理位置信息
                {

                }

                return View("ResponText", rspText);

                #endregion
            }
            else if (msgType == WeixinMsgType.Image)
            {
                #region 图片消息

                #endregion
            }
            return Content("success");
        }


        [ValidateInput(false)]
        public ActionResult SeftHelpInfo(string keyword, string xml)
        {
            var news = new WeixinResponNews();

            var root = XElement.Parse(xml);

            var text = WeixinHelper.ParseWeixinText(root);

            var rspText = new WeixinResponText();
            rspText.ToUserName = text.FromUserName;
            rspText.FromUserName = text.ToUserName;
            rspText.CreateTime = DateTime.Now;

            return View("ResponText", rspText);
        }
    }
}