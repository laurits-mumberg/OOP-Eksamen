using System;
using System.Collections.Generic;
using System.Linq;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.UI;
using Line_system.Users;
using Transaction = System.Transactions.Transaction;

namespace Line_system.Controller
{
    public class LineSystemController
    {
        private ILineSystem _lineSystem;
        private ILineSystemUI _lineSystemUi;
        private Dictionary<string, Action<string[]>> _adminCommands = new Dictionary<string, Action<string[]>>();
        
        public LineSystemController(ILineSystem lineSystem, ILineSystemUI lineSystemUi)
        {
            _lineSystem = lineSystem;
            _lineSystemUi = lineSystemUi;

            _adminCommands.Add(":quit", (argv) => _lineSystemUi.Close());
            _adminCommands.Add(":q", (argv) => _lineSystemUi.Close());
            _adminCommands.Add(":activate", (argv) => lineSystem.GetProductByID(int.Parse(argv[1])).IsActive = true);
            _adminCommands.Add(":deactivate", (argv) => lineSystem.GetProductByID(int.Parse(argv[1])).IsActive = false);
            _adminCommands.Add(":crediton", (argv) => lineSystem.GetProductByID(int.Parse(argv[1])).CanBeBoughtOnCredit = true);
            _adminCommands.Add(":creditoff", (argv) => lineSystem.GetProductByID(int.Parse(argv[1])).CanBeBoughtOnCredit = false);
            _adminCommands.Add(":addcredits", (argv) => lineSystem.AddCreditsToAccount(
                lineSystem.GetUserByUsername(argv[1]), decimal.Parse(argv[2])));
            
            _lineSystemUi.CommandEntered += ParseCommand;
            lineSystemUi.DisplayAvailableProducts(lineSystem.ActiveProducs.ToList());
            _lineSystemUi.Start();
        }
        
        public void ParseCommand(string command)
        {
            string[] args = command.Split(" ");

            try
            {
                if (IsAdminCommand(args))
                {
                    try
                    {
                        _adminCommands[args[0]](args);
                    }
                    catch (KeyNotFoundException e)
                    {
                        throw new AdminCommandNotFoundException();
                    }

                }
                else
                {
                    if (args.Length == 1)
                    {
                        DisplayUserInfo(args);
                    }
                    else if (args.Length > 1)
                    {
                        UserBuyProducts(args);
                    }
                }
            }
            catch (ProductNotFoundException e)
            {
                _lineSystemUi.DisplayProductNotFound(e.Message);
            }
            catch (UserNotFoundException e)
            {
                _lineSystemUi.DisplayUserNotFound(e.Message);
            }
            catch (InsufficientCreditsException e)
            {
                _lineSystemUi.DisplayInsufficientCash(_lineSystem.GetUserByUsername(args[0]),
                    _lineSystem.GetProductByID(int.Parse(args[1])));
            }
            catch (AdminCommandNotFoundException e)
            {
                _lineSystemUi.DisplayAdminCommandNotFoundMessage(args[0]);
            }
            catch (Exception e)
            {
                _lineSystemUi.DisplayGeneralError(e.Message);
            }
            finally
            {
                _lineSystemUi.Start();
            }
        }

        private bool IsAdminCommand(string[] args)
        {
            return args[0][0] == ':';
        }

        private void DisplayUserInfo(string[] args)
        {
            IUser user = _lineSystem.GetUserByUsername(args[0]);
            _lineSystemUi.DisplayUserInfo(user);
            List<ITransaction> transactions = _lineSystem.GetTransactions(user, 10);
            
            foreach (ITransaction transaction in transactions)
            {
                _lineSystemUi.DisplayTransaction(transaction);
            }
        }
        
        private void UserBuyProducts(string[] args)
        {
            IUser user = _lineSystem.GetUserByUsername(args[0]);

            for (int i = 1; i < args.Length; i++)
            {
                IProduct product = _lineSystem.GetProductByID(int.Parse(args[i]));
                BuyTransaction buyTransaction = _lineSystem.BuyProduct(user, product);
                _lineSystemUi.DisplayUserBuysProduct(buyTransaction);
            }
        }
    }
}