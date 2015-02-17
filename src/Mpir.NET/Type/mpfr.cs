using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	// Disable warning about missing XML comments.
	#pragma warning disable 1591

	public class mpfr : IDisposable, ICloneable, IConvertible, IComparable, IComparable<mpz>, IComparable<mpq>, IComparable<mpf>, IComparable<mpfr>, IComparable<int>, IComparable<uint>, IComparable<long>, IComparable<ulong>, IComparable<float>, IComparable<double>, IEquatable<mpz>, IEquatable<mpq>, IEquatable<mpf>, IEquatable<mpfr>, IEquatable<int>, IEquatable<uint>, IEquatable<long>, IEquatable<ulong>, IEquatable<float>, IEquatable<double>
	{
		public enum RoundingMode
		{
			ToNearest = 0,
			TowardZero = 1,
			TowardPlusInfinity = 2,
			TowardMinusInfinity = 3,
			AwayFromZero = 4,
		}

		#region Data

		private const long _DEFAULT_PRECISION = 128;
		private const RoundingMode _DEFAULT_ROUNDING_MODE = RoundingMode.ToNearest;
		private const uint _DEFAULT_STRING_BASE = 10;

		// TODO: ThreadStatic?
		private static RoundingMode _currentDefaultRoundingMode;

		internal IntPtr Val;
		private bool _disposed;

		#endregion

		#region Creation and destruction

		static mpfr()
		{
			DefaultPrecision = _DEFAULT_PRECISION;
			DefaultRoundingMode = _DEFAULT_ROUNDING_MODE;

			NaN = new mpfr(_DEFAULT_PRECISION);
			PlusInfinity = new mpfr(_DEFAULT_PRECISION);
			MinusInfinity = new mpfr(_DEFAULT_PRECISION);
			PlusZero = new mpfr(_DEFAULT_PRECISION);
			MinusZero = new mpfr(_DEFAULT_PRECISION);

			mpir.mpfr_set_nan(NaN);
			mpir.mpfr_set_inf(PlusInfinity, 1);
			mpir.mpfr_set_inf(MinusInfinity, -1);
			mpir.mpfr_set_zero(PlusZero, 1);
			mpir.mpfr_set_zero(MinusZero, -1);
		}

		internal mpfr(long? precision = null)
		{
			Val = precision.HasValue ? mpir.mpfr_init2(precision.Value) : mpir.mpfr_init();
		}

		public mpfr(mpfr op, RoundingMode? roundingMode = null, long? precision = null) : this(precision)
		{
			mpir.mpfr_set(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpfr(mpf op, RoundingMode? roundingMode = null, long? precision = null) : this(precision)
		{
			mpir.mpfr_set_f(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpfr(mpz op, RoundingMode? roundingMode = null, long? precision = null) : this(precision)
		{
			mpir.mpfr_set_z(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpfr(mpq op, RoundingMode? roundingMode = null, long? precision = null) : this(precision)
		{
			mpir.mpfr_set_q(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpfr(int op, RoundingMode? roundingMode = null, long? precision = null) : this(precision)
		{
			mpir.mpfr_set_si(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpfr(uint op, RoundingMode? roundingMode = null, long? precision = null) : this(precision)
		{
			mpir.mpfr_set_ui(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpfr(double op, RoundingMode? roundingMode = null, long? precision = null) : this(precision)
		{
			mpir.mpfr_set_d(this, op, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpfr(mpz op, long e, RoundingMode? roundingMode = null, long? precision = null) : this(precision)
		{
			mpir.mpfr_set_z_2exp(this, op, e, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpfr(int op, long e, RoundingMode? roundingMode = null, long? precision = null) : this(precision)
		{
			mpir.mpfr_set_si_2exp(this, op, e, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpfr(uint op, long e, RoundingMode? roundingMode = null, long? precision = null) : this(precision)
		{
			mpir.mpfr_set_ui_2exp(this, op, e, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpfr(string s, uint @base, RoundingMode? roundingMode = null, long? precision = null) : this(precision)
		{
			mpir.mpfr_set_str(this, s, @base, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public mpfr(string s, RoundingMode? roundingMode = null, long? precision = null) : this(s, _DEFAULT_STRING_BASE, roundingMode, precision)
		{
		}

		~mpfr()
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
			mpir.mpfr_clear(this);
			_disposed = true;
		}

		#endregion

		#region DefaultRoundingMode / Precision

		public static RoundingMode DefaultRoundingMode
		{
			get
			{
				//return (RoundingMode) mpir.mpfr_get_default_rounding_mode();
				return _currentDefaultRoundingMode;
			}
			set
			{
				_currentDefaultRoundingMode = value;
				mpir.mpfr_set_default_rounding_mode((int) value);
			}
		}

		public static long DefaultPrecision
		{
			get { return mpir.mpfr_get_default_prec(); }
			set { mpir.mpfr_set_default_prec(value); }
		}

		public long Precision
		{
			get { return mpir.mpfr_get_prec(this); }
			set { throw new InvalidOperationException(); }
		}

		#endregion

		// All code handling Decimal is commented out, dute to some
		// unexpected behaviour.

		#region Predefined Values

		public static readonly mpfr NegativeTen = new mpfr(-10, _DEFAULT_PRECISION);
		public static readonly mpfr NegativeThree = new mpfr(-3, _DEFAULT_PRECISION);
		public static readonly mpfr NegativeTwo = new mpfr(-2, _DEFAULT_PRECISION);
		public static readonly mpfr NegativeOne = new mpfr(-1, _DEFAULT_PRECISION);
		public static readonly mpfr Zero = new mpfr(0, _DEFAULT_PRECISION);
		public static readonly mpfr One = new mpfr(1, _DEFAULT_PRECISION);
		public static readonly mpfr Two = new mpfr(2, _DEFAULT_PRECISION);
		public static readonly mpfr Three = new mpfr(3, _DEFAULT_PRECISION);
		public static readonly mpfr Ten = new mpfr(10, _DEFAULT_PRECISION);

		public static readonly mpfr NaN;
		public static readonly mpfr PlusInfinity;
		public static readonly mpfr MinusInfinity;
		public static readonly mpfr PlusZero;
		public static readonly mpfr MinusZero;

		#endregion

		#region Basic Arithmetic

		public int Sign()
		{
			return mpir.mpfr_sgn(this);
		}

		public virtual mpfr Add(mpfr x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Math.Max(Precision, x.Precision));
			mpir.mpfr_add(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr Add(uint x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_add_ui(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Add(int x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_add_si(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Add(double x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_add_d(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Add(mpz x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_add_z(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Add(mpq x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_add_q(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr Subtract(mpfr x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Math.Max(Precision, x.Precision));
			mpir.mpfr_sub(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr Subtract(uint x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_sub_ui(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Subtract(int x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_sub_si(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Subtract(double x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_sub_d(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Subtract(mpz x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_sub_z(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Subtract(mpq x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_sub_q(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr SubtractFrom(uint x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_ui_sub(f, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr SubtractFrom(int x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_si_sub(f, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr SubtractFrom(double x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_d_sub(f, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr SubtractFrom(mpz x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_z_sub(f, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr Multiply(mpfr x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Math.Max(Precision, x.Precision));
			mpir.mpfr_mul(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr Multiply(uint x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_mul_ui(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Multiply(int x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_mul_si(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Multiply(double x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_mul_d(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Multiply(mpz x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_mul_z(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Multiply(mpq x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_mul_q(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Square(RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_sqr(f, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr Divide(mpfr x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Math.Max(Precision, x.Precision));
			mpir.mpfr_div(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr Divide(uint x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_div_ui(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Divide(int x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_div_si(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Divide(double x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_div_d(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Divide(mpz x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_div_z(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Divide(mpq x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_div_q(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr DivideFrom(uint x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_ui_div(f, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr DivideFrom(int x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_si_div(f, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr DivideFrom(double x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_d_div(f, x, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Inverse(RoundingMode? roundingMode = null)
		{
			return DivideFrom(1U, roundingMode);
		}

		public virtual mpfr Negate(RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_neg(f, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr Abs(RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_abs(f, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr Power(mpfr exponent, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_pow(f, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr Power(uint exponent, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_pow_ui(f, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Power(int exponent, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_pow_si(f, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr Power(mpz exponent, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_pow_z(f, this, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public static mpfr Power(uint x, uint exponent, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(DefaultPrecision);
			mpir.mpfr_ui_pow_ui(f, x, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public static mpfr Power(uint x, mpfr exponent, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(DefaultPrecision);
			mpir.mpfr_ui_pow(f, x, exponent, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr PositiveDifference(mpfr x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Math.Max(Precision, x.Precision));
			mpir.mpfr_dim(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr MultiplyBy2Exp(uint x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_mul_2ui(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr MultiplyBy2Exp(int x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_mul_2si(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr DivideBy2Exp(uint x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_div_2ui(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr DivideBy2Exp(int x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_div_2si(f, this, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		#endregion

		#region Roots

		public virtual mpfr Sqrt(RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_sqrt(f, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public static mpfr Sqrt(uint x, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(DefaultPrecision);
			mpir.mpfr_sqrt_ui(f, x, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public static mpfr Sqrt(int x, RoundingMode? roundingMode = null)
		{
			if (x < 0)
				throw new ArgumentOutOfRangeException("x");

			return Sqrt((uint) x, roundingMode);
		}

		public virtual mpfr InverseSqrt(RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_rec_sqrt(f, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr CubeRoot(RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_cbrt(f, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public virtual mpfr Root(uint n, RoundingMode? roundingMode = null)
		{
			var f = new mpfr(Precision);
			mpir.mpfr_root(f, this, n, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		#endregion

		#region Comparing

		public override int GetHashCode()
		{
			return ToMpf().GetHashCode();
		}

		public bool Equals(mpfr other)
		{
			return !ReferenceEquals(other, null) &&
				(ReferenceEquals(this, other) || (mpir.mpfr_equal_p(this, other) != 0));
		}

		public bool Equals(mpz other)
		{
			return !ReferenceEquals(other, null) && (CompareTo(other) == 0);
		}

		public bool Equals(mpq other)
		{
			return !ReferenceEquals(other, null) && (CompareTo(other) == 0);
		}

		public bool Equals(mpf other)
		{
			return !ReferenceEquals(other, null) && (CompareTo(other) == 0);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(obj, null))
				return false;

			if (obj is mpz)
				return Equals((mpz) obj);
			if (obj is mpq)
				return Equals((mpq) obj);
			if (obj is mpf)
				return Equals((mpf) obj);
			if (obj is mpfr)
				return Equals((mpfr) obj);

			if (obj is int)
				return this == (int) obj;
			if (obj is uint)
				return this == (uint) obj;
			if (obj is long)
				return this == (long) obj;
			if (obj is ulong)
				return this == (ulong) obj;
			if (obj is double)
				return this == (double) obj;
			if (obj is float)
				return this == (float) obj;
			if (obj is short)
				return this == (short) obj;
			if (obj is ushort)
				return this == (ushort) obj;
			if (obj is byte)
				return this == (byte) obj;
			if (obj is sbyte)
				return this == (sbyte) obj;

			return false;
		}

		public bool Equals(int other)
		{
			return CompareTo(other) == 0;
		}

		public bool Equals(uint other)
		{
			return CompareTo(other) == 0;
		}

		public bool Equals(long other)
		{
			return CompareTo(other) == 0;
		}

		public bool Equals(ulong other)
		{
			return CompareTo(other) == 0;
		}

		public bool Equals(float other)
		{
			return CompareTo(other) == 0;
		}

		public bool Equals(double other)
		{
			return CompareTo(other) == 0;
		}

		public int CompareTo(object obj)
		{
			if (obj is mpz)
				return CompareTo((mpz) obj);
			if (obj is mpq)
				return CompareTo((mpq) obj);
			if (obj is mpf)
				return CompareTo((mpf) obj);
			if (obj is mpfr)
				return CompareTo((mpfr) obj);

			if (obj is int)
				return CompareTo((int) obj);
			if (obj is uint)
				return CompareTo((uint) obj);
			if (obj is long)
				return CompareTo((long) obj);
			if (obj is ulong)
				return CompareTo((ulong) obj);
			if (obj is double)
				return CompareTo((double) obj);
			if (obj is float)
				return CompareTo((float) obj);
			if (obj is short)
				return CompareTo((short) obj);
			if (obj is ushort)
				return CompareTo((ushort) obj);
			if (obj is byte)
				return CompareTo((byte) obj);
			if (obj is sbyte)
				return CompareTo((sbyte) obj);
			if (obj is string)
				return CompareTo(new mpfr((string) obj, null, Precision));

			throw new ArgumentException("Cannot compare to " + obj.GetType());
		}

		public int CompareTo(mpfr other)
		{
			return Math.Sign(mpir.mpfr_cmp(this, other));
		}

		public int CompareTo(mpz other)
		{
			return Math.Sign(mpir.mpfr_cmp_z(this, other));
		}

		public int CompareTo(mpq other)
		{
			return Math.Sign(mpir.mpfr_cmp_q(this, other));
		}

		public int CompareTo(mpf other)
		{
			return Math.Sign(mpir.mpfr_cmp_f(this, other));
		}

		public int CompareTo(int other)
		{
			return Math.Sign(mpir.mpfr_cmp_si(this, other));
		}

		public int CompareTo(uint other)
		{
			return Math.Sign(mpir.mpfr_cmp_ui(this, other));
		}

		public int CompareTo(long other)
		{
			return CompareTo((mpz) other);
		}

		public int CompareTo(ulong other)
		{
			return CompareTo((mpz) other);
		}

		public int CompareTo(float other)
		{
			return CompareTo((double) other);
		}

		public int CompareTo(double other)
		{
			return Math.Sign(mpir.mpfr_cmp_d(this, other));
		}

		public static int Compare(mpfr x, object y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(object x, mpfr y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpfr x, mpfr y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(mpfr x, int y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(int x, mpfr y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpfr x, uint y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(uint x, mpfr y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpfr x, double y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(double x, mpfr y)
		{
			return -y.CompareTo(x);
		}

		int IComparable.CompareTo(object obj)
		{
			return Compare(this, obj);
		}

		public int CompareTo2Exp(uint x, long e)
		{
			return Math.Sign(mpir.mpfr_cmp_ui_2exp(this, x, e));
		}

		public int CompareTo2Exp(int x, long e)
		{
			return Math.Sign(mpir.mpfr_cmp_si_2exp(this, x, e));
		}

		public int CompareAbsTo(mpfr other)
		{
			return Math.Sign(mpir.mpfr_cmpabs(this, other));
		}

		public bool IsNaN()
		{
			return mpir.mpfr_nan_p(this) != 0;
		}

		public bool IsInfinity()
		{
			return mpir.mpfr_inf_p(this) != 0;
		}

		public bool IsNumber()
		{
			return mpir.mpfr_number_p(this) != 0;
		}

		public bool IsZero()
		{
			return mpir.mpfr_zero_p(this) != 0;
		}

		public bool IsRegular()
		{
			return mpir.mpfr_regular_p(this) != 0;
		}

		public bool IsGreaterThan(mpfr other)
		{
			return mpir.mpfr_greater_p(this, other) != 0;
		}

		public bool IsGreaterThanOrEqualTo(mpfr other)
		{
			return mpir.mpfr_greaterequal_p(this, other) != 0;
		}

		public bool IsLessThan(mpfr other)
		{
			return mpir.mpfr_less_p(this, other) != 0;
		}

		public bool IsLessThanOrEqualTo(mpfr other)
		{
			return mpir.mpfr_lessequal_p(this, other) != 0;
		}

		public bool IsLessOrGreaterThan(mpfr other)
		{
			return mpir.mpfr_lessgreater_p(this, other) != 0;
		}

		public bool IsUnordered(mpfr other)
		{
			return mpir.mpfr_unordered_p(this, other) != 0;
		}

		#endregion

		#region Cloning

		object ICloneable.Clone()
		{
			return Clone();
		}

		public mpfr Clone()
		{
			return new mpfr(this, null, Precision);
		}

		#endregion

		#region Conversions

		public bool IsInteger()
		{
			return mpir.mpfr_integer_p(this) != 0;
		}

		public mpz ToMpz(RoundingMode? roundingMode = null)
		{
			var z = new mpz();
			mpir.mpfr_get_z(z, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return z;
		}

		public mpz ToMpz2Exp(out long exponentOfTwo)
		{
			var z = new mpz();
			exponentOfTwo = mpir.mpfr_get_z_2exp(z, this);
			return z;
		}

		public mpq ToMpq(RoundingMode? roundingMode = null)
		{
			return ToMpf(roundingMode).ToMpq();
		}

		public mpf ToMpf(RoundingMode? roundingMode = null)
		{
			var f = new mpf((ulong) Precision);
			mpir.mpfr_get_f(f, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return f;
		}

		public mpfr ToMpfr2Exp(out long exponentOfTwo, RoundingMode? roundingMode = null, long? precision = null)
		{
			var fr = new mpfr(precision.HasValue ? precision.Value : Math.Max(DefaultPrecision, Precision));
			mpir.mpfr_frexp(out exponentOfTwo, fr, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			return fr;
		}

		public int ToInt32(RoundingMode? roundingMode = null)
		{
			return mpir.mpfr_get_si(this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public uint ToUInt32(RoundingMode? roundingMode = null)
		{
			return mpir.mpfr_get_ui(this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public double ToDouble(RoundingMode? roundingMode = null)
		{
			return mpir.mpfr_get_d(this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public double ToDouble(out int exponentOfTwo, RoundingMode? roundingMode = null)
		{
			return mpir.mpfr_get_d_2exp(out exponentOfTwo, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
		}

		public override string ToString()
		{
			return ToString(_DEFAULT_STRING_BASE);
		}

		public string ToString(uint @base, uint maxDigits = 0, RoundingMode? roundingMode = null)
		{
			long exp;
			string digits = mpir.mpfr_get_str(null, out exp, @base, maxDigits, this, (int) roundingMode.GetValueOrDefault(DefaultRoundingMode));
			string sign = String.Empty;

			if (digits.StartsWith("-"))
			{
				sign = "-";
				digits = digits.Substring(1);
			}
			if (digits == String.Empty)
			{
				digits = "0";
			}

			return String.Format("{0}0{1}{2}e{3}", sign, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, digits, exp);
		}

		#region IConvertible Members

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.Object;
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return (byte) this;
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		Decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			throw new InvalidCastException();
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return (double) this;
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return (short) this;
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return (int) this;
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return (long) this;
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return (sbyte) (short) this;
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return (float) this;
		}

		string IConvertible.ToString(IFormatProvider provider)
		{
			return ToString();
		}

		object IConvertible.ToType(System.Type targetType, IFormatProvider provider)
		{
			if (targetType == null)
				throw new ArgumentNullException("targetType");

			if (targetType == typeof (mpq))
				return this;

			IConvertible convertible = this;

			if (targetType == typeof (sbyte))
				return convertible.ToSByte(provider);
			if (targetType == typeof (byte))
				return convertible.ToByte(provider);
			if (targetType == typeof (short))
				return convertible.ToInt16(provider);
			if (targetType == typeof (ushort))
				return convertible.ToUInt16(provider);
			if (targetType == typeof (int))
				return convertible.ToInt32(provider);
			if (targetType == typeof (uint))
				return convertible.ToUInt32(provider);
			if (targetType == typeof (long))
				return convertible.ToInt64(provider);
			if (targetType == typeof (ulong))
				return convertible.ToUInt64(provider);
			if (targetType == typeof (float))
				return convertible.ToSingle(provider);
			if (targetType == typeof (double))
				return convertible.ToDouble(provider);
			if (targetType == typeof (Decimal))
				return convertible.ToDecimal(provider);
			if (targetType == typeof (string))
				return convertible.ToString(provider);
			if (targetType == typeof (object))
				return convertible;

			throw new InvalidCastException();
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return (ushort) this;
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return (uint) this;
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return (ulong) this;
		}

		#endregion

		#endregion

		#region Casting

		public static implicit operator mpfr(byte value)
		{
			return new mpfr(value, null, null);
		}

		public static implicit operator mpfr(int value)
		{
			return new mpfr(value, null, null);
		}

		public static implicit operator mpfr(uint value)
		{
			return new mpfr(value, null, null);
		}

		public static implicit operator mpfr(short value)
		{
			return new mpfr(value, null, null);
		}

		public static implicit operator mpfr(ushort value)
		{
			return new mpfr(value, null, null);
		}

		public static implicit operator mpfr(long value)
		{
			return new mpfr((mpz) value, null, null);
		}

		public static implicit operator mpfr(ulong value)
		{
			return new mpfr((mpz) value, null, null);
		}

		public static implicit operator mpfr(float value)
		{
			return new mpfr(value, null, null);
		}

		public static implicit operator mpfr(double value)
		{
			return new mpfr(value, null, null);
		}

		public static explicit operator mpfr(mpz value)
		{
			return value.ToMpfr();
		}

		public static explicit operator mpfr(mpq value)
		{
			return value.ToMpfr();
		}

		public static explicit operator mpfr(mpf value)
		{
			return value.ToMpfr();
		}

		public static explicit operator mpfr(string value)
		{
			return new mpfr(value, _DEFAULT_STRING_BASE, null, null);
		}

		public static explicit operator byte(mpfr value)
		{
			return (byte) (uint) value;
		}

		public static explicit operator int(mpfr value)
		{
			return value.ToInt32();
		}

		public static explicit operator uint(mpfr value)
		{
			return value.ToUInt32();
		}

		public static explicit operator short(mpfr value)
		{
			return (short) (int) value;
		}

		public static explicit operator ushort(mpfr value)
		{
			return (ushort) (uint) value;
		}

		public static explicit operator long(mpfr value)
		{
			return (long) (mpz) value;
		}

		public static explicit operator ulong(mpfr value)
		{
			return (ulong) (mpz) value;
		}

		public static explicit operator float(mpfr value)
		{
			return (float) (double) value;
		}

		public static explicit operator double(mpfr value)
		{
			return value.ToDouble();
		}

		public static explicit operator mpz(mpfr value)
		{
			return value.ToMpz();
		}

		public static explicit operator mpq(mpfr value)
		{
			return value.ToMpq();
		}

		public static explicit operator mpf(mpfr value)
		{
			return value.ToMpf();
		}

		public static explicit operator string(mpfr value)
		{
			return value.ToString();
		}

		#endregion

		#region Operators

		public static mpfr operator -(mpfr x)
		{
			return x.AsImmutable().Negate();
		}

		public static mpfr operator +(mpfr x, mpfr y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpfr operator +(mpfr x, int y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpfr operator +(mpfr x, uint y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpfr operator +(mpfr x, double y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpfr operator +(mpfr x, mpz y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpfr operator +(mpfr x, mpq y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpfr operator +(int x, mpfr y)
		{
			return y.AsImmutable().Add(x);
		}

		public static mpfr operator +(uint x, mpfr y)
		{
			return y.AsImmutable().Add(x);
		}

		public static mpfr operator +(double x, mpfr y)
		{
			return y.AsImmutable().Add(x);
		}

		public static mpfr operator +(mpz x, mpfr y)
		{
			return y.AsImmutable().Add(x);
		}

		public static mpfr operator +(mpq x, mpfr y)
		{
			return y.AsImmutable().Add(x);
		}

		public static mpfr operator -(mpfr x, mpfr y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpfr operator -(mpfr x, int y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpfr operator -(mpfr x, uint y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpfr operator -(mpfr x, double y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpfr operator -(mpfr x, mpz y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpfr operator -(mpfr x, mpq y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpfr operator -(int x, mpfr y)
		{
			return y.AsImmutable().SubtractFrom(x);
		}

		public static mpfr operator -(uint x, mpfr y)
		{
			return y.AsImmutable().SubtractFrom(x);
		}

		public static mpfr operator -(double x, mpfr y)
		{
			return y.AsImmutable().SubtractFrom(x);
		}

		public static mpfr operator -(mpz x, mpfr y)
		{
			return y.AsImmutable().SubtractFrom(x);
		}

		public static mpfr operator ++(mpfr x)
		{
			return x.Add(1U);
		}

		public static mpfr operator --(mpfr x)
		{
			return x.Subtract(1U);
		}

		public static mpfr operator *(mpfr x, mpfr y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpfr operator *(mpfr x, int y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpfr operator *(mpfr x, uint y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpfr operator *(mpfr x, double y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpfr operator *(mpfr x, mpz y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpfr operator *(mpfr x, mpq y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpfr operator *(int x, mpfr y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpfr operator *(uint x, mpfr y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpfr operator *(double x, mpfr y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpfr operator *(mpz x, mpfr y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpfr operator *(mpq x, mpfr y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpfr operator /(mpfr x, mpfr y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpfr operator /(mpfr x, int y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpfr operator /(mpfr x, uint y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpfr operator /(mpfr x, double y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpfr operator /(mpfr x, mpz y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpfr operator /(mpfr x, mpq y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpfr operator /(int x, mpfr y)
		{
			return y.AsImmutable().DivideFrom(x);
		}

		public static mpfr operator /(uint x, mpfr y)
		{
			return y.AsImmutable().DivideFrom(x);
		}

		public static mpfr operator /(double x, mpfr y)
		{
			return y.AsImmutable().DivideFrom(x);
		}

		public static mpfr operator <<(mpfr x, int shiftAmount)
		{
			return x.AsImmutable().MultiplyBy2Exp(shiftAmount);
		}

		public static mpfr operator >>(mpfr x, int shiftAmount)
		{
			return x.AsImmutable().DivideBy2Exp(shiftAmount);
		}

		public static bool operator <(mpfr x, mpfr y)
		{
			return x.IsLessThan(y);
		}

		public static bool operator <(int x, mpfr y)
		{
			return !y.IsNaN() && (y.CompareTo(x) > 0);
		}

		public static bool operator <(mpfr x, int y)
		{
			return !x.IsNaN() && (x.CompareTo(y) < 0);
		}

		public static bool operator <(uint x, mpfr y)
		{
			return !y.IsNaN() && (y.CompareTo(x) > 0);
		}

		public static bool operator <(mpfr x, uint y)
		{
			return !x.IsNaN() && (x.CompareTo(y) < 0);
		}

		public static bool operator <(double x, mpfr y)
		{
			return !y.IsNaN() && (y.CompareTo(x) > 0);
		}

		public static bool operator <(mpfr x, double y)
		{
			return !x.IsNaN() && (x.CompareTo(y) < 0);
		}

		public static bool operator <=(mpfr x, mpfr y)
		{
			return x.IsLessThanOrEqualTo(y);
		}

		public static bool operator <=(int x, mpfr y)
		{
			return !y.IsNaN() && (y.CompareTo(x) >= 0);
		}

		public static bool operator <=(mpfr x, int y)
		{
			return !x.IsNaN() && (x.CompareTo(y) <= 0);
		}

		public static bool operator <=(uint x, mpfr y)
		{
			return !y.IsNaN() && (y.CompareTo(x) >= 0);
		}

		public static bool operator <=(mpfr x, uint y)
		{
			return !x.IsNaN() && (x.CompareTo(y) <= 0);
		}

		public static bool operator <=(double x, mpfr y)
		{
			return !y.IsNaN() && (y.CompareTo(x) >= 0);
		}

		public static bool operator <=(mpfr x, double y)
		{
			return !x.IsNaN() && (x.CompareTo(y) <= 0);
		}

		public static bool operator >(mpfr x, mpfr y)
		{
			return x.IsGreaterThan(y);
		}

		public static bool operator >(int x, mpfr y)
		{
			return !y.IsNaN() && !(x <= y);
		}

		public static bool operator >(mpfr x, int y)
		{
			return !x.IsNaN() && !(x <= y);
		}

		public static bool operator >(uint x, mpfr y)
		{
			return !y.IsNaN() && !(x <= y);
		}

		public static bool operator >(mpfr x, uint y)
		{
			return !x.IsNaN() && !(x <= y);
		}

		public static bool operator >(double x, mpfr y)
		{
			return !y.IsNaN() && !(x <= y);
		}

		public static bool operator >(mpfr x, double y)
		{
			return !x.IsNaN() && !(x <= y);
		}

		public static bool operator >=(mpfr x, mpfr y)
		{
			return x.IsGreaterThanOrEqualTo(y);
		}

		public static bool operator >=(int x, mpfr y)
		{
			return !y.IsNaN() && !(x < y);
		}

		public static bool operator >=(mpfr x, int y)
		{
			return !x.IsNaN() && !(x < y);
		}

		public static bool operator >=(uint x, mpfr y)
		{
			return !y.IsNaN() && !(x < y);
		}

		public static bool operator >=(mpfr x, uint y)
		{
			return !x.IsNaN() && !(x < y);
		}

		public static bool operator >=(double x, mpfr y)
		{
			return !y.IsNaN() && !(x < y);
		}

		public static bool operator >=(mpfr x, double y)
		{
			return !x.IsNaN() && !(x < y);
		}

		public static bool operator ==(mpfr x, mpfr y)
		{
			var xNull = ReferenceEquals(x, null);
			var yNull = ReferenceEquals(y, null);

			return (xNull || yNull) ? (xNull && yNull) : x.Equals(y);
		}

		public static bool operator ==(int x, mpfr y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpfr x, int y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator ==(uint x, mpfr y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpfr x, uint y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator ==(double x, mpfr y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpfr x, double y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator !=(mpfr x, mpfr y)
		{
			return !(x == y);
		}

		public static bool operator !=(int x, mpfr y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpfr x, int y)
		{
			return !(x == y);
		}

		public static bool operator !=(uint x, mpfr y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpfr x, uint y)
		{
			return !(x == y);
		}

		public static bool operator !=(double x, mpfr y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpfr x, double y)
		{
			return !(x == y);
		}

		#endregion

		#region Mutable / Immutable

		public virtual bool IsMutable
		{
			get { return false; }
		}

		public virtual mpfr AsMutable()
		{
			throw new NotImplementedException();
		}

		public virtual mpfr AsImmutable()
		{
			return this;
		}

		#endregion
	}
}
