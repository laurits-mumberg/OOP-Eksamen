using Line_system;
using Line_system.Products;
using Line_system.Transactions;
using Line_system.Users;
using NUnit.Framework;
using NSubstitute;

namespace NunitTests
{
    public class BuyProductsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(10, 1)]
        [TestCase(10, 10)]
        [TestCase(0, 0)]
        public void BuyProduct_UserBuysProductWithEnoughMoney_PurchaseSuccessful(decimal userMoney, decimal productPrice)
        {
            // Arange
            LineSystem lineSystem = new LineSystem();
            IUser user = Substitute.For<IUser>();
            user.Balance.Returns(userMoney);
            
            IProduct product = Substitute.For<IProduct>();
            product.Price.Returns(productPrice);
            product.IsActive.Returns(true);

            // Act and Assert
            Assert.DoesNotThrow((() => lineSystem.BuyProduct(user, product))) ;
        }
        
        [TestCase(10, 11)]
        [TestCase(0, 10)]
        public void BuyProduct_UserBuysProductWithoutEnoughMoney_PurchaseThrows(decimal userMoney, decimal productPrice)
        {
            // Arange
            LineSystem lineSystem = new LineSystem();
            IUser user = Substitute.For<IUser>();
            user.Balance.Returns(userMoney);
            
            IProduct product = Substitute.For<IProduct>();
            product.Price.Returns(productPrice);
            product.IsActive.Returns(true);

            // Act and Assert
            Assert.Throws<InsufficientCreditsException>(() => lineSystem.BuyProduct(user, product)) ;
        }
    }
}