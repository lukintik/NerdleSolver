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
            string? input = Console.ReadLine();
            int inputTries = 0;
            while(inputTries <= NumberOfTries)
            {
                if (string.IsNullOrEmpty(input) && input.Count() < MaxNumberOfCharacter)
                {
                    Console.WriteLine("NOT A VALID INPUT");
                }
                else
                {
                    bool isValidCalculation = NerdleCalculator.NerdleCalculator.ValidateCalculationInput(input);
                    if (isValidCalculation)
                    {
                        Console.WriteLine("Correct calculation");
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