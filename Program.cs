using System;
using System.Diagnostics;
using MailKit.Security;
using MimeKit;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Common;
using System.IO;
using System.Net.NetworkInformation;

namespace AdvancedCLIApplication
{
    class Program
    {

        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
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
        public enum CoinSide
        {
            Heads = 0,
            Tails = 1
        }
        
        public static async Task Main(string[] args)
        {

            Console.Write("Enter your name: ");
            string fname = Console.ReadLine();

            if (fname == "")
            {
                fname = "User";
            }
            string versionNum = "v1.9.0";
            string theme = "Winter";
            Console.WriteLine("Hello " + fname + ", Welcome to Blaze Devs Advanced CLI Application! \nVersion: " + versionNum + "\nSeason/Theme: " + theme + "\nHappy New Year 2023!");


        Application:
            Console.Write("\nAvailable Applications: Calculator (A) | Clock (C) | Calendar (D) | Internet Activities (E) |\nInteresting Stuff (G) | Terminate CLI (I) |\nChoose your desired application: ");
            string applicationIn = Console.ReadLine();

            switch (applicationIn)
            {

                case "A":
                    goto Methods;
                case "C":
                    goto Clock;
                case "D":
                    goto Calendar;
                case "E":
                ActivityManager:
                    {                    
                        Console.WriteLine("\nAvailable Activities: Search Engines(A) | Email(B) | YouTube Downloader(C) | Give Feedback On This App(D) | About The App Developer(E) | Internet Availability Checker (F) | Switch Application(S) | Terminate CLI(T)");
                        Console.Write("Choose your desired activity: ");
                        string activityApp = Console.ReadLine();
                        switch(activityApp)
                        {
                            case "A":
                                {
                                    goto SearchModule;
                                }
                            case "B":
                                {
                                    goto MailLib2;
                                }
                            case "C":
                                {
                                    goto YTdlLib;
                                }
                            case "D":
                                {
                                    Process procweb = new Process();
                                    procweb.StartInfo.UseShellExecute = true;
                                    procweb.StartInfo.FileName = "https://blazedevs.dynu.com/Contact.aspx";
                                    procweb.Start();
                                    Console.WriteLine("Opened the Feedback page on your web browser");
                                    goto ActivityManager;
                                }
                            case "E":
                                {
                                    Process procAb = new Process();
                                    procAb.StartInfo.UseShellExecute = true;
                                    procAb.StartInfo.FileName = "https://blazedevs.dynu.com/aboutme.html";
                                    procAb.Start();
                                    Console.WriteLine("Opened the Developer's About page on your web browser");
                                    goto ActivityManager;
                                }
                            case "S":
                                {
                                    goto Application;
                                }
                            case "T":
                                {
                                    Environment.Exit(0);
                                    break;
                                }
                            case "F":
                                {
                                    goto InterNetChecker;
                                }
                            default:
                                Console.WriteLine("Pls enter a valid activity!");
                                goto ActivityManager;

                        }
                        break;
                    }                 
                case "G":
                    goto InterestingLib;
                case "H":
                    goto MailLib2;
                case "I":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Pls enter a valid application!");
                    goto Application;
            }
           InterNetChecker:
            string intStatus;
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    intStatus = "Internet is available :) | You can use our Internet Activities!";
                    Console.WriteLine(intStatus + "\n");
                    goto Application;
                }
                else
                {
                    intStatus = "Internet is not available :( | Please fix your Internet connection!";
                    Console.WriteLine(intStatus + "\n");
                    goto Application;
                }
            }
            catch (Exception e)
            {
                intStatus = "Error checking internet availability!" + "\nError Details: " + e.Message;
                Console.WriteLine(intStatus + "\n");
                goto Application;
            }

        YTdlLib:
            try
            {

                string machineUserN = Environment.UserName;
                var youtubeClient = new YoutubeExplode.YoutubeClient();
                Console.WriteLine("Disclaimer: This module requires FFmpeg to be installed in your PC! |\n if not installed then refer to this article: https://www.geeksforgeeks.org/how-to-install-ffmpeg-on-windows/");
                Console.WriteLine("\nAvailable Options: Download a video (V) | Download a playlist (P) | Return To Main Menu (R) | Terminate CLI (T)");
                Console.Write("Choose your desired download option: ");
                string downloadOpts = Console.ReadLine();
                switch (downloadOpts)
                {
                    case "V":
                        {
                        YTVD:
                            try
                            {

                                Console.Write("Enter the video URL: ");
                                string videoURI = Console.ReadLine();


                                var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(videoURI);

                                var audioStreamInfo = streamManifest.GetAudioStreams().GetWithHighestBitrate();
                                var videoStreamInfo = streamManifest.GetVideoStreams().GetWithHighestVideoQuality();
                                var streamInfos = new IStreamInfo[] { audioStreamInfo, videoStreamInfo };
                                Console.Write("\nEnter the desired file name for your download(video1 by default): ");
                                string fileNameV = Console.ReadLine();
                                if (fileNameV == "")
                                {
                                    fileNameV = "video1";
                                }
                                Console.Write("\nEnter the desired location for your download(Downloads by default): ");
                                string downPath = Console.ReadLine();
                                if (downPath == "")
                                {
                                    downPath = "C:\\Users\\" + machineUserN + "\\Downloads\\";
                                    Console.WriteLine("Download Path: " + downPath);
                                }
                                Console.Write("\nDo you want to download the video captions too[Y/N](N by default): ");
                                string resV = Console.ReadLine();
                                switch (resV)
                                {
                                    case "Y":
                                        {
                                            var trackManifest = await youtubeClient.Videos.ClosedCaptions.GetManifestAsync(videoURI);
                                            var trackInfoV = trackManifest.TryGetByLanguage("en");
                                            if (trackInfoV == null)
                                            {
                                                Console.WriteLine("\nNo english captions available!");
                                                Console.WriteLine("\nProceeding with video download...");
                                            }
                                            else
                                            {
                                                Console.WriteLine("English captions are available!");
                                                Console.Write("\nEnter a name for the captions file: ");
                                                string ccName = Console.ReadLine();
                                                if (ccName == "")
                                                {
                                                    ccName = fileNameV + ".srt";
                                                }
                                                var trackV = await youtubeClient.Videos.ClosedCaptions.GetAsync(trackInfoV);
                                                Console.WriteLine("Downloading... ");
                                                await youtubeClient.Videos.ClosedCaptions.DownloadAsync(trackInfoV, downPath + ccName);
                                                Console.WriteLine("Captions downloaded at " + downPath + " with name " + ccName);
                                                Console.WriteLine("Proceeding with video download...");
                                            }
                                            break;
                                        }
                                    case "N":
                                        {
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                                Console.WriteLine("\nDownloading...");
                                await youtubeClient.Videos.DownloadAsync(videoURI, new ConversionRequestBuilder(downPath + fileNameV + ".mp4").Build());

                                Console.WriteLine("Video has been downloaded successfully at " + downPath + " with the name " + fileNameV + ".mp4");
                                Console.WriteLine("Exiting Video Download Library...");
                                Console.WriteLine("\n");

                                goto YTdlLib;

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Unexpected error occurred!");
                                Console.WriteLine("Error Details: " + e.Message);
                                goto YTVD;
                            }
                        }
                    case "P":
                        {
                        YTPL:
                            try
                            {

                                string machineUserP = Environment.UserName;
                                var YTclient = new YoutubeExplode.YoutubeClient();
                                Console.Write("Enter your playlist URL: ");
                                string playlistURI = Console.ReadLine();
                                var playlistMeta = await YTclient.Playlists.GetAsync(playlistURI);
                                var playlistName = playlistMeta.Title;

                                Console.Write("\nChoose a download location for the playlist (Downloads by default): ");
                                string downPathP = Console.ReadLine();

                                if (downPathP == "")
                                {
                                    string downs = "C:\\Users\\" + machineUserN + "\\Downloads";
                                    downPathP = "C:\\Users\\" + machineUserN + "\\Downloads\\" + playlistName;
                                    if (!Directory.Exists(downPathP))
                                    {
                                        Directory.CreateDirectory(downPathP);
                                    }
                                    Console.WriteLine("Download Path: " + downPathP);
                                }
                                Console.Write("Choose a filename for the downloads(a number sequence will be appended)[video by default]: ");
                                string fileNameP = Console.ReadLine();
                                string fileNameT = fileNameP;
                                if (fileNameP == "")
                                {
                                    fileNameP = "video";
                                }
                                var i = 1;
                                await foreach (var videoP in YTclient.Playlists.GetVideosAsync(playlistURI))
                                {

                                    fileNameP = fileNameT + i;
                                    i = i + 1;
                                    var streamsManifest = await YTclient.Videos.Streams.GetManifestAsync(videoP.Id);
                                    var audioStreamInfo = streamsManifest.GetAudioStreams().GetWithHighestBitrate();
                                    var videoStreamInfo = streamsManifest.GetVideoStreams().GetWithHighestVideoQuality();
                                    var streamInfos = new IStreamInfo[] { audioStreamInfo, videoStreamInfo };
                                    Console.WriteLine("Downloading " + fileNameP + "...");
                                    await YTclient.Videos.DownloadAsync(videoP.Id, new ConversionRequestBuilder(downPathP + fileNameP + ".mp4").Build());
                                    Console.WriteLine("Downloaded successfully at " + downPathP);
                                }
                                Console.WriteLine("Playlist Downloaded Successfully!");
                                Console.WriteLine("Exiting Playlist Download Library...");
                                goto YTdlLib;

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Unexpected error occurred!");
                                Console.WriteLine("Error Details: " + e.Message);
                                goto YTPL;
                            }
                        }
                    case "R":
                        {
                            goto Application;
                        }
                    case "T":
                        {
                            Environment.Exit(0);
                            break;
                        }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error occurred: ");
                Console.WriteLine("Error Details: " + e.Message);
                Console.WriteLine("Returning to YouTube Downloader Library...");
                Console.WriteLine("\n");
                goto YTdlLib;
            }

        MailLib2:
            try
            {

                SmtpClient client = new SmtpClient();
                MimeMessage message = new MimeMessage();

                Console.WriteLine("\nAvailable Options: Send an Email (E) | Return to Main Menu (M) | Terminate CLI (T)");
                Console.Write("Choose your desired option: ");
                string mailOpts = Console.ReadLine();

                switch (mailOpts)
                {
                    case "E":
                        {
                            Console.WriteLine("\nWelcome to Blaze Devs FilumMail service");
                        //Server Credentials
                        MailServer:
                            Console.WriteLine("Available Mail Server Options: Gmail (G) | Outlook (O) | Custom Mail Server (C) ");
                            Console.Write("Choose your desired mail server: ");
                            string mailServer = Console.ReadLine();
                            switch (mailServer)
                            {
                                case "G":
                                    Console.WriteLine("Alert: Gmail now requires app passwords for sending mail using SMTP so use your generated app password to send email");
                                    Console.WriteLine("Check this article to generate app passwords: https://support.google.com/accounts/answer/185833");
                                    await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTlsWhenAvailable);
                                    break;
                                case "O":
                                    await client.ConnectAsync("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                                    break;
                                case "C":
                                    Console.Write("\nEnter the hostname of your mailserver: ");
                                    string hostName = Console.ReadLine();
                                    Console.Write("Enter the TLS port number of your mailserver: ");
                                    int portTLS = Convert.ToInt32(Console.ReadLine());
                                    await client.ConnectAsync(hostName, portTLS, SecureSocketOptions.StartTls);
                                    break;
                                default:
                                    Console.WriteLine("Invalid selection, please try again!");
                                    goto MailServer;
                            }
                            //Mail Credentials
                            Console.Write("\nEnter your login email address: ");
                            string credMail = Console.ReadLine();
                            Console.Write("Enter your login password: ");
                            string credPass = Console.ReadLine();
                            await client.AuthenticateAsync(
                                userName: credMail,
                                password: credPass
                                );


                            //Mail Content
                            Console.Write("\nEnter your full name: ");
                            string fName = Console.ReadLine();
                            Console.Write("\nEnter your email address: ");
                            string senderMail = Console.ReadLine();
                            Console.Write("\nEnter the receiver's email address: ");
                            string receiverMail = Console.ReadLine();
                            Console.Write("\nEnter the subject of your email: ");
                            string mailSubject = Console.ReadLine();
                            Console.Write("\nEnter the body of your email: ");
                            string mailBody = Console.ReadLine();
                            Console.Write("\nEnter the path for any attachments(if not then leave the field blank): ");
                            string mailAttach = Console.ReadLine();
                            if (mailAttach == "")
                            {
                                var bodyA = new BodyBuilder();
                                bodyA.TextBody = mailBody;
                                bodyA.HtmlBody = mailBody;
                                message.Body = bodyA.ToMessageBody();
                                Console.WriteLine("No Attachment Selected!");
                            }
                            else
                            {
                                Console.WriteLine("Attachment selected! FilePath is " + mailAttach);
                                var body = new BodyBuilder();
                                body.TextBody = mailBody;
                                body.HtmlBody = mailBody;
                                body.Attachments.Add(mailAttach);
                                message.Body = body.ToMessageBody();
                            }
                            message.From.Add(new MailboxAddress(
                                fName,
                                senderMail
                                ));
                            message.To.Add(new MailboxAddress(
                                "",
                                receiverMail
                                ));

                            message.Subject = mailSubject;

                            Console.WriteLine("Sending mail... ");
                            await client.SendAsync(message);
                            Console.WriteLine("\nMail sent successfully!");
                            await client.DisconnectAsync(true);

                            goto MailLib2;

                        }
                    case "M":
                        {
                            goto Application;
                        }
                    case "T":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Selection, please try again!");
                            goto MailLib2;
                        }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("\nUnexpected error occurred! Please try again!");
                Console.WriteLine("Error Details: " + e.Message);
                goto MailLib2;
            }


        InterestingLib:
            Console.Write("\nAvailable Options: Free Surprise (A) | Roll A Dice (B) | Flip a coin (C) | Random Generator (D) | Return To Main Menu (E)\nChoose your desired option:");
            string IntLibO = Console.ReadLine();
            switch (IntLibO)
            {
                case "A":
                    Console.WriteLine("Enjoy your surprise friend!");
                    Process procj = new Process();
                    procj.StartInfo.UseShellExecute = true;
                    procj.StartInfo.FileName = "https://t.ly/q4IX";
                    procj.Start();
                    goto InterestingLib;
                case "B":
                    Random dice = new Random();
                    int roll1 = dice.Next(1, 7);
                    int roll2 = dice.Next(1, 7);
                    int result = roll1 + roll2;
                    Console.WriteLine($"First dice roll: {roll1}");
                    Console.WriteLine($"Second dice roll: {roll2}");
                    Console.WriteLine($"Total of dice rolls: {roll1} + {roll2} = {result}");
                    goto InterestingLib;
                case "C":
                    Console.Write("Pick Heads or Tails: ");
                    var userInput = Console.ReadLine();

                    //Create and flip the coin
                    var rng = new Random();
                    var coin = (CoinSide)rng.Next(0, 2);

                    //Compare input to coin
                    if (coin.ToString() == userInput)
                        Console.WriteLine("You picked Right! {0}! ", coin);
                    else
                        Console.WriteLine("You picked Wrong! it was {0}", coin);
                    goto InterestingLib;
                case "D":
                    goto RandomLib;
                case "E":
                    goto Application;
                default:
                    Console.WriteLine("Pls enter a valid option!!!");
                    goto InterestingLib;
            }
        RandomLib:
            try
            {
                Console.WriteLine("\nAvailable Options:\nGenerate Random Number (A)\nGenerate Random Text (B)\nReturn To Main Menu (C)\n");
                Console.Write("Choose your desired option: ");
                string RandOpts = Console.ReadLine();
                Random rand = new Random();
                switch (RandOpts)
                {
                    case "A":
                        {
                            Console.Write("Choose length of the number: ");
                            int len = Convert.ToInt32(Console.ReadLine());
                            int randNum = rand.Next(1, len);
                            Console.WriteLine("\nRandom Number: " + randNum + "\n");
                            goto RandomLib;
                        }
                    case "B":
                        {
                            Console.Write("Do you want alphanumeric string? (Yes)/(No) : ");
                            string alphanumB = Console.ReadLine();
                            switch (alphanumB)
                            {
                                case "Yes":
                                    {
                                        Console.Write("Choose your desired alphanumeric string length: ");
                                        int size = Convert.ToInt32(Console.ReadLine());
                                        Random res = new Random();
                                        if (size > 1200)
                                        {
                                            Console.WriteLine("Maximum String Length is 1200, dont exceed that limit! ");
                                            goto RandomLib;
                                        }

                                        // String that contain both alphabets and numbers
                                        String alphastr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                                        // Initializing the empty string
                                        String randomstring = "";

                                        for (int i = 0; i < size; i++)
                                        {

                                            // Selecting a index randomly
                                            int x = res.Next(alphastr.Length);

                                            // Appending the character at the 
                                            // index to the random alphanumeric string.
                                            randomstring = randomstring + alphastr[x];
                                        }
                                        Console.WriteLine("Random alphanumeric String:" + randomstring);
                                        goto RandomLib;
                                    }
                                case "No":
                                    {
                                        Console.Write("Choose your desired string length: ");
                                        long strlen = Convert.ToInt64(Console.ReadLine());
                                        if (strlen > 1200)
                                        {
                                            Console.WriteLine("Maximum String Length is 1200, dont exceed that limit! ");
                                            goto RandomLib;
                                        }
                                        Random res = new Random();

                                        // String of alphabets 
                                        String textstr = "abcdefghijklmnopqrstuvwxyz";

                                        // Initializing the empty string
                                        String ran = "";

                                        for (int i = 0; i < strlen; i++)
                                        {

                                            // Selecting a index randomly
                                            int x = res.Next(textstr.Length);

                                            // Appending the character at the 
                                            // index to the random string.
                                            ran = ran + textstr[x];
                                        }
                                        Console.WriteLine("Random String:" + ran);
                                        goto RandomLib;
                                    }
                                default:
                                    Console.WriteLine("Pls enter a valid option");
                                    goto RandomLib;
                            }
                        }
                    case "C":
                        {
                            goto Application;
                        }
                    default:
                        Console.WriteLine("Pls enter a valid option!");
                        goto RandomLib;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error occurred");
                goto RandomLib;
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
                Console.Write("Choose an year(chooses the current year by default): ");
                string yearIn = Console.ReadLine();
                int yearNum;

                if ((yearIn.Length < 1) && (yearIn.Length > 4) && (IsNumeric(yearIn) == false))
                {
                    yearNum = DateTime.Now.Year;

                }
                else
                {
                    yearNum = Convert.ToInt32(yearIn);



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
            catch (Exception e)
            {
                Console.WriteLine("Oops something went wrong!");
                Console.WriteLine(e.Message);
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
                goto Clock;
            }


        //Calculator Modules
        Methods:

            Console.WriteLine("\nAvailable Methods: Scientific (S) | Arithmetic (A) | Programmer (P) | Unit Convertor (U) | Return to Main Menu (R) | Terminate CLI (E) ");
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
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Input string was not in a correct format.");
                                        }
                                        catch (InvalidOperationException)
                                        {
                                            Console.WriteLine("Not a valid numbers to perform operation");
                                        }
                                        catch (DivideByZeroException)
                                        {
                                            Console.WriteLine("Cannot Divide By Zero as it gives the result as infinity");
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

                case "R":
                    {
                        goto Application;
                    }
                case "E":
                    {
                        Environment.Exit(0);
                        break;
                    }
                case "P":
                    {
                    ProMthTxt:
                        Console.WriteLine("\n\nAvailable Functions: \nBinary, Decimal, Octal, Hexadecimal Conversions (B)\nByte Conversions(C)\nSwitch Method (W)\nTerminate CLI (T)\nShow this list again (L)");

                    ProMthFunctions:
                        Console.Write("\nChoose your desired function: ");
                        string ProMthOpts = Console.ReadLine();
                        switch (ProMthOpts)
                        {
                            case "B":
                                {
                                BDOHConvos:
                                    try
                                    {
                                        Console.WriteLine("\nAvailable Conversions: \nBinary To Decimal, Hexadecimal, Octal(B) \nDecimal To Binary, Hexadecimal, Octal(D) \nOctal To Binary, Hexadecimal, Decimal(O) \nHexadecimal To Binary, Octal, Decimal(H) \nReturn To Programmer Calculator (R) \nTerminate CLI(T)");
                                        Console.Write("\nChoose your desired conversion: ");
                                        string conversionsPro = Console.ReadLine();
                                        switch (conversionsPro)
                                        {
                                            case "B":
                                                {
                                                    Console.Write("Enter the desired binary number: ");
                                                    int num = Convert.ToInt32(Console.ReadLine());
                                                    Console.Write("Decimal: ");
                                                    Console.Write(Convert.ToString(num, 10));
                                                    Console.Write("\n");
                                                    Console.Write("Octal: ");
                                                    Console.Write(Convert.ToString(num, 8));
                                                    Console.Write("\n");
                                                    Console.Write("Hexadecimal: ");
                                                    Console.Write(Convert.ToString(num, 16));
                                                    Console.Write("\n");
                                                    goto BDOHConvos;
                                                }
                                            case "D":
                                                {
                                                    Console.Write("Enter the desired decimal number: ");
                                                    int num1 = Convert.ToInt32(Console.ReadLine());
                                                    Console.Write("Binary: ");
                                                    Console.Write(Convert.ToString(num1, 2));
                                                    Console.Write("\n");
                                                    Console.Write("Octal: ");
                                                    Console.Write(Convert.ToString(num1, 8));
                                                    Console.Write("\n");
                                                    Console.Write("Hexadecimal: ");
                                                    Console.Write(Convert.ToString(num1, 16));
                                                    Console.Write("\n");
                                                    goto BDOHConvos;
                                                    
                                                }
                                            case "O":
                                                {
                                                    Console.Write("Enter the desired octal number: ");
                                                    int num2 = Convert.ToInt32(Console.ReadLine());
                                                    Console.Write("Binary: ");
                                                    Console.Write(Convert.ToString(num2, 2));
                                                    Console.Write("\n");
                                                    Console.Write("Hexadecimal: ");
                                                    Console.Write(Convert.ToString(num2, 16));
                                                    Console.Write("\n");
                                                    Console.Write("Decimal: ");
                                                    Console.Write(Convert.ToString(num2, 10));
                                                    Console.Write("\n");
                                                    goto BDOHConvos;
                                                }
                                            case "H":
                                                {
                                                    Console.Write("Enter the desired hexadecimal number: ");
                                                    string num3 = Console.ReadLine();
                                                    Console.Write("Binary: ");
                                                    Console.Write(Convert.ToInt32(num3, 2));
                                                    Console.Write("\n");
                                                    Console.Write("Octal: ");
                                                    Console.Write(Convert.ToInt32(num3, 8));
                                                    Console.Write("\n");
                                                    Console.Write("Decimal: ");
                                                    Console.Write(Convert.ToInt32(num3, 10));
                                                    Console.Write("\n");
                                                    goto BDOHConvos;
                                                }
                                            case "R":
                                                {
                                                    goto ProMthFunctions;
                                                }
                                            case "T":
                                                {
                                                    Environment.Exit(0);
                                                    break;
                                                }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Unexpected error occurred!");
                                        Console.WriteLine("Error Details: " + e.Message);
                                        goto BDOHConvos;
                                    }
                                    goto BDOHConvos;
                                }
                            case "C":
                                {
                                    Console.WriteLine("This library is currently under development, please use other libraries for now!");
                                    Console.WriteLine("Exiting Byte Conversion Library...");
                                    //Console.WriteLine("Available Conversions:-");
                                    //Console.WriteLine("Bits To B, KB, MB, GB, TB (BI)");
                                    //Console.WriteLine("B To Bits, KB, MB, GB, TB (B)");
                                    //Console.WriteLine("KB To Bits, B, MB, GB, TB (KB)");
                                    //Console.WriteLine("MB To Bits, B, KB, GB, TB (MB)");
                                    //Console.WriteLine("GB To Bits, B, KB, MB, TB (GB)");
                                    //Console.WriteLine("TB To Bits, B, KB, MB, GB (TB)");

                                    //Console.Write("Choose your desired conversion: ");
                                    //string bcOpts = Console.ReadLine();
                                    //switch(bcOpts)
                                    //{
                                    //    case "BI":
                                    //        {
                                    //            Console.Write("Enter the bits: ");
                                    //            double bitsBI = Convert.ToDouble(Console.ReadLine());
                                    //            double byteBI = bitsBI / 8;
                                    //            double kbBI = byteBI / 1024;
                                    //            double mbBI = kbBI / 1024;


                                    //        }
                                    //    case "B":
                                    //        {

                                    //        }
                                    //    case "KB":
                                    //        {

                                    //        }
                                    //    case "MB":
                                    //        {

                                    //        }
                                    //    case "GB":
                                    //        {

                                    //        }
                                    //    case "TB":
                                    //        {

                                    //        }


                                    //}
                                    goto ProMthTxt;
                                }
                            case "W":
                                {
                                    goto Methods;
                                }
                            case "T":
                                {
                                    Environment.Exit(0);
                                    break;
                                }
                            case "L":
                                {
                                    goto ProMthTxt;
                                }

                        }
                        break;


                    }
                case "U":
                    goto UnitConversions;
            }
            //Function for generating different permutations of the string  
            static void generatePermutation(String str, int start, int end)
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
}
