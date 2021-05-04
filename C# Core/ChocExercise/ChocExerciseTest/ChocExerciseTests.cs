using NUnit.Framework;
using ChocExercise;

namespace ChocExerciseTest
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
			
		}

		[TestCase(3,1,2)]
		[TestCase(1, 1, 0)]
		[TestCase(0, 0, 0)]
		[TestCase(5, 5, 24)]
		[TestCase(1, 0, 0)]
		[TestCase(0, 1, 0)]
		public void ChocExerciseTest(int n, int m, int expected)
		{
			int actual = ChocExercise.ChocExercise.BreakChocolate(n, m);
			Assert.AreEqual(expected, actual);
		}
	}
}