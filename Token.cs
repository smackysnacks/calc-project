using System;
using System.Collections.Generic;

namespace Calculator
{
	public enum TokenType {None, Number, Function, FunctionArgSeparator, Operator, LeftParen, RightParen};

	public class Token
	{
		private static readonly Dictionary<string, TokenType> validTokens = new Dictionary<string, TokenType>() {
			{"^", TokenType.Operator},
			{"*", TokenType.Operator},
			{"/", TokenType.Operator},
			{"+", TokenType.Operator},
			{"-", TokenType.Operator},
			{"#", TokenType.Operator},
			{"@", TokenType.Operator},
			{"(", TokenType.LeftParen},
			{")", TokenType.RightParen},
			{",", TokenType.FunctionArgSeparator},
			{"sin", TokenType.Function},
			{"cos", TokenType.Function},
			{"tan", TokenType.Function},
			{"abs", TokenType.Function},
			{"max", TokenType.Function},
			{"min", TokenType.Function},
			{"neg", TokenType.Function},
			{"avg", TokenType.Function},
			{"sqrt", TokenType.Function},
			{"vavg", TokenType.Function}
		};

		TokenType type;
		string value;

		public TokenType Type {
			get {
				return type;
			}
		}

		public String Value {
			get {
				return value;
			}
		}

		public Token (string value)
		{
			this.value = value;
			this.type = GetTokenType ();
		}

		private TokenType GetTokenType()
		{
			TokenType tokenType;
			if (!validTokens.TryGetValue (this.value, out tokenType)) {
				// TODO may not actually be a number.
				tokenType = TokenType.Number;
			}

			return tokenType;
		}
	}
}
