using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyFrameWork.Common;

namespace DataAccess.Domain
{
    [Table("eb_admin")]
    public class AdminInfo
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(50)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        [Column("role_id")]
        public int? RoleID { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int Login { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        [Column("reg_time")]
        public DateTime RegTime { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        [Column("login_time")]
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("update_time")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 最后登录ip
        /// </summary>
        [Column("login_ip")]
        public string LoginIP { get; set; }

        /// <summary>
        /// 状态:0开，1关
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
