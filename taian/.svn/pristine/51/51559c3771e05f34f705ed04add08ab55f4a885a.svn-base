namespace WanTaiWeb.App_Code.UEditor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Web;

    public class UploadHandle : IUEditorHandle
    {
        public UploadHandle(WanTaiWeb.App_Code.UEditor.UploadConfig config)
        {
            this.UploadConfig = config;
            UploadResult result = new UploadResult {
                State = UploadState.Unknown
            };
            this.Result = result;
        }

        private bool CheckFileSize(int size)
        {
            return (size < this.UploadConfig.SizeLimit);
        }

        private bool CheckFileType(string filename)
        {
            string str = Path.GetExtension(filename).ToLower();
            return (from x in this.UploadConfig.AllowExtensions select x.ToLower()).Contains<string>(str);
        }

        private string GetStateMessage(UploadState state)
        {
            switch (state)
            {
                case UploadState.NetworkError:
                    return "网络错误";

                case UploadState.FileAccessError:
                    return "文件访问出错，请检查写入权限";

                case UploadState.TypeNotAllow:
                    return "不允许的文件格式";

                case UploadState.SizeLimitExceed:
                    return "文件大小超出服务器限制";

                case UploadState.Success:
                    return "SUCCESS";
            }
            return "未知错误";
        }

        public object Process()
        {
            byte[] buffer = null;
            string filename = null;
            if (this.UploadConfig.Base64)
            {
                filename = this.UploadConfig.Base64Filename;
                buffer = Convert.FromBase64String(HttpContext.Current.Request[this.UploadConfig.UploadFieldName]);
            }
            else
            {
                HttpPostedFile file = HttpContext.Current.Request.Files[this.UploadConfig.UploadFieldName];
                filename = file.FileName;
                if (!this.CheckFileType(filename))
                {
                    this.Result.State = UploadState.TypeNotAllow;
                    return this.WriteResult();
                }
                if (!this.CheckFileSize(file.ContentLength))
                {
                    this.Result.State = UploadState.SizeLimitExceed;
                    return this.WriteResult();
                }
                buffer = new byte[file.ContentLength];
                try
                {
                    file.InputStream.Read(buffer, 0, file.ContentLength);
                }
                catch (Exception)
                {
                    this.Result.State = UploadState.NetworkError;
                    this.WriteResult();
                }
            }
            this.Result.OriginFileName = filename;
            string path = PathFormatter.Format(filename, this.UploadConfig.PathFormat);
            string str3 = HttpContext.Current.Server.MapPath(path);
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(str3)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(str3));
                }
                File.WriteAllBytes(str3, buffer);
                this.Result.Url = path;
                this.Result.State = UploadState.Success;
            }
            catch (Exception exception)
            {
                this.Result.State = UploadState.FileAccessError;
                this.Result.ErrorMessage = exception.Message;
            }
            return this.WriteResult();
        }

        private object WriteResult()
        {
            return new { state = this.GetStateMessage(this.Result.State), url = this.Result.Url, title = this.Result.OriginFileName, original = this.Result.OriginFileName, error = this.Result.ErrorMessage };
        }

        private UploadResult Result { get; set; }

        private WanTaiWeb.App_Code.UEditor.UploadConfig UploadConfig { get; set; }
    }
}

