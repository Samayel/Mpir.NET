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

			// http://numbers.computation.free.fr/Constants/Algorithms/splitting.html
			Func<mpz, mpz, PQ> bs = null;
			bs = (a, b) =>
			{
				mpz Pab, Qab;
				// Directly compute P(a,a+1) and Q(a,a+1)
				if (b - a == 1)
				{
					Pab = mpz.One;
					Qab = b;
				}
				// Recursively compute P(a,b) and Q(a,b)
				else
				{
					// m is the midpoint of a and b
					var m = (a + b) / 2;
					// Recursively calculate P(a,m) and Q(a,m)
					var PQam = bs(a, m);
					// Recursively calculate P(m,b) and Q(m,b)
					var PQmb = bs(m, b);
					// Now combine
					Pab = PQam.P * PQmb.Q + PQmb.P;
					Qab = PQam.Q * PQmb.Q;
				}
				return new PQ {P = Pab, Q = Qab};
			};

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
			var PQ = bs(0, N);
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
