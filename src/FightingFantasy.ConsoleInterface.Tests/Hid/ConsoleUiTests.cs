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

        [Test]
        public void Run_can_clear_the_screen()
        {
            _input.SetupSequence(i => i.ReadLine())
                  .Returns("Clear")
                  .Returns("Exit");

            _consoleUi.Run();

            _output.Verify(o => o.Clear());
        }

        [Test]
        public void ListGames_enumerates_game_files()
        {
            _input.SetupSequence(i => i.ReadLine())
                  .Returns("New")
                  .Returns("Exit");

            _consoleUi.Run();

            _output.Verify(o => o.Write("  <b>1</b> - <u>Demons of the Deep</u>.\n"));
            _output.Verify(o => o.Write("  <b>2</b> - <u>Robot Commando</u>.\n"));
        }

        [TestCase(0, false, null)]
        [TestCase(1, true, "Demons of the Deep")]
        [TestCase(2, true, "Robot Commando")]
        [TestCase(3, false, null)]
        public void StartGame_checks_for_valid_index(int index, bool isValid, string title)
        {
            _input.SetupSequence(i => i.ReadLine())
                  .Returns("New")
                  .Returns(index.ToString())
                  .Returns("Exit");

            _consoleUi.Run();

            if (isValid)
            {
                _output.Verify(o => o.Write($"<u>{title}</u>\n\n"));
            }
            else
            {
                _output.Verify(o => o.Write("\nNot a valid game id. Type <b>New</b> again to see a list of games available.\n\n"));
            }
        }
    }
}