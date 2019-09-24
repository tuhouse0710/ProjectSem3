using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ProjectB8220.Models
{
    public static class Helper
    {
        


        ///<Sumary>
        ///Phương thức gửi mail
        ///</sumary>
        ///<param name ="toEmail"> Địa chỉ email nhận </param>
        ///<param name ="fromEmail"> Địa chỉ email nhận </param>
        ///<param name ="passEmail"> Địa chỉ email nhận </param>
        ///<param name ="tittleEmail"> Địa chỉ email nhận </param>
        ///<param name ="contentEmail"> Địa chỉ email nhận </param>
        public static void SendEmail(string toEmail,string fromEmail,string passEmail,string titleEmail, string contentEmail)
        {
            MailMessage mail = new MailMessage(); // Tạo đối tượng mail
            mail.To.Add(toEmail); // Gửi đến email
            mail.From = new MailAddress(fromEmail);
            mail.Subject = titleEmail; //Tiêu đề mail 
            mail.Body = contentEmail; //Phần thân email
            mail.IsBodyHtml = true; //Cho phép viết mã Html trong mail
            SmtpClient smtp = new SmtpClient(); //Tạo đối tượng gửi mail
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential(fromEmail, passEmail); // Tài khoản mail của bạn
            smtp.EnableSsl = true;
            smtp.Send(mail); //Gửi mail
        }

        internal static void SendEmail(string email, string v1, string v2, string v3, string v4,string v5)
        {
            throw new NotImplementedException();
        }

        internal static void SendEmail(string email, string v1, string v2, string v3, string v4, string v5,string v6)
        {
            throw new NotImplementedException();
        }
    }
}