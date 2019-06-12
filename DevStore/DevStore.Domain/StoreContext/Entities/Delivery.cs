using System;
using DevStore.Domain.StoreContext.Enums;
using DevStore.Shared.Entities;
using FluentValidator;

namespace DevStore.Domain.StoreContext.Entities
{
    public class Delivery: Entity
    {
        public Delivery(DateTime estimateDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimateDeliveryDate = estimateDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimateDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            //se data estimada da entrega for no passado nao entregar.
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            //Se status ja estiver entregue nao pode cancelar.
            Status = EDeliveryStatus.Canceled;
        }
    }
}