using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	internal class xmpfr : mpfr
	{
		#region Creation and destruction

		internal xmpfr(mpfr op) : base(op.Precision)
		{
			mpir.mpfr_set(this, op, (int) DefaultRoundingMode);
		}

		~xmpfr()
		{
			Dispose(false);
		}

		#endregion

		#region Precision / Exponent

		public override long Precision
		{
			get { return mpir.mpfr_get_prec(this); }
			set { mpir.mpfr_set_prec(this, value); }
		}

		public override long Exponent
		{
			get { return mpir.mpfr_get_exp(this); }
			set { mpir.mpfr_set_exp(this, value); }
		}

		#endregion

		// All code handling Decimal is commented out, dute to some
		// unexpected behaviour.

		#region Basic Arithmetic

		public override mpfr Add(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_add(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Add(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_add_ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Add(int x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_add_si(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Add(double x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_add_d(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Add(mpz x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_add_z(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Add(mpq x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_add_q(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Subtract(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sub(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Subtract(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sub_ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Subtract(int x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sub_si(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Subtract(double x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sub_d(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Subtract(mpz x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sub_z(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Subtract(mpq x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sub_q(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr SubtractFrom(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sub(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr SubtractFrom(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_ui_sub(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr SubtractFrom(int x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_si_sub(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr SubtractFrom(double x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_d_sub(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr SubtractFrom(mpz x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_z_sub(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Multiply(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_mul(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Multiply(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_mul_ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Multiply(int x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_mul_si(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Multiply(double x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_mul_d(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Multiply(mpz x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_mul_z(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Multiply(mpq x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_mul_q(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Square(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sqr(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Divide(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_div(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Divide(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_div_ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Divide(int x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_div_si(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Divide(double x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_div_d(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Divide(mpz x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_div_z(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Divide(mpq x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_div_q(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr DivideFrom(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_div(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr DivideFrom(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_ui_div(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr DivideFrom(int x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_si_div(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr DivideFrom(double x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_d_div(this, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Negate(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_neg(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Abs(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_abs(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Power(mpfr exponent, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_pow(this, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Power(uint exponent, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_pow_ui(this, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Power(int exponent, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_pow_si(this, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Power(mpz exponent, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_pow_z(this, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr PositiveDifference(mpfr x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_dim(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr MultiplyBy2Exp(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_mul_2ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr MultiplyBy2Exp(int x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_mul_2si(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr DivideBy2Exp(uint x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_div_2ui(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr DivideBy2Exp(int x, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_div_2si(this, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		#endregion

		#region Roots

		public override mpfr Sqrt(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sqrt(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr InverseSqrt(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_rec_sqrt(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr CubeRoot(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_cbrt(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Root(uint n, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_root(this, this, n, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		#endregion

		#region Special Functions

		public override mpfr Log(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_log(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Log2(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_log2(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Log10(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_log10(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Exp(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_exp(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Exp2(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_exp2(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Exp10(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_exp10(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Cos(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_cos(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Sin(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sin(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Tan(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_tan(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Sec(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sec(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Csc(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_csc(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Cot(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_cot(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr ArcCos(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_acos(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr ArcSin(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_asin(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr ArcTan(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_atan(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Cosh(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_cosh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Sinh(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sinh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Tanh(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_tanh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Sech(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_sech(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Csch(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_csch(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Coth(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_coth(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr ArcCosh(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_acosh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr ArcSinh(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_asinh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr ArcTanh(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_atanh(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Log1p(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_log1p(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Expm1(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_expm1(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Eint(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_eint(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Li2(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_li2(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Gamma(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_gamma(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr LnGamma(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_lngamma(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr LGamma(out int sign, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_lgamma(this, out sign, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Digamma(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_digamma(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Zeta(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_zeta(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Erf(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_erf(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Erfc(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_erfc(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr J0(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_j0(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr J1(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_j1(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Jn(int n, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_jn(this, n, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Y0(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_y0(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Y1(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_y1(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Yn(int n, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_yn(this, n, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Fma(mpfr x, mpfr y, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_fma(this, this, x, y, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Fms(mpfr x, mpfr y, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_fms(this, this, x, y, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Ai(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_ai(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		#endregion

		#region Integer and Remainder Related Functions

		public override mpfr Rint(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_rint(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Ceil()
		{
			mpir.mpfr_ceil(this, this);
			return this;
		}

		public override mpfr Floor()
		{
			mpir.mpfr_floor(this, this);
			return this;
		}

		public override mpfr Round()
		{
			mpir.mpfr_round(this, this);
			return this;
		}

		public override mpfr Trunc()
		{
			mpir.mpfr_trunc(this, this);
			return this;
		}

		public override mpfr RintCeil(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_rint_ceil(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr RintFloor(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_rint_floor(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr RintRound(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_rint_round(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr RintTrunc(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_rint_trunc(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Frac(RoundingMode? roundingMode = null)
		{
			mpir.mpfr_frac(this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Fmod(mpfr y, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_fmod(this, this, y, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr Remainder(mpfr y, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_remainder(this, this, y, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr RemainderQuotient(mpfr y, out int q, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_remquo(this, out q, this, y, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		#endregion

		#region Rounding Related Functions

		public override mpfr PrecisionRound(long precision, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_prec_round(this, precision, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		#endregion

		#region Miscellaneous Functions

		public override mpfr NextToward(mpfr y)
		{
			mpir.mpfr_nexttoward(this, y);
			return this;
		}

		public override mpfr NextAbove()
		{
			mpir.mpfr_nextabove(this);
			return this;
		}

		public override mpfr NextBelow()
		{
			mpir.mpfr_nextbelow(this);
			return this;
		}

		public override mpfr SetSignBit(int sign, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_setsign(this, this, sign, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		public override mpfr CopySignBit(mpfr sign, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_copysign(this, this, sign, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		#endregion

		#region Conversions

		public override mpfr ToMpfr2Exp(out long exponentOfTwo, RoundingMode? roundingMode = null)
		{
			mpir.mpfr_frexp(out exponentOfTwo, this, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return this;
		}

		#endregion

		#region Mutable / Immutable

		public override bool IsMutable
		{
			get { return true; }
		}

		public override mpfr AsMutable()
		{
			return this;
		}

		public override mpfr AsImmutable()
		{
			return Clone();
		}

		#endregion
	}
}
