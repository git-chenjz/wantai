using MyFrameWork.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace MyFrameWork.Wechat
{
    /// <summary>
    /// 微信基础配置
    /// </summary>
    public partial class Config
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public static string APPID { get; set; }
        /// <summary>
        /// 应用密钥
        /// </summary>
        public static string APPSECRET { get; set; }
        /// <summary>
        /// 应用通行证
        /// </summary>
        public static string APPToken { get; set; }
        /// <summary>
        /// 脚本通行证
        /// </summary>
        public static string JsapiTicket { get; set; }
        /// <summary>
        /// 商户ID
        /// </summary>
        public static string MCHID { get; set; }
        /// <summary>
        /// 商户密钥
        /// </summary>
        public static string KEY { get; set; }
        /// <summary>
        /// 支付异步通知url
        /// </summary>
        public static string NOTIFY_URL { get; set; }
    }

    /// <summary>
    /// 微信帮助类
    /// </summary>
    public class WXHelper
    {
        /// <summary>
        /// 通过GET方式 获取URL内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T GetWebContentByGet<T>(string url)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            using (WebResponse wr = req.GetResponse())
            {
                HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

                return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
        }
        /// <summary>
        /// 通过GET方式 获取URL内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static WebResponse GetWebResponseByGet(string url)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            return req.GetResponse();
        }
        /// <summary>
        /// 通过POST方式 获取URL内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T GetWebContentByPost<T>(string url, object source)
        {
            var js = JsonConvert.SerializeObject(source);

            byte[] bytes = Encoding.UTF8.GetBytes(js);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "text/xml";
            Stream reqstream = request.GetRequestStream();
            reqstream.Write(bytes, 0, bytes.Length);

            //声明一个HttpWebRequest请求  
            request.Timeout = 90000;
            //设置连接超时时间  
            request.Headers.Set("Pragma", "no-cache");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamReceive = response.GetResponseStream();
            Encoding encoding = Encoding.UTF8;

            StreamReader streamReader = new StreamReader(streamReceive, encoding);
            string strResult = streamReader.ReadToEnd();
            streamReceive.Dispose();
            streamReader.Dispose();

            return JsonConvert.DeserializeObject<T>(strResult);
        }
        /// <summary>
        /// 通过POST方式 获取URL内容 (XML格式转换)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T GetWebContentByPostXML<T>(string url, object source, Action<HttpWebRequest> action)
        {
            var js = ObjectToXml(source);

            byte[] bytes = Encoding.UTF8.GetBytes(js);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            action(request);
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "text/xml";
            Stream reqstream = request.GetRequestStream();
            reqstream.Write(bytes, 0, bytes.Length);

            //声明一个HttpWebRequest请求  
            request.Timeout = 90000;
            //设置连接超时时间  
            request.Headers.Set("Pragma", "no-cache");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamReceive = response.GetResponseStream();
            Encoding encoding = Encoding.UTF8;

            StreamReader streamReader = new StreamReader(streamReceive, encoding);
            string strResult = streamReader.ReadToEnd();
            streamReceive.Dispose();
            streamReader.Dispose();

            return GetXml<T>(strResult);
        }

        /// <summary>
        /// 提取XML数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static SortedDictionary<string, object> GetXml(HttpRequestBase request)
        {
            var result = new SortedDictionary<string, object>();

            //接收从微信后台POST过来的数据
            System.IO.Stream s = request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();

            var xml = builder.ToString();

            if (string.IsNullOrEmpty(xml))
            {
                throw new Exception("将空的xml串转换为WxPayData不合法!");
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode xmlNode = xmlDoc.FirstChild;//获取到根节点<xml>
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.HasChildNodes)
                {
                    List<string> temp = new List<string>();
                    foreach (XmlNode x in xe.ChildNodes)
                    {
                        temp.Add(x.InnerText);
                    }
                    result[xe.Name] = string.Join("|", temp);
                }
                else
                {
                    result[xe.Name] = xe.InnerText;
                }
            }

            return result;
        }
        public static T GetXml<T>(string source)
        {
            var result = new Dictionary<string, string> { };

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(source);
            XmlNode xmlNode = xmlDoc.FirstChild;//获取到根节点<xml>
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.HasChildNodes)
                {
                    List<string> temp = new List<string>();
                    foreach (XmlNode x in xe.ChildNodes)
                    {
                        temp.Add(x.InnerText);
                    }
                    result.Add(xe.Name, string.Join("|", temp));
                }
                else
                {
                    result.Add(xe.Name, xe.InnerText);
                }
            }

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result));
        }
        /// <summary>
        /// 生成XML数据
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string ToXml(SortedDictionary<string, object> dic)
        {
            string xml = "<xml>";
            foreach (KeyValuePair<string, object> pair in dic)
            {
                //字段值不能为null，会影响后续流程
                if (pair.Value == null)
                {
                    throw new Exception("内部含有值为null的字段!");
                }

                if (pair.Value.GetType() == typeof(int))
                {
                    xml += "<" + pair.Key + ">" + pair.Value + "</" + pair.Key + ">";
                }
                else if (pair.Value.GetType() == typeof(string))
                {
                    xml += "<" + pair.Key + ">" + "<![CDATA[" + pair.Value + "]]></" + pair.Key + ">";
                }
                else//除了string和int类型不能含有其他数据类型
                {
                    throw new Exception("字段数据类型错误!");
                }
            }
            xml += "</xml>";
            return xml;
        }
        /// <summary>
        /// 生成XML数据
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ObjectToXml(object source)
        {
            var result = new StringBuilder("");
            result.Append("<xml>");

            var ps = source.GetType().GetProperties();
            foreach (var x in ps)
            {
                if (x.PropertyType.IsAssignableFrom(typeof(int)))
                {
                    result.AppendFormat("<{0}>{1}</{0}>", x.Name, x.GetValue(source, null));
                }
                else
                {
                    result.AppendFormat("<{0}><![CDATA[{1}]]></{0}>", x.Name, x.GetValue(source, null));
                }
            }

            result.Append("</xml>");
            return result.ToString();
        }
    }

    #region 微信类定义 基础
    public class WX_Base
    {
        /// <summary>
        /// 失败时：代码
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 失败时：信息
        /// </summary>
        public string errmsg { get; set; }
    }
    #endregion

    #region 微信类定义 会话服务
    /// <summary>
    /// 获取accesstoken时返回的类
    /// </summary>
    public class WX_AccessToken : WX_Base
    {
        /// <summary>
        /// 成功时：获取到的凭证
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 成功时：凭证有效时间，单位：秒
        /// </summary>
        public int expires_in { get; set; }
    }
    /// <summary>
    /// 获取微信服务器的IP列表
    /// </summary>
    public class WX_IP : WX_Base
    {
        /// <summary>
        /// 微信服务器IP地址列表
        /// </summary>
        public List<string> ip_list { get; set; }
    }
    /// <summary>
    /// 获取用户信息返回的类
    /// </summary>
    public class WX_UserInfo : WX_Base
    {
        /// <summary>
        /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
        /// </summary>
        public int subscribe { get; set; }
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public int sex { get; set; }
        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 用户所在国家
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 用户所在省份
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 用户的语言，简体中文为zh_CN
        /// </summary>
        public string language { get; set; }
        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。若用户更换头像，原有头像URL将失效。
        /// </summary>
        public string headimgurl { get; set; }
        /// <summary>
        /// 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        public int subscribe_time { get; set; }
        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段
        /// </summary>
        public string unionid { get; set; }
        /// <summary>
        /// 公众号运营者对粉丝的备注，公众号运营者可在微信公众平台用户管理界面对粉丝添加备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 用户所在的分组ID
        /// </summary>
        public string groupid { get; set; }
    }
    /// <summary>
    /// 获取用户信息返回的类
    /// </summary>
    public class WX_UserInfos : WX_Base
    {
        /// <summary>
        /// 用户信息列表
        /// </summary>
        public List<WX_UserInfo> user_info_list { get; set; }
    }
    /// <summary>
    /// 获取关注者列表
    /// </summary>
    public class WX_UserList : WX_Base
    {
        public class _data
        {
            public string[] openid { get; set; }
        }

        public int total { get; set; }
        public int count { get; set; }
        public string next_openid { get; set; }
        public _data data { get; set; }
    }
    /// <summary>
    /// 发送模板消息返回数据
    public class WX_TemplateResult : WX_Base
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string msgid { get; set; }
    }
    /// <summary>
    /// 发送模板消息数据
    /// </summary>
    public class WX_TemplateSend
    {
        /// <summary>
        /// openID
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 模板ID
        /// </summary>
        public string template_id { get; set; }
        /// <summary>
        /// 跳转地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 发送数据
        /// </summary>
        public object data { get; set; }
    }
    #endregion

    #region 微信类定义 网页服务
    /// <summary>
    /// 通过用户的CODE返回的用户Token信息
    /// </summary>
    public class WX_UserAccessToken : WX_Base
    {
        /// <summary>
        /// 网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// access_token接口调用凭证超时时间，单位（秒）
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        public string refresh_token { get; set; }
        /// <summary>
        /// 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        public string scope { get; set; }
        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        public string unionid { get; set; }
    }
    /// <summary>
    /// 通过AccessToken取Ticket
    /// </summary>
    public class WX_TicketToken : WX_Base
    {
        public string ticket { get; set; }
        public int? expires_in { get; set; }
    }
    #endregion

    #region 微信类定义 支付服务
    /// <summary>
    /// 红包发送数据
    /// </summary>
    public class WX_RedPackSend
    {
        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
        public string nonce_str { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 商户订单号	
        /// </summary>
        public string mch_billno { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 公众账号appid
        /// </summary>
        public string wxappid { get; set; }
        /// <summary>
        /// 红包发送者名称
        /// </summary>
        public string send_name { get; set; }
        /// <summary>
        /// 接受红包的用户用户在wxappid下的openid
        /// </summary>
        public string re_openid { get; set; }
        /// <summary>
        /// 付款金额，单位分
        /// </summary>
        public int total_amount { get; set; }
        /// <summary>
        /// 红包发放总人数
        /// </summary>
        public int total_num { get; set; }
        /// <summary>
        /// 祝福语
        /// </summary>
        public string wishing { get; set; }
        /// <summary>
        /// 调用接口的机器Ip地址
        /// </summary>
        public string client_ip { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string act_name { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <returns></returns>
        public WX_RedPackSend SetSign()
        {
            var ps = this.GetType().GetProperties().Where(a => a.Name != "sign").OrderBy(a => a.Name);
            var result = "";
            foreach (var x in ps)
            {
                if (result == "")
                {
                    result = string.Format("{0}={1}", x.Name, x.GetValue(this, null));
                }
                else
                {
                    result = string.Format("{0}&{1}={2}", result, x.Name, x.GetValue(this, null));
                }
            }

            result = string.Format("{0}&key={1}", result, Config.KEY);

            this.sign = Md5.Encode(result).ToUpper();

            return this;
        }
    }
    /// <summary>
    /// 红包接收数据
    /// </summary>
    public class WX_RedPackResult
    {
        /// <summary>
        /// 返回状态码	SUCCESS/FAIL
        /// </summary>
        public string return_code { get; set; }
        /// <summary>
        /// 返回信息 返回信息，如非空，为错误原因 签名失败 参数格式校验错误
        /// </summary>
        public string return_msg { get; set; }

        #region 以下字段在return_code为SUCCESS的时候有返回
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 业务结果	SUCCESS/FAIL
        /// </summary>
        public string result_code { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public string err_code { get; set; }
        /// <summary>
        /// 错误代码描述
        /// </summary>
        public string err_code_des { get; set; }
        #endregion

        #region 以下字段在return_code和result_code都为SUCCESS的时候有返回
        /// <summary>
        /// 商户订单号	
        /// </summary>
        public string mch_billno { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 公众账号appid
        /// </summary>
        public string wxappid { get; set; }
        /// <summary>
        /// 用户openid
        /// </summary>
        public string re_openid { get; set; }
        /// <summary>
        /// 付款金额
        /// </summary>
        public int total_amount { get; set; }
        /// <summary>
        /// 发放成功时间
        /// </summary>
        public string send_time { get; set; }
        /// <summary>
        /// 微信单号	
        /// </summary>
        public string send_listid { get; set; }
        #endregion
    }
    #endregion
}
