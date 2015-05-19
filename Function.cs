using System;
using System.Collections.Generic;

namespace Calculator
{
	public static class Function
	{
		public static double Call(string function, Stack<Token> argumentStack)
		{
			Queue<double> args = new Queue<double> ();

			switch (function) {
			case "sin":
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				return Math.Sin (args.Dequeue ());
			case "cos":
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				return Math.Cos (args.Dequeue ());
			case "tan":
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				return Math.Tan (args.Dequeue ());
			case "abs":
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				return Math.Abs (args.Dequeue ());
			case "max":
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				return Math.Max (args.Dequeue (), args.Dequeue ());
			case "min":
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				return Math.Min (args.Dequeue (), args.Dequeue ());
			case "neg":
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				return -args.Dequeue ();
			case "avg":
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				return (args.Dequeue() + args.Dequeue()) / 2;
			case "sqrt":
				args.Enqueue (double.Parse (argumentStack.Pop ().Value));
				return Math.Sqrt (args.Dequeue ());
			case "vavg":
				int count = int.Parse (argumentStack.Pop ().Value);
				double sum = 0;
				for (int i = 0; i < count; ++i)
					sum += double.Parse (argumentStack.Pop ().Value);

				return sum / count;
			}

			throw new ArgumentException (String.Format ("Invalid function, {0}", function));
		}
	}
}
