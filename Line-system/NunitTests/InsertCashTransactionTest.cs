using System.Text.RegularExpressions;
using Line_system.Transactions;
using Line_system.Users;
using NSubstitute;
using NUnit.Framework;

namespace NunitTests
{
    public class InsertCashTransactionTest
    {
        [TestCase(0, 10)]
        [TestCase(0, 0)]
        [TestCase(10, 100)]
        public void Execute_UserInsertesMoney_MoneyInsertedSuccesfully(decimal userMoney, decimal insertMoney)
        {
            // Arrange
            IUser user = new User(1,"first", "last", "user", userMoney,"test@test.com");
            InsertCashTransaction insertCashTransaction = new InsertCashTransaction(user, insertMoney);

            // Act
            insertCashTransaction.Execute();
            
            // Assert
            Assert.AreEqual(userMoney + insertMoney, user.Balance);
        }
        
    }
}