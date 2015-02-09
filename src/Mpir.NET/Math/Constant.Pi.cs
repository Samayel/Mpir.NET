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
		 * Compute int(pi * 10^digits)
		 *
		 * This is done using Chudnovsky's series with binary splitting
		 */
		public static mpz PiZ(mpz digits)
		{
			if (digits < 0)
				throw new ArgumentOutOfRangeException("digits");

			const long C = 640320;
			const long C3_OVER_24 = C * C * C / 24;

			/*
			 * Source: http://www.craig-wood.com/nick/articles/pi-chudnovsky/
			 * 
			 * Computes the terms for binary splitting the Chudnovsky infinite series
			 * 
			 * a(a) = +/- (13591409 + 545140134*a)
			 * p(a) = (6*a-5)*(2*a-1)*(6*a-1)
			 * b(a) = 1
			 * q(a) = a*a*a*C3_OVER_24
			 */
			Func<mpz, mpz, Series.PQT> directlyCompute = (a, b) =>
			{
				mpz Pab, Qab;
				if (a == 0)
				{
					Pab = Qab = mpz.One;
				}
				else
				{
					Pab = (6 * a - 5) * (2 * a - 1) * (6 * a - 1);
					Qab = a.Power(3U) * C3_OVER_24;
				}

				// t(a) = a(a) * p(a)
				var Tab = Pab * (13591409 + 545140134 * a);
				if (a.IsOdd())
				{
					Tab = -Tab;
				}

				return new Series.PQT { P = Pab, Q = Qab, T = Tab };
			};
			Func<Series.PQT, Series.PQT, Series.PQT> recursivelyCombine = (am, mb) => new Series.PQT
			{
				P = am.P * mb.P,
				Q = am.Q * mb.Q,
				T = mb.Q * am.T + am.P * mb.T
			};

			//how many terms to compute
			var DIGITS_PER_TERM = Math.Log10(C3_OVER_24 / 6 / 2 / 6);
			var N = (digits.ToMpf() / DIGITS_PER_TERM).ToMpz() + 10;

			// Calclate P(0,N), Q(0,N) and T(0,N)
			var PQT = Series.SumOfMachinLikeFormulaWithBinarySplitting(0, N, directlyCompute, recursivelyCombine);
			var one_squared = mpz.Ten.Power(2 * digits);
			var sqrtC = (10005 * one_squared).Sqrt();

			return (PQT.Q * 426880 * sqrtC) / PQT.T;
		}

		public static mpq PiQ(mpz digits)
		{
			return new mpq(PiZ(digits), mpz.Ten.Power(digits));
		}

		public static mpf PiF(mpz digits)
		{
			return PiQ(digits).ToMpf();
		}
	}
}

// ReSharper restore InconsistentNaming
