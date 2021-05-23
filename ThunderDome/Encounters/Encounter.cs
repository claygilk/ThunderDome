namespace ThunderDome
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TestScript;

    /// <summary>
    /// Then generic encounter class.
    /// </summary>
    public class Encounter
    {
        /// <summary>
        /// Runs a 1 v 1 encounter.
        /// </summary>
        /// <param name="fighter1"> first creature.</param>
        /// <param name="fighter2">second creature. </param>
        /// <param name="printWinnerToFile">logs result of fight.</param>
        /// <param name="playInConsole">displays each round in console.</param>
        /// <param name="numOfMatches">number of fights to run.</param>
        public void ThunderDome(RootStatBlock fighter1, RootStatBlock fighter2, bool printWinnerToFile, bool playInConsole, int numOfMatches)
        {
            for (int i = 1; i <= numOfMatches; i++)
            {
                // determine initiative 
                int fighter1Int = Dice.Roll(1, 20) + fighter1.dexMod;
                int fighter2Int = Dice.Roll(1, 20) + fighter2.dexMod;

                if (playInConsole)
                {
                    Console.WriteLine($"The {fighter1.Name} rolled a {fighter1Int} for Initiative.");
                    Console.WriteLine($"The {fighter2.Name} rolled a {fighter2Int} for Initiative.\n");
                }

                // rez the loser from the last match and heal the winner to full
                fighter1.Revivify();
                fighter2.Revivify();

                int roundNum = 1;

                // do-while loop to repeat each combat round
                do
                {
                    if (fighter1.IsDead == true)
                    {
                        // prints winner to console and logs
                        if (playInConsole)
                        {
                            Console.WriteLine($"____________________ Round: {roundNum} ____________________");
                            Console.WriteLine($"{fighter2.Name} WINS!!");
                        }

                        if (printWinnerToFile)
                        {
                            WriteLog.LogResult(fighter2.Name, fighter1.Name);
                        }

                        break;
                    }
                    else if (fighter2.IsDead == true)
                    {
                        // prints winner to console and logs
                        if (playInConsole)
                        {
                            Console.WriteLine($" ____________________ Round: {roundNum} ____________________ ");
                            Console.WriteLine($"{fighter1.Name} WINS!!");

                        }

                        if (printWinnerToFile)
                        {
                            WriteLog.LogResult(fighter1.Name, fighter2.Name);
                        }

                        break;
                    }
                    else
                    {
                        // executes round of combat and writes to console
                        if (playInConsole)
                        {
                            Console.WriteLine($" ____________________ Round: {roundNum} ____________________ ");
                            Console.WriteLine($"{fighter1.Name} {fighter1.HealthBar()}               {fighter2.Name} {fighter2.HealthBar()}\n");

                        }

                        if (fighter1Int >= fighter2Int)
                        {
                            fighter1.MakeAttack(fighter2, playInConsole);
                            fighter2.MakeAttack(fighter1, playInConsole);
                        }
                        else
                        {
                            fighter2.MakeAttack(fighter1, playInConsole);
                            fighter1.MakeAttack(fighter2, playInConsole);
                        }
                        roundNum += 1;
                    }
                }
                while (fighter1.IsDead == false || fighter2.IsDead == false);
            }
        }
    }
}
