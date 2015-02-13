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

		public static PQ LinearCombinationOfPQTerms(IList<PQ> terms, IList<mpz> factors = null)
		{
			if (terms == null)
				throw new ArgumentNullException("terms");

			factors = factors ?? new[] { mpz.One };

			Func<int, int, PQ> directlyCompute = (a, b) => new PQ { P = factors[a % factors.Count] * terms[a].P, Q = terms[a].Q };
			Func<PQ, PQ, PQ> recursivelyCombine = (am, mb) => new PQ { P = am.P * mb.Q + mb.P * am.Q, Q = am.Q * mb.Q };

			return BinarySplitting(0, terms.Count, directlyCompute, recursivelyCombine);
		}

		// ReSharper restore InconsistentNaming

		/*
		 * http://numbers.computation.free.fr/Constants/Algorithms/splitting.html
		 */
		public static T BinarySplitting<T>(mpz a, mpz b, Func<mpz, mpz, T> directlyCompute, Func<T, T, T> recursivelyCombine, int rangeThreshold = _BINARY_SPLITTING_RECURSION_THRESHOLD)
		{
			if (a < 0)
				throw new ArgumentOutOfRangeException("a");
			if (b <= a)
				throw new ArgumentOutOfRangeException("b");
			if (directlyCompute == null)
				throw new ArgumentNullException("directlyCompute");
			if (recursivelyCombine == null)
				throw new ArgumentNullException("recursivelyCombine");
			if (rangeThreshold < 1)
				throw new ArgumentOutOfRangeException("rangeThreshold");

			return BinarySplittingImpl(a, b, directlyCompute, recursivelyCombine, rangeThreshold);
		}

		public static T BinarySplitting<T>(int a, int b, Func<int, int, T> directlyCompute, Func<T, T, T> recursivelyCombine, int rangeThreshold = _BINARY_SPLITTING_RECURSION_THRESHOLD)
		{
			if (a < 0)
				throw new ArgumentOutOfRangeException("a");
			if (b <= a)
				throw new ArgumentOutOfRangeException("b");
			if (directlyCompute == null)
				throw new ArgumentNullException("directlyCompute");
			if (recursivelyCombine == null)
				throw new ArgumentNullException("recursivelyCombine");
			if (rangeThreshold < 1)
				throw new ArgumentOutOfRangeException("rangeThreshold");

			return BinarySplittingImpl(a, b, directlyCompute, recursivelyCombine, rangeThreshold);
		}

		private static T BinarySplittingImpl<T>(mpz a, mpz b, Func<mpz, mpz, T> directlyCompute, Func<T, T, T> recursivelyCombine, int rangeThreshold)
		{
			// Directly compute e.g. P(a, a + rangeThreshold) and Q(a, a + rangeThreshold)
			if ((b - a) <= rangeThreshold)
			{
				return directlyCompute(a, b);
			}

			// Recursively compute e.g. P(a, b) and Q(a, b)

			// m is the midpoint of a and b
			var m = (a + b) >> 1;

			// Recursively calculate e.g. P(a, m) and Q(a, m)
			var am = BinarySplittingImpl(a, m, directlyCompute, recursivelyCombine, rangeThreshold);
			// Recursively calculate e.g. P(m, b) and Q(m, b)
			var mb = BinarySplittingImpl(m, b, directlyCompute, recursivelyCombine, rangeThreshold);

			// Now combine
			return recursivelyCombine(am, mb);
		}

		private static T BinarySplittingImpl<T>(int a, int b, Func<int, int, T> directlyCompute, Func<T, T, T> recursivelyCombine, int rangeThreshold)
		{
			// Directly compute e.g. P(a, a + rangeThreshold) and Q(a, a + rangeThreshold)
			if ((b - a) <= rangeThreshold)
			{
				return directlyCompute(a, b);
			}

			// Recursively compute e.g. P(a, b) and Q(a, b)

			// m is the midpoint of a and b
			var m = (a + b) >> 1;

			// Recursively calculate e.g. P(a, m) and Q(a, m)
			var am = BinarySplittingImpl(a, m, directlyCompute, recursivelyCombine, rangeThreshold);
			// Recursively calculate e.g. P(m, b) and Q(m, b)
			var mb = BinarySplittingImpl(m, b, directlyCompute, recursivelyCombine, rangeThreshold);

			// Now combine
			return recursivelyCombine(am, mb);
		}
	}
}
