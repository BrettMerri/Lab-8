using System;
using System.Collections.Generic;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true; //Declare loop to true

            //Set default foreground and background color in the console.
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Title = "Batting Average Calculator"; //Set title of the console window
            Console.WriteLine("Welcome to Batting Average Calculator!");

            while (loop) //Loop main while loop is true
            {
                Console.Write("Enter number of times at bat (Enter a number between 1 and 25): ");
                int TimesBatting =  GetValidInteger(1, 25); //Gets a valid integer between 1 and 25 and assign it to TimesBatting.
                GetBattingResults(TimesBatting); //Prompts user for batting results then calculates and prints the results.
                if (!ContinueApp()) //Prompts user if he wants to continue. Set loop to false if use does not want to continue.
                    loop = false;
            }
        }
        public static int GetValidInteger(int Min, int Max)
        {
            int IntegerInput;
            while (true) //Loop GetValidInteger in case of error
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out IntegerInput)) //Validates if user input is an integer
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input not a number."); //Prompts error if input is not an integer
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Try again: ");
                    continue; //Restart the loop
                }
                if (IntegerInput < Min || IntegerInput > Max) //Validates if user input is between Min and Max
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: Input not between {Min} and {Max}."); //Prompts error if input is not between Min and Max
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Try again: ");
                    continue; //Restart the loop
                }
                return IntegerInput;
            }
        }
        public static void GetBattingResults(int TimesBatting)
        {
            List<int> BattingResults = new List<int>(TimesBatting); //Create a BattingResults list of length TimesBatting

            int AtBatsNotZero = 0; //Initialize int AtBatsNotZero to zero.
            int Sum = 0; //Initialize int Sum to zero.

            Console.WriteLine("0=out, 1=single, 2=double, 3=triple, 4=home run\n");

            for (int i = 0; i < TimesBatting; i++)
            {
                Console.Write($"Result for at-bat {i + 1}: ");

                BattingResults.Add(GetValidInteger(0, 4)); //Gets a valid integer between 0 and 4 and adds it to the BattingResults list

                if (BattingResults[i] != 0) //If user input is zero
                {
                    AtBatsNotZero++; //Increment AtBatsNotZero
                    Sum += BattingResults[i]; //Add BattingResults[i] value to Sum to get the sum of all batting results. 
                }
                
            }

            //Cast double to AtBatsNotZero and Sum so the result is a double instead of an integer.
            //Math.Round numbers to three decimal places
            double BattingAverage = Math.Round(((double)AtBatsNotZero / BattingResults.Count), 3); //BattingAverage = number of Atbats not zero / number of Atbats
            double SluggingPercent = Math.Round(((double)Sum / BattingResults.Count), 3); //SluggingPercent = SUM/Number of Atbats

            Console.WriteLine($"Batting Average: {BattingAverage}");
            Console.WriteLine($"Slugging Percentage: {SluggingPercent}");
        }
        public static bool ContinueApp()
        {
            while (true) //Loop ContinueApp in case of an error
            {
                Console.Write("Another batter? (y/n): ");
                string input = Console.ReadLine().ToLower(); 
                if (input == "y")
                {
                    Console.WriteLine();
                    return true;
                }
                else if (input == "n")
                {
                    Console.WriteLine("Byebye!");
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input not y or n.\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
