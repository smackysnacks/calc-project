using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Calculator
{
	public static class Lexer
	{
		public static Queue<Token> Tokenize (string expression)
		{
			Queue<Token> tokens = new Queue<Token> ();
			const string pattern = @"(\+|-|\*|/|\^|\(|\)|,|sin|cos|tan|min|max|abs|neg|avg|sqrt|vavg)";

			expression = expression.Replace ("pi", Math.PI.ToString());
			expression = expression.Replace (" ", "");
			foreach (string tok in Regex.Split(expression, pattern)) {
				if (tok != "")
					tokens.Enqueue (new Token (tok));
			}

			return tokens;
		}
	}
}

