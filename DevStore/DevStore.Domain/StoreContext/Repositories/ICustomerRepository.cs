using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Queries;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DevStore.Domain.StoreContext.Repositoties
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CHeckEmail(string email);

        void Save(Customer customer);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);

        IEnumerable<ListCustomerQueryResult> Get();

        GetCustomerQueryRepository Get(Guid id);
        IEnumerable<ListCustomerOrderResult> GetOrdes(Guid Id);
    }
}