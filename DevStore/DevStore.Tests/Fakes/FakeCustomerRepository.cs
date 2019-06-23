using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Repositoties;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevStore.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CHeckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
            
        }
    }
}
