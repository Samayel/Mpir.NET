using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	internal class xmpq : mpq
	{
		#region Creation and destruction

		public xmpq(mpq op) : base(op)
		{
		}

		~xmpq()
		{
			Dispose(false);
		}

		#endregion

		#region Numerator & Denominator

		public override mpz Numerator
		{
			get
			{
				var numerator = new mpz();
				mpir.mpq_get_num(numerator, this);
				return numerator;
			}
			set
			{
				mpir.mpq_set_num(this, value);
				mpir.mpq_canonicalize(this);
			}
		}

		public override mpz Denominator
		{
			get
			{
				var denominator = new mpz();
				mpir.mpq_get_den(denominator, this);
				return denominator;
			}
			set
			{
				mpir.mpq_set_den(this, value);
				mpir.mpq_canonicalize(this);
			}
		}

		#endregion

		#region Basic Arithmetic

		public override mpq Negate()
		{
			mpir.mpq_neg(this, this);
			return this;
		}

		public override mpq Add(mpq x)
		{
			mpir.mpq_add(this, this, x);
			return this;
		}

		public override mpq Subtract(mpq x)
		{
			mpir.mpq_sub(this, this, x);
			return this;
		}

		public override mpq Multiply(mpq x)
		{
			mpir.mpq_mul(this, this, x);
			return this;
		}

		public override mpq MultiplyBy2Exp(uint x)
		{
			mpir.mpq_mul_2exp(this, this, x);
			return this;
		}

		public override mpq Divide(mpq x)
		{
			mpir.mpq_div(this, this, x);
			return this;
		}

		public override mpq DivideBy2Exp(uint x)
		{
			mpir.mpq_div_2exp(this, this, x);
			return this;
		}

		public override mpq Inverse()
		{
			mpir.mpq_inv(this, this);
			return this;
		}

		public override mpq Abs()
		{
			mpir.mpq_abs(this, this);
			return this;
		}

		public override mpq Power(uint exponent)
		{
			mpir.mpq_set_num(this, Numerator.Power(exponent));
			mpir.mpq_set_den(this, Denominator.Power(exponent));
			return this;
		}

		#endregion

		#region Roots

		public override mpq Sqrt()
		{
			mpir.mpq_set_num(this, Numerator.Sqrt());
			mpir.mpq_set_den(this, Denominator.Sqrt());
			mpir.mpq_canonicalize(this);
			return this;
		}

		public override mpq Sqrt(out bool isExact)
		{
			bool isNumExact;
			bool isDenExact;

			mpir.mpq_set_num(this, Numerator.Sqrt(out isNumExact));
			mpir.mpq_set_den(this, Denominator.Sqrt(out isDenExact));
			mpir.mpq_canonicalize(this);

			isExact = isNumExact && isDenExact;

			return this;
		}

		public override mpq Root(uint n)
		{
			mpir.mpq_set_num(this, Numerator.Root(n));
			mpir.mpq_set_den(this, Denominator.Root(n));
			mpir.mpq_canonicalize(this);
			return this;
		}

		public override mpq Root(uint n, out bool isExact)
		{
			bool isNumExact;
			bool isDenExact;

			mpir.mpq_set_num(this, Numerator.Root(n, out isNumExact));
			mpir.mpq_set_den(this, Denominator.Root(n, out isDenExact));
			mpir.mpq_canonicalize(this);

			isExact = isNumExact && isDenExact;

			return this;
		}

		#endregion

		#region Mutable / Immutable

		public override bool IsMutable
		{
			get { return true; }
		}

		public override mpq AsMutable()
		{
			return this;
		}

		public override mpq AsImmutable()
		{
			return new mpq(this);
		}

		#endregion
	}
}
