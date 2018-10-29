
using System.Threading.Tasks;

namespace DoE.MailConfig
{

    public enum EmailBodyContext
    {
        Text,
        Html
    }

    public enum Client
    {
        Smtp,
        Protocol
    }

    public abstract class Email 
    {
        public abstract Email To();
        public abstract Email From();
        public abstract Email CC();
        public abstract Email BCC();

        public abstract Email AddSubject(string subject);
        public abstract Email AddMessage(EmailBodyContext contextType);

        public abstract Email SendEmail();
        public abstract Email SendToMailbox();

        public abstract Task<Email> SendEmailAsync();
        public abstract Task<Email> SendToMailboxAsync();

    }
}
