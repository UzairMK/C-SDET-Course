using System;
using System.Collections.Generic;

namespace SafariPark
{
    public abstract class BasicEnemy : IEnemy
    {
        private readonly char _icon = '!';
        public MapLocation MapLocation { get; set; }
        public int HP { get; set; }
        public List<(int prob, int minDam, int maxDam, string moveName)> abilities = new List<(int prob, int minDam, int maxDam, string moveName)>();
        public List<(string attribute, char operation, int modifierValue)> damageModifiers = new List<(string attribute, char operation, int modifierValue)>();


        public BasicEnemy(Map map, int hp)
        {
            HP = hp;
            MapLocation = new MapLocation(map, _icon);
        }

        protected abstract void SetDamageModifiers();
        protected abstract void SetAbilities();

        public void TakeDamage(int damage, string attribute)
        {
            foreach (var modifier in damageModifiers)
            {
                if (modifier.attribute == attribute)
                {
                    switch (modifier.operation)
                    {
                        case '+':
                            damage += modifier.modifierValue;
                            HP -= damage;
                            Console.WriteLine($"{GetType().Name} took {damage} damage from your move.");
                            return;
                        case '-':
                            damage -= modifier.modifierValue;
                            HP -= damage;
                            Console.WriteLine($"{GetType().Name} took {damage} damage from your move.");
                            return;
                        case '*':
                            damage *= modifier.modifierValue;
                            HP -= damage;
                            Console.WriteLine($"{GetType().Name} took {damage} damage from your move.");
                            return;
                        case '/':
                            damage /= modifier.modifierValue;
                            HP -= damage;
                            Console.WriteLine($"{GetType().Name} took {damage} damage from your move.");
                            return;
                    }
                }
            }

            HP -= damage;
            Console.WriteLine($"{GetType().Name} took {damage} damage from your move.");
        }

        public void DealDamage(Player player)
        {
            Random rng = new Random();
            int i = rng.Next(100);

            foreach (var ability in abilities)
            {
                if (i >= ability.prob)
                {
                    int damage = rng.Next(ability.minDam, ability.maxDam + 1);
                    player.HP -= damage;
                    Console.WriteLine($"{GetType().Name} used '{ability.moveName}' to do {damage} damage.");
                    return;
                }
            }
        }
    }
}
