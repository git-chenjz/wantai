using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    /// <summary>
    /// 用户答卷
    /// </summary>
    public class QuestionUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string WechatUserID { get; set; }
        /// <summary>
        /// 问卷ID
        /// </summary>
        public int QuestionID { get; set; }
        /// <summary>
        /// 答卷时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public int Score { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }

        public virtual WechatUser WechatUser { get; set; }
        public virtual Question Question { get; set; }
    }
}
