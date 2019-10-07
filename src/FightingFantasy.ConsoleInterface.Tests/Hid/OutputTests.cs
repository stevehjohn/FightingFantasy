using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
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

            _console.SetupGet(c => c.WindowWidth)
                    .Returns(80);

            _output = new Output(_console.Object, _sleeper.Object);
        }

        [Test]
        public void Write_hides_the_cursor()
        {
            _output.Write("This is plain text.");

            _console.VerifySet(c => c.CursorVisible = false);
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
            var output = new StringBuilder();

            _console.Setup(c => c.Write(It.IsAny<char>()))
                    .Callback<char>(c => output.Append(c));

            _output.Write("This is <b>bold</b> text.");

            Assert.That(output.ToString(), Is.EqualTo("This is bold text."));

            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Bold, Times.Once);
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal, Times.Exactly(2));
        }

        [Test]
        public void Write_parses_text_for_italic()
        {
            var output = new StringBuilder();

            _console.Setup(c => c.Write(It.IsAny<char>()))
                    .Callback<char>(c => output.Append(c));

            _output.Write("This is <i>italic</i> text.");

            Assert.That(output.ToString(), Is.EqualTo("This is italic text."));

            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Italic, Times.Once);
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal, Times.Exactly(2));
        }

        [Test]
        public void Write_parses_text_for_underline()
        {
            var output = new StringBuilder();

            _console.Setup(c => c.Write(It.IsAny<char>()))
                    .Callback<char>(c => output.Append(c));

            _output.Write("This is <u>underlined</u> text.");

            Assert.That(output.ToString(), Is.EqualTo("This is underlined text."));
            
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Underline, Times.Once);
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal, Times.Exactly(2));
        }

        [Test]
        public void Write_parses_text_for_caps()
        {
            var output = new StringBuilder();

            _console.Setup(c => c.Write(It.IsAny<char>()))
                    .Callback<char>(c => output.Append(c));

            _output.Write("This is <c>caps</c> text.");

            Assert.That(output.ToString(), Is.EqualTo("This is caps text."));

            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Caps, Times.Once);
            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal, Times.Exactly(2));
        }

        [Test]
        public void Write_uses_default_if_unknown_tag()
        {
            var output = new StringBuilder();

            _console.Setup(c => c.Write(It.IsAny<char>()))
                    .Callback<char>(c => output.Append(c));

            _output.Write("This is <badger>badger</badger> text.");

            Assert.That(output.ToString(), Is.EqualTo("This is badger text."));

            _console.VerifySet(c => c.ForegroundColour = AppSettings.Instance.ColourScheme.Normal, Times.Exactly(3));
        }

        [Test]
        public void Write_processes_br_element_and_trims_leading_spaces()
        {
            var output = new StringBuilder();

            _console.Setup(c => c.Write(It.IsAny<char>()))
                    .Callback<char>(c => output.Append(c));

            _console.Setup(c => c.Write(It.IsAny<string>()))
                    .Callback<string>(s => output.Append(s));

            _output.Write("This is one line.<br> This is the next.");

            Assert.That(output.ToString(), Is.EqualTo("This is one line.\n\nThis is the next."));
        }

        [Test]
        public void Write_inserts_newline_if_word_will_wrap()
        {
            var output = new StringBuilder();

            _console.Setup(c => c.Write(It.IsAny<char>()))
                    .Callback<char>(c => output.Append(c));

            _console.SetupGet(c => c.CursorLeft)
                    .Returns(() => output.ToString().Split('\n').Last().Length);

            _console.SetupGet(c => c.WindowWidth)
                    .Returns(25);

            _output.Write("This is one line. |-------------| That should wrap.");

            Assert.That(output.ToString(), Is.EqualTo("This is one line. \n|-------------| That \nshould wrap."));
        }

        [Test]
        public void Clear_calls_underlying_console_Clear()
        {
            _output.Clear();

            _console.Verify(c => c.Clear());
        }
    }
}