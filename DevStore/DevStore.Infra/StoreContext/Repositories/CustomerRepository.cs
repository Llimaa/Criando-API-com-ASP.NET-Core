using Dapper;
using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Queries;
using DevStore.Domain.StoreContext.Repositoties;
using DevStore.Infra.StoreContext.DataContexts;
using System;
using System.Data;
using System.Linq;

namespace DevStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public bool CheckDocument(string document)
        {
            return _context.Connection.Query<bool>("spCheckDocument",
                new { Document = document },
                commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public bool CHeckEmail(string email)
        {
            return _context.Connection.Query<bool>("spCheckEmail",
                new { Email = email },
                commandType: CommandType.StoredProcedure) // uso esse parametro pra dizer que em vez de usar o select eu uso no nome da minha store procedure.
               .FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _context.Connection.Query<CustomerOrdersCountResult>("spGetCustomerOrdersCount",
                new { Document = document },
                commandType: CommandType.StoredProcedure)
               .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FistName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document.Number,
                    Email = customer.Email.Address,
                    Phone = customer.Phone
                }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                    new
                    {
                        Id = address.Id,
                        customerId = customer.Id,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City,
                        State = address.State,
                        Country = address.Country,
                        ZipCode = address.ZipCode,
                        Type = address.Type
                    }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
