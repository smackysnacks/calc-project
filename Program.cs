using System;
using System.Collections.Generic;

namespace Calculator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			FunTest ();

			string[] expressions = {
				"3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3",
				"4 + 2",
				"3.1415 * -3.1415"
			};

			foreach (var expression in expressions)
				TestExpression (expression);
		}

		public static void TestExpression(string expression)
		{
			Console.WriteLine ("Testing expression: " + expression);

			ShuntingYard algorithm = new ShuntingYard (Lexer.Tokenize (expression));
			Queue<Token> postfixNotation = algorithm.PostfixTokens;

			Console.Write ("Evaluating expression: ");
			foreach (var token in postfixNotation) {
				Console.Write (token.Value + " ");
			}
			Console.WriteLine ();

			Console.Write ("Result: ");
			Evaluator evaluator = new Evaluator (postfixNotation);
			Console.WriteLine (evaluator.Evaluate ());
		}

		public static void FunTest()
		{

		}
	}
}
