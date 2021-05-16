namespace ThunderDome
{
    using System;

    /// <summary>
    /// Subclass of StatBlock that supplies info necessary to make a goblin.
    /// </summary>
    public class GoblinBlock : StatBlock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoblinBlock"/> class.
        /// </summary>
        /// <param name="inName"> The name of this particular goblin.</param>
        public GoblinBlock(string inName)
        {
            this.CreatureName = inName;
            this.Race = "Goblin";
            this.MaxHealth = 7;
            this.CurrentHealth = this.MaxHealth;
            this.ArmorClass = 15;
            this.AttackModifier = 4;
            this.DamageModifier = 2;

        }

    }
}
