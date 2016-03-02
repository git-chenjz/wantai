using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyFrameWork.Common;

namespace DataAccess.Domain
{
    /// <summary>
    /// 功能表
    /// </summary>
    [Table("eb_features")]
    public class Features
    {
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 父id
        /// </summary>
        public int Pid { get; set; }

        /// <summary>
        /// 上级集合
        /// </summary>
        [Column("depth_pid")]
        public string DepthPid { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(25)]
        public string Name { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 类型：栏目0、功能1、外链2
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        public IEnumerable<Features> Childrens { get; set; }

        public string GetTypeName()
        {
            string name = "栏目";
            if (Type == 1) name = "功能";
            else if (Type == 2) name = "外链";
            return name;
        }
    }
}
