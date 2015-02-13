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

			public PQ CanonicalizeIf(bool condition)
			{
				if (!condition)
					return this;

				var gcd = mpz.Gcd(P, Q);

				return (gcd == 1)
					? this
					: new PQ
					{
						P = P.DivideExactly(gcd),
						Q = Q.DivideExactly(gcd)
					};
			}
		}

		public struct PQT
		{
			public mpz P;
			public mpz Q;
			public mpz T;
		}

		/*
		 * = c * (f_0 * t_0 + f_1 * t_1 + ... + f_n * t_n)
		 */
		public static PQ LinearCombinationOfPQTerms(IList<PQ> terms, IList<mpz> factors = null, mpz commonFactor = null, bool canonicalizeDirectlyComputed = false, bool canonicalizeRecursivelyCombined = false, bool canonicalizeResult = false)
		{
			if (terms == null)
				throw new ArgumentNullException("terms");

			factors = factors ?? new[] { mpz.One };

			Func<int, int, PQ> directlyCompute = (a, b) =>
			{
				var f = factors[a % factors.Count];
				return (f == 1)
					? terms[a].CanonicalizeIf(canonicalizeDirectlyComputed)
					: new PQ { P = f * terms[a].P, Q = terms[a].Q }.CanonicalizeIf(canonicalizeDirectlyComputed);
			};

			Func<PQ, PQ, PQ> recursivelyCombine = (am, mb) => new PQ { P = am.P * mb.Q + mb.P * am.Q, Q = am.Q * mb.Q }.CanonicalizeIf(canonicalizeRecursivelyCombined);

			var ans = BinarySplitting(0, terms.Count, directlyCompute, recursivelyCombine);

			return (commonFactor == null)
				? ans.CanonicalizeIf(canonicalizeResult)
				: new PQ { P = commonFactor * ans.P, Q = ans.Q }.CanonicalizeIf(canonicalizeResult);
		}

		// ReSharper restore InconsistentNaming

		/*
		 * http://numbers.computation.free.fr/Constants/Algorithms/splitting.html
		 */
		public static T BinarySplitting<T>(mpz a, mpz b, Func<mpz, mpz, T> directlyCompute, Func<T, T, T> recursivelyCombine, int rangeThreshold = _BINARY_SPLITTING_RECURSION_THRESHOLD)
		{
			if (a == null)
				throw new ArgumentNullException("a");
			if (b == null)
				throw new ArgumentNullException("b");
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
