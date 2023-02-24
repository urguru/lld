using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder
{
    internal class Dice
    {
        private readonly Random randomNumberGenerator = new Random();

        public Dice(int value) 
        {
            Value = value;
        }

        public int RollDice()
        {
            var randomNumber = randomNumberGenerator.Next(1, Value);
            return randomNumber;
        }

        public int Value { get; private set; }
    }
}
