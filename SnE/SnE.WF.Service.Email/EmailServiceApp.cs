using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoE.Email.Email.smtp;
using DoE.MailConfig;

namespace DoE.Email
{
    public class EmailServiceApp : IEmailServiceApp
    {

        public EmailServiceApp(Client client)
        {

            switch (client)
            {
                case Client.Smtp:
                       Smtp = new SmtpClient();
                    break;
                default:
                    break;
            }

        }

        public SmtpClient Smtp
        {
            get;
            set;
        }

    }
}
