using NerdleCalculator;
using System;
using System.Linq;

namespace Wordle
{
    static class Program
    {
        const int NumberOfTries = 6;
        const int MaxNumberOfCharacter = 8;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Nerdle");
            string answer = "10+2-3=7";
            
            int inputTries = 0;
            while(inputTries <= NumberOfTries)
            {
                Console.WriteLine("Enter Your Guess:");
                string? input = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(input) && input.Count() < MaxNumberOfCharacter)
                {
                    Console.WriteLine("NOT A VALID INPUT");
                }
                else if(input == answer)
                {
                    Console.WriteLine("You solved the nerdle");
                    break;
                }
                else
                {
                    bool isValidCalculation = NerdleCalculator.NerdleCalculator.ValidateCalculationInput(input);
                    if (isValidCalculation)
                    {
                        Console.WriteLine("Correct calculation");
                        inputTries++;
                    }
                    else
                    {
                        Console.WriteLine("Wrong calculation");
                    }
                }
            }
        }
    }
}