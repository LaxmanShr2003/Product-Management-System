using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laxmanPMS.Infrastructure.Services
{
    public class EmailSender: IEmailSender
    {
      

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Plug in your email service here to send an email.
            return Task.CompletedTask;
        }
    }
}
