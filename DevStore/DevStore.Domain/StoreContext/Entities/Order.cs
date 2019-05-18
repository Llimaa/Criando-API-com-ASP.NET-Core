using System;
using System.Collections.Generic;
using DevStore.Domain.StoreContext.Enums;

namespace DevStore.Domain.StoreContext.Entities
{
    public class Order
    {
        public Order(Customer customer) 
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            //tenho sempre que iniciar a lista qui no construtor, se nao vai dar erro quando eu for inserir algo nela.
            Items = new List<OrderItem>();
            Deliveies = new List<Delivery> ();

        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        //IReadOnlyCollection utilizamos ele para nao deixar
        // que outra classe que n seja  a partir do order add os item
        public IReadOnlyCollection<OrderItem> Items { get; private set; }
        public IReadOnlyCollection<Delivery> Deliveies { get; private set; }

    public void AddItem(OrderItem item) 
    {
        //validar item.
        //adiiona ao pedido.
    }
        //TO place an order
        public void Price(){}
    
    }
}