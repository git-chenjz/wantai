using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;
using MyFrameWork.Common;

namespace MyFrameWork.Wechat
{
    public class WeixinHelper
    {
        public static WeixinMsgType GetWeixinMsgType(XElement root)
        {
            var msgType = root.Element("MsgType");

            if (msgType == null)
            {
                return WeixinMsgType.Unknown;
            }

            var result = WeixinMsgType.Unknown;

            var value = msgType.Value;
            value = value.Replace("<![CDATA[", "");
            value = value.Replace("]]", "");

            switch (value)
            {
                case "text":
                    result = WeixinMsgType.Text;
                    break;
                case "image":
                    result = WeixinMsgType.Image;
                    break;
                case "voice":
                    result = WeixinMsgType.Voice;
                    break;
                case "video":
                    result = WeixinMsgType.Video;
                    break;
                case "location":
                    result = WeixinMsgType.Location;
                    break;
                case "link":
                    result = WeixinMsgType.Link;
                    break;
                case "event":
                    result = WeixinMsgType.Event;
                    break;
                default:
                    result = WeixinMsgType.Unknown;
                    break;
            }



            return result;
        }
        //解析微信文本消息
        public static WeixinImage ParseWeixinImage(XElement root)
        {
            var img = new WeixinImage();

            //XElement root = XElement.Load(inputStream);
            img.ToUserName = WeixinHelper.GetWeixinXmlElementValue(root.Element("ToUserName"));
            img.FromUserName = WeixinHelper.GetWeixinXmlElementValue(root.Element("FromUserName"));
            img.CreateTime = int.Parse(root.Element("CreateTime").Value).ToDateTime();
            img.MsgType = WeixinHelper.GetWeixinXmlElementValue(root.Element("MsgType"));
            img.PicUrl = WeixinHelper.GetWeixinXmlElementValue(root.Element("PicUrl"));
            img.MsgId = WeixinHelper.GetWeixinXmlElementValue(root.Element("MsgId"));

            return img;
        }

        //解析微信文本消息
        public static WeixinText ParseWeixinText(XElement root)
        {
            var text = new WeixinText();

            //XElement root = XElement.Load(inputStream);
            text.ToUserName = WeixinHelper.GetWeixinXmlElementValue(root.Element("ToUserName"));
            text.FromUserName = WeixinHelper.GetWeixinXmlElementValue(root.Element("FromUserName"));
            text.CreateTime = int.Parse(root.Element("CreateTime").Value).ToDateTime();
            text.MsgType = WeixinHelper.GetWeixinXmlElementValue(root.Element("MsgType"));
            text.Content = WeixinHelper.GetWeixinXmlElementValue(root.Element("Content"));
            text.MsgId = WeixinHelper.GetWeixinXmlElementValue(root.Element("MsgId"));

            return text;
        }

        //解析微信语音消息
        public static WeixinVoice ParseWeixinVoice(XElement root)
        {
            var voice = new WeixinVoice();

            voice.ToUserName = WeixinHelper.GetWeixinXmlElementValue(root.Element("ToUserName"));
            voice.FromUserName = WeixinHelper.GetWeixinXmlElementValue(root.Element("FromUserName"));
            voice.CreateTime = int.Parse(root.Element("CreateTime").Value).ToDateTime();
            voice.MsgType = WeixinHelper.GetWeixinXmlElementValue(root.Element("MsgType"));
            voice.MediaId = WeixinHelper.GetWeixinXmlElementValue(root.Element("MediaId"));
            voice.Format = WeixinHelper.GetWeixinXmlElementValue(root.Element("Format"));
            voice.Recognition = WeixinHelper.GetWeixinXmlElementValue(root.Element("Recognition"));
            voice.MsgId = WeixinHelper.GetWeixinXmlElementValue(root.Element("MsgId"));

            return voice;
        }

        //解析微信事件消息
        public static WeixinEvent ParseWeixinEvent(XElement root)
        {
            var weixinEvent = new WeixinEvent();

            //XElement root = XElement.Load(inputStream);
            weixinEvent.ToUserName = WeixinHelper.GetWeixinXmlElementValue(root.Element("ToUserName"));
            weixinEvent.FromUserName = WeixinHelper.GetWeixinXmlElementValue(root.Element("FromUserName"));
            weixinEvent.CreateTime = int.Parse(root.Element("CreateTime").Value).ToDateTime();
            weixinEvent.MsgType = WeixinHelper.GetWeixinXmlElementValue(root.Element("MsgType"));
            weixinEvent.Event = WeixinHelper.GetWeixinXmlElementValue(root.Element("Event"));
            weixinEvent.EventKey = WeixinHelper.GetWeixinXmlElementValue(root.Element("EventKey"));

            weixinEvent.Latitude = WeixinHelper.GetWeixinXmlElementValue(root.Element("Latitude"));
            weixinEvent.Longitude = WeixinHelper.GetWeixinXmlElementValue(root.Element("Longitude"));
            weixinEvent.Precision = WeixinHelper.GetWeixinXmlElementValue(root.Element("Precision"));


            return weixinEvent;
        }


        //解析微信支付的警告信息
        public static WeixinPayAlarm ParseWeixinPayAlarm(XElement root)
        {
            var weixinPayAlarm = new WeixinPayAlarm();

            //XElement root = XElement.Load(inputStream);
            weixinPayAlarm.AppId = WeixinHelper.GetWeixinXmlElementValue(root.Element("AppId"));
            weixinPayAlarm.ErrorType = WeixinHelper.GetWeixinXmlElementValue(root.Element("ErrorType"));
            weixinPayAlarm.Description = WeixinHelper.GetWeixinXmlElementValue(root.Element("Description"));
            weixinPayAlarm.AlarmContent = WeixinHelper.GetWeixinXmlElementValue(root.Element("AlarmContent"));
            weixinPayAlarm.TimeStamp = int.Parse(root.Element("TimeStamp").Value).ToDateTime();
            weixinPayAlarm.AppSignature = WeixinHelper.GetWeixinXmlElementValue(root.Element("EventKey"));

            weixinPayAlarm.SignMethod = WeixinHelper.GetWeixinXmlElementValue(root.Element("SignMethod"));


            return weixinPayAlarm;
        }

        //解析微信支付的客户权益XML信息
        public static WeixinPayRights ParseWeixinPayRights(XElement root)
        {
            var weixinPayRights = new WeixinPayRights();

            //XElement root = XElement.Load(inputStream);
            weixinPayRights.OpenId = WeixinHelper.GetWeixinXmlElementValue(root.Element("AppId"));
            weixinPayRights.TimeStamp = int.Parse(root.Element("TimeStamp").Value).ToDateTime();
            weixinPayRights.MsgType = WeixinHelper.GetWeixinXmlElementValue(root.Element("MsgType"));
            weixinPayRights.FeedBackId = WeixinHelper.GetWeixinXmlElementValue(root.Element("FeedBackId"));
            weixinPayRights.TransId = WeixinHelper.GetWeixinXmlElementValue(root.Element("TransId"));
            weixinPayRights.Reason = WeixinHelper.GetWeixinXmlElementValue(root.Element("Reason"));

            weixinPayRights.Solution = WeixinHelper.GetWeixinXmlElementValue(root.Element("Solution"));
            weixinPayRights.ExtInfo = WeixinHelper.GetWeixinXmlElementValue(root.Element("ExtInfo"));
            weixinPayRights.AppSignature = WeixinHelper.GetWeixinXmlElementValue(root.Element("AppSignature"));

            weixinPayRights.SignMethod = WeixinHelper.GetWeixinXmlElementValue(root.Element("SignMethod"));



            return weixinPayRights;
        }


        //解析微信支付成功的XML
        public static WeixinPaySuccessNotice ParseWeixinPaySuccessNotice(XElement root)
        {
            var weixinPaySuccessNotice = new WeixinPaySuccessNotice();

            //XElement root = XElement.Load(inputStream);
            weixinPaySuccessNotice.OpenId = WeixinHelper.GetWeixinXmlElementValue(root.Element("OpenId"));
            weixinPaySuccessNotice.TimeStamp = int.Parse(root.Element("TimeStamp").Value).ToDateTime();
            weixinPaySuccessNotice.AppId = WeixinHelper.GetWeixinXmlElementValue(root.Element("AppId"));
            weixinPaySuccessNotice.IsSubscribe = WeixinHelper.GetWeixinXmlElementValue(root.Element("IsSubscribe"));
            weixinPaySuccessNotice.NonceStr = WeixinHelper.GetWeixinXmlElementValue(root.Element("NonceStr"));
            weixinPaySuccessNotice.AppSignature = WeixinHelper.GetWeixinXmlElementValue(root.Element("AppSignature"));

            weixinPaySuccessNotice.SignMethod = WeixinHelper.GetWeixinXmlElementValue(root.Element("SignMethod"));

            return weixinPaySuccessNotice;
        }


        public static string GetWeixinXmlElementValue(XElement e)
        {
            if (e == null)
            {
                return null;
            }

            var value = e.Value;
            value = value.Replace("<![CDATA[", "");
            value = value.Replace("]]", "");

            return value;
        }



        #region 自定义菜单

        public static bool WeixinCustomMenus(string accessToken, List<WeixinCustomMenu> menus)
        {
            //var baseUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
            //var url = string.Format(baseUrl, appId, appSecret);
            //var dataReturn = RequestHelper.HttpGet(url, "", null);

            //var match = Regex.Match(dataReturn, "\"access_token\":\"(.*)\",");
            //string accessToken = null;
            //if (match != null)
            //{
            //    accessToken = match.Groups[1].Value;
            //}

            var cookieContainer = new CookieContainer();
            var dataReturn = "";
            //if (accessToken != null)
            //{
            var menusJson = "{\n";
            menusJson += "\"button\":[";
            var baseUrl = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";
            var url = string.Format(baseUrl, accessToken);

            //主按钮，1-3个
            foreach (var menu in menus.Where(x => x.ParentId == null))
            {
                //子按钮，2-5个
                var subMenus = menus.Where(x => x.ParentId == menu.MenuId).OrderBy(x => x.ShowOrder).Take(5).ToList();
                if (subMenus.Count > 0)
                {
                    menusJson += string.Format("\n{{\n\"name\":\"{0}\",\n", menu.Name);
                    var subMenusJson = "\"sub_button\":[";
                    foreach (var subMenu in subMenus)
                    {
                        if (subMenu.Type == "click")
                        {
                            subMenusJson += string.Format("\n{{\n\"type\":\"{0}\",\n\"name\":\"{1}\",\n\"key\":\"{2}\"\n}},", subMenu.Type, subMenu.Name, "SUBMENU" + subMenu.MenuId);
                        }
                        else
                        {
                            subMenusJson += string.Format("\n{{\n\"type\":\"{0}\",\n\"name\":\"{1}\",\n\"url\":\"{2}\"\n}},", subMenu.Type, subMenu.Name, subMenu.Url);
                        }
                    }
                    //去除结尾外多余的“，”
                    subMenusJson = subMenusJson.Substring(0, subMenusJson.Length - 1);

                    subMenusJson += "]\n";

                    menusJson += subMenusJson;
                    menusJson += "},";
                }
                else
                {
                    if (menu.Type == "click")
                    {
                        menusJson += string.Format("\n{{\"type\":\"{0}\",\n\"name\":\"{1}\",\n\"key\":\"{2}\"}},", menu.Type, menu.Name, "MENU" + menu.MenuId);
                    }
                    else
                    {
                        menusJson += string.Format("\n{{\"type\":\"{0}\",\n\"name\":\"{1}\",\n\"url\":\"{2}\"\n}},", menu.Type, menu.Name, menu.Url);
                    }

                }
            }

            //去掉结尾多余的“，”
            menusJson = menusJson.Substring(0, menusJson.Length - 1);

            menusJson += "]\n";
            menusJson += "}\n";


            //提交到服务器
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(menusJson);
            // 准备请求...
            try
            {
                // 设置参数
                request = WebRequest.Create(url) as HttpWebRequest;
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                string err = string.Empty;
                dataReturn = content;

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dataReturn = string.Empty;
            }

            //dataReturn = retString;
            //dataReturn = RequestHelper.HttpPost(url, "?"+menus, null);
            //正确结果：{"errcode":0,"errmsg":"ok"}
            //错误结果：{"errcode":40018,"errmsg":"invalid button name size"}
            var match = Regex.Match(dataReturn, "\"errmsg\":\"ok\"");

            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
            //}else

        }

        public static bool WeixinCustomMenusDelete(string appId, string appSecret)
        {

            var baseUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
            var url = string.Format(baseUrl, appId, appSecret);
            var dataReturn = RequestHelper.HttpGet(url, "", null);

            var match = Regex.Match(dataReturn, "\"access_token\":\"(.*)\",");
            string accessToken = null;
            if (match != null)
            {
                accessToken = match.Groups[1].Value;
            }

            var cookieContainer = new CookieContainer();
            if (accessToken != null)
            {
                url = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + accessToken;

                //提交到服务器
                dataReturn = RequestHelper.HttpGet(url, "", cookieContainer);

                //dataReturn = retString;
                //dataReturn = RequestHelper.HttpPost(url, "?"+menus, null);
                //正确结果：{"errcode":0,"errmsg":"ok"}
                //错误结果：{"errcode":40018,"errmsg":"invalid button name size"}
                match = Regex.Match(dataReturn, "\"errmsg\":\"ok\"");
                if (match.Success)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region 抽奖

        //获取抽奖随机数
        public static int LotteryGetRand(int[] vals)
        {
            var dataReturn = 1;

            //可取值总和
            var total = vals.Sum();

            //概率数组循环 
            var rand = new Random(new Object().GetHashCode());
            for (int i = 0; i < vals.Length; i++)
            {
                var num = rand.Next(1, total);
                if (num <= vals[i])
                {
                    dataReturn = i + 1;
                    break;
                }
                else
                {
                    total -= vals[i];
                }
            }

            return dataReturn;
        }

        #endregion


        #region 微信公众平台高级接口

        //access_token是公众号的全局唯一票据，公众号调用各接口时都需使用access_token。
        //正常情况下access_token有效期为7200秒，重复获取将导致上次获取的access_token失效。 
        public static string GetAcccessToken(string appId, string appSecret)
        {
            var urlBase = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
            var url = string.Format(urlBase, appId, appSecret);

            var data = RequestHelper.HttpGet(url, "", new CookieContainer());

            var match = Regex.Match(data, "access_token\":\"(.*)\",");
            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return null;
        }

        //jsapi_ticket
        public static string GetJSAPI_TICKET(string acccessToken)
        {
            var urlBase = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";
            var url = string.Format(urlBase, acccessToken);

            var data = RequestHelper.HttpGet(url, "", new CookieContainer());

            var match = Regex.Match(data, "ticket\":\"(.*)\",");
            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return null;
        }

        #region 生成带参数的二维码

        //生成临时二维码的图片链接
        //一般为：https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={TICKET}
        //最大数量为4294967295（32位整数），有有效期的限制
        public static string GetTemporaryDimCode(string accessToken, int scenceId, int time = 1800)
        {
            var url = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=" + accessToken;
            var postData = "{\"expire_seconds\": " + time + ", \"action_name\": \"QR_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": " + scenceId + "}}}";
            var data = RequestHelper.HttpPost(url, postData, new CookieContainer());

            //success:{"ticket":"gQG28DoAAAAAAAAAASxodHRwOi8vd2VpeGluLnFxLmNvbS9xL0FuWC1DNmZuVEhvMVp4NDNMRnNRAAIEesLvUQMECAcAAA==","expire_seconds":1800}
            //failed:{"errcode":40013,"errmsg":"invalid appid"},"{\"errcode\":48001,\"errmsg\":\"api unauthorized\"}"
            var match = Regex.Match(data, "ticket\":\"(.*)\",");
            if (match.Success)
            {
                return "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + match.Groups[1].Value;
            }

            return null;
        }

        //生成永久二维码的图片链接
        //一般为：https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={TICKET}
        //最大数量为1000
        public static string GetPermanentDimCode(string accessToken, int scenceId)
        {
            var url = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=" + accessToken;
            var postData = "{\"action_name\": \"QR_LIMIT_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": " + scenceId + "}}}";
            var data = RequestHelper.HttpPost(url, postData, new CookieContainer());

            //success:{"ticket":"gQG28DoAAAAAAAAAASxodHRwOi8vd2VpeGluLnFxLmNvbS9xL0FuWC1DNmZuVEhvMVp4NDNMRnNRAAIEesLvUQMECAcAAA==","expire_seconds":1800}
            //failed:{"errcode":40013,"errmsg":"invalid appid"},"{\"errcode\":48001,\"errmsg\":\"api unauthorized\"}","{\"errcode\":40052,\"errmsg\":\"invalid action name\"}"
            var match = Regex.Match(data, "ticket\":\"(.*)\",\"url\":");
            if (match.Success)
            {
                return "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + match.Groups[1].Value;
            }

            return null;
        }

        #endregion

        #region 客服消息

        //当用户主动发消息给公众号的时候，微信将会把消息数据推送给开发者，开发者在一段时间内（目前为48小时）可以调用客服消息接口，
        //通过POST一个JSON数据包来发送消息给普通用户，在48小时内不限制发送次数。此接口主要用于客服等有人工消息处理环节的功能，
        //方便开发者为用户提供更加优质的服务。 
        //public static string SaveWeixinUserImg(string url)
        //{
        //    try
        //    {
        //        string encodingName = string.Empty;
        //        WebRequest webRequest = HttpWebRequest.Create(url);
        //        HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
        //        Stream stream = webResponse.GetResponseStream();


        //        //将头像保存成本地文件
        //        var type = "user";
        //        string year = DateTime.Now.Year.ToString();
        //        string month = DateTime.Now.Month.ToString();
        //        string day = DateTime.Now.Day.ToString();
        //        string fileName = CommonHelper.GetFileName() + ".jpg";
        //        string time = year + "/" + month + "/" + day;

        //        if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/up/" + type + "/" + time)))
        //        {
        //            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/up/" + type + "/" + time));
        //        }

        //        byte[] arrayByte = new byte[1024];
        //        int imgLong = (int)webResponse.ContentLength;
        //        int l = 0;
        //        FileStream fso = new FileStream(HttpContext.Current.Server.MapPath("/up/" + type + "/" + time + "/" + fileName), FileMode.Create);
        //        while (l < imgLong)
        //        {
        //            int i = stream.Read(arrayByte, 0, 1024);
        //            fso.Write(arrayByte, 0, i);
        //            l += i;
        //        }


        //        string fileName_thumb = "/up/" + type + "/" + time + "/" + fileName + "_thumb.jpg";
        //        string fileName_small = "/up/" + type + "/" + time + "/" + fileName + "_small.jpg";
        //        string fileName_large = "/up/" + type + "/" + time + "/" + fileName + "_large.jpg";

        //        CommonHelper.MakeThumbnail_Stream(fso, HttpContext.Current.Server.MapPath(fileName_thumb), 60, 60, "Cut");
        //        CommonHelper.MakeThumbnail_Stream(fso, HttpContext.Current.Server.MapPath(fileName_small), 140, 140, "W");
        //        CommonHelper.MakeThumbnail_Stream(fso, HttpContext.Current.Server.MapPath(fileName_large), 300, 1, "W");


        //        fso.Close();

        //        stream.Close();

        //        return "/up/" + type + "/" + time + "/" + fileName;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        #endregion

        #region 用户

        //获取用户基本信息
        //bluesky:2013-11-12
        public static WeixinMpUser GetUserInfo(string accessToken, string openId)
        {
            var urlBase = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";
            var url = string.Format(urlBase, accessToken, openId);

            var data = RequestHelper.HttpGet(url, "", new CookieContainer());

            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(WeixinMpUser));

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));

            var user = (WeixinMpUser)ds.ReadObject(ms);

            //下载微信公众平台的头像图片到本地
            if (user != null && !string.IsNullOrEmpty(user.headimgurl))
            {

                //var pictureUrl = WeixinHelper.SaveWeixinUserImg(user.headimgurl);

                //if (!string.IsNullOrEmpty(pictureUrl))
                //{
                //    user.PictureUrl = pictureUrl;
                //}
                //else
                //{
                user.PictureUrl = user.headimgurl;
                //}
            }

            return user;
        }

        public static WeiXinUserInfo GetWeixinUserInfo(string accessToken, string openId)
        {
            var urlBase = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";
            var url = string.Format(urlBase, accessToken, openId);

            var data = RequestHelper.HttpGet(url, "", new CookieContainer());

            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(WeiXinUserInfo));

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));

            var user = (WeiXinUserInfo)ds.ReadObject(ms);

            //下载微信公众平台的头像图片到本地
            //if (user != null && !string.IsNullOrEmpty(user.headimgurl))
            //{

            //    var pictureUrl = WeixinHelper.SaveWeixinUserImg(user.headimgurl);


            //    if (!string.IsNullOrEmpty(pictureUrl))
            //    {
            //        user.headimgurl = pictureUrl;
            //    }
            //}

            return user;
        }

        //获取关注者列表
        public static WeixinMpUserList GetUsers(string accessToken)
        {
            var urlBase = "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}";
            var url = string.Format(urlBase, accessToken);

            var data = RequestHelper.HttpGet(url, "", new CookieContainer());

            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(WeixinMpUserList));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));

            var users = (WeixinMpUserList)ds.ReadObject(ms);

            #region 样例

            //{
            //  "total":23000,
            //  "count":10000,
            //  "data":{"
            //     openid":[
            //        "OPENID1",
            //        "OPENID2",
            //        ...,
            //        "OPENID10000"
            //     ]
            //   },
            //   "next_openid":"NEXT_OPENID1"
            //}


            #endregion

            return users;
        }

        #endregion

        #region 分组

        public static WeixinUserGroupWrap GetGroups(string accessToken)
        {
            var urlBase = "https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}";
            var url = string.Format(urlBase, accessToken);

            var data = RequestHelper.HttpGet(url, "", new CookieContainer());

            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(WeixinUserGroupWrap));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));

            var groups = (WeixinUserGroupWrap)ds.ReadObject(ms);

            return groups;
        }

        //创建分组
        //一个公众账号，最多支持创建500个分组
        //bluesky:2013-11-12
        public static WeixinUserGroup CreateGroup(string accessToken, string groupName)
        {
            var urlBase = "https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}";
            var url = string.Format(urlBase, accessToken);

            var postData = "{\"group\":{\"name\":\"" + groupName + "\"}}";

            string data = null;
            try
            {
                data = RequestHelper.HttpPost(url, postData, new CookieContainer());
            }
            catch (Exception eeee)
            {
            }

            //success:data=="{\"group\":{\"id\":102,\"name\":\"test\"}}"


            var dataCut = "";
            if (data != null)
            {
                var start = data.IndexOf("{\"id\":");
                var end = data.LastIndexOf("}");
                dataCut = data.Substring(start, end - start);
            }

            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(WeixinUserGroup));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(dataCut));

            var group = (WeixinUserGroup)ds.ReadObject(ms);

            return group;
        }

        //修改分组名
        //bluesky:2013-11-12
        public static bool EditGroup(string accessToken, int groupId, string newGroupName)
        {
            var urlBase = "https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}";
            var url = string.Format(urlBase, accessToken);

            var postData = "{\"group\":{\"id\":" + groupId + ",\"name\":\"" + newGroupName + "\"}}";

            var data = RequestHelper.HttpPost(url, postData, new CookieContainer());

            //success:data=="{\"errcode\":0,\"errmsg\":\"ok\"}"
            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(WeixinRspData));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));

            var rspData = (WeixinRspData)ds.ReadObject(ms);

            if (rspData != null)
            {
                return rspData.errcode == 0;
            }

            return false;
        }

        //移动用户分组
        //移动成功后，该用户即成为该分组下排在第一位置的用户
        //bluesky:2013-11-12
        public static bool MoveToGroup(string accessToken, string openId, int toGroupId)
        {
            var urlBase = "https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token={0}";
            var url = string.Format(urlBase, accessToken);

            var postData = "{\"openid\":\"" + openId + "\",\"to_groupid\":" + toGroupId + "}";

            var data = RequestHelper.HttpPost(url, postData, new CookieContainer());

            //success:data=="{\"errcode\":0,\"errmsg\":\"ok\"}"
            //failed(eg):data=={"errcode":40013,"errmsg":"invalid appid"}
            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(WeixinRspData));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));

            var rspData = (WeixinRspData)ds.ReadObject(ms);

            if (rspData != null)
            {
                return rspData.errcode == 0;
            }

            return false;
        }

        #endregion


        #endregion

    }

    public class WeixinTextMessageSend
    {
        private string AccessToken { get; set; }
        private string WeixinUserOpenId { get; set; }

        public string Message { get; set; }

        public WeixinTextMessageSend(string accessToken, string openId, string msg)
        {
            AccessToken = accessToken;
            WeixinUserOpenId = openId;
            Message = msg;
        }

        public bool Send()
        {
            return SendTextMessage(AccessToken, WeixinUserOpenId, Message);
        }


        private bool SendTextMessage(string accessToken, string openId, string content)
        {
            var postData = "{\n";
            postData += "\"touser\":\"" + openId + "\",\n";
            postData += "\"msgtype\":\"text\",\n";
            postData += "\"text\":\n";
            postData += "{\n";
            postData += "\"content\":\"" + content + "\"\n";
            postData += "}\n";
            postData += "}";


            var url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + accessToken;

            var data = RequestHelper.HttpPost(url, postData, new CookieContainer());


            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(WeixinRspData));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));

            var rspData = (WeixinRspData)ds.ReadObject(ms);

            if (rspData != null)
            {
                return rspData.errcode == 0;
            }

            return false;
        }

    }

    public class WeixinNewsMessageSend
    {
        private string WeixinAppId { get; set; }
        private string WeixinAppSecret { get; set; }
        private string WeixinUserOpenId { get; set; }

        public WeixinResponNews News { get; set; }

        public WeixinNewsMessageSend(string AppId, string AppSecret, string openId, WeixinResponNews news)
        {
            WeixinAppId = AppId;
            WeixinAppSecret = AppSecret;
            WeixinUserOpenId = openId;
            News = news;
        }

        public bool Send()
        {
            var accessToken = WeixinHelper.GetAcccessToken(WeixinAppId, WeixinAppSecret);

            return SendNewsMessage(accessToken, WeixinUserOpenId, News);
        }

        private bool SendNewsMessage(string accessToken, string openId, WeixinResponNews news)
        {
            var postData = "{\n";
            postData += "\"touser\":\"" + openId + "\",\n";
            postData += "\"msgtype\":\"news\",\n";
            postData += "\"news\":\n";
            postData += "{\n";
            postData += "\"articles\": [";

            for (int i = 0; i < news.ArticleCount; i++)
            {

                postData += "{";
                postData += "\"title\":\"" + news.Articles[i].Title + "\",";
                postData += "\"description\":\"" + news.Articles[i].Description + "\",";
                postData += "\"url\":\"" + news.Articles[i].Url + "\",";
                postData += "\"picurl\":\"" + news.Articles[i].PicUrl + "\",";
                postData += "}";
                if (i != news.ArticleCount - 1)
                {
                    postData += ",";
                }
            }
            postData += "]\n";
            postData += "}\n";
            postData += "}";


            var url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + accessToken;

            var data = RequestHelper.HttpPost(url, postData, new CookieContainer());

            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(WeixinRspData));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));

            var rspData = (WeixinRspData)ds.ReadObject(ms);

            if (rspData != null)
            {
                return rspData.errcode == 0;
            }

            return false;
        }

    }

    public class WeixinTemplateMessageSend
    {
        private string WeixinAppId { get; set; }
        private string WeixinAppSecret { get; set; }
        private string WeixinUserOpenId { get; set; }

        public string TemplateId { get; set; }

        public string TargetUrl { get; set; }

        public string Detail { get; set; }

        public WeixinTemplateMessageSend(string AppId, string AppSecret, string openId, string templateId, string targetUrl, string detail)
        {
            WeixinAppId = AppId;
            WeixinAppSecret = AppSecret;
            WeixinUserOpenId = openId;
            TemplateId = templateId;
            TargetUrl = targetUrl;
            Detail = detail;
        }

        public bool Send()
        {
            var accessToken = WeixinHelper.GetAcccessToken(WeixinAppId, WeixinAppSecret);

            return SendTemplateMessage(accessToken);
        }
        private bool SendTemplateMessage(string accessToken)
        {
            var postData = "{\n";
            postData += "\"touser\":\"" + WeixinUserOpenId + "\",\n";
            postData += "\"template_id\":\"" + TemplateId + "\",\n";
            postData += "\"url\":\"" + TargetUrl + "\",\n";
            postData += "\"topcolor\":\"#ff0000\",\n";
            postData += "\"data\":\n";
            postData += "{\n";
            postData += Detail;
            postData += "}\n";
            postData += "}";

            var url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + accessToken;

            var data = RequestHelper.HttpPost(url, postData, new CookieContainer());

            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(WeixinRspData));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));

            var rspData = (WeixinRspData)ds.ReadObject(ms);

            if (rspData != null)
            {
                return rspData.errcode == 0;
            }

            return false;
        }


    }
}
