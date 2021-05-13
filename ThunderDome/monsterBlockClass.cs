using System;

public class monsterBlock
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

    // monsterBlock constructor
    public monsterBlock(string inName, int inHealth, string inRace)
    {
        name = inName;
        race = inRace;
        maxhealth = inHealth;
        currentHealth = inHealth;
    }


    //Display healthbar
    public static string healthBar(monsterBlock monster)
    {
        double doubleCurrentHealth = ((double)monster.currentHealth / (double)monster.MaxHealth) * 10;
        int intCurrentHealth = Convert.ToInt32(doubleCurrentHealth);
        string hpChunks = "";
        string hpEmpties = "";

        for (int i = 0; i < intCurrentHealth; i++)
        {
            hpChunks += "#";
        }
        for (int i = 0; i < (10 - intCurrentHealth); i++)
        {
            hpEmpties += "_";
        }

        return $"HP: [{hpChunks}{hpEmpties}]";
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
                Console.WriteLine($"{attacker.name} dealt {damageDelt} points of damage to {target.name} \n");

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
                Console.WriteLine($"____________________ Round: {roundNum} ____________________");
                Console.WriteLine($"{fighter2.name} WINS!!");
                break;

            }
            else if (fighter2.isDead == true)
            {
                Console.WriteLine($" ____________________ Round: {roundNum} ____________________ ");
                Console.WriteLine($"{fighter1.name} WINS!!");
                break;

            }
            else
            {
                Console.WriteLine($" ____________________ Round: {roundNum} ____________________ ");
                Console.WriteLine($"{fighter1.name} {healthBar(fighter1)}               {fighter2.name} {healthBar(fighter2)}");
                monsterBlock.Attack(fighter2, fighter1);
                monsterBlock.Attack(fighter1, fighter2);
                roundNum += 1;

            }
        }
        while (fighter1.isDead == false || fighter2.isDead == false);
    }
}