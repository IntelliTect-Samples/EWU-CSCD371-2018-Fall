using IntelliTect.TestTools.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
	[TestClass]
	public class CalculatorTest
	{
		[TestMethod]
		public void TestCalculatorAddSucceed()
		{
			ConsoleAssert.Expect(GenerateConsoleOutputSucceed(3, 5, "+", 8), Calculator.Calculator.Main);
		}

		[TestMethod]
		public void TestCalculatorSubtractSucceed()
		{
			ConsoleAssert.Expect(GenerateConsoleOutputSucceed(3, 5, "-", -2), Calculator.Calculator.Main);
		}

		[TestMethod]
		public void TestCalculatorMultiplySucceed()
		{
			ConsoleAssert.Expect(GenerateConsoleOutputSucceed(3, 5, "*", 15), Calculator.Calculator.Main);
		}

		[TestMethod]
		public void TestCalculatorMultiplyAltSucceed()
		{
			ConsoleAssert.Expect(GenerateConsoleOutputSucceed(3, 5, "x", 15), Calculator.Calculator.Main);
		}

		[TestMethod]
		public void TestCalculatorDivideSucceed()
		{
			ConsoleAssert.Expect(GenerateConsoleOutputSucceed(3, 5, "/", (decimal) 0.6), Calculator.Calculator.Main);
		}

		[TestMethod]
		public void TestCalculatorPowSucceed()
		{
			ConsoleAssert.Expect(GenerateConsoleOutputSucceed(3, 5, "**", 243), Calculator.Calculator.Main);
		}

		[TestMethod]
		public void TestCalculatorDivideByZero()
		{
			ConsoleAssert.Expect(GenerateConsoleOutputFail("1 / 0", "Cannot divide by zero."), Calculator.Calculator.Main);
		}

		[TestMethod]
		public void TestCalculatorInvalidInputAll()
		{
			ConsoleAssert.Expect(GenerateConsoleOutputFail("fail", "Expression is not properly formatted."), Calculator.Calculator.Main);
		}

		[TestMethod]
		public void TestCalculatorInvalidInputLeftOperand()
		{
			ConsoleAssert.Expect(GenerateConsoleOutputFail("invalid + 1", "Left operand is not a valid number."), Calculator.Calculator.Main);
		}

		[TestMethod]
		public void TestCalculatorInvalidInputRightOperand()
		{
			ConsoleAssert.Expect(GenerateConsoleOutputFail("1 + invalid", "Right operand is not a valid number."), Calculator.Calculator.Main);
		}

		[TestMethod]
		public void TestCalculatorInvalidInputOperator()
		{
			ConsoleAssert.Expect(GenerateConsoleOutputFail("1 invalid 1", "Passed in operator is not a valid operator."), Calculator.Calculator.Main);
		}

		private string GenerateConsoleOutputSucceed(decimal leftOperand, decimal rightOperand, string expressionOperator,
			decimal expectedOutput)
		{
			return $@"{initialConsoleOutput}
<<{leftOperand} {expressionOperator} {rightOperand}
>>Answer: {expectedOutput}
{endConsoleOutput}";
		}

		private string GenerateConsoleOutputFail(string badInput, string failOutput)
		{
			return $@"{initialConsoleOutput}
<<{badInput}
>>{failOutput}
{endConsoleOutput}";
		}

		private readonly string initialConsoleOutput = $@">>Welcome to Calculator!
>>Enter a mathematical expression or type 'help' for available operations.";

		private readonly string endConsoleOutput = $@">>
Type 'n' to end program, type new expression to continue.

<<n";
	}
}
