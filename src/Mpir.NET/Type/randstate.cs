using System;
using System.Collections.Generic;

// Disable warning about missing XML comments.
#pragma warning disable 1591

namespace Mpir.NET
{
	public class randstate : IDisposable, ICloneable
	{
		#region Data

		internal IntPtr Val;
		private bool _disposed;

		#endregion

		#region Creation and destruction

		private randstate()
		{
		}

		public randstate(randstate op)
		{
			Val = mpir.gmp_randinit_set(op);
		}

		~randstate()
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
			mpir.gmp_randclear(this);
			_disposed = true;
		}

		public static randstate Create()
		{
			return new randstate { Val = mpir.gmp_randinit_default() };
		}

		public static randstate CreateMersenneTwister()
		{
			return new randstate { Val = mpir.gmp_randinit_mt() };
		}

		public static randstate CreateLinearCongruential(mpz a, uint c, ulong m2exp)
		{
			return new randstate { Val = mpir.gmp_randinit_lc_2exp(a, c, m2exp) };
		}

		public static randstate CreateLinearCongruential(ulong size)
		{
			return new randstate { Val = mpir.gmp_randinit_lc_2exp_size(size) };
		}

		#endregion

		#region Seeding

		public void SetSeed(mpz seed)
		{
			mpir.gmp_randseed(this, seed);
		}

		public void SetSeed(uint seed)
		{
			mpir.gmp_randseed_ui(this, seed);
		}

		#endregion

		#region Miscellaneous

		public uint GetUniformlyDistributedRandomBits(uint size)
		{
			return mpir.gmp_urandomb_ui(this, size);
		}

		public uint GetUniformlyDistributedRandomNumber(uint limit)
		{
			return mpir.gmp_urandomm_ui(this, limit);
		}

		#endregion

		#region Cloning

		object ICloneable.Clone()
		{
			return Clone();
		}

		public randstate Clone()
		{
			return new randstate(this);
		}

		#endregion
	}
}
