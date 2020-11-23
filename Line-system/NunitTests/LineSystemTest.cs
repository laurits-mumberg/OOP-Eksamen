using Line_system;
using Line_system.Users;
using NUnit.Framework;

namespace NunitTests
{
    public class LineSystemTest
    {
        [SetUp]
        public void Setup()
        {

        }
        
        [TestCase("ndavo", true)]
        [TestCase("afull", true)]
        [TestCase("afull2", false)]
        public void GetTransactions_TransactionsExist_FilterAndReturnSuccessfully(string username, bool exists)
        {
            // Arrange 
            ILineSystem lineSystem = new LineSystem();

            // Act
            IUser user = lineSystem.GetUserByUsername(username);
            
            //Act
            Assert.AreEqual((user != null), exists);
        }
    }
}