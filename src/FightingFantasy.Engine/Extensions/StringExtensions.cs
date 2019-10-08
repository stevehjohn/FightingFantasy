using System;

namespace FightingFantasy.Engine.Extensions
{
    public static class StringExtensions
    {
        public static string Pluralise(this string text, int value)
        {
            return Math.Abs(value) == 1
                       ? text.Replace("{s}", string.Empty)
                       : text.Replace("{s}", "s");
        }
    }
}