using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace TP_DSYNC.Models.Help
{
    public class MailSender
    {
        //SMTP MAIL
        public bool Mail_Send(string MailFrom, string[] MailTos, string MailSub, string MailBody, bool isBodyHtml)
        {
            string smtpServer = "10.2.1.17";
            int smtpPort = 25;
            string mailAccount = "twwpos_service";
            string mailPwd = "TWpos@)!*";

            try
            {
                if (string.IsNullOrEmpty(MailFrom))
                {
                    MailFrom = "twwpos_service@taiwantaxi.com.tw";
                }

                //建立MailMessage物件
                System.Net.Mail.MailMessage mms = new System.Net.Mail.MailMessage();
                mms.From = new MailAddress(MailFrom);
                mms.Subject = MailSub;
                mms.Body = MailBody;
                mms.IsBodyHtml = isBodyHtml;

                if (MailTos != null)
                {
                    for (int i = 0; i < MailTos.Length; i++)
                    {
                        //加入信件的收信人(們)address
                        if (!string.IsNullOrEmpty(MailTos[i].Trim()))
                        {
                            mms.Bcc.Add(new MailAddress(MailTos[i].Trim()));
                        }
                    }
                }

                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    if (!string.IsNullOrEmpty(mailAccount) && !string.IsNullOrEmpty(mailPwd))
                    {
                        client.Credentials = new NetworkCredential(mailAccount, mailPwd);
                    }
                    client.Send(mms);//寄出一封信
                }
                Logs.Write("Mail", "Mail_Send From=" + mms.From + "\n" + "Mail_Send Bcc=" + mms.Bcc + "\n" + "Mail_Send Body=" + mms.Body + "\n" + "Mail_Send IsBodyHtml=" + mms.IsBodyHtml + "\n");
                //成功
                return true;

            }
            catch (Exception ex)
            {
                Logs.Write("Mail", "Mail_Send-Err=" + ex.Message + "\n");
                //寄失敗
                return false;
            }
        }

        public bool Google_Send( string[] MailTos, string MailSub, string MailBody)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string mailAccount = "bstwjacky@gmail.com";
            string mailPwd = "2griuddi";

            try
            {
                string MailFrom = "bstwjacky@gmail.com";

                //建立MailMessage物件
                System.Net.Mail.MailMessage mms = new System.Net.Mail.MailMessage();
                mms.From = new MailAddress(MailFrom);
                mms.Subject = MailSub;
                mms.Body = MailBody;
                mms.IsBodyHtml = true;

                if (MailTos != null)
                {
                    for (int i = 0; i < MailTos.Length; i++)
                    {
                        //加入信件的收信人address
                        if (!string.IsNullOrEmpty(MailTos[i].Trim()))
                        {
                            mms.To.Add(new MailAddress(MailTos[i].Trim()));
                        }
                    }
                }

                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    if (!string.IsNullOrEmpty(mailAccount) && !string.IsNullOrEmpty(mailPwd))
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Credentials = new NetworkCredential(mailAccount, mailPwd);
                    }
                    client.Send(mms);//寄出一封信
                }
                Logs.Write("Mail", "Mail_Send From=" + mms.From + "\n" + "Mail_Send Bcc=" + mms.Bcc + "\n" + "Mail_Send Body=" + mms.Body + "\n" + "Mail_Send IsBodyHtml=" + mms.IsBodyHtml + "\n");
                //成功
                return true;

            }
            catch (Exception ex)
            {
                Logs.Write("Mail", "Mail_Send-Err=" + ex.Message + "\n");
                //寄失敗
                return false;
            }
        }
    }
}