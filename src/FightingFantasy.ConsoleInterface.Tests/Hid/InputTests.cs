using FightingFantasy.ConsoleInterface.Hid;
using FightingFantasy.ConsoleInterface.Infrastructure;
using Moq;
using NUnit.Framework;

namespace FightingFantasy.ConsoleInterface.Tests.Hid
{
    [TestFixture]
    public class InputTests
    {
        private Mock<IConsole> _console;

        private IInput _input;

        [SetUp]
        public void SetUp()
        {
            _console = new Mock<IConsole>();

            _input = new Input(_console.Object);
        }

        [Test]
        public void ReadLine_shows_the_cursor()
        {
            _input.ReadLine();

            _console.VerifySet(c => c.CursorVisible = true);
        }

        [Test]
        public void ReadLine_outputs_a_prompt()
        {
            _input.ReadLine();

            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Prompt);
            _console.Verify(c => c.Write("> "));
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Prompt);
        }

        [Test]
        public void ReadLine_returns_user_entry()
        {
            const string text = "This is some user input";

            _console.Setup(c => c.ReadLine())
                    .Returns(text);

            var result = _input.ReadLine();

            Assert.That(result, Is.EqualTo(text));
        }
    }
}