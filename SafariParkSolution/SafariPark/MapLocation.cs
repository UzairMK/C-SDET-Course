using System;
using System.Collections.Generic;

namespace SafariPark
{
    public class MapLocation
    {
        private char _icon;
        private Map _map;
        private Dictionary<char, int[]> directionDict = new Dictionary<char, int[]>()
        {
            { 'w', new int[] { -1, 0 } },
            { 's', new int[] { 1, 0 } },
            { 'a', new int[] { 0, -1 } },
            { 'd', new int[] { 0, 1 } },
            { '0', new int[] { 0, 0 } }
        };
        public int X { get; set; }
        public int Y { get; set; }

        public MapLocation(Map map, char icon)
        {
            _map = map;
            _icon = icon;
            do
            {
                Random rng = new Random();
                X = rng.Next(1, map.MapArray.GetLength(0));
                Y = rng.Next(1, map.MapArray.GetLength(1));
            } while (_map.MapArray[X, Y] != _map.emptySpace);
            _map.MapArray[X, Y] = _icon;
        }

        public MapLocation(int x, int y, Map map, char icon)
        {
            X = x;
            Y = y;
            _map = map;
            _icon = icon;
            if (_map.MapArray[X, Y] != _map.emptySpace)
                throw new Exception("Invalid position");
            _map.MapArray[X, Y] = _icon;
        }

        public void Move(char direction)
        {
            int[] vector2D = directionDict[direction];
            UpdateMap(vector2D[0], vector2D[1]);
        }

        public void Move(IntVector2D intVector2D)
        {
            int[] domDir = intVector2D.DominateDirection();
            UpdateMap(domDir[0], domDir[1]);
        }

        public void UpdateMap(int diffX, int diffY)
        {
            if (_map.MapArray[X + diffX, Y + diffY] == _map.fence || _map.MapArray[X + diffX, Y + diffY] == _icon)
                return;
            _map.MapArray[X, Y] = _map.emptySpace;
            X += diffX;
            Y += diffY;
            _map.MapArray[X, Y] = _icon;
        }

        public override bool Equals(object obj)
        {
            MapLocation that = (MapLocation)obj;
            return X == that.X && Y == that.Y ? true : false;
        }
    }
}
