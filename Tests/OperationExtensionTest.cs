using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Calc.Tests
{
    public class OperationExtensionTest
    {
        private Stack<double> stack = new Stack<double>();

        [SetUp]
        public void Init()
        {
            stack.Push(9);
            stack.Push(3);
        }
        
        [Test]
        public void ThrowsExceptionWhenStackIsEmpty()
        {
            var emptyStack = new Stack<double>();

            emptyStack.Push(1);

            Assert.Throws<Exception>(() => Operators.Plus.ApplyTo(emptyStack), "В стеке меньше двух элементов");
        }

        [Test]
        public void ChecksPlus()
        {
            Assert.AreEqual(Operators.Plus.ApplyTo(stack), 12);
        }

        [Test]
        public void ChecksMinus()
        {
            Assert.AreEqual(Operators.Minus.ApplyTo(stack), 6);
        }

        [Test]
        public void ChecksMultiplication()
        {
            Assert.AreEqual(Operators.Multiplication.ApplyTo(stack), 27);
        }

        [Test]
        public void ChecksDivision()
        {
            Assert.AreEqual(Operators.Division.ApplyTo(stack), 3);
        }

        [Test]
        public void ThrowsExceptionWhenOperatoIsNotValid()
        {
            Assert.Throws<Exception>(() => Operators.OpenBracket.ApplyTo(stack));
        }
    }
}
