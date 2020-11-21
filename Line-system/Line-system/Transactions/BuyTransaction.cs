using System;
using Line_system.Products;
using Line_system.Users;

namespace Line_system.Transactions
{
    public class BuyTransaction : Transaction

    {
        public IProduct Product { get; set; }
        
        // TODO: Fix
        public BuyTransaction(int id, User user, DateTime date, decimal amount, IProduct product) : base(id, user, date, amount)
        {
            Product = product;
        }

        public override void Execute()
        {
            if (Product.IsActive)
            {
                if (User.Balance - Product.Price >= 0 || Product.CanBeBoughtOnCredit)
                {
                    User.Balance -= Product.Price;
                }
                else
                {
                    // Throw 
                }
            }
            else
            {
                //  TODO: Throw exception om at varen ikke er aktiv
            }
        }
    }
}