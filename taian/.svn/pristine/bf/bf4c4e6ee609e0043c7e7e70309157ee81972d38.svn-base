using DataAccess.Domain;
using DataService;
using MyFrameWork.Common;
using MyFrameWork.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WanTaiWeb.Areas.Admin.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Tel { get; set; }
        public int Page { get; set; }
        public PagedResult<VUser> Users { get; set; }

        public UserModel()
        {
            Page = 1;
            Name = "";
            Tel = "";
        }

        public void GetUsers()
        {
            Name = Name == null ? "" : Name.Trim();
            Tel = Tel == null ? "" : Tel.Trim();
            var wsv = ServiceLocator.Instance.Resolve<IWechatService>();
            Users = wsv.GetViewUsers(Page,Name,Tel);
        }
    }
}