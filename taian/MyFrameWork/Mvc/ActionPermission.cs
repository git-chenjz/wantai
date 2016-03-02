using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Mvc
{
    public class ActionPermission
    {
        public string ActionUrl { get; set; }
        public string AreasName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
        public bool IsReuse { get; set; }
    }
}
