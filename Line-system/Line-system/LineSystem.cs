using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Line_system.CsvReading;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.Users;
using Transaction = System.Transactions.Transaction;

namespace Line_system
{
    public class LineSystem : ILineSystem
    {
        private IEnumerable<IUser> Users { get; set; }
        private IEnumerable<ITransaction> Transactions { get; set; }
        private IEnumerable<IProduct> Products { get; set; }

        public LineSystem()
        {
            Users = GetUserData(Path.Combine(Directory.GetCurrentDirectory(), "../../../../Data/users.csv"), ',');
            foreach (IUser user in Users)
            {
                Console.WriteLine(user);
            }

            Products = GetProductData(Path.Combine(Directory.GetCurrentDirectory(), "../../../../Data/products.csv"), ';');
            foreach (IProduct product in Products)
            {
                Console.WriteLine(product);
            }
        }
        
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

        public IEnumerable<IUser> GetUsers(Predicate<IUser> predicate)
        {
            return Users.Where(user => predicate(user));
        }

        public IUser GetUserByUsername(string username)
        {
            try
            {
                return Users.First(user => user.Username == username);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ITransaction> GetTransactions(IUser user, int count)
        {
            return Transactions.Where(transaction => transaction.User == user)
                .OrderBy((transaction => transaction.Date))
                .Take(count);
        }

        public IEnumerable<IProduct> ActiveProducts()
        {
            return Products.Where(product => product.IsActive).ToList();
        }

        private List<IUser> GetUserData(string filePath, char separator)
        {
            CsvReaderContext<IUser> readerContext = new CsvReaderContext<IUser>(new UserReadStrategy());
            return readerContext.ReadData(filePath, separator);
        }
        
        private List<IProduct> GetProductData(string filePath, char separator)
        {
            CsvReaderContext<IProduct> readerContext = new CsvReaderContext<IProduct>(new ProductReadStrategy());
            return readerContext.ReadData(filePath, separator);
        }
    }
}