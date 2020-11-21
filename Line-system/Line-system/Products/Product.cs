namespace Line_system.Products
{
    public class Product : IProduct

    {
        public int ID { get; }
        public string Name { get; }
        public decimal Price { get; }
        public bool IsActive { get; }
        public bool CanBeBoughtOnCredit { get; }
    }
}