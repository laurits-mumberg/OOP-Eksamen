using System;
using Line_system.Users;

namespace Line_system.Transactions
{
    public class InsertCashTransaction : Transaction
    {
        // TODO: Gør noget bedre her
        public InsertCashTransaction(User user, decimal amount) : base(user, amount)
        {
        }

        public override void Execute()
        {
            User.Balance += this.Amount;
        }

        public override string ToString()
        {
            return $"InsertCashTransaction: {base.ToString()}";
        }
    }
}