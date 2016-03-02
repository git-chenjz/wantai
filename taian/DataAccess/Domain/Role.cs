using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyFrameWork.Common;

namespace DataAccess.Domain
{
    [Table("eb_role")]
    public class Role
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        [Column("role_name")]
        public string RoleName { get; set; }

        /// <summary>
        /// 操作权限
        /// </summary>
        public string Actions { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public List<Permission> Permission
        {
            get
            {
                if (Actions.IsNullOrEmpty()) return new List<Permission>();
                return Actions.ToObject<List<Permission>>();
            }
            set
            {
                if (!value.IsNullOrEmpty())
                    Actions = value.ToJson();
            }
        }
    }

    public class Permission
    {
        public Permission() { Fields = new List<string>(); }

        public int ID { get; set; }
        public string Url { get; set; }
        /// <summary>
        /// 类型：栏目0、功能1、外链2、操作3
        /// </summary>
        public int Type { get; set; }

        public List<string> Fields { get; set; }
    }
}
