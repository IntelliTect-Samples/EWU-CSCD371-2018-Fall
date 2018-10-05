using System;
using System.Collections.Generic;
namespace Expression
{
    public class Expression
    {
    private String inFix;
    private LinkedList<String> postFixLL;
    private Stack expressionStack;
    private String[] myOperators = {"(", "+", "-", "*", "/", "^"};
    private int[] onStack = {0,2,2,4,4,5};
    private int[] currentItem = {100,1,1,3,3,6};
    
    public Expression(String str)
    {
        str = trimInput(str);
        if(str.Length == 0)
        {
            str = " ";
        }
        this.inFix = str;
        this.expressionStack = new Stack();
        postFixInit();
    }

    private String trimInput(String str)
    {
        return str.Trim();
    }
    
    private bool isDecimal(String str) //used this way, value would be converted to string right after
    {
            try 
            {
                decimal x = Decimal.Parse(str);
                return true;
            }
            catch(FormatException) 
            {
                return false;
            }
        } 
    
    private void postFixInit()
    {
        this.postFixLL = new LinkedList<string>();
        int index = 0;
        bool invalidSym = false;
        while(index < inFix.Length)
        {  
            char symbol = inFix[index];
            //                                 check for decimal value         
            if((symbol > 47 && symbol < 58) || symbol == '.' || (inFix.Length > 2 &&  symbol == '-'  && inFix[index + 1] == '.' && (inFix[index + 2] > 47 && inFix[index + 1] < 58) ) || (symbol == '-' && (inFix[index + 1] > 47 && inFix[index + 1] < 58)))  
            {
                
                String num;
                int i = index + 1;
                num = symbol.ToString();
                char tempSymbol;
                while(i < inFix.Length)
                {
                    tempSymbol = inFix[i];
                    if((tempSymbol >= '0' && tempSymbol <= '9') || tempSymbol == '.')
                    {
                        index++;
                        num += tempSymbol.ToString();
                    }
                    else
                    {
                        i = inFix.Length;//break out of loop
                    }
                    i++;
                }
                if(!checkValidDecimalValue(num))
                {
                    this.postFixLL.AddLast("bad");
                    return;
                }
                this.postFixLL.AddLast(num);
                index++;
                if(index < inFix.Length && inFix[index] == '-' && inFix[index + 1] != '-' && inFix[index + 1] != '(')
                {
                    this.expressionStack.push("+");
                }
            }
            //check for symbols
            else if(symbol == '(')
            {
                this.expressionStack.push(symbol.ToString());
                index++;
            }
            else if(symbol == ')')
            {
                while(!string.Equals(this.expressionStack.peek(), "("))
                {
                    this.postFixLL.AddLast(this.expressionStack.pop());
                }
                this.expressionStack.pop();//pops left ')'
                index++;
            }
            else
            {
                int currentMyOperators = findIndex(symbol.ToString(), myOperators.Length);
                try
                {
                    while((!(this.expressionStack.isEmpty())) && (onStack[findIndex(this.expressionStack.peek(), myOperators.Length)] >= currentItem[currentMyOperators]))
                    {
                        this.postFixLL.AddLast(this.expressionStack.pop());
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    invalidSym = true;
                }
                this.expressionStack.push(symbol.ToString());
                index++;
            }
        }
        while(!(this.expressionStack.isEmpty()))
        {
            this.postFixLL.AddLast(this.expressionStack.pop());
        }
        if(invalidSym)
        {
            Console.WriteLine("Invalid Symbol Found");
            this.postFixLL.AddFirst("0");//used quickly for edge case "non-value ## +-/* value */
        }
    }
    
    public int findIndex(string symbol, int length)
    {
        for(int x = 0; x < length; x++)
        {
            if(string.Equals(symbol, this.myOperators[x]))
            {
                return x;
            }
        }
        return -1;
    }
    
    public String postFixEval()
    {
        int index = 0;
        decimal tempValue = 0;
        foreach(string symbol in postFixLL)
        {
            //Console.WriteLine(symbol);
            if(isDecimal(symbol))
            {
                this.expressionStack.push(symbol);
            }
            else
            {
                decimal left = 0;
                decimal right = 0;
                if(Decimal.TryParse(this.expressionStack.pop().ToString(), out left))//case 3++3
                {
                    if(this.expressionStack.isEmpty())
                    {
                        return "Error: Invalid Expression such as ++ not allowed.";
                    }
                }
                if(Decimal.TryParse(this.expressionStack.pop().ToString(), out right) == false)
                {
                    return "Error: Cannot convert to decimal.";
                }
                if(string.Equals(symbol, "^"))
                {               
                    if(!Decimal.TryParse(Math.Pow((double)right, (double)left).ToString(), out tempValue) || !checkValidDecimalValue(tempValue)) 
                    {
                        return "Error: Overflow would occur if attempt to take power to.";
                    }    
                    this.expressionStack.push(tempValue.ToString());
                }
                else if(string.Equals(symbol, "/"))
                {
                    if(left == 0)
                    {
                        return "Error: Cannot divide by zero";
                    }
                    if(!checkDec(right, left, symbol)) 
                    {
                        return "Error: Overflow would occur if attempt to divide";
                    }    
                    this.expressionStack.push((right / left).ToString());
                }
                else if(string.Equals(symbol, "*"))
                {
                    if(!checkDec(right, left, symbol)) 
                    {
                        return "Error: Overflow would occur if attempt to multiply";
                    }    
                    this.expressionStack.push((right * left).ToString());
                }
                else if(string.Equals(symbol, "-"))//minus no longer necessary
                {
                    if(!checkDec(right, left, symbol))  
                    {
                        return "Error: Overflow would occur if attempt to subtract";
                    }    
                    this.expressionStack.push((right - left).ToString());
                }
                else if(string.Equals(symbol, "+"))//minus no longer necessary
                {
                    if(!checkDec(right, left, symbol)) 
                    {
                        return "Error: Overflow would occur if attempt to add";
                    }    
                    this.expressionStack.push((right + left).ToString());
                }
                else
                {
                    return "Error: Invalid Expression cannot be calculated.";
                }
            }
            index++;
        }
        decimal finalDec =  Decimal.Round(Decimal.Parse(this.expressionStack.pop()),9);
        if(Decimal.Equals(finalDec, 0))
        {
            finalDec = 0;
        }
        return this.inFix + " = " + finalDec;
    }

    private bool checkValidDecimalValue(decimal tempValue)
    {
        double tempDoub = 0;
        if(Double.TryParse(tempValue.ToString(), out tempDoub))
        {
            if(tempDoub > (double)Decimal.MaxValue || tempDoub < (double)Decimal.MinValue)
            {
                return false;
            }
            return true;
        }
        return false;
    }

    private bool checkValidDecimalValue(String tempValue)
    {
        decimal tempDoub = 0;
        if(Decimal.TryParse(tempValue.ToString(), out tempDoub))
        {
            if(tempDoub > Decimal.MaxValue || tempDoub < Decimal.MinValue)
            {
                return false;
            }
            return true;
        }
        return false;
    }

    private bool checkDec(decimal a, decimal b, String oper)
    {
        decimal temp = 0;
        try
        {
            if(oper.Equals("+"))
            {
                temp = a + b;
            }
            else if(oper.Equals("-"))
            {
                temp = a - b;
            }            
            else if(oper.Equals("/"))
            {
                temp = a / b;
            }
            else if(oper.Equals("*"))
            {
                temp = a * b;
            }
            else
            {
                return false;
            }
            return true;
        }
        catch(ArithmeticException)
        {
            return false;
        }
    }

    }
}