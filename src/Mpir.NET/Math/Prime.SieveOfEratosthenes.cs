using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	public static partial class Prime
	{
		public static mpz SieveOfEratosthenes(ulong limit)
		{
			if (limit <= 0)
				throw new ArgumentOutOfRangeException("limit");

			var sieve = mpz.FromZeroBitIndexes(Enumerable.Empty<ulong>(), limit);

			sieve.ClearBit(0);
			sieve.ClearBit(1);

			for (var n = 2UL; ; n++)
			{
				if (!sieve[n]) continue;

				var mStart = n * n;
				if (mStart > limit) break;

				var mStep = (n == 2) ? n : 2 * n;
				for (var m = mStart; m <= limit; m += mStep)
				{
					sieve.ClearBit(m);
				}
			}

			return sieve;
		}

		public static mpz SieveOfEratosthenes(long limit)
		{
			if (limit <= 0)
				throw new ArgumentOutOfRangeException("limit");

			return SieveOfEratosthenes((ulong) limit);
		}

		public static mpz SieveOfEratosthenes(int limit)
		{
			if (limit <= 0)
				throw new ArgumentOutOfRangeException("limit");

			var sieve = new BitArray(limit + 1, true);

			sieve.Set(0, false);
			sieve.Set(1, false);

			var root = (int) Math.Sqrt(limit);

			for (var n = 2; n <= root; n++)
			{
				if (!sieve.Get(n)) continue;

				var mStep = (n == 2) ? n : 2 * n;
				for (var m = n * n; m <= limit; m += mStep)
				{
					sieve.Set(m, false);
				}
			}


			return new mpz(sieve);
		}
	}
}
