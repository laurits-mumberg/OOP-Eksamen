using System;
using Line_system.Users;

namespace Line_system.Transactions
{
    public abstract class Transaction : ITransaction

    {
        public int ID { get; }
        public User User { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }

        public Transaction(User user, decimal amount)
        {
            ID = 1; // TODO
            User = user;
            Date = DateTime.Now;
            Amount = amount;
        }
        
        public abstract void Execute();

        public override string ToString()
        {
            return $"{ID}, ({User}), {Amount}, {Date}";
        }
    }
}