using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFrameWork.Common;
using MyFrameWork.Extensions;

namespace DataAccess.Domain
{
    public class AdminDto
    {
        public int ID { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
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
        public DateTime RegTimeDto { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 最后登录ip
        /// </summary>
        public string LoginIP { get; set; }

        /// <summary>
        /// 状态:0开，1关
        /// </summary>
        public int Status { get; set; }
        
        public string StatusName { get { return Status == 0 ? "启用" : "关闭"; } }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
