using System;
using System.Collections.Generic;
using System.Linq;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.Users;
using Transaction = System.Transactions.Transaction;

namespace Line_system
{
    public class LineSystem : ILineSystem
    {
        private List<IUser> Users { get; set; }
        private List<ITransaction> Transactions { get; set; }
        
        public void BuyProduct(IUser user, IProduct product)
        {
            BuyTransaction buyTransaction = new BuyTransaction(user, product);
            
            try
            {
                ExecuteTransaction(buyTransaction);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddCreditsToAccount(IUser user, decimal amount)
        {
            InsertCashTransaction insertCashTransaction = new InsertCashTransaction(user, amount);
            ExecuteTransaction(insertCashTransaction);
        }

        public void ExecuteTransaction(ITransaction transaction)
        {
            transaction.Execute();
        }

        public Product GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<IUser> GetUsers(Predicate<IUser> predicate)
        {
            return Users.FindAll(predicate);
        }

        public IUser GetUserByUsername(string username)
        {
            return Users.Find(user => user.Username == username);
        }

        public List<ITransaction> GetTransactions(IUser user, int count)
        {
            return Transactions.FindAll(transaction => transaction.User == user)
                .OrderBy((transaction => transaction.Date))
                .Take(count)
                .ToList();
        }

        public List<Product> ActiveProducts()
        {
            throw new NotImplementedException();
        }
    }
}