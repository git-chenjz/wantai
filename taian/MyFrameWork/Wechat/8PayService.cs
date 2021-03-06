﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Wechat
{
    public class PayService
    {
        const string SENDREDPACK = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack";

        #region 红包支付
        /// <summary>
        /// 发送红包
        /// </summary>
        /// <param name="send"></param>
        /// <returns></returns>
        public static WX_RedPackResult SendRedPack(WX_RedPackSend send)
        {
            var result = WXHelper.GetWebContentByPostXML<WX_RedPackResult>(SENDREDPACK, send, a =>
            {
                var store = new X509Store("My", StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                var cert = store.Certificates.Find(X509FindType.FindBySubjectName, "厦门万泰沧海生物技术有限公司", false)[0];

                a.ClientCertificates.Add(cert);
                a.KeepAlive = true;
            });

            return result;
        }

        #endregion
    }
}
