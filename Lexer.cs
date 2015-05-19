using System;
using System.Collections.Generic;

namespace Calculator
{
	public static class Lexer
	{
		public static Queue<Token> Tokenize (string expression)
		{
			Queue<Token> tokens = new Queue<Token> ();

			foreach (string tok in expression.Split (new string[] { " " }, StringSplitOptions.None)) {
				tokens.Enqueue (new Token (tok));
			}

			return tokens;
		}
	}
}

