using System;
using System.Collections.Generic;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.UI;
using Line_system.Users;

namespace Line_system.CLI
{
    public class LineSystemCLI
    {
        private ILineSystem _lineSystem;
        private ILineSystemUI _lineSystemUi;
        private Dictionary<string, Action<string[]>> _adminCommands = new Dictionary<string, Action<string[]>>();
        
        public LineSystemCLI(ILineSystem lineSystem, ILineSystemUI lineSystemUi)
        {
            _lineSystem = lineSystem;
            _lineSystemUi = lineSystemUi;

            _adminCommands.Add(":quit", (argv) => _lineSystemUi.Close());
            _adminCommands.Add(":q", (argv) => _lineSystemUi.Close());
            _adminCommands.Add(":activate", (argv) => lineSystem.GetProductByID(int.Parse(argv[1])).IsActive = true);
            _adminCommands.Add(":deactivate", (argv) => lineSystem.GetProductByID(int.Parse(argv[1])).IsActive = false);
            _adminCommands.Add(":crediton", (argv) => lineSystem.GetProductByID(int.Parse(argv[1])).CanBeBoughtOnCredit = true);
            _adminCommands.Add(":creditoff", (argv) => lineSystem.GetProductByID(int.Parse(argv[1])).CanBeBoughtOnCredit = false);
            _adminCommands.Add(":addcredits", (argv) => new InsertCashTransaction(
                lineSystem.GetUserByUsername(argv[1]), decimal.Parse(argv[2])).Execute());
            
            _lineSystemUi.CommandEntered += ParseCommand;
            _lineSystemUi.Start();
        }
        
        public void ParseCommand(string command)
        {
            string[] args = command.Split(" ");

            if (IsAdminCommand(args))
            {
                _adminCommands[args[0]](args);
            }
            else
            {
                try
                {
                    UserBuyProducts(args);
                }
                catch
                {
                    //TODO
                }
            }
            _lineSystemUi.Start();
        }

        private bool IsAdminCommand(string[] args)
        {
            return args[0][0] == ':';
        }

        private void UserBuyProducts(string[] args)
        {
            IUser user = _lineSystem.GetUserByUsername(args[0]);
            Console.WriteLine(user);

            for (int i = 1; i < args.Length; i++)
            {
                IProduct product = _lineSystem.GetProductByID(int.Parse(args[i]));
                BuyTransaction buyTransaction = _lineSystem.BuyProduct(user, product);
                _lineSystemUi.DisplayUserBuysProduct(buyTransaction);
            }
        }
    }
}