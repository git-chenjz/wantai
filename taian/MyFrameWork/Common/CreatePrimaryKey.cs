using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Common
{
    /// <summary>
    /// 唯一ID生成类
    /// </summary>
    public class CreatePrimaryKey
    {
        private static object syncRoot = new object();
        private static CreatePrimaryKey instance;
        /// <summary>
        /// 唯一ID生成类
        /// </summary>
        public static CreatePrimaryKey Current
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CreatePrimaryKey();
                        }
                    }
                }
                return instance;
            }
        }
        private DateTime StartTime = new DateTime(2000, 1, 1);
        private int subValue = 1;
        private long lastTimeMark = 1;
        public long ID
        {
            get
            {
                long timeMark = (long)(DateTime.Now - StartTime).TotalMilliseconds;
                if (lastTimeMark == timeMark)
                {
                    subValue++;
                }
                else
                {
                    subValue = 1;
                    lastTimeMark = timeMark;
                }
                long guid = timeMark + subValue;
                System.Threading.Thread.Sleep(1);
                return guid;
            }
        }
    }
}
