using System;

namespace ThunderDome
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates two fighters, boblin and hoblin. 

            monsterBlock boblin = new monsterBlock(7);
            boblin.race = "Goblin";
            boblin.armorClass = 15;
            boblin.attackModifier = 4;
            boblin.damageModifier = 2;
            boblin.name = "Boblin";

            monsterBlock hoblin = new monsterBlock(7);
            hoblin.race = "Goblin";
            hoblin.armorClass = 15;
            hoblin.attackModifier = 4;
            hoblin.damageModifier = 2;
            hoblin.name = "Hoblin";

            //And puts them in the thunderdome.
            monsterBlock.ThunderDome(boblin, hoblin);



        }


    }
}

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
    }

    public monsterBlock(int inHealth)
    {
        maxhealth = inHealth;
        currentHealth = inHealth;
    }

    //Attac() method is called whenever a monsterBlock makes an attack
    public static int Attack(monsterBlock attacker, monsterBlock target)
    {
        //Attack fails if either attacker or target is dead
        if (target.isDead == true)
        {
            Console.WriteLine($"{target.name} is already dead!");
            return 0;
        }
        else if (attacker.isDead == true)
        {
            Console.WriteLine($"{attacker.name} is already dead!");
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
                Console.WriteLine($"{attacker.name} hit {target.name}!");
                Console.WriteLine($"{attacker.name} dealt {damageDelt} points of damage to {target.name} ({target.currentHealth} HP) \n");

            }
            else
            {
                Console.WriteLine($"{attacker.name} missed on {target.name}!\n");
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
    //ThunderDome() method takes two monsterBlocks as arguments and makes them fight until one is dead
    //Two Monsters Enter One Monster Leaves
    public static void ThunderDome(monsterBlock fighter1, monsterBlock fighter2)
    {
        int roundNum = 1;
        do
        {


            if (fighter1.isDead == true)
            {
                Console.WriteLine($"################### Round: {roundNum} ###################");
                Console.WriteLine($"{fighter2.name} WINS!!");
                break;

            }
            else if (fighter2.isDead == true)
            {
                Console.WriteLine($"################### Round: {roundNum} ###################");
                Console.WriteLine($"{fighter1.name} WINS!!");
                break;

            }
            else
            {
                Console.WriteLine($"################### Round: {roundNum} ###################");
                monsterBlock.Attack(fighter2, fighter1);
                monsterBlock.Attack(fighter1, fighter2);
                roundNum += 1;

            }
        }
        while (fighter1.isDead == false || fighter2.isDead == false);
    }
}




