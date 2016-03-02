using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    public class MyProblem
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
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string WechatUserID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否已回复 0:已回复 1:未回复
        /// </summary>
        public int IsReport { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string Reports { get; set; }
        /// <summary>
        /// 是否已审核 0:通过  1:未通过   2: 未审核
        /// </summary>
        public int IsAudit { get; set; }
    }
}
