namespace ThunderDome
{
    using System;

    /// <summary>
    /// subclass of StatBlock that supplies info necessary to make a Hobgoblin.
    /// </summary>
    public class HobgoblinBlock : StatBlock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HobgoblinBlock"/> class.
        /// </summary>
        /// <param name="inName"> The name of this particular hobgoblin.</param>
        public HobgoblinBlock(string inName)
        {
            this.CreatureName = inName;
            this.Race = "Hobgoblin";
            this.MaxHealth = 11;
            this.CurrentHealth = this.MaxHealth;
            this.ArmorClass = 18;
            this.AttackModifier = 3;
            this.DamageModifier = 1;
        }
    }
}
