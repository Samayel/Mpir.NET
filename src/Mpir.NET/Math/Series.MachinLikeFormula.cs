using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Mpir.NET
{
	public static partial class Series
	{
		public struct PQ
		{
			public mpz P;
			public mpz Q;
		}

		public struct PQT
		{
			public mpz P;
			public mpz Q;
			public mpz T;
		}

		/*
		 * http://numbers.computation.free.fr/Constants/Algorithms/splitting.html
		 */
		public static T SumOfMachinLikeFormulaWithBinarySplitting<T>(mpz a, mpz b, Func<mpz, mpz, T> directlyCompute, Func<T, T, T> recursivelyCombine)
		{
			// Directly compute P(a,a+1) and Q(a,a+1)
			if (b - a == 1)
			{
				return directlyCompute(a, b);
			}

			// Recursively compute P(a,b) and Q(a,b)

			// m is the midpoint of a and b
			var m = (a + b) >> 1;

			// Recursively calculate P(a,m) and Q(a,m)
			var am = SumOfMachinLikeFormulaWithBinarySplitting(a, m, directlyCompute, recursivelyCombine);
			// Recursively calculate P(m,b) and Q(m,b)
			var mb = SumOfMachinLikeFormulaWithBinarySplitting(m, b, directlyCompute, recursivelyCombine);

			// Now combine
			return recursivelyCombine(am, mb);
		}
	}
}

// ReSharper restore InconsistentNaming
