using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using ThunderDome;
using System.Text.RegularExpressions;
using Encounters;

namespace TestScript
{
    class Program
    {
        static void Main(string[] args)
        {

            // This block creates a list of StatBlock objects from the list of JSON files in /Bestiary
            string [] folderBestiary = Directory.GetFiles("../../../Bestiary");

            List<RootStatBlock> bestiary = new List<RootStatBlock>();
            foreach(string filePath in folderBestiary)
            {
                string jsonString = File.ReadAllText(filePath);
                RootStatBlock newCreature = JsonConvert.DeserializeObject<RootStatBlock>(jsonString);
                bestiary.Add(newCreature);
            }

            foreach(RootStatBlock creature in bestiary)
            {
                CleanUp.SetAttack(creature);
            }

            // This block allows the player to select combatants

            Console.WriteLine("WELCOME TO THE THUNDERDOME!");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("Choose two combatants to enter the ThunderDome!");


            for (int i = 0; i < bestiary.Count; i++) 
            {
                Console.WriteLine($"{i+1}: {bestiary[i].Name}");
            }

            int firstChoice = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();
            Sheet.Character(bestiary[firstChoice]);
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Make your second choice.");
            for (int i = 0; i < bestiary.Count; i++)
            {
                if(i != firstChoice)
                {
                Console.WriteLine($"{i+1}: {bestiary[i].Name}");
                }
                else
                {
                    Console.WriteLine($"{i+1}: ");
                }
            }
            int secondChoice = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.Clear();
            Sheet.Character(bestiary[secondChoice]);
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Do you wish to watch the fight? y/n");
            string choice = Console.ReadLine().ToLower();

            bool watchFight;

            if (choice == "y")
            {
                watchFight = true;
            }
            else
            {
                watchFight = false;
            }

            Console.Clear();
            Console.WriteLine("And lastly, how many times do you wish for them to fight?");
            string matchInput = Console.ReadLine();
            int matches = 0;

            try
            {
                matches = Convert.ToInt32(matchInput);
            }
            catch
            {
                Console.WriteLine("Please Enter a number");
                do
                {
                    Console.Clear();
                    Console.WriteLine("How many times do you wish for them to fight?");
                    matchInput = Console.ReadLine();
                }
                while (!Int32.TryParse(matchInput, out matches));
            }



            //Saftey net to prevent player from writing too many fights to the console

            if(matches > 10)
            {
                watchFight = false;
            }

            // This block creates and runs an encounter
            Console.Clear();
            Encounter oneLeaves = new Encounter();
            oneLeaves.ThunderDome(bestiary[firstChoice], bestiary[secondChoice], true, watchFight, matches);
        }
    }
}

