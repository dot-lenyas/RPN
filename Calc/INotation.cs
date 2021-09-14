using System.Collections.Generic;

namespace Calc
{
    public interface INotation
    {
        List<string> Convert2PostfixNotation(string str);
    }
}
