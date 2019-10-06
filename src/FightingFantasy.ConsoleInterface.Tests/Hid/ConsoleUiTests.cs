using FightingFantasy.ConsoleInterface.Hid;
using Moq;
using NUnit.Framework;

namespace FightingFantasy.ConsoleInterface.Tests.Hid
{
    [TestFixture]
    public class ConsoleUiTests
    {
        private Mock<IOutput> _output;
        private Mock<IInput> _input;

        private ConsoleUi _consoleUi;

        [SetUp]
        public void SetUp()
        {
            _output = new Mock<IOutput>();
            _input = new Mock<IInput>();

            _consoleUi = new ConsoleUi(_output.Object, _input.Object);
        }

        [Test]
        public void Run_greets_the_user_appropriately()
        {
            _consoleUi.Run();

            _output.Verify(o => o.Write("\nWelcome to Stevö John's <b>Fighting Fantasy</b> Game Engine!\n\n"));
            _output.Verify(o => o.Write("Type <b>help</b> at any time for commands.\n\n"));
        }
    }
}