using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment2
{
    public class Calculator
    {
        public static string myOperator;

        public static int findLocationOfOperator(string userExpression)
        {
            if (userExpression.IndexOf('+') > 0)
            {
                myOperator = "Addition";
                return userExpression.IndexOf('+');
            }
            else if (userExpression.IndexOf('/') > 0)
            {
                myOperator = "Division";
                return userExpression.IndexOf('/');
            }
            else if (userExpression.IndexOf('*') > 0)
            {
                myOperator = "mupltiplication";
                return userExpression.IndexOf('*');
            }
            else if (userExpression.IndexOf('-', 1) > 0) //start search at index 1 in case the first number is a negitive num.
            {
                myOperator = "Subraction";
                return userExpression.IndexOf('-');
            }
            else
                return -1;
        }

       
        public static void Main(string[] args)
        {
           
            String usersExpression;
            if (args.Length > 0)
            {
                System.Console.WriteLine("Expression passed in by the command line is " + args[0]);
                usersExpression = args[0];
            }
            else
            {
                System.Console.WriteLine("No command line argument given. Please manually enter an expression.");
                System.Console.WriteLine("Enter an expression (ie. 1+3 with no spaces) and then press Enter.");
                usersExpression = System.Console.ReadLine();
            }
            int locOfOperator = findLocationOfOperator(usersExpression);
            //System.Console.WriteLine("The + is located at " + locOfOperator);

            if (locOfOperator == -1)  //no operator was in the expression.
            {
                System.Console.WriteLine("Invalid expression - no operator!");
            }
            else
            {
                string firstNumAsAString = usersExpression.Substring(0, locOfOperator);
                //System.Console.WriteLine("First number is " + firstNumAsAString);

                //double firstNum = double.Parse(firstNumAsAString, CultureInfo.InvariantCulture);            
                if (double.TryParse(firstNumAsAString, out double firstNum))
                {
                    //number is a valid double.
                }
                else
                {
                    System.Console.WriteLine("First number was invalid.");
                    firstNum = 0;
                }
                string lastNumAsAString = usersExpression.Substring(locOfOperator + 1, ((usersExpression.Length - 1) - locOfOperator));
                //System.Console.WriteLine("Last number is " + lastNumAsAString);

                //double lastNum = double.Parse(lastNumAsAString, CultureInfo.InvariantCulture);
                if (double.TryParse(lastNumAsAString, out double lastNum))
                {
                    //number is a valid double.
                }
                else
                {
                    System.Console.WriteLine("Last number was invalid.");
                    lastNum = 0;
                }
                if (myOperator == ("Addition"))
                {
                    double result = firstNum + lastNum;
                    if (Double.IsPositiveInfinity(result) || Double.IsNegativeInfinity(result))
                        System.Console.WriteLine("Error - Number is larger that a double");
                    else
                        System.Console.WriteLine("=" + result);
                }
                else if (myOperator == ("Subraction"))
                {
                    double result = firstNum - lastNum;
                    System.Console.WriteLine("=" + result);
                }
                else if (myOperator == ("Division"))
                {

                    if (lastNum == 0)
                    {
                        System.Console.WriteLine("Error, can not divide by 0!!!");
                    }
                    else
                    {
                        double result = firstNum / lastNum;
                        System.Console.WriteLine("=" + result);
                    }
                }
                else if (myOperator == ("mupltiplication"))
                {
                    double result = firstNum * lastNum;
                    System.Console.WriteLine("=" + result);
                }
            }
                       

            System.Console.WriteLine("Press any key to quit");
            System.Console.ReadLine();

        }//end of main

    }//end of class
}//end of namespace


    

