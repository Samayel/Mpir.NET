using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Mpir.NET
{
	public static partial class Constant
	{
		private struct PQ
		{
			public mpz P;
			public mpz Q;
		}
	
		private struct PQT
		{
			public mpz P;
			public mpz Q;
			public mpz T;
		}
	}
}

// ReSharper restore InconsistentNaming
