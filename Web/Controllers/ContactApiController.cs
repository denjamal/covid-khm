using System;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Web.WebApi;
using Web.Services;

namespace Web.Controllers
{
    public class ContactApiController : UmbracoApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> CreateContactRequest(Models.ContactDTO contact)
        {
            try
            {
                using (var emailService = GetEmailService())
                {
                    emailService.Init();
                    await emailService.SendEmailAsync(contact);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }

        private static EmailService GetEmailService()
        {
            var emailForNotification = System.Configuration.ConfigurationManager.AppSettings["emailForNotification"];
            var smtpServer = System.Configuration.ConfigurationManager.AppSettings["smtpServer"];
            var smtpPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["smtpPort"]);
            var smtpLogin = System.Configuration.ConfigurationManager.AppSettings["smtpLogin"];
            var smtpPassword = System.Configuration.ConfigurationManager.AppSettings["smtpPassword"];
            var emailService = new EmailService(emailForNotification, smtpServer, smtpPort, smtpLogin, smtpPassword);
            emailService.Init();
            return emailService;
        }
    }
}
