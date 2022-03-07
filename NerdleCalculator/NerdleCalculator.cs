namespace NerdleCalculator
{
    public static class NerdleCalculator
    {
        private const int operatorSize = 4;

        public static char[] Operators => new char[operatorSize] { '+', '-', '*', '/' };

        const char Equal = '=';

        public static bool ValidateCalculationInput(string input)
        {
            Stack<char> operators = new Stack<char>();
            Stack<int> numbers = new Stack<int>();
            int answer = ExtractAnswerFromInput(input);
            
            foreach(char item in input)
            {
                if (item == Equal)
                {
                    break;
                }
                if (Operators.Contains(item))
                {
                    operators.Push(item);
                }
                else
                {
                    numbers.Push(int.Parse(item.ToString()));
                }
            }
            
            return false;
        }
        
        public static int ExtractAnswerFromInput(string input)
        {
            return Convert.ToInt32(input.Substring(input.IndexOf(Equal) + 1));
        }
    }
}