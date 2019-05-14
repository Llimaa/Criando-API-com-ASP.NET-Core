namespace DevStore.Domain.StoreContext
{
    public class OrderItem
    {
        public Product Propduct { get; set; }
        public string  Quantity { get; set; }
        public string  Price { get; set; }
    }
}