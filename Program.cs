using System;
using System.IO;

namespace CoolCalculator
{
    class Program
    {

        static void Main(string[] args)
        {
            string versionNum = "v1.0.4";
            Console.Write("Enter your name: ");
            string fname = Console.ReadLine();

            if (fname == "")
            {
                fname = "User";
            }
            Console.WriteLine("Hello " + fname + ", Welcome to Blaze Devs Advanced CLI Application! \nVersion: " + versionNum);

            Application:
            string applicationIn;
            Console.Write("Available Applications: Calculator | GuessingGame | Clock | Terminate CLI (exit) \nEnter your application: ");
            applicationIn = Console.ReadLine();

            switch (applicationIn)
            {

                case "Calculator":
                    goto Method;
                    break;
                case "GuessingGame":
                    Console.WriteLine("This module is currently under development");
                    goto Application;
                    break;
                case "Clock":
                    Console.WriteLine("This module is currently under development");
                    goto Application;
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Pls enter a valid application!");
                    goto Application;
                    break;
            }
            
            //Calculator Modules
        Method:
            string methodType;
            Console.WriteLine("\nAvailable Methods: Basic | Advanced | Return to Main Menu (RMM) (By Default Advanced method is selected) ");
            Console.Write("Choose a method: ");
            methodType = Console.ReadLine();

            if (methodType == "")
            {
                methodType = "Advanced";
            }

            if (methodType == "Advanced") 
            {
                Console.WriteLine("\nCurrent Method: Advanced");
                Console.WriteLine("Available Operators: \nFor Addition: + \nFor Subtraction: - \nFor Division: / \nFor Multiplication: * \nFor Modulus: % ");
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

                    switch (op)
                    {
                        case "+":
                            Console.WriteLine(num1 + num2);
                            break;
                        case "-":
                            Console.WriteLine(num1 - num2);
                            break;
                        case "/":
                            Console.WriteLine("Quotient is " + num1 / num2);
                            break;
                        case "*":
                            Console.WriteLine("Product is " + num1 * num2);
                            break;
                        case "%":
                            Console.WriteLine("Modulus is " + num1 % num2);
                            break;
                        case "Switch":
                            goto Method;
                        default:
                            Console.WriteLine("Invalid Operator, pls enter a valid operator!");
                            break;
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
            if (methodType == "RMM")
            {
                goto Application;
            }

        }
    }
}
