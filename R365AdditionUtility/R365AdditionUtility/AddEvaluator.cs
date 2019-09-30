using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R365AdditionUtility
{
    public class AddEvaluator
    {
        /// <summary>
        /// RequirementOne
        /// </summary>
        /// <param name="input">Comma Delimited String of no more than 2 numbers</param>
        /// <example>20 will return 20; 1,5000 will return 5001</example>
        /// <remarks>invalid / missing numbers should be converted to 0 e.g. "" will return 0; 5,tytyt will return 5</remarks>
        public int RequirementOne(string input)
        {
            int total = 0;
            var values = input.Split(',');
            var max = values.Count();
            if (max > 2)
                max = 2;
            for (int i = 0; i < max; i++)
            {
                string currentVal = values[i];
                if (currentVal.Trim() == "")
                {
                    currentVal = "0";
                }
                int numberValue = 0;
                if (int.TryParse(currentVal, out numberValue))
                    total = total + numberValue;
            }
            Console.WriteLine(total);
            return total;
        }

        /// <summary>
        /// RequirementTwo
        /// </summary>
        /// <param name="input">Comma Delimited String</param>
        /// <example>1,2,3,4,5,6,7,8,9,10,11,12 will return 78</example>
        /// <remarks>Support an unlimited number of numbers</remarks>
        public int RequirementTwo(string input)
        {
            int total = 0;
            var values = input.Split(',');
            foreach (string val in values)
            {
                int numberValue = 0;
                if (int.TryParse(val, out numberValue))
                    total = total + numberValue;
            }
            Console.WriteLine(total);
            return total;
        }

        /// <summary>
        /// RequirementThree
        /// </summary>
        /// <param name="input">Comma or Newline Delimited String</param>
        /// <example>1\n2,3 will return 6</example>
        /// <remarks>Support a newline character as an alternative delimiter</remarks>
        public int RequirementThree(string input)
        {
            int total = 0;
            input = input.Replace("\\n", ",").Replace("\n", ",");
            var values = input.Split(',');
            foreach (string val in values)
            {
                int numberValue = 0;
                if (int.TryParse(val, out numberValue))
                    total = total + numberValue;
            }
            Console.WriteLine(total);
            return total;
        }

        /// <summary>
        /// RequirementFour
        /// </summary>
        /// <param name="input">Comma Delimited String</param>
        /// <example>-1,3,-4 will return an exception</example>
        /// <remarks>Deny negative numbers. An exception should be thrown that includes all of the negative numbers provided</remarks>
        public int RequirementFour(string input)
        {
            string negativeValuesFound = "";
            int total = 0;
            var values = input.Split(',');
            foreach (string val in values)
            {
                int numberValue = 0;
                if (int.TryParse(val, out numberValue))
                {
                    if (numberValue < 0)
                    {
                        if (negativeValuesFound.Length > 0)
                            negativeValuesFound = negativeValuesFound + " & ";
                        negativeValuesFound = negativeValuesFound + numberValue.ToString();
                    }
                    else
                    {
                        total = total + numberValue;
                    }
                }
            }
            if (negativeValuesFound.Length == 0)
                Console.WriteLine(total);
            else
            {
                Console.WriteLine("The value(s)" + negativeValuesFound + " are denied.  Negative Numbers are not accepted.");
                throw new ArgumentOutOfRangeException("Negative Values are denied.");
            }
            return total;
        }


        /// <summary>
        /// RequirementFive
        /// </summary>
        /// <param name="input">Comma Delimited String</param>
        /// <example>2,1001,6 will return 8</example>
        /// <remarks>Ignore any number greater than 1000</remarks>
        public int RequirementFive(string input)
        {
            int total = 0;
            var values = input.Split(',');
            foreach (string val in values)
            {
                int numberValue = 0;
                if (int.TryParse(val, out numberValue))
                {
                    if (numberValue <= 1000)
                    {
                        total = total + numberValue;
                    }
                }
            }
            Console.WriteLine(total);
            return total;
        }

        /// <summary>
        /// RequirementSix
        /// </summary>
        /// <param name="input">Comma Delimited String or 
        /// String Delimited by an alternative character identified with the format: //{delimiter}\n{numbers}</param>
        /// <example>//;\n2;5 will return 7</example>
        /// <remarks>Support 1 custom single character length delimiter all previous formats should also be supported</remarks>
        public int RequirementSix(string input)
        {
            int total = 0;
            if (input.Substring(0, 2) == "//")
            {
                input = input.Replace("\\n", "\n");
                var delimitedFormatString = input.Split('\n');
                var delimiter = delimitedFormatString[0].Replace("//", "");
                if (delimiter.Length == 1)
                {
                    var delChar = Char.Parse(delimiter);
                    var newLineValues = input.Split(delChar);
                    foreach (string val in newLineValues)
                    {
                        int numberValue = 0;
                        if (int.TryParse(val, out numberValue))
                            total = total + numberValue;
                    }
                }
                else
                {
                    throw new ArgumentException("Delemiters must not exceed one character.");
                }
            }
            else
            {
                var values = input.Split(',');
                foreach (string val in values)
                {
                    int numberValue = 0;
                    if (int.TryParse(val, out numberValue))
                        total = total + numberValue;
                }
            }
            Console.WriteLine(total);
            return total;
        }

        /// <summary>
        /// RequirementSeven
        /// </summary>
        /// <param name="input">Comma Delimited String or 
        /// String Delimited by an alternative string of any length identified with the format: //{delimiter}\n{numbers}</param>
        /// <example>//[***]\n11***22***33 will return 66</example>
        /// <remarks>Support 1 custom delimiter of any length all previous formats should also be supported</remarks>
        public int RequirementSeven(string input)
        {
            int total = 0;
            if (input.Substring(0, 2) == "//")
            {
                input = input.Replace("\\n", "\n");
                var delimitedFormatString = input.Split('\n');
                var delimiter = delimitedFormatString[0].Replace("//[","").Replace("]", "");
                input = delimitedFormatString[1].Replace(delimiter, ",");
            }
            var values = input.Split(',');
            foreach (string val in values)
            {
                int numberValue = 0;
                if (int.TryParse(val, out numberValue))
                    total = total + numberValue;
            }
            Console.WriteLine(total);
            return total;
        }

        /// <summary>
        /// RequirementEight
        /// </summary>
        /// <param name="input">Comma Delimited String or 
        /// String Delimited by an alternative string of any length identified with the format: //[{delimiter1}][{delimiter2}]...\n{numbers}</param>
        /// <example>//[*][!!][r9r]\n11r9r22*33!!44 will return 110</example>
        /// <remarks>Support multiple delimiters of any length all previous formats should also be supported</remarks>
        public int RequirementEight(string input)
        {
            int total = 0;
            if (input.Substring(0, 2) == "//")
            {
                input = input.Replace("\\n", "\n");
                var delimitedFormatString = input.Split('\n');
                var delimiters = delimitedFormatString[0].Replace("][", ",").Replace("//[", "").Replace("]", "").Split(',');
                input = delimitedFormatString[1];
                foreach (string delimiter in delimiters)
                {
                    input = input.Replace(delimiter, ",");
                }
            }
            var values = input.Split(',');
            foreach (string val in values)
            {
                int numberValue = 0;
                if (int.TryParse(val, out numberValue))
                    total = total + numberValue;
            }
            Console.WriteLine(total);
            return total;
        }


    }
}
