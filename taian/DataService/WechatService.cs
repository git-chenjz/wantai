using DataAccess.Domain;
using DataAccess.Repositories;
using DataAccess.Repositories.Impl;
using MyFrameWork.Data;
using MyFrameWork.Ioc;
using MyFrameWork.Wechat;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataService
{
    public class WechatService : BaseService, IWechatService
    {
        #region 字段
        private IWechatUserRepository _wechatUserRepository;
        private IWechatConfigRepository _wechatConfigRepository;
        private IWechatRedPackRepository _wehcatRedPackRepository;
        private IWechatTemplateRepository _wechatTemplateRepository;
        #endregion

        #region 构造
        public WechatService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IWechatUserRepository wechatUserRepository,
            IWechatConfigRepository wechatConfigRepository,
            IWechatRedPackRepository wehcatRedPackRepository,
            IWechatTemplateRepository wechatTemplateRepository
            )
            : base(mySqlUnitOfWork)
        {
            _wechatUserRepository = wechatUserRepository;
            _wechatConfigRepository = wechatConfigRepository;
            _wehcatRedPackRepository = wehcatRedPackRepository;
            _wechatTemplateRepository = wechatTemplateRepository;
        }
        #endregion

        #region 微信配置
        public WechatConfig GetWechatConfig()
        {
            var configs = _wechatConfigRepository.Get();
            if (configs.Any() == false)
            {
                var config = new WechatConfig { ID = Guid.NewGuid().ToString("N").ToUpper() };
                _wechatConfigRepository.Create(config);
                _wechatConfigRepository.Save();

                return config;
            }

            return configs.First();
        }
        public void SaveWechatConfig(WechatConfig config)
        {
            var temp = GetWechatConfig();

            temp.AppID = config.AppID;
            temp.AppSecret = config.AppSecret;
            temp.MchID = config.MchID;
            temp.MchKey = config.MchKey;

            _wechatConfigRepository.Save();
        }
        public void SaveWechatToken(WechatConfig config)
        {
            var temp = GetWechatConfig();

            temp.AppToken = config.AppToken;
            temp.AppTokenActiveTime = config.AppTokenActiveTime;
            temp.JsapiTicket = config.JsapiTicket;

            _wechatConfigRepository.Save();
        }
        public void SaveWechatToken()
        {
            var config = GetWechatConfig();

            Config.APPID = config.AppID;
            Config.APPSECRET = config.AppSecret;
            Config.MCHID = config.MchID;
            Config.KEY = config.MchKey;

            var token = SessionService.GetAccessToken();
            if (token.errcode == 0)
            {
                Config.APPToken = token.access_token;
                var ticket = WebService.GetTicketToken();

                Config.JsapiTicket = ticket.ticket;

                config.AppToken = token.access_token;
                config.AppTokenActiveTime = DateTime.Now.AddSeconds(token.expires_in).AddMinutes(-30);
                config.JsapiTicket = ticket.ticket;

                _wechatConfigRepository.Save();
            }
        }
        #endregion

        #region 微信用户
        public WechatUser GetWechatUserByCode(string code)
        {
            var user = WebService.GetUserAccessToken(code);
            if (user.errcode != 0)
                return null;

            var temp = new WechatUser
            {
                ID = Guid.NewGuid().ToString("N").ToUpper(),
                OpenID = user.openid
            };

            var users = _wechatUserRepository.Get(a => a.OpenID.Equals(user.openid));
            if (users.Any())
            {
                temp = users.First();
            }
            else
            {
                _wechatUserRepository.Create(temp);
            }

            temp.Token = user.access_token;
            temp.RefreshToken = user.refresh_token;
            temp.RefreshTime = DateTime.Now.AddSeconds(user.expires_in);

            var info = SessionService.GetUserInfo(temp.OpenID);
            if (info.errcode == 0)
            {
                temp.City = info.city;
                temp.Country = info.country;
                temp.Groupid = info.groupid;
                temp.HeadImgUrl = info.headimgurl;
                temp.Language = info.language;
                temp.NickName = info.nickname;
                temp.Province = info.province;
                temp.Remark = info.remark;
                temp.Sex = info.sex;
                temp.Subscribe = info.subscribe;
                temp.Unionid = info.unionid;
            }

            _wechatUserRepository.Save();
            return temp;
        }
        public WechatUser GetWechatUserByOpenID(string openID)
        {
            var temp = new WechatUser
            {
                ID = Guid.NewGuid().ToString("N").ToUpper(),
                OpenID = openID
            };

            var users = _wechatUserRepository.Get(a => a.OpenID.Equals(openID));
            if (users.Any())
            {
                temp = users.First();
            }
            else
            {
                _wechatUserRepository.Create(temp);
            }

            var info = SessionService.GetUserInfo(temp.OpenID);
            if (info.errcode == 0)
            {
                temp.City = info.city;
                temp.Country = info.country;
                temp.Groupid = info.groupid;
                temp.HeadImgUrl = info.headimgurl;
                temp.Language = info.language;
                temp.NickName = info.nickname;
                temp.Province = info.province;
                temp.Remark = info.remark;
                temp.Sex = info.sex;
                temp.Subscribe = info.subscribe;
                temp.Unionid = info.unionid;
                _wechatUserRepository.Save();

                return temp;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 微信红包
        /// <summary>
        /// 发送有奖调研红包
        /// </summary>
        /// <param name="openID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public WechatRedPack SendRedPack(string openID, int amount)
        {
            var time = DateTime.Now.Date;
            var no = string.Format("{0}{1}{2}",
                Config.MCHID,
                DateTime.Now.ToString("yyyyMMdd"),
                (_wehcatRedPackRepository.Get(a => a.SendTime >= time).Count() + 1).ToString().PadLeft(10, '0')
                );

            //记录发送红包
            var pack = new WechatRedPack
            {
                ActionName = "有奖调研",
                SendTime = DateTime.Now,
                Amount = amount,
                No = no,
                OpenID = openID,
                Result = "WAIT"
            };

            _wehcatRedPackRepository.Create(pack);
            _wehcatRedPackRepository.Save();

            //开始发送红包
            var result = PayService.SendRedPack(new WX_RedPackSend
            {
                act_name = pack.ActionName,
                client_ip = ConfigurationManager.AppSettings["ServiceIP"],
                mch_billno = pack.No,
                mch_id = Config.MCHID,
                nonce_str = pack.ID.ToString(),
                re_openid = openID,
                remark = ConfigurationManager.AppSettings["Remark"],
                send_name = ConfigurationManager.AppSettings["SendName"],
                total_amount = amount,
                total_num = 1,
                wishing = ConfigurationManager.AppSettings["Wishing"],
                wxappid = Config.APPID
            }.SetSign());

            //发送成功
            if (result.return_code == "SUCCESS" && result.result_code == "SUCCESS")
            {
                pack.ListID = result.send_listid;
                pack.Result = "SUCCESS";
                pack.Remark = result.return_msg;
            }
            else if (result.return_code == "SUCCESS")
            {
                pack.Result = result.result_code;
                pack.Remark = result.return_msg;
            }
            else
            {
                pack.Result = result.return_code;
                pack.Remark = result.return_msg;
            }

            _wehcatRedPackRepository.Update(pack);
            _wehcatRedPackRepository.Save();

            return pack;
        }
        #endregion

        #region 微信消息

        #endregion

        #region 微信定时处理
        /// <summary>
        /// 更新微信配置
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public static void RefreshTokens(object source, ElapsedEventArgs e)
        {
            if (source != null)
                (source as Timer).Stop();

            try
            {
                var wsv = ServiceLocator.Instance.Resolve<IWechatService>();

                var config = wsv.GetWechatConfig();

                Config.APPID = config.AppID;
                Config.APPSECRET = config.AppSecret;
                Config.MCHID = config.MchID;
                Config.KEY = config.MchKey;
                Config.APPToken = config.AppToken;
                Config.JsapiTicket = config.JsapiTicket;

                var time = DateTime.Now;
                if (config.AppTokenActiveTime == null || config.AppTokenActiveTime < time)
                {
                    var token = SessionService.GetAccessToken();
                    if (token.errcode == 0)
                    {
                        Config.APPToken = token.access_token;
                        var ticket = WebService.GetTicketToken();

                        Config.JsapiTicket = ticket.ticket;
                        config.AppToken = token.access_token;
                        config.AppTokenActiveTime = DateTime.Now.AddSeconds(token.expires_in).AddMinutes(-30);
                        config.JsapiTicket = ticket.ticket;

                        wsv.SaveWechatToken(config);
                    }
                }

            }
            catch (Exception ex)
            {
            }

            if (source != null)
                (source as Timer).Start();
        }


        #endregion
    }
}
