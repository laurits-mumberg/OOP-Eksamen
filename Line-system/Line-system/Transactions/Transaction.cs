using System;
using Line_system.Users;

namespace Line_system.Transactions
{
    public class Transaction : ITransaction

    {
        public int ID { get; }
        public User User { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }

        public Transaction(int id, User user, DateTime date, decimal amount)
        {
            ID = id;
            User = user;
            Date = date;
            Amount = amount;
        }
        
        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
    }
}