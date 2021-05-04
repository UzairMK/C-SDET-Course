using System;
using System.Collections.Generic;

namespace SafariPark
{
    public abstract class BasicEnemy : IEnemy
    {
        private readonly string _icon = "! ";
        public MapLocation MapLocation { get; set; }
        public int HP { get; set; }
        public List<(int prob, int minDam, int maxDam, string moveName)> abilities = new();
        public List<(string attribute, char operation, int modifierValue)> damageModifiers = new();


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
            int probabilitySum = 0;
            List<int> probabilityList = new();
            foreach (var (prob, minDam, maxDam, moveName) in abilities)
            {
                probabilitySum += prob;
                probabilityList.Add(probabilitySum);
            }

            Random rng = new();
            int r = rng.Next(probabilitySum + 1);

            for (int i = 0; i < probabilityList.Count; i++)
            {
                if (r <= probabilityList[i])
                {
                    var (_, minDam, maxDam, moveName) = abilities[i];
                    int damage = rng.Next(minDam, maxDam + 1);
                    player.HP -= damage;
                    Console.WriteLine($"{GetType().Name} used '{moveName}' to do {damage} damage.");
                    return;
                }
            }
        }
    }
}
