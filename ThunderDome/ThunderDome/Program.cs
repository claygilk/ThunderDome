using System;

namespace ThunderDome
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates four different fighters to choose from. adds them to roster array
            // new comment to test git ignore
            StatBlock boblin = new GoblinBlock("Boblin");
            StatBlock gobo = new GoblinBlock("Gobo");

            // monsterBlock braun = new bugbearBlock("Braun");
            StatBlock bobbert = new HobgoblinBlock("Bobbert");
            StatBlock bork = new OrcBlock("Bork");
            StatBlock[] roster = { boblin, gobo, bobbert, bork };

            // gets user input to pick contestants
            Console.WriteLine("Who do you want to enter the ThunderDome? Choose one of the following:");
            Console.WriteLine($"1:{roster[0].CreatureName} 2: {roster[1].CreatureName} 3: {roster[2].CreatureName} 4:{roster[3].CreatureName}");

            int firstpickButton = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Your first pick is " + roster[firstpickButton].CreatureName);

            Console.WriteLine("Who is your second pick?");
            int secondpickButton = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Your second pick is " + roster[secondpickButton].CreatureName);

            Console.WriteLine("And how many times do you want them to fight?");
            int pickNumOfMatches = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Do you want to watch the ThunderDome? y/n");
            string wantToWatchString = Console.ReadLine();
            bool wantToWatch;
            if (wantToWatchString == "y" || wantToWatchString == "Y")
            {
                wantToWatch = true;
            }
            else
            {
                wantToWatch = false;
            }

            // Put both fighters into the ThunderDome
            // Thunderdome(fighter1, fighter2, printWinnerToFile, playInConsole, numOfMatches)
            StatBlock.ThunderDome(roster[firstpickButton], roster[secondpickButton], true, wantToWatch, pickNumOfMatches);

        }
    }
}

