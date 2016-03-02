using MongoDB.Attributes;
using MyFrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Log
{
    public class OperateLogInfo
    {
        public OperateLogInfo()
        {
            Id = CreatePrimaryKey.Current.ID;
        }
        [MongoId]
        public long Id { get; set; }
        public string MethodName { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
