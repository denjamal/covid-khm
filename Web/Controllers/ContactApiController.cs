using System;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Web.WebApi;
using Web.Services;

namespace Web.Controllers
{
    public class ContactApiController : UmbracoApiController
    {
        string _emailForNotification = "";
        string _smtpServer = "";
        int _smtpPort = 0;
        string _smtpLogin = "";
        string _smtpPassword = "";

        public ContactApiController()
        {
            _emailForNotification = System.Configuration.ConfigurationManager.AppSettings["emailForNotification"];
            _smtpServer = System.Configuration.ConfigurationManager.AppSettings["smtpServer"];
            _smtpPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["smtpPort"]);
            _smtpLogin = System.Configuration.ConfigurationManager.AppSettings["smtpLogin"];
            _smtpPassword = System.Configuration.ConfigurationManager.AppSettings["smtpPassword"];
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateContactRequest(Models.ContactDTO contact)
        {
            try
            {
                using (EmailService emailSerrvice = new EmailService(_emailForNotification, _smtpServer, _smtpPort, _smtpLogin, _smtpPassword))
                {
                    emailSerrvice.Init();
                    await emailSerrvice.SendEmailAsync(contact);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }
    }
}
