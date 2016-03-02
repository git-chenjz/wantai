using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyFrameWork.Mvc
{
    public class JsonEnumResult : JsonResult
    {
        public JsonEnumResult() : this(null, null, null) { }
        public JsonEnumResult(Object data) : this(data, null, null) { }
        public JsonEnumResult(Object data, String contentType) : this(data, contentType, null) { }

        public JsonEnumResult(Object data, String contentType, Encoding encoding)
        {
            if (SerializerSettings == null)
                SerializerSettings = new JsonSerializerSettings();
            SerializerSettings.Converters.Add(new JavaScriptDateTimeConverter());
            SerializerSettings.Converters.Add(new StringEnumConverter());
            Formatting = Formatting.Indented;
            Data = data;
            ContentType = contentType;
            ContentEncoding = encoding;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            response.ContentEncoding = ContentEncoding != null ? ContentEncoding : Encoding.UTF8;

            if (Data != null)
            {
                JsonTextWriter writer = new JsonTextWriter(response.Output) { Formatting = Formatting };
                JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);
                serializer.Serialize(writer, Data);
                writer.Flush();
            }
        }

        public JsonSerializerSettings SerializerSettings { get; set; }
        public Formatting Formatting { get; set; }
    }
}
