using System.Collections.Generic;
using System.Linq;
using FightingFantasy.Engine.Core;
using NUnit.Framework;

namespace FightingFantasy.Engine.Tests.Core
{
    [TestFixture]
    public class DieTests
    {
        private IDie _die;

        [SetUp]
        public void SetUp()
        {
            _die = new Die();
        }

        [Test]
        public void Die_throws_between_one_and_six()
        {
            var rolls = new List<int>();

            for (var i = 0; i < 100; i++)
            {
                var result = _die.Roll();

                Assert.That(result, Is.InRange(1, 6));

                rolls.Add(result);
            }

            Assert.True(rolls.Any(r => r == 1));
            Assert.True(rolls.Any(r => r == 2));
            Assert.True(rolls.Any(r => r == 3));
            Assert.True(rolls.Any(r => r == 4));
            Assert.True(rolls.Any(r => r == 5));
            Assert.True(rolls.Any(r => r == 6));
        }
    }
}