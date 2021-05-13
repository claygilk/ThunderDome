using System;
using System.Collections.Generic;
using System.Text;

namespace ThunderDome
{
    class orcBlock : monsterBlock
    {
        public orcBlock(string inName)
        {
            name = inName;
            race = "Orc";
            MaxHealth = 15;
            currentHealth = MaxHealth;
            armorClass = 13;
            attackModifier = 5;
            damageModifier = 3;
        }
    }
}
