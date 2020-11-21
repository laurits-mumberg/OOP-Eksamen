using System;
using Line_system.Products;

namespace Line_system
{
    public class SeasonalProduct : Product
    {
        public DateTime SeasonStartDate { get; }
        public DateTime SeasonEndDate { get; }
        
        public override string ToString()
        {
            return $"ID: {ID}, {Name}, {Price}";
        }
    }
}