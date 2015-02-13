using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	public static partial class Series
	{
		private const int _BINARY_SPLITTING_RECURSION_THRESHOLD = 1;

		// ReSharper disable InconsistentNaming

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

		// ReSharper restore InconsistentNaming

		/*
		 * http://numbers.computation.free.fr/Constants/Algorithms/splitting.html
		 */
		public static T SumOfMachinLikeFormulaWithBinarySplitting<T>(mpz a, mpz b, Func<mpz, mpz, T> directlyCompute, Func<T, T, T> recursivelyCombine, int threshold = _BINARY_SPLITTING_RECURSION_THRESHOLD)
		{
			// Directly compute e.g. P(a, a + threshold) and Q(a, a + threshold)
			if (b - a <= threshold)
			{
				return directlyCompute(a, b);
			}

			// Recursively compute e.g. P(a, b) and Q(a, b)

			// m is the midpoint of a and b
			var m = (a + b) >> 1;

			// Recursively calculate e.g. P(a, m) and Q(a, m)
			var am = SumOfMachinLikeFormulaWithBinarySplitting(a, m, directlyCompute, recursivelyCombine, threshold);
			// Recursively calculate e.g. P(m, b) and Q(m, b)
			var mb = SumOfMachinLikeFormulaWithBinarySplitting(m, b, directlyCompute, recursivelyCombine, threshold);

			// Now combine
			return recursivelyCombine(am, mb);
		}
	}
}
