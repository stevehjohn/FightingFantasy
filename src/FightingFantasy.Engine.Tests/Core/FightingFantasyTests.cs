using FightingFantasy.Engine.Core;
using Moq;
using NUnit.Framework;

namespace FightingFantasy.Engine.Tests.Core
{
    [TestFixture]
    public class FightingFantasyTests
    {
        private Mock<IDie> _die;

        private Engine.Core.FightingFantasy _engine;

        [SetUp]
        public void SetUp()
        {
            _die = new Mock<IDie>();

            _engine = new Engine.Core.FightingFantasy(_die.Object);
        }

        [Test]
        public void LoadGame_creates_new_protagonist_with_initialised_attributes_if_not_a_saved_game()
        {
            _die.SetupSequence(d => d.Roll())
                .Returns(3)
                .Returns(4)
                .Returns(1)
                .Returns(6);

            _engine.LoadGame("TestFiles\\GameState.json");

            Assert.That(_engine.GameState.Protagonist.Skill.Value, Is.EqualTo(9));
            Assert.That(_engine.GameState.Protagonist.Stamina.Value, Is.EqualTo(17));
            Assert.That(_engine.GameState.Protagonist.Luck.Value, Is.EqualTo(12));
        }
    }
}