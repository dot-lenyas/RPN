using System;
using System.Collections.Generic;

namespace Calc
{
    class Operators
    {
        public const string OpenBracket = "(";
        public const string CloseBracket = ")";
        public const string Plus = "+";
        public const string Minus = "-";
        public const string Multiplication = "*";
        public const string Division = "/";

        public static readonly Dictionary<string, int> Priority = new Dictionary<string, int>
        {
            {OpenBracket, 0},
            {CloseBracket, 0},
            {Plus, 1},
            {Minus, 1},
            {Multiplication, 2},
            {Division, 2}
        };

        public static double action(string operation, double first, double second)
        {
            switch (operation)
            {
                case Plus: return first + second;
                case Minus: return first - second;
                case Multiplication: return first * second;
                case Division: return first / second;
                default: throw new Exception("Invalid operator!");
            }
        }
    }
}
