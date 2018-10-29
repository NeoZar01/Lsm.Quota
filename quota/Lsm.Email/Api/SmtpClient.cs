using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoE.MailConfig;

namespace DoE.Email.Email.smtp
{
    public class SmtpClient : DoE.MailConfig.Email
    {

        public override MailConfig.Email AddMessage(EmailBodyContext contextType)
        {
            return this;
        }

        public override MailConfig.Email AddSubject(string subject)
        {
            return this;
        }

        public override MailConfig.Email BCC()
        {
            return this;
        }

        public override MailConfig.Email CC()
        {
            return this;
        }

        public override MailConfig.Email From()
        {
            return this;
        }

        public override MailConfig.Email SendEmail()
        {
            return this;
        }

        public override Task<MailConfig.Email> SendEmailAsync()
        {
            throw new NotImplementedException();
        }

        public override MailConfig.Email SendToMailbox()
        {
            return this;
        }

        public override Task<MailConfig.Email> SendToMailboxAsync()
        {
            throw new NotImplementedException();
        }

        public override MailConfig.Email To()
        {
            return this;
        }
    }
}
