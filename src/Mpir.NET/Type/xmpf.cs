using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	internal class xmpf : mpf
	{
		#region Creation and destruction

		public xmpf(mpf op) : base(op, op.Precision)
		{
		}

		~xmpf()
		{
			Dispose(false);
		}

		#endregion

		#region Basic Arithmetic

		public override mpf Negate()
		{
			mpir.mpf_neg(this, this);
			return this;
		}

		public override mpf Add(mpf x)
		{
			mpir.mpf_add(this, this, x);
			return this;
		}

		public override mpf Add(uint x)
		{
			mpir.mpf_add_ui(this, this, x);
			return this;
		}

		public override mpf Subtract(mpf x)
		{
			mpir.mpf_sub(this, this, x);
			return this;
		}

		public override mpf Subtract(uint x)
		{
			mpir.mpf_sub_ui(this, this, x);
			return this;
		}

		public override mpf SubtractFrom(uint x)
		{
			mpir.mpf_ui_sub(this, x, this);
			return this;
		}

		public override mpf Multiply(mpf x)
		{
			mpir.mpf_mul(this, this, x);
			return this;
		}

		public override mpf Multiply(uint x)
		{
			mpir.mpf_mul_ui(this, this, x);
			return this;
		}

		public override mpf Divide(mpf x)
		{
			mpir.mpf_div(this, this, x);
			return this;
		}

		public override mpf Divide(uint x)
		{
			mpir.mpf_div_ui(this, this, x);
			return this;
		}

		public override mpf DivideFrom(uint x)
		{
			mpir.mpf_ui_div(this, x, this);
			return this;
		}

		public override mpf Abs()
		{
			mpir.mpf_abs(this, this);
			return this;
		}

		public override mpf Power(uint exponent)
		{
			mpir.mpf_pow_ui(this, this, exponent);
			return this;
		}

		public override mpf MultiplyBy2Exp(uint x)
		{
			mpir.mpf_mul_2exp(this, this, x);
			return this;
		}

		public override mpf DivideBy2Exp(uint x)
		{
			mpir.mpf_div_2exp(this, this, x);
			return this;
		}

		#endregion

		#region Roots

		public override mpf Sqrt()
		{
			mpir.mpf_sqrt(this, this);
			return this;
		}

		#endregion

		#region Rounding

		public override mpf Ceil()
		{
			mpir.mpf_ceil(this, this);
			return this;
		}

		public override mpf Floor()
		{
			mpir.mpf_floor(this, this);
			return this;
		}

		public override mpf Trunc()
		{
			mpir.mpf_trunc(this, this);
			return this;
		}

		#endregion

		#region Comparing

		public override mpf RelativeDifference(mpf other)
		{
			mpir.mpf_reldiff(this, this, other);
			return this;
		}

		#endregion

		#region Mutable / Immutable

		public override bool IsMutable
		{
			get { return true; }
		}

		public override mpf AsMutable()
		{
			return this;
		}

		public override mpf AsImmutable()
		{
			return new mpf(this, Precision);
		}

		#endregion
	}
}
