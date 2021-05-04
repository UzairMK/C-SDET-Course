using NUnit.Framework;
using ReverseWordOrder;
namespace ReverseWordOrderTests
{
    public class Tests
    {

        [TestCase("Sparta Global", "Global Sparta")]
        [TestCase("And after all you're my Wonderwall", "Wonderwall my you're all after And")]
        public void ReverseWordMethod_String_ReturnsStringWithWordsInReverseOrder(string input, string expected)
        {
            var actual = WordReverser.ReverseWords(input);
            Assert.AreEqual(actual, expected);
        }
    }
}