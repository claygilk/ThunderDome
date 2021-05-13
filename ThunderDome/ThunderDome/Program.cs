using System;

namespace ThunderDome
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates four different fighters to choose from.

            monsterBlock boblin = new goblinBlock("Boblin");
            monsterBlock braun = new bugbearBlock("Braun");
            monsterBlock bobbert = new hobgoblinBlock("Bobbert");
            monsterBlock bork = new orcBlock("Bork");

            monsterBlock[] roster = { boblin, braun, bobbert, bork };
            monsterBlock[] secondRound = new monsterBlock[4];


            Console.WriteLine("Who do you want to enter the ThunderDome? Choose one of the following:");
            Console.WriteLine($"1:{roster[0].name} 2: {roster[1].name} 3: {roster[2].name} 4:{roster[3].name}");
            
            int firstpickButton = (Convert.ToInt32(Console.ReadLine()) -1);
            Console.WriteLine("Your first pick is " + roster[firstpickButton].name);

            Console.WriteLine("Who is your second pick?");
            int secondpickButton = (Convert.ToInt32(Console.ReadLine()) - 1);
            Console.WriteLine("Your second pick is " + roster[secondpickButton].name);

            //Put both fighters into the ThunderDome
            monsterBlock.ThunderDome(roster[firstpickButton], roster[secondpickButton]);

        }
    }
}








