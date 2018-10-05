using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace tests
{

    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void testMinLength()
        {   
            Assert.AreEqual(0, "".Length);
            Assert.AreEqual(7, "Chester".Length);
        }

        [TestMethod]
        public void testTrim()
        {
            Assert.AreEqual("", "".Trim());
            Assert.AreEqual("bob", "bob                ".Trim());
            Assert.AreEqual("bob", "        bob                  ".Trim());
            Assert.AreEqual("raichu is cool", "raichu is cool".Trim());
        }

        [TestMethod]
        public void testToUpper()
        {
            Assert.AreEqual("BULBASAUR", "bulbasaur".ToUpper());
            Assert.AreEqual("CHARMANDER", "cHarMander".ToUpper());
            Assert.AreEqual("SQUIRTLE", "SQUIRTLE".ToUpper());
            Assert.AreEqual("", "".ToUpper());
            Assert.AreEqual("1331 12", "1331 12".ToUpper());
        }
        [TestMethod]
        public void testSubString()
        {
            Assert.AreEqual("", "can".Substring(0,0));
            Assert.AreEqual("bob", "bob".Substring(0,"bob".Length));
            Assert.AreEqual("", "".Substring(0,0));
            Assert.AreEqual("a", "andy".Substring(0,1));
        }
    }

//CHECK MAX VALUE
    [TestClass]
    public class UnitTestEdgeCasesMax
    {
        [TestMethod]
        public void testDecMaxInputed()
        {   
            
            string myValue = Decimal.MaxValue.ToString();
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 79228162514264337593543950335"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
        
        [TestMethod]
        public void testDecMaxInputedAdd()
        {   
            string myValue = Decimal.MaxValue.ToString() + "+1";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to add"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void testDecMaxInputedSubtract()
        {   
            string myValue = Decimal.MaxValue.ToString() + "-1";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 79228162514264337593543950334";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void testDecMaxInputedMultiply()
        {   
            string myValue = Decimal.MaxValue.ToString() + "*2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to multiply"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void testDecMaxInputedDivide()
        {   
            string myValue = Decimal.MaxValue.ToString()+"/-"+Decimal.MaxValue.ToString();
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void testDecMaxInputedPower()
        {   
            string myValue = Decimal.MaxValue.ToString()+"^2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
    }



//CHECK MIN VALUE
    [TestClass]
    public class UnitTestEdgeCasesMin
    {
        [TestMethod]
        public void testDecMinInputed()
        {   
            string myValue = Decimal.MinValue.ToString();
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -79228162514264337593543950335"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
        
        [TestMethod]
        public void testDecMinInputedAdd()
        {   
            string myValue = Decimal.MinValue.ToString()+"+-1";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to add"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void testDecMinInputedSubtract() // -1 -- num === -1 + num//meant to do equivalent to, not javascript notation
        {   
            string myValue = "-1-"+Decimal.MinValue.ToString();
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 79228162514264337593543950334"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void testDecMinInputedMultiply()
        {   
            string myValue = Decimal.MinValue.ToString() + "*2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to multiply"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void testDecMinInputedDivide()
        {   
            string myValue = Decimal.MinValue.ToString() + "/" +  Decimal.MinValue.ToString();
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void testDecMinInputedPower()
        {   
            string myValue = Decimal.MinValue.ToString()+"^2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
    }

    //overdone error case, copy/paste/controlF/replace made it quicker. Used calculator to confirm results, two results gave overflow while calculator did not, so possible method for pow is ineffiecient
    //zero was tested in several cases, errors occured in tests using divison
    //errors also occured when negative powers to a certain number were entered, resulting in overflow.
    
//Check Multiple Sign Expression
    [TestClass]
    public class UnitTestMultCalc
    {
        [TestMethod]
        public void posPlusPosPlusPos()
        {  
            string myValue = "3+3+3";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 9"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);

        }

        [TestMethod]
        public void zeroDivZeroDivZero()
        {  
            string myValue = "0/0/0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);

        }

        [TestMethod]
        public void posPowZeroDivZero2()
        {  
            string myValue = "2^0/0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);

        }

        [TestMethod]
        public void posPowZeroDivPos()
        {  
            string myValue = "2^0/1";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void multiSymbol()
        {  
            string myValue = "4-4*3+3.3";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -4.7"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
    } 
    
    [TestClass]
    public class UnitTestOddInput
    {
        [TestMethod]
        public void calculateLetter()
        {   
            string myValue = "A";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot convert to decimal."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

//My program handles if user passes in no input as I expect, but testTools throw a NullReferenceError when testing
/*        [TestMethod]
        public void calculateEmpty()
        {   
            string myValue = "";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot convert to decimal."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);

        }
*/
        [TestMethod]
        public void calculateLetterInSub()
        {   
            string myValue = "3-a3";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Invalid Symbol Found
Error: Invalid Expression cannot be calculated."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);

        }

        [TestMethod]
        public void calculateLetterInDiv()
        {   
            string myValue = "3/a3";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Invalid Symbol Found
Error: Invalid Expression cannot be calculated."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);

        }

        [TestMethod]
        public void calculateLetterInPow()
        {   
            string myValue = "3^a3";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Invalid Symbol Found
Error: Invalid Expression cannot be calculated."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);

        }

        [TestMethod]
        public void calculateLetterInPowMulti()
        {   
            string myValue = "3^a332ara";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Invalid Symbol Found
Error: Invalid Expression cannot be calculated."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);

        }
    }


/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestMinusSingleDigits
    {
        [TestMethod]
        public void posMinusPosSingleDigits()
        {   
            string myValue = "2-2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMinusNegSingleDigits()
        {   
            string myValue = "2--3";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 5"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMinusPosSingleDigits()
        {   
            string myValue = "-2-2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -4"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negMinusNegSingleDigits()
        {   
            string myValue = "-2--2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusPosSingleDigits()
        {   
            string myValue = "0-2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -2"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMinusZeroSingleDigits()
        {   
            string myValue = "2-0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 2"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMinusZeroSingleDigits()
        {   
            string myValue = "-2-0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -2"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusNegSingleDigits()
        {   
            string myValue = "0--2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 2"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusZeroSingleDigits()
        {   
            string myValue = "0-0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestPlusSingleDigits
    {
        [TestMethod]
        public void posPlusPosSingleDigits()
        {   
            string myValue = "1+2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 3"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPlusNegSingleDigits()
        {   
            string myValue = "1+-1";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPlusPosSingleDigits()
        {   
            string myValue = "-2+1";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negPlusNegSingleDigits()
        {   
            string myValue = "-2+-4";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -6"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusPosSingleDigits()
        {   
            string myValue = "0+2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 2"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPlusZeroSingleDigits()
        {   
            string myValue = "2+0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 2"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPlusZeroSingleDigits()
        {   
            string myValue = "-2+0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -2"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusNegSingleDigits()
        {   
            string myValue = "0+-1";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusZeroSingleDigits()
        {   
            string myValue = "0+0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestPlusDoubleDigits
    {
        [TestMethod]
        public void posPlusPosDoubleDigits()
        {   
            string myValue = "21+22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 43"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPlusNegDoubleDigits()
        {   
            string myValue = "21+-31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -10"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPlusPosDoubleDigits()
        {   
            string myValue = "-21+21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negPlusNegDoubleDigits()
        {   
            string myValue = "-42+-24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -66"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusPosDoubleDigits()
        {   
            string myValue = "0+23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPlusZeroDoubleDigits()
        {   
            string myValue = "24+0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 24"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPlusZeroDoubleDigits()
        {   
            string myValue = "-23+0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusNegDoubleDigits()
        {   
            string myValue = "00+-21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -21"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusZeroDoubleDigits()
        {   
            string myValue = "0.0+0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
    }
    
    /*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestMinusDoubleDigits
    {
        [TestMethod]
        public void posMinusPosDoubleDigits()
        {   
            string myValue = "21-22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMinusNegDoubleDigits()
        {   
            string myValue = "21--31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 52"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMinusPosDoubleDigits()
        {   
            string myValue = "-21-21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -42"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negMinusNegDoubleDigits()
        {   
            string myValue = "-42--24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -18"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusPosDoubleDigits()
        {   
            string myValue = "0-23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMinusZeroDoubleDigits()
        {   
            string myValue = "24-0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 24"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMinusZeroDoubleDigits()
        {   
            string myValue = "-23-0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusNegDoubleDigits()
        {   
            string myValue = "0--21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 21"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusZeroDoubleDigits()
        {   
            string myValue = "00+00";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestPlusSingleDecimal
    {
        [TestMethod]
        public void posPlusPosSingleDecimalDigits()
        {   
            string myValue = ".21-.22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.01"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPlusNegSingleDecimalDigits()
        {   
            string myValue = ".21+-.31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.10"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPlusPosSingleDecimalDigits()
        {   
            string myValue = "-.21+.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negPlusNegSingleDecimalDigits()
        {   
            string myValue = "-.42+-.24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.66"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusPosSingleDecimalDigits()
        {   
            string myValue = "0+.23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPlusZeroSingleDecimalDigits()
        {   
            string myValue = ".24+.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.24"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPlusZeroSingleDecimalDigits()
        {   
            string myValue = "-.23+0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusNegSingleDecimalDigits()
        {   
            string myValue = "0+-.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.21"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusZeroSingleDecimalDigits()
        {   
            string myValue = ".0+.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }    
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestMinusSingleDecimal
    {
        [TestMethod]
        public void posMinusPosSingleDecimalDigits()
        {   
            string myValue = ".21-.22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.01"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMinusNegSingleDecimalDigits()
        {   
            string myValue = ".21--.31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.52"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMinusPosSingleDecimalDigits()
        {   
            string myValue = "-.21-.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.42"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negMinusNegSingleDecimalDigits()
        {   
            string myValue = "-.42--.24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.18"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusPosSingleDecimalDigits()
        {   
            string myValue = ".0-.23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMinusZeroSingleDecimalDigits()
        {   
            string myValue = ".24-.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.24"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMinusZeroSingleDecimalDigits()
        {   
            string myValue = "-.23-.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusNegSingleDecimalDigits()
        {   
            string myValue = ".0--.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.21"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusZeroSingleDecimalDigits()
        {   
            string myValue = ".0-.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }    
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestPlusDecimal
    {
        [TestMethod]
        public void posPlusPosDecimal()
        {   
            string myValue = "5.21+5.22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 10.43"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPlusNegDecimal()
        {   
            string myValue = "2.21+-2.31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.10"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPlusPosDecimal()
        {   
            string myValue = "-2.21+2.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negPlusNegDecimal()
        {   
            string myValue = "-1.42+-1.24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -2.66"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusPosDecimal()
        {   
            string myValue = "0.0+3.23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 3.23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPlusZeroDecimal()
        {   
            string myValue = "3.24+0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 3.24"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPlusZeroDecimal()
        {   
            string myValue = "-3.23+0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -3.23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusNegDecimal()
        {   
            string myValue = "0.0+-2.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -2.21"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPlusZeroDecimal()
        {   
            string myValue = "0.0+0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }        
    
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestMinusDecimal
    {
        [TestMethod]
        public void posMinusPosDecimal()
        {   
            string myValue = "5.21-5.22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.01"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMinusNegDecimal()
        {   
            string myValue = "2.21--2.31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 4.52"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMinusPosDecimal()
        {   
            string myValue = "-2.21-2.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -4.42"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negMinusNegDecimal()
        {   
            string myValue = "-1.42--1.24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.18"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusPosDecimal()
        {   
            string myValue = "0.0-3.23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -3.23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMinusZeroDecimal()
        {   
            string myValue = "3.24-0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 3.24"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMinusZeroDecimal()
        {   
            string myValue = "-3.23-0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -3.23"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusNegDecimal()
        {   
            string myValue = "0.0--2.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 2.21"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMinusZeroDecimal()
        {   
            string myValue = "0.0-0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }        
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestMultiplySingleDigits
    {
        [TestMethod]
        public void posMultiplyPosSingleDigits()
        {   
            string myValue = "2*2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 4"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMultiplyNegSingleDigits()
        {   
            string myValue = "2*-3";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -6"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMultiplyPosSingleDigits()
        {   
            string myValue = "-2*2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -4"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negMultiplyNegSingleDigits()
        {   
            string myValue = "-2*-2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 4"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyPosSingleDigits()
        {   
            string myValue = "0*2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMultiplyZeroSingleDigits()
        {   
            string myValue = "2*0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMultiplyZeroSingleDigits()
        {   
            string myValue = "-2*0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyNegSingleDigits()
        {   
            string myValue = "0*-2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyZeroSingleDigits()
        {   
            string myValue = "-2*-2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 4"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestDivideSingleDigits
    {
        [TestMethod]
        public void posDividePosSingleDigits()
        {   
            string myValue = "2/2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posDivideNegSingleDigits()
        {   
            string myValue = "2/-3";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.666666667"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negDividePosSingleDigits()
        {   
            string myValue = "-2/2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negDivideNegSingleDigits()
        {   
            string myValue = "-2/-2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDividePosSingleDigits()
        {   
            string myValue = "0/2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posDivideZeroSingleDigits()
        {   
            string myValue = "2/0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negDivideZeroSingleDigits()
        {   
            string myValue = "-2/0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDivideNegSingleDigits()
        {   
            string myValue = "0/-2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDivideZeroSingleDigits()
        {   
            string myValue = "0/0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestMultiplyDoubleDigits
    {
        [TestMethod]
        public void posMultiplyPosDoubleDigits()
        {   
            string myValue = "21*22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 462"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMultiplyNegDoubleDigits()
        {   
            string myValue = "21*-31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -651"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMultiplyPosDoubleDigits()
        {   
            string myValue = "-21*21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -441"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negMultiplyNegDoubleDigits()
        {   
            string myValue = "-42*-24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1008"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyPosDoubleDigits()
        {   
            string myValue = "0*23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMultiplyZeroDoubleDigits()
        {   
            string myValue = "24*0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMultiplyZeroDoubleDigits()
        {   
            string myValue = "-23*0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyNegDoubleDigits()
        {   
            string myValue = "00*-21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyZeroDoubleDigits()
        {   
            string myValue = "0.0*0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

    }
    
    /*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestDivideDoubleDigits
    {
        [TestMethod]
        public void posDividePosDoubleDigits()
        {   
            string myValue = "21/22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.954545455"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posDivideNegDoubleDigits()
        {   
            string myValue = "21/-31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.677419355"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negDividePosDoubleDigits()
        {   
            string myValue = "-21/21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negDivideNegDoubleDigits()
        {   
            string myValue = "-42/-24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1.75"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDividePosDoubleDigits()
        {   
            string myValue = "0/23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posDivideZeroDoubleDigits()
        {   
            string myValue = "24/0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negDivideZeroDoubleDigits()
        {   
            string myValue = "-23/0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDivideNegDoubleDigits()
        {   
            string myValue = "0/-21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDivideZeroDoubleDigits()
        {   
            string myValue = "00/00";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestMultiplySingleDecimal
    {
        [TestMethod]
        public void posMultiplyPosSingleDecimalDigits()
        {   
            string myValue = ".21*-.22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.0462"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMultiplyNegSingleDecimalDigits()
        {   
            string myValue = ".21*-.31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.0651"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMultiplyPosSingleDecimalDigits()
        {   
            string myValue = "-.21*.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.0441"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negMultiplyNegSingleDecimalDigits()
        {   
            string myValue = "-.42*-.24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.1008"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyPosSingleDecimalDigits()
        {   
            string myValue = "0*.23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMultiplyZeroSingleDecimalDigits()
        {   
            string myValue = ".24*.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMultiplyZeroSingleDecimalDigits()
        {   
            string myValue = "-.23*0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyNegSingleDecimalDigits()
        {   
            string myValue = "0*-.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyZeroSingleDecimalDigits()
        {   
            string myValue = ".0*.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }    
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestDivideSingleDecimal
    {
        [TestMethod]
        public void posDividePosSingleDecimalDigits()
        {   
            string myValue = ".21/.22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.954545455"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posDivideNegSingleDecimalDigits()
        {   
            string myValue = ".21/-.31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.677419355"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negDividePosSingleDecimalDigits()
        {   
            string myValue = "-.21/.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negDivideNegSingleDecimalDigits()
        {   
            string myValue = "-.42/-.24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1.75"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDividePosSingleDecimalDigits()
        {   
            string myValue = ".0/.23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posDivideZeroSingleDecimalDigits()
        {   
            string myValue = ".24/.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negDivideZeroSingleDecimalDigits()
        {   
            string myValue = "-.23/.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDivideNegSingleDecimalDigits()
        {   
            string myValue = ".0/-.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDivideZeroSingleDecimalDigits()
        {   
            string myValue = ".0/.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }    
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestMultiplyDecimal
    {
        [TestMethod]
        public void posMultiplyPosDecimal()
        {   
            string myValue = "5.21*5.22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 27.1962"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMultiplyNegDecimal()
        {   
            string myValue = "2.21*-2.31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -5.1051"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMultiplyPosDecimal()
        {   
            string myValue = "-2.21*2.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -4.8841"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negMultiplyNegDecimal()
        {   
            string myValue = "-1.42*-1.24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1.7608"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyPosDecimal()
        {   
            string myValue = "0.0*3.23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posMultiplyZeroDecimal()
        {   
            string myValue = "3.24*0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negMultiplyZeroDecimal()
        {   
            string myValue = "-3.23*0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyNegDecimal()
        {   
            string myValue = "0.0*-2.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroMultiplyZeroDecimal()
        {   
            string myValue = "0.0*0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }        
    
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestDivideDecimal
    {
        [TestMethod]
        public void posDividePosDecimal()
        {   
            string myValue = "5.21/5.22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.998084291"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posDivideNegDecimal()
        {   
            string myValue = "2.21/-2.31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -0.956709957"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negDividePosDecimal()
        {   
            string myValue = "-2.21/2.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = -1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negDivideNegDecimal()
        {   
            string myValue = "-1.42/-1.24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1.145161290"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDividePosDecimal()
        {   
            string myValue = "0.0/3.23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posDivideZeroDecimal()
        {   
            string myValue = "3.24/0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negDivideZeroDecimal()
        {   
            string myValue = "-3.23/0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDivideNegDecimal()
        {   
            string myValue = "0.0/-2.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroDivideZeroDecimal()
        {   
            string myValue = "0.0/0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Cannot divide by zero"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }        
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestPowerSingleDigits
    {
        public void posPowerPosSingleDigits()
        {   
            string myValue = "2^2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 4"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }    

        [TestMethod]
        public void posPowerNegSingleDigits()
        {   
            string myValue = "2^-3";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.125"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPowerPosSingleDigits()
        {   
            string myValue = "-2^2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 4"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negPowerNegSingleDigits()
        {   
            string myValue = "-2^-2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.25"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerPosSingleDigits()
        {   
            string myValue = "0^2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPowerZeroSingleDigits()
        {   
            string myValue = "2^0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPowerZeroSingleDigits()
        {   
            string myValue = "-2^0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerNegSingleDigits()
        {   
            string myValue = "0^-2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerZeroSingleDigits()
        {   
            string myValue = "0^0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }
    }

/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestPowerDoubleDigits
    {
        [TestMethod]
        public void posPowerPosDoubleDigits()
        {   
            string myValue = "21^22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPowerNegDoubleDigits()
        {   
            string myValue = "21^-31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPowerPosDoubleDigits()
        {   
            string myValue = "-21^21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negPowerNegDoubleDigits()
        {   
            string myValue = "-42^-24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerPosDoubleDigits()
        {   
            string myValue = "0^23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPowerZeroDoubleDigits()
        {   
            string myValue = "24^0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPowerZeroDoubleDigits()
        {   
            string myValue = "-23^0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerNegDoubleDigits()
        {   
            string myValue = "00^-21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerZeroDoubleDigits()
        {   
            string myValue = "0.0^0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

    }

    [TestClass]
    public class UnitTestPowerSingleDecimal
    {
        [TestMethod]
        public void posPowerPosSingleDecimalDigits()
        {   
            string myValue = ".21^.22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.709395199"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPowerNegSingleDecimalDigits()
        {   
            string myValue = ".21^-.31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1.622228469"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPowerPosSingleDecimalDigits()//did not give overflow on calculator, may've done incorrect
        {   
            string myValue = "-.21^.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negPowerNegSingleDecimalDigits()
        {   
            string myValue = "-.4^-.2";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerPosSingleDecimalDigits()
        {   
            string myValue = "0^.23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPowerZeroSingleDecimalDigits()
        {   
            string myValue = ".24^.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPowerZeroSingleDecimalDigits()
        {   
            string myValue = "-.23^0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerNegSingleDecimalDigits()
        {   
            string myValue = "0^-.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerZeroSingleDecimalDigits()
        {   
            string myValue = ".0^.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }    
    }


/*----------------------------------------------------------------------------------- */
    [TestClass]
    public class UnitTestPowerDecimal
    {
        [TestMethod]
        public void posPowerPosDecimal()
        {   
            string myValue = "5.21^5.22";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 5519.413298368"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPowerNegDecimal()
        {   
            string myValue = "2.21^-2.31";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0.160123048"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPowerPosDecimal()
        {   
            string myValue = "-2.21^2.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void negPowerNegDecimal()//calculator did not give overflow, so may've done incorrect
        {   
            string myValue = "-1.42^-1.24";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerPosDecimal()
        {   
            string myValue = "0.0^3.23";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 0"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void posPowerZeroDecimal()
        {   
            string myValue = "3.24^0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }       

        [TestMethod]
        public void negPowerZeroDecimal()
        {   
            string myValue = "-3.23^0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerNegDecimal()
        {   
            string myValue = "0.0^-2.21";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>Error: Overflow would occur if attempt to take power to."; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }

        [TestMethod]
        public void zeroPowerZeroDecimal()
        {   
            string myValue = "0.0^0.0";
            String expectedOutput = $@"Please type in the expression you wish to calculate: <<{myValue}
>>{myValue} = 1"; 
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput,  src.Program.Main);
        }        
    }
}
