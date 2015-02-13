using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	public static partial class Series
	{
		private const int _BINARY_SEARCH_RECURSION_THRESHOLD = 0;

		public static mpz BinarySearch(mpz a, mpz b, mpz reference, Func<mpz, mpz> f, bool isInDescendingOrder = false, int rangeThreshold = _BINARY_SEARCH_RECURSION_THRESHOLD, bool returnMinimumOfRange = false)
		{
			if (a == null)
				throw new ArgumentNullException("a");
			if (b == null)
				throw new ArgumentNullException("b");
			if (reference == null)
				throw new ArgumentNullException("reference");
			if (b < a)
				throw new ArgumentOutOfRangeException("b");
			if (f == null)
				throw new ArgumentNullException("f");
			if (rangeThreshold < 0)
				throw new ArgumentOutOfRangeException("rangeThreshold");

			while ((b - a) > rangeThreshold)
			{
				// m is the midpoint of a and b
				var m = (a + b) >> 1;

				var compare = isInDescendingOrder
					? -f(m).CompareTo(reference)
					: f(m).CompareTo(reference);

				switch (compare)
				{
					case -1:
						a = m + 1;
						break;
					case 0:
						return m;
					case 1:
						b = m - 1;
						break;
				}
			}

			return (returnMinimumOfRange ^ isInDescendingOrder) ? a : b;
		}
	}
}
