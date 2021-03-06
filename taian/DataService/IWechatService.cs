﻿using DataAccess.Domain;
using MyFrameWork.Common;
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

        void UpdateUserPosition(string wechatUserID, double longitude, double latitude);
        UserPosition GetUserPosition(string wehcatUserID);

        WechatUserProfile GetWechatUserProfile(string id);
        void EditWechatUserProfile(string id,Action<WechatUserProfile> action);

        PagedResult<VUser> GetViewUsers(int page=0,string name="",string tel="");
        PagedResult<VInoculationRecord> GetViewRecords(int page = 0,int rows=20);
    }
}
