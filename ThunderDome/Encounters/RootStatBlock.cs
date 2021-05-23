using System;
using System.Collections.Generic;
using System.Text;
using ThunderDome;

namespace TestScript
{
    public class RootStatBlock
    {
        // CONSTRUCTOR
        public RootStatBlock(string nickname)
        {
            this.CurrentHealth = 0;
            this.nickName = nickname;
            this.CleanActions = new List<Attack>();
        }

        // PROPERTIES
        public List<Attack> CleanActions { get; set; }


        public bool IsDead { get; set; }
        public string nickName { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public string source { get; set; }
        public int page { get; set; }
        public bool srd { get; set; }
        public List<OtherSource> otherSources { get; set; }
        public string size { get; set; }
        public Type type { get; set; }
        public List<string> alignment { get; set; }
        public List<Ac> ac { get; set; }

        private Hp Hp;
        public Hp hp
        {
            get { return Hp; }
            set
            {
                Hp = value;
                this.CurrentHealth = this.hp.average;
            }

        }

        public Attack Attack { get; set; }
        public int CurrentHealth { get; set; }
        public Speed speed { get; set; }
        public int walkSpeed { get; set; }
        public int str { get; set; }
        public int strMod
        {
            get { return GetModifier(this.str); }
        }
        public int dex { get; set; }
        public int dexMod
        {
            get { return GetModifier(this.dex); }
        }
        public int con { get; set; }
        public int conMod
        {
            get { return GetModifier(this.con); }
        }
        public int @int { get; set; }
        public int @intMod
        {
            get { return GetModifier(this.@int); }
        }
        public int wis { get; set; }
        public int wisMod
        {
            get { return GetModifier(this.wis); }
        }
        public int cha { get; set; }
        public int chaMod
        {
            get { return GetModifier(this.cha); }
        }
        public Skill skill { get; set; }
        public List<string> senses { get; set; }
        public int passive { get; set; }
        public List<string> languages { get; set; }
        public string cr { get; set; }
        public List<Trait> trait { get; set; }
        public List<Action> action { get; set; }
        public List<string> environment { get; set; }
        public bool hasToken { get; set; }
        public SoundClip soundClip { get; set; }
        public List<AltArt> altArt { get; set; }
        public List<string> senseTags { get; set; }
        public List<string> languageTags { get; set; }
        public List<string> damageTags { get; set; }
        public List<string> miscTags { get; set; }
        public bool hasFluff { get; set; }
        public bool hasFluffImages { get; set; }

        // CUSTOM METHODS
        public static int GetModifier(int abilityScore)
        {
            int abilityModifier = (abilityScore - 10) / 2;
            return abilityModifier;
        }

        public string HealthBar()
        {
            return $"HP: [{this.CurrentHealth}/{this.hp.average}]";
        }

        public void TakeDamage(int damage)
        {
            this.CurrentHealth -= damage;
            if (this.CurrentHealth <= 0)
            {
                this.IsDead = true;
                this.CurrentHealth = 0;
            }
        }

        public void Revivify()
        {
            this.CurrentHealth = this.hp.average;
            this.IsDead = false;
        }

        // Attack Method
        public void MakeAttack(RootStatBlock target, bool attackInConsole, int whichAttack = 0)
        {
            // Set Valid Target
            // Attack fails if either attacker or target is dead
            if (target.IsDead == true)
            {
                if (attackInConsole)
                {
                    Console.WriteLine($"The {target.Name} is already dead!");
                }
            }
            else if (this.IsDead == true)
            {
                if (attackInConsole)
                {
                    Console.WriteLine($"The {this.Name} can't attack because they're already dead!");
                }
            }
            else
            {
                //Roll attack(s)

                if (this.CleanActions[whichAttack].attackName == "Multiattack")
                {
                    Console.WriteLine("Multiattack");
                    MakeAttack(target, attackInConsole, 1);
                    MakeAttack(target, attackInConsole, 1);
                }
                else
                {


                    int attackRoll = Dice.Roll(1, 20);
                    int toHit = attackRoll + this.CleanActions[whichAttack].attackModifier;

                    // on a hit, calls takeDamage() method, to deal damage to the target
                    if (toHit >= target.ac[0].ac)
                    {
                        int damageDelt = Dice.Roll(this.CleanActions[whichAttack].numberOfDice, this.CleanActions[whichAttack].diceSize) + this.CleanActions[whichAttack].damageModifier;
                        target.TakeDamage(damageDelt);

                        if (attackInConsole)
                        {
                            Console.WriteLine($"The {this.Name} rolled a {toHit} ({attackRoll} + {this.CleanActions[whichAttack].attackModifier}) on a {this.action[whichAttack].name} attack.");
                            Console.WriteLine($"The {this.Name} hit the {target.Name} for {damageDelt} points of damage!\n");
                        }
                    }
                    else
                    {
                        if (attackInConsole)
                        {
                            Console.WriteLine($"The {this.Name} missed on the {target.Name}!\n");
                        }
                    }
                }
            }
        }
    }
}
