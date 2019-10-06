using FightingFantasy.ConsoleInterface.Hid;
using Moq;
using NUnit.Framework;

namespace FightingFantasy.ConsoleInterface.Tests.Hid
{
    [TestFixture]
    public class ConsoleUiTests
    {
        private Mock<IOutput> _output;

        private ConsoleUi _consoleUi;

        [SetUp]
        public void SetUp()
        {
            _output = new Mock<IOutput>();

            _consoleUi = new ConsoleUi(_output.Object);
        }

        [Test]
        public void Run_greets_the_user_appropriately()
        {
            _consoleUi.Run();

            _output.Verify(o => o.Write("Welcome to Stevö John's Fighting Fantasy Game Engine!\n\n"));
            _output.Verify(o => o.Write("Type help at any time for commands.\n\n"));
        }
    }
}