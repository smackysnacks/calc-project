using System;
using System.Collections.Generic;

namespace Calculator
{
	/// <summary>
	/// http://en.wikipedia.org/wiki/Shunting-yard_algorithm
	/// </summary>
	public class ShuntingYard
	{
		readonly Queue<Token> infixTokens;

		public ShuntingYard (Queue<Token> infixTokens)
		{
			this.infixTokens = infixTokens;
		}

		public Queue<Token> PostfixTokens
		{
			get {
				return InfixToPostfix ();
			}
		}

		private static Queue<Token> CloneQueue(Queue<Token> queue)
		{
			Queue<Token> clonedQueue = new Queue<Token>();
			foreach (var item in queue) {
				clonedQueue.Enqueue (item);
			}
			return clonedQueue;
		}

		private Queue<Token> InfixToPostfix()
		{
			Queue<Token> infixTokensCopy = CloneQueue (this.infixTokens); // mutate separate queue
			Queue<Token> outputQueue = new Queue<Token> ();
			Stack<Token> operatorStack = new Stack<Token> ();
			TokenType lastTokenType = TokenType.None;

			while (infixTokensCopy.Count > 0) {
				Token token = infixTokensCopy.Dequeue ();

				if (token.Type == TokenType.Number) {
					outputQueue.Enqueue (token);
				} else if (token.Type == TokenType.Function) {
					operatorStack.Push (token);
				} else if (token.Type == TokenType.FunctionArgSeparator) {
					while (operatorStack.Peek().Type != TokenType.LeftParen) {
						outputQueue.Enqueue (operatorStack.Pop ());
					}
				} else if (token.Type == TokenType.Operator) {
					if ((operatorStack.Count == 0 && outputQueue.Count == 0) ||
							(lastTokenType == TokenType.Operator) ||
							(lastTokenType == TokenType.LeftParen)) { // this is a unary operator
						if (token.Value == "-") {
							token = new Token ("#"); // unary minus operator
						} else if (token.Value == "+") {
							token = new Token ("@");
						}
					}

					Operator operator1 = new Operator (token);
					while (operatorStack.Count > 0 && operatorStack.Peek().Type == TokenType.Operator) {
						Operator operator2 = new Operator (operatorStack.Peek ());

						if ((operator1.Associativity == "left" && operator1.Precedence <= operator2.Precedence) ||
						    (operator1.Associativity == "right" && operator1.Precedence < operator2.Precedence)) {
							operatorStack.Pop ();
							outputQueue.Enqueue (operator2.Op);
						} else {
							break;
						}
					}
					operatorStack.Push (operator1.Op);
				} else if (token.Type == TokenType.LeftParen) {
					operatorStack.Push (token);
				} else if (token.Type == TokenType.RightParen) {
					while (operatorStack.Peek().Type != TokenType.LeftParen) {
						outputQueue.Enqueue (operatorStack.Pop ());
					}

					operatorStack.Pop (); // discard left parenthesis

					if (operatorStack.Count > 0 && operatorStack.Peek().Type == TokenType.Function) {
						outputQueue.Enqueue (operatorStack.Pop ());
					}
				}

				lastTokenType = token.Type;
			}

			while (operatorStack.Count > 0)
				outputQueue.Enqueue (operatorStack.Pop ());

			return outputQueue;
		}
	}
}
