using DevStore.Domain.StoreContext.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevStore.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void send(string to, string from, string subject, string body)
        {
            //TODO 
        }
    }
}
