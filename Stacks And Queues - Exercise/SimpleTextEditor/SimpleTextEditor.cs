using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int numberRotations = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> pushedPhrases = new Stack<string>();
            for (int i = 0; i < numberRotations; i++)
            {
                string[] command = Console.ReadLine().Split();
                switch (command[0])
                {
                    case "1":
                        pushedPhrases.Push(sb.ToString());
                        string strToAppend = command[1];
                        sb.Append(strToAppend);
                        break;
                    case "2":
                        pushedPhrases.Push(sb.ToString());
                        int countChars = int.Parse(command[1]);
                        sb.Remove(sb.Length - countChars, countChars);
                        break;
                    case "3":
                        int index = int.Parse(command[1]);
                        Console.WriteLine(sb[index - 1]);
                        break;
                    case "4":
                        if (sb.Length == 0)
                        {
                            sb.Append(pushedPhrases.Pop());
                        }
                        else
                        {
                            sb.Replace(sb.ToString(), pushedPhrases.Pop());
                        }
                        break;
                }
            }
        }
    }
}
