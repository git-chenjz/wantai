using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    /// <summary>
    /// 与会信息
    /// </summary>
    public class MeetingUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string WechatUserID { get; set; }
        /// <summary>
        /// 会议ID
        /// </summary>
        public int MeetingID { get; set; }
        /// <summary>
        /// 身份Json数据
        /// </summary>
        public string IdentityData { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? DueTime { get; set; }
        /// <summary>
        /// 签到时间
        /// </summary>
        public DateTime? SignTime { get; set; }

        public virtual WechatUser WechatUser { get; set; }
        public virtual Meeting Meeting { get; set; }
    }
}
