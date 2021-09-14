using System;
using System.Collections.Generic;

namespace Calc
{
    static class OperationExtension
    {
        public static double ApplyTo(this string operation, Stack<double> stack)
        {
            double first, second;

            if(stack.Count >= 2) 
            {
                second = stack.Pop();
                first = stack.Pop();
            }
            else
                throw new Exception("Expression is not valid!");

            return Operators.action(operation, first, second);
        }
    }
}
