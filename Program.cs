using System;

namespace CoolCalculator
{
    class Program
    {

        static void Main(string[] args)
        {
            string versionNum = "v1.0.2";
            Console.Write("Enter your name: ");
            string fname = Console.ReadLine();

            if (fname == "")
            {
                fname = "User";
            }
            Console.WriteLine("Hello " + fname + ", Welcome to Blaze Devs Advanced CLI Calculator! \nVersion: " + versionNum);

        //Console.Write("Current Date and Time is : ");
        //DateTime now = DateTime.Now;
        //Console.WriteLine(now);
        Method:
            string methodType;
            Console.WriteLine("Available Methods: Basic | Advanced");
            Console.Write("Choose a method: ");
            methodType = Console.ReadLine();
            if (methodType == "")
            {
                Console.WriteLine("Pls enter a valid method!");
                goto Method;
            }


            if (methodType == "Advanced") 
            {
                Console.WriteLine("\nAvailable Operators: \nFor Addition: + \nFor Subtraction: - \nFor Division: / \nFor Multiplication: * \nFor Modulus: % ");
                Console.WriteLine("If you want to switch method then type Switch in operator field!");
            
            Begin:

                try
                {
                    Console.Write("\nEnter a number: ");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter another number: ");
                    double num2 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter an Operator: ");
                    string op = Console.ReadLine();

                    if (op == "+")
                    {
                        Console.WriteLine(num1 + num2);
                    }
                    else if (op == "-")
                    {
                        Console.WriteLine(num1 - num2);
                    }
                    else if (op == "/")
                    {
                        Console.WriteLine("Quotient is " + num1 / num2);
                    }
                    else if (op == "*")
                    {
                        Console.WriteLine("Product is " + num1 * num2);
                    }
                    else if (op == "%")
                    {
                        Console.WriteLine("Modulus is " + num1 % num2);
                    }
                    else if (op == "Switch")
                    {
                        goto Method;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Operator, pls enter a valid operator!");

                    }
                }
                catch
                {
                    Console.WriteLine("Unexpected Error, pls try again!");
                }
                goto Begin;
            }

            if (methodType == "Basic")
            {
                Console.WriteLine("This module in under development, pls use the Advanced Method till then!");
                goto Method;

            }

        }
    }
}
