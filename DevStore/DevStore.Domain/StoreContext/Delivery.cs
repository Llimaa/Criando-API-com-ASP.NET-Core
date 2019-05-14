using System;

namespace DevStore.Domain.StoreContext
{
    public class delivery
    {
        public DateTime CreateDate { get; set; }
        public DateTime EstimateDeliveryDate { get; set; }
        public string  status { get; set; }
    }
}