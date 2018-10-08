using System;

namespace SimpleCalc
{
    public class SimpleCalcProgram
    {
        public static void Main(string[] args)
        {
            String FirstInt = "", SecondInt = "";
            String OperatorString ="";

            Console.WriteLine("Please enter an arithmetic expression: ");
            String FirstString = Console.ReadLine().ToString().ToLower();

            char[] CharArray = FirstString.ToCharArray();


            for (int i = 0; i < CharArray.Length; i++)
            {
                 if (Char.IsDigit(CharArray[i]))
                {
                    FirstInt += CharArray[i].ToString();
                    
                }
                else
                {   if (!Char.IsDigit(CharArray[i]) && i < 1)
                    {
                        FirstInt = CharArray[0].ToString();
                    }
                    else
                    {
                        if (CharArray[i] == '+')
                        {
                            OperatorString = CharArray[i].ToString();
                        }
                        else if (CharArray[i] == '-')
                        {
                            OperatorString = CharArray[i].ToString();
                        }
                        else if (CharArray[i] == '*')
                        {
                            OperatorString = CharArray[i].ToString();
                        }
                        else if (CharArray[i] == '/')
                        {
                            OperatorString = CharArray[i].ToString();
                        }
                        else
                        {
                            Console.WriteLine("Error! You entered a wrong operator!");
                        }

                        if (!Char.IsDigit(CharArray[i + 1]))
                        {
                            SecondInt = CharArray[i + 1].ToString();
                            i++;
                        }
                       

                            for (int x = i + 1; x < CharArray.Length; x++)
                            {
                                if (Char.IsDigit(CharArray[x]))
                                {
                                    SecondInt += CharArray[x].ToString();
                                }
                                else
                                {
                                    Console.WriteLine("Error! You entered a wrong number!");
                                }
                                i++;
                            }
                        
                    }
                    
                }
                
            }


            int FirstIntString = IntOrNot(FirstInt);
                        
            int SecondIntString = IntOrNot(SecondInt);

            int Res = Comparison(OperatorString, FirstIntString, SecondIntString);

            Console.WriteLine($"Your answer is: {Res}");
            Console.ReadLine();
        }

        public static int IntOrNot(String StringInt)
        {
                int j, i = 0;
                if (Int32.TryParse(StringInt, out j))
                {
                    i = j;
                    return i;
                }
                else
                {
                    Console.WriteLine("Your expression could not be parsed.");
                }


            return i;
        }

        public static int Comparison(string OperatorString, int FirstInt, int SecondInt)
        {
            int Res = 0;
            if (OperatorString == "+")
            {
                Res = FirstInt + SecondInt;
            }
            else if (OperatorString == "-")
            {
                Res = FirstInt - SecondInt;
            }
            else if (OperatorString == "*")
            {
                Res = FirstInt * SecondInt;
            }
            else if (OperatorString == "/")
            {
                if (SecondInt == 0)
                {
                    Console.WriteLine("Can't devide by 0!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                Res = FirstInt / SecondInt;
            }

            return Res;
        }

        public static String Operator()
        {
            bool repeat = true;
            String OperatorString = "";
            while (repeat)
            {

                Console.WriteLine("Please enter one of the following operators + , - , * , / ");
                OperatorString = Console.ReadLine();

                if (OperatorString == "+")
                {
                    return OperatorString;
                }
                else if (OperatorString == "-")
                {
                    return OperatorString;
                }
                else if (OperatorString == "*")
                {
                    return OperatorString;
                }
                else if (OperatorString == "/")
                {
                    return OperatorString;
                }
                else
                {
                    Console.WriteLine("Error! You entered a wrong operator!");

                }

                Console.WriteLine("Do you want to try again? Y/N");
                string res = Console.ReadLine();
                if (res == "Y" || res == "y")
                {
                    repeat = true;
                }
                else
                {
                    repeat = false;
                    Environment.Exit(0);
                }
            }
            return OperatorString;
        }
    
    }
    
}
