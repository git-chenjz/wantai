using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyFrameWork.Common
{
    public class ExecuteStartupTasks
    {
        public ExecuteStartupTasks(string assembly)
        {
            List<IStartupTask> startupTasks = new List<IStartupTask>();
            string[] assemblies = assembly.Split(',');

            foreach (String item in assemblies)
            {
                try
                {
                    var asm = Assembly.Load(item);

                    // get all types from the assembly that inherit IStartupTask  
                    var query = from t in asm.GetTypes()
                                where t.IsClass && t.GetInterface(typeof(IStartupTask).FullName) != null
                                select t;

                    // add types to list of startup tasks  
                    foreach (Type type in query)
                    {
                        startupTasks.Add((IStartupTask)Activator.CreateInstance(type));
                    }
                }
                catch (Exception ex)
                {
                    //Exceptions.LogException(ex);
                }
            }

            // execute each startup task  
            foreach (IStartupTask task in startupTasks)
            {
                task.Execute();
            }
        }
    }
}
