namespace Line_system.Products
{
    public class Product : IProduct

    {
        public int ID { get; }
        public string Name { get; }
        public decimal Price { get; }
        public virtual bool IsActive { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public Product(int id, string name, decimal price, bool isActive, bool canBeBoughtOnCredit)
        {
            ID = id;
            Name = name;
            Price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }
        
        public override string ToString()
        {
            return $"ID: {ID}, {Name}, {Price}";
        }
    }
}