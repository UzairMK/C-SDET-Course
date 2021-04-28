using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
