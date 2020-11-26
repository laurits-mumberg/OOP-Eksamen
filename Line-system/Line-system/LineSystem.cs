using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Line_system.CsvReading;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.UI;
using Line_system.Users;
using Transaction = System.Transactions.Transaction;

namespace Line_system
{
    public class LineSystem : ILineSystem
    {
        private IEnumerable<IUser> Users { get; set; }
        private List<ITransaction> Transactions { get; set; } = new List<ITransaction>();
        private IEnumerable<IProduct> Products { get; set; }

        public IEnumerable<IProduct> ActiveProducs
        {
            get
            {
                return Products.Where(product => product.IsActive).ToList();
            }
        }

        public LineSystem()
        {
            Users = GetUserData(Path.Combine(Directory.GetCurrentDirectory(), "../../../../Data/users.csv"), ',').ToList();

            Products = GetProductData(Path.Combine(Directory.GetCurrentDirectory(), "../../../../Data/products.csv"), ';').ToList();
        }
        
        public BuyTransaction BuyProduct(IUser user, IProduct product)
        {
            BuyTransaction buyTransaction = new BuyTransaction(user, product);
            ExecuteTransaction(buyTransaction);
            Transactions.Add(buyTransaction);

            return buyTransaction;
        }

        public InsertCashTransaction AddCreditsToAccount(IUser user, decimal amount)
        {
            InsertCashTransaction insertCashTransaction = new InsertCashTransaction(user, amount);
            ExecuteTransaction(insertCashTransaction);
            Transactions.Add(insertCashTransaction);
            
            return insertCashTransaction;
        }

        public void ExecuteTransaction(ITransaction transaction)
        {
            transaction.Execute();
        }

        public IProduct GetProductByID(int id)
        {
            try
            {
                return Products.First(product => product.ID == id);
            }
            catch
            {
                throw new ProductNotFoundException(id.ToString());
            }
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
                throw new UserNotFoundException(username);
            }
        }

        public List<ITransaction> GetTransactions(IUser user, int count)
        {
            return Transactions.Where(transaction => transaction.User == user)
                .OrderBy((transaction => transaction.Date))
                .Take(count)
                .ToList();
        }

        private IEnumerable<IUser> GetUserData(string filePath, char separator)
        {
            CsvReaderContext<IUser> readerContext = new CsvReaderContext<IUser>(new UserReadStrategy());
            return readerContext.ReadData(filePath, separator);
        }
        
        private IEnumerable<IProduct> GetProductData(string filePath, char separator)
        {
            CsvReaderContext<IProduct> readerContext = new CsvReaderContext<IProduct>(new ProductReadStrategy());
            return readerContext.ReadData(filePath, separator);
        }
    }
}