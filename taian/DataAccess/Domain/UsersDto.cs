using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyFrameWork.Common;
using MyFrameWork.Extensions;

namespace DataAccess.Domain
{
    public class UsersDto
    {
        public int ID { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        public string Openid { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegTime { get; set; }

        /// <summary>
        /// 是否注册用户
        /// </summary>
        public bool IsReg { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 类型医疗机构1、学校2
        /// </summary>
        public int JobType { get; set; }

        /// <summary>
        /// 单位 or 学院
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 部门 or 院系
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 学校里用的身份，老师1，学生2
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        public string ClassID { get; set; }
    }
}
