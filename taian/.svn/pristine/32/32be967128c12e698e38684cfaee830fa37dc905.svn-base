using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using log4net.Core;

namespace MyFrameWork.Log
{
    public class LogHelper
    {
        private readonly log4net.ILog loginfo = null;

        public LogHelper(string name)
        {
            string path = Path.GetDirectoryName(System.Web.HttpContext.Current.Server.MapPath("~/log4net.config"));
            var logsetString = File.ReadAllText(Path.Combine(path, "log4net.config")).Replace("{name}", name);
            string logFile = Path.Combine(path, "log", name, name + ".log4net.config");
            if (!Directory.Exists(Path.Combine(path, "log", name)))
            {
                Directory.CreateDirectory(Path.Combine(path, "log", name));
            }
            if (!File.Exists(logFile))
            {
                File.WriteAllText(logFile, logsetString);
            }
            log4net.Config.XmlConfigurator.Configure(new FileInfo(logFile));
            loginfo = log4net.LogManager.GetLogger(name);
        }
        public void WriteError(string info)
        {
            if (loginfo.IsErrorEnabled)
                loginfo.Error(info);
        }
        public void WriteError(string info, Exception se)
        {
            if (loginfo.IsErrorEnabled)
                loginfo.Error(info, se);
        }
        public void WriteInfo(string info)
        {
            if (loginfo.IsInfoEnabled)
                loginfo.Info(info);
        }
    }
}
