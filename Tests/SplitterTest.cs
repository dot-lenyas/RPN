using System.Linq;
using NUnit.Framework;

namespace Calc.Tests
{
    public class SplitterTest
    {
        [Test]
        public void CorrectRemoveWhiteSpaces()
        {
            var splitSource = Splitter.SplitSourceStr(" 13 + 7 ");

            Assert.AreEqual(splitSource.Count(), 3);
            Assert.AreEqual(splitSource.ElementAt(0), "13");
            Assert.AreEqual(splitSource.ElementAt(1), "+");
            Assert.AreEqual(splitSource.ElementAt(2), "7");
        }

        [Test]
        public void ChecksPlus()
        {
           CheckOperator(Operators.Plus);
        }

        [Test]
        public void ChecksMinus()
        {
            CheckOperator(Operators.Minus);
        }

        [Test]
        public void ChecksMultiplication()
        {
            CheckOperator(Operators.Multiplication);
        }

        [Test]
        public void ChecksDivision()
        {
            CheckOperator(Operators.Division);
        }

        [Test]
        public void ChecksBracket()
        {
            var splitSoure = Splitter.SplitSourceStr("(1)");

            Assert.AreEqual(splitSoure.ElementAt(0), "(");
            Assert.AreEqual(splitSoure.Last(), ")");
            Assert.AreEqual(splitSoure.Count(), 3);
        }

        void CheckOperator(string op)
        {
            var splitSource = Splitter.SplitSourceStr(string.Format("5{0}3", op));

            Assert.AreEqual(splitSource.ElementAt(1), op);
            Assert.AreEqual(splitSource.Count(), 3);
        }
    }
}
