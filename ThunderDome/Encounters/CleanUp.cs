using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace TestScript
{
    /// <summary>
    /// This Class is used to modify and add functionality to the deserialized RootStatBlock
    /// </summary>
    static class CleanUp
    {
        /// <summary>
        /// This Method takes attack description from the RootStatBlock
        /// and translates it into readable English.
        /// Then assigns it to the description property of the new Attack class
        /// </summary>
        /// <param name="raw">The string from the 'entries' property of the Action class.</param>
        /// <returns>A string of readable English.</returns>
        static public string CleanAttackDescription(string raw)
        {

            // 1. Remove uncessary characters from JSON string: @, {, }.
            raw = raw.Replace("@", "");
            raw = raw.Replace("{", "");
            raw = raw.Replace("}", "");

            // 2. Initialize regular expressions to which substrings need to be changed

            // These first three all match different types of ranged or melee attacks
            Regex melee = new Regex(@"atk\smw\shit\s$"); //11 char long
            Regex ranged = new Regex(@"atk\srw\shit\s$"); // 11 char long
            Regex meleeOrRanged = new Regex(@"atk\smw,rw\shit\s$"); //14 char long

            // These two patch the part which becomes "Hit: ##"
            Regex doubleDigitDMG = new Regex(@"h\d\d");
            Regex singleDigitDMG = new Regex(@"h\d");

            // takes a character window of length 11 and scans the raw string for matchs
            // matches are replaced with "Melee/Ranged Weapon Attack" wording
            for (int i = 0; i < raw.Length - 11; i++)
            {
                string view = raw.Substring(i, 11);
                if (melee.IsMatch(view))
                {
                    raw = raw.Replace(view, "Melee Weapon Attack: +");
                }
                if (ranged.IsMatch(view))
                {
                    raw = raw.Replace(view, "Ranged Weapon Attack: +");
                }
            }

            // Same as the loop above but larger character window 
            // This loop is used when an attack can either be ranged or melee
            for (int i = 0; i < raw.Length - 14; i++)
            {
                string view = raw.Substring(i, 14);
                if (meleeOrRanged.IsMatch(view))
                {
                    raw = raw.Replace(view, "Melee or Ranged Weapon Attack: +");
                }
            }

            // This loop uses a character window of size 3 to write 'Hit: ' when the average damage is in the double digits
            for (int i = 0; i < raw.Length - 3; i++)
            {
                string view = raw.Substring(i, 3);
                if (doubleDigitDMG.IsMatch(view))
                {
                    raw = raw.Insert(i + 1, "Hit: ");
                    raw = raw.Remove(i, 1);
                }
            }

            // Same as the loop above, but for when the average damage is in the single digits.
            for (int i = 0; i < raw.Length - 2; i++)
            {
                string view = raw.Substring(i, 2);
                if (singleDigitDMG.IsMatch(view))
                {
                    raw = raw.Insert(i + 1, "Hit: ");
                    raw = raw.Remove(i, 1);
                }
            }
            return raw;
        }

        /// <summary>
        /// This Method converts the raw Action class to a new (usable) Attack class
        /// </summary>
        /// <param name="creature"> The RootStatBlock of the creature being CleanedUp.</param>
        static public void SetAttack(RootStatBlock creature)
        {
            //Iterate over every action the creature has
            for (int i = 0; i < creature.action.Count; i++)
            {
                // Instantiate new Attack object whose values will be initialized throughout this loop
                Attack outputAttack = new Attack();

                // Initialize Attack name and description
                outputAttack.attackName = creature.action[i].name;
                outputAttack.description = CleanAttackDescription(creature.action[i].entries[0]);

                //This Regex splits the action description into only the parts in curly brackets
                string raw = creature.action[i].entries[0];
                string[] curlies = Regex.Split(raw, @"{([^}]*)}");

                // This loop then iterates thru each set of curly brackets to assign the proper values to the new Attack object
                foreach (string item in curlies)
                {
                    if (item.Contains("hit") && item[0] == '@')
                    {
                        // item = "{@hit 4}"

                        string[] hitAndMod = item.Split(" ");
                        // hitAndMod = ["@hit", "4"]

                        outputAttack.attackModifier = Convert.ToInt32(hitAndMod[1]);
                        // converts to int and assigns to Attack object
                    }
                    if (item.Contains("damage") && item[0] == '@')
                    {
                        string damageFormula = item.Substring(item.IndexOf(" "));
                        // damageFormula = " 2d8 + 3" // Removes "@damage" from beginning of string

                        damageFormula = damageFormula.TrimStart();
                        // damageFormula = "2d8 + 3" // removes white space from beginning of string

                        string[] diceAndMod = damageFormula.Split(" + ");
                        // diceAndMod = ["2d8","3"] // splits formula into Array of length 2

                        string dmgMod = diceAndMod[1];
                        //dmgMod = "3"

                        string[] numAndSize = diceAndMod[0].Split("d");
                        // numAndSize ["2", "8"]

                        string numDice = numAndSize[0];
                        // numDice = "2"

                        string sizeDice = numAndSize[1];
                        // sizeDice = "8"

                        outputAttack.numberOfDice = Convert.ToInt32(numDice);
                        outputAttack.diceSize = Convert.ToInt32(sizeDice);
                        outputAttack.damageModifier = Convert.ToInt32(dmgMod);
                    }
                }
                // The new attack is then added to the list of attacks
                creature.CleanActions.Add(outputAttack);
            }

        }
    }
}
