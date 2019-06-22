using DevStore.Domain.StoreContext.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevStore.Tests.Fakes
{
    class FakeEmailService : IEmailService
    {
        public void send(string to, string from, string subject, string body)
        {
            
        }
    }
}
