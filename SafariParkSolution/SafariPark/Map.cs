using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariPark
{
    public class Map
    {
        public readonly char emptySpace = ' ';
        public readonly char fence = '=';
        public int X { get; set; }
        public int Y { get; set; }
        public char[,] MapArray { get; set; }

        public Map(int x, int y)
        {
            X = x;
            Y = y;
            MakeMapArray();
        }

        public void MakeMapArray()
        {
            MapArray = new char[X+2,Y+2];
            for (int x = 0; x < MapArray.GetLength(0); x++)
            {
                for (int y = 0; y < MapArray.GetLength(1); y++)
                {
                    if (x == 0 || x == MapArray.GetUpperBound(0) || y == 0 || y == MapArray.GetUpperBound(1))
                    {
                        MapArray[x, y] = fence;
                        continue;
                    }
                    MapArray[x, y] = emptySpace;
                }
            }
        }
    }
}
