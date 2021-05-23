using System;
using System.Collections.Generic;
using System.Text;
using TestScript;
using ThunderDome;

namespace Encounters
{
    /// <summary>
    /// This Class if for displaying information about a given creature
    /// </summary>
    public class Sheet
    {
        /// <summary>
        /// This Method writes the characters statblock or character sheet to the console.
        /// </summary>
        /// <param name="creature">The name of the creature whose stats you wish to view.</param>
        public static void Character(RootStatBlock creature)
        {
            Console.WriteLine($"\n##### {creature.nickName} The {creature.Name} #####");
            Console.WriteLine("Max HP: " + creature.hp.average);
            Console.WriteLine("Current HP: " + creature.CurrentHealth + "\n");

            Console.WriteLine("AC: " + creature.ac[0].ac + "\n");

            Console.WriteLine($"Strength:  {creature.str}({creature.strMod})");
            Console.WriteLine($"Dexterity:  {creature.dex}({creature.dexMod})");
            Console.WriteLine($"Constitution:  {creature.con}({creature.conMod})");
            Console.WriteLine($"Intelligence:  {creature.@int}({creature.intMod})");
            Console.WriteLine($"Wisdom:  {creature.wis}({creature.wisMod})");
            Console.WriteLine($"Charisma:  {creature.cha}({creature.chaMod})\n");

            foreach (Attack tidyAttack in creature.CleanActions)
            {
                Console.WriteLine($"Action: {tidyAttack.attackName}. {tidyAttack.description}\n");
            }
        }
    }
}
