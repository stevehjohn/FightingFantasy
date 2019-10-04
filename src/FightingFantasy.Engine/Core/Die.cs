using System;

namespace FightingFantasy.Engine.Core
{
    public class Die : IDie
    {
        private readonly Random _random;

        public Die()
        {
            _random = new Random();
        }

        public int Roll()
        {
            return _random.Next(6) + 1;
        }
    }
}