using System;
using System.Collections.Generic;
using System.Text;

namespace ThunderDome
{
    public class Dice
    {
        public static int Roll(int numberOfDice, int sizeOfDice)
        {
            Random diceRoller = new Random();
            int thisRoll = diceRoller.Next(1, sizeOfDice+1);
            return thisRoll;
        }

        //public static int AdvRoll(int numberOfDice, int sizeOfDice)
        //{
        //    Dice.Roll(numberOfDice, sizeOfDice);
        //    Dice.Roll(numberOfDice, sizeOfDice);
        //    return higher
        //}

    }
}
