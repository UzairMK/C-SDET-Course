namespace SafariPark
{
    public class CyberToothTiger : BasicEnemy
    {
        public CyberToothTiger(Map map, int hp = 100) : base(map, hp)
        {
            SetDamageModifiers();
            SetAbilities();
        }

        protected override void SetDamageModifiers()
        {
            damageModifiers.Add(("water", '*', 11));
            damageModifiers.Add(("physical", '/', 2));
        }

        protected override void SetAbilities()
        {
            abilities.Add((20, 20, 25, "Bite"));
            abilities.Add((60, 15, 18, "Scratch"));
            abilities.Add((20, 5, 10, "Aggressive tickle"));
        }
    }
}
