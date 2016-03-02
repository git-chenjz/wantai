using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Domain
{
    [Table("CycleTable")]
    public class CycleTable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }
        public int ViewNum { get; set; }
        public string Sponsor { get; set; }
        /// <summary>
        /// 是否显示【1：显示，0：不显示】
        /// </summary>
        public int IsShow { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
