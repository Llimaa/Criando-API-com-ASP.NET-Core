using System;
using DevStore.Domain.StoreContext.Enums;

namespace DevStore.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public Delivery (DateTime estimateDeliveryDate) 
        {
            CreateDate = DateTime.Now;
            EstimateDeliveryDate = estimateDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimateDeliveryDate { get; private set; }
        public EDeliveryStatus  Status { get; private set; }
    }
}