using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace Utilities.Helper
{
    public static class MailSender
    {
        public static string sendMail(string Title, string Message)
        {
            try
            {

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.EnableSsl = true;

                smtp.Credentials = new NetworkCredential("hr.abkrenoooo@gmail.com", "hr.abkrenoooo@123");


                smtp.Send("hr.abkrenoooo@gmail.com", "elgendya160@gmail.com", Title, Message);

                return "Mail Sent Successfully";

            }
            catch (Exception ex)
            {
                return "Mail Faild";
            }
        }
    }
}
