using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    /// <summary>
    /// 未发送模板的记录
    /// </summary>
    public class VInoculationRecord
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string WechatUserID { get; set; }
        /// <summary>
        /// 疫苗类型
        /// </summary>
        public int? InoculationConfigID { get; set; }
        /// <summary>
        /// 期数名称
        /// </summary>
        public string PhaseName { get; set; }
        /// <summary>
        /// 期数代码
        /// </summary>
        public int? PhaseCode { get; set; }
        /// <summary>
        /// 下一期周期
        /// </summary>
        public int? CycleDay { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string InoculationDescription { get; set; }
        /// <summary>
        /// 我的备注
        /// </summary>
        public string MyDescription { get; set; }
        /// <summary>
        /// 接种时间
        /// </summary>
        public DateTime InoculabilityTime { get; set; }
        /// <summary>
        /// 实际接种时间
        /// </summary>
        public DateTime? ActualInoculabilityTime { get; set; }
        /// <summary>
        /// 接种状态
        /// </summary>
        public InoculationStatus Status { get; set; }
        public string OpenID { get; set; }
        public string VName { get; set; }
    }
}
