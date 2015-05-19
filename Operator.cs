using System;
using System.Collections.Generic;

namespace Calculator
{
	public class Operator
	{
		public delegate double EvaluationDelegate(double x, double y);

		/// <summary>
		/// Dictionary mapping operator string to a 2-tuple where the first
		/// item in the tuple is operator precendence and the second item in
		/// the tuple is associativity.
		/// </summary>
		private readonly Dictionary<string, Tuple<int, string, EvaluationDelegate>> operatorInfo =
			new Dictionary<string, Tuple<int, string, EvaluationDelegate>> ()
		{
			{"^", new Tuple<int, string, EvaluationDelegate> (4, "right", Math.Pow)},
			{"*", new Tuple<int, string, EvaluationDelegate>(3, "left", (x, y) => x * y)},
			{"/", new Tuple<int, string, EvaluationDelegate>(3, "left", (x, y) => x / y)},
			{"+", new Tuple<int, string, EvaluationDelegate>(2, "left", (x, y) => x + y)},
			{"-", new Tuple<int, string, EvaluationDelegate>(2, "left", (x, y) => x - y)},
		};

		private readonly Token op;

		public Operator (Token token)
		{
			this.op = token;
		}

		public Token Op {
			get {
				return op;
			}
		}

		public int Precedence {
			get {
				Tuple<int, string, EvaluationDelegate> tuple;
				operatorInfo.TryGetValue (op.Value, out tuple);

				return tuple.Item1;
			}
		}

		public string Associativity {
			get {
				Tuple<int, string, EvaluationDelegate> tuple;
				operatorInfo.TryGetValue (op.Value, out tuple);

				return tuple.Item2;
			}
		}

		public EvaluationDelegate Operation {
			get {
				Tuple<int, string, EvaluationDelegate> tuple;
				operatorInfo.TryGetValue (op.Value, out tuple);

				return tuple.Item3;
			}
		}
	}
}

