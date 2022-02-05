using System;

namespace CoolCalculator
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string fname = Console.ReadLine();

            if (fname == "")
            {
                fname = "User";
            }
            string versionNum = "v1.1.2";
            Console.WriteLine("Hello " + fname + ", Welcome to Blaze Devs Advanced CLI Application! \nVersion: " + versionNum);

            Application:
            Console.Write("Available Applications: Calculator (A) | GuessingGame (B) | Clock (C) | Calendar (D) | Terminate CLI (E) | Help (0)\nChoose your desired application: ");
            string applicationIn = Console.ReadLine();

            switch (applicationIn)
            {

                case "A":
                    goto Methods;
                case "B":
                    Console.WriteLine("This module is currently under development");
                    goto Application;
                case "C":
                    goto Clock;
                case "D":
                    goto Calendar;
                case "E":
                    Environment.Exit(0);
                    break;
                case "0":
                    Console.WriteLine("This module is currently under development");
                    goto Application;
                default:
                    Console.WriteLine("Pls enter a valid application!");
                    goto Application;
            }

            //Calendar Modules
            Calendar:
            try
            {
                Console.Write("Choose an year: ");
                int yearNum = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i < 13; i++)
                {
                    var month = new DateTime(yearNum, i, 1);
          
                    var headingSpaces = new string(' ', 16 - month.ToString("MMMM").Length);
                    Console.WriteLine($"{month.ToString("MMMM")}{headingSpaces}{month.Year}");
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine("Su Mo Tu We Th Fr Sa");

                    var padLeftDays = (int)month.DayOfWeek;
                    var currentDay = month;

                    var iterations = DateTime.DaysInMonth(month.Year, month.Month) + padLeftDays;
                    for (int j = 0; j < iterations; j++)
                    {
                        if (j < padLeftDays)
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write($"{currentDay.Day.ToString().PadLeft(2, ' ')} ");

                            if ((j + 1) % 7 == 0)
                            {
                                Console.WriteLine();
                            }
                            currentDay = currentDay.AddDays(1);
                        }
                    }
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\nDone!");
            CalOpts:
                Console.Write("\nAvailable Options: Select a Different Year (edit) | Return to Main Menu(RMM) | Terminate CLI (exit)\nChoose your input: ");
                string calOpts = Console.ReadLine();
                switch (calOpts)
                {
                    case "edit":
                        goto Calendar;
                    case "RMM":
                        goto Application;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Pls enter a valid Input");
                        goto CalOpts;
                }
            }
            catch
            {
                Console.WriteLine("Oops something went wrong!");
                goto Calendar;
            }

        //Clock Modules
        Clock:
            try
            {
                Console.Write("\nCurrent Date and Time is : ");
                DateTime now = DateTime.Now;
                Console.WriteLine(now);

                Console.Write("\nAvailable Options: Refresh (Ref)/Enter key | Return to Main Menu (RMM) \nChoose an option: ");
                string optionsBtn = Console.ReadLine();

                switch (optionsBtn)
                {
                    case "Ref":
                        goto Clock;
                    case "RMM":
                        goto Application;
                    default:
                        goto Clock;
                }                 
            }
            catch
            {
                Console.WriteLine("Oops Something Went Wrong!");
            }


         //Calculator Modules
         Methods:

                Console.WriteLine("\nAvailable Methods: Scientific (S) | Arithmetic (A) | Return to Main Menu (RMM) | Terminate CLI (exit) ");
                Console.Write("Choose a method: ");
                string methodType = Console.ReadLine();
                switch (methodType)
                {
                    default:
                        {
                            Console.WriteLine("Pls choose a valid method");
                            goto Methods;
                        }
                    case "":
                        {
                            Console.WriteLine("Pls choose a valid method");
                            goto Methods;
                        }
                    case "A":
                        {
                            Console.WriteLine("\nCurrent Method: Arithmetic");
                            Console.WriteLine("Available Operators: \nFor Addition: + \nFor Subtraction: - \nFor Division: # \nFor Division with Remainder: / \nFor Multiplication: * \nFor Modulus: % ");
                            Console.WriteLine("If you want to switch method then type Swh in operation field!");
                            Console.WriteLine("To Terminate CLI, type exit in operation field!");

                            Begin:
                            Console.Write("\nChoose your operation: ");
                            string operationIn = Console.ReadLine();
                        try
                        {
                            switch (operationIn)
                            {
                                case "/":
                                    {
                                        try
                                        {
                                            Console.Write("Enter the dividend: ");
                                            int dividendNum = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Enter the divisor: ");
                                            int divisorNum = Convert.ToInt32(Console.ReadLine());
                                            int remainNum;
                                            int quotientNum = Math.DivRem(dividendNum, divisorNum, out remainNum);
                                            Console.WriteLine("\nQuotient is " + quotientNum);
                                            Console.WriteLine("Remainder is " + remainNum);
                                            break;
                                        }
                                        catch (FormatException ex)
                                        {
                                            Console.WriteLine("Input string was not in a correct format.");
                                        }
                                        catch (InvalidOperationException ex)
                                        {
                                            Console.WriteLine("Not a valid numbers to perform operation");
                                        }
                                        catch (DivideByZeroException ex)
                                        {
                                            Console.WriteLine("Cannot Divide By Zero as it gives answer as infinity");
                                        }
                                        break;
                                    }

                                case "*":
                                    {
                                        Console.Write("Enter a number to multiply: ");
                                        double mulNum1 = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Enter another number to multiply: ");
                                        double mulNum2 = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Product is " + mulNum1 * mulNum2);
                                        break;
                                    }

                                case "%":
                                    {
                                        Console.Write("Enter first number: ");
                                        double modNum1 = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Enter second number: ");
                                        double modNum2 = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Modulus is " + modNum1 % modNum2);
                                        break;
                                    }

                                case "-":
                                    {
                                        Console.Write("Enter first number: ");
                                        double subNum1 = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Enter second number: ");
                                        double subNum2 = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Answer is ");
                                        Console.Write(subNum1 - subNum2);
                                        break;
                                    }

                                case "+":
                                    {
                                        Console.Write("Enter first number: ");
                                        double addNum1 = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Enter second number: ");
                                        double addNum2 = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Answer is ");
                                        Console.Write(addNum1 + addNum2);
                                        break;
                                    }
                                case "#":
                                    {
                                        Console.Write("Enter the dividend: ");
                                        double dividendNum = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Enter the divisor: ");
                                        double divisorNum = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("\nQuotient is " + dividendNum / divisorNum);
                                        break;
                                    }

                                case "Swh":
                                    goto Methods;

                                case "exit":
                                    Environment.Exit(0);
                                    break;
                                case "":
                                    Console.WriteLine("Invalid Operator, pls enter a valid operator!");
                                    break;
                                default:
                                    Console.WriteLine("Invalid Operator, pls enter a valid operator!");
                                    break;
                            }
                            goto Begin;
                        }
                        catch
                        {
                            Console.WriteLine("Unexpected Error, pls try again");
                            goto Begin;
                        }

                        }
 
                    case "S":
                        {
                        BasicMthTxt:
                            //Console.WriteLine("This module in under development, pls use the Advanced Method till then!");
                            Console.WriteLine("\n\nAvailable Functions: \nSquareroot (S)\nRounding-off (R)\nCuberoot (C)\nChecking Prime Numbers (P)\nExponents (E)\nSwitch Method (W)\nTerminate CLI (T)\nShow this list again (L)");
                        function:
                            Console.Write("\nChoose the function you want to use: ");
                            string funcTion = Console.ReadLine();
                            try
                            {
                                switch (funcTion)
                                {
                                    case "S":
                                        {
                                            Console.Write("Enter your desired number: ");
                                            double sqNum = Convert.ToDouble(Console.ReadLine());
                                            Console.Write("\nSquareroot of " + sqNum + " is ");
                                            Console.Write(Math.Sqrt(sqNum));
                                            goto function;
                                        }

                                    case "R":
                                        {
                                            Console.Write("Enter the number you want to round-off: ");
                                            double rndNum = Convert.ToDouble(Console.ReadLine());
                                            Console.Write("\nRounding-off " + rndNum + " gives ");
                                            Console.Write(Math.Round(rndNum));
                                            goto function;
                                        }

                                    case "C":
                                        {
                                            Console.Write("Enter your desired number: ");
                                            double cbNum = Convert.ToDouble(Console.ReadLine());
                                            Console.Write("\nCuberoot of " + cbNum + " is ");
                                            Console.Write(Math.Cbrt(cbNum));
                                            goto function;
                                        }
                                    case "P":
                                        int n, i, m = 0, flag = 0;
                                        Console.Write("Enter the Number to check Prime: ");
                                        n = int.Parse(Console.ReadLine());
                                        m = n / 2;
                                        for (i = 2; i <= m; i++)
                                        {
                                            if (n % i == 0)
                                            {
                                                Console.Write("Number is not Prime.");
                                                flag = 1;
                                                goto function;
                                            }
                                        }
                                        if (flag == 0)
                                        {
                                            Console.Write("Number is Prime.");
                                            goto function;
                                        }
                                        break;

                                    case "E":
                                    {
                                        Console.Write("Enter base number: ");
                                        double base_num = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Enter power/exponent: ");
                                        double pow_num = Convert.ToDouble(Console.ReadLine());
                                        double result = Math.Pow(base_num, pow_num);
                                        Console.WriteLine("The answer is " + result);
                                        goto function;
                                    }
                                    case "L":
                                        goto BasicMthTxt;
                                    case "W":
                                        goto Methods;
                                    case "T":
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        Console.WriteLine("Pls enter a valid function!");
                                        goto function;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Unexpected Error, pls try again!");
                                goto function;
                            }
                            break;
                        }

                    case "RMM":
                        goto Application;
                    case "exit":
                        Environment.Exit(0);
                        break;
                }
        }
    }
}
