namespace SafariPark
{
    public interface IEnemy
    {
        public MapLocation MapLocation { get; set; }
        int HP { get; set; }
        void TakeDamage(int damage, string attribute);
        void DealDamage(Player targetPlayer);
    }
}
