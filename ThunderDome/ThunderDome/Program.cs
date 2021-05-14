using System;

namespace ThunderDome
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates four different fighters to choose from. adds them to roster array

            monsterBlock boblin = new goblinBlock("Boblin");
            monsterBlock gobo = new goblinBlock("Gobo");
            //monsterBlock braun = new bugbearBlock("Braun");
            monsterBlock bobbert = new hobgoblinBlock("Bobbert");
            monsterBlock bork = new orcBlock("Bork");
            monsterBlock[] roster = { boblin, gobo, bobbert, bork };

            //gets user input to pick contestants
            Console.WriteLine("Who do you want to enter the ThunderDome? Choose one of the following:");
            Console.WriteLine($"1:{roster[0].name} 2: {roster[1].name} 3: {roster[2].name} 4:{roster[3].name}");

            int firstpickButton = (Convert.ToInt32(Console.ReadLine()) - 1);
            Console.WriteLine("Your first pick is " + roster[firstpickButton].name);

            Console.WriteLine("Who is your second pick?");
            int secondpickButton = (Convert.ToInt32(Console.ReadLine()) - 1);
            Console.WriteLine("Your second pick is " + roster[secondpickButton].name);

            Console.WriteLine("And how many times do you want them to fight?");
            int pickNumOfMatches = (Convert.ToInt32(Console.ReadLine()));

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

            //Put both fighters into the ThunderDome
            //Thunderdome(fighter1, fighter2, printWinnerToFile, playInConsole, numOfMatches)
            monsterBlock.ThunderDome(roster[firstpickButton], roster[secondpickButton], true, wantToWatch, pickNumOfMatches);

        }
    }
}








