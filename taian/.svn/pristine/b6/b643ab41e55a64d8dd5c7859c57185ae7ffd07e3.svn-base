using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System;

namespace MyFrameWork.Common
{
    public static class JsonHelper
    {
        public static T ToObject<T>(this string sJasonData)
        {
            JsonSerializerSettings jsonSs = new JsonSerializerSettings();
            var timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            jsonSs.Converters.Add(timeConverter);
            jsonSs.Converters.Add(new DataTableConverter());
            return JsonConvert.DeserializeObject<T>(sJasonData, jsonSs);
        }

        public static object ToObject(this string sJasonData, Type type)
        {
            JsonSerializerSettings jsonSs = new JsonSerializerSettings();
            var timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            jsonSs.Converters.Add(timeConverter);
            jsonSs.Converters.Add(new DataTableConverter());
            return JsonConvert.DeserializeObject(sJasonData, type, jsonSs);
        }

        public static String ToJson<T>(this T obj)
        {
            JsonSerializerSettings jsonSs = new JsonSerializerSettings();
            var timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            jsonSs.Converters.Add(timeConverter);
            jsonSs.Converters.Add(new DataTableConverter());
            //jsonSs.Converters.Add(new JavaScriptDateTimeConverter());
            //jsonSs.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            //jsonSs.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            //jsonSs.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            string json = JsonConvert.SerializeObject(obj, Formatting.None, jsonSs);
            return json;
        }

        public static String ToJsonTime<T>(this T obj)
        {
            JsonSerializerSettings jsonSs = new JsonSerializerSettings();
            var timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            jsonSs.Converters.Add(timeConverter);
            jsonSs.Converters.Add(new DataTableConverter());
            string json = JsonConvert.SerializeObject(obj, Formatting.None, jsonSs);
            return json;
        }
        /// <summary>
        /// 解析JSON数组生成对象实体集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json数组字符串(eg.[{"ID":"112","Name":"石子儿"}])</param>
        /// <returns>对象实体集合</returns>
        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;
        }
    }
}
