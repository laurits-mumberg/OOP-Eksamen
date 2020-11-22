﻿using System;
using Line_system.Products;
using Line_system.Users;

namespace Line_system.Transactions
{
    public class BuyTransaction : Transaction

    {
        public IProduct Product { get; set; }
        
        // TODO: Fix
        public BuyTransaction(IUser user, IProduct product) : base(user, product.Price * -1)
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
                    throw new InsufficientCreditsException($"({User}) does not have enough to buy product: ({Product}). User balance is: {User.Balance}");
                }
            }
            else
            {
                //  TODO: Throw exception om at varen ikke er aktiv
            }
        }

        public override string ToString()
        {
            return $"BuyTransaction: {base.ToString()}, {Product}";
        }
    }
}