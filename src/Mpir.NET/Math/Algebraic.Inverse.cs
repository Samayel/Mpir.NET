﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Mpir.NET
{
	public static partial class Algebraic
	{
		private const int _INVERSE_INITIAL_GUESS_BITS = 32;

		/*
		 * Compute int(1/n * 10^digits)
		 *
		 * This is done using Newton-Raphson method.
		 */
		public static mpz InverseZ(ulong n, mpz digits)
		{
			mpz e;
			var r_dash = InverseImpl(n, digits, out e);

			// (r' / 2^e) * 10^digits
			return (r_dash * new mpz(5).Power(digits)).ShiftRight(e - digits);
		}

		public static mpq InverseQ(ulong n, mpz digits)
		{
			return new mpq(InverseZ(n, digits), mpz.Ten.Power(digits));
		}

		public static mpf InverseF(ulong n, mpz digits)
		{
			return InverseQ(n, digits).ToMpf();
		}

		public static mpz InverseImpl(ulong x, mpz digits, out mpz e)
		{
			if (digits == null)
				throw new ArgumentNullException("digits");
			if (digits <= 0)
				throw new ArgumentOutOfRangeException("digits");

			var r_i_dash = new mpz((1UL << _INVERSE_INITIAL_GUESS_BITS) / ((double) x));
			var e_i = new mpz(_INVERSE_INITIAL_GUESS_BITS);

			var targetPrecision = digits << 2; // bits per digit = log(10)/log(2) ~ 3.3

			while (e_i <= targetPrecision)
			{
				var e_previ = e_i;
				e_i = e_i << 1;
				var one_i = mpz.One.ShiftLeft(e_i);

				/*
				 * http://www.numberworld.org/y-cruncher/algorithms/division.html
				 * 
				 * d_i+1 = r_i * x - 1
				 *       = (r_i' * x - 2^e_i) / 2^e_i
				 *       = (r_i' * x * 2^e_i - 2^(2*e_i)) / 2^(2*e_i)
				 * 
				 * r_i+1 = r_i * (1 - d_i+1)
				 *       = r_i' / 2^e_i * (1 - d_i+1' / 2^(2*e_i))
				 * 	     = r_i' * (2^(2*e_i) - d_i+1') / 2^e_i / 2^(2*e_i)
				 */
				var d_i_dash = (r_i_dash * x).ShiftLeft(e_previ) - one_i;
				r_i_dash = (r_i_dash * (one_i - d_i_dash)).ShiftRight(e_previ);
			}

			e = e_i;
			return r_i_dash;
		}
	}
}

// ReSharper restore InconsistentNaming
