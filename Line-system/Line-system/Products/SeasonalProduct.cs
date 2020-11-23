using System;
using Line_system.Products;

namespace Line_system
{
    public class SeasonalProduct : Product
    {
        public DateTime SeasonStartDate { get; }
        public DateTime SeasonEndDate { get; }
     
        public SeasonalProduct(int id, string name, decimal price, bool isActive, DateTime seasonStartDate, DateTime seasonEndDate)
            : base(id, name, price, isActive)
        {
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }
        
        public override string ToString()
        {
            return $"ID: {ID}, {Name}, {Price}";
        }
    }
}