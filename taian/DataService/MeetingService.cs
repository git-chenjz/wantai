﻿using DataAccess.Domain;
using DataAccess.Repositories;
using MyFrameWork.Common;
using MyFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class MeetingService : BaseService, IMeetingService
    {
        #region 字段
        private IMeetingRepository _meetingRepository;
        private IMeetingUserRepository _meetingUserRepository;
        #endregion

        #region 构造
        public MeetingService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IMeetingRepository meetingRepository,
            IMeetingUserRepository meetingUserRepository
            )
            : base(mySqlUnitOfWork)
        {
            _meetingRepository = meetingRepository;
            _meetingUserRepository = meetingUserRepository;
        }
        #endregion

        #region 会议
        public PagedResult<Meeting> GetMeetings(int page = 0, MeetingStatus? status = null)
        {
            return _meetingRepository.GetPaged(a => (status == null || a.Status == status), a => a.OrderByDescending(b => b.MeetingTime), page,100);
        }
        public Meeting GetMeeting(int id)
        {
            return _meetingRepository.Find(id);
        }
        public void EditMeeting(Meeting meeting)
        {
            if (meeting.ID == 0)
            {
                meeting.CreateTime = DateTime.Now;
                _meetingRepository.Create(meeting);
            }
            else
            {
                var temp = _meetingRepository.Find(meeting.ID);
                if (temp != null)
                {
                    temp.Des = meeting.Des;
                    temp.ImgUrl = meeting.ImgUrl;
                    temp.MeetingTime = meeting.MeetingTime;
                    temp.Sponsor = meeting.Sponsor;
                    temp.Status = meeting.Status;
                    temp.Title = meeting.Title;
                }
            }
            _meetingRepository.Save();
        }
        public void DeleteMeeting(int id)
        {
            _meetingRepository.Delete(a => a.ID == id);
            _meetingRepository.Save();
        }

        public IEnumerable<MeetingUser> GetMeetingUsers(int meetingID)
        {
            return _meetingUserRepository.Get(a => a.MeetingID == meetingID);
        }
        public IEnumerable<Meeting> GetMeetingsByWechatUserID(string wechatUserID, bool checkSignUp = false)
        {
            var meetingIDs = _meetingUserRepository.Get(a => a.WechatUserID == wechatUserID && (checkSignUp == false || a.SignTime != null)).Select(a => a.MeetingID);

            return _meetingRepository.Get(a => meetingIDs.Contains(a.ID)).OrderByDescending(a => a.MeetingTime);
        }
        public void SignUpMeeting(int meetingID, string wechatUserID, object data)
        {
            var meeting = _meetingRepository.Find(meetingID);
            if (meeting == null || meeting.MeetingTime < DateTime.Now || meeting.Status != MeetingStatus.启用)
                return;

            var mu = _meetingUserRepository.Find(a => a.MeetingID == meetingID && a.WechatUserID == wechatUserID);
            if (mu != null)
                return;

            mu = new MeetingUser
            {
                DueTime = DateTime.Now,
                MeetingID = meetingID,
                WechatUserID = wechatUserID,
                IdentityData = JsonHelper.ToJson(data)
            };

            _meetingUserRepository.Create(mu);
            _meetingUserRepository.Save();
        }
        public void SignInMeeting(int meetingID, string wechatUserID)
        {
            var mu = _meetingUserRepository.Find(a => a.MeetingID == meetingID && a.WechatUserID == wechatUserID);

            if (mu != null && mu.SignTime != null)
            {
                mu.SignTime = DateTime.Now;
                _meetingUserRepository.Save();
            }
        }
        #endregion

        #region 会议
        //public IEnumerable<Meeting> GetMeetings()
        //{
        //    return _meetingRepository.Get().OrderByDescending(a => a.MeetingTime);
        //}
        //public Meeting GetMeeting(int id, bool include = false)
        //{
        //    if (include)
        //        return _meetingRepository.Get(a => a.ID == id, "MeetingUsers").FirstOrDefault();

        //    return _meetingRepository.Get(a => a.ID == id).FirstOrDefault();
        //}
        //public PagedResult<Meeting> GetPagedMeeting(int page = 1, int? status = null)
        //{
        //    //清理过期
        //    var time = DateTime.Now.AddDays(-1).Date;
        //    var meets = _meetingRepository.Get(a => a.Status != 2 && a.MeetingTime < time);
        //    foreach (var x in meets)
        //    {
        //        x.Status = 2;
        //    }
        //    if (meets.Any())
        //    {
        //        _meetingRepository.Save();
        //    }

        //    return _meetingRepository.GetPaged(a => status == null || a.Status == status, a => a.OrderByDescending(b => b.MeetingTime), page);
        //}
        //public void EditMeeting(Meeting meeting)
        //{
        //    if (meeting.ID == 0)
        //    {
        //        meeting.CreateTime = DateTime.Now;
        //        _meetingRepository.Create(meeting);
        //    }
        //    else
        //    {
        //        var temp = _meetingRepository.Find(meeting.ID);
        //        if (temp != null)
        //        {
        //            temp.Des = meeting.Des;
        //            temp.ImgUrl = meeting.ImgUrl;
        //            temp.MeetingTime = meeting.MeetingTime;
        //            temp.Sponsor = meeting.Sponsor;
        //            temp.Status = meeting.Status;
        //            temp.Title = meeting.Title;
        //        }
        //    }
        //    _meetingRepository.Save();
        //}
        //public void DeleteMeeting(int id)
        //{
        //    var meeting = _meetingRepository.Find(id);
        //    if (meeting != null)
        //    {
        //        _meetingRepository.Delete(meeting);
        //        _meetingRepository.Save();
        //    }
        //}
        ///// <summary>
        ///// 获取用户会议列表
        ///// </summary>
        ///// <param name="uid">用户id</param>
        ///// <param name="type">【0：已报名会议，1：已参加会议】</param>
        ///// <returns></returns>
        //public PagedResult<MeetingUser> GetPagedByUid(int uid, int type)
        //{
        //    Expression<Func<MeetingUser, bool>> filter = c => true;
        //    if (uid > 0)
        //        filter = filter.And(c => c.UserID == uid);
        //    if (type == 0)
        //        filter = filter.And(c => c.DueTime != null);
        //    if (type == 1)
        //        filter = filter.And(c => c.SignTime != null);

        //    return _meetingUserRepository.GetPaged(filter);
        //}

        //public MeetingUser GetMeetingUserByMetId(int meetingId)
        //{
        //    var meetingUser = _meetingUserRepository.Find(c => c.MeetingID == meetingId);
        //    if (meetingUser == null)
        //        meetingUser = new MeetingUser();
        //    return meetingUser;
        //}

        //public bool IsAttendMeeting(int meetingId, int uid)
        //{
        //    return _meetingUserRepository.Contains(c => c.MeetingID == meetingId && c.UserID == uid);
        //}
        //public bool IsSignInMeeting(int meetingId, int uid)
        //{
        //    return _meetingUserRepository.Contains(c => c.MeetingID == meetingId && c.UserID == uid && c.SignTime != null);
        //}
        //public int MeetingSignUp(MeetingUser meetingUser)
        //{
        //    _meetingUserRepository.Create(meetingUser);
        //    return _meetingUserRepository.Save();
        //}

        //public int? MeetingSignIn(int id, int userID)
        //{
        //    var mu = _meetingUserRepository.Find(a => a.UserID == userID && a.MeetingID == id);
        //    if (mu != null && mu.SignTime == null)
        //    {
        //        mu.SignTime = DateTime.Now;
        //        _meetingUserRepository.Save();
        //    }

        //    if (mu == null)
        //        return null;

        //    return mu.MeetingID;
        //}
        #endregion
    }
}
