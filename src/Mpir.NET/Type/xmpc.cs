using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	internal class xmpc : mpc
	{
		#region Creation and destruction

		internal xmpc(mpc op) : base(precisionRe: op.PrecisionRe, precisionIm: op.PrecisionIm)
		{
			mpir.mpc_set(this, op, (int) DefaultRoundingMode);
		}

		~xmpc()
		{
			Dispose(false);
		}

		#endregion

		#region Precision

		public override long Precision
		{
			get { return mpir.mpc_get_prec(this); }
			set { mpir.mpc_set_prec(this, value); }
		}

		#endregion

		#region Projection and Decomposing Functions

		public override mpc Proj(RoundingMode? roundingMode = null)
		{
			mpir.mpc_proj(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		#endregion

		#region Basic Arithmetic

		public override mpc Add(mpc x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_add(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Add(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_add_fr(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Add(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_add_ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Subtract(mpc x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_sub(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Subtract(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_sub_fr(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Subtract(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_sub_ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc SubtractFrom(mpc x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_sub(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc SubtractFrom(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_fr_sub(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc SubtractFrom(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_ui_sub(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc SubtractFrom(uint re, uint im, RoundingMode? roundingMode = null)
		{
			mpir.mpc_ui_ui_sub(this, re, im, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Negate(RoundingMode? roundingMode = null)
		{
			mpir.mpc_neg(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Multiply(mpc x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_mul(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Multiply(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_mul_fr(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Multiply(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_mul_ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Multiply(int x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_mul_si(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc MultiplyI(int sgn, RoundingMode? roundingMode = null)
		{
			mpir.mpc_mul_i(this, this, sgn, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Square(RoundingMode? roundingMode = null)
		{
			mpir.mpc_sqr(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Fma(mpc x, mpc y, RoundingMode? roundingMode = null)
		{
			mpir.mpc_fma(this, this, x, y, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Divide(mpc x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_div(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Divide(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_div_fr(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Divide(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_div_ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc DivideFrom(mpc x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_div(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc DivideFrom(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_fr_div(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc DivideFrom(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_ui_div(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Conj(RoundingMode? roundingMode = null)
		{
			mpir.mpc_conj(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc MultiplyBy2Exp(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_mul_2ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc MultiplyBy2Exp(int x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_mul_2si(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc DivideBy2Exp(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_div_2ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc DivideBy2Exp(int x, RoundingMode? roundingMode = null)
		{
			mpir.mpc_div_2si(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		#endregion

		#region Power Functions and Logarithm

		public override mpc Sqrt(RoundingMode? roundingMode = null)
		{
			mpir.mpc_sqrt(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Power(mpc exponent, RoundingMode? roundingMode = null)
		{
			mpir.mpc_pow(this, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Power(double exponent, RoundingMode? roundingMode = null)
		{
			mpir.mpc_pow_d(this, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Power(int exponent, RoundingMode? roundingMode = null)
		{
			mpir.mpc_pow_si(this, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Power(uint exponent, RoundingMode? roundingMode = null)
		{
			mpir.mpc_pow_ui(this, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Power(mpz exponent, RoundingMode? roundingMode = null)
		{
			mpir.mpc_pow_z(this, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Power(mpfr exponent, RoundingMode? roundingMode = null)
		{
			mpir.mpc_pow_fr(this, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Exp(RoundingMode? roundingMode = null)
		{
			mpir.mpc_exp(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Log(RoundingMode? roundingMode = null)
		{
			mpir.mpc_log(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Log10(RoundingMode? roundingMode = null)
		{
			mpir.mpc_log10(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		#endregion

		#region Trigonometric Functions

		public override mpc Sin(RoundingMode? roundingMode = null)
		{
			mpir.mpc_sin(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Cos(RoundingMode? roundingMode = null)
		{
			mpir.mpc_cos(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Tan(RoundingMode? roundingMode = null)
		{
			mpir.mpc_tan(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Sinh(RoundingMode? roundingMode = null)
		{
			mpir.mpc_sinh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Cosh(RoundingMode? roundingMode = null)
		{
			mpir.mpc_cosh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc Tanh(RoundingMode? roundingMode = null)
		{
			mpir.mpc_tanh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc ArcSin(RoundingMode? roundingMode = null)
		{
			mpir.mpc_asin(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc ArcCos(RoundingMode? roundingMode = null)
		{
			mpir.mpc_acos(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc ArcTan(RoundingMode? roundingMode = null)
		{
			mpir.mpc_atan(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc ArcSinh(RoundingMode? roundingMode = null)
		{
			mpir.mpc_asinh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc ArcCosh(RoundingMode? roundingMode = null)
		{
			mpir.mpc_acosh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpc ArcTanh(RoundingMode? roundingMode = null)
		{
			mpir.mpc_atanh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		#endregion

		#region Cloning

		public override mpc Clone()
		{
			return new xmpc(this);
		}

		#endregion

		#region Mutable / Immutable

		public override bool IsMutable
		{
			get { return true; }
		}

		public override mpc AsMutable()
		{
			return this;
		}

		public override mpc AsImmutable()
		{
			return new mpc(this, precisionRe: PrecisionRe, precisionIm: PrecisionIm, roundingMode: null);
		}

		#endregion
	}
}
