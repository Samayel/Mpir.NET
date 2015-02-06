using System;
using System.Collections.Generic;

// Disable warning about missing XML comments.
#pragma warning disable 1591

namespace Mpir.NET
{
    public class gmp_randstate_t : IDisposable
    {
        #region Data

        internal IntPtr Val;
        private bool _disposed;
        
        #endregion

        #region Creation and destruction

        public gmp_randstate_t()                             { Val = mpir.gmp_randinit_default();            }
        public gmp_randstate_t(mpz a, uint c, ulong m2exp) { Val = mpir.gmp_randinit_lc_2exp(a, c, m2exp); }
        public gmp_randstate_t(gmp_randstate_t op)           { Val = mpir.gmp_randinit_set(op);              }

        public static gmp_randstate_t randinit_mt() { return new gmp_randstate_t(true); }
        private gmp_randstate_t(bool dummy) { Val = mpir.gmp_randinit_mt(); }

        ~gmp_randstate_t()
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
            if (!_disposed) {
                // dispose unmanaged resources
                mpir.gmp_randclear(this);
                _disposed = true;   
            }
        }

        #endregion
    }
}
