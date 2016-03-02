using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Wechat
{
    public class Weixin
    {
    }

    #region 接收信息

    public class WeixinText
    {
        public string ToUserName { get; set; }//开发者微信号
        public string FromUserName { get; set; }//发送方帐号（一个OpenID）
        public DateTime CreateTime { get; set; }//消息创建时间 （整型）
        public string MsgType { get; set; }//text
        public string Content { get; set; }//文本消息内容
        public string MsgId { get; set; }//消息id，64位整型
    }

    public class WeixinImage
    {
        public string ToUserName { get; set; }//开发者微信号
        public string FromUserName { get; set; }//发送方帐号（一个OpenID）
        public DateTime CreateTime { get; set; }//消息创建时间 （整型）
        public string MsgType { get; set; }//image
        public string PicUrl { get; set; }//图片链接
        public string MsgId { get; set; }//消息id，64位整型
    }


    public class WeixinVoice
    {
        public string ToUserName { get; set; }//开发者微信号
        public string FromUserName { get; set; }//发送方帐号（一个OpenID）
        public DateTime CreateTime { get; set; }//消息创建时间 （整型）
        public string MsgType { get; set; }//voice
        public string MediaId { get; set; } // 语音消息媒体id，可以调用多媒体文件下载接口拉取该媒体
        public string Format { get; set; } //语音格式：amr
        public string Recognition { get; set; } //语音识别结果，UTF8编码
        public string MsgId { get; set; }//消息id，64位整型
    }

    public class WeixinVideo
    {
        public string ToUserName { get; set; }//开发者微信号
        public string FromUserName { get; set; }//发送方帐号（一个OpenID）
        public DateTime CreateTime { get; set; }//消息创建时间 （整型）
        public string MsgType { get; set; }//视频为video
        public string MediaId { get; set; } // 视频消息媒体id，可以调用多媒体文件下载接口拉取数据
        public string ThumbMediaId { get; set; } //视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        public string MsgId { get; set; }//消息id，64位整型
    }


    public class WeixinLocation
    {
        public string ToUserName { get; set; }//开发者微信号
        public string FromUserName { get; set; }//发送方帐号（一个OpenID）
        public DateTime CreateTime { get; set; }//消息创建时间 （整型）
        public string MsgType { get; set; }//location
        public string LocationX { get; set; }//地理位置纬度
        public string LocationY { get; set; }//地理位置经度
        public string Scale { get; set; }//地图缩放大小
        public string Label { get; set; }//地理位置信息
        public string MsgId { get; set; }//消息id，64位整型
    }

    public class WeixinLink
    {
        public string ToUserName { get; set; }//接收方微信号
        public string FromUserName { get; set; }//发送方微信号，若为普通用户，则是一个OpenID
        public DateTime CreateTime { get; set; }//消息创建时间
        public string MsgType { get; set; }//消息类型，link
        public string Title { get; set; }//消息标题
        public string Description { get; set; }//消息描述
        public string Url { get; set; }//消息链接
        public string MsgId { get; set; }//消息id，64位整型
    }

    public class WeixinEvent
    {
        public string ToUserName { get; set; }//接收方微信号
        public string FromUserName { get; set; }//发送方微信号，若为普通用户，则是一个OpenID
        public DateTime CreateTime { get; set; }//消息创建时间
        public string MsgType { get; set; }//消息类型，event
        public string Event { get; set; }//事件类型，subscribe(订阅)、unsubscribe(取消订阅)、CLICK(自定义菜单点击事件)
        public string EventKey { get; set; }//事件KEY值，与自定义菜单接口中KEY值对应

        public string Latitude { get; set; } //地理位置纬度
        public string Longitude { get; set; } //地理位置经度
        public string Precision { get; set; }//地理位置精度

    }

    #endregion


    #region 微信支付信息
    public class WeixinPayAlarm
    {
        public string AppId { get; set; }//AppId
        public string ErrorType { get; set; }//警告类型
        public DateTime TimeStamp { get; set; }//消息创建时间
        public string Description { get; set; }//警告描述
        public string AlarmContent { get; set; }//警告详情
        public string AppSignature { get; set; }//

        public string SignMethod { get; set; } //签名方法
    }


    public class WeixinPayRights
    {
        public string OpenId { get; set; }//OpenId
        public DateTime TimeStamp { get; set; }//
        public string MsgType { get; set; }//

        public string FeedBackId { get; set; }//
        public string TransId { get; set; }//
        public string Reason { get; set; }//

        public string Solution { get; set; } //

        public string ExtInfo { get; set; } //

        public string AppSignature { get; set; } //
        public string SignMethod { get; set; }

        public List<WeixinPayRightsPicInfoItem> PicInfo { get; set; }//多个图片
    }

    public class WeixinPayRightsPicInfoItem
    {
        public string PicUrl { get; set; }
    }

    public class WeixinPaySuccessNotice
    {
        public string OpenId { get; set; }//支付用户的OpenId
        public string AppId { get; set; }//AppId
        public DateTime TimeStamp { get; set; }//支付成功的通知时间
        public string IsSubscribe { get; set; }//是否订阅了当前公众号
        public string NonceStr { get; set; }//返回信息
        public string AppSignature { get; set; }//

        public string SignMethod { get; set; } //签名方法
    }

    #endregion

    #region 回复信息

    public class WeixinResponText
    {
        public string ToUserName { get; set; }//接收方帐号（收到的OpenID）
        public string FromUserName { get; set; }//开发者微信号
        public DateTime CreateTime { get; set; }//消息创建时间 （整型）
        public string MsgType { get; set; }//text
        public string Content { get; set; }//回复的消息内容,长度不超过2048字节
        public string FuncFlag { get; set; }//位0x0001被标志时，星标刚收到的消息。
    }

    public class WeixinResponMusic
    {
        public string ToUserName { get; set; }//接收方帐号（收到的OpenID）
        public string FromUserName { get; set; }//开发者微信号
        public DateTime CreateTime { get; set; }//消息创建时间 （整型）
        public string MsgType { get; set; }//music
        public string Title { get; set; }
        public string Description { get; set; }
        public string MusicUrl { get; set; }//音乐链接
        public string HQMusicUrl { get; set; }//高质量音乐链接，WIFI环境优先使用该链接播放音乐
        public string FuncFlag { get; set; }//位0x0001被标志时，星标刚收到的消息。
    }

    public class WeixinResponNews
    {
        public WeixinResponNews()
        {
            Articles = new List<WeixinResponItem>();
        }

        public string ToUserName { get; set; }//接收方帐号（收到的OpenID）
        public string FromUserName { get; set; }//开发者微信号
        public DateTime CreateTime { get; set; }//消息创建时间 （整型）
        public string MsgType { get; set; }//news
        public int ArticleCount { get; set; }//图文消息个数，限制为10条以内
        public List<WeixinResponItem> Articles { get; set; }//多条图文消息信息，默认第一个item为大图
        public int FuncFlag { get; set; }//位0x0001被标志时，星标刚收到的消息
    }

    public class WeixinResponItem
    {
        public string Title { get; set; }//图文消息标题
        public string Description { get; set; }//图文消息描述
        public string PicUrl { get; set; }//图片链接，支持JPG、PNG格式，较好的效果为大图640*320，小图80*80
        public string Url { get; set; }//点击图文消息跳转链接
    }

    #endregion

    public class WeixinUserGroupWrap
    {
        public List<WeixinUserGroup> groups;
    }

    public class WeixinUserGroup
    {
        /// <summary>
        /// 分组ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 分组名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 分组下用户数
        /// </summary>
        public int cnt { get; set; }

        //高级接口
        public int count { get; set; }

        //public string GroupId { get; set; }
        //public string GroupName { get; set; }
    }

    /// <summary>
    /// 用户详细信息
    /// </summary>
    public class WeiXinUserInfo
    {
        /// <summary>
        /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
        /// </summary>
        public int subscribe { get; set; }

        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string openId { get; set; }

        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public string sex { get; set; }

        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 用户所在国家
        /// </summary>
        public string conuntry { get; set; }

        /// <summary>
        /// 用户所在省份
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 用户的语言，简体中文为zh_CN
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
        /// </summary>
        public string headimgurl { get; set; }

        /// <summary>
        /// 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        public string subscribe_time { get; set; }

        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段
        /// </summary>
        public string unionid { get; set; }


    }


    public class WeixinMpUser
    {
        //从微信公共平台用户管理页面获取的简略的用户信息
        public string id { get; set; }
        public string nick_name { get; set; }//*重用
        public string remark_name { get; set; }//*重用
        public string group_id { get; set; }//*重用

        //获取了微信用户详细信息之后的信息
        public string fake_id { get; set; }
        public string user_name { get; set; }
        public string signature { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string gender { get; set; }

        //高级接口中
        public string openid { get; set; }//用户的标识，对当前公众号唯一，同id
        public string nickname { get; set; }//用户的昵称
        public string headimgurl { get; set; }//用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空 
        public int subscribe { get; set; }//用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息
        public string language { get; set; }
        public string sex { get; set; }//用户的性别，值为1时是男性，值为2时是女性，值为0时是未知 
        public string subscribe_time { get; set; }
        //public string privilege;//用户特权信息，json 数组，如微信沃卡用户为（chinaunicom） 

        //额外添加的
        public string groupname { get; set; }
        public string OpenID { get; set; }
        public string PictureUrl { get; set; }
        public List<WeixinUserGroup> Groups;

        //public string FakeId { get; set; }
        //public string NickName { get; set; }
        //public string ReMarkName { get; set; }
        //public string Username { get; set; }
        //public string Signature { get; set; }
        //public string Country { get; set; }
        //public string Province { get; set; }
        //public string City { get; set; }
        //public string Sex { get; set; }
        //public string GroupID { get; set; }
        //public string PictureUrl { get; set; }


        //public string OpenID { get; set; }
    }

    //微信公众平台高级接口：获取关注者列表，数据结果
    //bluesky:2013-11-12
    public class WeixinMpUserList
    {
        public int total { set; get; }
        public int count { set; get; }
        public WeixinMpData data { set; get; }
        public string next_openid { set; get; }
    }

    public class WeixinMpData
    {
        public List<string> openid;
    }

    public class BaseResp
    {
        public int ret { get; set; }
        public string err_msg { get; set; }
    }

    //2013-10-30微信公众平台改版，数据结果发生变化
    public class WeixinMpContactInfo
    {
        public BaseResp base_resp;
        public WeixinMpUser contact_info;
        public WeixinUserGroupWrap groups;
    }

    public class WeixinMpAppmsg
    {
        public string appId { get; set; }
        public string count { get; set; }
        public string time { get; set; }
        public List<WeixinMpAppmsgItem> appmsgList { get; set; }
    }

    public class WeixinMpAppmsgItem
    {
        public string imgURL { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public string no_url { get; set; }
    }

    public class WeixinRspData
    {
        public string access_token { set; get; }
        public int expires_in { set; get; }
        public string refresh_token { set; get; }
        public string openid { set; get; }
        public string scope { set; get; }

        //error:
        public int errcode { set; get; }
        public string errmsg { set; get; }
    }

    #region 自定义计时器

    /// 
    /// 自定义定时器
    /// 
    public class MyTimer : System.Timers.Timer
    {
        static public int TimeCount { set; get; }

        public string AppMsgId { set; get; }

        public int UserCount { set; get; }

        public int SiteId { set; get; }

        /// 
        /// 构造函数
        /// 
        public MyTimer(double interval, string appMsgId, int userCount, int siteId)
            : base(interval)
        {
            AppMsgId = appMsgId;
            UserCount = userCount;
            SiteId = siteId;
        }

    }


    #endregion

    public enum WeixinMsgType { Text = 1, Image = 2, Location = 3, Link = 4, Event = 5, Music = 6, News = 7, Voice = 8, Video = 9, Unknown = 0 };


    public class WeixinCustomMenu
    {
        public string MenuId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ParentId { get; set; }
        public string Type { get; set; }
        public string ReturnType { get; set; }
        public string Url { get; set; }
        public Nullable<int> ShowOrder { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<int> CreatedBy { get; set; }

    }
}
