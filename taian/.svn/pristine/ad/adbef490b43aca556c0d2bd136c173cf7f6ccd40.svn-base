using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IWechatService
    {
        WechatConfig GetWechatConfig();
        void SaveWechatConfig(WechatConfig config);
        void SaveWechatToken();
        void SaveWechatToken(WechatConfig config);
        WechatRedPack SendRedPack(string openID, int amount);
        WechatUser GetWechatUserByCode(string code);
        WechatUser GetWechatUserByOpenID(string openID);
    }
}
