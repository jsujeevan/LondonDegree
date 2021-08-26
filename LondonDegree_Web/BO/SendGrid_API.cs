using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LondonDegree_Web.Models;
using System.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LondonDegree_Web.BO
{
    public class SendGrid_API
    {
        private static readonly log4net.ILog vm_Log_o = log4net.LogManager.GetLogger("ErrorLogger");

        public string SendEmail(EmailModel in_emailModel_o)
        {
            var responseString = "";
            string emailSwitch = ConfigurationManager.AppSettings["EMAIL"];
            string apiKey = ConfigurationManager.AppSettings["APPSETTING_SENDGRID_APIKEY"];
            string adminemailFrom = ConfigurationManager.AppSettings["APPSETTING_SENDGRID_LONDONDEGREE_EMAIL_FROM"];

            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(adminemailFrom),
                Subject = in_emailModel_o.Email_Subject_s,
                HtmlContent = in_emailModel_o.Email_Message_s,
            };
            msg.AddTo(new EmailAddress(in_emailModel_o.Person_To_Email_s));
            if (emailSwitch.Equals("ON", StringComparison.InvariantCultureIgnoreCase)) {
                var response = client.SendEmailAsync(msg);
                vm_Log_o.Info("Email " + in_emailModel_o.PK_Email_ID_gu + " Status " + response.Status.ToString());
                responseString = response.Status.ToString();
            }
            
            return responseString;
        }
    }
}