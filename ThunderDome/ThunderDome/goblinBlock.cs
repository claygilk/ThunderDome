using System;
using System.Collections.Generic;
using System.Text;

namespace ThunderDome
{
    class goblinBlock : monsterBlock
    {

        public goblinBlock(string inName)
        {
            name = inName;
            race = "Goblin";
            MaxHealth = 7;
            currentHealth = MaxHealth;
            armorClass = 15;
            attackModifier = 4;
            damageModifier = 2;

        }

    }
}
