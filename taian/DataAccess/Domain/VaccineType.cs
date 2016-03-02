using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    /// <summary>
    /// 疫苗类型
    /// </summary>
    public class VaccineType
    {
        /// <summary>
        /// 主键 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgUrl{get;set;}
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public virtual ICollection<LBSVaccineType> LBSVaccineTypes { get; set; }
    }
}
