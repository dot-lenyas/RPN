using System;
using System.Collections.Generic;

namespace Calc
{
    public abstract class Operators 
    {
        public abstract string Name;
        public abstract int Priority;
        public abstract double action(double first, double second);
    }

    class Plus: Operators
    {
        public override string Name => "+";
        public override int Priority => 1;
        public override double action(double first, double second) { return first + second }
    }
    class Minus : Operators
    {
        public override string Name => "-";
        public override int Priority => 1;
        public override double action(double first, double second) { return first - second }
    }
    class Multiplication : Operators
    {
        public override string Name => "*";
        public override int Priority => 2;
        public override double action(double first, double second) { return first * second }
    }
    class Division : Operators
    {
        public override string Name => "/";
        public override int Priority => 2;
        public override double action(double first, double second) { return first / second }
    }
    class OpenBracket : Operators
    {
        public override string Name => "(";
        public override int Priority => 0;
    }
    class CloseBracket : Operators
    {
        public override string Name => ")";
        public override int Priority => 0;
    }
}
