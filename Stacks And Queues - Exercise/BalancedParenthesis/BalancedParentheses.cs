using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            string parentheses = Console.ReadLine();

            Stack<char> parenthesesStack = new Stack<char>();
            bool isBalanced = true;
            Dictionary<char, char> pairs = new Dictionary<char, char>();
            pairs.Add('(',')');
            pairs.Add('[',']');
            pairs.Add('{','}');
            
            foreach (var parenthesis in parentheses)
            {
                if (parentheses.Length % 2 != 0 || parentheses.Length == 0)
                {
                    isBalanced = false;
                    break;
                }
                if (pairs.ContainsKey(parenthesis))
                {
                    parenthesesStack.Push(parenthesis);
                }
                else
                {
                    char openParentesis = parenthesesStack.Pop();
                    if (pairs[openParentesis] != parenthesis)
                    {
                        isBalanced = false;
                    }
                }
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
