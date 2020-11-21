using System;
using Line_system.Users;

namespace Line_system.Transactions
{
    public class InsertCashTransaction : Transaction
    {
        // TODO: Gør noget bedre her
        public InsertCashTransaction(int id, User user, DateTime date, decimal amount) : base(id, user, date, amount)
        {
        }

        public override void Execute()
        {
            // TODO: Find ud af om det giver mening at skrive this hele tiden.
            User.Balance += this.Amount;
        }

        public override string ToString()
        {
            return $"{User.Username} inserted {this.Amount} into his/her account";
        }
    }
}