using System;
using Line_system.Users;

namespace Line_system.Transactions
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(IUser user, decimal amount) : base(user, amount)
        {
        }

        public override void Execute()
        {
            User.Balance += this.Amount;
            SaveToFile($"{ID},{User},{Date},{Amount}");
        }

        public override string ToString()
        {
            return $"InsertCashTransaction: {base.ToString()}";
        }
    }
}