using System;
using System.Collections.Generic;
using System.Linq;

// I didn't start the project in time to finish, no excuse. My Apologies. //

namespace Assignment2
{
    public class SimpleCalculator
    {
        public static void Main(string[] args)
        {
            bool doAgain = false;
            do
            {
                Console.WriteLine("Welcome to a Simple Calculator, please enter an expression to evaluate");
                string inputString = Console.ReadLine();
                string formatted = String.Join(" ", InfixConverter(new[] { inputString }));
                Console.WriteLine(formatted);
                int outputResult = Calculate(formatted);
                Console.WriteLine($"The result is: {outputResult}");
                Console.WriteLine("Press Enter to Exit");
                Console.ReadLine();
            } while (doAgain);
        }

        public static int Calculate( string input )
        {
            var operandStack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if ( !( "+-/*()" ).Contains( input[ i ] ) )
                {
                    operandStack.Push( input[ i ] );
                }
                else
                {
                    int leftNum = operandStack.Pop();
                    int rightNum = operandStack.Pop();
                    int tempResult;
                
                    switch ( input[ i ] )
                    {
                        case '+':
                            tempResult = leftNum + rightNum;
                            operandStack.Push(tempResult);
                            break;

                        case '-':
                            tempResult = leftNum - rightNum;
                            operandStack.Push(tempResult);
                            break;
                        case '*':
                            tempResult = leftNum * rightNum;
                            operandStack.Push(tempResult);
                            break;
                        case '/':
                            if (rightNum == 0)
                            {
                                Console.WriteLine("Error, cannot divide by 0");
                            }
                            else
                            {
                                tempResult = leftNum / rightNum;
                                operandStack.Push(tempResult);
                            }
                            break;
                    }
                    
                }
            }
            var result = operandStack.Pop();

            return result;

        }

        public static int CalculatePrecedence(string input)
        {
            switch (input)
            {
                case "(":
                    return 100;
                case ")":
                    return 100;
                case "/":
                    return 50;
                case "*":
                    return 50;
                case "+":
                    return 25;
                case "-":
                    return 25;
                default:
                    return 0;
            }
        }

        public static string[] InfixConverter(string[] infix)
        {
            //Create temp stack for holding operators
            var tempStack = new Stack<string>();
            //Create stack that will hold the completed postfix expression
            var postfixStack = new Stack<string>();
            //Create temp string to pass a character around
            var tempString = "";

            //Main for loop to walk through infix expression and convert it to postfix
            for (int i = 0; i < infix.Length; i++)
            {
                //Check if current character is NOT an operator
                if ( !( "+-/*()" ).Contains( infix[ i ] ) )
                {
                    //If current character is NOT an operator, push to postfix stack
                    postfixStack.Push( infix[ i ] );
                }
                //If current character IS an operator
                else
                {
                    //Check if current character is a left parens '('
                    if ( infix[ i ].Equals( "(" ) )
                    {
                        //If current character is a left parens '(', push to the temp operator stack
                        tempStack.Push( infix[ i ] );
                    }

                    //Check if current character is right parens ')'
                    else if ( infix[ i ].Equals( ")" ) )
                    {
                        //If current character is right parens ')', pop from temp operator stack and set it to temp string
                        tempString = tempStack.Pop();
                        //While loop to walk through the rest of the tempString until the closing parens is found '('
                        while ( !( tempString.Equals( "(" ) ) )
                        {
                            //If tempString does not equal left parent '(', push that character to the postfix stack
                            postfixStack.Push( tempString );
                            //Then pop the top character off of the temp operator stack and set it to the tempString
                            tempString = tempStack.Pop(); 
                        }
                    }

                    //Finally, current character should now be an operator ( + - * /)
                    else
                    {
                        //While loop to walk through the temp operator stack
                        while ( tempStack.Count > 0)
                        {
                            //Pop top operator on temp operator stack and assign it to tempString
                            tempString = tempStack.Pop();
                            //Check if tempString operator has higher than or equal precedence than the current character (operator)
                            if (CalculatePrecedence( tempString ) >= CalculatePrecedence( infix[ i ] ) )
                            {
                                //If tempString operator has greater precedence than the current character operator, push it to postfixStack
                                postfixStack.Push(tempString);
                            }
                            else
                            {
                                //If tempString operator has less precedence than the current character operator, push it to the temp operator stack
                                tempStack.Push( tempString );
                            }
                        }
                        //When walked down to last operator in the temp operator stack, push the current character operator to the temp operator stack
                        tempStack.Push( infix[ i ] );
                    }
                }
            }

            //After the main for loop, if temp operator stack is not empty, pop the stack and push the item to the postfix stack, repeat until empty
            while ( tempStack.Count > 0 )
            {
                postfixStack.Push( tempStack.Pop() );
            }

            //convert the stack to an array and return it.
            return postfixStack.ToArray();
        }
    }
}
