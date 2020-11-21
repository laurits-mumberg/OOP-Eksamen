using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;
using Line_system.Products;
using Line_system.Users;

namespace Line_system
{
    public interface ILineSystem
    {
        public void BuyProduct(User user, Product product);
        public void AddCreditsToAccount(User user, decimal amount);
        public void ExecuteTransaction(Transaction transaction);
        public Product GetProductByID(int id);
        public List<User> GetUsers(Predicate<User> predicate);
        public User GetUserByUsername(string username);
        public List<Transaction> GetTransactions(User user, int count);
        public List<Product> ActiveProducts();
    }
}
