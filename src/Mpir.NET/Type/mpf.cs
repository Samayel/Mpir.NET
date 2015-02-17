using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	// Disable warning about missing XML comments.
	#pragma warning disable 1591

	public class mpf : IDisposable, ICloneable, IConvertible, IComparable, IComparable<mpz>, IComparable<mpq>, IComparable<mpf>, IComparable<int>, IComparable<uint>, IComparable<long>, IComparable<ulong>, IComparable<float>, IComparable<double>, IEquatable<mpz>, IEquatable<mpq>, IEquatable<mpf>, IEquatable<int>, IEquatable<uint>, IEquatable<long>, IEquatable<ulong>, IEquatable<float>, IEquatable<double>
	{
		#region Data

		private const ulong _DEFAULT_PRECISION = 128;
		private const uint _DEFAULT_STRING_BASE = 10;

		internal IntPtr Val;
		private bool _disposed;

		#endregion

		#region Creation and destruction

		static mpf()
		{
			DefaultPrecision = _DEFAULT_PRECISION;
		}

		internal mpf(ulong? precision = null)
		{
			Val = precision.HasValue ? mpir.mpf_init2(precision.Value) : mpir.mpf_init();
		}

		public mpf(mpf op, ulong? precision = null) : this(precision)
		{
			mpir.mpf_set(this, op);
		}

		public mpf(mpz op, ulong? precision = null) : this(precision)
		{
			mpir.mpf_set_z(this, op);
		}

		public mpf(mpq op, ulong? precision = null) : this(precision)
		{
			mpir.mpf_set_q(this, op);
		}

		public mpf(int op, ulong? precision = null) : this(precision)
		{
			mpir.mpf_set_si(this, op);
		}

		public mpf(uint op, ulong? precision = null) : this(precision)
		{
			mpir.mpf_set_ui(this, op);
		}

		public mpf(double op, ulong? precision = null) : this(precision)
		{
			mpir.mpf_set_d(this, op);
		}

		public mpf(string s, uint @base, ulong? precision = null) : this(precision)
		{
			mpir.mpf_set_str(this, s, @base);
		}

		public mpf(string s, ulong? precision = null) : this(s, _DEFAULT_STRING_BASE, precision)
		{
		}

		~mpf()
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
			mpir.mpf_clear(this);
			_disposed = true;
		}

		#endregion

		#region Precision

		public static ulong DefaultPrecision
		{
			get { return mpir.mpf_get_default_prec(); }
			set { mpir.mpf_set_default_prec(value); }
		}

		public virtual ulong Precision
		{
			get { return mpir.mpf_get_prec(this); }
			set { throw new InvalidOperationException(); }
		}

		public ulong VirtualPrecision
		{
			set { mpir.mpf_set_prec_raw(this, value); }
		}

		#endregion

		// All code handling Decimal is commented out, dute to some
		// unexpected behaviour.

		#region Predefined Values

		public static readonly mpf NegativeTen = new mpf(-10, _DEFAULT_PRECISION);
		public static readonly mpf NegativeThree = new mpf(-3, _DEFAULT_PRECISION);
		public static readonly mpf NegativeTwo = new mpf(-2, _DEFAULT_PRECISION);
		public static readonly mpf NegativeOne = new mpf(-1, _DEFAULT_PRECISION);
		public static readonly mpf Zero = new mpf(0, _DEFAULT_PRECISION);
		public static readonly mpf One = new mpf(1, _DEFAULT_PRECISION);
		public static readonly mpf Two = new mpf(2, _DEFAULT_PRECISION);
		public static readonly mpf Three = new mpf(3, _DEFAULT_PRECISION);
		public static readonly mpf Ten = new mpf(10, _DEFAULT_PRECISION);

		#endregion

		#region Basic Arithmetic

		public int Sign()
		{
			return mpir.mpf_sgn(this);
		}

		public virtual mpf Negate()
		{
			var f = new mpf(Precision);
			mpir.mpf_neg(f, this);
			return f;
		}

		public virtual mpf Add(mpf x)
		{
			var f = new mpf(Math.Max(Precision, x.Precision));
			mpir.mpf_add(f, this, x);
			return f;
		}

		public virtual mpf Add(uint x)
		{
			var f = new mpf(Precision);
			mpir.mpf_add_ui(f, this, x);
			return f;
		}

		public mpf Add(int x)
		{
			return (x >= 0)
				? Add((uint) x)
				: Subtract((uint) -x);
		}

		public virtual mpf Subtract(mpf x)
		{
			var f = new mpf(Math.Max(Precision, x.Precision));
			mpir.mpf_sub(f, this, x);
			return f;
		}

		public virtual mpf Subtract(uint x)
		{
			var f = new mpf(Precision);
			mpir.mpf_sub_ui(f, this, x);
			return f;
		}

		public mpf Subtract(int x)
		{
			return (x >= 0)
				? Subtract((uint) x)
				: Add((uint) -x);
		}

		public virtual mpf SubtractFrom(uint x)
		{
			var f = new mpf(Precision);
			mpir.mpf_ui_sub(f, x, this);
			return f;
		}

		public mpf SubtractFrom(int x)
		{
			return (x >= 0)
				? SubtractFrom((uint) x)
				: Add((uint) -x).Negate();
		}

		public virtual mpf Multiply(mpf x)
		{
			var f = new mpf(Math.Max(Precision, x.Precision));
			mpir.mpf_mul(f, this, x);
			return f;
		}

		public virtual mpf Multiply(uint x)
		{
			var f = new mpf(Precision);
			mpir.mpf_mul_ui(f, this, x);
			return f;
		}

		public mpf Multiply(int x)
		{
			return (x >= 0)
				? Multiply((uint) x)
				: Multiply((uint) -x).Negate();
		}

		public mpf Square()
		{
			return Multiply(this);
		}

		public virtual mpf Divide(mpf x)
		{
			var f = new mpf(Math.Max(Precision, x.Precision));
			mpir.mpf_div(f, this, x);
			return f;
		}

		public virtual mpf Divide(uint x)
		{
			var f = new mpf(Precision);
			mpir.mpf_div_ui(f, this, x);
			return f;
		}

		public mpf Divide(int x)
		{
			return (x >= 0)
				? Divide((uint) x)
				: Divide((uint) -x).Negate();
		}

		public virtual mpf DivideFrom(uint x)
		{
			var f = new mpf(Precision);
			mpir.mpf_ui_div(f, x, this);
			return f;
		}

		public mpf DivideFrom(int x)
		{
			return (x >= 0)
				? DivideFrom((uint) x)
				: DivideFrom((uint) -x).Negate();
		}

		public mpf Inverse()
		{
			return DivideFrom(1U);
		}

		public virtual mpf Abs()
		{
			var f = new mpf(Precision);
			mpir.mpf_abs(f, this);
			return f;
		}

		public virtual mpf Power(uint exponent)
		{
			var f = new mpf(Precision);
			mpir.mpf_pow_ui(f, this, exponent);
			return f;
		}

		public mpf Power(int exponent)
		{
			return (exponent >= 0)
				? Power((uint) exponent)
				: Power((uint) -exponent).Inverse();
		}

		public virtual mpf MultiplyBy2Exp(uint x)
		{
			var f = new mpf(Precision);
			mpir.mpf_mul_2exp(f, this, x);
			return f;
		}

		public mpf MultiplyBy2Exp(int x)
		{
			return (x >= 0)
				? MultiplyBy2Exp((uint) x)
				: DivideBy2Exp((uint) -x);
		}

		public virtual mpf DivideBy2Exp(uint x)
		{
			var f = new mpf(Precision);
			mpir.mpf_div_2exp(f, this, x);
			return f;
		}

		public mpf DivideBy2Exp(int x)
		{
			return (x >= 0)
				? DivideBy2Exp((uint) x)
				: MultiplyBy2Exp((uint) -x);
		}

		#endregion

		#region Roots

		public virtual mpf Sqrt()
		{
			var f = new mpf(Precision);
			mpir.mpf_sqrt(f, this);
			return f;
		}

		public static mpf Sqrt(uint x)
		{
			var f = new mpf();
			mpir.mpf_sqrt_ui(f, x);
			return f;
		}

		public static mpf Sqrt(int x)
		{
			if (x < 0)
				throw new ArgumentOutOfRangeException("x");

			return Sqrt((uint) x);
		}

		#endregion

		#region Rounding

		public virtual mpf Ceil()
		{
			var f = new mpf(Precision);
			mpir.mpf_ceil(f, this);
			return f;
		}

		public virtual mpf Floor()
		{
			var f = new mpf(Precision);
			mpir.mpf_floor(f, this);
			return f;
		}

		public virtual mpf Trunc()
		{
			var f = new mpf(Precision);
			mpir.mpf_trunc(f, this);
			return f;
		}

		#endregion

		#region Random Number Functions

		public static mpf GetUniformlyDistributedRandomBits(randstate state, ulong nbits)
		{
			var f = new mpf(Math.Max(DefaultPrecision, nbits));
			mpir.mpf_urandomb(f, state, nbits);
			return f;
		}

		public static mpf GetBiasedRandomBits(randstate state, long maxSize, long exp)
		{
			var f = new mpf();
			mpir.mpf_rrandomb(f, state, maxSize, exp);
			return f;
		}

		#endregion

		#region Comparing

		public override int GetHashCode()
		{
			return ToMpq().GetHashCode();
		}

		public bool Equals(mpf other)
		{
			return !ReferenceEquals(other, null) &&
					(ReferenceEquals(this, other) || (Compare(this, other) == 0));
		}

		public bool Equals(mpf other, ulong bits)
		{
			return !ReferenceEquals(other, null) &&
					(ReferenceEquals(this, other) || (mpir.mpf_eq(this, other, bits) != 0));
		}

		public virtual mpf RelativeDifference(mpf other)
		{
			var f = new mpf(Math.Max(Precision, other.Precision));
			mpir.mpf_reldiff(f, this, other);
			return f;
		}

		public bool Equals(mpz other)
		{
			return !ReferenceEquals(other, null) && Equals(other.ToMpf());
		}

		public bool Equals(mpq other)
		{
			return !ReferenceEquals(other, null) && Equals(other.ToMpf());
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
				return CompareTo(new mpf((string) obj, Precision));

			throw new ArgumentException("Cannot compare to " + obj.GetType());
		}

		public int CompareTo(mpf other)
		{
			return Math.Sign(mpir.mpf_cmp(this, other));
		}

		public int CompareTo(mpz other)
		{
			return CompareTo(other.ToMpf());
		}

		public int CompareTo(mpq other)
		{
			return CompareTo(other.ToMpf());
		}

		public int CompareTo(int other)
		{
			return Math.Sign(mpir.mpf_cmp_si(this, other));
		}

		public int CompareTo(uint other)
		{
			return Math.Sign(mpir.mpf_cmp_ui(this, other));
		}

		public int CompareTo(long other)
		{
			return CompareTo((mpf) other);
		}

		public int CompareTo(ulong other)
		{
			return CompareTo((mpf) other);
		}

		public int CompareTo(float other)
		{
			return CompareTo((double) other);
		}

		public int CompareTo(double other)
		{
			return Math.Sign(mpir.mpf_cmp_d(this, other));
		}

		public static int Compare(mpf x, object y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(object x, mpf y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpf x, mpf y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(mpf x, int y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(int x, mpf y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpf x, uint y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(uint x, mpf y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpf x, double y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(double x, mpf y)
		{
			return -y.CompareTo(x);
		}

		int IComparable.CompareTo(object obj)
		{
			return Compare(this, obj);
		}

		#endregion

		#region Cloning

		object ICloneable.Clone()
		{
			return Clone();
		}

		public mpf Clone()
		{
			return new mpf(this, Precision);
		}

		#endregion

		#region Conversions

		public bool IsInteger()
		{
			return mpir.mpf_integer_p(this) != 0;
		}

		public mpz ToMpz()
		{
			return new mpz(this);
		}

		public mpq ToMpq()
		{
			return new mpq(this);
		}

		public mpfr ToMpfr()
		{
			return new mpfr(this, null, (long) Precision);
		}

		public double ToDouble(out int exponentOfTwo)
		{
			return mpir.mpf_get_d_2exp(out exponentOfTwo, this);
		}

		public override string ToString()
		{
			return ToString(_DEFAULT_STRING_BASE);
		}

		public string ToString(uint @base, uint maxDigits = 0)
		{
			long exp;
			string digits = mpir.mpf_get_string(out exp, @base, maxDigits, this);
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

		public static implicit operator mpf(byte value)
		{
			return new mpf(value, null);
		}

		public static implicit operator mpf(int value)
		{
			return new mpf(value, null);
		}

		public static implicit operator mpf(uint value)
		{
			return new mpf(value, null);
		}

		public static implicit operator mpf(short value)
		{
			return new mpf(value, null);
		}

		public static implicit operator mpf(ushort value)
		{
			return new mpf(value, null);
		}

		public static implicit operator mpf(long value)
		{
			return new mpf((mpz) value, null);
		}

		public static implicit operator mpf(ulong value)
		{
			return new mpf((mpz) value, null);
		}

		public static implicit operator mpf(float value)
		{
			return new mpf(value, null);
		}

		public static implicit operator mpf(double value)
		{
			return new mpf(value, null);
		}

		public static explicit operator mpf(mpz value)
		{
			return value.ToMpf();
		}

		public static explicit operator mpf(mpq value)
		{
			return value.ToMpf();
		}

		public static explicit operator mpf(string value)
		{
			return new mpf(value, _DEFAULT_STRING_BASE, null);
		}

		public static explicit operator byte(mpf value)
		{
			return (byte) (uint) value;
		}

		public static explicit operator int(mpf value)
		{
			return mpir.mpf_get_si(value);
		}

		public static explicit operator uint(mpf value)
		{
			return mpir.mpf_get_ui(value);
		}

		public static explicit operator short(mpf value)
		{
			return (short) (int) value;
		}

		public static explicit operator ushort(mpf value)
		{
			return (ushort) (uint) value;
		}

		public static explicit operator long(mpf value)
		{
			return (long) (mpz) value;
		}

		public static explicit operator ulong(mpf value)
		{
			return (ulong) (mpz) value;
		}

		public static explicit operator float(mpf value)
		{
			return (float) (double) value;
		}

		public static explicit operator double(mpf value)
		{
			return mpir.mpf_get_d(value);
		}

		public static explicit operator mpz(mpf value)
		{
			return value.ToMpz();
		}

		public static explicit operator mpq(mpf value)
		{
			return value.ToMpq();
		}

		public static explicit operator string(mpf value)
		{
			return value.ToString();
		}

		#endregion

		#region Operators

		public static mpf operator -(mpf x)
		{
			return x.AsImmutable().Negate();
		}

		public static mpf operator +(mpf x, mpf y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpf operator +(mpf x, int y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpf operator +(mpf x, uint y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpf operator +(int x, mpf y)
		{
			return y.AsImmutable().Add(x);
		}

		public static mpf operator +(uint x, mpf y)
		{
			return y.AsImmutable().Add(x);
		}

		public static mpf operator -(mpf x, mpf y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpf operator -(mpf x, int y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpf operator -(mpf x, uint y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpf operator -(int x, mpf y)
		{
			return y.AsImmutable().SubtractFrom(x);
		}

		public static mpf operator -(uint x, mpf y)
		{
			return y.AsImmutable().SubtractFrom(x);
		}

		public static mpf operator ++(mpf x)
		{
			return x.Add(1U);
		}

		public static mpf operator --(mpf x)
		{
			return x.Subtract(1U);
		}

		public static mpf operator *(mpf x, mpf y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpf operator *(mpf x, int y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpf operator *(mpf x, uint y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpf operator *(int x, mpf y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpf operator *(uint x, mpf y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpf operator /(mpf x, mpf y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpf operator /(mpf x, int y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpf operator /(mpf x, uint y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static mpf operator /(int x, mpf y)
		{
			return y.AsImmutable().DivideFrom(x);
		}

		public static mpf operator /(uint x, mpf y)
		{
			return y.AsImmutable().DivideFrom(x);
		}

		public static mpf operator <<(mpf x, int shiftAmount)
		{
			return x.AsImmutable().MultiplyBy2Exp(shiftAmount);
		}

		public static mpf operator >>(mpf x, int shiftAmount)
		{
			return x.AsImmutable().DivideBy2Exp(shiftAmount);
		}

		public static bool operator <(mpf x, mpf y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <(int x, mpf y)
		{
			return y.CompareTo(x) > 0;
		}

		public static bool operator <(mpf x, int y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <(uint x, mpf y)
		{
			return y.CompareTo(x) > 0;
		}

		public static bool operator <(mpf x, uint y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <(double x, mpf y)
		{
			return y.CompareTo(x) > 0;
		}

		public static bool operator <(mpf x, double y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <=(mpf x, mpf y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator <=(int x, mpf y)
		{
			return y.CompareTo(x) >= 0;
		}

		public static bool operator <=(mpf x, int y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator <=(uint x, mpf y)
		{
			return y.CompareTo(x) >= 0;
		}

		public static bool operator <=(mpf x, uint y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator <=(double x, mpf y)
		{
			return y.CompareTo(x) >= 0;
		}

		public static bool operator <=(mpf x, double y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator >(mpf x, mpf y)
		{
			return !(x <= y);
		}

		public static bool operator >(int x, mpf y)
		{
			return !(x <= y);
		}

		public static bool operator >(mpf x, int y)
		{
			return !(x <= y);
		}

		public static bool operator >(uint x, mpf y)
		{
			return !(x <= y);
		}

		public static bool operator >(mpf x, uint y)
		{
			return !(x <= y);
		}

		public static bool operator >(double x, mpf y)
		{
			return !(x <= y);
		}

		public static bool operator >(mpf x, double y)
		{
			return !(x <= y);
		}

		public static bool operator >=(mpf x, mpf y)
		{
			return !(x < y);
		}

		public static bool operator >=(int x, mpf y)
		{
			return !(x < y);
		}

		public static bool operator >=(mpf x, int y)
		{
			return !(x < y);
		}

		public static bool operator >=(uint x, mpf y)
		{
			return !(x < y);
		}

		public static bool operator >=(mpf x, uint y)
		{
			return !(x < y);
		}

		public static bool operator >=(double x, mpf y)
		{
			return !(x < y);
		}

		public static bool operator >=(mpf x, double y)
		{
			return !(x < y);
		}

		public static bool operator ==(mpf x, mpf y)
		{
			var xNull = ReferenceEquals(x, null);
			var yNull = ReferenceEquals(y, null);

			return (xNull || yNull) ? (xNull && yNull) : x.Equals(y);
		}

		public static bool operator ==(int x, mpf y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpf x, int y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator ==(uint x, mpf y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpf x, uint y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator ==(double x, mpf y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpf x, double y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator !=(mpf x, mpf y)
		{
			return !(x == y);
		}

		public static bool operator !=(int x, mpf y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpf x, int y)
		{
			return !(x == y);
		}

		public static bool operator !=(uint x, mpf y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpf x, uint y)
		{
			return !(x == y);
		}

		public static bool operator !=(double x, mpf y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpf x, double y)
		{
			return !(x == y);
		}

		#endregion

		#region Mutable / Immutable

		public virtual bool IsMutable
		{
			get { return false; }
		}

		public virtual mpf AsMutable()
		{
			return new xmpf(this);
		}

		public virtual mpf AsImmutable()
		{
			return this;
		}

		#endregion
	}
}
