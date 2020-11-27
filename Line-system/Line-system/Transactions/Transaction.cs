using System;
using System.IO;
using Line_system.Users;

namespace Line_system.Transactions
{
    public abstract class Transaction : ITransaction

    {
        private static int currentID = 0;
        public int ID { get; }
        public IUser User { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }

        public Transaction(IUser user, decimal amount)
        {
            ID = currentID;
            currentID++;
            User = user;
            Date = DateTime.Now;
            Amount = amount;
        }

        protected void SaveToFile(string transactionLog)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "../../../../Data/transactions.csv");
            if (File.Exists(path))
            {
                StreamWriter streamWriter = File.AppendText(path);
                streamWriter.WriteLine(transactionLog);
                streamWriter.Dispose();
            }
            else
            {
                File.Create(path).Dispose();
                SaveToFile(transactionLog);
            }
        }
        
        public abstract void Execute();

        public override string ToString()
        {
            return $"{ID}, ({User}), {Amount}, {Date}";
        }
    }
}