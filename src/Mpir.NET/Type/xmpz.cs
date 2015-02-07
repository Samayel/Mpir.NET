using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpir.NET
{
	internal class xmpz : mpz
	{
		#region Creation and destruction

		public xmpz(mpz op) : base(op)
		{
		}

		~xmpz()
		{
			Dispose(false);
		}

		public override void Reallocate(uint size)
		{
			mpir.mpz_realloc2(this, size);
		}

		#endregion

		#region Basic Arithmetic

		public override mpz Negate()
		{
			mpir.mpz_neg(this, this);
			return this;
		}

		#region add

		public override mpz Add(mpz x)
		{
			mpir.mpz_add(this, this, x);
			return this;
		}

		public override mpz Add(uint x)
		{
			mpir.mpz_add_ui(this, this, x);
			return this;
		}

		#endregion

		#region sub

		public override mpz Subtract(mpz x)
		{
			mpir.mpz_sub(this, this, x);
			return this;
		}

		public override mpz Subtract(uint x)
		{
			mpir.mpz_sub_ui(this, this, x);
			return this;
		}

		public override mpz SubtractFrom(uint x)
		{
			mpir.mpz_ui_sub(this, x, this);
			return this;
		}

		#endregion

		#region mul

		public override mpz Multiply(mpz x)
		{
			mpir.mpz_mul(this, this, x);
			return this;
		}

		public override mpz Multiply(int x)
		{
			mpir.mpz_mul_si(this, this, x);
			return this;
		}

		public override mpz Multiply(uint x)
		{
			mpir.mpz_mul_ui(this, this, x);
			return this;
		}

		public override mpz MultiplyBy2Exp(uint x)
		{
			mpir.mpz_mul_2exp(this, this, x);
			return this;
		}

		#endregion

		#region cdiv

		public override mpz CDivQ(mpz x)
		{
			mpir.mpz_cdiv_q(this, this, x);
			return this;
		}

		public override mpz CDivR(mpz x)
		{
			mpir.mpz_cdiv_r(this, this, x);
			return this;
		}

		public override mpz CDivQR(mpz x, out mpz r)
		{
			r = new mpz();
			mpir.mpz_cdiv_qr(this, r, this, x);
			return this;
		}

		public override mpz CDivQ(uint x)
		{
			mpir.mpz_cdiv_q_ui(this, this, x);
			return this;
		}

		public override mpz CDivR(uint x)
		{
			mpir.mpz_cdiv_r_ui(this, this, x);
			return this;
		}

		public override mpz CDivQR(uint x, out mpz r)
		{
			r = new mpz();
			mpir.mpz_cdiv_qr_ui(this, r, this, x);
			return this;
		}

		public override mpz CDivQ2Exp(uint x)
		{
			mpir.mpz_cdiv_q_2exp(this, this, x);
			return this;
		}

		public override mpz CDivR2Exp(uint x)
		{
			mpir.mpz_cdiv_r_2exp(this, this, x);
			return this;
		}

		#endregion

		#region fdiv

		public override mpz FDivQ(mpz x)
		{
			mpir.mpz_fdiv_q(this, this, x);
			return this;
		}

		public override mpz FDivR(mpz x)
		{
			mpir.mpz_fdiv_r(this, this, x);
			return this;
		}

		public override mpz FDivQR(mpz x, out mpz r)
		{
			r = new mpz();
			mpir.mpz_fdiv_qr(this, r, this, x);
			return this;
		}

		public override mpz FDivQ(uint x)
		{
			mpir.mpz_fdiv_q_ui(this, this, x);
			return this;
		}

		public override mpz FDivR(uint x)
		{
			mpir.mpz_fdiv_r_ui(this, this, x);
			return this;
		}

		public override mpz FDivQR(uint x, out mpz r)
		{
			r = new mpz();
			mpir.mpz_fdiv_qr_ui(this, r, this, x);
			return this;
		}

		public override mpz FDivQ2Exp(uint x)
		{
			mpir.mpz_fdiv_q_2exp(this, this, x);
			return this;
		}

		public override mpz FDivR2Exp(uint x)
		{
			mpir.mpz_fdiv_r_2exp(this, this, x);
			return this;
		}

		#endregion

		#region tdiv

		public override mpz TDivQ(mpz x)
		{
			mpir.mpz_tdiv_q(this, this, x);
			return this;
		}

		public override mpz TDivR(mpz x)
		{
			mpir.mpz_tdiv_r(this, this, x);
			return this;
		}

		public override mpz TDivQR(mpz x, out mpz r)
		{
			r = new mpz();
			mpir.mpz_tdiv_qr(this, r, this, x);
			return this;
		}

		public override mpz TDivQ(uint x)
		{
			mpir.mpz_tdiv_q_ui(this, this, x);
			return this;
		}

		public override mpz TDivR(uint x)
		{
			mpir.mpz_tdiv_r_ui(this, this, x);
			return this;
		}

		public override mpz TDivQR(uint x, out mpz r)
		{
			r = new mpz();
			mpir.mpz_tdiv_qr_ui(this, r, this, x);
			return this;
		}

		public override mpz TDivQ2Exp(uint x)
		{
			mpir.mpz_tdiv_q_2exp(this, this, x);
			return this;
		}

		public override mpz TDivR2Exp(uint x)
		{
			mpir.mpz_tdiv_r_2exp(this, this, x);
			return this;
		}

		#endregion

		#region mod

		public override mpz Mod(mpz x)
		{
			mpir.mpz_mod(this, this, x);
			return this;
		}

		public override mpz Mod(uint x)
		{
			mpir.mpz_mod_ui(this, this, x);
			return this;
		}

		#endregion

		#region divexact

		public override mpz DivideExactly(mpz x)
		{
			mpir.mpz_divexact(this, this, x);
			return this;
		}

		public override mpz DivideExactly(uint x)
		{
			mpir.mpz_divexact_ui(this, this, x);
			return this;
		}

		#endregion

		#region powm

		public override mpz PowerMod(mpz exponent, mpz mod)
		{
			mpir.mpz_powm(this, this, exponent, mod);
			return this;
		}

		public override mpz PowerMod(uint exponent, mpz mod)
		{
			mpir.mpz_powm_ui(this, this, exponent, mod);
			return this;
		}

		#endregion

		#region pow

		public override mpz Power(uint exponent)
		{
			mpir.mpz_pow_ui(this, this, exponent);
			return this;
		}

		#endregion

		#endregion

		#region Roots

		public override mpz Root(uint n, out bool isExact)
		{
			var ans = mpir.mpz_root(this, this, n);
			isExact = ans != 0;
			return this;
		}

		public override mpz Root(uint n)
		{
			mpir.mpz_nthroot(this, this, n);
			return this;
		}

		public override mpz Root(uint n, out mpz r)
		{
			r = new mpz();
			mpir.mpz_rootrem(this, r, this, n);
			return this;
		}

		public override mpz Sqrt()
		{
			mpir.mpz_sqrt(this, this);
			return this;
		}

		public override mpz Sqrt(out mpz r)
		{
			r = new mpz();
			mpir.mpz_sqrtrem(this, r, this);
			return this;
		}

		#endregion

		#region Number Theoretic Functions

		#region prime

		public override mpz NextPrime()
		{
			mpir.mpz_nextprime(this, this);
			return this;
		}

		public override mpz NextPrimeCandidate(randstate state)
		{
			mpir.mpz_next_prime_candidate(this, this, state);
			return this;
		}

		#endregion

		#region gcd

		public override mpz Gcd(mpz x)
		{
			mpir.mpz_gcd(this, this, x);
			return this;
		}

		public override mpz Gcd(uint x)
		{
			mpir.mpz_gcd_ui(this, this, x);
			return this;
		}

		#endregion

		#region lcm

		public override mpz Lcm(mpz x)
		{
			mpir.mpz_lcm(this, this, x);
			return this;
		}

		public override mpz Lcm(uint x)
		{
			mpir.mpz_lcm_ui(this, this, x);
			return this;
		}

		#endregion

		#region invert

		public override bool TryInvertMod(mpz mod, out mpz result)
		{
			using (var z = new mpz())
			{
				var ans = mpir.mpz_invert(z, this, mod);
				if (ans == 0)
				{
					result = null;
					return false;
				}

				mpir.mpz_set(this, z);
				result = this;
				return true;
			}
		}

		public override bool InverseModExists(mpz mod)
		{
			mpz result;
			return AsImmutable().TryInvertMod(mod, out result);
		}

		#endregion

		#region remove

		public override mpz RemoveFactor(mpz factor, out ulong count)
		{
			count = mpir.mpz_remove(this, this, factor);
			return this;
		}

		#endregion

		#endregion

		#region Bitwise Functions

		public override mpz And(mpz x)
		{
			mpir.mpz_and(this, this, x);
			return this;
		}

		public override mpz Or(mpz x)
		{
			mpir.mpz_ior(this, this, x);
			return this;
		}

		public override mpz Xor(mpz x)
		{
			mpir.mpz_xor(this, this, x);
			return this;
		}

		public override mpz Complement()
		{
			mpir.mpz_com(this, this);
			return this;
		}

		public override mpz SetBit(ulong bitIndex)
		{
			mpir.mpz_setbit(this, bitIndex);
			return this;
		}

		public override mpz ClearBit(ulong bitIndex)
		{
			mpir.mpz_clrbit(this, bitIndex);
			return this;
		}

		public override mpz ComplementBit(ulong bitIndex)
		{
			mpir.mpz_combit(this, bitIndex);
			return this;
		}

		public override bool this[ulong bitIndex]
		{
			get
			{
				return GetBit(bitIndex) != 0;
			}
			set
			{
				SetBit(bitIndex, value ? 1 : 0);
			}
		}

		public override bool this[long bitIndex]
		{
			get
			{
				return GetBit(bitIndex) != 0;
			}
			set
			{
				SetBit(bitIndex, value ? 1 : 0);
			}
		}

		#endregion

		#region Mutable / Immutable

		public override bool IsMutable
		{
			get { return true; }
		}

		public override mpz AsMutable()
		{
			return this;
		}

		public override mpz AsImmutable()
		{
			return new mpz(this);
		}

		#endregion
	}
}
