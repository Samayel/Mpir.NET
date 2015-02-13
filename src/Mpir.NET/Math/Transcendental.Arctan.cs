using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	public static partial class Transcendental
	{
		private const int _ARCTAN_OF_INVERSE_SERIES_SUM_DIGITS_SURCHARGE = 10;
		private const int _ARCTAN_OF_INVERSE_NUMBER_OF_TERMS_SURCHARGE = 10;

		public static mpz ArctanOfInverseSeriesSumZ(mpz digits, IList<mpz> args, IList<mpz> factors, mpz commonFactor)
		{
			var pq = ArctanOfInverseSeriesSum(digits + _ARCTAN_OF_INVERSE_SERIES_SUM_DIGITS_SURCHARGE, args, factors, commonFactor);
			var one = mpz.Ten.Power(digits);

			return pq.P * one / pq.Q;
		}

		public static mpq ArctanOfInverseSeriesSumQ(mpz digits, IList<mpz> args, IList<mpz> factors, mpz commonFactor)
		{
			return new mpq(ArctanOfInverseSeriesSumZ(digits, args, factors, commonFactor), mpz.Ten.Power(digits));
		}

		public static mpf ArctanOfInverseSeriesSumF(mpz digits, IList<mpz> args, IList<mpz> factors, mpz commonFactor)
		{
			return ArctanOfInverseSeriesSumQ(digits, args, factors, commonFactor).ToMpf();
		}

		public static Series.PQ ArctanOfInverseSeriesSum(mpz digits, IList<mpz> args, IList<mpz> factors, mpz commonFactor)
		{
			var terms = args.Select(x => ArctanOfInverse(digits, x)).ToArray();
			return Series.LinearCombinationOfPQTerms(terms, factors, commonFactor);
		}

		public static Series.PQ ArctanOfInverse(mpz digits, mpz x)
		{
			if (digits == null)
				throw new ArgumentNullException("digits");
			if (digits <= 0)
				throw new ArgumentOutOfRangeException("digits");
			if (x == null)
				throw new ArgumentNullException("x");
			if (x <= 1)
				throw new ArgumentOutOfRangeException("x");

			// http://numbers.computation.free.fr/Constants/Algorithms/splitting.html
			Func<mpz, mpz, Series.PQT> directlyCompute = (a, b) =>
			{
				var t = 2 * a + 3;
				var q = t * x.Square();
				var p = a.IsEven() ? mpz.NegativeOne : mpz.One;
				return new Series.PQT { P = p, Q = q, T = t };
			};
			Func<Series.PQT, Series.PQT, Series.PQT> recursivelyCombine = (am, mb) => new Series.PQT { P = mb.Q * am.P + am.T * mb.P, Q = am.Q * mb.Q, T = am.T * mb.T };

			// How many terms to compute
			/*
			 *         x^(2k+1) > 10^digits
			 * => (2k+1) log(x) > digits * log(10)
			 * =>        2k + 1 > digits * log(10) / log(x)
			 * =>            2k > digits * log(10) / log(x)
			 * =>             k > [digits * log(10) / log(x)] / 2
			 */
			var n = (digits.ToMpf() * Math.Log(10, (double) x) / 2).ToMpz() + _ARCTAN_OF_INVERSE_NUMBER_OF_TERMS_SURCHARGE;

			// Calclate P(0,N), Q(0,N) and T(0,N)
			var pqt = Series.BinarySplitting(0, n, directlyCompute, recursivelyCombine);

			return new Series.PQ { P = pqt.P + pqt.Q, Q = x * pqt.Q };
		}
	}
}
