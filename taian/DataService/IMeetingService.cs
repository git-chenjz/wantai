using DataAccess.Domain;
using MyFrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IMeetingService
    {
        #region 会议
        PagedResult<Meeting> GetMeetings(int page = 0, MeetingStatus? status = null);
        Meeting GetMeeting(int id);
        void EditMeeting(Meeting meeting);
        void DeleteMeeting(int id);

        IEnumerable<Meeting> GetMeetingsByWechatUserID(string wechatUserID);
        IEnumerable<MeetingUser> GetMeetingUsers( int meetingID);
        void SignUpMeeting(int meetingID, string wechatUserID,object data);
        void SignInMeeting(int meetingID, string wechatUserID);
        #endregion

        #region 会议
        //IEnumerable<Meeting> GetMeetings();
        //PagedResult<Meeting> GetPagedMeeting(int page = 1, int? status = null);
        //Meeting GetMeeting(int id,bool include=false);
        //void EditMeeting(Meeting meeting);
        //void DeleteMeeting(int id);
        //PagedResult<MeetingUser> GetPagedByUid(int uid, int type);
        //MeetingUser GetMeetingUserByMetId(int meetingId);
        //bool IsAttendMeeting(int meetingId, int uid);
        //bool IsSignInMeeting(int meetingId, int uid);
        //int MeetingSignUp(MeetingUser meetingUser);
        //int? MeetingSignIn(int id, int userID);
        #endregion
    }
}
