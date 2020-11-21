using System;
using Line_system.Users;

namespace Line_system.Transactions
{
    public interface ITransaction
    {
        public int ID { get; }
        public User User { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }
        
        public void Execute();
    }
}