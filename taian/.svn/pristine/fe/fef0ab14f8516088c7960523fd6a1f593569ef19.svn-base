using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyFrameWork.Common;

namespace DataAccess.Domain
{
    [Table("eb_purview_field")]
    public class PurviewField
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 功能id或操作id
        /// </summary>
        [Column("obj_id")]
        public int ObjID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 唯一编号:用于写到字典里的KEY
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 类型：0功能、1操作
        /// </summary>
        public int Type { get; set; }
    }
}
