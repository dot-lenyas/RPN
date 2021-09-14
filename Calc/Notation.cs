using System;
using System.Collections.Generic;
using System.Linq;

namespace Calc
{
    class Notation : INotation
    {
        public List<string> Convert2PostfixNotation(string str)
        {
            var splitSource = Splitter.SplitSourceStr(str);
            var postfixNotation = new List<string>();
            var operationsStack = new Stack<string>();

            for (int i = 0; i < splitSource.Count(); ++i)
            {
                if (Operators.Priority.ContainsKey(splitSource[i]))
                {
                    if (splitSource[i].Equals(Operators.CloseBracket))
                    {
                        var isOpenBracketExist = false;

                        while (operationsStack.Count != 0)
                        {
                            if (operationsStack.Peek().Equals(Operators.OpenBracket))
                            {
                                operationsStack.Pop();
                                isOpenBracketExist = true;
                                break;
                            }

                            postfixNotation.Add(operationsStack.Pop());
                        }

                        if (!isOpenBracketExist)
                            throw new Exception("Open bracket not found!");

                        continue;
                    }

                    if (i != 0 && i + 1 < splitSource.Count && splitSource[i].Equals(Operators.Minus) &&
                        Operators.Priority.ContainsKey(splitSource[i - 1]))
                    {
                        postfixNotation.Add(string.Concat(splitSource[i], splitSource[i + 1]));
                        i += 1;
                        continue;
                    }

                    while (operationsStack.Count != 0)
                    {
                        if (Operators.Priority[splitSource[i]] <= Operators.Priority[operationsStack.Peek()] &&
                            !splitSource[i].Equals(Operators.OpenBracket))
                            postfixNotation.Add(operationsStack.Pop());
                        else
                            break;
                    }

                    operationsStack.Push(splitSource[i]);
                }
                else
                    postfixNotation.Add(splitSource[i]);
            }

            while (operationsStack.Count != 0)
                postfixNotation.Add(operationsStack.Pop());

            return postfixNotation;
        }
    }
}
