﻿namespace WanTaiWeb.App_Code.UEditor
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public static class PathFormatter
    {
        public static string Format(string originFileName, string pathFormat)
        {
            if (string.IsNullOrWhiteSpace(pathFormat))
            {
                pathFormat = "{filename}{rand:6}";
            }
            originFileName = new Regex(@"[\\\/\:\*\?\042\<\>\|]").Replace(originFileName, "");
            string extension = Path.GetExtension(originFileName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originFileName);
            pathFormat = pathFormat.Replace("{filename}", fileNameWithoutExtension);
            pathFormat = new Regex(@"\{rand(\:?)(\d+)\}", RegexOptions.Compiled).Replace(pathFormat, delegate (Match match) {
                int num = 6;
                if (match.Groups.Count > 2)
                {
                    num = Convert.ToInt32(match.Groups[2].Value);
                }
                Random random = new Random();
                return random.Next((int) Math.Pow(10.0, (double) num), (int) Math.Pow(10.0, (double) (num + 1))).ToString();
            });
            pathFormat = pathFormat.Replace("{time}", DateTime.Now.Ticks.ToString());
            pathFormat = pathFormat.Replace("{yyyy}", DateTime.Now.Year.ToString());
            pathFormat = pathFormat.Replace("{yy}", (DateTime.Now.Year % 100).ToString("D2"));
            pathFormat = pathFormat.Replace("{mm}", DateTime.Now.Month.ToString("D2"));
            pathFormat = pathFormat.Replace("{dd}", DateTime.Now.Day.ToString("D2"));
            pathFormat = pathFormat.Replace("{hh}", DateTime.Now.Hour.ToString("D2"));
            pathFormat = pathFormat.Replace("{ii}", DateTime.Now.Minute.ToString("D2"));
            pathFormat = pathFormat.Replace("{ss}", DateTime.Now.Second.ToString("D2"));
            return (pathFormat + extension);
        }
    }
}

