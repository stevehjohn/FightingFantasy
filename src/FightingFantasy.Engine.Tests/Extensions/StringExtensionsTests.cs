using System;
using FightingFantasy.Engine.Extensions;
using NUnit.Framework;

namespace FightingFantasy.Engine.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [TestCase("Your luck has decreased by {0} point{s}.", -2, "Your luck has decreased by 2 points.")]
        [TestCase("Your luck has decreased by {0} point{s}.", -1, "Your luck has decreased by 1 point.")]
        [TestCase("Your luck has changed by {0} point{s}.", 0, "Your luck has changed by 0 points.")]
        [TestCase("Your luck has increased by {0} point{s}.", 1, "Your luck has increased by 1 point.")]
        [TestCase("Your luck has increased by {0} point{s}.", 2, "Your luck has increased by 2 points.")]
        public void Pluralise_produces_correct_output(string text, int value, string expected)
        {
            Assert.That(text.Replace("{0}", Math.Abs(value).ToString()).Pluralise(value), Is.EqualTo(expected));
        }
    }
}