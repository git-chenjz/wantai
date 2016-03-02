using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Mvc
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Authorize : Attribute
    {
        public Authorize() { }
        public AuthorizeEnum AuthorizeEnum { get; set; }
        public Authorize(AuthorizeEnum authorizeEnum) { AuthorizeEnum = authorizeEnum; }
    }
}
