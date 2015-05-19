using System;
using System.Collections.Generic;

namespace Calculator
{
	public class Evaluator
	{
		readonly Queue<Token> postfixExpression;

		public Evaluator (Queue<Token> postfixExpression)
		{
			this.postfixExpression = postfixExpression;
		}

		public double Evaluate()
		{
			Stack<Token> evaluationStack = new Stack<Token> ();
			foreach (var token in postfixExpression) {
				if (token.Type == TokenType.Number) {
					evaluationStack.Push (token);
				} else {
					Token temp = evaluationStack.Pop ();
					Operator op = new Operator (token);

					double result = op.Operation(Double.Parse(evaluationStack.Pop().Value), Double.Parse(temp.Value));
					evaluationStack.Push (new Token (result.ToString ()));
				}
			}

			return Double.Parse (evaluationStack.Pop ().Value);
		}
	}
}

