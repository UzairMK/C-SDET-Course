using System;

namespace IterationLib
{
    public class Highest
    {
        public static int HighestWhileLoop(int[] nums)
        {
            // this method should use a while loop
            int max = int.MinValue;
            int counter = 0;

            while (counter < nums.GetUpperBound(0))
            {
                max = Math.Max(max, nums[counter]);
                counter++;
            }

            return max;
        }

        public static int HighestForLoop(int[] nums)
        {
            // this method should use a for loop
            int max = int.MinValue;

            for (int i = 0; i < nums.GetUpperBound(0); i++)
            {
                max = Math.Max(max, nums[i]);
            }

            return max;
        }

        public static int HighestForEachLoop(int[] nums)
        {
            // this method should use a for-each loop
            int max = int.MinValue;

            foreach (int i in nums)
            {
                max = Math.Max(max, i);
            }

            return max;
        }

        public static int HighestDoWhileLoop(int[] nums)
        {
            // this method should use a do-while loop
            int max = int.MinValue;
            int counter = 0;

            do
            {
                if (nums.Length == 0)
                    break;
                max = Math.Max(max, nums[counter]);
                counter++;
            } while (counter < nums.GetUpperBound(0));

            return max;
        }
    }
}