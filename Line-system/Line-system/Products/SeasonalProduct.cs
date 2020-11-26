using System;
using Line_system.Products;

namespace Line_system
{
    public class SeasonalProduct : Product
    {
        public override bool IsActive => (DateTime.Now > SeasonStartDate && DateTime.Now < SeasonEndDate);
        public DateTime SeasonStartDate { get; }
        public DateTime SeasonEndDate { get; }
     
        public SeasonalProduct(int id, string name, decimal price, bool isActive, bool canBeBoughtOnCredit, DateTime seasonStartDate, DateTime seasonEndDate)
            : base(id, name, price, isActive, canBeBoughtOnCredit)
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