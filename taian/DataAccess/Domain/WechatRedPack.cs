using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    /// <summary>
    /// 微信红包
    /// </summary>
    public class WechatRedPack
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 微信单号
        /// </summary>
        public string ListID { get; set; }
        /// <summary>
        /// 用户OPENID
        /// </summary>
        public string OpenID { get; set; }
        /// <summary>
        /// 金额  分
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
