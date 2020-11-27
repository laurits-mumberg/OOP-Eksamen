using System;
using System.Net.NetworkInformation;
using Line_system;
using Line_system.Controller;
using Line_system.Transactions;
using Line_system.UI;
using NSubstitute;
using NUnit.Framework;

namespace NunitTests
{
    public class LineSystemControllerTests
    {
        [TestCase(":DoesNotExist")]
        [TestCase(":")]
        public void ParseCommand_CommandDoesNotExist_ThrowCorrectException(string command)
        {
            // Arrange
            ILineSystem lineSystem = Substitute.For<ILineSystem>();
            ILineSystemUI lineSystemUi = Substitute.For<ILineSystemUI>();
            LineSystemController lineSystemController = new LineSystemController(lineSystem, lineSystemUi);

            // Act
            lineSystemController.ParseCommand(command);

            // Assert
            lineSystemUi.Received().DisplayAdminCommandNotFoundMessage(command);
        }
        
        [TestCase(":q")]
        [TestCase(":quit")]
        public void ParseCommand_CommandDoesExist_CallsCorrectUiMethod(string command)
        {
            // Arrange
            ILineSystem lineSystem = Substitute.For<ILineSystem>();
            ILineSystemUI lineSystemUi = Substitute.For<ILineSystemUI>();
            LineSystemController lineSystemController = new LineSystemController(lineSystem, lineSystemUi);
            
            // Act
            lineSystemController.ParseCommand(command);

            // Assert
            lineSystemUi.Received().Close();
        }
    }
}