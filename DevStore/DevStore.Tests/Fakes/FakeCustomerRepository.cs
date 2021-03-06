﻿using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Queries;
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

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryRepository Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerOrderResult> GetOrdes(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
            
        }
    }
}
