using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	public static partial class Constant
	{
		public static mpz Ln2Z(mpz digits)
		{
			return Transcendental.ArctanhOfInverseSeriesSumZ(
				digits,
				new[] { new mpz(26), new mpz(4801), new mpz(8749) },
				new[] { new mpz(18), new mpz(-2), new mpz(8) });
		}

		public static mpq Ln2Q(mpz digits)
		{
			return new mpq(Ln2Z(digits), mpz.Ten.Power(digits));
		}

		public static mpf Ln2F(mpz digits)
		{
			return Ln2Q(digits).ToMpf();
		}
	}
}
