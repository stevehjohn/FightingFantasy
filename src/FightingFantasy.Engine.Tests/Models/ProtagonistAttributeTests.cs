using FightingFantasy.Engine.Models;
using NUnit.Framework;

namespace FightingFantasy.Engine.Tests.Models
{
    [TestFixture]
    public class ProtagonistAttributeTests
    {
        private ProtagonistAttribute _protagonistAttribute;

        [SetUp]
        public void SetUp()
        {
            _protagonistAttribute = new ProtagonistAttribute();
        }

        [Test]
        public void HistoryLength_returns_correct_value()
        {
            _protagonistAttribute.Value = 1;
            _protagonistAttribute.Value = 2;
            _protagonistAttribute.Value = 3;

            Assert.That(_protagonistAttribute.HistoryLength, Is.EqualTo(3));
        }

        [Test]
        public void InitialValue_returns_correct_value()
        {
            _protagonistAttribute.Value = 1;
            _protagonistAttribute.Value = 2;
            _protagonistAttribute.Value = 3;

            Assert.That(_protagonistAttribute.InitialValue, Is.EqualTo(1));
        }

        [Test]
        public void Value_returns_correct_value()
        {
            _protagonistAttribute.Value = 1;
            _protagonistAttribute.Value = 2;
            _protagonistAttribute.Value = 3;

            Assert.That(_protagonistAttribute.Value, Is.EqualTo(3));
        }
    }
}