using System;
using System.Collections.Generic;

namespace DevStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand
    {
        public Guid Id { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }
    }

    public class OrderItemCommand
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
    }
}