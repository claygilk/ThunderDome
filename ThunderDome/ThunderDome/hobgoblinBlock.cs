using System;
using System.Collections.Generic;
using System.Text;

namespace ThunderDome
{
    class hobgoblinBlock : monsterBlock
    {
        public hobgoblinBlock(string inName)
        {
            name = inName;
            race = "Hobgoblin";
            MaxHealth = 11;
            currentHealth = MaxHealth;
            armorClass = 18;
            attackModifier = 3;
            damageModifier = 1;
        }
    }
}
