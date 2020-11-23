using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.Users;
using Transaction = System.Transactions.Transaction;

namespace Line_system
{
    public interface ILineSystem
    {
        public void BuyProduct(IUser user, IProduct product);
        public void AddCreditsToAccount(IUser user, decimal amount);
        public void ExecuteTransaction(ITransaction transaction);
        public Product GetProductByID(int id);
        public IEnumerable<IUser> GetUsers(Predicate<IUser> predicate);
        public IUser GetUserByUsername(string username);
        public IEnumerable<ITransaction> GetTransactions(IUser user, int count);
        public IEnumerable<IProduct> ActiveProducts();
    }
}
