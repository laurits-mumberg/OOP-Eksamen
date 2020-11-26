using System;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.Users;

namespace Line_system.UI
{
    public class LineSystemCLI : ILineSystemUI
    {
        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"Could not find a user with the username: {username}");
        }

        public void DisplayProductNotFound(string messge)
        {
            Console.WriteLine($"Product not found error: {messge}");
        }

        public void DisplayUserInfo(IUser user)
        {
            Console.WriteLine($"{user}\nBalance: {user.Balance}"); 
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine($"Too many arguments given for the {command} command");
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"The admin command {adminCommand} was not found");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine($"{transaction.User} bought {transaction.Product}");
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine($"{transaction.User} bought {count}: {transaction.Product.Name}");
        }

        public void Close()
        {
            Console.WriteLine("Should close program");// TODO: Luk lortet
        }

        public void DisplayInsufficientCash(IUser user, IProduct product)
        {
            Console.WriteLine($"({user}) has insufficient balance to buy: {product}\n" +
                              $"({user} has a balance of: {user.Balance})");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine($"Error: {errorString}");
        }

        public void DisplayTransaction(ITransaction transaction)
        {
            if (transaction is InsertCashTransaction insertCashTransaction)
            {
                Console.WriteLine($"{insertCashTransaction.User} inserted {insertCashTransaction.Amount}");
            }
            else if (transaction is BuyTransaction buyTransaction)
            {
                Console.WriteLine($"{buyTransaction.User} bought {buyTransaction.Product}");
            }
        }

        public void Start()
        {
            Console.WriteLine("Write a command:");
            string command = Console.ReadLine();
            CommandEntered?.Invoke(command);
        }

        public delegate void CommandEventHandler(string command);
        public event ILineSystemUI.CommandEventHandler CommandEntered;
    }
}