using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace ShopStore.Tools
{
    public class Emailing
    {
        public static void Email(string to, string subject, string mailbody)
        {
            using (var mm = new MailMessage("brianmanson1231@gmail.com", to))
            {
                mm.Body = mailbody;
                mm.Subject = subject;
                mm.IsBodyHtml = true;
                var smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                var networkCred = new NetworkCredential("brianmanson1231@gmail.com", "kivixklhyrgzgtmr");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}