using FightingFantasy.Engine.Core;
using FightingFantasy.Engine.Models;
using Moq;
using NUnit.Framework;

namespace FightingFantasy.Engine.Tests.Models
{
    [TestFixture]
    public class ProtagonistTests
    {
        private Mock<IDie> _die;

        [SetUp]
        public void SetUp()
        {
            _die = new Mock<IDie>();
        }

        [Test]
        public void Skill_is_initialised_to_correct_value()
        {
            _die.Setup(d => d.Roll())
                .Returns(6);

            var protagonist = new Protagonist(_die.Object);

            Assert.That(protagonist.Skill.Value, Is.EqualTo(12));
        }

        [Test]
        public void Stamina_is_initialised_to_correct_value()
        {
            _die.SetupSequence(d => d.Roll())
                .Returns(0)
                .Returns(6)
                .Returns(1);

            var protagonist = new Protagonist(_die.Object);

            Assert.That(protagonist.Stamina.Value, Is.EqualTo(19));
        }

        [Test]
        public void Luck_is_initialised_to_correct_value()
        {
            _die.SetupSequence(d => d.Roll())
                .Returns(0)
                .Returns(0)
                .Returns(0)
                .Returns(1);

            var protagonist = new Protagonist(_die.Object);

            Assert.That(protagonist.Luck.Value, Is.EqualTo(7));
        }
    }
}