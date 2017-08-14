using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "n";
            while (str != "y")
            {
                int number = 0;
                Console.Write("Enter first number: ");
                int num1 = int.Parse(Console.ReadLine());
                Console.Write("Enter second number: ");
                int num2 = int.Parse(Console.ReadLine());
                Console.Write("Enter sign: ");
                string sign = Console.ReadLine();

                if (sign == "+")
                {
                    number = Plus(num1, num2);
                }
                else if (sign == "-")
                {
                    number = minus(num1, num2);
                }
                else if (sign == "/")
                {
                    number = div(num1, num2);
                }
                else if (sign == "*")
                {
                    number = mult(num1, num2);
                }

                Console.WriteLine(number);
            }
            }
            static int Plus(int a, int b)
            {
                return a + b;
            }
            static int minus(int a, int b)
            {
                return a - b;
            }
            static int div(int a, int b)
            {
                return a / b;
            }
            static int mult(int a, int b)
            {
                return a * b;
            }
    }
}
