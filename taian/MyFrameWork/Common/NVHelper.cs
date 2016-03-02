using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.IO;
using NVelocity;
using NVelocity.App;
using NVelocity.Context;
using Commons.Collections;
using NVelocity.Runtime;

namespace MyFrameWork.Common
{
    public class NVHelper
    {
        public static string Get(string builder, Dictionary<string, object> data)
        {
            VelocityEngine vltEngine = new VelocityEngine();
            ExtendedProperties props = new ExtendedProperties();
            props.AddProperty(RuntimeConstants.INPUT_ENCODING, "UTF-8");
            props.AddProperty(RuntimeConstants.OUTPUT_ENCODING, "UTF-8");
            vltEngine.Init(props);
            StringWriter vltWriter = new StringWriter();
            VelocityContext vltContext = new VelocityContext();
            foreach (var item in data) vltContext.Put(item.Key, item.Value);
            vltContext.Put("system", new { user = HttpContext.Current.User.Identity.Name, now = DateTime.Now });
            vltEngine.Evaluate(vltContext, vltWriter, null, builder);
            return vltWriter.GetStringBuilder().ToString();
        }
    }
}
