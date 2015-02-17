using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Mpir.NET
{
	// Disable warning about missing XML comments.
	#pragma warning disable 1591

	public class mpz : IDisposable, ICloneable, IConvertible, IComparable, IComparable<mpz>, IComparable<mpq>, IComparable<mpf>, IComparable<int>, IComparable<uint>, IComparable<long>, IComparable<ulong>, IComparable<float>, IComparable<double>, IEquatable<mpz>, IEquatable<mpq>, IEquatable<mpf>, IEquatable<int>, IEquatable<uint>, IEquatable<long>, IEquatable<ulong>, IEquatable<float>, IEquatable<double>
	{
		#region Data

		private const uint _DEFAULT_STRING_BASE = 10;

		internal IntPtr Val;
		private bool _disposed;

		#endregion

		#region Creation and destruction

		internal mpz()
		{
			Val = mpir.mpz_init();
		}

		public mpz(mpz op)
		{
			Val = mpir.mpz_init_set(op);
		}

		public mpz(mpq op) : this()
		{
			mpir.mpz_set_q(this, op);
		}

		public mpz(mpf op) : this()
		{
			mpir.mpz_set_f(this, op);
		}

		public mpz(uint op)
		{
			Val = mpir.mpz_init_set_ui(op);
		}

		public mpz(int op)
		{
			Val = mpir.mpz_init_set_si(op);
		}

		public mpz(long op) : this()
		{
			FromByteArray(BitConverter.GetBytes(op), BitConverter.IsLittleEndian ? -1 : 1);
		}

		public mpz(ulong op) : this()
		{
			FromByteArray(BitConverter.GetBytes(op), BitConverter.IsLittleEndian ? -1 : 1);
		}

		public mpz(double op)
		{
			Val = mpir.mpz_init_set_d(op);
		}

		public mpz(string s, uint @base)
		{
			Val = mpir.mpz_init_set_str(s, @base);
		}

		public mpz(string s) : this(s, _DEFAULT_STRING_BASE)
		{
		}

		public mpz(BigInteger op) : this(op.ToByteArray(), -1)
		{
		}

		public mpz(BitArray op) : this(BitArrayToByteArray(op), -1)
		{
		}

		public mpz(byte[] bytes, int order) : this()
		{
			FromByteArray(bytes, order);
		}

		~mpz()
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
			mpir.mpz_clear(this);
			_disposed = true;
		}

		public virtual void Reallocate(uint size)
		{
			throw new NotSupportedException();
		}

		#endregion

		#region Import and export byte array

		/// Import the integer in the byte array bytes.
		/// Endianess is specified by order, which is 1 for big endian or -1 
		/// for little endian.
		private void FromByteArray(byte[] source, int order)
		{
			mpir.Mpir_mpz_import(this, (uint) source.Length, order, sizeof (byte), 0, 0U, source);
		}

		/// Import the integer in the byte array bytes, starting at startOffset
		/// and ending at endOffset.
		/// Endianess is specified by order, which is 1 for big endian or -1 
		/// for little endian.
		private void ImportByOffset(byte[] source, int startOffset, int endOffset, int order)
		{
			mpir.Mpir_mpz_import_by_offset(this, startOffset, endOffset, order, sizeof (byte), 0, 0U, source);
		}

		/// Export to the value to a byte array.
		/// Endianess is specified by order, which is 1 for big endian or -1 
		/// for little endian.
		public byte[] ToByteArray(int order)
		{
			return mpir.Mpir_mpz_export(order, sizeof (byte), 0, 0U, this);
		}

		private static byte[] BitArrayToByteArray(BitArray bits)
		{
			var ret = new byte[(bits.Length - 1) / 8 + 1];
			bits.CopyTo(ret, 0);

			// ignore unvalid bits from last byte
			if (bits.Length > 0)
			{
				ret[ret.Length - 1] &= (byte) ((1 << ((bits.Length - 1) % 8 + 1)) - 1);
			}

			return ret;
		}

		#endregion

		// All code handling Decimal is commented out, dute to some
		// unexpected behaviour.

		#region Predefined Values

		public static readonly mpz NegativeTen = new mpz(-10);
		public static readonly mpz NegativeThree = new mpz(-3);
		public static readonly mpz NegativeTwo = new mpz(-2);
		public static readonly mpz NegativeOne = new mpz(-1);
		public static readonly mpz Zero = new mpz(0);
		public static readonly mpz One = new mpz(1);
		public static readonly mpz Two = new mpz(2);
		public static readonly mpz Three = new mpz(3);
		public static readonly mpz Ten = new mpz(10);

		#endregion

		#region Basic Arithmetic

		public int Sign()
		{
			return mpir.mpz_sgn(this);
		}

		public virtual mpz Negate()
		{
			var z = new mpz();
			mpir.mpz_neg(z, this);
			return z;
		}

		#region add

		public virtual mpz Add(mpz x)
		{
			var z = new mpz();
			mpir.mpz_add(z, this, x);
			return z;
		}

		public mpz Add(int x)
		{
			return (x >= 0)
				? Add((uint) x)
				: Subtract((uint) -x);
		}

		public virtual mpz Add(uint x)
		{
			var z = new mpz();
			mpir.mpz_add_ui(z, this, x);
			return z;
		}

		#endregion

		#region sub

		public virtual mpz Subtract(mpz x)
		{
			var z = new mpz();
			mpir.mpz_sub(z, this, x);
			return z;
		}

		public mpz Subtract(int x)
		{
			return (x >= 0)
				? Subtract((uint) x)
				: Add((uint) -x);
		}

		public virtual mpz Subtract(uint x)
		{
			var z = new mpz();
			mpir.mpz_sub_ui(z, this, x);
			return z;
		}

		public virtual mpz SubtractFrom(mpz x)
		{
			var z = new mpz();
			mpir.mpz_sub(z, x, this);
			return z;
		}

		public mpz SubtractFrom(int x)
		{
			return (x >= 0)
				? SubtractFrom((uint) x)
				: Add((uint) -x).Negate();
		}

		public virtual mpz SubtractFrom(uint x)
		{
			var z = new mpz();
			mpir.mpz_ui_sub(z, x, this);
			return z;
		}

		#endregion

		#region mul

		public virtual mpz Multiply(mpz x)
		{
			var z = new mpz();
			mpir.mpz_mul(z, this, x);
			return z;
		}

		public virtual mpz Multiply(int x)
		{
			var z = new mpz();
			mpir.mpz_mul_si(z, this, x);
			return z;
		}

		public virtual mpz Multiply(uint x)
		{
			var z = new mpz();
			mpir.mpz_mul_ui(z, this, x);
			return z;
		}

		public mpz MultiplyBy2Exp(int x)
		{
			if (x < 0)
				throw new ArgumentOutOfRangeException("x");

			return MultiplyBy2Exp((uint) x);
		}

		public virtual mpz MultiplyBy2Exp(uint x)
		{
			var z = new mpz();
			mpir.mpz_mul_2exp(z, this, x);
			return z;
		}

		public mpz Square()
		{
			return Multiply(this);
		}

		#endregion

		#region cdiv

		public virtual mpz CDivQ(mpz x)
		{
			var z = new mpz();
			mpir.mpz_cdiv_q(z, this, x);
			return z;
		}

		public virtual mpz CDivR(mpz x)
		{
			var z = new mpz();
			mpir.mpz_cdiv_r(z, this, x);
			return z;
		}

		public virtual mpz CDivQR(mpz x, out mpz r)
		{
			var z = new mpz();
			r = new mpz();
			mpir.mpz_cdiv_qr(z, r, this, x);
			return z;
		}

		public virtual mpz CDivQ(uint x)
		{
			var z = new mpz();
			mpir.mpz_cdiv_q_ui(z, this, x);
			return z;
		}

		public virtual mpz CDivR(uint x)
		{
			var z = new mpz();
			mpir.mpz_cdiv_r_ui(z, this, x);
			return z;
		}

		public virtual mpz CDivQR(uint x, out mpz r)
		{
			var z = new mpz();
			r = new mpz();
			mpir.mpz_cdiv_qr_ui(z, r, this, x);
			return z;
		}

		public virtual mpz CDivQ2Exp(uint x)
		{
			var z = new mpz();
			mpir.mpz_cdiv_q_2exp(z, this, x);
			return z;
		}

		public virtual mpz CDivR2Exp(uint x)
		{
			var z = new mpz();
			mpir.mpz_cdiv_r_2exp(z, this, x);
			return z;
		}

		public mpz CDivQ(int x)
		{
			return (x >= 0)
				? CDivQ((uint) x)
				: CDivQ((uint) -x).Negate();
		}

		public mpz CDivR(int x)
		{
			return CDivR(new mpz(x));
		}

		public mpz CDivQR(int x, out mpz r)
		{
			return CDivQR(new mpz(x), out r);
		}

		public mpz CDivQ2Exp(int x)
		{
			return (x >= 0)
				? CDivQ2Exp((uint) x)
				: MultiplyBy2Exp((uint) -x);
		}

		public mpz CDivR2Exp(int x)
		{
			return (x >= 0)
				? CDivR2Exp((uint) x)
				: Zero;
		}

		#endregion

		#region fdiv

		public virtual mpz FDivQ(mpz x)
		{
			var z = new mpz();
			mpir.mpz_fdiv_q(z, this, x);
			return z;
		}

		public virtual mpz FDivR(mpz x)
		{
			var z = new mpz();
			mpir.mpz_fdiv_r(z, this, x);
			return z;
		}

		public virtual mpz FDivQR(mpz x, out mpz r)
		{
			var z = new mpz();
			r = new mpz();
			mpir.mpz_fdiv_qr(z, r, this, x);
			return z;
		}

		public virtual mpz FDivQ(uint x)
		{
			var z = new mpz();
			mpir.mpz_fdiv_q_ui(z, this, x);
			return z;
		}

		public virtual mpz FDivR(uint x)
		{
			var z = new mpz();
			mpir.mpz_fdiv_r_ui(z, this, x);
			return z;
		}

		public virtual mpz FDivQR(uint x, out mpz r)
		{
			var z = new mpz();
			r = new mpz();
			mpir.mpz_fdiv_qr_ui(z, r, this, x);
			return z;
		}

		public virtual mpz FDivQ2Exp(uint x)
		{
			var z = new mpz();
			mpir.mpz_fdiv_q_2exp(z, this, x);
			return z;
		}

		public virtual mpz FDivR2Exp(uint x)
		{
			var z = new mpz();
			mpir.mpz_fdiv_r_2exp(z, this, x);
			return z;
		}

		public mpz FDivQ(int x)
		{
			return (x >= 0)
				? FDivQ((uint) x)
				: FDivQ((uint) -x).Negate();
		}

		public mpz FDivR(int x)
		{
			return FDivR(new mpz(x));
		}

		public mpz FDivQR(int x, out mpz r)
		{
			return FDivQR(new mpz(x), out r);
		}

		public mpz FDivQ2Exp(int x)
		{
			return (x >= 0)
				? FDivQ2Exp((uint) x)
				: MultiplyBy2Exp((uint) -x);
		}

		public mpz FDivR2Exp(int x)
		{
			return (x >= 0)
				? FDivR2Exp((uint) x)
				: Zero;
		}

		#endregion

		#region tdiv

		public virtual mpz TDivQ(mpz x)
		{
			var z = new mpz();
			mpir.mpz_tdiv_q(z, this, x);
			return z;
		}

		public virtual mpz TDivR(mpz x)
		{
			var z = new mpz();
			mpir.mpz_tdiv_r(z, this, x);
			return z;
		}

		public virtual mpz TDivQR(mpz x, out mpz r)
		{
			var z = new mpz();
			r = new mpz();
			mpir.mpz_tdiv_qr(z, r, this, x);
			return z;
		}

		public virtual mpz TDivQ(uint x)
		{
			var z = new mpz();
			mpir.mpz_tdiv_q_ui(z, this, x);
			return z;
		}

		public virtual mpz TDivR(uint x)
		{
			var z = new mpz();
			mpir.mpz_tdiv_r_ui(z, this, x);
			return z;
		}

		public virtual mpz TDivQR(uint x, out mpz r)
		{
			var z = new mpz();
			r = new mpz();
			mpir.mpz_tdiv_qr_ui(z, r, this, x);
			return z;
		}

		public virtual mpz TDivQ2Exp(uint x)
		{
			var z = new mpz();
			mpir.mpz_tdiv_q_2exp(z, this, x);
			return z;
		}

		public virtual mpz TDivR2Exp(uint x)
		{
			var z = new mpz();
			mpir.mpz_tdiv_r_2exp(z, this, x);
			return z;
		}

		public mpz TDivQ(int x)
		{
			return (x >= 0)
				? TDivQ((uint) x)
				: TDivQ((uint) -x).Negate();
		}

		public mpz TDivR(int x)
		{
			return TDivR(new mpz(x));
		}

		public mpz TDivQR(int x, out mpz r)
		{
			return TDivQR(new mpz(x), out r);
		}

		public mpz TDivQ2Exp(int x)
		{
			return (x >= 0)
				? TDivQ2Exp((uint) x)
				: MultiplyBy2Exp((uint) -x);
		}

		public mpz TDivR2Exp(int x)
		{
			return (x >= 0)
				? TDivR2Exp((uint) x)
				: Zero;
		}

		#endregion

		#region mod

		public virtual mpz Mod(mpz x)
		{
			var z = new mpz();
			mpir.mpz_mod(z, this, x);
			return z;
		}

		public virtual mpz Mod(uint x)
		{
			var z = new mpz();
			mpir.mpz_mod_ui(z, this, x);
			return z;
		}

		public mpz Mod(int x)
		{
			if (x < 0)
				throw new ArgumentOutOfRangeException("x");

			return Mod((uint) x);
		}

		public uint ModAsUInt32(uint mod)
		{
			return mpir.mpz_fdiv_ui(this, mod);
		}

		#endregion

		#region divexact

		public virtual mpz DivideExactly(mpz x)
		{
			var z = new mpz();
			mpir.mpz_divexact(z, this, x);
			return z;
		}

		public virtual mpz DivideExactly(uint x)
		{
			var z = new mpz();
			mpir.mpz_divexact_ui(z, this, x);
			return z;
		}

		public mpz DivideExactly(int x)
		{
			return (x >= 0)
				? DivideExactly((uint) x)
				: DivideExactly((uint) -x).Negate();
		}

		#endregion

		#region divisible

		public bool IsDivisibleBy(mpz x)
		{
			return mpir.mpz_divisible_p(this, x) != 0;
		}

		public bool IsDivisibleBy(uint x)
		{
			return mpir.mpz_divisible_ui_p(this, x) != 0;
		}

		public bool IsDivisibleBy(int x)
		{
			return (x >= 0)
				? IsDivisibleBy((uint) x)
				: IsDivisibleBy((uint) -x);
		}

		public bool IsDivisibleBy2Exp(uint x)
		{
			return mpir.mpz_divisible_2exp_p(this, x) != 0;
		}

		public bool IsDivisibleBy2Exp(int x)
		{
			return (x < 0) || IsDivisibleBy2Exp((uint) x);
		}

		#endregion

		#region congruent

		public bool CongruentMod(mpz x, mpz mod)
		{
			return mpir.mpz_congruent_p(this, x, mod) != 0;
		}

		public bool CongruentMod(uint x, uint mod)
		{
			return mpir.mpz_congruent_ui_p(this, x, mod) != 0;
		}

		public bool CongruentMod(int x, int mod)
		{
			if (mod < 0)
				throw new ArgumentOutOfRangeException("mod");

			return (x >= 0)
				? CongruentMod((uint) x, (uint) mod)
				: CongruentMod((uint) ((x % mod) + mod), (uint) mod);
		}

		public bool CongruentMod2Exp(mpz x, uint e)
		{
			return mpir.mpz_congruent_2exp_p(this, x, e) != 0;
		}

		public bool CongruentMod2Exp(mpz x, int e)
		{
			if (e < 0)
				throw new ArgumentOutOfRangeException("e");

			return CongruentMod2Exp(x, (uint) e);
		}

		#endregion

		#region powm

		public virtual mpz PowerMod(mpz exponent, mpz mod)
		{
			var z = new mpz();
			mpir.mpz_powm(z, this, exponent, mod);
			return z;
		}

		public virtual mpz PowerMod(uint exponent, mpz mod)
		{
			var z = new mpz();
			mpir.mpz_powm_ui(z, this, exponent, mod);
			return z;
		}

		public mpz PowerMod(int exponent, mpz mod)
		{
			return PowerMod(new mpz(exponent), mod);
		}

		#endregion

		#region pow

		public mpz Power(mpz exponent)
		{
			if (exponent < 0)
				throw new ArgumentOutOfRangeException("exponent");

			if (exponent <= UInt32.MaxValue)
			{
				return Power((uint) exponent);
			}

			// b^e = b^(q*ui + r) = (b^ui)^q * b^r

			mpz r;
			var q = exponent.AsImmutable().TDivQR(UInt32.MaxValue, out r);

			var isBaseTwo = Equals(Two);

			var b_ui = isBaseTwo
				? MultiplyBy2Exp(UInt32.MaxValue - 1)
				: Power(UInt32.MaxValue);
			var b_ui_q = b_ui.Power(q);

			if (isBaseTwo)
			{
				return b_ui_q.MultiplyBy2Exp((uint) r);
			}

			var b_r = AsImmutable().Power((uint) r);
			return b_ui_q.Multiply(b_r);
		}

		public virtual mpz Power(uint exponent)
		{
			var z = new mpz();
			mpir.mpz_pow_ui(z, this, exponent);
			return z;
		}

		public mpz Power(int exponent)
		{
			if (exponent < 0)
				throw new ArgumentOutOfRangeException("exponent");

			return Power((uint) exponent);
		}

		public static mpz Power(mpz x, mpz exponent)
		{
			return x.AsImmutable().Power(exponent);
		}

		public static mpz Power(uint x, uint exponent)
		{
			var z = new mpz();
			mpir.mpz_ui_pow_ui(z, x, exponent);
			return z;
		}

		public static mpz Power(int x, int exponent)
		{
			if (exponent < 0)
				throw new ArgumentOutOfRangeException("exponent");

			if (x >= 0)
			{
				return Power((uint) x, (uint) exponent);
			}

			return ((exponent % 2) == 0)
				? Power((uint) -x, (uint) exponent)
				: Power((uint) -x, (uint) exponent).Negate();
		}

		#endregion

		#endregion

		#region Roots

		public virtual mpz Root(uint n, out bool isExact)
		{
			var z = new mpz();
			var ans = mpir.mpz_root(z, this, n);
			isExact = ans != 0;
			return z;
		}

		public mpz Root(int n, out bool isExact)
		{
			if (n < 0)
				throw new ArgumentOutOfRangeException("n");

			return Root((uint) n, out isExact);
		}

		public virtual mpz Root(uint n)
		{
			var z = new mpz();
			mpir.mpz_nthroot(z, this, n);
			return z;
		}

		public mpz Root(int n)
		{
			if (n < 0)
				throw new ArgumentOutOfRangeException("n");

			return Root((uint) n);
		}

		public virtual mpz Root(uint n, out mpz r)
		{
			var z = new mpz();
			r = new mpz();
			mpir.mpz_rootrem(z, r, this, n);
			return z;
		}

		public mpz Root(int n, out mpz r)
		{
			if (n < 0)
				throw new ArgumentOutOfRangeException("n");

			return Root((uint) n, out r);
		}

		public virtual mpz Sqrt()
		{
			var z = new mpz();
			mpir.mpz_sqrt(z, this);
			return z;
		}

		public virtual mpz Sqrt(out mpz r)
		{
			var z = new mpz();
			r = new mpz();
			mpir.mpz_sqrtrem(z, r, this);
			return z;
		}

		public mpz Sqrt(out bool isExact)
		{
			return Root(2U, out isExact);
		}

		public bool IsPerfectPower()
		{
			return mpir.mpz_perfect_power_p(this) != 0;
		}

		public bool IsPerfectSquare()
		{
			return mpir.mpz_perfect_square_p(this) != 0;
		}

		#endregion

		#region Number Theoretic Functions

		#region prime

		public bool IsProbablePrime(randstate state, int prob, uint div)
		{
			return mpir.mpz_probable_prime_p(this, state, prob, div) != 0;
		}

		public bool IsLikelyPrime(randstate state, uint div)
		{
			return mpir.mpz_likely_prime_p(this, state, div) != 0;
		}

		[Obsolete("This function is obsolete. It will disappear from future MPIR releases.")]
		public bool IsProbablePrime(uint repetitions)
		{
			return mpir.mpz_probab_prime_p(this, repetitions) != 0;
		}

		[Obsolete("This function is obsolete. It will disappear from future MPIR releases.")]
		public virtual mpz NextPrime()
		{
			var z = new mpz();
			mpir.mpz_nextprime(z, this);
			return z;
		}

		public virtual mpz NextPrimeCandidate(randstate state)
		{
			var z = new mpz();
			mpir.mpz_next_prime_candidate(z, this, state);
			return z;
		}

		#endregion

		#region gcd

		public static mpz Gcd(mpz x, mpz y)
		{
			return x.AsImmutable().Gcd(y);
		}

		public virtual mpz Gcd(mpz x)
		{
			var z = new mpz();
			mpir.mpz_gcd(z, this, x);
			return z;
		}

		public virtual mpz Gcd(uint x)
		{
			var z = new mpz();
			mpir.mpz_gcd_ui(z, this, x);
			return z;
		}

		public mpz Gcd(int x)
		{
			return (x >= 0)
				? Gcd((uint) x)
				: Gcd((uint) -x);
		}

		public static mpz Gcd(mpz x, mpz y, out mpz a, out mpz b)
		{
			var g = new mpz();
			a = new mpz();
			b = new mpz();
			mpir.mpz_gcdext(g, a, b, x, y);
			return g;
		}

		#endregion

		#region lcm

		public static mpz Lcm(mpz x, mpz y)
		{
			return x.AsImmutable().Lcm(y);
		}

		public virtual mpz Lcm(mpz x)
		{
			var z = new mpz();
			mpir.mpz_lcm(z, this, x);
			return z;
		}

		public virtual mpz Lcm(uint x)
		{
			var z = new mpz();
			mpir.mpz_lcm_ui(z, this, x);
			return z;
		}

		public mpz Lcm(int x)
		{
			return (x >= 0)
				? Lcm((uint) x)
				: Lcm((uint) -x);
		}

		#endregion

		#region invert

		public virtual bool TryInvertMod(mpz mod, out mpz result)
		{
			var z = new mpz();

			var ans = mpir.mpz_invert(z, this, mod);
			if (ans == 0)
			{
				result = null;
				return false;
			}

			result = z;
			return true;
		}

		public mpz InvertMod(mpz mod)
		{
			mpz z;

			if (!TryInvertMod(mod, out z))
				throw new ArithmeticException("This modular inverse does not exists.");

			return z;
		}

		public virtual bool InverseModExists(mpz mod)
		{
			mpz result;
			return TryInvertMod(mod, out result);
		}

		public mpz DivideMod(mpz x, mpz mod)
		{
			// (this * x.InvertMod(mod)) % mod;
			return Multiply(x.AsImmutable().InvertMod(mod)).Mod(mod);
		}

		#endregion

		#region jacobi

		public static int JacobiSymbol(mpz x, mpz y)
		{
			return mpir.mpz_jacobi(x, y);
		}

		#endregion

		#region legendre

		public static int LegendreSymbol(mpz x, mpz primeY)
		{
			return mpir.mpz_legendre(x, primeY);
		}

		#endregion

		#region kronecker

		public static int KroneckerSymbol(mpz x, mpz y)
		{
			return mpir.mpz_kronecker(x, y);
		}

		public static int KroneckerSymbol(mpz x, int y)
		{
			return mpir.mpz_kronecker_si(x, y);
		}

		public static int KroneckerSymbol(int x, mpz y)
		{
			return mpir.mpz_si_kronecker(x, y);
		}

		public static int KroneckerSymbol(mpz x, uint y)
		{
			return mpir.mpz_kronecker_ui(x, y);
		}

		public static int KroneckerSymbol(uint x, mpz y)
		{
			return mpir.mpz_ui_kronecker(x, y);
		}

		#endregion

		#region remove

		public virtual mpz RemoveFactor(mpz factor, out ulong count)
		{
			var z = new mpz();
			count = mpir.mpz_remove(z, this, factor);
			return z;
		}

		public mpz RemoveFactor(mpz factor)
		{
			ulong count;
			return RemoveFactor(factor, out count);
		}

		#endregion

		#region factorial

		public static mpz Factorial(uint x)
		{
			var z = new mpz();
			mpir.mpz_fac_ui(z, x);
			return z;
		}

		public static mpz Factorial(int x)
		{
			if (x < 0)
				throw new ArgumentOutOfRangeException("x");

			return Factorial((uint) x);
		}

		public static mpz Factorial2(uint x)
		{
			var z = new mpz();
			mpir.mpz_2fac_ui(z, x);
			return z;
		}

		public static mpz Factorial2(int x)
		{
			if (x < 0)
				throw new ArgumentOutOfRangeException("x");

			return Factorial2((uint) x);
		}

		public static mpz FactorialM(uint x, uint m)
		{
			var z = new mpz();
			mpir.mpz_mfac_uiui(z, x, m);
			return z;
		}

		public static mpz FactorialM(int x, uint m)
		{
			if (x < 0)
				throw new ArgumentOutOfRangeException("x");

			return FactorialM((uint) x, m);
		}

		#endregion

		#region primorial

		public static mpz Primorial(uint x)
		{
			var z = new mpz();
			mpir.mpz_primorial_ui(z, x);
			return z;
		}

		public static mpz Primorial(int x)
		{
			if (x < 0)
				throw new ArgumentOutOfRangeException("x");

			return Primorial((uint) x);
		}

		#endregion

		#region binomial

		public static mpz Binomial(mpz n, uint k)
		{
			var z = new mpz();
			mpir.mpz_bin_ui(z, n, k);
			return z;
		}

		public static mpz Binomial(mpz n, int k)
		{
			if (k < 0)
				throw new ArgumentOutOfRangeException("k");

			return Binomial(n, (uint) k);
		}

		public static mpz Binomial(uint n, uint k)
		{
			var z = new mpz();
			mpir.mpz_bin_uiui(z, n, k);
			return z;
		}

		public static mpz Binomial(int n, int k)
		{
			if (k < 0)
				throw new ArgumentOutOfRangeException("k");

			if (n >= 0)
			{
				return Binomial((uint) n, (uint) k);
			}

			var z = Binomial((uint) (-n + k - 1), (uint) k);
			return (k % 2 == 0)
				? z
				: z.Negate();
		}

		#endregion

		#region fibonacci

		public static mpz Fibonacci(uint n)
		{
			var z = new mpz();
			mpir.mpz_fib_ui(z, n);
			return z;
		}

		public static mpz Fibonacci(int n)
		{
			if (n < 0)
				throw new ArgumentOutOfRangeException("n");

			return Fibonacci((uint) n);
		}

		public static mpz Fibonacci(uint n, out mpz previous)
		{
			var z = new mpz();
			previous = new mpz();
			mpir.mpz_fib2_ui(z, previous, n);
			return z;
		}

		public static mpz Fibonacci(int n, out mpz previous)
		{
			if (n < 0)
				throw new ArgumentOutOfRangeException("n");

			return Fibonacci((uint) n, out previous);
		}

		#endregion

		#region lucas

		public static mpz Lucas(uint n)
		{
			var z = new mpz();
			mpir.mpz_lucnum_ui(z, n);
			return z;
		}

		public static mpz Lucas(int n)
		{
			if (n < 0)
				throw new ArgumentOutOfRangeException("n");

			return Lucas((uint) n);
		}

		public static mpz Lucas(uint n, out mpz previous)
		{
			var z = new mpz();
			previous = new mpz();
			mpir.mpz_lucnum2_ui(z, previous, n);
			return z;
		}

		public static mpz Lucas(int n, out mpz previous)
		{
			if (n < 0)
				throw new ArgumentOutOfRangeException("n");

			return Lucas((uint) n, out previous);
		}

		#endregion

		#endregion

		#region Random Number Functions

		public static mpz GetUniformlyDistributedRandomBits(randstate state, ulong size)
		{
			var z = new mpz();
			mpir.mpz_urandomb(z, state, size);
			return z;
		}

		public static mpz GetUniformlyDistributedRandomNumber(randstate state, mpz limit)
		{
			var z = new mpz();
			mpir.mpz_urandomm(z, state, limit);
			return z;
		}

		public static mpz GetBiasedRandomBits(randstate state, ulong size)
		{
			var z = new mpz();
			mpir.mpz_rrandomb(z, state, size);
			return z;
		}

		#endregion

		#region Bitwise Functions

		public virtual mpz And(mpz x)
		{
			var z = new mpz();
			mpir.mpz_and(z, this, x);
			return z;
		}

		public virtual mpz Or(mpz x)
		{
			var z = new mpz();
			mpir.mpz_ior(z, this, x);
			return z;
		}

		public virtual mpz Xor(mpz x)
		{
			var z = new mpz();
			mpir.mpz_xor(z, this, x);
			return z;
		}

		public virtual mpz Complement()
		{
			var z = new mpz();
			mpir.mpz_com(z, this);
			return z;
		}

		public ulong CountOnes()
		{
			return mpir.mpz_popcount(this);
		}

		public ulong HammingDistance(mpz x)
		{
			return mpir.mpz_hamdist(this, x);
		}

		public ulong IndexOfZeroBit(ulong startingIndex)
		{
			return mpir.mpz_scan0(this, startingIndex);
		}

		public ulong IndexOfZeroBit(long startingIndex)
		{
			if (startingIndex < 0)
				throw new ArgumentOutOfRangeException("startingIndex");

			return IndexOfZeroBit((ulong) startingIndex);
		}

		public ulong IndexOfOneBit(ulong startingIndex)
		{
			return mpir.mpz_scan1(this, startingIndex);
		}

		public ulong IndexOfOneBit(long startingIndex)
		{
			if (startingIndex < 0)
				throw new ArgumentOutOfRangeException("startingIndex");

			return IndexOfOneBit((ulong) startingIndex);
		}

		public virtual mpz SetBit(ulong bitIndex)
		{
			var z = Clone();
			mpir.mpz_setbit(z, bitIndex);
			return z;
		}

		public mpz SetBit(long bitIndex)
		{
			if (bitIndex < 0)
				throw new ArgumentOutOfRangeException("bitIndex");

			return SetBit((ulong) bitIndex);
		}

		public virtual mpz ClearBit(ulong bitIndex)
		{
			var z = Clone();
			mpir.mpz_clrbit(z, bitIndex);
			return z;
		}

		public mpz ClearBit(long bitIndex)
		{
			if (bitIndex < 0)
				throw new ArgumentOutOfRangeException("bitIndex");

			return ClearBit((ulong) bitIndex);
		}

		public virtual mpz ComplementBit(ulong bitIndex)
		{
			var z = Clone();
			mpir.mpz_combit(z, bitIndex);
			return z;
		}

		public mpz ComplementBit(long bitIndex)
		{
			if (bitIndex < 0)
				throw new ArgumentOutOfRangeException("bitIndex");

			return ComplementBit((ulong) bitIndex);
		}

		public int GetBit(ulong bitIndex)
		{
			return mpir.mpz_tstbit(this, bitIndex);
		}

		public int GetBit(long bitIndex)
		{
			if (bitIndex < 0)
				throw new ArgumentOutOfRangeException("bitIndex");

			return GetBit((ulong) bitIndex);
		}

		public mpz SetBit(ulong bitIndex, int value)
		{
			return (value == 0)
				? ClearBit(bitIndex)
				: SetBit(bitIndex);
		}

		public mpz SetBit(long bitIndex, int value)
		{
			if (bitIndex < 0)
				throw new ArgumentOutOfRangeException("bitIndex");

			return SetBit((ulong) bitIndex, value);
		}

		public virtual bool this[ulong bitIndex]
		{
			get
			{
				return GetBit(bitIndex) != 0;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public virtual bool this[long bitIndex]
		{
			get
			{
				return GetBit(bitIndex) != 0;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public mpz ShiftLeft(mpz shiftAmount)
		{
			if (shiftAmount < 0)
				throw new ArgumentOutOfRangeException("shiftAmount");

			return (shiftAmount <= UInt32.MaxValue)
				? MultiplyBy2Exp((uint) shiftAmount)
				: Multiply(Two.Power(shiftAmount));
		}

		public mpz ShiftLeft(uint shiftAmount)
		{
			return MultiplyBy2Exp(shiftAmount);
		}

		public mpz ShiftLeft(int shiftAmount)
		{
			return MultiplyBy2Exp(shiftAmount);
		}

		public mpz ShiftRight(mpz shiftAmount)
		{
			if (shiftAmount < 0)
				throw new ArgumentOutOfRangeException("shiftAmount");

			return (shiftAmount <= UInt32.MaxValue)
				? FDivQ2Exp((uint) shiftAmount)
				: FDivQ(Two.Power(shiftAmount));
		}

		public mpz ShiftRight(uint shiftAmount)
		{
			return FDivQ2Exp(shiftAmount);
		}

		public mpz ShiftRight(int shiftAmount)
		{
			return FDivQ2Exp(shiftAmount);
		}

		public IEnumerable<ulong> ToOneBitIndexes(ulong? maxBitIndex = null)
		{
			var max = maxBitIndex.HasValue ? maxBitIndex.Value : BitLength - 1;

			ulong index = 0;
			while (true)
			{
				index = IndexOfOneBit(index);
				if (index > max) break;

				yield return index;
				index++;
			}
		}

		public IEnumerable<ulong> ToOneBitIndexes(long maxBitIndex)
		{
			if (maxBitIndex < 0)
				throw new ArgumentOutOfRangeException("maxBitIndex");

			return ToOneBitIndexes((ulong) maxBitIndex);
		}

		public IEnumerable<ulong> ToZeroBitIndexes(ulong? maxBitIndex = null)
		{
			var max = maxBitIndex.HasValue ? maxBitIndex.Value : BitLength - 1;

			ulong index = 0;
			while (true)
			{
				index = IndexOfZeroBit(index);
				if (index > max) break;

				yield return index;
				index++;
			}
		}

		public IEnumerable<ulong> ToZeroBitIndexes(long maxBitIndex)
		{
			if (maxBitIndex < 0)
				throw new ArgumentOutOfRangeException("maxBitIndex");

			return ToZeroBitIndexes((ulong) maxBitIndex);
		}

		public static mpz FromOneBitIndexes(IEnumerable<ulong> indexes)
		{
			var z = Zero.AsMutable();

			foreach (var index in indexes)
			{
				z.SetBit(index);
			}

			return z;
		}

		public static mpz FromZeroBitIndexes(IEnumerable<ulong> indexes, ulong maxOneBitIndex)
		{
			var z = Two.AsMutable().Power(maxOneBitIndex + One).Subtract(1U);

			foreach (var index in indexes.Where(i => i <= maxOneBitIndex))
			{
				z.ClearBit(index);
			}

			return z;
		}

		public static mpz FromZeroBitIndexes(IEnumerable<ulong> indexes, long maxOneBitIndex)
		{
			if (maxOneBitIndex < 0)
				throw new ArgumentOutOfRangeException("maxOneBitIndex");

			return FromZeroBitIndexes(indexes, (ulong) maxOneBitIndex);
		}

		#endregion

		#region Miscellaneous Functions

		public bool IsEven()
		{
			return mpir.mpz_even_p(this) != 0;
		}

		public bool IsOdd()
		{
			return mpir.mpz_odd_p(this) != 0;
		}

		public ulong Length(uint @base)
		{
			return mpir.mpz_sizeinbase(this, @base);
		}

		public ulong BitLength
		{
			get { return Length(2U); }
		}

		#endregion

		#region Comparing

		public override int GetHashCode()
		{
			var hash = 0U;

			var bytes = ToByteArray(-1);

			var len = bytes.Length;
			var shift = 0;
			for (var i = 0; i < len; ++i)
			{
				hash ^= (uint) bytes[i] << shift;
				shift = shift + 8 & 31;
			}

			return (int) hash;
		}

		public bool Equals(mpz other)
		{
			return !ReferenceEquals(other, null) &&
				(ReferenceEquals(this, other) || (Compare(this, other) == 0));
		}

		public bool Equals(mpq other)
		{
			return !ReferenceEquals(other, null) && ToMpq().Equals(other);
		}

		public bool Equals(mpf other)
		{
			return !ReferenceEquals(other, null) && ToMpf().Equals(other);
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
				return this == (mpz) (long) obj;
			if (obj is ulong)
				return this == (mpz) (ulong) obj;
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
				return CompareTo(new mpz((string) obj));

			throw new ArgumentException("Cannot compare to " + obj.GetType());
		}

		public int CompareTo(mpz other)
		{
			return Math.Sign(mpir.mpz_cmp(this, other));
		}

		public int CompareTo(mpq other)
		{
			return ToMpq().CompareTo(other);
		}

		public int CompareTo(mpf other)
		{
			return ToMpf().CompareTo(other);
		}

		public int CompareTo(int other)
		{
			return Math.Sign(mpir.mpz_cmp_si(this, other));
		}

		public int CompareTo(uint other)
		{
			return Math.Sign(mpir.mpz_cmp_ui(this, other));
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
			return Math.Sign(mpir.mpz_cmp_d(this, other));
		}

		public int CompareAbsTo(object obj)
		{
			var other = obj as mpz;
			if (!ReferenceEquals(other, null))
				return CompareAbsTo(other);

			if (obj is int)
				return CompareAbsTo((int) obj);
			if (obj is uint)
				return CompareAbsTo((uint) obj);
			if (obj is long)
				return CompareAbsTo((mpz) (long) obj);
			if (obj is ulong)
				return CompareAbsTo((mpz) (ulong) obj);
			if (obj is double)
				return CompareAbsTo((double) obj);
			if (obj is float)
				return CompareAbsTo((float) obj);
			if (obj is short)
				return CompareAbsTo((short) obj);
			if (obj is ushort)
				return CompareAbsTo((ushort) obj);
			if (obj is byte)
				return CompareAbsTo((byte) obj);
			if (obj is sbyte)
				return CompareAbsTo((sbyte) obj);
			if (obj is string)
				return CompareAbsTo(new mpz((string) obj));

			throw new ArgumentException("Cannot compare to " + obj.GetType());
		}

		public int CompareAbsTo(mpz other)
		{
			return Math.Sign(mpir.mpz_cmpabs(this, other));
		}

		public int CompareAbsTo(int other)
		{
			return (other >= 0)
				? Math.Sign(mpir.mpz_cmpabs_ui(this, (uint) other))
				: Math.Sign(mpir.mpz_cmpabs_ui(this, (uint) -other));
		}

		public int CompareAbsTo(uint other)
		{
			return Math.Sign(mpir.mpz_cmpabs_ui(this, other));
		}

		public int CompareAbsTo(double other)
		{
			return Math.Sign(mpir.mpz_cmpabs_d(this, other));
		}

		public static int Compare(mpz x, object y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(object x, mpz y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpz x, mpz y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(mpz x, int y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(int x, mpz y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpz x, uint y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(uint x, mpz y)
		{
			return -y.CompareTo(x);
		}

		public static int Compare(mpz x, double y)
		{
			return x.CompareTo(y);
		}

		public static int Compare(double x, mpz y)
		{
			return -y.CompareTo(x);
		}

		public static int CompareAbs(mpz x, object y)
		{
			return x.CompareAbsTo(y);
		}

		public static int CompareAbs(object x, mpz y)
		{
			return -y.CompareAbsTo(x);
		}

		public static int CompareAbs(mpz x, mpz y)
		{
			return x.CompareAbsTo(y);
		}

		public static int CompareAbs(mpz x, int y)
		{
			return x.CompareAbsTo(y);
		}

		public static int CompareAbs(int x, mpz y)
		{
			return -y.CompareAbsTo(x);
		}

		public static int CompareAbs(mpz x, uint y)
		{
			return x.CompareAbsTo(y);
		}

		public static int CompareAbs(uint x, mpz y)
		{
			return -y.CompareAbsTo(x);
		}

		public static int CompareAbs(mpz x, double y)
		{
			return x.CompareAbsTo(y);
		}

		public static int CompareAbs(double x, mpz y)
		{
			return -y.CompareAbsTo(x);
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

		public mpz Clone()
		{
			return new mpz(this);
		}

		#endregion

		#region Conversions

		public mpq ToMpq()
		{
			return new mpq(this);
		}

		public mpf ToMpf(ulong? precision = null)
		{
			return new mpf(
				this,
				precision.HasValue ? precision.Value : Math.Max(mpf.DefaultPrecision, BitLength + 16)
			);
		}

		public mpf ToMpf(long precision)
		{
			if (precision < 0)
				throw new ArgumentOutOfRangeException("precision");

			return ToMpf((ulong) precision);
		}

		public mpfr ToMpfr(long? precision = null)
		{
			return new mpfr(
				this,
				null,
				precision.HasValue ? precision.Value : Math.Max(mpfr.DefaultPrecision, (long) BitLength + 16)
			);
		}

		public BigInteger ToBigInteger()
		{
			return new BigInteger(ToByteArray(-1));
		}

		public BitArray ToBitArray()
		{
			return new BitArray(ToByteArray(-1));
		}

		public double ToDouble(out int exponentOfTwo)
		{
			return mpir.mpz_get_d_2exp(out exponentOfTwo, this);
		}

		public override string ToString()
		{
			return ToString(_DEFAULT_STRING_BASE);
		}

		public string ToString(uint @base)
		{
			return mpir.mpz_get_string(@base, this);
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

			if (targetType == typeof (mpz))
				return this;

			var convertible = (IConvertible) this;

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

		public static implicit operator mpz(byte value)
		{
			return new mpz(value);
		}

		public static implicit operator mpz(int value)
		{
			return new mpz(value);
		}

		public static implicit operator mpz(uint value)
		{
			return new mpz(value);
		}

		public static implicit operator mpz(short value)
		{
			return new mpz(value);
		}

		public static implicit operator mpz(ushort value)
		{
			return new mpz(value);
		}

		public static implicit operator mpz(long value)
		{
			return new mpz(value);
		}

		public static implicit operator mpz(ulong value)
		{
			return new mpz(value);
		}

		public static explicit operator mpz(float value)
		{
			return new mpz(value);
		}

		public static explicit operator mpz(double value)
		{
			return new mpz(value);
		}

		public static explicit operator mpz(string value)
		{
			return new mpz(value, _DEFAULT_STRING_BASE);
		}

		public static explicit operator byte(mpz value)
		{
			return (byte) (uint) value;
		}

		public static explicit operator int(mpz value)
		{
			return mpir.mpz_get_si(value);
		}

		public static explicit operator uint(mpz value)
		{
			return mpir.mpz_get_ui(value);
		}

		public static explicit operator short(mpz value)
		{
			return (short) (int) value;
		}

		public static explicit operator ushort(mpz value)
		{
			return (ushort) (uint) value;
		}

		public static explicit operator long(mpz value)
		{
			var bytes = new byte[8];
			var exportedBytes = value.ToByteArray(BitConverter.IsLittleEndian ? -1 : 1);
			var destOffset = BitConverter.IsLittleEndian ? 0 : 8 - exportedBytes.Length;

			Buffer.BlockCopy(exportedBytes, 0, bytes, destOffset, exportedBytes.Length);
			return BitConverter.ToInt64(bytes, 0);
		}

		public static explicit operator ulong(mpz value)
		{
			var bytes = new byte[8];
			var exportedBytes = value.ToByteArray(BitConverter.IsLittleEndian ? -1 : 1);
			var destOffset = BitConverter.IsLittleEndian ? 0 : 8 - exportedBytes.Length;

			Buffer.BlockCopy(exportedBytes, 0, bytes, destOffset, exportedBytes.Length);
			return BitConverter.ToUInt64(bytes, 0);
		}

		public static explicit operator float(mpz value)
		{
			return (float) (double) value;
		}

		public static explicit operator double(mpz value)
		{
			return mpir.mpz_get_d(value);
		}

		public static explicit operator string(mpz value)
		{
			return value.ToString();
		}

		#endregion

		#region Operators

		public static mpz operator -(mpz x)
		{
			return x.AsImmutable().Negate();
		}

		public static mpz operator ~(mpz x)
		{
			return x.AsImmutable().Complement();
		}

		public static mpz operator +(mpz x, mpz y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpz operator +(mpz x, int y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpz operator +(mpz x, uint y)
		{
			return x.AsImmutable().Add(y);
		}

		public static mpz operator +(int x, mpz y)
		{
			return y.AsImmutable().Add(x);
		}

		public static mpz operator +(uint x, mpz y)
		{
			return y.AsImmutable().Add(x);
		}

		public static mpz operator -(mpz x, mpz y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpz operator -(mpz x, int y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpz operator -(mpz x, uint y)
		{
			return x.AsImmutable().Subtract(y);
		}

		public static mpz operator -(int x, mpz y)
		{
			return y.AsImmutable().SubtractFrom(x);
		}

		public static mpz operator -(uint x, mpz y)
		{
			return y.AsImmutable().SubtractFrom(x);
		}

		public static mpz operator ++(mpz x)
		{
			return x.Add(1U);
		}

		public static mpz operator --(mpz x)
		{
			return x.Subtract(1U);
		}

		public static mpz operator *(mpz x, mpz y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpz operator *(mpz x, int y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpz operator *(mpz x, uint y)
		{
			return x.AsImmutable().Multiply(y);
		}

		public static mpz operator *(int x, mpz y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpz operator *(uint x, mpz y)
		{
			return y.AsImmutable().Multiply(x);
		}

		public static mpz operator /(mpz x, mpz y)
		{
			return x.AsImmutable().TDivQ(y);
		}

		public static mpz operator /(mpz x, int y)
		{
			return x.AsImmutable().TDivQ(y);
		}

		public static mpz operator /(mpz x, uint y)
		{
			return x.AsImmutable().TDivQ(y);
		}

		public static mpz operator <<(mpz x, int shiftAmount)
		{
			if (shiftAmount < 0)
				throw new ArgumentOutOfRangeException("shiftAmount");

			return x.AsImmutable().ShiftLeft((uint) shiftAmount);
		}

		public static mpz operator >>(mpz x, int shiftAmount)
		{
			if (shiftAmount < 0)
				throw new ArgumentOutOfRangeException("shiftAmount");

			return x.AsImmutable().ShiftRight((uint) shiftAmount);
		}

		public static mpz operator &(mpz x, mpz y)
		{
			return x.AsImmutable().And(y);
		}

		public static mpz operator |(mpz x, mpz y)
		{
			return x.AsImmutable().Or(y);
		}

		public static mpz operator ^(mpz x, mpz y)
		{
			return x.AsImmutable().Xor(y);
		}

		public static mpz operator %(mpz x, mpz y)
		{
			return x.AsImmutable().Mod(y);
		}

		public static mpz operator %(mpz x, int y)
		{
			return x.AsImmutable().Mod(y);
		}

		public static mpz operator %(mpz x, uint y)
		{
			return x.AsImmutable().Mod(y);
		}

		public static bool operator <(mpz x, mpz y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <(int x, mpz y)
		{
			return y.CompareTo(x) > 0;
		}

		public static bool operator <(mpz x, int y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <(uint x, mpz y)
		{
			return y.CompareTo(x) > 0;
		}

		public static bool operator <(mpz x, uint y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <(double x, mpz y)
		{
			return y.CompareTo(x) > 0;
		}

		public static bool operator <(mpz x, double y)
		{
			return x.CompareTo(y) < 0;
		}

		public static bool operator <=(mpz x, mpz y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator <=(int x, mpz y)
		{
			return y.CompareTo(x) >= 0;
		}

		public static bool operator <=(mpz x, int y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator <=(uint x, mpz y)
		{
			return y.CompareTo(x) >= 0;
		}

		public static bool operator <=(mpz x, uint y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator <=(double x, mpz y)
		{
			return y.CompareTo(x) >= 0;
		}

		public static bool operator <=(mpz x, double y)
		{
			return x.CompareTo(y) <= 0;
		}

		public static bool operator >(mpz x, mpz y)
		{
			return !(x <= y);
		}

		public static bool operator >(int x, mpz y)
		{
			return !(x <= y);
		}

		public static bool operator >(mpz x, int y)
		{
			return !(x <= y);
		}

		public static bool operator >(uint x, mpz y)
		{
			return !(x <= y);
		}

		public static bool operator >(mpz x, uint y)
		{
			return !(x <= y);
		}

		public static bool operator >(double x, mpz y)
		{
			return !(x <= y);
		}

		public static bool operator >(mpz x, double y)
		{
			return !(x <= y);
		}

		public static bool operator >=(mpz x, mpz y)
		{
			return !(x < y);
		}

		public static bool operator >=(int x, mpz y)
		{
			return !(x < y);
		}

		public static bool operator >=(mpz x, int y)
		{
			return !(x < y);
		}

		public static bool operator >=(uint x, mpz y)
		{
			return !(x < y);
		}

		public static bool operator >=(mpz x, uint y)
		{
			return !(x < y);
		}

		public static bool operator >=(double x, mpz y)
		{
			return !(x < y);
		}

		public static bool operator >=(mpz x, double y)
		{
			return !(x < y);
		}

		public static bool operator ==(mpz x, mpz y)
		{
			var xNull = ReferenceEquals(x, null);
			var yNull = ReferenceEquals(y, null);

			return (xNull || yNull) ? (xNull && yNull) : x.Equals(y);
		}

		public static bool operator ==(int x, mpz y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpz x, int y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator ==(uint x, mpz y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpz x, uint y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator ==(double x, mpz y)
		{
			return !ReferenceEquals(y, null) && y.Equals(x);
		}

		public static bool operator ==(mpz x, double y)
		{
			return !ReferenceEquals(x, null) && x.Equals(y);
		}

		public static bool operator !=(mpz x, mpz y)
		{
			return !(x == y);
		}

		public static bool operator !=(int x, mpz y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpz x, int y)
		{
			return !(x == y);
		}

		public static bool operator !=(uint x, mpz y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpz x, uint y)
		{
			return !(x == y);
		}

		public static bool operator !=(double x, mpz y)
		{
			return !(x == y);
		}

		public static bool operator !=(mpz x, double y)
		{
			return !(x == y);
		}

		#endregion

		#region Mutable / Immutable

		public virtual bool IsMutable
		{
			get { return false; }
		}

		public virtual mpz AsMutable()
		{
			return new xmpz(this);
		}

		public virtual mpz AsImmutable()
		{
			return this;
		}

		#endregion
	}
}
