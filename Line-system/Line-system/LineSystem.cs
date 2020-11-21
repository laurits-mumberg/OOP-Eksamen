using System;
using System.Collections.Generic;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.Users;
using Transaction = System.Transactions.Transaction;

namespace Line_system
{
    public class LineSystem : ILineSystem
    {
        public void BuyProduct(User user, Product product)
        {
            try
            {
                BuyTransaction buyTransaction = new BuyTransaction(user, product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddCreditsToAccount(User user, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers(Predicate<User> predicate)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactions(User user, int count)
        {
            throw new NotImplementedException();
        }

        public List<Product> ActiveProducts()
        {
            throw new NotImplementedException();
        }
    }
}