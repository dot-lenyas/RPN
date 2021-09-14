using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace Calc.Tests
{
    class IOManagerTest
    {
        [Test]
        public void ReadLineCorrectWorks()
        {
            Console.SetIn(new StringReader("2+2"));

            var source = IOManager.ReadLine();

            Assert.AreEqual(source, "2+2");
        }

        [Test]
        public void WriteMessageCorrectWorks()
        {
            var str = new StringBuilder();
            Console.SetOut(new StringWriter(str));

            IOManager.WriteMessage("15");

            Assert.IsTrue(str.ToString().Contains("15"));
        }
    }
}
