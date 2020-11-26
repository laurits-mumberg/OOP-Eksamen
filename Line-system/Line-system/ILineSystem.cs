using System;
using System.Collections.Generic;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.Users;

namespace Line_system
{
    public interface ILineSystem
    {
        public IEnumerable<IProduct> ActiveProducs { get; }
        public BuyTransaction BuyProduct(IUser user, IProduct product);
        public InsertCashTransaction AddCreditsToAccount(IUser user, decimal amount);
        public void ExecuteTransaction(ITransaction transaction);
        public IProduct GetProductByID(int id);
        public IEnumerable<IUser> GetUsers(Predicate<IUser> predicate);
        public IUser GetUserByUsername(string username);
        public List<ITransaction> GetTransactions(IUser user, int count);
    }
}
