using System;
using System.Collections.Generic;

namespace Calculator
{
	public enum TokenType {Number, Function, FunctionArgSeparator, Operator, LeftParen, RightParen};

	public class Token
	{
		private static readonly Dictionary<string, TokenType> validTokens = new Dictionary<string, TokenType>() {
			{"^", TokenType.Operator},
			{"*", TokenType.Operator},
			{"/", TokenType.Operator},
			{"+", TokenType.Operator},
			{"-", TokenType.Operator},
			{"(", TokenType.LeftParen},
			{")", TokenType.RightParen},
			{"sin", TokenType.Function},
			{"cos", TokenType.Function},
			{"tan", TokenType.Function}
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
