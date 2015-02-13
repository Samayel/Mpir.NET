using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Mpir.NET
{
	public static partial class Constant
	{
		private const int _MPZ_DIGITS_IN_BASE_10_UNDERESTIMATION = 2;
		/*
		 * Compute int(e * 10^digits)
		 *
		 * This is done using Taylor series of exp(1) with binary splitting
		 */
		public static mpz eZ(mpz digits)
		{
			if (digits < 0)
				throw new ArgumentOutOfRangeException("digits");

			Func<mpz, mpz, Series.PQ> directlyCompute = (a, b) => new Series.PQ { P = mpz.One, Q = b };
			Func<Series.PQ, Series.PQ, Series.PQ> recursivelyCombine = (am, mb) => new Series.PQ { P = am.P * mb.Q + mb.P, Q = am.Q * mb.Q };

			// How many terms to compute
			Func<mpz, mpz, mpz, mpz> search = null;
			search = (a, b, x) =>
			{
				if (b - a < 100) return b;

				var m = (a + b) >> 1;
				/*
				 * http://www.johndcook.com/blog/2011/06/10/stirling-approximation/
				 * 
				 *             k! > 10^digits
				 * =>      log k! > digits
				 * => k log k - k > digits
				 * 
				 * with log n! = sum_k=1^n log k
				 *            >= int_x=1^n log x dx
				 *             = n log n - n + 1
				 *             > n log n - n
				 */
				return (m * (m.Length(10) - _MPZ_DIGITS_IN_BASE_10_UNDERESTIMATION) - m) < x
					? search(m, b, x)
					: search(a, m, x);
			};
			var n = search(0, digits, digits);

			// Calculate P(0, N) and Q(0, N)
			var pq = Series.SumOfMachinLikeFormulaWithBinarySplitting(0, n, directlyCompute, recursivelyCombine);
			var one = mpz.Ten.Power(digits);

			return one + (one * pq.P) / pq.Q;
		}

		public static mpq eQ(mpz digits)
		{
			return new mpq(eZ(digits), mpz.Ten.Power(digits));
		}

		public static mpf eF(mpz digits)
		{
			return eQ(digits).ToMpf();
		}
	}
}

// ReSharper restore InconsistentNaming
