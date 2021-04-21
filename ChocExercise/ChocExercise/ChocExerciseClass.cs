using System;

namespace ChocExercise
{
	public class ChocExercise
	{
        public static int BreakChocolate(int n, int m)
        {
            if (n == 0 || m == 0) 
                return 0;
            else
                return (n * m) - 1;
        }
    }
}
