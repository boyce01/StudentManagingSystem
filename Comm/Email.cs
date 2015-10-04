using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Comm //整体项目中的公共类库，DAL,BLL,UI都可以添加Comm的引用，然后调用
{
    /// <summary>
    /// 用于发送邮件
    /// </summary>
    public class Email
    {
        public string smtp;
        public string from;
        public string pwd;
        public string to;
        public string title;
        public string body;
        public ArrayList paths;

        /// <summary>
        /// 发送邮件单元类的构造函数
        /// </summary>
        /// <param name="Psmtp">SMTP服务器地址</param>
        /// <param name="Pfrom">发件人地址</param>
        /// <param name="Ppwd">发件人密码</param>
        /// <param name="Pto">收件人地址</param>
        /// <param name="Ptitle">主题</param>
        /// <param name="Pbody">正文</param>
        /// <param name="Ppaths">附件</param>
        public Email(string Psmtp, string Pfrom, string Ppwd, string Pto, string Ptitle, string Pbody, ArrayList Ppaths)//Email类的构造函数
        {
            smtp = Psmtp; from = Pfrom; pwd = Ppwd; to = Pto; title = Ptitle; body = Pbody; paths = Ppaths;
        }

        /*发邮件*/
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns>是否发送成功</returns>
        public bool SendMail()
        {
            //创建smtpclient对象
            System.Net.Mail.SmtpClient client = new SmtpClient();
            client.Host = smtp;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(from, pwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //创建mailMessage对象 
            System.Net.Mail.MailMessage message = new MailMessage(from, to);
            message.Subject = title;
            //正文默认格式为html
            message.Body = body;
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            //添加附件
            if (paths != null && paths.Count != 0)
            {
                foreach (string path in paths)
                {
                    Attachment data = new Attachment(path, System.Net.Mime.MediaTypeNames.Application.Octet);
                    message.Attachments.Add(data);
                }
            }
            try { client.Send(message); return true; }//MessageBox.Show("邮件发送成功."); 
            catch { return false; }//MessageBox.Show("邮件发送失败." + ex.ToString());
        }
    }
}

