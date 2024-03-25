using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WEBAPP.Models
{
    public class sendOTP
    {
        public string SendSMS(string body)

        {
            string result = string.Empty;
            try
            {
                string message = HttpUtility.UrlEncode(body);
                using (var wb = new WebClient())
                {
                    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "AZhiJq5mRhY-i5AA22JMFbWbUjwT5SAIAeronNKuLP"},
                {"numbers" , "919654116965"},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
                    result = System.Text.Encoding.UTF8.GetString(response);
                    return result;
                }

            }
            catch(Exception ex)
            {

            }
            return result;

        }


        public async Task<string>  SendEmail(string body)
        {

            HttpClient httpClient = new HttpClient();

           //var result= await httpClient.GetAsync("http://localhost:81/api/Email/sendEmail?body=text");
           // var apiKey = "SG.KzNkEQA5S2me0a2T0vvq-wJ3FH3zb8B74";
           // var client = new SendGridClient(apiKey);
           // var msg = new SendGridMessage()
           // {
           //     From = new EmailAddress("test@gmail.com", "MDF Online"),
           //     Subject = "Email Verification OTP",
           //     PlainTextContent =  HttpUtility.UrlEncode(body),
           //     //HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>"
           // };
           // msg.AddTo(new EmailAddress("testcc@gmail.com", "Super Admin"));
            //var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
            return "";
        }
    }
}