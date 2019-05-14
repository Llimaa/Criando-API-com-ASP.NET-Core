using System;
using System.Collections.Generic;

namespace DevStore.Domain.StoreContext
{
    public class Order
    {
        public Customer Customer { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }

        public IList<OrderItem> Items { get; set; }
        public IList<delivery> Deliveies { get; set; }

    
        //TO place an order
        public void Price(){}
    }
}