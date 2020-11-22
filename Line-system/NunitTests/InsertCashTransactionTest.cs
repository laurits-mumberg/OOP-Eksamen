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
            IUser user = Substitute.For<IUser>(); // TODO: Kan man bruge substitute her?
            user.Balance = userMoney;
            InsertCashTransaction insertCashTransaction = new InsertCashTransaction(user, insertMoney);
            
            // Act
            insertCashTransaction.Execute();
            
            // Assert
            Assert.AreEqual(userMoney + insertMoney, user.Balance);
        }
        
    }
}