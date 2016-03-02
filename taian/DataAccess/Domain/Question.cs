using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    /// <summary>
    /// 问卷
    /// </summary>
    public class Question
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgPath { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public QuestionStatus Status { get; set; }

        public virtual ICollection<QuestionItem> QuestionItems { get; set; }
        public virtual ICollection<QuestionUser> QuestionUsers { get; set; }
    }

    public enum QuestionStatus
    {
        启用 = 0,
        禁用 = 1,
        结束 = 2
    }
}
