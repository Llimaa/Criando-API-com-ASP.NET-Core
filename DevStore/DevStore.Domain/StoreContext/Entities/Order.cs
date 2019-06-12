using System;
using System.Collections.Generic;
using System.Linq;
using DevStore.Domain.StoreContext.Enums;
using DevStore.Shared.Entities;
using FluentValidator;

namespace DevStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            //tenho sempre que iniciar a lista qui no construtor, se nao vai dar erro quando eu for inserir algo nela.
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();

        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        //IReadOnlyCollection utilizamos ele para nao deixar
        // que outra classe que n seja  a partir do order add os item
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} n�o tem {quantity} em estoque.");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        //Criar um pedido
        public void Place()
        {
            //Gerar n�mero do pedido.
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_items.Count == 0)
                AddNotification("Order", "Este pedido n�o possui itens!");
        }

        //Pagar um pedido
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        //Enviar um pedido.
        public void Ship()
        {
            //A cada 5 produtos � um entrega.
            var deliveries = new List<Delivery>();
            // deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            //Quebra as entregas.
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            //Envia as entregas.
            deliveries.ForEach(x => x.Ship());

            //adiciona as entregas aos pedidos.
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        //Cancelar pedido.
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }


    }
}