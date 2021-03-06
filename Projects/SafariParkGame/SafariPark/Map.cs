namespace SafariPark
{
    public class Map
    {
        public readonly string emptySpace = "  ";
        public readonly string fence = "# ";
        public int X { get; set; }
        public int Y { get; set; }
        public string[,] MapArray { get; set; }

        public Map(int x, int y)
        {
            X = x > 4 ? x : 5;
            Y = y > 4 ? y : 5;
            MakeMapArray();
        }

        public void MakeMapArray()
        {
            MapArray = new string[X+2,Y+2];
            for (int x = 0; x < MapArray.GetLength(0); x++)
            {
                for (int y = 0; y < MapArray.GetLength(1); y++)
                {
                    if (x == 0 || x == MapArray.GetUpperBound(0) || y == 0 || y == MapArray.GetUpperBound(1))
                    {
                        MapArray[x, y] = fence;
                    }
                    else
                    {
                        MapArray[x, y] = emptySpace;
                    }
                }
            }
        }
    }
}
