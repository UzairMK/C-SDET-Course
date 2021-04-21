using NUnit.Framework;
using Lab_07_Selections;

namespace Lab_07_Selections_Tests
{
    public class Tests
    {
        [TestCase(75, "Pass with Distinction")]
        [TestCase(80, "Pass with Distinction")]
        public void Mark75AndOverPassWithDistinction(int mark, string expected)
        {
            var actual = Program.Grade(mark);
            Assert.AreEqual(expected,actual);
        }

        [TestCase(74, "Pass with Merit")]
        [TestCase(60, "Pass with Merit")]
        public void MarkBetween60And74PassWithMerit(int mark, string expected)
        {
            var actual = Program.Grade(mark);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(101)]
        [TestCase(-1)]
        public void MarkOutOfRangeException(int mark)
        {
            Assert.Throws<System.Exception>(() => Program.Grade(mark));
        }

        [TestCase(0,"Code Green")]
        [TestCase(1,"Code Amber")]
        [TestCase(2,"Code Amber")]
        [TestCase(3,"Code Red")]
        [TestCase(4,"Code Invalid")]
        public void CheckPrority(int level, string expected)
        {
            var actual = Program.Prority(level);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(40, "Pass")]
        [TestCase(39, "Fail")]
        public void CheckTurnary(int mark, string expected)
        {
            var actual = Program.Turnary(mark);
            Assert.AreEqual(expected, actual);
        }
    }
}