using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    /// <summary>
    /// 创新疫苗文章
    /// </summary>
    public class InnovateFeed
    {
        public int ID { get; set; }
        public InnovateFeedType Type { get; set; }
        public string Title { get; set; }
        public string Des { get; set; }
        public string ImgPath { get; set; }
        public int ClickNum { get; set; }
        public DateTime CreateTime { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public ActiveStatus Status { get; set; }
    }

    /// <summary>
    /// 创新疫苗文章类型
    /// </summary>
    public enum InnovateFeedType
    {
        戊肝知识 = 0,
        戊肝疫苗知识 = 1,
        宫颈癌知识 = 2,
        宫颈癌疫苗资讯 = 3
    }

    public enum ActiveStatus
    {
        启用 = 0,
        禁用 = 1
    }
}
