using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Mpir.NET
{
	public static partial class Constant
	{
		private const int _PI_NUMBER_OF_TERMS_SURCHARGE = 10;

		/*
		 * Compute int(pi * 10^digits)
		 *
		 * This is done using Chudnovsky's series with binary splitting
		 */
		public static mpz PiZ(mpz digits)
		{
			if (digits == null)
				throw new ArgumentNullException("digits");
			if (digits <= 0)
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
					var a2 = a << 1;
					var a6 = a2 * 3;
					Pab = (a6 - 5) * (a2 - 1) * (a6 - 1);
					Qab = a.Power(3U) * C3_OVER_24;
				}

				// t(a) = p(a) * a(a)
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

			// How many terms to compute
			var digitsPerTerm = Math.Log10(C3_OVER_24 / 6 / 2 / 6);
			var n = (digits.ToMpf() / digitsPerTerm).ToMpz() + _PI_NUMBER_OF_TERMS_SURCHARGE;

			// Calculate P(0, N), Q(0, N) and T(0, N)
			var pqt = Series.BinarySplitting(0, n, directlyCompute, recursivelyCombine);
			var oneSquared = mpz.Ten.Power(digits << 1);
			var sqrtC = (10005 * oneSquared).Sqrt();

			return (pqt.Q * 426880 * sqrtC) / pqt.T;
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
