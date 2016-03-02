namespace WanTaiWeb.Controllers
{
    using Newtonsoft.Json;
    using System;
    using System.Web;
    using System.Web.Mvc;
    using WanTaiWeb.App_Code.UEditor;

    public class UEditorController : Controller
    {
        public ContentResult Handle()
        {
            IUEditorHandle handle = null;
            switch (Request["action"])
            {
                case "config":
                    handle = new ConfigHandler();
                    break;
                case "uploadimage":
                    handle = new UploadHandle(new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("imageAllowFiles"),
                        PathFormat = Config.GetString("imagePathFormat"),
                        SizeLimit = Config.GetInt("imageMaxSize"),
                        UploadFieldName = Config.GetString("imageFieldName")
                    });
                    break;
                case "uploadscrawl":
                    handle = new UploadHandle(new UploadConfig()
                    {
                        AllowExtensions = new string[] { ".png" },
                        PathFormat = Config.GetString("scrawlPathFormat"),
                        SizeLimit = Config.GetInt("scrawlMaxSize"),
                        UploadFieldName = Config.GetString("scrawlFieldName"),
                        Base64 = true,
                        Base64Filename = "scrawl.png"
                    });
                    break;
                case "uploadvideo":
                    handle = new UploadHandle(new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("videoAllowFiles"),
                        PathFormat = Config.GetString("videoPathFormat"),
                        SizeLimit = Config.GetInt("videoMaxSize"),
                        UploadFieldName = Config.GetString("videoFieldName")
                    });
                    break;
                case "uploadfile":
                    handle = new UploadHandle(new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("fileAllowFiles"),
                        PathFormat = Config.GetString("filePathFormat"),
                        SizeLimit = Config.GetInt("fileMaxSize"),
                        UploadFieldName = Config.GetString("fileFieldName")
                    });
                    break;
                default:
                    handle = new NotSupportedHandler();
                    break;
            }
            return base.Content(JsonConvert.SerializeObject(handle.Process()));
        }

        [HttpPost]
        public ContentResult Handle(string action)
        {
            IUEditorHandle handle = null;
            switch (Request["action"])
            {
                case "config":
                    handle = new ConfigHandler();
                    break;
                case "uploadimage":
                    handle = new UploadHandle(new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("imageAllowFiles"),
                        PathFormat = Config.GetString("imagePathFormat"),
                        SizeLimit = Config.GetInt("imageMaxSize"),
                        UploadFieldName = Config.GetString("imageFieldName")
                    });
                    break;
                case "uploadscrawl":
                    handle = new UploadHandle(new UploadConfig()
                    {
                        AllowExtensions = new string[] { ".png" },
                        PathFormat = Config.GetString("scrawlPathFormat"),
                        SizeLimit = Config.GetInt("scrawlMaxSize"),
                        UploadFieldName = Config.GetString("scrawlFieldName"),
                        Base64 = true,
                        Base64Filename = "scrawl.png"
                    });
                    break;
                case "uploadvideo":
                    handle = new UploadHandle(new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("videoAllowFiles"),
                        PathFormat = Config.GetString("videoPathFormat"),
                        SizeLimit = Config.GetInt("videoMaxSize"),
                        UploadFieldName = Config.GetString("videoFieldName")
                    });
                    break;
                case "uploadfile":
                    handle = new UploadHandle(new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("fileAllowFiles"),
                        PathFormat = Config.GetString("filePathFormat"),
                        SizeLimit = Config.GetInt("fileMaxSize"),
                        UploadFieldName = Config.GetString("fileFieldName")
                    });
                    break;
                default:
                    handle = new NotSupportedHandler();
                    break;
            }
            return base.Content(JsonConvert.SerializeObject(handle.Process()));
        }

        [HttpGet]
        public ActionResult Upload()
        {
            string str = base.Request.QueryString["url"];
            if (str == null)
            {
                str = "";
            }
            base.ViewData["url"] = str;
            return base.View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase filename)
        {
            return base.View();
        }
    }
}

