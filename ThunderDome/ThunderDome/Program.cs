using System;

namespace ThunderDome
{
    class Program
    {
        static void Main(string[] args)
        {

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

            monsterBlock.ThunderDome(boblin, hoblin);



        }


    }
}

class monsterBlock
{
    public string race;
    private int maxhealth;
    public int MaxHealth
    {
        get { return maxhealth; }
    }
    public int currentHealth;
    public int armorClass;
    public int attackModifier;
    public int damageModifier;
    public string name;
    public bool isDead;

    public monsterBlock(int inHealth)
    {
        maxhealth = inHealth;
        currentHealth = inHealth;
    }

    public static int Attack(monsterBlock attacker, monsterBlock target)
    {
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

            //Console.WriteLine($"Scimitar: {attackRoll + attackModifier} ({attackRoll} + {attackModifier}) to hit.");


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
    public static int takeDamage(int damage, monsterBlock target)
    {
        target.currentHealth -= damage;

        if (target.currentHealth <= 0)
        {
            target.isDead = true;
        }

        return 1;
    }
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




