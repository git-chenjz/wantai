using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    /// <summary>
    /// 问卷题目
    /// </summary>
   public  class QuestionItem
    {
       /// <summary>
       /// 主键
       /// </summary>
       public int ID { get; set; }
       /// <summary>
       /// 问卷ID
       /// </summary>
       public int QuestionID { get; set; }
       /// <summary>
       /// 题目排序
       /// </summary>
       public int Sort { get; set; }
       /// <summary>
       /// 题目
       /// </summary>
       public string Title { get; set; }
       /// <summary>
       /// 是否为单选
       /// </summary>
       public bool IsRadio { get; set; }

       public virtual Question Question { get; set; }
       public virtual ICollection<QuestionSelect> QuestionSelects { get; set; }
    }
}
