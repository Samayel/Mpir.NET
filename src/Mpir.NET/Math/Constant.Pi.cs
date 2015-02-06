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
		public static mpz PiZ(int digits)
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
			 * 
			 * returns P(a,b), Q(a,b) and T(a,b)
			 */
			Func<mpz, mpz, PQT> bs = null;
			bs = (a, b) =>
			{
				mpz Pab, Qab, Tab;
				// Directly compute P(a,a+1), Q(a,a+1) and T(a,a+1)
				if (b - a == 1)
				{
					if (a == 0)
					{
						Pab = Qab = mpz.One;
					}
					else
					{
						Pab = (6 * a - 5) * (2 * a - 1) * (6 * a - 1);
						Qab = a.Power(3U) * C3_OVER_24;
					}
					// a(a) * p(a)
					Tab = Pab * (13591409 + 545140134 * a);
					if (a.IsOdd())
					{
						Tab = -Tab;
					}
				}
				// Recursively compute P(a,b), Q(a,b) and T(a,b)
				else
				{
					// m is the midpoint of a and b
					var m = (a + b) / 2;
					// Recursively calculate P(a,m), Q(a,m) and T(a,m)
					var PQTam = bs(a, m);
					// Recursively calculate P(m,b), Q(m,b) and T(m,b)
					var PQTmb = bs(m, b);
					// Now combine
					Pab = PQTam.P * PQTmb.P;
					Qab = PQTam.Q * PQTmb.Q;
					Tab = PQTmb.Q * PQTam.T + PQTam.P * PQTmb.T;
				}
				return new PQT {P = Pab, Q = Qab, T = Tab};
			};

			//how many terms to compute
			var DIGITS_PER_TERM = System.Math.Log10(C3_OVER_24 / 6 / 2 / 6);
			var N = (int) (digits / DIGITS_PER_TERM + 1);

			// Calclate P(0,N) and Q(0,N)
			var PQT = bs(0, N);
			var one_squared = mpz.Ten.Power(2 * ((uint) digits));
			var sqrtC = (10005 * one_squared).Sqrt();

			return (PQT.Q * 426880 * sqrtC) / PQT.T;
		}

		public static mpq PiQ(int digits)
		{
			return new mpq(PiZ(digits), mpz.Power(10, digits));
		}

		public static mpf PiF(int digits)
		{
			return PiQ(digits).ToMpf();
		}
	}
}

// ReSharper restore InconsistentNaming
