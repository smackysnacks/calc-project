using System;
using System.Collections.Generic;

namespace Calculator
{
	public static class Function
	{
		public static double Call(string function, Stack<Token> argumentStack)
		{
			switch (function) {
			case "sin":
				return Math.Sin (GetArg(argumentStack));
			case "cos":
				return Math.Cos (GetArg(argumentStack));
			case "tan":
				return Math.Tan (GetArg(argumentStack));
			case "abs":
				return Math.Abs (GetArg(argumentStack));
			case "max":
				return Math.Max (GetArg(argumentStack), GetArg(argumentStack));
			case "min":
				return Math.Min (GetArg(argumentStack), GetArg(argumentStack));
			case "neg":
				return -GetArg (argumentStack);
			case "avg":
				return (GetArg(argumentStack) + GetArg(argumentStack)) / 2;
			case "sqrt":
				return Math.Sqrt (GetArg(argumentStack));
			case "vavg":
				int count = (int)GetArg(argumentStack);
				double sum = 0;
				for (int i = 0; i < count; ++i)
					sum += GetArg(argumentStack);

				return sum / count;
			}

			throw new ArgumentException (String.Format ("Invalid function, {0}", function));
		}

		private static double GetArg(Stack<Token> argumentStack)
		{
			return double.Parse (argumentStack.Pop ().Value);
		}
	}
}
