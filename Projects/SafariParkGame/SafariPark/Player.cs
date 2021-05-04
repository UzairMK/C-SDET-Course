using System;
using System.Collections.Generic;

namespace SafariPark
{
    public class Player
    {
        private const string _playerIcon = "P ";
        public MapLocation mapLocation;
        public int HP { get; set; } = 100;

        private readonly Dictionary<char, (int minDam, int maxDam, string attribute, string abilityName)> abilities = new()
        {
            {'q', (20, 30, "physical", "Machete slash") },
            {'w', (5, 8, "water", "Shoot water gun") },
            {'e', (25, 35, "fire", "Fire laser gun") }
        };

        public Player(Map map)
        {
            mapLocation = new MapLocation(map, _playerIcon);
        }

        public Player(int x, int y, Map map)
        {
            mapLocation = new MapLocation(x, y, map, _playerIcon);
        }

        public void DealDamage(char input, IEnemy target)
        {
            var (minDam, maxDam, attribute, abilityName) = abilities[input];
            var damage = new Random().Next(minDam, maxDam + 1);
            target.TakeDamage(damage, attribute);
            Console.WriteLine($"You used '{abilityName}'");
        }
    }
}
