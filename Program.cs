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
            string versionNum = "v1.0.6";
            Console.WriteLine("Hello " + fname + ", Welcome to Blaze Devs Advanced CLI Application! \nVersion: " + versionNum);

            Application:
            Console.Write("Available Applications: Calculator | GuessingGame | Clock | Calendar | Terminate CLI (exit) | Help \nChoose your desired application: ");
            string applicationIn = Console.ReadLine();

            switch (applicationIn)
            {

                case "Calculator":
                    goto Method;
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
                        // Pad the first week with empty spaces if needed
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
        Method:
            Console.WriteLine("\nAvailable Methods: Basic | Advanced | Return to Main Menu (RMM) (By Default Advanced method is selected) ");
            Console.Write("Choose a method: ");
            string methodType = Console.ReadLine();

            if (methodType == "")
            {
                methodType = "Advanced";
            }

            if (methodType == "Advanced") 
            {
                Console.WriteLine("\nCurrent Method: Advanced");
                Console.WriteLine("Available Operators: \nFor Addition: + \nFor Subtraction: - \nFor Division: / \nFor Multiplication: * \nFor Modulus: % ");
                Console.WriteLine("If you want to switch method then type Switch in operator field!");
                Console.WriteLine("To Terminate CLI, type exit in operator field!");
            
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
                        case "exit":
                            Environment.Exit(0);
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
