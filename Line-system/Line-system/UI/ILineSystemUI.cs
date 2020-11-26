using System;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.Users;
using NUnit.Framework.Internal.Execution;

namespace Line_system.UI
{
    public interface ILineSystemUI
    {
        public delegate void CommandEventHandler(string command);
        public event CommandEventHandler CommandEntered;
        
        void DisplayUserNotFound(string username);
        void DisplayProductNotFound(string message);
        void DisplayUserInfo(IUser user);
        void DisplayTooManyArgumentsError(string command);
        void DisplayAdminCommandNotFoundMessage(string adminCommand);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void Close();
        void DisplayInsufficientCash(IUser user, IProduct product);
        void DisplayGeneralError(string errorString);
        void DisplayTransaction(ITransaction transaction);
        void Start();
    }
}