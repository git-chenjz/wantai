using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Common
{
    public class RetrunJsonMsg
    {
        public bool success { get; private set; }
        public string msg { get; private set; }
        public int total { get; private set; }
        public object rows { get; private set; }

        public RetrunJsonMsg(bool success, string msg)
        {
            this.success = success;
            this.msg = msg;
        }
        public RetrunJsonMsg(int total, object rows)
        {
            this.total = total;
            this.rows = rows;
        }
        public RetrunJsonMsg(bool success, string msg, int total, object rows)
        {
            this.success = success;
            this.msg = msg;
            this.total = total;
            this.rows = rows;
        }
        public RetrunJsonMsg(bool success, string msg, object rows)
        {
            this.success = success;
            this.msg = msg;
            this.rows = rows;
        }
    }
    public class RetrunJsonMsg<T>
    {
        public bool success { get; private set; }
        public string msg { get; private set; }
        public int total { get; private set; }
        public IEnumerable<T> rows { get; private set; }

        public RetrunJsonMsg(bool success, string msg)
        {
            this.success = success;
            this.msg = msg;
        }
        public RetrunJsonMsg(int total, IEnumerable<T> rows)
        {
            this.total = total;
            this.rows = rows;
        }
        public RetrunJsonMsg(bool success, string msg, int total, IEnumerable<T> rows)
        {
            this.success = success;
            this.msg = msg;
            this.total = total;
            this.rows = rows;
        }
        public RetrunJsonMsg(bool success, string msg, IEnumerable<T> rows)
        {
            this.success = success;
            this.msg = msg;
            this.rows = rows;
        }
    }
}
