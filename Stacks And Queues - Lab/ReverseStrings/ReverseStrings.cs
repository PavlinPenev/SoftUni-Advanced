using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            Stack<char> strToReverse = new Stack<char>(Console.ReadLine().ToCharArray());
            while (strToReverse.Count > 0)
            {
                Console.Write(strToReverse.Pop());
            }
        }
    }
}
