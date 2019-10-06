using FightingFantasy.ConsoleInterface.Hid;
using FightingFantasy.ConsoleInterface.Infrastructure;
using Moq;
using NUnit.Framework;

namespace FightingFantasy.ConsoleInterface.Tests.Hid
{
    [TestFixture]
    public class OutputTests
    {
        private Mock<IConsole> _console;
        private Mock<ISleeper> _sleeper;

        private IOutput _output;

        [SetUp]
        public void SetUp()
        {
            _console = new Mock<IConsole>();
            _sleeper = new Mock<ISleeper>();

            _output = new Output(_console.Object, _sleeper.Object);
        }

        [Test]
        public void Write_sets_default_colour_without_markup()
        {
            _output.Write("This is plain text.");

            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal);
        }

        [Test]
        public void Write_parses_text_for_bold()
        {
            _output.Write("This is <b>bold</b> text.");

            _console.Verify(c => c.Write('T'));
            _console.Verify(c => c.Write('h'));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('s'));
            _console.Verify(c => c.Write(' '));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('s'));
            _console.Verify(c => c.Write(' '));
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Bold);
            _console.Verify(c => c.Write('b'));
            _console.Verify(c => c.Write('o'));
            _console.Verify(c => c.Write('l'));
            _console.Verify(c => c.Write('d'));
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal);
            _console.Verify(c => c.Write(' '));
            _console.Verify(c => c.Write('t'));
            _console.Verify(c => c.Write('e'));
            _console.Verify(c => c.Write('x'));
            _console.Verify(c => c.Write('t'));
            _console.Verify(c => c.Write('.'));
        }

        [Test]
        public void Write_parses_text_for_italic()
        {
            _output.Write("This is <i>italic</i> text.");

            _console.Verify(c => c.Write('T'));
            _console.Verify(c => c.Write('h'));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('s'));
            _console.Verify(c => c.Write(' '));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('s'));
            _console.Verify(c => c.Write(' '));
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Italic);
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('t'));
            _console.Verify(c => c.Write('a'));
            _console.Verify(c => c.Write('l'));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('c'));
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal);
            _console.Verify(c => c.Write(' '));
            _console.Verify(c => c.Write('t'));
            _console.Verify(c => c.Write('e'));
            _console.Verify(c => c.Write('x'));
            _console.Verify(c => c.Write('t'));
            _console.Verify(c => c.Write('.'));
        }

        [Test]
        public void Write_parses_text_for_underline()
        {
            _output.Write("This is <u>underlined</u> text.");

            _console.Verify(c => c.Write('T'));
            _console.Verify(c => c.Write('h'));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('s'));
            _console.Verify(c => c.Write(' '));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('s'));
            _console.Verify(c => c.Write(' '));
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Underline);
            _console.Verify(c => c.Write('u'));
            _console.Verify(c => c.Write('n'));
            _console.Verify(c => c.Write('d'));
            _console.Verify(c => c.Write('e'));
            _console.Verify(c => c.Write('r'));
            _console.Verify(c => c.Write('l'));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('n'));
            _console.Verify(c => c.Write('e'));
            _console.Verify(c => c.Write('d'));
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal);
            _console.Verify(c => c.Write(' '));
            _console.Verify(c => c.Write('t'));
            _console.Verify(c => c.Write('e'));
            _console.Verify(c => c.Write('x'));
            _console.Verify(c => c.Write('t'));
            _console.Verify(c => c.Write('.'));
        }

        [Test]
        public void Write_parses_text_for_caps()
        {
            _output.Write("This is <c>caps</c> text.");

            _console.Verify(c => c.Write('T'));
            _console.Verify(c => c.Write('h'));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('s'));
            _console.Verify(c => c.Write(' '));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('s'));
            _console.Verify(c => c.Write(' '));
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Caps);
            _console.Verify(c => c.Write('c'));
            _console.Verify(c => c.Write('a'));
            _console.Verify(c => c.Write('p'));
            _console.Verify(c => c.Write('s'));
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal);
            _console.Verify(c => c.Write(' '));
            _console.Verify(c => c.Write('t'));
            _console.Verify(c => c.Write('e'));
            _console.Verify(c => c.Write('x'));
            _console.Verify(c => c.Write('t'));
            _console.Verify(c => c.Write('.'));
        }

        [Test]
        public void Write_uses_default_if_unknown_tag()
        {
            _output.Write("This is <badger>badger</badger> text.");

            _console.Verify(c => c.Write('T'));
            _console.Verify(c => c.Write('h'));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('s'));
            _console.Verify(c => c.Write(' '));
            _console.Verify(c => c.Write('i'));
            _console.Verify(c => c.Write('s'));
            _console.Verify(c => c.Write(' '));
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal);
            _console.Verify(c => c.Write('b'));
            _console.Verify(c => c.Write('a'));
            _console.Verify(c => c.Write('d'));
            _console.Verify(c => c.Write('g'));
            _console.Verify(c => c.Write('e'));
            _console.Verify(c => c.Write('r'));
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal);
            _console.Verify(c => c.Write(' '));
            _console.Verify(c => c.Write('t'));
            _console.Verify(c => c.Write('e'));
            _console.Verify(c => c.Write('x'));
            _console.Verify(c => c.Write('t'));
            _console.Verify(c => c.Write('.'));
        }

        [Test]
        public void Clear_calls_underlying_console_Clear()
        {
            _output.Clear();

            _console.Verify(c => c.Clear());
        }
    }
}