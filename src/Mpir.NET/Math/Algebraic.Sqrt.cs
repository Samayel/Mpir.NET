using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Mpir.NET
{
	public static partial class Algebraic
	{
		private const int _SQRT_INITIAL_GUESS_BITS = 32;

		/*
		 * Compute int(sqrt(n) * 10^digits)
		 *
		 * This is done using Newton-Raphson method.
		 */
		public static mpz SqrtZ(ulong n, mpz digits)
		{
			mpz e;
			var r_dash = InverseSqrtImpl(n, digits, out e);

			// (r' / 2^e) * n * 10^digits
			return (r_dash * n * new mpz(5).Power(digits)).ShiftRight(e - digits);
		}

		public static mpz InverseSqrtZ(ulong n, mpz digits)
		{
			mpz e;
			var r_dash = InverseSqrtImpl(n, digits, out e);

			// (r' / 2^e) * 10^digits
			return (r_dash * new mpz(5).Power(digits)).ShiftRight(e - digits);
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

		public static mpz InverseSqrtImpl(ulong x, mpz digits, out mpz e)
		{
			var r_i_dash = new mpz((1UL << _SQRT_INITIAL_GUESS_BITS) / Math.Sqrt(x));
			var e_i = new mpz(_SQRT_INITIAL_GUESS_BITS);

			var targetPrecision = digits << 2; // bits per digit = log(10)/log(2) ~ 3.3

			while (e_i <= targetPrecision)
			{
				var e_previ = e_i;
				e_i = e_i << 1;
				var one_i = mpz.One.ShiftLeft(e_i);

				/*
				 * http://www.numberworld.org/y-cruncher/algorithms/invsqrt.html
				 * http://cs.stackexchange.com/a/37645
				 *
				 * w_i+1 = r_i^2
				 *       = r_i'^2 / 2^(2*e_i)
				 *  => w_i+1' = r_i'^2
				 *  
				 * d_i+1 = 1 - w_i+1 * x
				 *       = 1 - r_i'^2 / 2^(2*e_i) * x
				 *       = (2^(2*e_i) - r_i'^2 * x) / 2^(2*e_i)
				 *  => d_i+1' = 2^(2*e_i) - w_i+1' * x
				 *  
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

			e = e_i;
			return r_i_dash;
		}
	}
}

// ReSharper restore InconsistentNaming
