using System;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            CustomStack<string> myStack = new CustomStack<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input.Split(new string[] {" ", ", "}, StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "Push":
                        for (int i = 1; i < commands.Length; i++)
                        {
                            myStack.Push(commands[i]);
                        }

                        break;
                    case "Pop":
                        myStack.Pop();
                        break;
                }
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);   
            }
        }
    }
}
