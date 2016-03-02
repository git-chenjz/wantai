namespace WanTaiWeb.App_Code.UEditor
{
    using System;

    public class NotSupportedHandler : IUEditorHandle
    {
        public object Process()
        {
            return new { state = "action 参数为空或者 action 不被支持。" };
        }
    }
}

