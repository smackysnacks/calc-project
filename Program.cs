using System;
using System.Collections.Generic;

namespace Calculator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			while (true) {
				Console.Write (">>> ");
				string expression = Console.ReadLine ();

				ShuntingYard algorithm = new ShuntingYard (Lexer.Tokenize (expression));
				Queue<Token> postfixNotation = algorithm.PostfixTokens;
				Evaluator evaluator = new Evaluator (postfixNotation);
				Console.WriteLine (evaluator.Evaluate ());
			}
		}

		public static void TestCases()
		{
			string[] expressions = {
				"min(((-((42)))      * sin(    pi/2 + pi))*2,64)",
				"sin(pi/2) +4",
				"+(42)",
				"3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3",
				"4 + 2",
				"3.1415 * -3.1415",
				"sin ( 1.570795 )",
				"sin ( abs ( -4 * 3 ^ 2 ) + 1 )",
				"sin ( pi / 2 )",
				"min ( pi , pi / 2 )",
				"max ( pi , pi / 2 )",
				"3*2+42.14-3",
				"sin(pi/2) * 3 +2",
				"-(42) * 2",
				"avg(2, 3)",
				"sqrt(9)",
				"vavg(4, 3, 2, 6, 4) + 100",
				"cos(pi/2)"
			};

			foreach (string expression in expressions) {
				ShuntingYard algorithm = new ShuntingYard (Lexer.Tokenize (expression));
				Queue<Token> postfixNotation = algorithm.PostfixTokens;
				Evaluator evaluator = new Evaluator (postfixNotation);
				Console.WriteLine (evaluator.Evaluate ());
			}
		}
	}
}
