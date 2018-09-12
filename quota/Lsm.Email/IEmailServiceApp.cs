using DoE.Email.Email.smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Email
{
    public interface IEmailServiceApp
    {
        SmtpClient Smtp
        { get; set; }
    }


}
