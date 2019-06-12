using DevStore.Domain.StoreContext.Entities;

namespace DevStore.Domain.StoreContext.Repositoties
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CHeckEmail(string email);

        void Save(Customer customer);
    }
}