using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    /// <summary>
    /// 问卷选项
    /// </summary>
    public class QuestionSelect
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 题目ID
        /// </summary>
        public int QuestionItemID { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public int Score { get; set; }

        public virtual QuestionItem QuestionItem { get; set; }
        public virtual ICollection<QuestionSelectUser> QuestionSelectUsers { get; set; }
    }
}
