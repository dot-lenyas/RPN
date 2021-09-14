using System;
using System.Collections.Generic;

namespace Calc
{
    class Calc
    {
        private readonly INotation notation;

        public Calc(INotation notation)
        {
            this.notation = notation;
        }

        public void Run()
        {
            try
            {
                IOManager.WriteMessage("Введите выражение:");

                var str = IOManager.ReadLine();

                if (string.IsNullOrEmpty(str))
                    throw new Exception("Line is empty!");

                IOManager.WriteMessage(Calculation(str).ToString());
            }
            catch (Exception ex)
            {
                IOManager.WriteMessage(ex.Message);
            }
        }

        public double Calculation(string str)
        {
            var postfixNotation = notation.Convert2PostfixNotation(str.Replace('.', ','));
            var values = new Stack<double>();
            
            foreach (var el in postfixNotation)
            {
                double resultPars;

                values.Push(double.TryParse(el, out resultPars) ? resultPars : el.ApplyTo(values));
            }

            if(values.Count > 1)
                throw new Exception("Expression is not valid!");

            return values.Pop();
        }
    }
}
