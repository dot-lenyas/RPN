using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Calc.Tests
{
    class CalcTest
    {
        [Test]
        public void CalculationWorksCorrectly()
        {
            var mock = new Mock<INotation>();

            mock.Setup(x => x.Convert2PostfixNotation("(5+3)*10"))
                .Returns(new List<string> { "5", "3", "+", "10", "*" });

            var calc = new Calc(mock.Object);

            var result = calc.Calculation("(5+3)*10");

            Assert.AreEqual(result, 80);
        }

        [Test]
        public void CalculationThrowsExceptionWhenInputSourceIsEmpty()
        {
            var mock = new Mock<INotation>();

            mock.Setup(x => x.Convert2PostfixNotation(Environment.NewLine))
                .Returns(new List<string>());

            var calc = new Calc(mock.Object);

            Assert.Throws<InvalidOperationException>(()=>calc.Calculation(Environment.NewLine));
        }

        [Test]
        public void CalculationCorrectWorksWithFloatPoint()
        {
            var mock = new Mock<INotation>();

            mock.Setup(x => x.Convert2PostfixNotation("5,5+4,5"))
                .Returns(new List<string> { "5,5", "4,5", "+" });

            var calc = new Calc(mock.Object);

            Assert.AreEqual(calc.Calculation("5.5+4.5"), 10);
        }

        [Test]
        public void CalculationThrowsExceptionWhenAfterCalculateStackContains2El()
        {
            var mock = new Mock<INotation>();

            mock.Setup(x => x.Convert2PostfixNotation("(5)(4)"))
                .Returns(new List<string> { "5", "4" });

            var calc = new Calc(mock.Object);

            Assert.Throws<Exception>(() => calc.Calculation("(5)(4)"), "После окончания расчета в стеке должен остаться один элемент - результат");
        }
    }
}
