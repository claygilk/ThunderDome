namespace ThunderDome
{
    using System;

    /// <summary>
    /// subclass of StatBlock that supplies info necessary to make a bugbear.
    /// </summary>
    public class BugbearBlock : StatBlock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BugbearBlock"/> class.
        /// </summary>
        /// <param name="inName">The name of this instance of Bugbear.</param>
        public BugbearBlock(string inName)
        {
            this.CreatureName = inName;
            this.Race = "Bugbear";
            this.MaxHealth = 27;
            this.CurrentHealth = this.MaxHealth;
            this.ArmorClass = 16;
            this.AttackModifier = 4;
            this.DamageModifier = 2;
        }
    }
}
