namespace ThunderDome
{
    using System;

    /// <summary>
    ///  This is the parent class to all Monster, NPC and PC stat blocks.
    /// </summary>
    public class StatBlock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatBlock"/> class.
        /// </summary>
        /// <param name="inName"> Name of Creature for StatBlock.</param>
        public StatBlock(string inName)
        {
            this.CreatureName = inName;
            this.Race = "Creature";
            this.MaxHealth = 10;
            this.CurrentHealth = 10;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatBlock"/> class.
        /// I forget why this empty constructor is necessary, but if it's removed the project doesn't build.
        /// </summary>
        public StatBlock()
        {
        }

        /// <summary>
        ///  Gets or Sets Race Property.
        /// </summary>
        public string Race { get; set; }

        /// <summary>
        ///  Gets or Sets Current HP Property.
        /// </summary>
        public int CurrentHealth { get; set; }

        /// <summary>
        ///  Gets or Sets Armor Class Property.
        /// </summary>
        public int ArmorClass { get; set; }

        /// <summary>
        ///  Gets or Sets Attack Modifier Property.
        /// </summary>
        public int AttackModifier { get; set; }

        /// <summary>
        ///  Gets or Sets Damage Modifier Property.
        /// </summary>
        public int DamageModifier { get; set; }

        /// <summary>
        ///  Gets or Sets Creature Name Property.
        /// </summary>
        public string CreatureName { get; set; }

        /// <summary>
        ///  Gets or Sets a value indicating whether creature is dead.
        /// </summary>
        public bool IsDead { get; set; }

        /// <summary>
        ///  Gets or Sets Maximum HP Property.
        /// </summary>
        public int MaxHealth { get; set; }

        /// <summary>
        /// Prints Health bar.
        /// </summary>
        /// <param name="monster"> the monster whose health you wish to display. </param>
        /// <returns>  the string of the health bar.</returns>
        public static string HealthBar(StatBlock monster)
        {
            return $"HP: [{monster.CurrentHealth}/{monster.MaxHealth}]";
        }

        /// <summary>
        /// make attack roll.
        /// </summary>
        /// <param name="attacker"> the creature making the attack. </param>
        /// <param name="target"> the creature being targeted. </param>
        /// <param name="attackInConsole"> bool to determine if results should be printed to console. </param>
        /// <returns>  the string of the health bar.</returns>
        public static int Attack(StatBlock attacker, StatBlock target, bool attackInConsole)
        {
            // Attack fails if either attacker or target is dead
            if (target.IsDead == true)
            {
                if (attackInConsole)
                {
                    Console.WriteLine($"{target.CreatureName} is already dead!");
                }

                return 0;
            }
            else if (attacker.IsDead == true)
            {
                if (attackInConsole)
                {
                    Console.WriteLine($"{attacker.CreatureName} is already dead!");
                }

                return 0;
            }
            else
            {
                Random roll = new Random();
                int attackRoll = roll.Next(1, 20);
                int toHit = attackRoll + attacker.AttackModifier;

                // on a hit, calls takeDamage() method, to deal damage to the target
                if (toHit >= target.ArmorClass)
                {
                    int damageRoll = roll.Next(1, 6);
                    int damageDelt = damageRoll + attacker.DamageModifier;
                    TakeDamage(damageDelt, target);

                    if (attackInConsole)
                    {
                        Console.WriteLine($"{attacker.CreatureName} hit {target.CreatureName} for {damageDelt} points of damage!\n");
                    }
                }
                else
                {
                    if (attackInConsole)
                    {
                        Console.WriteLine($"{attacker.CreatureName} missed on {target.CreatureName}!\n");
                    }
                }

                return toHit;
            }
        }

        /// <summary>
        /// Inflicts damage on target if attack hits. And sets them to dead if they get dropped to 0.
        /// </summary>
        /// <param name="damage"> the value of the damage dealt. </param>
        /// <param name="target"> the statblock of the target. </param>
        public static void TakeDamage(int damage, StatBlock target)
        {
            target.CurrentHealth -= damage;
            if (target.CurrentHealth <= 0)
            {
                target.IsDead = true;
                target.CurrentHealth = 0;
            }
        }

        /// <summary>
        /// Restores creature to makes health and makes them alive again.
        /// </summary>
        /// <param name="target">Creature to be rezd.</param>
        public static void Revivify(StatBlock target)
        {
            target.CurrentHealth = target.MaxHealth;
            target.IsDead = false;
        }

        /// <summary>
        /// Runs a 1 v 1 encounter.
        /// </summary>
        /// <param name="fighter1"> first creature.</param>
        /// <param name="fighter2">second creature. </param>
        /// <param name="printWinnerToFile">logs result of fight.</param>
        /// <param name="playInConsole">displays each round in console.</param>
        /// <param name="numOfMatches">number of fights to run.</param>
        public static void ThunderDome(StatBlock fighter1, StatBlock fighter2, bool printWinnerToFile, bool playInConsole, int numOfMatches)
        {
            for (int i = 1; i <= numOfMatches; i++)
            {
                // rez the loser from the last match and heal the winner to full
                Revivify(fighter1);
                Revivify(fighter2);

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
                            Console.WriteLine($"{fighter2.CreatureName} WINS!!");
                        }

                        if (printWinnerToFile)
                        {
                            WriteLog.LogResult(fighter2.CreatureName, fighter1.CreatureName);
                        }

                        break;
                    }
                    else if (fighter2.IsDead == true)
                    {
                        // prints winner to console and logs
                        if (playInConsole)
                        {
                            Console.WriteLine($" ____________________ Round: {roundNum} ____________________ ");
                            Console.WriteLine($"{fighter1.CreatureName} WINS!!");
                        }

                        if (printWinnerToFile)
                        {
                            WriteLog.LogResult(fighter1.CreatureName, fighter2.CreatureName);
                        }

                        break;
                    }
                    else
                    {
                        // executes round of combat and writes to console
                        if (playInConsole)
                        {
                            Console.WriteLine($" ____________________ Round: {roundNum} ____________________ ");
                            Console.WriteLine($"{fighter1.CreatureName} {HealthBar(fighter1)}               {fighter2.CreatureName} {HealthBar(fighter2)}");
                        }

                        StatBlock.Attack(fighter2, fighter1, playInConsole);
                        StatBlock.Attack(fighter1, fighter2, playInConsole);
                        roundNum += 1;
                    }
                }
                while (fighter1.IsDead == false || fighter2.IsDead == false);
            }
        }
    }
}
