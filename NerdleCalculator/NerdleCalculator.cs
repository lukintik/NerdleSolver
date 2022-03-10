using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NerdleCalculator
{
    public static class NerdleCalculator
    {
        private const int operatorSize = 4;

        public static char[] Operators => new char[operatorSize] { '+', '-', '*', '/' };
        public static string[] MultiDivOperators => new string[2] { "*", "/" };
        public static string[] PlusMinusOperators => new string[2] { "+", "-" };


        const char Equal = '=';

        public static bool ValidateCalculationInput(string input)
        {
            int answer = ExtractAnswerFromInput(input);
            string calculation = input.Split('=')[0];
            string[] numbers = calculation.Split(Operators);

            List<NumberOperation> operation = new List<NumberOperation>();
            List<CalculationInput> storage = new List<CalculationInput>();
            int index = 0;

            foreach (char item in calculation)
            {
                if (Operators.Contains(item))
                {
                    operation.Add(new NumberOperation()
                    {
                        operand = item,
                        index = index,
                        isOperand = Operators.Contains(item)
                    });
                }
                index++;
            }
            int storageIndex = 0;
            storage.Add(new CalculationInput(numbers[0], 0, false));
            int count = 0;
            foreach (NumberOperation op in operation)
            {
                storageIndex++;
                count++;
                // adding operand
                storage.Add(new CalculationInput(op.operand.ToString(), count, op.isOperand));
                count++;

                // adding next number
                storage.Add(new CalculationInput(numbers[storageIndex], count, false));
            }
            int finalResult = 0;
            var operatorList = storage.Where(x => x.isOperand).ToList();
            bool isReverseOrder = false;
            List<CalculationInput> newOperandList = new List<CalculationInput>();

            if (
                storage.FirstOrDefault(x => MultiDivOperators.Contains(x.input))?.index >
               storage.FirstOrDefault(x => PlusMinusOperators.Contains(x.input))?.index)
            {
                operatorList = operatorList.OrderByDescending(x => x.index).ToList();
                isReverseOrder = true;
            }

            for (int i = 0; i < operatorList.Count(); i++)
            {

                if (i == 0)
                {
                    int operatorIndex = operatorList[i].index;
                    finalResult = CalculateNumber(int.Parse(storage[operatorIndex - 1].input), int.Parse(storage[operatorIndex + 1].input), operatorList[i].input);
                }
                else
                {
                    int operatorIndex = operatorList[i].index;
                    finalResult = CalculateNumber(finalResult, int.Parse(isReverseOrder ? storage[operatorIndex - 1].input : storage[operatorIndex + 1].input), operatorList[i].input);
                }
            }

            return finalResult == answer;
        }

        public static int ExtractAnswerFromInput(string input)
        {
            return Convert.ToInt32(input.Substring(input.IndexOf(Equal) + 1));
        }

        private static int CalculateNumber(int number1, int number2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return number1 + number2;
                    break;
                case "-":
                    return number1 - number2;
                    break;
                case "/":
                    return number1 / number2;
                    break;
                case "*":
                    return number1 * number2;
                    break;
            }
            return 0;
        }

        internal class NumberOperation
        {
            public char operand { get; set; }
            public int index { get; set; }

            public bool isOperand { get; set; }
        }


        internal class CalculationInput
        {
            public string input { get; set; }
            public int index { get; set; }
            public bool isOperand { get; set; }

            public CalculationInput(string input, int index, bool isOperand)
            {
                this.input = input;
                this.index = index;
                this.isOperand = isOperand;
            }
        }
    }
}