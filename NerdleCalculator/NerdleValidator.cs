using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdleCalculator
{
    public class NerdleValidator
    {
        public static List<NumberResult> CheckAnswer(string input, string answer)
        {
            List<NumberResult> result = new List<NumberResult>();
            for (int i =0; i< input.Length; i++)
            {
                if(answer.Contains(input[i]))
                {
                    if (input[i] == answer[i])
                    {
                        result.Add(new NumberResult()
                        {
                            Status = "Green",
                            Input = input[i].ToString(),
                            index = i
                        });
                    }
                    else
                    {
                        result.Add(new NumberResult()
                        {
                            Status = "Yellow",
                            Input = input[i].ToString(),
                            index = i
                        });
                    }
                }
                else
                {
                    result.Add(new NumberResult()
                    {
                        Status = "White",
                        Input = input[i].ToString(),
                        index = i
                    });
                }
               
            }
            return result;
        }
    }
}
