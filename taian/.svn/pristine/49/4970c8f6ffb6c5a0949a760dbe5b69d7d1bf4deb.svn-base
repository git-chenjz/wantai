using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;

namespace MyFrameWork.Common.Email
{
    public class SendMail
    {
        private MailAddress MailAddress_from;
        private MailAddress MailAddress_to;
        private MailMessage MailMessage_Mai;
        private System.Net.Mail.SmtpClient SmtpClient;

        public SendMail()
        {
            MessageEmailConfig config = EmailCore.GetConfig();
            this.setSmtpClient(config.SmtpServer, Convert.ToInt32(config.SmtpPort));
            this.setAddressform(config.SendAddress, config.Password, config.DisplayName);
        }

        public SendMail(string serverHost, int Port, string mailFrom, string Password, string DisPlayText)
        {
            this.setSmtpClient(serverHost, Port);
            this.setAddressform(mailFrom, Password, DisPlayText);
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //Log.Debug(e.Error.Message + e.Error.InnerException.Message);
            }
        }

        public void SendEmail(string title, string[] mailto, string content, bool async = true)
        {
            this.MailMessage_Mai = new MailMessage();
            foreach (string str in mailto)
            {
                this.MailAddress_to = new MailAddress(str);
                this.MailMessage_Mai.To.Add(this.MailAddress_to);
            }
            this.MailMessage_Mai.From = this.MailAddress_from;
            this.MailMessage_Mai.Subject = title;
            this.MailMessage_Mai.IsBodyHtml = true;
            this.MailMessage_Mai.SubjectEncoding = Encoding.UTF8;
            this.MailMessage_Mai.Body = content;
            this.MailMessage_Mai.BodyEncoding = Encoding.UTF8;
            this.MailMessage_Mai.Priority = MailPriority.Normal;
            this.MailMessage_Mai.Attachments.Clear();
            if (async)
            {
                this.SmtpClient.SendCompleted += new SendCompletedEventHandler(SendMail.SendCompletedCallback);
                this.SmtpClient.SendAsync(this.MailMessage_Mai, "");
            }
            else
            {
                this.SmtpClient.Send(this.MailMessage_Mai);
            }
        }

        private void setAddressform(string MailAddress, string MailPwd, string DisplayName)
        {
            NetworkCredential credential = new NetworkCredential(MailAddress, MailPwd);
            this.MailAddress_from = new MailAddress(MailAddress, DisplayName);
            this.SmtpClient.Credentials = credential;
        }

        private void setSmtpClient(string ServerHost, int Port)
        {
            this.SmtpClient = new System.Net.Mail.SmtpClient();
            this.SmtpClient.Host = ServerHost;
            this.SmtpClient.Port = Port;
        }
    }
}
