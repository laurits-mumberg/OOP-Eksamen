using System;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.Users;

namespace Line_system.UI
{
    public class LineSystemUI : ILineSystemUI

    {
        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"Could not find a user with the username: {username}");
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine("Product not found");
        }

        public void DisplayUserInfo(User user)
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

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine($"({user}) has insufficient balance to buy: {product}\n" +
                              $"({user} has a balance of: {user.Balance})");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine($"Error: {errorString}");
        }

        public void Start()
        {
            Console.WriteLine("AAU LINE SYSTEM COMMAND DUMP");
        }
    }
}