using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace StringMath
{
    public class StringMath
    {
        public static void Main(string[] args)
        {
            String line;
            bool argsFlag = false;
            if (args.Length == 1)
                argsFlag = true;
          

            Console.WriteLine("Enter 'exit' to end program.");
            bool runFlag = true;

            while (runFlag) {
                Console.Write("Enter binomial math operation to solve. e.g. (-2.5%5.1): ");
                line = (argsFlag)? args[0] : Console.ReadLine();
                if (argsFlag)
                    argsFlag = false;
                if (!string.IsNullOrEmpty(line))
                {
                    try{
                        runFlag = ParseLine(line);
                    }
                    catch(Exception ex){
                        Console.WriteLine($"Failed to evalute expression: {line}");
                        Console.WriteLine($"Reason: {ex.Message}");
                    }
                }
            }
            Console.WriteLine("Program complete.");
        }

        private static bool ParseLine(string line)
        {
            bool runFlag = line.ToLower().Equals("exit") ? false : true;
            if (runFlag && !(line.Length == 0 || line.Length < 3))
            {
                MatchCollection operands = ParseLineParameters(line);
                char op = FindOperator(line, operands);
                double result = EvaluateExpression(operands, op);
                PrintFormattedResult(operands, op, result);
            }
            return runFlag;
        }

        private static MatchCollection ParseLineParameters(string line)
        {
            line = System.Text.RegularExpressions.Regex.Replace(line, " ", "");
            //0-1 minus signs followed by 1+ digits, optional decimal point and precision digits
            Regex regex = new Regex(@"(?<!\d)-?(\d+)?(\.\d+)?"); 
            MatchCollection matches = regex.Matches(line);

            if (matches.Count != 2)
                throw new ArgumentException($"Invalid expression {line}");
            return matches;
        }

        private static char FindOperator(string line, MatchCollection operands)
        {
            List<char> delimiters = new List<char> { '+', '-', '/', '*', '%', '^', };
            IEnumerator<Match> en = (IEnumerator < Match >) operands.GetEnumerator();
            en.MoveNext();
            Match lhs = en.Current;
            char c = line[lhs.Index + lhs.Length];
            if (delimiters.Contains(c))
                return c;
            throw new ArgumentException($"Incorrect format: cannot find operator: {line}");
        }


        private static double EvaluateExpression(MatchCollection operands, char op)
        {
            string lhsString = operands[0].Value;
            string rhsString = operands[1].Value;
            bool lDec = lhsString.Contains(".");
            bool rDec = rhsString.Contains(".");
            double lhs, rhs;
            if (lDec || rDec)
            {
                Double.TryParse(lhsString, out lhs);
                Double.TryParse(rhsString, out rhs);
            }
            else
            {
                long.TryParse(lhsString, out long lTemp);
                long.TryParse(rhsString, out long rTemp);
                lhs = Convert.ToDouble(lTemp);
                rhs = Convert.ToDouble(rTemp);
            }
            return EvaluateOperands(lhs, rhs, op);
        }

        //Will suffer loss of precision with large (> 16 digits) integer numbers
        private static double EvaluateOperands(double lhs, double rhs, char op)
        {
            switch (op)
            {
                case '+':
                    return lhs + rhs;
                case '-':
                    return lhs - rhs;
                case '*':
                    return lhs * rhs;
                case '/':
                    if (Math.Abs(rhs) < Double.Epsilon)
                        throw new DivideByZeroException();
                    return lhs / rhs;
                case '%':
                    return lhs % rhs;
                case '^':
                        return Math.Pow(lhs, rhs);
                default:
                    throw new ArgumentException("Unsupported operator");
            }
       
        }

        private static void PrintFormattedResult(MatchCollection operands,char op, double result)
        {
            Console.WriteLine($"{operands[0]}{op}{operands[1]} = {String.Format("{0:0.####}", result)}");
        }

        

    }
}
