using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariPark
{
    public class Player
    {
        private const char _playerIcon = 'P';
        public MapLocation mapLocation;
        public int HP { get; set; } = 100;

        public Player(Map map)
        {
            mapLocation = new MapLocation(map, _playerIcon);
        }

        public Player(int x, int y, Map map)
        {
            mapLocation = new MapLocation(x, y, map, _playerIcon);
        }
    }
}
