namespace SafariPark
{
    public class NakedEagle : BasicEnemy
    {
        public NakedEagle(Map map, int hp = 80) : base(map, hp)
        {
            SetDamageModifiers();
            SetAbilities();
        }

        protected override void SetDamageModifiers()
        {
            damageModifiers.Add(("water", '*', 0));
            damageModifiers.Add(("physical", '+', 30));
            damageModifiers.Add(("fire", '+', 10));
        }

        protected override void SetAbilities()
        {
            abilities.Add((30, 15, 23, "Bite"));
            abilities.Add((40, 8, 13, "Slap"));
            abilities.Add((30, 0, 0, "Blank stare"));
        }
    }
}
