using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    /// <summary>
    /// 会议信息
    /// </summary>
    public class Meeting
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 会议时间
        /// </summary>
        public DateTime MeetingTime { get; set; }
        /// <summary>
        /// 主办方
        /// </summary>
        public string Sponsor { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public MeetingStatus Status { get; set; }

        public virtual ICollection<MeetingUser> MeetingUsers { get; set; }
    }

    public enum MeetingStatus
    {
        启用 = 0,
        禁用 = 1,
        过期 = 2
    }
}
