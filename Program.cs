using System;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.IO;

namespace CoolCalculator
{
    class Program
    {      
    //Function for swapping the characters at position I with character at position j  
        public static String swapString(String a, int i, int j)
        {
            char[] b = a.ToCharArray();
            char ch;
            ch = b[i];
            b[i] = b[j];
            b[j] = ch;
            //Converting characters from array into single string  
            return string.Join("", b);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string fname = Console.ReadLine();

            if (fname == "")
            {
                fname = "User";
            }
            string versionNum = "v1.6.0";
            string theme = "Summer";
            Console.WriteLine("Hello " + fname + ", Welcome to Blaze Devs Advanced CLI Application! \nVersion: " + versionNum + "\nSeason/Theme: " + theme);

            Application:
            Console.Write("Available Applications: Calculator (A) | Unit Conversions (B) | Clock (C) | Calendar (D) | Search Engines (E) |\nTerminate CLI (F) | Give Feedback (G)| About The Developer (H) | Interesting Stuff (J)\nChoose your desired application: ");
            string applicationIn = Console.ReadLine();

            switch (applicationIn)
            {

                case "A":
                    goto Methods;
                case "B":
                    goto UnitConversions;
                case "C":
                    goto Clock;
                case "D":
                    goto Calendar;
                case "E":
                    goto SearchModule;
                case "F":
                    Environment.Exit(0);
                    break;
                case "G":
                    Process procweb = new Process();
                    procweb.StartInfo.UseShellExecute = true;
                    procweb.StartInfo.FileName = "https://blazedevs.dynu.com/Contact.aspx";
                    procweb.Start();
                    goto Application;
                case "H":
                    Process procAb = new Process();
                    procAb.StartInfo.UseShellExecute = true;
                    procAb.StartInfo.FileName = "https://blazedevs.dynu.com/aboutme.html";
                    procAb.Start();
                    goto Application;
                case "J":
                    Process procj = new Process();
                    procj.StartInfo.UseShellExecute = true;
                    procj.StartInfo.FileName = "https://t.ly/q4IX";
                    procj.Start();
                    goto Application;
                default:
                    Console.WriteLine("Pls enter a valid application!");
                    goto Application;
            }
        //Unit Conversions
        UnitConversions:
            Console.WriteLine("Available Conversions:\nTemperature Conversions (TC)\nWeight Conversions (WC)\nReturn To Main Menu (RMM)");
            Console.Write("Choose your desired conversion: ");
            string UnConvers = Console.ReadLine();
            switch (UnConvers)
            {
                case "TC":
                    {
                    TempConvertor:
                        try
                        {
                            Console.Write("\nAvailable Conversions:-\nFahrenheit To Celsius (FC)\nCelsius to Fahrenheit (CF)\nReturn To Main Menu (RMM)\n\nChoose your desired conversion: ");
                            string TempConver = Console.ReadLine();
                            switch (TempConver)
                            {
                                case "CF":
                                    Console.Write("Enter the Celsius Temperature: ");
                                    double cTemp = Convert.ToDouble(Console.ReadLine());
                                    double fTemp = ((cTemp * 9) / 5) + 32;
                                    Console.WriteLine("Temperature in Fahrenheit: " + fTemp);
                                    goto TempConvertor;
                                case "FC":
                                    Console.Write("Enter the Fahrenheit Temperature: ");
                                    double fTemp1 = Convert.ToDouble(Console.ReadLine());
                                    double cTemp1 = (fTemp1 - 32) * 5 / 9;
                                    Console.WriteLine("Temperature in Celsius: " + cTemp1);
                                    goto TempConvertor;
                                case "RMM":
                                    goto UnitConversions;
                                default:
                                    Console.WriteLine("Pls enter a valid conversion!");
                                    goto TempConvertor;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Pls enter a valid input!");
                            goto TempConvertor;
                        }
                    }
                case "WC":
                    {
                    WeghConver:
                        try
                        {
                            Console.WriteLine("\nAvailable Conversions:\nKG To Grams (G)\nGrams To KG (K)\nReturn To Main Menu (RMM)");
                            Console.Write("Enter your desired conversion: ");
                            string WeightConver = Console.ReadLine();
                            switch (WeightConver)
                            {
                                case "G":
                                    {
                                        Console.Write("Enter weight in grams: ");
                                        float grams = Convert.ToInt64(Console.ReadLine());
                                        float kilograms = grams / 1000;
                                        Console.WriteLine("Weight in kilograms is " + kilograms);
                                        goto WeghConver;
                                    }
                                case "K":
                                    {
                                        Console.Write("Enter weight in kilograms: ");
                                        float kilograms = Convert.ToInt64(Console.ReadLine());
                                        float grams = kilograms * 1000;
                                        Console.WriteLine("Weight in grams is " + grams);
                                        goto WeghConver;
                                    }
                                case "RMM":
                                    goto UnitConversions;
                                default:
                                    Console.WriteLine("Pls enter a valid conversion!");
                                    goto WeghConver;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Unexpected error occurred");
                            goto WeghConver;
                        }
                    }
                        
                case "RMM":
                    {
                        goto Application;
                    }
                default:
                    Console.WriteLine("Pls enter a valid conversion");
                    goto UnitConversions;
            }
        //Search Modules
        SearchModule:
            Console.WriteLine("Available Options & Search Engines:- \nGoogle (G)\nBing (B)\nYahoo (Y)\nDuckDuckGo (D)\nAsk (A)\nAol (AO)\nWikipedia (W)\nReturn To Main Menu (RMM)\nTerminate CLI (T)");
         FunctionsS:
            Console.Write("Choose your search engine: ");
            string searche = Console.ReadLine();
            Console.Write("Enter your query:");
            string query = Console.ReadLine();
            switch (searche)
            {
                case "G":
                    Process procG = new Process();
                    procG.StartInfo.UseShellExecute = true;
                    procG.StartInfo.FileName = "https://google.com/search?q=" + query;
                    procG.Start();
                    goto FunctionsS;
                case "B":
                    Process procB = new Process();
                    procB.StartInfo.UseShellExecute = true;
                    procB.StartInfo.FileName = "https://www.bing.com/search?q=" + query;
                    procB.Start();
                    goto FunctionsS;
                case "Y":
                    Process procY = new Process();
                    procY.StartInfo.UseShellExecute = true;
                    procY.StartInfo.FileName = "https://search.yahoo.com/search?q=" + query;
                    procY.Start();
                    goto FunctionsS;
                case "D":
                    Process procD = new Process();
                    procD.StartInfo.UseShellExecute = true;
                    procD.StartInfo.FileName = "https://duckduckgo.com/?q=" + query;
                    procD.Start();
                    goto FunctionsS;
                case "A":
                    Process procA = new Process();
                    procA.StartInfo.UseShellExecute = true;
                    procA.StartInfo.FileName = "https://www.ask.com/web?q=" + query;
                    procA.Start();
                    goto FunctionsS;
                case "AO":
                    Process procAO = new Process();
                    procAO.StartInfo.UseShellExecute = true;
                    procAO.StartInfo.FileName = "https://search.aol.com/search?q=" + query;
                    procAO.Start();
                    goto FunctionsS;
                case "W":
                    Process procW = new Process();
                    procW.StartInfo.UseShellExecute = true;
                    procW.StartInfo.FileName = "https://en.wikipedia.org/w/?search=" + query;
                    procW.Start();
                    goto FunctionsS;
                case "RMM":
                    goto Application;
                case "T":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Pls enter a valid search engine!");
                    goto FunctionsS;
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
                            Console.WriteLine("\n\nAvailable Functions: \nSquareroot (S)\nRounding-off (R)\nCuberoot (C)\nChecking Prime Numbers (P)\nPermutations (PE)\nExponents (E)\nArea of a rectangle (A)\nVolume of a circle (V)\nStrike Rate In Cricket (SR)\nSwitch Method (W)\nTerminate CLI (T)\nShow this list again (L)");
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
                                case "PE":
                                    {
                                        String str;
                                        Console.Write("Enter your desired string here:");
                                        str = Console.ReadLine();
                                        int len = str.Length;
                                        Console.WriteLine("All the permutations of the string are: ");
                                        generatePermutation(str, 0, len);
                                        goto function;
                                    }
                                case "A":
                                    {
                                        Console.Write("Enter the width of the rectangle: ");
                                        double width = Convert.ToDouble(Console.ReadLine());
                                        Console.Write("Enter the height of the rectangle: ");
                                        double height = Convert.ToDouble(Console.ReadLine());
                                        double answer = width * height;
                                        Console.WriteLine("Area of the rectangle: " + answer);
                                        goto function;
                                    }
                                case "V":
                                    {
                                        Console.Write("Enter the radius of the circle: ");
                                        double radius = Convert.ToDouble(Console.ReadLine());
                                        double pi = 3.14285714286;
                                        double volume = (4.0 / 3.0) * pi * (radius * radius * radius);
                                        Console.WriteLine("Volume of the circle: " + volume);
                                        goto function;
                                    }                                   
                                case "SR":
                                    {
                                        int runs, balls;
                                        double strikerate;
                                        Console.Write("Enter total runs: ");
                                        runs = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Enter total balls: ");
                                        balls = Convert.ToInt32(Console.ReadLine());
                                        strikerate = (runs / balls) * 100;
                                        Console.WriteLine("Strike rate is " + strikerate);
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
        //Function for generating different permutations of the string  
        public static void generatePermutation(String str, int start, int end)
        {
            //Prints the permutations  
            if (start == end - 1)
                Console.WriteLine(str);
            else
            {
                for (int i = start; i < end; i++)
                {
                    //Swapping the string by fixing a character  
                    str = swapString(str, start, i);
                    //Recursively calling function generatePermutation() for rest of the characters   
                    generatePermutation(str, start + 1, end);
                    //Backtracking and swapping the characters again.  
                    str = swapString(str, start, i);
                }
            }
        }
    }
}
