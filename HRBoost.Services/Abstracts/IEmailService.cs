using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBoost.Services.Abstracts
{
    public interface IEmailService
    {
        public Task SendEmail(string receptor, string subject, string body);
    }
}
