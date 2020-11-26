using System;
using Line_system.Users;
using NUnit.Framework;

namespace NunitTests
{
    public class UserTests
    {
        [TestCase("firstName", null)]
        [TestCase(null, "lastName")]
        [TestCase(null, null)]
        public void User_CreateUserWithNullArgumensForName_ThrowNullException(string firstName, string lastName)
        {
            // Arrange, Act and Assert
            Assert.Throws<ArgumentNullException>(() => new User(1, firstName, lastName, "test", 100, "test@test.com"));
        }

        [TestCase("Test@Test.com")]
        [TestCase("test@test.com")]
        [TestCase("te23st@te234st.com")]
        [TestCase("te_st@tes_t.com")]
        [TestCase("te.st@te.st.com")]
        public void User_CreateUserWithValidEmail_DoesNotThrow(string email)
        {
            // Arrange, Act and Assert
            Assert.DoesNotThrow(() => new User(1, "firstName", "lastName", "userName", 1, email));
        }
        
        [TestCase("Test")]
        [TestCase("Test@Test")]
        [TestCase("Test.com")]
        [TestCase("Tes t.c om")]
        [TestCase("Te#st@Te#st.com")]
        public void User_CreateUserWithBadEmail_ThrowsFormatException(string email)
        {
            // Arrange, Act and Assert
            Assert.Throws<FormatException>(() => new User(1, "firstName", "lastName", "userName", 1, email));
        }
    }
}