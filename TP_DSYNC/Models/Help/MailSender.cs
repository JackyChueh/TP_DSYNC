using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using TP_DSYNC.Models.DataDefine.ALERT;

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

        public string MailTemplate(ALERT_LOG c)
        {
            string html = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8' />
    <title></title>
    <style>
        body {{
            width: 100%;
            font-family: '微軟正黑體', 'Microsoft JhengHei', 'Segoe UI Semibold', 'Segoe UI', 'Lucida Grande', Verdana, Arial, Helvetica, sans-serif
        }}

        .content-head {{
            font-size: 24px;
            font-weight: bold;
            color: #ffffff;
            background-color: #0094ff;
            height: 100px;
            padding-left: 20px;
            border-radius: 5px;
        }}

        .content-body {{
            margin-top: 10px;
            max-width: 100%;
            border-collapse: collapse;
            border-radius: 5px;
            font-size:16px;
        }}

            .content-body thead {{
                background-color: #eeeeee;
            }}

            .content-body td {{
                border: 1px solid #0094ff;
                padding: 10px;
                text-align: left;
            }}

            .content-body .error {{
                color: #ff0000;
            }}


        .content-footer {{
            width: 100%;
            height: 50px;
        }}

            .content-footer .send-time {{
                text-align: left;
            }}

            .content-footer .send-from {{
                text-align: right;
            }}
    </style>
</head>
<body>
    <table>
        <tr>
            <td class='content-head'>
                <table style='width:100%;'>
                    <tr>
                        <td style='width:100%; text-align:center;'>
                            中控室監控數據異常通知
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class='content-body'>
                    <thead>
                        <tr><td>監控類別</td><td>位置</td><td>設備名稱</td><td>數據欄位</td><td>最大值</td><td>最小值</td><td>異常值</td><td>警報時間</td></tr>
                    </thead>
                    <tbody>
                        <tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td class='error'>{6}</td><td>{7}</td></tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td class='content-footer'>
                <table style='width:100%'>
                    <tr>
                        <td class='send-time'>
                            發送時間:{8}
                        </td>
                        <td class='send-from'>
                            訊息來源:中控室監控數據報表系統
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>

";

            html = string.Format(html, c.DATA_TYPE, c.LOCATION, c.DEVICE_ID, c.DATA_FIELD, c.MAX_VALUE, c.MIN_VALUE, c.ALERT_VALUE, ((DateTime)c.CHECK_DATE).ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return html;
        }
    }
}