﻿using System;

namespace CoolCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string versionNum = "v1.0.0";
            Console.Write("Enter your name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Hello " + fname + ", Welcome to Blaze Devs Advanced CLI Calculator! \nVersion: " + versionNum);
            //Console.Write("Current Date and Time is : ");
            //DateTime now = DateTime.Now;
            //Console.WriteLine(now);

            string methodType;
            Console.Write("Choose a method(Basic or Advanced):");
            methodType = Console.ReadLine();

            
            Console.WriteLine("Available Operators: \nFor Addition: + \nFor Subtraction: - \nFor Division: / \nFor Multiplication: * \nFor Modulus: % ");

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
    }
}