using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Mpir.NET
{
	public static partial class Constant
	{
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

			//how many terms to compute
			Func<mpz, mpz, mpz, mpz> search = null;
			search = (a, b, x) =>
			{
				if (b - a < 100) return b;

				var m = (a + b) / 2;
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
				return ((m.Length(10) - 2) * m - m) < x
					? search(m, b, x)
					: search(a, m, x);
			};
			var N = search(0, digits, digits);

			// Calclate P(0,N) and Q(0,N)
			var PQ = Series.SumOfMachinLikeFormulaWithBinarySplitting(0, N, directlyCompute, recursivelyCombine);
			var one = mpz.Ten.Power(digits);

			return one + (one * PQ.P) / PQ.Q;
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
