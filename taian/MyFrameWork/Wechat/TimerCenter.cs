using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyFrameWork.Wechat
{
    /// <summary>
    /// 定时中心服务
    /// </summary>
    public class TimerCenter
    {
        private List<Timer> _timers { get; set; }

        public TimerCenter()
        {
            _timers = new List<Timer>();
        }

        /// <summary>
        /// 增加定时服务
        /// </summary>
        /// <param name="handler">委托事件</param>
        /// <param name="time">时间间隔</param>
        /// <param name="enabled">是否启动</param>
        public void AddService(ElapsedEventHandler handler, int time, bool enabled = true)
        {

            var timer = new Timer();
            timer.Elapsed += handler;
            timer.Interval = time;
            timer.Enabled = enabled;

            _timers.Add(timer);
        }
        /// <summary>
        /// 停止所有定时服务
        /// </summary>
        public void StopAllServices()
        {
            foreach (var x in _timers)
            {
                x.Stop();
            }
        }
    }
}
