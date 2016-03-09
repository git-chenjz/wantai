using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    /// <summary>
    /// 接种配置
    /// </summary>
    public class InoculationConfig
    {
        /// <summary>
        /// 主键 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 疫苗类型
        /// </summary>
        public int VaccineTypeID { get; set; }
        /// <summary>
        /// 期数名称
        /// </summary>
        public string PhaseName { get; set; }
        /// <summary>
        /// 期数代码
        /// </summary>
        public int PhaseCode { get; set; }
        /// <summary>
        /// 下一期周期
        /// </summary>
        public int CycleDay { get; set; }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string Description { get; set; }

        public virtual VaccineType VaccineType { get; set; }
    }
}
