using DataAccess.Domain;
using DataService;
using MyFrameWork.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WanTaiWeb.Infrastructure;

namespace WanTaiWeb.Areas.Web.Models
{
    public class MeetingModel
    {
        public int Tag { get; set; }
        public IEnumerable<Meeting> Meetings { get; set; }
        public int ID { get; set; }
        public Meeting Meeting { get; set; }


        public MeetingModel()
        {
            ID = 0;
            Tag = 0;
            Meetings = new List<Meeting> { };
        }

        public void LoadMeetings()
        {
            var msv= ServiceLocator.Instance.Resolve<IMeetingService>();

            if (Tag == 0)
            {
                Meetings = msv.GetMeetingsByWechatUserID(UserCache.WechatUser.ID);
            }
            else
            {
                Meetings = msv.GetMeetingsByWechatUserID(UserCache.WechatUser.ID,true);
            }
        }
        public void LoadMeeting()
        {
            var msv = ServiceLocator.Instance.Resolve<IMeetingService>();

            Meeting = msv.GetMeeting(ID);
        }
    }
}