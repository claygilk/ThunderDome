using System;
using System.Collections.Generic;
using System.Text;

namespace ThunderDome
{
    class bugbearBlock : monsterBlock
    {
        public bugbearBlock(string inName)
        {
            name = inName;
            race = "Bugbear";
            MaxHealth = 27;
            currentHealth = MaxHealth;
            armorClass = 16;
            attackModifier = 4;
            damageModifier = 2;
        }
    }
}
