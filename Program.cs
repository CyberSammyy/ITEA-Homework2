using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace ITEA_Homework2
{
    class Program
    {
        public static decimal Calculator(decimal n1, decimal n2, string oper)
        {
            if(oper == "+")
            {
                return n1 + n2;       
            }
            else if(oper == "-")
            {
                return n1 - n2;
            }
            else if(oper == "abs")
            {
                if (n1 > n2)
                {
                    return n1 - n2;
                }
                else if (n2 > n1)
                {
                    return n2 - n1;
                }
                else return 0;
            }
            else if(oper == "*")
            {
                return n1 * n2;
            }
            else if(oper == "/")
            {
                if(n2 == 0)
                {
                    Console.WriteLine("Error dividing by zero! Returning 0");
                    return 0;
                }
                else
                {
                    return n1 / n2;
                }
            }
            else if(oper == "^")
            {
                return Convert.ToDecimal(Pow(Convert.ToDouble(n1), Convert.ToDouble(n2)));
            }
            else if(oper == "sqrt1")
            {
                return Convert.ToDecimal(Sqrt(Convert.ToDouble(n1)));
            }
            else if(oper == "sqrt2")
            {
                return Convert.ToDecimal(Sqrt(Convert.ToDouble(n2)));
            }
            else
            {
                Console.WriteLine("Incorrect or empty math operator. Returning 0");
                return 0;
            }
        }
        public static int Max(int[] digits)
        {
            return digits.Max();
        }
        public static int Min(int[] digits)
        {
            return digits.Min();
        }
        public static decimal ToDecimal(double number)
        {
            return Convert.ToDecimal(number);
        }
        public static int[] Reverse(int[] array)
        {
            int size = array.Length;
            for(int i = 0; i < size / 2; i++)
            {
                int temp = array[i];
                array[i] = array[size - i - 1];
                array[size - i - 1] = temp;
            }
            return array;
        }
        public static void Show(int[] digits)
        {
            int counter = 1;
            foreach(var a in digits)
            {
                Console.WriteLine("{0} digit is:" + a, counter);
                counter++;
            }
            Console.WriteLine();
        }
        public static int[] Digits(double number)
        {
            int number_int;
            decimal numb = ToDecimal(number);
            while(numb.ToString().Contains(","))
            {
                numb *= 10;
                numb = Convert.ToDecimal(numb.ToString().TrimEnd('0'));
            }
            number_int = (int)numb;
            int size = numb.ToString().Length;
            int[] digits = new int[size];
            for(int i = 0; i < size; i++)
            {
                digits[i] = number_int % 10;
                number_int /= 10;
            }
            return Reverse(digits);
        }
        static void Main(string[] args)
        {
            decimal first_num = 0;
            decimal second_num = 0;
            decimal result = 0;
            bool flag = true;
            while (true)
            {
                double num = 0;
                do
                {
                    Console.WriteLine("Enter your number: ");
                }
                while (!double.TryParse(Console.ReadLine(), out num));
                Show(Digits(num));
                Console.WriteLine("Maximum digit: " + Max(Digits(num)));
                Console.WriteLine("Minimum digit: " + Min(Digits(num)));
                Console.WriteLine("Do you wanna continue? Y/N");
                var key = Console.ReadKey();
                Console.WriteLine();
                if(key.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Restarting...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Going to the second part of the program....");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
            }
            while(true)
            {
                if (flag)
                {
                    while (true)
                    {
                        Console.WriteLine("Input first number:");
                        if (decimal.TryParse(Console.ReadLine(), out first_num)) break; ;
                    }
                }
                else second_num = result;
                while (true)
                {
                    Console.WriteLine("Input second number:");
                    if (decimal.TryParse(Console.ReadLine(), out second_num)) break; ;
                }
                Console.WriteLine("Enter operation:");
                result = Calculator(first_num, second_num, Console.ReadLine());
                Console.WriteLine("Result: {0}", result);
                Console.WriteLine("Do you wanna continue? E - exit, R - repeat, C - continue");
                var key2 = Console.ReadKey();
                if(key2.Key == ConsoleKey.E)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Bye!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    break;
                }
                else if(key2.Key == ConsoleKey.R)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Restarting...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if(key2.Key == ConsoleKey.C)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Restarting with the first number = last result...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    flag = false;
                    first_num = result;
                    Console.WriteLine("Your first number is {0}", first_num);
                }
            }
        }
    }
}
