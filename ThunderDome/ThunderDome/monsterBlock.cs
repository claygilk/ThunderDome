using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ThunderDome
{
    class monsterBlock
    {
        //create properties for the class monsterBlock
        public string race;
        public int currentHealth;
        public int armorClass;
        public int attackModifier;
        public int damageModifier;
        public string name;
        public bool isDead;
        private int maxhealth;

        //maxhealth is private because it should not be changed when damage is taken
        public int MaxHealth
        {
            get { return maxhealth; }
            set { maxhealth = value; }
        }


        // monsterBlock constructor
        public monsterBlock(string inName)
        {
            name = inName;
            race = "Creature";
            maxhealth = 10;
            currentHealth = 10;

        }
        public monsterBlock()
        { }


        //Display current health in console
        public static string healthBar(monsterBlock monster)
        {
            return $"HP: [{monster.currentHealth}/{monster.MaxHealth}]";
        }

        //Attack() method is called whenever a monsterBlock makes an attack
        public static int Attack(monsterBlock attacker, monsterBlock target, bool attackInConsole)
        {
            //Attack fails if either attacker or target is dead
            if (target.isDead == true)
            {
                if (attackInConsole)
                {
                    Console.WriteLine($"{target.name} is already dead!");
                }
                return 0;
            }
            else if (attacker.isDead == true)
            {
                if (attackInConsole)
                {
                    Console.WriteLine($"{attacker.name} is already dead!");
                }
                return 0;
            }
            else
            {
                Random roll = new Random();
                int attackRoll = roll.Next(1, 20);
                int toHit = attackRoll + attacker.attackModifier;

                //on a hit, calls takeDamage() method, to deal damage to the target
                if (toHit >= target.armorClass)
                {
                    int damageRoll = roll.Next(1, 6);
                    int damageDelt = damageRoll + attacker.damageModifier;
                    takeDamage(damageDelt, target);

                    if (attackInConsole)
                    {
                        Console.WriteLine($"{attacker.name} hit {target.name} for {damageDelt} points of damage!\n");
                    }
                }
                else
                {
                    if (attackInConsole)
                    {
                        Console.WriteLine($"{attacker.name} missed on {target.name}!\n");
                    }
                }
                return toHit;
            }

        }
        //method takeDamage() reduces the target's currentHealth on a hit. 
        public static int takeDamage(int damage, monsterBlock target)
        {
            target.currentHealth -= damage;
            //if this method reduces the target's hp to 0, changes their status to dead
            if (target.currentHealth <= 0)
            {
                target.isDead = true;
                target.currentHealth = 0;
            }

            return 1;
        }

        public static void revivfy(monsterBlock target)
        {
            target.currentHealth = target.MaxHealth;
            target.isDead = false;
        }


        //ThunderDome() method takes two monsterBlocks as arguments and makes them fight until one is dead
        //Two Monsters Enter One Monster Leaves
        public static void ThunderDome(monsterBlock fighter1, monsterBlock fighter2, bool printWinnerToFile, bool playInConsole, int numOfMatches)
        {
            for (int i = 1; i <= numOfMatches; i++)
            {
                //rez the loser from the last match and heal the winner to full
                revivfy(fighter1);
                revivfy(fighter2);

                int roundNum = 1;
                //do-while loop to repeat each combat round
                do
                {


                    if (fighter1.isDead == true)
                    {
                        //prints winner to console and logs
                        if (playInConsole)
                        {
                            Console.WriteLine($"____________________ Round: {roundNum} ____________________");
                            Console.WriteLine($"{fighter2.name} WINS!!");
                        }
                        if (printWinnerToFile)
                        {
                            writeLog.logWinner(fighter2.name, fighter1.name);
                        }
                        break;

                    }
                    else if (fighter2.isDead == true)
                    {
                        //prints winner to console and logs
                        if (playInConsole)
                        {
                            Console.WriteLine($" ____________________ Round: {roundNum} ____________________ ");
                            Console.WriteLine($"{fighter1.name} WINS!!");
                        }
                        if (printWinnerToFile)
                        {
                            writeLog.logWinner(fighter1.name, fighter2.name);
                        }
                        break;

                    }
                    else
                    {
                        //executes round of combat and writes to console
                        if (playInConsole)
                        {
                            Console.WriteLine($" ____________________ Round: {roundNum} ____________________ ");
                            Console.WriteLine($"{fighter1.name} {healthBar(fighter1)}               {fighter2.name} {healthBar(fighter2)}");
                        }
                        monsterBlock.Attack(fighter2, fighter1, playInConsole);
                        monsterBlock.Attack(fighter1, fighter2, playInConsole);
                        roundNum += 1;

                    }

                }
                while (fighter1.isDead == false || fighter2.isDead == false);

            }



        }
    }
}
