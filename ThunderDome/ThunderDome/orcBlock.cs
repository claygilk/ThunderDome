namespace ThunderDome
{
    using System;

    /// <summary>
    /// subclass of StatBlock that supplies info necessary to make a orc.
    /// </summary>
    public class OrcBlock : StatBlock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrcBlock"/> class.
        /// </summary>
        /// <param name="inName"> Name of this instance of Orc.</param>
        public OrcBlock(string inName)
        {
            this.CreatureName = inName;
            this.Race = "Orc";
            this.MaxHealth = 15;
            this.CurrentHealth = this.MaxHealth;
            this.ArmorClass = 13;
            this.AttackModifier = 5;
            this.DamageModifier = 3;
        }
    }
}
