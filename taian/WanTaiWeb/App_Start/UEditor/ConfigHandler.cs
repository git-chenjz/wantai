namespace WanTaiWeb.App_Code.UEditor
{
    using System;

    public class ConfigHandler : IUEditorHandle
    {
        public object Process()
        {
            return Config.Items;
        }
    }
}

