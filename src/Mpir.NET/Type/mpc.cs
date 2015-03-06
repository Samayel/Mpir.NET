using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	public class mpc : IDisposable, ICloneable, IComparable<mpc>, IEquatable<mpc>
	{
		// ReSharper disable InconsistentNaming
		public enum RoundingMode
		{
			ReToNearest_ImToNearest = mpfr.RoundingMode.ToNearest | (mpfr.RoundingMode.ToNearest << 4),
			ReToNearest_ImTowardZero = mpfr.RoundingMode.ToNearest | (mpfr.RoundingMode.TowardZero << 4),
			ReToNearest_ImTowardPlusInfinity = mpfr.RoundingMode.ToNearest | (mpfr.RoundingMode.TowardPlusInfinity << 4),
			ReToNearest_ImTowardMinusInfinity = mpfr.RoundingMode.ToNearest | (mpfr.RoundingMode.TowardMinusInfinity << 4),

			ReTowardZero_ImToNearest = mpfr.RoundingMode.TowardZero | (mpfr.RoundingMode.ToNearest << 4),
			ReTowardZero_ImTowardZero = mpfr.RoundingMode.TowardZero | (mpfr.RoundingMode.TowardZero << 4),
			ReTowardZero_ImTowardPlusInfinity = mpfr.RoundingMode.TowardZero | (mpfr.RoundingMode.TowardPlusInfinity << 4),
			ReTowardZero_ImTowardMinusInfinity = mpfr.RoundingMode.TowardZero | (mpfr.RoundingMode.TowardMinusInfinity << 4),

			ReTowardPlusInfinity_ImToNearest = mpfr.RoundingMode.TowardPlusInfinity | (mpfr.RoundingMode.ToNearest << 4),
			ReTowardPlusInfinity_ImTowardZero = mpfr.RoundingMode.TowardPlusInfinity | (mpfr.RoundingMode.TowardZero << 4),
			ReTowardPlusInfinity_ImTowardPlusInfinity = mpfr.RoundingMode.TowardPlusInfinity | (mpfr.RoundingMode.TowardPlusInfinity << 4),
			ReTowardPlusInfinity_ImTowardMinusInfinity = mpfr.RoundingMode.TowardPlusInfinity | (mpfr.RoundingMode.TowardMinusInfinity << 4),

			ReTowardMinusInfinity_ImToNearest = mpfr.RoundingMode.TowardMinusInfinity | (mpfr.RoundingMode.ToNearest << 4),
			ReTowardMinusInfinity_ImTowardZero = mpfr.RoundingMode.TowardMinusInfinity | (mpfr.RoundingMode.TowardZero << 4),
			ReTowardMinusInfinity_ImTowardPlusInfinity = mpfr.RoundingMode.TowardMinusInfinity | (mpfr.RoundingMode.TowardPlusInfinity << 4),
			ReTowardMinusInfinity_ImTowardMinusInfinity = mpfr.RoundingMode.TowardMinusInfinity | (mpfr.RoundingMode.TowardMinusInfinity << 4),
		}
		// ReSharper restore InconsistentNaming

		#region Data

		private const long _DEFAULT_PRECISION = 128;
		private const RoundingMode _DEFAULT_ROUNDING_MODE = RoundingMode.ReToNearest_ImToNearest;
		private const int _DEFAULT_STRING_BASE = 10;

		internal IntPtr Val;
		private bool _disposed;

		#endregion

		#region Creation and destruction

		static mpc()
		{
			DefaultRoundingMode = _DEFAULT_ROUNDING_MODE;
			DefaultPrecision = _DEFAULT_PRECISION;

			NaN = new mpc(precision: _DEFAULT_PRECISION);
			mpir.mpc_set_nan(NaN);
		}

		internal mpc(long? precision = null)
		{
			Val = mpir.mpc_init2(precision.GetValueOrDefault(DefaultPrecision));
		}

		internal mpc(long? precisionRe = null, long? precisionIm = null)
		{
			Val = mpir.mpc_init3(precisionRe.GetValueOrDefault(DefaultPrecision), precisionIm.GetValueOrDefault(DefaultPrecision));
		}

		public mpc(mpc op, long? precision = null, RoundingMode? roundingMode = null) : this(precision: precision)
		{
			mpir.mpc_set(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(mpc op, long? precisionRe = null, long? precisionIm = null, RoundingMode? roundingMode = null) : this(precisionRe: precisionRe, precisionIm: precisionIm)
		{
			mpir.mpc_set(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(mpf op, long? precision = null, RoundingMode? roundingMode = null) : this(precision: precision)
		{
			mpir.mpc_set_f(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(mpfr op, long? precision = null, RoundingMode? roundingMode = null) : this(precision: precision)
		{
			mpir.mpc_set_fr(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(mpz op, long? precision = null, RoundingMode? roundingMode = null) : this(precision: precision)
		{
			mpir.mpc_set_z(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(mpq op, long? precision = null, RoundingMode? roundingMode = null) : this(precision: precision)
		{
			mpir.mpc_set_q(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(int op, long? precision = null, RoundingMode? roundingMode = null) : this(precision: precision)
		{
			mpir.mpc_set_si(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(uint op, long? precision = null, RoundingMode? roundingMode = null) : this(precision: precision)
		{
			mpir.mpc_set_ui(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(double op, long? precision = null, RoundingMode? roundingMode = null) : this(precision: precision)
		{
			mpir.mpc_set_d(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(mpf re, mpf im, long? precisionRe = null, long? precisionIm = null, RoundingMode? roundingMode = null) : this(precisionRe: precisionRe, precisionIm: precisionIm)
		{
			mpir.mpc_set_f_f(this, re, im, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(mpfr re, mpfr im, long? precisionRe = null, long? precisionIm = null, RoundingMode? roundingMode = null) : this(precisionRe: precisionRe, precisionIm: precisionIm)
		{
			mpir.mpc_set_fr_fr(this, re, im, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(mpz re, mpz im, long? precisionRe = null, long? precisionIm = null, RoundingMode? roundingMode = null) : this(precisionRe: precisionRe, precisionIm: precisionIm)
		{
			mpir.mpc_set_z_z(this, re, im, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(mpq re, mpq im, long? precisionRe = null, long? precisionIm = null, RoundingMode? roundingMode = null) : this(precisionRe: precisionRe, precisionIm: precisionIm)
		{
			mpir.mpc_set_q_q(this, re, im, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(uint re, uint im, long? precisionRe = null, long? precisionIm = null, RoundingMode? roundingMode = null) : this(precisionRe: precisionRe, precisionIm: precisionIm)
		{
			mpir.mpc_set_ui_ui(this, re, im, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(int re, int im, long? precisionRe = null, long? precisionIm = null, RoundingMode? roundingMode = null) : this(precisionRe: precisionRe, precisionIm: precisionIm)
		{
			mpir.mpc_set_si_si(this, re, im, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(double re, double im, long? precisionRe = null, long? precisionIm = null, RoundingMode? roundingMode = null) : this(precisionRe: precisionRe, precisionIm: precisionIm)
		{
			mpir.mpc_set_d_d(this, re, im, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(string s, int @base, long? precision = null, RoundingMode? roundingMode = null) : this(precision: precision)
		{
			mpir.mpc_set_str(this, s, @base, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpc(string s, long? precision = null, RoundingMode? roundingMode = null) : this(s, _DEFAULT_STRING_BASE, precision: precision, roundingMode: roundingMode)
		{
		}

		~mpc()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			// There are no managed resources, so <disposing> is not used.
			if (_disposed) return;

			// dispose unmanaged resources
			mpir.mpc_clear(this);
			_disposed = true;
		}

		#endregion

		#region DefaultRoundingMode / Precision

		public static RoundingMode DefaultRoundingMode { get; set; }

		public static long DefaultPrecision { get; set; }

		public virtual long Precision
		{
			get { return mpir.mpc_get_prec(this); }
			set { throw new InvalidOperationException(); }
		}

		public long PrecisionRe
		{
			get
			{
				long pr, pi;
				mpir.mpc_get_prec2(out pr, out pi, this);
				return pr;
			}
		}

		public long PrecisionIm
		{
			get
			{
				long pr, pi;
				mpir.mpc_get_prec2(out pr, out pi, this);
				return pi;
			}
		}

		#endregion

		// All code handling Decimal is commented out, dute to some
		// unexpected behaviour.

		#region Predefined Values

		public static readonly mpc NegativeTen = new mpc(-10, precision: _DEFAULT_PRECISION, roundingMode: _DEFAULT_ROUNDING_MODE);
		public static readonly mpc NegativeTwo = new mpc(-2, precision: _DEFAULT_PRECISION, roundingMode: _DEFAULT_ROUNDING_MODE);
		public static readonly mpc NegativeOne = new mpc(-1, precision: _DEFAULT_PRECISION, roundingMode: _DEFAULT_ROUNDING_MODE);
		public static readonly mpc Zero = new mpc(0, precision: _DEFAULT_PRECISION, roundingMode: _DEFAULT_ROUNDING_MODE);
		public static readonly mpc One = new mpc(1, precision: _DEFAULT_PRECISION, roundingMode: _DEFAULT_ROUNDING_MODE);
		public static readonly mpc Two = new mpc(2, precision: _DEFAULT_PRECISION, roundingMode: _DEFAULT_ROUNDING_MODE);
		public static readonly mpc Ten = new mpc(10, precision: _DEFAULT_PRECISION, roundingMode: _DEFAULT_ROUNDING_MODE);

		public static readonly mpc NegativeOneI = new mpc(0, -1, precisionRe: _DEFAULT_PRECISION, precisionIm: _DEFAULT_PRECISION, roundingMode: _DEFAULT_ROUNDING_MODE);
		public static readonly mpc OneI = new mpc(0, 1, precisionRe: _DEFAULT_PRECISION, precisionIm: _DEFAULT_PRECISION, roundingMode: _DEFAULT_ROUNDING_MODE);

		public static readonly mpc NaN;

		#endregion

		#region Projection and Decomposing Functions

		public mpfr Re
		{
			get
			{
				var re = new mpfr(precision: PrecisionRe);
				mpir.mpc_real(re, this, (int) mpfr.RoundingMode.ToNearest);
				return re;
			}
		}

		public mpfr Im
		{
			get
			{
				var im = new mpfr(precision: PrecisionIm);
				mpir.mpc_imag(im, this, (int) mpfr.RoundingMode.ToNearest);
				return im;
			}
		}

		public mpfr Arg(mpfr.RoundingMode? roundingMode = null)
		{
			var fr = new mpfr(precision: Math.Max(PrecisionRe, PrecisionIm));
			mpir.mpc_arg(fr, this, (int) roundingMode.GetValueOrDefault(mpfr.DefaultRoundingMode));
			return fr;
		}

		public virtual mpc Proj(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_proj(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		#endregion

		#region Basic Arithmetic

		public virtual mpc Add(mpc x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.PrecisionRe), precisionIm: Math.Max(PrecisionIm, x.PrecisionIm));
			mpir.mpc_add(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Add(mpfr x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.Precision), precisionIm: PrecisionIm);
			mpir.mpc_add_fr(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Add(uint x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_add_ui(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Subtract(mpc x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.PrecisionRe), precisionIm: Math.Max(PrecisionIm, x.PrecisionIm));
			mpir.mpc_sub(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Subtract(mpfr x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.Precision), precisionIm: PrecisionIm);
			mpir.mpc_sub_fr(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Subtract(uint x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_sub_ui(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc SubtractFrom(mpc x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.PrecisionRe), precisionIm: Math.Max(PrecisionIm, x.PrecisionIm));
			mpir.mpc_sub(c, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc SubtractFrom(mpfr x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.Precision), precisionIm: PrecisionIm);
			mpir.mpc_fr_sub(c, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc SubtractFrom(uint x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_ui_sub(c, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc SubtractFrom(uint re, uint im, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_ui_ui_sub(c, re, im, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Negate(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_neg(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Multiply(mpc x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.PrecisionRe), precisionIm: Math.Max(PrecisionIm, x.PrecisionIm));
			mpir.mpc_mul(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Multiply(mpfr x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.Precision), precisionIm: Math.Max(PrecisionIm, x.Precision));
			mpir.mpc_mul_fr(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Multiply(uint x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_mul_ui(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Multiply(int x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_mul_si(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc MultiplyI(int sgn, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_mul_i(c, this, sgn, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Square(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_sqr(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Fma(mpc x, mpc y, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, Math.Max(x.PrecisionRe, y.PrecisionRe)), precisionIm: Math.Max(PrecisionIm, Math.Max(x.PrecisionIm, y.PrecisionIm)));
			mpir.mpc_fma(c, this, x, y, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Divide(mpc x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.PrecisionRe), precisionIm: Math.Max(PrecisionIm, x.PrecisionIm));
			mpir.mpc_div(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Divide(mpfr x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.Precision), precisionIm: Math.Max(PrecisionIm, x.Precision));
			mpir.mpc_div_fr(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Divide(uint x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_div_ui(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc DivideFrom(mpc x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.PrecisionRe), precisionIm: Math.Max(PrecisionIm, x.PrecisionIm));
			mpir.mpc_div(c, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc DivideFrom(mpfr x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: Math.Max(PrecisionRe, x.Precision), precisionIm: Math.Max(PrecisionIm, x.Precision));
			mpir.mpc_fr_div(c, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc DivideFrom(uint x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_ui_div(c, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public mpc Inverse(RoundingMode? roundingMode = null)
		{
			return DivideFrom(1U, roundingMode);
		}

		public virtual mpc Conj(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_conj(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public mpfr Abs(mpfr.RoundingMode? roundingMode = null)
		{
			var fr = new mpfr(precision: Math.Max(PrecisionRe, PrecisionIm));
			mpir.mpc_abs(fr, this, (int) roundingMode.GetValueOrDefault(mpfr.DefaultRoundingMode));
			return fr;
		}

		public mpfr Norm(mpfr.RoundingMode? roundingMode = null)
		{
			var fr = new mpfr(precision: Math.Max(PrecisionRe, PrecisionIm));
			mpir.mpc_norm(fr, this, (int) roundingMode.GetValueOrDefault(mpfr.DefaultRoundingMode));
			return fr;
		}

		public virtual mpc MultiplyBy2Exp(uint x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_mul_2ui(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc MultiplyBy2Exp(int x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_mul_2si(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc DivideBy2Exp(uint x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_div_2ui(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc DivideBy2Exp(int x, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_div_2si(c, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		#endregion

		#region Power Functions and Logarithm

		public virtual mpc Sqrt(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_sqrt(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Power(mpc exponent, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_pow(c, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Power(double exponent, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_pow_d(c, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Power(int exponent, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_pow_si(c, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Power(uint exponent, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_pow_ui(c, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Power(mpz exponent, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_pow_z(c, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Power(mpfr exponent, RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_pow_fr(c, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Exp(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_exp(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Log(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_log(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Log10(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_log10(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		#endregion

		#region Trigonometric Functions

		public virtual mpc Sin(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_sin(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Cos(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_cos(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public void SinCos(out mpc sin, out mpc cos, RoundingMode? roundingModeSin = null, RoundingMode? roundingModeCos = null)
		{
			sin = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			cos = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_sin_cos(sin, cos, this, (int) roundingModeSin.GetValueOrDefault(DefaultRoundingMode), (int) roundingModeCos.GetValueOrDefault(DefaultRoundingMode));
		}

		public virtual mpc Tan(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_tan(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Sinh(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_sinh(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Cosh(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_cosh(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc Tanh(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_tanh(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc ArcSin(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_asin(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc ArcCos(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_acos(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc ArcTan(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_atan(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc ArcSinh(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_asinh(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc ArcCosh(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_acosh(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		public virtual mpc ArcTanh(RoundingMode? roundingMode = null)
		{
			var c = new mpc(precisionRe: PrecisionRe, precisionIm: PrecisionIm);
			mpir.mpc_atanh(c, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return c;
		}

		#endregion

		#region Miscellaneous Functions

		public static mpc GetUniformlyDistributedRandom(randstate state, long? precision = null)
		{
			var c = new mpc(precision: precision.GetValueOrDefault(DefaultPrecision));
			mpir.mpc_urandom(c, state);
			return c;
		}

		#endregion

		#region Comparing

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as mpc);
		}

		public bool Equals(mpc other)
		{
			return !ReferenceEquals(other, null) &&
					(ReferenceEquals(this, other) || (CompareTo(other) == 0));
		}

		public int CompareTo(mpc other)
		{
			return Math.Sign(mpir.mpc_cmp(this, other));
		}

		public static int Compare(mpfr x, mpfr y)
		{
			return x.CompareTo(y);
		}

		public bool IsNaN()
		{
			return Re.IsNaN() || Im.IsNaN();
		}

		#endregion

		#region Cloning

		object ICloneable.Clone()
		{
			return Clone();
		}

		public virtual mpc Clone()
		{
			return new mpc(this, precisionRe: PrecisionRe, precisionIm: PrecisionIm, roundingMode: null);
		}

		#endregion

		#region Conversions

		public override string ToString()
		{
			return ToString(_DEFAULT_STRING_BASE);
		}

		public string ToString(int @base, uint maxDigits = 0, RoundingMode? roundingMode = null)
		{
			return mpir.mpc_get_str(@base, maxDigits, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		#endregion

		#region Casting

		public static implicit operator mpc(byte value)
		{
			return new mpc(value, precision: null, roundingMode: null);
		}

		public static implicit operator mpc(int value)
		{
			return new mpc(value, precision: null, roundingMode: null);
		}

		public static implicit operator mpc(uint value)
		{
			return new mpc(value, precision: null, roundingMode: null);
		}

		public static implicit operator mpc(short value)
		{
			return new mpc(value, precision: null, roundingMode: null);
		}

		public static implicit operator mpc(ushort value)
		{
			return new mpc(value, precision: null, roundingMode: null);
		}

		public static implicit operator mpc(long value)
		{
			return new mpc((mpz) value, precision: null, roundingMode: null);
		}

		public static implicit operator mpc(ulong value)
		{
			return new mpc((mpz) value, precision: null, roundingMode: null);
		}

		public static implicit operator mpc(float value)
		{
			return new mpc(value, precision: null, roundingMode: null);
		}

		public static implicit operator mpc(double value)
		{
			return new mpc(value, precision: null, roundingMode: null);
		}

		public static explicit operator mpc(mpz value)
		{
			return value.ToMpc();
		}

		public static explicit operator mpc(mpq value)
		{
			return value.ToMpc();
		}

		public static explicit operator mpc(mpf value)
		{
			return value.ToMpc();
		}

		public static explicit operator mpc(mpfr value)
		{
			return value.ToMpc();
		}

		public static explicit operator mpc(string value)
		{
			return new mpc(value, _DEFAULT_STRING_BASE, precision: null, roundingMode: null);
		}

		public static explicit operator string(mpc value)
		{
			return value.ToString();
		}

		#endregion

		#region Operators

		public static mpc operator -(mpc x)
		{
			return x.AsImmutable().Negate();
		}

		public static mpc operator +(mpc x, mpc y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpc operator +(mpc x, uint y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpc operator +(mpc x, mpfr y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpc operator +(uint x, mpc y)
		{
			return y.AsImmutable().Add(x);
		}

		public static mpc operator +(mpfr x, mpc y)
		{
			return y.AsImmutable().Add(x);
		}

		public static mpc operator -(mpc x, mpc y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpc operator -(mpc x, uint y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpc operator -(mpc x, mpfr y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpc operator -(uint x, mpc y)
		{
			return y.AsImmutable().SubtractFrom(x);
		}

		public static mpc operator -(mpfr x, mpc y)
		{
			return y.AsImmutable().SubtractFrom(x);
		}

		public static mpc operator ++(mpc x)
		{
			return x.Add(1U);
		}

		public static mpc operator --(mpc x)
		{
			return x.Subtract(1U);
		}

		public static mpc operator *(mpc x, mpc y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpc operator *(mpc x, int y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpc operator *(mpc x, uint y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpc operator *(mpc x, mpfr y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpc operator *(int x, mpc y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpc operator *(uint x, mpc y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpc operator *(mpfr x, mpc y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpc operator /(mpc x, mpc y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpc operator /(mpc x, uint y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpc operator /(mpc x, mpfr y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpc operator /(uint x, mpc y)
		{
			return y.AsImmutable().DivideFrom(x);
		}

		public static mpc operator /(mpfr x, mpc y)
		{
			return y.AsImmutable().DivideFrom(x);
		}

		public static mpc operator <<(mpc x, int shiftAmount)
		{
			return x.AsImmutable().MultiplyBy2Exp(shiftAmount);
		}

		public static mpc operator >>(mpc x, int shiftAmount)
		{
			return x.AsImmutable().DivideBy2Exp(shiftAmount);
		}

		public static bool operator <(mpc x, mpc y)
		{
			return !x.IsNaN() && !y.IsNaN() && (x.CompareTo(y) < 0);
		}

		public static bool operator <=(mpc x, mpc y)
		{
			return !x.IsNaN() && !y.IsNaN() && (x.CompareTo(y) <= 0);
		}

		public static bool operator >(mpc x, mpc y)
		{
			return !x.IsNaN() && !y.IsNaN() && (x.CompareTo(y) > 0);
		}

		public static bool operator >=(mpc x, mpc y)
		{
			return !x.IsNaN() && !y.IsNaN() && (x.CompareTo(y) >= 0);
		}

		public static bool operator ==(mpc x, mpc y)
		{
			var xNull = ReferenceEquals(x, null);
			var yNull = ReferenceEquals(y, null);

			return (xNull || yNull) ? (xNull && yNull) : x.Equals(y);
		}

		public static bool operator !=(mpc x, mpc y)
		{
			return !(x == y);
		}

		#endregion

		#region Mutable / Immutable

		public virtual bool IsMutable
		{
			get { return false; }
		}

		public virtual mpc AsMutable()
		{
			return new xmpc(this);
		}

		public virtual mpc AsImmutable()
		{
			return this;
		}

		#endregion
	}
}
