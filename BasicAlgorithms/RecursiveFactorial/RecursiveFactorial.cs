using System;

namespace RecursiveFactorial
{
    class RecursiveFactorial
    {
        static void Main()
        {
            double n = double.Parse(Console.ReadLine());
            double result = 1;
            Console.WriteLine(Factorial(n, result));
        }

        static double Factorial(double x, double result)
        {

            if (x <= 1)
            {
                return result;
            }

            result *= x;
            x--;
            return Factorial(x, result);
        }
    }
}