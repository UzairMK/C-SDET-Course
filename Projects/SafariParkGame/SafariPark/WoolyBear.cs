namespace SafariPark
{
    public class WoolyBear : BasicEnemy
    {
        public WoolyBear(Map map, int hp = 90) : base(map, hp)
        {
            SetDamageModifiers();
            SetAbilities();
        }

        protected override void SetDamageModifiers()
        {
            damageModifiers.Add(("water", '*', 2));
            damageModifiers.Add(("fire", '*', 2));
        }

        protected override void SetAbilities()
        {
            abilities.Add((40, 5, 20, "FRIENDLY Hug"));
            abilities.Add((30, 5, 15, "Wooly Slap"));
            abilities.Add((30, 1, 5, "Yawn"));
        }
    }
}
