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
            _input.Setup(i => i.ReadLine())
                  .Returns("Exit");

            _consoleUi.Run();

            _output.Verify(o => o.Write("\nWelcome to Stevö John's <b>Fighting Fantasy</b> Game Engine!\n\n"));
            _output.Verify(o => o.Write("Type <b>help</b> at any time for a list of commands.\n\n"));
        }

        [Test]
        public void Run_prompts_user_to_enter_an_instruction()
        {
            _input.SetupSequence(i => i.ReadLine())
                  .Returns(" ")
                  .Returns("Exit");

            _consoleUi.Run();

            _output.Verify(o => o.Write("\nPlease enter an instruction.\n\n"));
        }

        [Test]
        public void Run_responds_appropriately_when_command_not_understood()
        {
            _input.SetupSequence(i => i.ReadLine())
                  .Returns("Bugger off!")
                  .Returns("Exit");

            _consoleUi.Run();

            _output.Verify(o => o.Write("\nI'm sorry, I don't know how to <b>bugger off!</b>.\n\n"));
        }

        [Test]
        public void Run_shows_help_text()
        {
            _input.SetupSequence(i => i.ReadLine())
                  .Returns("Help")
                  .Returns("Exit");

            _consoleUi.Run();

            _output.Verify(o => o.Write(It.Is<string>(s => s.StartsWith("\nThe following commands"))));
        }
    }
}