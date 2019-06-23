using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Queries;

namespace DevStore.Domain.StoreContext.Repositoties
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CHeckEmail(string email);

        void Save(Customer customer);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
    }
}