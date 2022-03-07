using NerdleCalculator;

namespace Wordle
{
    static class Program
    {
        const int NumberOfTries = 6;
        const int MaxNumberOfCharacter = 8;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Wordle");
            string answer = "10+2-3=7";
            string? input = Console.ReadLine();

            if(string.IsNullOrEmpty(input) && input.Count() < MaxNumberOfCharacter)
            {
                Console.WriteLine("NOT A VALID INPUT");
            }
            else
            {
                NerdleCalculator.NerdleCalculator.ValidateCalculationInput(input);
            }

        }
    }
}