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
            string versionNum = "v1.0.8";
            Console.WriteLine("Hello " + fname + ", Welcome to Blaze Devs Advanced CLI Application! \nVersion: " + versionNum);

            Application:
            Console.Write("Available Applications: Calculator | GuessingGame | Clock | Calendar | Terminate CLI (exit) | Help \nChoose your desired application: ");
            string applicationIn = Console.ReadLine();

            switch (applicationIn)
            {

                case "Calculator":
                    goto Methods;
                case "GuessingGame":
                    Console.WriteLine("This module is currently under development");
                    goto Application;
                case "Clock":
                    goto Clock;
                case "exit":
                    Environment.Exit(0);
                    break;
                case "Help":
                    Console.WriteLine("This module is currently under development");
                    goto Application;
                case "Calendar":
                    goto Calendar;
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
            Console.WriteLine("\nAvailable Methods: Basic | Arithmetic (Athm) | Return to Main Menu (RMM) (By Default Arithmetic method is selected) ");
            Console.Write("Choose a method: ");
            string methodType = Console.ReadLine();

            if (methodType == "")
            {
                methodType = "Athm";
            }

            else if (methodType == "Athm") 
            {
                Console.WriteLine("\nCurrent Method: Arithmetic");
                Console.WriteLine("Available Operators: \nFor Addition: + \nFor Subtraction: - \nFor Division: # \nFor Division with Remainder: / \nFor Multiplication: * \nFor Modulus: % ");
                Console.WriteLine("If you want to switch method then type Switch in operation field!");
                Console.WriteLine("To Terminate CLI, type exit in operation field!");
            
            Begin:

                try
                {
                    Console.Write("\nChoose your operation: ");
                    string operationIn = Console.ReadLine();
                    switch (operationIn)
                    {
                        case "/":
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

                        case "Switch":
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
                }                
                catch /*(Exception e)*/
                {
                    Console.WriteLine("Unexpected Error, pls try again!");
                    //Console.WriteLine(e.Message);
                }

                goto Begin;
            }

            else if (methodType == "Basic")
            {
                BasicMth:
                //Console.WriteLine("This module in under development, pls use the Advanced Method till then!");
                Console.Write("Choose the function you want to use: ");
                string funcTion = Console.ReadLine();
                switch (funcTion)
                {
                    case "Sqrt":
                        {
                            Console.Write("Enter your desired number: ");
                            double sqNum = Convert.ToDouble(Console.ReadLine());
                            Console.Write("\nSquareroot of " + sqNum + " is ");
                            Console.Write(Math.Sqrt(sqNum));
                            goto BasicMth;
                        }

                    case "Rnd":
                        {
                            Console.Write("Enter the number you want to round-off: ");
                            double rndNum = Convert.ToDouble(Console.ReadLine());
                            Console.Write("\nRounding-off " + rndNum + " gives ");
                            Console.Write(Math.Round(rndNum));
                            goto BasicMth;
                        }

                    case "Cbrt":
                        {
                            Console.Write("Enter your desired number: ");
                            double cbNum = Convert.ToDouble(Console.ReadLine());
                            Console.Write("\nCuberoot of " + cbNum + " is ");
                            Console.Write(Math.Cbrt(cbNum));
                            goto BasicMth;
                        }
                }
            }
            else if (methodType == "RMM")
            {
                goto Application;
            }

        }
    }
}
