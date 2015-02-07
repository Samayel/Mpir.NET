using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	// Disable warning about missing XML comments.
	#pragma warning disable 1591

	public class mpq : IDisposable, ICloneable, IConvertible, IComparable, IComparable<mpz>, IComparable<mpq>, IComparable<mpf>, IComparable<int>, IComparable<uint>, IComparable<long>, IComparable<ulong>, IComparable<float>, IComparable<double>, IEquatable<mpz>, IEquatable<mpq>, IEquatable<mpf>, IEquatable<int>, IEquatable<uint>, IEquatable<long>, IEquatable<ulong>, IEquatable<float>, IEquatable<double>
	{
		#region Data

		private const uint _DEFAULT_STRING_BASE = 10;

		internal IntPtr Val;
		private bool _disposed;

		#endregion

		#region Creation and destruction

		internal mpq()
		{
			Val = mpir.mpq_init();
		}

		public mpq(mpq op) : this()
		{
			mpir.mpq_set(this, op);
		}

		public mpq(mpz op) : this()
		{
			mpir.mpq_set_z(this, op);
			mpir.mpq_canonicalize(this);
		}

		public mpq(mpf op) : this()
		{
			mpir.mpq_set_f(this, op);
			mpir.mpq_canonicalize(this);
		}

		public mpq(mpz op1, mpz op2) : this()
		{
			mpir.mpq_set_num(this, op1);
			mpir.mpq_set_den(this, op2);
			mpir.mpq_canonicalize(this);
		}

		public mpq(uint op1, uint op2 = 1U) : this()
		{
			mpir.mpq_set_ui(this, op1, op2);
			mpir.mpq_canonicalize(this);
		}

		public mpq(int op1, uint op2 = 1U) : this()
		{
			mpir.mpq_set_si(this, op1, op2);
			mpir.mpq_canonicalize(this);
		}

		public mpq(int op1, int op2) : this()
		{
			if (op2 < 0)
			{
				op1 = -op1;
				op2 = -op2;
			}
			mpir.mpq_set_si(this, op1, (uint) op2);
			mpir.mpq_canonicalize(this);
		}

		public mpq(double op) : this()
		{
			mpir.mpq_set_d(this, op);
			mpir.mpq_canonicalize(this);
		}

		public mpq(string s, uint @base) : this()
		{
			mpir.mpq_set_str(this, s, @base);
			mpir.mpq_canonicalize(this);
		}

		public mpq(string s) : this(s, _DEFAULT_STRING_BASE)
		{
		}

		~mpq()
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
			mpir.mpq_clear(this);
			_disposed = true;
		}

		#endregion

		// All code handling Decimal is commented out, dute to some
		// unexpected behaviour.

		#region Predefined Values

		public static readonly mpq NegativeTen = new mpq(-10, 1);
		public static readonly mpq NegativeThree = new mpq(-3, 1);
		public static readonly mpq NegativeTwo = new mpq(-2, 1);
		public static readonly mpq NegativeOne = new mpq(-1, 1);
		public static readonly mpq Zero = new mpq(0, 1);
		public static readonly mpq One = new mpq(1, 1);
		public static readonly mpq Two = new mpq(2, 1);
		public static readonly mpq Three = new mpq(3, 1);
		public static readonly mpq Ten = new mpq(10, 1);

		#endregion

		#region Numerator & Denominator

		public virtual mpz Numerator
		{
			get
			{
				var numerator = new mpz();
				mpir.mpq_get_num(numerator, this);
				return numerator;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public virtual mpz Denominator
		{
			get
			{
				var denominator = new mpz();
				mpir.mpq_get_den(denominator, this);
				return denominator;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		#endregion

		#region Basic Arithmetic

		public int Sign()
		{
			return mpir.mpq_sgn(this);
		}

		public virtual mpq Negate()
		{
			var q = new mpq();
			mpir.mpq_neg(q, this);
			return q;
		}

		public virtual mpq Add(mpq x)
		{
			var q = new mpq();
			mpir.mpq_add(q, this, x);
			return q;
		}

		public virtual mpq Subtract(mpq x)
		{
			var q = new mpq();
			mpir.mpq_sub(q, this, x);
			return q;
		}

		public virtual mpq Multiply(mpq x)
		{
			var q = new mpq();
			mpir.mpq_mul(q, this, x);
			return q;
		}

		public virtual mpq MultiplyBy2Exp(uint x)
		{
			var q = new mpq();
			mpir.mpq_mul_2exp(q, this, x);
			return q;
		}

		public mpq MultiplyBy2Exp(int x)
		{
			return (x >= 0)
				? MultiplyBy2Exp((uint) x)
				: DivideBy2Exp((uint) -x);
		}

		public mpq Square()
		{
			return Multiply(this);
		}

		public virtual mpq Divide(mpq x)
		{
			var q = new mpq();
			mpir.mpq_div(q, this, x);
			return q;
		}

		public virtual mpq DivideBy2Exp(uint x)
		{
			var q = new mpq();
			mpir.mpq_div_2exp(q, this, x);
			return q;
		}

		public mpq DivideBy2Exp(int x)
		{
			return (x >= 0)
				? DivideBy2Exp((uint) x)
				: MultiplyBy2Exp((uint) -x);
		}

		public virtual mpq Inverse()
		{
			var q = new mpq();
			mpir.mpq_inv(q, this);
			return q;
		}

		public virtual mpq Abs()
		{
			var q = new mpq();
			mpir.mpq_abs(q, this);
			return q;
		}

		public virtual mpq Power(uint exponent)
		{
			return new mpq(Numerator.Power(exponent), Denominator.Power(exponent));
		}

		public mpq Power(int exponent)
		{
			return (exponent >= 0)
				? Power((uint) exponent)
				: Power((uint) -exponent).Inverse();
		}

		public static mpq Power(uint x, uint exponent)
		{
			return mpz.Power(x, exponent);
		}

		public static mpq Power(int x, int exponent)
		{
			return (exponent >= 0)
				? mpz.Power(x, exponent)
				: mpz.Power(x, -exponent).ToMpq().Inverse();
		}

		#endregion

		#region Roots

		public virtual mpq Sqrt()
		{
			return new mpq(Numerator.Sqrt(), Denominator.Sqrt());
		}

		public virtual mpq Sqrt(out bool isExact)
		{
			bool isNumExact;
			bool isDenExact;

			var ans = new mpq(Numerator.Sqrt(out isNumExact), Denominator.Sqrt(out isDenExact));
			isExact = isNumExact && isDenExact;

			return ans;
		}

		public virtual mpq Root(uint n)
		{
			return new mpq(Numerator.Root(n), Denominator.Root(n));
		}

		public mpq Root(int n)
		{
			return (n >= 0)
				? Root((uint) n)
				: Root((uint) -n).Inverse();
		}

		public virtual mpq Root(uint n, out bool isExact)
		{
			bool isNumExact;
			bool isDenExact;

			var ans = new mpq(Numerator.Root(n, out isNumExact), Denominator.Root(n, out isDenExact));
			isExact = isNumExact && isDenExact;

			return ans;
		}

		public mpq Root(int n, out bool isExact)
		{
			return (n >= 0)
				? Root((uint) n, out isExact)
				: Root((uint) -n, out isExact).Inverse();
		}

		#endregion

		#region Comparing

		public override int GetHashCode()
		{
			var num = Numerator.GetHashCode();
			var den = Denominator.GetHashCode();

			return ((num << 5) + num) ^ den;
		}

		public bool Equals(mpq other)
		{
			return !ReferenceEquals(other, null) && 
				(ReferenceEquals(this, other) || (mpir.mpq_equal(this, other) != 0));
		}

		public bool Equals(mpz other)
		{
			return !ReferenceEquals(other, null) && Equals(other.ToMpq());
		}

		public bool Equals(mpf other)
		{
			return !ReferenceEquals(other, null) && Equals(other.ToMpq());
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
				return CompareTo((short) (sbyte) obj);
			if (obj is string)
				return CompareTo(new mpq(obj as string));

			throw new ArgumentException("Cannot compare to " + obj.GetType());
		}

		public int CompareTo(mpq other)
		{
			return mpir.mpq_cmp(this, other);
		}

		public int CompareTo(mpz other)
		{
			return CompareTo(other.ToMpq());
		}

		public int CompareTo(mpf other)
		{
			return CompareTo(other.ToMpq());
		}

		public int CompareTo(int other)
		{
			return mpir.mpq_cmp_si(this, other, 1U);
		}

		public int CompareTo(uint other)
		{
			return mpir.mpq_cmp_ui(this, other, 1U);
		}

		public int CompareTo(long other)
		{
			return CompareTo((mpq) other);
		}

		public int CompareTo(ulong other)
		{
			return CompareTo((mpq) other);
		}

		public int CompareTo(float other)
		{
			return CompareTo((double) other);
		}

		public int CompareTo(double other)
		{
			return CompareTo((mpq) other);
		}

		int IComparable.CompareTo(object obj)
		{
			return Compare(this, obj);
		}

		public static int Compare(mpq x, object y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(object x, mpq y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpq x, mpq y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(mpq x, int y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(int x, mpq y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpq x, uint y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(uint x, mpq y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpq x, double y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(double x, mpq y)
		{
			return -y.CompareTo(x);
		}

		#endregion

		#region Cloning

		object ICloneable.Clone()
		{
			return Clone();
		}

		public mpq Clone()
		{
			return new mpq(this);
		}

		#endregion

		#region Conversions

		public bool IsInteger()
		{
			return Denominator == 1U;
		}

		public mpz ToMpz()
		{
			return new mpz(this);
		}

		public mpf ToMpf(ulong? precision = null)
		{
			return new mpf(
				this, 
				precision.HasValue ? precision.Value : Math.Max(mpf.DefaultPrecision, Math.Max(Numerator.BitLength, Denominator.BitLength) + 32)
			);
		}

		public mpf ToMpf(long precision)
		{
			if (precision < 0)
				throw new ArgumentOutOfRangeException("precision");

			return ToMpf((ulong) precision);
		}

		public override string ToString()
		{
			return ToString(_DEFAULT_STRING_BASE);
		}

		public string ToString(uint @base)
		{
			return mpir.mpq_get_string(@base, this);
		}

		public string ToDecimalString(int maxDecimalPlaces)
		{
			if (maxDecimalPlaces < 0)
				throw new ArgumentOutOfRangeException("maxDecimalPlaces");

			bool isNegative = Numerator < 0;
			var numerator = isNegative ? Numerator.AsImmutable().Negate() : Numerator.AsImmutable();
			var denominator = Denominator.AsImmutable();

			mpz tail;
			var integerPart = numerator.TDivQR(denominator, out tail);
			var fractionalPart = mpz.Ten.AsMutable().Power(maxDecimalPlaces).Multiply(tail).TDivQ(denominator);

			return (isNegative ? "-" : String.Empty) + integerPart + "." + fractionalPart.ToString().PadLeft(maxDecimalPlaces, '0').TrimEnd('0');
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

		public static implicit operator mpq(byte value)
		{
			return new mpq(value);
		}

		public static implicit operator mpq(int value)
		{
			return new mpq(value);
		}

		public static implicit operator mpq(uint value)
		{
			return new mpq(value);
		}

		public static implicit operator mpq(short value)
		{
			return new mpq(value);
		}

		public static implicit operator mpq(ushort value)
		{
			return new mpq(value);
		}

		public static implicit operator mpq(long value)
		{
			return new mpq((mpz) value);
		}

		public static implicit operator mpq(ulong value)
		{
			return new mpq((mpz) value);
		}

		public static implicit operator mpq(float value)
		{
			return new mpq(value);
		}

		public static implicit operator mpq(double value)
		{
			return new mpq(value);
		}

		public static implicit operator mpq(mpz value)
		{
			return value.ToMpq();
		}

		public static explicit operator mpq(string value)
		{
			return new mpq(value, _DEFAULT_STRING_BASE);
		}

		public static explicit operator byte(mpq value)
		{
			return (byte) (ulong) value;
		}

		public static explicit operator int(mpq value)
		{
			return (int) (long) value;
		}

		public static explicit operator uint(mpq value)
		{
			return (uint) (ulong) value;
		}

		public static explicit operator short(mpq value)
		{
			return (short) (long) value;
		}

		public static explicit operator ushort(mpq value)
		{
			return (ushort) (ulong) value;
		}

		public static explicit operator long(mpq value)
		{
			return (long) (mpz) value;
		}

		public static explicit operator ulong(mpq value)
		{
			return (ulong) (mpz) value;
		}

		public static explicit operator float(mpq value)
		{
			return (float) (double) value;
		}

		public static explicit operator double(mpq value)
		{
			return mpir.mpq_get_d(value);
		}

		public static explicit operator mpz(mpq value)
		{
			return value.ToMpz();
		}

		public static explicit operator string(mpq value)
		{
			return value.ToString();
		}

		#endregion

		#region Operators

		public static mpq operator -(mpq x)
		{
			return x.AsImmutable().Negate();
		}

		public static mpq operator +(mpq x, mpq y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpq operator -(mpq x, mpq y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpq operator ++(mpq x)
		{
			return x.Add(One);
		}

		public static mpq operator --(mpq x)
		{
			return x.Subtract(One);
		}

		public static mpq operator *(mpq x, mpq y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpq operator /(mpq x, mpq y)
		{
			return x.AsImmutable().Divide(y);
		}

		public static bool operator <(mpq x, mpq y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <(int x, mpq y)
		{
			return y.CompareTo(x) > 0;
		}

		public static bool operator <(mpq x, int y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <(uint x, mpq y)
		{
			return y.CompareTo(x) > 0;
		}

		public static bool operator <(mpq x, uint y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <(double x, mpq y)
		{
			return y.CompareTo(x) > 0;
		}

		public static bool operator <(mpq x, double y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <=(mpq x, mpq y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator <=(int x, mpq y)
		{
			return y.CompareTo(x) >= 0;
		}

		public static bool operator <=(mpq x, int y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator <=(uint x, mpq y)
		{
			return y.CompareTo(x) >= 0;
		}

		public static bool operator <=(mpq x, uint y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator <=(double x, mpq y)
		{
			return y.CompareTo(x) >= 0;
		}

		public static bool operator <=(mpq x, double y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator >(mpq x, mpq y)
		{
			return !(x <= y);
		}

		public static bool operator >(int x, mpq y)
		{
			return !(x <= y);
		}

		public static bool operator >(mpq x, int y)
		{
			return !(x <= y);
		}

		public static bool operator >(uint x, mpq y)
		{
			return !(x <= y);
		}

		public static bool operator >(mpq x, uint y)
		{
			return !(x <= y);
		}

		public static bool operator >(double x, mpq y)
		{
			return !(x <= y);
		}

		public static bool operator >(mpq x, double y)
		{
			return !(x <= y);
		}

		public static bool operator >=(mpq x, mpq y)
		{
			return !(x < y);
		}

		public static bool operator >=(int x, mpq y)
		{
			return !(x < y);
		}

		public static bool operator >=(mpq x, int y)
		{
			return !(x < y);
		}

		public static bool operator >=(uint x, mpq y)
		{
			return !(x < y);
		}

		public static bool operator >=(mpq x, uint y)
		{
			return !(x < y);
		}

		public static bool operator >=(double x, mpq y)
		{
			return !(x < y);
		}

		public static bool operator >=(mpq x, double y)
		{
			return !(x < y);
		}

		public static bool operator ==(mpq x, mpq y)
		{
			var xNull = ReferenceEquals(x, null);
			var yNull = ReferenceEquals(y, null);

			return (xNull || yNull) ? (xNull && yNull) : x.Equals(y);
		}

		public static bool operator ==(int x, mpq y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpq x, int y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator ==(uint x, mpq y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpq x, uint y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator ==(double x, mpq y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpq x, double y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator !=(mpq x, mpq y)
		{
			return !(x == y);
		}

		public static bool operator !=(int x, mpq y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpq x, int y)
		{
			return !(x == y);
		}

		public static bool operator !=(uint x, mpq y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpq x, uint y)
		{
			return !(x == y);
		}

		public static bool operator !=(double x, mpq y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpq x, double y)
		{
			return !(x == y);
		}

		#endregion

		#region Mutable / Immutable

		public virtual bool IsMutable
		{
			get { return false; }
		}

		public virtual mpq AsMutable()
		{
			return new xmpq(this);
		}

		public virtual mpq AsImmutable()
		{
			return this;
		}

		#endregion
	}
}
