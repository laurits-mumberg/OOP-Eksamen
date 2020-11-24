namespace Line_system.Products
{
    public interface IProduct
    {
        public int ID { get; }
        public string Name { get; }
        public decimal Price { get; }
        public bool IsActive { get; set; }
        public bool CanBeBoughtOnCredit { get; }
        
        // TODO: Find ud af om den her gør noget
        public string ToString();
    }
}