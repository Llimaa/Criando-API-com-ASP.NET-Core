using System;
using System.Collections.Generic;
using System.Text;

namespace DevStore.Domain.StoreContext.Queries
{
    public class GetCustomerQueryRepository
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string  Email { get; set; }
    }
}
