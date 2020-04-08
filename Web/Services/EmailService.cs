using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Web.Services
{
    public class EmailService : IDisposable
    {
        private bool _disposed;
        private readonly string _emailForNotification = string.Empty;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpLogin;
        private readonly string _smtpPassword;
        private SmtpClient _smtpClient;

        public EmailService(
            string emailForNotification,
            string smtpServer,
            int smtpPort,
            string smtpLogin,
            string smtpPassword
            )
        {
            _emailForNotification = emailForNotification
                ?? throw new ArgumentNullException(nameof(emailForNotification));
            _smtpServer = smtpServer
                ?? throw new ArgumentNullException(nameof(smtpServer));
            _smtpPort = smtpPort;
            _smtpLogin = smtpLogin
                ?? throw new ArgumentNullException(nameof(smtpLogin));
            _smtpPassword = smtpPassword
                ?? throw new ArgumentNullException(nameof(smtpPassword));
        }

        public void Init()
        {
            _smtpClient = new SmtpClient(_smtpServer, _smtpPort)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(_smtpLogin, _smtpPassword)
            };
        }

        public Task SendEmailAsync(Models.ContactDTO contact)
        {
            var subject = "Message from " + contact.ContactName;
            var msg = $"From: name: {contact.ContactName} \n email: {contact.ContactEmail} \n message: {contact.ContactMessage}";
            var message = new MailMessage(_smtpLogin, _emailForNotification, subject, msg);
            return _smtpClient.SendMailAsync(message);
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _smtpClient?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposed = true;
            }
        }

        ~EmailService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        #endregion IDisposable Support
    }
}