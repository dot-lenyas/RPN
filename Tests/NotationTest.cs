using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Calc.Tests
{
    public class NotationTest
    {
        private readonly Notation notation = new Notation();

        [Test]
        public void SuccessfullyWorkWithoutBrackets()
        {
            var postfixNot = notation.Convert2PostfixNotation("5+3*10");
            var v = AggregatePostfixNot(postfixNot);

            Assert.AreEqual(v, "5310*+");
        }

        [Test]
        public void SuccessfullyWorkWithBrackets()
        {
            var postfixNot = notation.Convert2PostfixNotation("(7-(1+2))*4+3");
            var v = AggregatePostfixNot(postfixNot);

            Assert.AreEqual(v, "712+-4*3+");
        }

        [Test]
        public void ThrowsExceptionWhenOpenBracketNotFound()
        {
            Assert.Throws<Exception>(() => notation.Convert2PostfixNotation("1+7)"));
        }

        [Test]
        public void CorrectWorksWithNegativeNumbers()
        {
            var postfixNot = notation.Convert2PostfixNotation("5+-7");
            var v = AggregatePostfixNot(postfixNot);

            Assert.AreEqual(v, "5-7+");
        }

        [Test]
        public void IndexIsNotExitOutsideSplitSource()
        {
            var postfixNot = notation.Convert2PostfixNotation("5--");
            var v = AggregatePostfixNot(postfixNot);

            Assert.AreEqual(v, "5--");
        }

        string AggregatePostfixNot(List<string> postfixNot)
        {
            return postfixNot.Aggregate(string.Empty, (current, not) => current + not);
        }
    }
}
