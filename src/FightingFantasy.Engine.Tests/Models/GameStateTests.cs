using FightingFantasy.Engine.Core;
using FightingFantasy.Engine.Models;
using Moq;
using NUnit.Framework;

namespace FightingFantasy.Engine.Tests.Models
{
    [TestFixture]
    public class GameStateTests
    {
        private GameState _gameState;

        [SetUp]
        public void SetUp()
        {
            var protagonist = new Protagonist(new Die());

            _gameState = new GameState(protagonist);
        }

        [Test]
        public void LoadMap_can_deserialise_map_JSON()
        {
            _gameState.LoadMap(".\\TestFiles\\Map.json");

            Assert.That(_gameState.Map.Count, Is.EqualTo(2));

            var location = _gameState.Map[3];

            Assert.That(location.Id, Is.EqualTo(3));
            Assert.True(location.Description.StartsWith("You swim strongly"));
            Assert.True(location.Description.EndsWith("of the sand."));
            Assert.That(location.VisitCount, Is.EqualTo(0));
            Assert.That(location.Choices.Count, Is.EqualTo(1));
            Assert.That(location.Choices[0].Description, Is.EqualTo("Continue..."));
            Assert.That(location.Choices[0].Id, Is.EqualTo(196));

            location = _gameState.Map[196];

            Assert.That(location.Id, Is.EqualTo(196));
            Assert.True(location.Description.StartsWith("You swim closer"));
            Assert.True(location.Description.EndsWith("will you do?"));
            Assert.That(location.VisitCount, Is.EqualTo(0));
            Assert.That(location.Choices.Count, Is.EqualTo(3));
            Assert.That(location.Choices[0].Description, Is.EqualTo("Run away."));
            Assert.That(location.Choices[0].Id, Is.EqualTo(10));
            Assert.That(location.Choices[1].Description, Is.EqualTo("Listen to the voice."));
            Assert.That(location.Choices[1].Id, Is.EqualTo(321));
            Assert.That(location.Choices[2].Description, Is.EqualTo("Attack."));
            Assert.That(location.Choices[2].Id, Is.EqualTo(26));
        }
    }
}