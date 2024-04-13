using System;
using System.Net;
using 共通Data;


namespace Common
{
    public static class Mail
    {
        public static void SendMailAndLog(string subject, Exception ex)
        {
            ログ.ログ書き出し(ex);

            SendMail(subject, ex.Message + "\r\n" + ex.StackTrace);
        }

        public static void SendMailAndLogErr(string subject, Exception ex)
        {
            SendMailAndLog("エラー" + subject, ex);
        }

        public static void SendMail(string subject, string body)
        {
            string id = "1111@111.com";
            string pass = "1111";
            string fromEmail = "1111@111.com";
            string toEmail = "1111@111.com";

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.111.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(id, pass);
            smtp.EnableSsl = true;

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(fromEmail, toEmail, "AutoFX " + subject, body);
            smtp.Send(msg);
        }

    }
}
