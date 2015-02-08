using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Mpir.NET
{
	public static class Algebraic
	{
		/*
		 * Compute int(sqrt(n) * 10^digits)
		 *
		 * This is done using Newton-Raphson method.
		 */
		public static mpz SqrtZ(ulong n, mpz digits)
		{
			mpz one;
			var r_dash = InverseSqrtImpl(n, digits, out one);

			return (r_dash * n * mpz.Ten.Power(digits)) / one;
		}

		public static mpz InverseSqrtZ(ulong n, mpz digits)
		{
			mpz one;
			var r_dash = InverseSqrtImpl(n, digits, out one);

			return (r_dash * mpz.Ten.Power(digits)) / one;
		}

		public static mpq SqrtQ(ulong n, mpz digits)
		{
			return new mpq(SqrtZ(n, digits), mpz.Ten.Power(digits));
		}

		public static mpq InverseSqrtQ(ulong n, mpz digits)
		{
			return new mpq(InverseSqrtZ(n, digits), mpz.Ten.Power(digits));
		}

		public static mpf SqrtF(ulong n, mpz digits)
		{
			return SqrtQ(n, digits).ToMpf();
		}

		public static mpf InverseSqrtF(ulong n, mpz digits)
		{
			return InverseSqrtQ(n, digits).ToMpf();
		}

		public static mpz InverseSqrtImpl(ulong x, mpz digits, out mpz one)
		{
			var r_i_dash = new mpz((1UL << 32) / Math.Sqrt(x));
			var e_i = new mpz(32);
			var one_i = mpz.One.ShiftLeft(e_i);

			var targetPrecision = 4 * digits;

			while (e_i <= targetPrecision)
			{
				var e_previ = e_i;
				e_i = e_i << 1;
				one_i = mpz.One.ShiftLeft(e_i);

				/*
				 * http://www.numberworld.org/y-cruncher/algorithms/invsqrt.html
				 * http://cs.stackexchange.com/a/37645
				 *
				 * w_i+1 = r_i^2
				 *       = r_i'^2 / 2^(2*e_i)
				 *  => w_i+1' = r_i'^2
				 * d_i+1 = 1 - w_i+1 * x
				 *       = 1 - r_i'^2 / 2^(2*e_i) * x
				 *       = (2^(2*e_i) - r_i'^2 * x) / 2^(2*e_i)
				 *  => d_i+1' = 2^(2*e_i) - w_i+1' * x
				 * r_i+1 = r_i * (1 + d_i+1 / 2)
				 *       = r_i' / 2^e_i * (1 + (d_i+1' / 2) / 2^(2*e_i))
				 *       = r_i' / 2^e_i * (2^(2*e_i) + d_i+1' / 2) / 2^(2*e_i)
				 *       = r_i' * (2^(2*e_i) + d_i+1' / 2) / 2^e_i / 2^(2*e_i)
				 *  => r_i+1' = r_i' * (2^(2*e_i) + d_i+1' / 2) / 2^e_i
				 */
				var w_i_dash = r_i_dash * r_i_dash;
				var d_i_dash = one_i - w_i_dash * x;
				r_i_dash = (r_i_dash * (one_i + (d_i_dash >> 1))).ShiftRight(e_previ);
			}

			one = one_i;
			return r_i_dash;
		}
	}
}

// ReSharper restore InconsistentNaming
