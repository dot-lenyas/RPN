using System;

namespace Calc
{
    class IOManager
    {
        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
