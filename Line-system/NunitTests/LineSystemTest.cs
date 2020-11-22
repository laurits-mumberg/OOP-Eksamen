using System;
using System.Collections.Generic;
using Line_system;
using Line_system.Transactions;
using Line_system.Users;
using NSubstitute;
using NSubstitute.Exceptions;
using NUnit.Framework;

namespace NunitTests
{
    public class LineSystemTest
    {

        private IUser User1 { get; set; }
        private IUser User2 { get; set; }
        private List<ITransaction> TestTransactions { get; set; }
        
        
        [SetUp]
        public void Setup()
        {
            User1 = Substitute.For<IUser>();
            User2 = Substitute.For<IUser>();
            
            TestTransactions[0] = getSubstituteTransaction(User1, DateTime.Now, 1);
            TestTransactions[1] = getSubstituteTransaction(User1, DateTime.Now.AddDays(-1), 2);
            TestTransactions[3] = getSubstituteTransaction(User1, DateTime.Now.AddDays(-2), 3);
            TestTransactions[4] = getSubstituteTransaction(User2, DateTime.Now, 4);
            TestTransactions[5] = getSubstituteTransaction(User2, DateTime.Now.AddDays(-1), 5);
        }

        private ITransaction getSubstituteTransaction(IUser user, DateTime date, int id)
        {
            ITransaction transaction = Substitute.For<ITransaction>();
            transaction.User.Returns(user);
            transaction.Date.Returns(date);
            transaction.ID.Returns(id);

            return transaction;
        }
        
        [TestCase()]
        public void GetTransactions_TransactionsExist_FilterAndReturnSuccessfully(IUser user, int count)
        {
            // Arrange 
            ILineSystem lineSystem = Substitute.For<ILineSystem>();
            lineSystem.
            
            //Act
            lineSystem.GetTransactions(user, count);
        }
    }
}