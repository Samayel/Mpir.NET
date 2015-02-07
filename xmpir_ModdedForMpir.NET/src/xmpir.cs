/*
Copyright 2010 Sergey Bochkanov.

The X-MPIR is free software; you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation; either version 3 of the License, or (at your
option) any later version.

The X-MPIR is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
License for more details.

You should have received a copy of the GNU Lesser General Public License
along with the X-MPIR; see the file COPYING.LIB.  If not, write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
MA 02110-1301, USA.
*/

/*
Modifications by John Reynolds, to provide disposal of unmanaged resources,
binary import/export functions etc.
*/    

using System;
using System.Reflection;
using System.Runtime.InteropServices;

// Disable warning about missing XML comments.
#pragma warning disable 1591

namespace Mpir.NET 
{

using mpz_intptr = IntPtr;
using mpq_intptr = IntPtr;
using mpf_intptr = IntPtr;
using mpfr_intptr = IntPtr;
using gmp_randstate_intptr = IntPtr;


public static partial class mpir
{
    //
    // xMPIR library handle
    private static IntPtr hxmpir = initialize_hxmpir();
    

    //
    // Automatically generated code: pointers to functions
    //
    private static IntPtr __ptr__xmpir_mpz_init = GetProcAddressSafe(hxmpir, "xmpir_mpz_init");
    private static IntPtr __ptr__xmpir_mpz_init2 = GetProcAddressSafe(hxmpir, "xmpir_mpz_init2");
    private static IntPtr __ptr__xmpir_mpz_init_set = GetProcAddressSafe(hxmpir, "xmpir_mpz_init_set");
    private static IntPtr __ptr__xmpir_mpz_init_set_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_init_set_ui");
    private static IntPtr __ptr__xmpir_mpz_init_set_si = GetProcAddressSafe(hxmpir, "xmpir_mpz_init_set_si");
    private static IntPtr __ptr__xmpir_mpz_init_set_d = GetProcAddressSafe(hxmpir, "xmpir_mpz_init_set_d");
    private static IntPtr __ptr__xmpir_mpz_init_set_str = GetProcAddressSafe(hxmpir, "xmpir_mpz_init_set_str");
    private static IntPtr __ptr__xmpir_mpq_init = GetProcAddressSafe(hxmpir, "xmpir_mpq_init");
    private static IntPtr __ptr__xmpir_mpf_init = GetProcAddressSafe(hxmpir, "xmpir_mpf_init");
    private static IntPtr __ptr__xmpir_mpf_init2 = GetProcAddressSafe(hxmpir, "xmpir_mpf_init2");
    private static IntPtr __ptr__xmpir_mpf_init_set = GetProcAddressSafe(hxmpir, "xmpir_mpf_init_set");
    private static IntPtr __ptr__xmpir_mpf_init_set_ui = GetProcAddressSafe(hxmpir, "xmpir_mpf_init_set_ui");
    private static IntPtr __ptr__xmpir_mpf_init_set_si = GetProcAddressSafe(hxmpir, "xmpir_mpf_init_set_si");
    private static IntPtr __ptr__xmpir_mpf_init_set_d = GetProcAddressSafe(hxmpir, "xmpir_mpf_init_set_d");
    private static IntPtr __ptr__xmpir_mpf_init_set_str = GetProcAddressSafe(hxmpir, "xmpir_mpf_init_set_str");
    private static IntPtr __ptr__xmpir_mpz_clear = GetProcAddressSafe(hxmpir, "xmpir_mpz_clear");
    private static IntPtr __ptr__xmpir_mpq_clear = GetProcAddressSafe(hxmpir, "xmpir_mpq_clear");
    private static IntPtr __ptr__xmpir_mpf_clear = GetProcAddressSafe(hxmpir, "xmpir_mpf_clear");
    private static IntPtr __ptr__xmpir_xmpir_dummy = GetProcAddressSafe(hxmpir, "xmpir_xmpir_dummy");
    private static IntPtr __ptr__xmpir_xmpir_dummy_add = GetProcAddressSafe(hxmpir, "xmpir_xmpir_dummy_add");
    private static IntPtr __ptr__xmpir_xmpir_dummy_3mpz = GetProcAddressSafe(hxmpir, "xmpir_xmpir_dummy_3mpz");
    private static IntPtr __ptr__xmpir_gmp_randinit_default = GetProcAddressSafe(hxmpir, "xmpir_gmp_randinit_default");
    private static IntPtr __ptr__xmpir_gmp_randinit_mt = GetProcAddressSafe(hxmpir, "xmpir_gmp_randinit_mt");
    private static IntPtr __ptr__xmpir_gmp_randinit_lc_2exp = GetProcAddressSafe(hxmpir, "xmpir_gmp_randinit_lc_2exp");
    private static IntPtr __ptr__xmpir_gmp_randinit_lc_2exp_size = GetProcAddressSafe(hxmpir, "xmpir_gmp_randinit_lc_2exp_size");
    private static IntPtr __ptr__xmpir_gmp_randinit_set = GetProcAddressSafe(hxmpir, "xmpir_gmp_randinit_set");
    private static IntPtr __ptr__xmpir_gmp_randclear = GetProcAddressSafe(hxmpir, "xmpir_gmp_randclear");
    private static IntPtr __ptr__xmpir_gmp_randseed = GetProcAddressSafe(hxmpir, "xmpir_gmp_randseed");
    private static IntPtr __ptr__xmpir_gmp_randseed_ui = GetProcAddressSafe(hxmpir, "xmpir_gmp_randseed_ui");
    private static IntPtr __ptr__xmpir_gmp_urandomb_ui = GetProcAddressSafe(hxmpir, "xmpir_gmp_urandomb_ui");
    private static IntPtr __ptr__xmpir_gmp_urandomm_ui = GetProcAddressSafe(hxmpir, "xmpir_gmp_urandomm_ui");
    private static IntPtr __ptr__xmpir_mpz_realloc2 = GetProcAddressSafe(hxmpir, "xmpir_mpz_realloc2");
    private static IntPtr __ptr__xmpir_mpf_set_default_prec = GetProcAddressSafe(hxmpir, "xmpir_mpf_set_default_prec");
    private static IntPtr __ptr__xmpir_mpf_get_default_prec = GetProcAddressSafe(hxmpir, "xmpir_mpf_get_default_prec");
    private static IntPtr __ptr__xmpir_mpz_set = GetProcAddressSafe(hxmpir, "xmpir_mpz_set");
    private static IntPtr __ptr__xmpir_mpz_set_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_set_ui");
    private static IntPtr __ptr__xmpir_mpz_set_si = GetProcAddressSafe(hxmpir, "xmpir_mpz_set_si");
    private static IntPtr __ptr__xmpir_mpz_set_d = GetProcAddressSafe(hxmpir, "xmpir_mpz_set_d");
    private static IntPtr __ptr__xmpir_mpz_set_q = GetProcAddressSafe(hxmpir, "xmpir_mpz_set_q");
    private static IntPtr __ptr__xmpir_mpz_set_f = GetProcAddressSafe(hxmpir, "xmpir_mpz_set_f");
    private static IntPtr __ptr__xmpir_mpz_set_str = GetProcAddressSafe(hxmpir, "xmpir_mpz_set_str");
    private static IntPtr __ptr__xmpir_mpz_swap = GetProcAddressSafe(hxmpir, "xmpir_mpz_swap");
    private static IntPtr __ptr__xmpir_mpz_get_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_get_ui");
    private static IntPtr __ptr__xmpir_mpz_get_si = GetProcAddressSafe(hxmpir, "xmpir_mpz_get_si");
    private static IntPtr __ptr__xmpir_mpz_get_d = GetProcAddressSafe(hxmpir, "xmpir_mpz_get_d");
    private static IntPtr __ptr__xmpir_mpz_get_d_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpz_get_d_2exp");
    private static IntPtr __ptr__xmpir_mpz_get_string = GetProcAddressSafe(hxmpir, "xmpir_mpz_get_string");
    private static IntPtr __ptr__xmpir_mpz_add = GetProcAddressSafe(hxmpir, "xmpir_mpz_add");
    private static IntPtr __ptr__xmpir_mpz_add_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_add_ui");
    private static IntPtr __ptr__xmpir_mpz_sub = GetProcAddressSafe(hxmpir, "xmpir_mpz_sub");
    private static IntPtr __ptr__xmpir_mpz_sub_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_sub_ui");
    private static IntPtr __ptr__xmpir_mpz_ui_sub = GetProcAddressSafe(hxmpir, "xmpir_mpz_ui_sub");
    private static IntPtr __ptr__xmpir_mpz_mul = GetProcAddressSafe(hxmpir, "xmpir_mpz_mul");
    private static IntPtr __ptr__xmpir_mpz_mul_si = GetProcAddressSafe(hxmpir, "xmpir_mpz_mul_si");
    private static IntPtr __ptr__xmpir_mpz_mul_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_mul_ui");
    private static IntPtr __ptr__xmpir_mpz_addmul = GetProcAddressSafe(hxmpir, "xmpir_mpz_addmul");
    private static IntPtr __ptr__xmpir_mpz_addmul_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_addmul_ui");
    private static IntPtr __ptr__xmpir_mpz_submul = GetProcAddressSafe(hxmpir, "xmpir_mpz_submul");
    private static IntPtr __ptr__xmpir_mpz_submul_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_submul_ui");
    private static IntPtr __ptr__xmpir_mpz_mul_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpz_mul_2exp");
    private static IntPtr __ptr__xmpir_mpz_neg = GetProcAddressSafe(hxmpir, "xmpir_mpz_neg");
    private static IntPtr __ptr__xmpir_mpz_abs = GetProcAddressSafe(hxmpir, "xmpir_mpz_abs");
    private static IntPtr __ptr__xmpir_mpz_cdiv_q = GetProcAddressSafe(hxmpir, "xmpir_mpz_cdiv_q");
    private static IntPtr __ptr__xmpir_mpz_cdiv_r = GetProcAddressSafe(hxmpir, "xmpir_mpz_cdiv_r");
    private static IntPtr __ptr__xmpir_mpz_cdiv_qr = GetProcAddressSafe(hxmpir, "xmpir_mpz_cdiv_qr");
    private static IntPtr __ptr__xmpir_mpz_cdiv_q_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_cdiv_q_ui");
    private static IntPtr __ptr__xmpir_mpz_cdiv_r_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_cdiv_r_ui");
    private static IntPtr __ptr__xmpir_mpz_cdiv_qr_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_cdiv_qr_ui");
    private static IntPtr __ptr__xmpir_mpz_cdiv_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_cdiv_ui");
    private static IntPtr __ptr__xmpir_mpz_cdiv_q_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpz_cdiv_q_2exp");
    private static IntPtr __ptr__xmpir_mpz_cdiv_r_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpz_cdiv_r_2exp");
    private static IntPtr __ptr__xmpir_mpz_fdiv_q = GetProcAddressSafe(hxmpir, "xmpir_mpz_fdiv_q");
    private static IntPtr __ptr__xmpir_mpz_fdiv_r = GetProcAddressSafe(hxmpir, "xmpir_mpz_fdiv_r");
    private static IntPtr __ptr__xmpir_mpz_fdiv_qr = GetProcAddressSafe(hxmpir, "xmpir_mpz_fdiv_qr");
    private static IntPtr __ptr__xmpir_mpz_fdiv_q_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_fdiv_q_ui");
    private static IntPtr __ptr__xmpir_mpz_fdiv_r_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_fdiv_r_ui");
    private static IntPtr __ptr__xmpir_mpz_fdiv_qr_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_fdiv_qr_ui");
    private static IntPtr __ptr__xmpir_mpz_fdiv_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_fdiv_ui");
    private static IntPtr __ptr__xmpir_mpz_fdiv_q_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpz_fdiv_q_2exp");
    private static IntPtr __ptr__xmpir_mpz_fdiv_r_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpz_fdiv_r_2exp");
    private static IntPtr __ptr__xmpir_mpz_tdiv_q = GetProcAddressSafe(hxmpir, "xmpir_mpz_tdiv_q");
    private static IntPtr __ptr__xmpir_mpz_tdiv_r = GetProcAddressSafe(hxmpir, "xmpir_mpz_tdiv_r");
    private static IntPtr __ptr__xmpir_mpz_tdiv_qr = GetProcAddressSafe(hxmpir, "xmpir_mpz_tdiv_qr");
    private static IntPtr __ptr__xmpir_mpz_tdiv_q_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_tdiv_q_ui");
    private static IntPtr __ptr__xmpir_mpz_tdiv_r_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_tdiv_r_ui");
    private static IntPtr __ptr__xmpir_mpz_tdiv_qr_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_tdiv_qr_ui");
    private static IntPtr __ptr__xmpir_mpz_tdiv_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_tdiv_ui");
    private static IntPtr __ptr__xmpir_mpz_tdiv_q_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpz_tdiv_q_2exp");
    private static IntPtr __ptr__xmpir_mpz_tdiv_r_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpz_tdiv_r_2exp");
    private static IntPtr __ptr__xmpir_mpz_mod = GetProcAddressSafe(hxmpir, "xmpir_mpz_mod");
    private static IntPtr __ptr__xmpir_mpz_mod_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_mod_ui");
    private static IntPtr __ptr__xmpir_mpz_divexact = GetProcAddressSafe(hxmpir, "xmpir_mpz_divexact");
    private static IntPtr __ptr__xmpir_mpz_divexact_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_divexact_ui");
    private static IntPtr __ptr__xmpir_mpz_divisible_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_divisible_p");
    private static IntPtr __ptr__xmpir_mpz_divisible_ui_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_divisible_ui_p");
    private static IntPtr __ptr__xmpir_mpz_divisible_2exp_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_divisible_2exp_p");
    private static IntPtr __ptr__xmpir_mpz_congruent_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_congruent_p");
    private static IntPtr __ptr__xmpir_mpz_congruent_ui_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_congruent_ui_p");
    private static IntPtr __ptr__xmpir_mpz_congruent_2exp_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_congruent_2exp_p");
    private static IntPtr __ptr__xmpir_mpz_powm = GetProcAddressSafe(hxmpir, "xmpir_mpz_powm");
    private static IntPtr __ptr__xmpir_mpz_powm_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_powm_ui");
    private static IntPtr __ptr__xmpir_mpz_pow_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_pow_ui");
    private static IntPtr __ptr__xmpir_mpz_ui_pow_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_ui_pow_ui");
    private static IntPtr __ptr__xmpir_mpz_root = GetProcAddressSafe(hxmpir, "xmpir_mpz_root");
    private static IntPtr __ptr__xmpir_mpz_nthroot = GetProcAddressSafe(hxmpir, "xmpir_mpz_nthroot");
    private static IntPtr __ptr__xmpir_mpz_rootrem = GetProcAddressSafe(hxmpir, "xmpir_mpz_rootrem");
    private static IntPtr __ptr__xmpir_mpz_sqrt = GetProcAddressSafe(hxmpir, "xmpir_mpz_sqrt");
    private static IntPtr __ptr__xmpir_mpz_sqrtrem = GetProcAddressSafe(hxmpir, "xmpir_mpz_sqrtrem");
    private static IntPtr __ptr__xmpir_mpz_perfect_power_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_perfect_power_p");
    private static IntPtr __ptr__xmpir_mpz_perfect_square_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_perfect_square_p");
    private static IntPtr __ptr__xmpir_mpz_probable_prime_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_probable_prime_p");
    private static IntPtr __ptr__xmpir_mpz_likely_prime_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_likely_prime_p");
    private static IntPtr __ptr__xmpir_mpz_probab_prime_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_probab_prime_p");
    private static IntPtr __ptr__xmpir_mpz_nextprime = GetProcAddressSafe(hxmpir, "xmpir_mpz_nextprime");
    private static IntPtr __ptr__xmpir_mpz_next_prime_candidate = GetProcAddressSafe(hxmpir, "xmpir_mpz_next_prime_candidate");
    private static IntPtr __ptr__xmpir_mpz_gcd = GetProcAddressSafe(hxmpir, "xmpir_mpz_gcd");
    private static IntPtr __ptr__xmpir_mpz_gcd_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_gcd_ui");
    private static IntPtr __ptr__xmpir_mpz_gcdext = GetProcAddressSafe(hxmpir, "xmpir_mpz_gcdext");
    private static IntPtr __ptr__xmpir_mpz_lcm = GetProcAddressSafe(hxmpir, "xmpir_mpz_lcm");
    private static IntPtr __ptr__xmpir_mpz_lcm_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_lcm_ui");
    private static IntPtr __ptr__xmpir_mpz_invert = GetProcAddressSafe(hxmpir, "xmpir_mpz_invert");
    private static IntPtr __ptr__xmpir_mpz_jacobi = GetProcAddressSafe(hxmpir, "xmpir_mpz_jacobi");
    private static IntPtr __ptr__xmpir_mpz_legendre = GetProcAddressSafe(hxmpir, "xmpir_mpz_legendre");
    private static IntPtr __ptr__xmpir_mpz_kronecker = GetProcAddressSafe(hxmpir, "xmpir_mpz_kronecker");
    private static IntPtr __ptr__xmpir_mpz_kronecker_si = GetProcAddressSafe(hxmpir, "xmpir_mpz_kronecker_si");
    private static IntPtr __ptr__xmpir_mpz_kronecker_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_kronecker_ui");
    private static IntPtr __ptr__xmpir_mpz_si_kronecker = GetProcAddressSafe(hxmpir, "xmpir_mpz_si_kronecker");
    private static IntPtr __ptr__xmpir_mpz_ui_kronecker = GetProcAddressSafe(hxmpir, "xmpir_mpz_ui_kronecker");
    private static IntPtr __ptr__xmpir_mpz_remove = GetProcAddressSafe(hxmpir, "xmpir_mpz_remove");
    private static IntPtr __ptr__xmpir_mpz_fac_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_fac_ui");
    private static IntPtr __ptr__xmpir_mpz_2fac_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_2fac_ui");
    private static IntPtr __ptr__xmpir_mpz_mfac_uiui = GetProcAddressSafe(hxmpir, "xmpir_mpz_mfac_uiui");
    private static IntPtr __ptr__xmpir_mpz_primorial_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_primorial_ui");
    private static IntPtr __ptr__xmpir_mpz_bin_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_bin_ui");
    private static IntPtr __ptr__xmpir_mpz_bin_uiui = GetProcAddressSafe(hxmpir, "xmpir_mpz_bin_uiui");
    private static IntPtr __ptr__xmpir_mpz_fib_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_fib_ui");
    private static IntPtr __ptr__xmpir_mpz_fib2_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_fib2_ui");
    private static IntPtr __ptr__xmpir_mpz_lucnum_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_lucnum_ui");
    private static IntPtr __ptr__xmpir_mpz_lucnum2_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_lucnum2_ui");
    private static IntPtr __ptr__xmpir_mpz_cmp = GetProcAddressSafe(hxmpir, "xmpir_mpz_cmp");
    private static IntPtr __ptr__xmpir_mpz_cmp_d = GetProcAddressSafe(hxmpir, "xmpir_mpz_cmp_d");
    private static IntPtr __ptr__xmpir_mpz_cmp_si = GetProcAddressSafe(hxmpir, "xmpir_mpz_cmp_si");
    private static IntPtr __ptr__xmpir_mpz_cmp_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_cmp_ui");
    private static IntPtr __ptr__xmpir_mpz_cmpabs = GetProcAddressSafe(hxmpir, "xmpir_mpz_cmpabs");
    private static IntPtr __ptr__xmpir_mpz_cmpabs_d = GetProcAddressSafe(hxmpir, "xmpir_mpz_cmpabs_d");
    private static IntPtr __ptr__xmpir_mpz_cmpabs_ui = GetProcAddressSafe(hxmpir, "xmpir_mpz_cmpabs_ui");
    private static IntPtr __ptr__xmpir_mpz_sgn = GetProcAddressSafe(hxmpir, "xmpir_mpz_sgn");
    private static IntPtr __ptr__xmpir_mpz_and = GetProcAddressSafe(hxmpir, "xmpir_mpz_and");
    private static IntPtr __ptr__xmpir_mpz_ior = GetProcAddressSafe(hxmpir, "xmpir_mpz_ior");
    private static IntPtr __ptr__xmpir_mpz_xor = GetProcAddressSafe(hxmpir, "xmpir_mpz_xor");
    private static IntPtr __ptr__xmpir_mpz_com = GetProcAddressSafe(hxmpir, "xmpir_mpz_com");
    private static IntPtr __ptr__xmpir_mpz_popcount = GetProcAddressSafe(hxmpir, "xmpir_mpz_popcount");
    private static IntPtr __ptr__xmpir_mpz_hamdist = GetProcAddressSafe(hxmpir, "xmpir_mpz_hamdist");
    private static IntPtr __ptr__xmpir_mpz_scan0 = GetProcAddressSafe(hxmpir, "xmpir_mpz_scan0");
    private static IntPtr __ptr__xmpir_mpz_scan1 = GetProcAddressSafe(hxmpir, "xmpir_mpz_scan1");
    private static IntPtr __ptr__xmpir_mpz_setbit = GetProcAddressSafe(hxmpir, "xmpir_mpz_setbit");
    private static IntPtr __ptr__xmpir_mpz_clrbit = GetProcAddressSafe(hxmpir, "xmpir_mpz_clrbit");
    private static IntPtr __ptr__xmpir_mpz_combit = GetProcAddressSafe(hxmpir, "xmpir_mpz_combit");
    private static IntPtr __ptr__xmpir_mpz_tstbit = GetProcAddressSafe(hxmpir, "xmpir_mpz_tstbit");
    private static IntPtr __ptr__xmpir_mpz_urandomb = GetProcAddressSafe(hxmpir, "xmpir_mpz_urandomb");
    private static IntPtr __ptr__xmpir_mpz_urandomm = GetProcAddressSafe(hxmpir, "xmpir_mpz_urandomm");
    private static IntPtr __ptr__xmpir_mpz_rrandomb = GetProcAddressSafe(hxmpir, "xmpir_mpz_rrandomb");
    private static IntPtr __ptr__xmpir_mpz_fits_uint_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_fits_uint_p");
    private static IntPtr __ptr__xmpir_mpz_fits_sint_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_fits_sint_p");
    private static IntPtr __ptr__xmpir_mpz_odd_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_odd_p");
    private static IntPtr __ptr__xmpir_mpz_even_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_even_p");
    private static IntPtr __ptr__xmpir_mpz_sizeinbase = GetProcAddressSafe(hxmpir, "xmpir_mpz_sizeinbase");
    private static IntPtr __ptr__xmpir_mpq_canonicalize = GetProcAddressSafe(hxmpir, "xmpir_mpq_canonicalize");
    private static IntPtr __ptr__xmpir_mpq_set = GetProcAddressSafe(hxmpir, "xmpir_mpq_set");
    private static IntPtr __ptr__xmpir_mpq_set_z = GetProcAddressSafe(hxmpir, "xmpir_mpq_set_z");
    private static IntPtr __ptr__xmpir_mpq_set_ui = GetProcAddressSafe(hxmpir, "xmpir_mpq_set_ui");
    private static IntPtr __ptr__xmpir_mpq_set_si = GetProcAddressSafe(hxmpir, "xmpir_mpq_set_si");
    private static IntPtr __ptr__xmpir_mpq_set_str = GetProcAddressSafe(hxmpir, "xmpir_mpq_set_str");
    private static IntPtr __ptr__xmpir_mpq_swap = GetProcAddressSafe(hxmpir, "xmpir_mpq_swap");
    private static IntPtr __ptr__xmpir_mpq_get_d = GetProcAddressSafe(hxmpir, "xmpir_mpq_get_d");
    private static IntPtr __ptr__xmpir_mpq_set_d = GetProcAddressSafe(hxmpir, "xmpir_mpq_set_d");
    private static IntPtr __ptr__xmpir_mpq_set_f = GetProcAddressSafe(hxmpir, "xmpir_mpq_set_f");
    private static IntPtr __ptr__xmpir_mpq_get_string = GetProcAddressSafe(hxmpir, "xmpir_mpq_get_string");
    private static IntPtr __ptr__xmpir_mpq_add = GetProcAddressSafe(hxmpir, "xmpir_mpq_add");
    private static IntPtr __ptr__xmpir_mpq_sub = GetProcAddressSafe(hxmpir, "xmpir_mpq_sub");
    private static IntPtr __ptr__xmpir_mpq_mul = GetProcAddressSafe(hxmpir, "xmpir_mpq_mul");
    private static IntPtr __ptr__xmpir_mpq_mul_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpq_mul_2exp");
    private static IntPtr __ptr__xmpir_mpq_div = GetProcAddressSafe(hxmpir, "xmpir_mpq_div");
    private static IntPtr __ptr__xmpir_mpq_div_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpq_div_2exp");
    private static IntPtr __ptr__xmpir_mpq_neg = GetProcAddressSafe(hxmpir, "xmpir_mpq_neg");
    private static IntPtr __ptr__xmpir_mpq_abs = GetProcAddressSafe(hxmpir, "xmpir_mpq_abs");
    private static IntPtr __ptr__xmpir_mpq_inv = GetProcAddressSafe(hxmpir, "xmpir_mpq_inv");
    private static IntPtr __ptr__xmpir_mpq_cmp = GetProcAddressSafe(hxmpir, "xmpir_mpq_cmp");
    private static IntPtr __ptr__xmpir_mpq_cmp_ui = GetProcAddressSafe(hxmpir, "xmpir_mpq_cmp_ui");
    private static IntPtr __ptr__xmpir_mpq_cmp_si = GetProcAddressSafe(hxmpir, "xmpir_mpq_cmp_si");
    private static IntPtr __ptr__xmpir_mpq_sgn = GetProcAddressSafe(hxmpir, "xmpir_mpq_sgn");
    private static IntPtr __ptr__xmpir_mpq_equal = GetProcAddressSafe(hxmpir, "xmpir_mpq_equal");
    private static IntPtr __ptr__xmpir_mpq_get_num = GetProcAddressSafe(hxmpir, "xmpir_mpq_get_num");
    private static IntPtr __ptr__xmpir_mpq_get_den = GetProcAddressSafe(hxmpir, "xmpir_mpq_get_den");
    private static IntPtr __ptr__xmpir_mpq_set_num = GetProcAddressSafe(hxmpir, "xmpir_mpq_set_num");
    private static IntPtr __ptr__xmpir_mpq_set_den = GetProcAddressSafe(hxmpir, "xmpir_mpq_set_den");
    private static IntPtr __ptr__xmpir_mpf_get_prec = GetProcAddressSafe(hxmpir, "xmpir_mpf_get_prec");
    private static IntPtr __ptr__xmpir_mpf_set_prec = GetProcAddressSafe(hxmpir, "xmpir_mpf_set_prec");
    private static IntPtr __ptr__xmpir_mpf_set = GetProcAddressSafe(hxmpir, "xmpir_mpf_set");
    private static IntPtr __ptr__xmpir_mpf_set_ui = GetProcAddressSafe(hxmpir, "xmpir_mpf_set_ui");
    private static IntPtr __ptr__xmpir_mpf_set_si = GetProcAddressSafe(hxmpir, "xmpir_mpf_set_si");
    private static IntPtr __ptr__xmpir_mpf_set_d = GetProcAddressSafe(hxmpir, "xmpir_mpf_set_d");
    private static IntPtr __ptr__xmpir_mpf_set_z = GetProcAddressSafe(hxmpir, "xmpir_mpf_set_z");
    private static IntPtr __ptr__xmpir_mpf_set_q = GetProcAddressSafe(hxmpir, "xmpir_mpf_set_q");
    private static IntPtr __ptr__xmpir_mpf_set_str = GetProcAddressSafe(hxmpir, "xmpir_mpf_set_str");
    private static IntPtr __ptr__xmpir_mpf_swap = GetProcAddressSafe(hxmpir, "xmpir_mpf_swap");
    private static IntPtr __ptr__xmpir_mpf_get_d = GetProcAddressSafe(hxmpir, "xmpir_mpf_get_d");
    private static IntPtr __ptr__xmpir_mpf_get_d_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpf_get_d_2exp");
    private static IntPtr __ptr__xmpir_mpf_get_si = GetProcAddressSafe(hxmpir, "xmpir_mpf_get_si");
    private static IntPtr __ptr__xmpir_mpf_get_ui = GetProcAddressSafe(hxmpir, "xmpir_mpf_get_ui");
    private static IntPtr __ptr__xmpir_mpf_get_string = GetProcAddressSafe(hxmpir, "xmpir_mpf_get_string");
    private static IntPtr __ptr__xmpir_mpf_add = GetProcAddressSafe(hxmpir, "xmpir_mpf_add");
    private static IntPtr __ptr__xmpir_mpf_add_ui = GetProcAddressSafe(hxmpir, "xmpir_mpf_add_ui");
    private static IntPtr __ptr__xmpir_mpf_sub = GetProcAddressSafe(hxmpir, "xmpir_mpf_sub");
    private static IntPtr __ptr__xmpir_mpf_ui_sub = GetProcAddressSafe(hxmpir, "xmpir_mpf_ui_sub");
    private static IntPtr __ptr__xmpir_mpf_sub_ui = GetProcAddressSafe(hxmpir, "xmpir_mpf_sub_ui");
    private static IntPtr __ptr__xmpir_mpf_mul = GetProcAddressSafe(hxmpir, "xmpir_mpf_mul");
    private static IntPtr __ptr__xmpir_mpf_mul_ui = GetProcAddressSafe(hxmpir, "xmpir_mpf_mul_ui");
    private static IntPtr __ptr__xmpir_mpf_div = GetProcAddressSafe(hxmpir, "xmpir_mpf_div");
    private static IntPtr __ptr__xmpir_mpf_ui_div = GetProcAddressSafe(hxmpir, "xmpir_mpf_ui_div");
    private static IntPtr __ptr__xmpir_mpf_div_ui = GetProcAddressSafe(hxmpir, "xmpir_mpf_div_ui");
    private static IntPtr __ptr__xmpir_mpf_sqrt = GetProcAddressSafe(hxmpir, "xmpir_mpf_sqrt");
    private static IntPtr __ptr__xmpir_mpf_sqrt_ui = GetProcAddressSafe(hxmpir, "xmpir_mpf_sqrt_ui");
    private static IntPtr __ptr__xmpir_mpf_pow_ui = GetProcAddressSafe(hxmpir, "xmpir_mpf_pow_ui");
    private static IntPtr __ptr__xmpir_mpf_neg = GetProcAddressSafe(hxmpir, "xmpir_mpf_neg");
    private static IntPtr __ptr__xmpir_mpf_abs = GetProcAddressSafe(hxmpir, "xmpir_mpf_abs");
    private static IntPtr __ptr__xmpir_mpf_mul_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpf_mul_2exp");
    private static IntPtr __ptr__xmpir_mpf_div_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpf_div_2exp");
    private static IntPtr __ptr__xmpir_mpf_cmp = GetProcAddressSafe(hxmpir, "xmpir_mpf_cmp");
    private static IntPtr __ptr__xmpir_mpf_cmp_d = GetProcAddressSafe(hxmpir, "xmpir_mpf_cmp_d");
    private static IntPtr __ptr__xmpir_mpf_cmp_ui = GetProcAddressSafe(hxmpir, "xmpir_mpf_cmp_ui");
    private static IntPtr __ptr__xmpir_mpf_cmp_si = GetProcAddressSafe(hxmpir, "xmpir_mpf_cmp_si");
    private static IntPtr __ptr__xmpir_mpf_eq = GetProcAddressSafe(hxmpir, "xmpir_mpf_eq");
    private static IntPtr __ptr__xmpir_mpf_reldiff = GetProcAddressSafe(hxmpir, "xmpir_mpf_reldiff");
    private static IntPtr __ptr__xmpir_mpf_sgn = GetProcAddressSafe(hxmpir, "xmpir_mpf_sgn");
    private static IntPtr __ptr__xmpir_mpf_ceil = GetProcAddressSafe(hxmpir, "xmpir_mpf_ceil");
    private static IntPtr __ptr__xmpir_mpf_floor = GetProcAddressSafe(hxmpir, "xmpir_mpf_floor");
    private static IntPtr __ptr__xmpir_mpf_trunc = GetProcAddressSafe(hxmpir, "xmpir_mpf_trunc");
    private static IntPtr __ptr__xmpir_mpf_integer_p = GetProcAddressSafe(hxmpir, "xmpir_mpf_integer_p");
    private static IntPtr __ptr__xmpir_mpf_fits_uint_p = GetProcAddressSafe(hxmpir, "xmpir_mpf_fits_uint_p");
    private static IntPtr __ptr__xmpir_mpf_fits_sint_p = GetProcAddressSafe(hxmpir, "xmpir_mpf_fits_sint_p");
    private static IntPtr __ptr__xmpir_mpf_urandomb = GetProcAddressSafe(hxmpir, "xmpir_mpf_urandomb");
    private static IntPtr __ptr__xmpir_mpf_rrandomb = GetProcAddressSafe(hxmpir, "xmpir_mpf_rrandomb");



    //
    // Automatically generated code: definitions
    //
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init(out IntPtr result);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init2(out IntPtr result, ulong prec);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init_set(out IntPtr result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init_set_ui(out IntPtr result, uint op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init_set_si(out IntPtr result, int op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init_set_d(out IntPtr result, double op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init_set_str(out IntPtr result, IntPtr str, uint _base);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_init(out IntPtr result);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init(out IntPtr result);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init2(out IntPtr result, ulong prec);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init_set(out IntPtr result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init_set_ui(out IntPtr result, uint op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init_set_si(out IntPtr result, int op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init_set_d(out IntPtr result, double op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init_set_str(out IntPtr result, IntPtr str, uint _base);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_clear(IntPtr v);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_clear(IntPtr v);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_clear(IntPtr v);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_xmpir_dummy();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_xmpir_dummy_add(out int result, int a, int b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_xmpir_dummy_3mpz(out int result, IntPtr op0, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randinit_default(out IntPtr result);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randinit_mt(out IntPtr result);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randinit_lc_2exp(out IntPtr result, IntPtr a, uint c, ulong m2exp);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randinit_lc_2exp_size(out IntPtr result, ulong size);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randinit_set(out IntPtr result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randclear(IntPtr v);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randseed(IntPtr state, IntPtr seed);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randseed_ui(IntPtr state, uint seed);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_urandomb_ui(out uint result, IntPtr state, uint n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_urandomm_ui(out uint result, IntPtr state, uint n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_realloc2(IntPtr x, uint n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_default_prec(ulong prec);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_default_prec(out ulong result);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_ui(IntPtr rop, uint op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_si(IntPtr rop, int op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_d(IntPtr rop, double op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_q(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_f(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_str(out int result, IntPtr rop, IntPtr str, uint _base);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_swap(IntPtr rop1, IntPtr rop2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_get_ui(out uint result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_get_si(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_get_d(out double result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_get_d_2exp(out double result, out int expptr, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_get_string(out IntPtr result, uint _base, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_add(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_add_ui(IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sub(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sub_ui(IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_ui_sub(IntPtr rop, uint op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mul(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mul_si(IntPtr rop, IntPtr op1, int op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mul_ui(IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_addmul(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_addmul_ui(IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_submul(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_submul_ui(IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mul_2exp(IntPtr rop, IntPtr op1, ulong op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_neg(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_abs(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_q(IntPtr q, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_r(IntPtr r, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_qr(IntPtr q, IntPtr r, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_q_ui(out uint result, IntPtr q, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_r_ui(out uint result, IntPtr r, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_qr_ui(out uint result, IntPtr q, IntPtr r, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_ui(out uint result, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_q_2exp(IntPtr q, IntPtr n, ulong b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_r_2exp(IntPtr r, IntPtr n, ulong b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_q(IntPtr q, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_r(IntPtr r, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_qr(IntPtr q, IntPtr r, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_q_ui(out uint result, IntPtr q, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_r_ui(out uint result, IntPtr r, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_qr_ui(out uint result, IntPtr q, IntPtr r, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_ui(out uint result, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_q_2exp(IntPtr q, IntPtr n, ulong b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_r_2exp(IntPtr r, IntPtr n, ulong b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_q(IntPtr q, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_r(IntPtr r, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_qr(IntPtr q, IntPtr r, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_q_ui(out uint result, IntPtr q, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_r_ui(out uint result, IntPtr r, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_qr_ui(out uint result, IntPtr q, IntPtr r, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_ui(out uint result, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_q_2exp(IntPtr q, IntPtr n, ulong b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_r_2exp(IntPtr r, IntPtr n, ulong b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mod(IntPtr r, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mod_ui(out uint result, IntPtr r, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_divexact(IntPtr q, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_divexact_ui(IntPtr q, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_divisible_p(out int result, IntPtr n, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_divisible_ui_p(out int result, IntPtr n, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_divisible_2exp_p(out int result, IntPtr n, ulong b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_congruent_p(out int result, IntPtr n, IntPtr c, IntPtr d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_congruent_ui_p(out int result, IntPtr n, uint c, uint d);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_congruent_2exp_p(out int result, IntPtr n, IntPtr c, ulong b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_powm(IntPtr rop, IntPtr _base, IntPtr _exp, IntPtr _mod);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_powm_ui(IntPtr rop, IntPtr _base, uint _exp, IntPtr _mod);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_pow_ui(IntPtr rop, IntPtr _base, uint _exp);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_ui_pow_ui(IntPtr rop, uint _base, uint _exp);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_root(out int result, IntPtr rop, IntPtr op, uint n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_nthroot(IntPtr rop, IntPtr op, uint n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_rootrem(IntPtr root, IntPtr rem, IntPtr u, uint n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sqrt(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sqrtrem(IntPtr rop1, IntPtr rop2, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_perfect_power_p(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_perfect_square_p(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_probable_prime_p(out int result, IntPtr n, IntPtr state, int prob, uint div);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_likely_prime_p(out int result, IntPtr n, IntPtr state, uint div);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_probab_prime_p(out int result, IntPtr n, uint reps);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_nextprime(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_next_prime_candidate(IntPtr rop, IntPtr op, IntPtr state);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_gcd(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_gcd_ui(out uint result, IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_gcdext(IntPtr g, IntPtr s, IntPtr t, IntPtr a, IntPtr b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_lcm(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_lcm_ui(IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_invert(out int result, IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_jacobi(out int result, IntPtr a, IntPtr b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_legendre(out int result, IntPtr a, IntPtr p);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_kronecker(out int result, IntPtr a, IntPtr b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_kronecker_si(out int result, IntPtr a, int b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_kronecker_ui(out int result, IntPtr a, uint b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_si_kronecker(out int result, int a, IntPtr b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_ui_kronecker(out int result, uint a, IntPtr b);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_remove(out ulong result, IntPtr rop, IntPtr op, IntPtr f);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fac_ui(IntPtr rop, uint op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_2fac_ui(IntPtr rop, uint op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mfac_uiui(IntPtr rop, uint op, uint m);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_primorial_ui(IntPtr rop, uint op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_bin_ui(IntPtr rop, IntPtr n, uint k);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_bin_uiui(IntPtr rop, uint n, uint k);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fib_ui(IntPtr fn, uint n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fib2_ui(IntPtr fn, IntPtr fnsub1, uint n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_lucnum_ui(IntPtr ln, uint n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_lucnum2_ui(IntPtr ln, IntPtr lnsub1, uint n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmp(out int result, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmp_d(out int result, IntPtr op1, double op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmp_si(out int result, IntPtr op1, int op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmp_ui(out int result, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmpabs(out int result, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmpabs_d(out int result, IntPtr op1, double op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmpabs_ui(out int result, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sgn(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_and(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_ior(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_xor(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_com(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_popcount(out ulong result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_hamdist(out ulong result, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_scan0(out ulong result, IntPtr op, ulong starting_bit);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_scan1(out ulong result, IntPtr op, ulong starting_bit);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_setbit(IntPtr rop, ulong bit_index);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_clrbit(IntPtr rop, ulong bit_index);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_combit(IntPtr rop, ulong bit_index);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tstbit(out int result, IntPtr op, ulong bit_index);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_urandomb(IntPtr rop, IntPtr state, ulong n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_urandomm(IntPtr rop, IntPtr state, IntPtr n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_rrandomb(IntPtr rop, IntPtr state, ulong n);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fits_uint_p(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fits_sint_p(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_odd_p(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_even_p(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sizeinbase(out ulong result, IntPtr op, uint _base);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_canonicalize(IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_z(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_ui(IntPtr rop, uint op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_si(IntPtr rop, int op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_str(out int result, IntPtr rop, IntPtr str, uint _base);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_swap(IntPtr rop1, IntPtr rop2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_get_d(out double result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_d(IntPtr rop, double op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_f(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_get_string(out IntPtr result, uint _base, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_add(IntPtr sum, IntPtr addend1, IntPtr addend2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_sub(IntPtr difference, IntPtr minuend, IntPtr subtrahend);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_mul(IntPtr product, IntPtr multiplier, IntPtr multiplicand);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_mul_2exp(IntPtr rop, IntPtr op1, ulong op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_div(IntPtr quotient, IntPtr dividend, IntPtr divisor);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_div_2exp(IntPtr rop, IntPtr op1, ulong op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_neg(IntPtr negated_operand, IntPtr operand);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_abs(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_inv(IntPtr inverted_number, IntPtr number);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_cmp(out int result, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_cmp_ui(out int result, IntPtr op1, uint num2, uint den2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_cmp_si(out int result, IntPtr op1, int num2, uint den2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_sgn(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_equal(out int result, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_get_num(IntPtr numerator, IntPtr rational);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_get_den(IntPtr denominator, IntPtr rational);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_num(IntPtr rational, IntPtr numerator);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_den(IntPtr rational, IntPtr denominator);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_prec(out ulong result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_prec(IntPtr rop, ulong prec);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_ui(IntPtr rop, uint op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_si(IntPtr rop, int op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_d(IntPtr rop, double op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_z(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_q(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_str(out int result, IntPtr rop, IntPtr str, uint _base);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_swap(IntPtr rop1, IntPtr rop2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_d(out double result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_d_2exp(out double result, out int expptr, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_si(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_ui(out uint result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_string(out IntPtr result, out long expptr, uint _base, uint n_digits, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_add(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_add_ui(IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_sub(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_ui_sub(IntPtr rop, uint op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_sub_ui(IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_mul(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_mul_ui(IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_div(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_ui_div(IntPtr rop, uint op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_div_ui(IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_sqrt(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_sqrt_ui(IntPtr rop, uint op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_pow_ui(IntPtr rop, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_neg(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_abs(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_mul_2exp(IntPtr rop, IntPtr op1, ulong op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_div_2exp(IntPtr rop, IntPtr op1, ulong op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_cmp(out int result, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_cmp_d(out int result, IntPtr op1, double op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_cmp_ui(out int result, IntPtr op1, uint op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_cmp_si(out int result, IntPtr op1, int op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_eq(out int result, IntPtr op1, IntPtr op2, ulong op3);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_reldiff(IntPtr rop, IntPtr op1, IntPtr op2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_sgn(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_ceil(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_floor(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_trunc(IntPtr rop, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_integer_p(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_fits_uint_p(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_fits_sint_p(out int result, IntPtr op);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_urandomb(IntPtr rop, IntPtr state, ulong nbits);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_rrandomb(IntPtr rop, IntPtr state, long max_size, long exp);



    //
    // Automatically generated code: delegates
    //
    private static __xmpir_mpz_init xmpir_mpz_init = (__xmpir_mpz_init)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_init, typeof(__xmpir_mpz_init));
    private static __xmpir_mpz_init2 xmpir_mpz_init2 = (__xmpir_mpz_init2)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_init2, typeof(__xmpir_mpz_init2));
    private static __xmpir_mpz_init_set xmpir_mpz_init_set = (__xmpir_mpz_init_set)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_init_set, typeof(__xmpir_mpz_init_set));
    private static __xmpir_mpz_init_set_ui xmpir_mpz_init_set_ui = (__xmpir_mpz_init_set_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_init_set_ui, typeof(__xmpir_mpz_init_set_ui));
    private static __xmpir_mpz_init_set_si xmpir_mpz_init_set_si = (__xmpir_mpz_init_set_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_init_set_si, typeof(__xmpir_mpz_init_set_si));
    private static __xmpir_mpz_init_set_d xmpir_mpz_init_set_d = (__xmpir_mpz_init_set_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_init_set_d, typeof(__xmpir_mpz_init_set_d));
    private static __xmpir_mpz_init_set_str xmpir_mpz_init_set_str = (__xmpir_mpz_init_set_str)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_init_set_str, typeof(__xmpir_mpz_init_set_str));
    private static __xmpir_mpq_init xmpir_mpq_init = (__xmpir_mpq_init)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_init, typeof(__xmpir_mpq_init));
    private static __xmpir_mpf_init xmpir_mpf_init = (__xmpir_mpf_init)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_init, typeof(__xmpir_mpf_init));
    private static __xmpir_mpf_init2 xmpir_mpf_init2 = (__xmpir_mpf_init2)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_init2, typeof(__xmpir_mpf_init2));
    private static __xmpir_mpf_init_set xmpir_mpf_init_set = (__xmpir_mpf_init_set)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_init_set, typeof(__xmpir_mpf_init_set));
    private static __xmpir_mpf_init_set_ui xmpir_mpf_init_set_ui = (__xmpir_mpf_init_set_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_init_set_ui, typeof(__xmpir_mpf_init_set_ui));
    private static __xmpir_mpf_init_set_si xmpir_mpf_init_set_si = (__xmpir_mpf_init_set_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_init_set_si, typeof(__xmpir_mpf_init_set_si));
    private static __xmpir_mpf_init_set_d xmpir_mpf_init_set_d = (__xmpir_mpf_init_set_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_init_set_d, typeof(__xmpir_mpf_init_set_d));
    private static __xmpir_mpf_init_set_str xmpir_mpf_init_set_str = (__xmpir_mpf_init_set_str)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_init_set_str, typeof(__xmpir_mpf_init_set_str));
    private static __xmpir_mpz_clear xmpir_mpz_clear = (__xmpir_mpz_clear)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_clear, typeof(__xmpir_mpz_clear));
    private static __xmpir_mpq_clear xmpir_mpq_clear = (__xmpir_mpq_clear)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_clear, typeof(__xmpir_mpq_clear));
    private static __xmpir_mpf_clear xmpir_mpf_clear = (__xmpir_mpf_clear)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_clear, typeof(__xmpir_mpf_clear));
    private static __xmpir_xmpir_dummy xmpir_xmpir_dummy = (__xmpir_xmpir_dummy)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_xmpir_dummy, typeof(__xmpir_xmpir_dummy));
    private static __xmpir_xmpir_dummy_add xmpir_xmpir_dummy_add = (__xmpir_xmpir_dummy_add)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_xmpir_dummy_add, typeof(__xmpir_xmpir_dummy_add));
    private static __xmpir_xmpir_dummy_3mpz xmpir_xmpir_dummy_3mpz = (__xmpir_xmpir_dummy_3mpz)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_xmpir_dummy_3mpz, typeof(__xmpir_xmpir_dummy_3mpz));
    private static __xmpir_gmp_randinit_default xmpir_gmp_randinit_default = (__xmpir_gmp_randinit_default)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_gmp_randinit_default, typeof(__xmpir_gmp_randinit_default));
    private static __xmpir_gmp_randinit_mt xmpir_gmp_randinit_mt = (__xmpir_gmp_randinit_mt)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_gmp_randinit_mt, typeof(__xmpir_gmp_randinit_mt));
    private static __xmpir_gmp_randinit_lc_2exp xmpir_gmp_randinit_lc_2exp = (__xmpir_gmp_randinit_lc_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_gmp_randinit_lc_2exp, typeof(__xmpir_gmp_randinit_lc_2exp));
    private static __xmpir_gmp_randinit_lc_2exp_size xmpir_gmp_randinit_lc_2exp_size = (__xmpir_gmp_randinit_lc_2exp_size)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_gmp_randinit_lc_2exp_size, typeof(__xmpir_gmp_randinit_lc_2exp_size));
    private static __xmpir_gmp_randinit_set xmpir_gmp_randinit_set = (__xmpir_gmp_randinit_set)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_gmp_randinit_set, typeof(__xmpir_gmp_randinit_set));
    private static __xmpir_gmp_randclear xmpir_gmp_randclear = (__xmpir_gmp_randclear)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_gmp_randclear, typeof(__xmpir_gmp_randclear));
    private static __xmpir_gmp_randseed xmpir_gmp_randseed = (__xmpir_gmp_randseed)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_gmp_randseed, typeof(__xmpir_gmp_randseed));
    private static __xmpir_gmp_randseed_ui xmpir_gmp_randseed_ui = (__xmpir_gmp_randseed_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_gmp_randseed_ui, typeof(__xmpir_gmp_randseed_ui));
    private static __xmpir_gmp_urandomb_ui xmpir_gmp_urandomb_ui = (__xmpir_gmp_urandomb_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_gmp_urandomb_ui, typeof(__xmpir_gmp_urandomb_ui));
    private static __xmpir_gmp_urandomm_ui xmpir_gmp_urandomm_ui = (__xmpir_gmp_urandomm_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_gmp_urandomm_ui, typeof(__xmpir_gmp_urandomm_ui));
    private static __xmpir_mpz_realloc2 xmpir_mpz_realloc2 = (__xmpir_mpz_realloc2)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_realloc2, typeof(__xmpir_mpz_realloc2));
    private static __xmpir_mpf_set_default_prec xmpir_mpf_set_default_prec = (__xmpir_mpf_set_default_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set_default_prec, typeof(__xmpir_mpf_set_default_prec));
    private static __xmpir_mpf_get_default_prec xmpir_mpf_get_default_prec = (__xmpir_mpf_get_default_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_get_default_prec, typeof(__xmpir_mpf_get_default_prec));
    private static __xmpir_mpz_set xmpir_mpz_set = (__xmpir_mpz_set)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_set, typeof(__xmpir_mpz_set));
    private static __xmpir_mpz_set_ui xmpir_mpz_set_ui = (__xmpir_mpz_set_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_set_ui, typeof(__xmpir_mpz_set_ui));
    private static __xmpir_mpz_set_si xmpir_mpz_set_si = (__xmpir_mpz_set_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_set_si, typeof(__xmpir_mpz_set_si));
    private static __xmpir_mpz_set_d xmpir_mpz_set_d = (__xmpir_mpz_set_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_set_d, typeof(__xmpir_mpz_set_d));
    private static __xmpir_mpz_set_q xmpir_mpz_set_q = (__xmpir_mpz_set_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_set_q, typeof(__xmpir_mpz_set_q));
    private static __xmpir_mpz_set_f xmpir_mpz_set_f = (__xmpir_mpz_set_f)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_set_f, typeof(__xmpir_mpz_set_f));
    private static __xmpir_mpz_set_str xmpir_mpz_set_str = (__xmpir_mpz_set_str)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_set_str, typeof(__xmpir_mpz_set_str));
    private static __xmpir_mpz_swap xmpir_mpz_swap = (__xmpir_mpz_swap)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_swap, typeof(__xmpir_mpz_swap));
    private static __xmpir_mpz_get_ui xmpir_mpz_get_ui = (__xmpir_mpz_get_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_get_ui, typeof(__xmpir_mpz_get_ui));
    private static __xmpir_mpz_get_si xmpir_mpz_get_si = (__xmpir_mpz_get_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_get_si, typeof(__xmpir_mpz_get_si));
    private static __xmpir_mpz_get_d xmpir_mpz_get_d = (__xmpir_mpz_get_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_get_d, typeof(__xmpir_mpz_get_d));
    private static __xmpir_mpz_get_d_2exp xmpir_mpz_get_d_2exp = (__xmpir_mpz_get_d_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_get_d_2exp, typeof(__xmpir_mpz_get_d_2exp));
    private static __xmpir_mpz_get_string xmpir_mpz_get_string = (__xmpir_mpz_get_string)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_get_string, typeof(__xmpir_mpz_get_string));
    private static __xmpir_mpz_add xmpir_mpz_add = (__xmpir_mpz_add)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_add, typeof(__xmpir_mpz_add));
    private static __xmpir_mpz_add_ui xmpir_mpz_add_ui = (__xmpir_mpz_add_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_add_ui, typeof(__xmpir_mpz_add_ui));
    private static __xmpir_mpz_sub xmpir_mpz_sub = (__xmpir_mpz_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_sub, typeof(__xmpir_mpz_sub));
    private static __xmpir_mpz_sub_ui xmpir_mpz_sub_ui = (__xmpir_mpz_sub_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_sub_ui, typeof(__xmpir_mpz_sub_ui));
    private static __xmpir_mpz_ui_sub xmpir_mpz_ui_sub = (__xmpir_mpz_ui_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_ui_sub, typeof(__xmpir_mpz_ui_sub));
    private static __xmpir_mpz_mul xmpir_mpz_mul = (__xmpir_mpz_mul)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_mul, typeof(__xmpir_mpz_mul));
    private static __xmpir_mpz_mul_si xmpir_mpz_mul_si = (__xmpir_mpz_mul_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_mul_si, typeof(__xmpir_mpz_mul_si));
    private static __xmpir_mpz_mul_ui xmpir_mpz_mul_ui = (__xmpir_mpz_mul_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_mul_ui, typeof(__xmpir_mpz_mul_ui));
    private static __xmpir_mpz_addmul xmpir_mpz_addmul = (__xmpir_mpz_addmul)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_addmul, typeof(__xmpir_mpz_addmul));
    private static __xmpir_mpz_addmul_ui xmpir_mpz_addmul_ui = (__xmpir_mpz_addmul_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_addmul_ui, typeof(__xmpir_mpz_addmul_ui));
    private static __xmpir_mpz_submul xmpir_mpz_submul = (__xmpir_mpz_submul)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_submul, typeof(__xmpir_mpz_submul));
    private static __xmpir_mpz_submul_ui xmpir_mpz_submul_ui = (__xmpir_mpz_submul_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_submul_ui, typeof(__xmpir_mpz_submul_ui));
    private static __xmpir_mpz_mul_2exp xmpir_mpz_mul_2exp = (__xmpir_mpz_mul_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_mul_2exp, typeof(__xmpir_mpz_mul_2exp));
    private static __xmpir_mpz_neg xmpir_mpz_neg = (__xmpir_mpz_neg)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_neg, typeof(__xmpir_mpz_neg));
    private static __xmpir_mpz_abs xmpir_mpz_abs = (__xmpir_mpz_abs)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_abs, typeof(__xmpir_mpz_abs));
    private static __xmpir_mpz_cdiv_q xmpir_mpz_cdiv_q = (__xmpir_mpz_cdiv_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cdiv_q, typeof(__xmpir_mpz_cdiv_q));
    private static __xmpir_mpz_cdiv_r xmpir_mpz_cdiv_r = (__xmpir_mpz_cdiv_r)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cdiv_r, typeof(__xmpir_mpz_cdiv_r));
    private static __xmpir_mpz_cdiv_qr xmpir_mpz_cdiv_qr = (__xmpir_mpz_cdiv_qr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cdiv_qr, typeof(__xmpir_mpz_cdiv_qr));
    private static __xmpir_mpz_cdiv_q_ui xmpir_mpz_cdiv_q_ui = (__xmpir_mpz_cdiv_q_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cdiv_q_ui, typeof(__xmpir_mpz_cdiv_q_ui));
    private static __xmpir_mpz_cdiv_r_ui xmpir_mpz_cdiv_r_ui = (__xmpir_mpz_cdiv_r_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cdiv_r_ui, typeof(__xmpir_mpz_cdiv_r_ui));
    private static __xmpir_mpz_cdiv_qr_ui xmpir_mpz_cdiv_qr_ui = (__xmpir_mpz_cdiv_qr_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cdiv_qr_ui, typeof(__xmpir_mpz_cdiv_qr_ui));
    private static __xmpir_mpz_cdiv_ui xmpir_mpz_cdiv_ui = (__xmpir_mpz_cdiv_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cdiv_ui, typeof(__xmpir_mpz_cdiv_ui));
    private static __xmpir_mpz_cdiv_q_2exp xmpir_mpz_cdiv_q_2exp = (__xmpir_mpz_cdiv_q_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cdiv_q_2exp, typeof(__xmpir_mpz_cdiv_q_2exp));
    private static __xmpir_mpz_cdiv_r_2exp xmpir_mpz_cdiv_r_2exp = (__xmpir_mpz_cdiv_r_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cdiv_r_2exp, typeof(__xmpir_mpz_cdiv_r_2exp));
    private static __xmpir_mpz_fdiv_q xmpir_mpz_fdiv_q = (__xmpir_mpz_fdiv_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fdiv_q, typeof(__xmpir_mpz_fdiv_q));
    private static __xmpir_mpz_fdiv_r xmpir_mpz_fdiv_r = (__xmpir_mpz_fdiv_r)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fdiv_r, typeof(__xmpir_mpz_fdiv_r));
    private static __xmpir_mpz_fdiv_qr xmpir_mpz_fdiv_qr = (__xmpir_mpz_fdiv_qr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fdiv_qr, typeof(__xmpir_mpz_fdiv_qr));
    private static __xmpir_mpz_fdiv_q_ui xmpir_mpz_fdiv_q_ui = (__xmpir_mpz_fdiv_q_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fdiv_q_ui, typeof(__xmpir_mpz_fdiv_q_ui));
    private static __xmpir_mpz_fdiv_r_ui xmpir_mpz_fdiv_r_ui = (__xmpir_mpz_fdiv_r_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fdiv_r_ui, typeof(__xmpir_mpz_fdiv_r_ui));
    private static __xmpir_mpz_fdiv_qr_ui xmpir_mpz_fdiv_qr_ui = (__xmpir_mpz_fdiv_qr_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fdiv_qr_ui, typeof(__xmpir_mpz_fdiv_qr_ui));
    private static __xmpir_mpz_fdiv_ui xmpir_mpz_fdiv_ui = (__xmpir_mpz_fdiv_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fdiv_ui, typeof(__xmpir_mpz_fdiv_ui));
    private static __xmpir_mpz_fdiv_q_2exp xmpir_mpz_fdiv_q_2exp = (__xmpir_mpz_fdiv_q_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fdiv_q_2exp, typeof(__xmpir_mpz_fdiv_q_2exp));
    private static __xmpir_mpz_fdiv_r_2exp xmpir_mpz_fdiv_r_2exp = (__xmpir_mpz_fdiv_r_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fdiv_r_2exp, typeof(__xmpir_mpz_fdiv_r_2exp));
    private static __xmpir_mpz_tdiv_q xmpir_mpz_tdiv_q = (__xmpir_mpz_tdiv_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_tdiv_q, typeof(__xmpir_mpz_tdiv_q));
    private static __xmpir_mpz_tdiv_r xmpir_mpz_tdiv_r = (__xmpir_mpz_tdiv_r)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_tdiv_r, typeof(__xmpir_mpz_tdiv_r));
    private static __xmpir_mpz_tdiv_qr xmpir_mpz_tdiv_qr = (__xmpir_mpz_tdiv_qr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_tdiv_qr, typeof(__xmpir_mpz_tdiv_qr));
    private static __xmpir_mpz_tdiv_q_ui xmpir_mpz_tdiv_q_ui = (__xmpir_mpz_tdiv_q_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_tdiv_q_ui, typeof(__xmpir_mpz_tdiv_q_ui));
    private static __xmpir_mpz_tdiv_r_ui xmpir_mpz_tdiv_r_ui = (__xmpir_mpz_tdiv_r_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_tdiv_r_ui, typeof(__xmpir_mpz_tdiv_r_ui));
    private static __xmpir_mpz_tdiv_qr_ui xmpir_mpz_tdiv_qr_ui = (__xmpir_mpz_tdiv_qr_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_tdiv_qr_ui, typeof(__xmpir_mpz_tdiv_qr_ui));
    private static __xmpir_mpz_tdiv_ui xmpir_mpz_tdiv_ui = (__xmpir_mpz_tdiv_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_tdiv_ui, typeof(__xmpir_mpz_tdiv_ui));
    private static __xmpir_mpz_tdiv_q_2exp xmpir_mpz_tdiv_q_2exp = (__xmpir_mpz_tdiv_q_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_tdiv_q_2exp, typeof(__xmpir_mpz_tdiv_q_2exp));
    private static __xmpir_mpz_tdiv_r_2exp xmpir_mpz_tdiv_r_2exp = (__xmpir_mpz_tdiv_r_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_tdiv_r_2exp, typeof(__xmpir_mpz_tdiv_r_2exp));
    private static __xmpir_mpz_mod xmpir_mpz_mod = (__xmpir_mpz_mod)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_mod, typeof(__xmpir_mpz_mod));
    private static __xmpir_mpz_mod_ui xmpir_mpz_mod_ui = (__xmpir_mpz_mod_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_mod_ui, typeof(__xmpir_mpz_mod_ui));
    private static __xmpir_mpz_divexact xmpir_mpz_divexact = (__xmpir_mpz_divexact)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_divexact, typeof(__xmpir_mpz_divexact));
    private static __xmpir_mpz_divexact_ui xmpir_mpz_divexact_ui = (__xmpir_mpz_divexact_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_divexact_ui, typeof(__xmpir_mpz_divexact_ui));
    private static __xmpir_mpz_divisible_p xmpir_mpz_divisible_p = (__xmpir_mpz_divisible_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_divisible_p, typeof(__xmpir_mpz_divisible_p));
    private static __xmpir_mpz_divisible_ui_p xmpir_mpz_divisible_ui_p = (__xmpir_mpz_divisible_ui_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_divisible_ui_p, typeof(__xmpir_mpz_divisible_ui_p));
    private static __xmpir_mpz_divisible_2exp_p xmpir_mpz_divisible_2exp_p = (__xmpir_mpz_divisible_2exp_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_divisible_2exp_p, typeof(__xmpir_mpz_divisible_2exp_p));
    private static __xmpir_mpz_congruent_p xmpir_mpz_congruent_p = (__xmpir_mpz_congruent_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_congruent_p, typeof(__xmpir_mpz_congruent_p));
    private static __xmpir_mpz_congruent_ui_p xmpir_mpz_congruent_ui_p = (__xmpir_mpz_congruent_ui_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_congruent_ui_p, typeof(__xmpir_mpz_congruent_ui_p));
    private static __xmpir_mpz_congruent_2exp_p xmpir_mpz_congruent_2exp_p = (__xmpir_mpz_congruent_2exp_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_congruent_2exp_p, typeof(__xmpir_mpz_congruent_2exp_p));
    private static __xmpir_mpz_powm xmpir_mpz_powm = (__xmpir_mpz_powm)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_powm, typeof(__xmpir_mpz_powm));
    private static __xmpir_mpz_powm_ui xmpir_mpz_powm_ui = (__xmpir_mpz_powm_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_powm_ui, typeof(__xmpir_mpz_powm_ui));
    private static __xmpir_mpz_pow_ui xmpir_mpz_pow_ui = (__xmpir_mpz_pow_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_pow_ui, typeof(__xmpir_mpz_pow_ui));
    private static __xmpir_mpz_ui_pow_ui xmpir_mpz_ui_pow_ui = (__xmpir_mpz_ui_pow_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_ui_pow_ui, typeof(__xmpir_mpz_ui_pow_ui));
    private static __xmpir_mpz_root xmpir_mpz_root = (__xmpir_mpz_root)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_root, typeof(__xmpir_mpz_root));
    private static __xmpir_mpz_nthroot xmpir_mpz_nthroot = (__xmpir_mpz_nthroot)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_nthroot, typeof(__xmpir_mpz_nthroot));
    private static __xmpir_mpz_rootrem xmpir_mpz_rootrem = (__xmpir_mpz_rootrem)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_rootrem, typeof(__xmpir_mpz_rootrem));
    private static __xmpir_mpz_sqrt xmpir_mpz_sqrt = (__xmpir_mpz_sqrt)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_sqrt, typeof(__xmpir_mpz_sqrt));
    private static __xmpir_mpz_sqrtrem xmpir_mpz_sqrtrem = (__xmpir_mpz_sqrtrem)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_sqrtrem, typeof(__xmpir_mpz_sqrtrem));
    private static __xmpir_mpz_perfect_power_p xmpir_mpz_perfect_power_p = (__xmpir_mpz_perfect_power_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_perfect_power_p, typeof(__xmpir_mpz_perfect_power_p));
    private static __xmpir_mpz_perfect_square_p xmpir_mpz_perfect_square_p = (__xmpir_mpz_perfect_square_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_perfect_square_p, typeof(__xmpir_mpz_perfect_square_p));
    private static __xmpir_mpz_probable_prime_p xmpir_mpz_probable_prime_p = (__xmpir_mpz_probable_prime_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_probable_prime_p, typeof(__xmpir_mpz_probable_prime_p));
    private static __xmpir_mpz_likely_prime_p xmpir_mpz_likely_prime_p = (__xmpir_mpz_likely_prime_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_likely_prime_p, typeof(__xmpir_mpz_likely_prime_p));
    private static __xmpir_mpz_probab_prime_p xmpir_mpz_probab_prime_p = (__xmpir_mpz_probab_prime_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_probab_prime_p, typeof(__xmpir_mpz_probab_prime_p));
    private static __xmpir_mpz_nextprime xmpir_mpz_nextprime = (__xmpir_mpz_nextprime)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_nextprime, typeof(__xmpir_mpz_nextprime));
    private static __xmpir_mpz_next_prime_candidate xmpir_mpz_next_prime_candidate = (__xmpir_mpz_next_prime_candidate)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_next_prime_candidate, typeof(__xmpir_mpz_next_prime_candidate));
    private static __xmpir_mpz_gcd xmpir_mpz_gcd = (__xmpir_mpz_gcd)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_gcd, typeof(__xmpir_mpz_gcd));
    private static __xmpir_mpz_gcd_ui xmpir_mpz_gcd_ui = (__xmpir_mpz_gcd_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_gcd_ui, typeof(__xmpir_mpz_gcd_ui));
    private static __xmpir_mpz_gcdext xmpir_mpz_gcdext = (__xmpir_mpz_gcdext)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_gcdext, typeof(__xmpir_mpz_gcdext));
    private static __xmpir_mpz_lcm xmpir_mpz_lcm = (__xmpir_mpz_lcm)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_lcm, typeof(__xmpir_mpz_lcm));
    private static __xmpir_mpz_lcm_ui xmpir_mpz_lcm_ui = (__xmpir_mpz_lcm_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_lcm_ui, typeof(__xmpir_mpz_lcm_ui));
    private static __xmpir_mpz_invert xmpir_mpz_invert = (__xmpir_mpz_invert)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_invert, typeof(__xmpir_mpz_invert));
    private static __xmpir_mpz_jacobi xmpir_mpz_jacobi = (__xmpir_mpz_jacobi)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_jacobi, typeof(__xmpir_mpz_jacobi));
    private static __xmpir_mpz_legendre xmpir_mpz_legendre = (__xmpir_mpz_legendre)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_legendre, typeof(__xmpir_mpz_legendre));
    private static __xmpir_mpz_kronecker xmpir_mpz_kronecker = (__xmpir_mpz_kronecker)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_kronecker, typeof(__xmpir_mpz_kronecker));
    private static __xmpir_mpz_kronecker_si xmpir_mpz_kronecker_si = (__xmpir_mpz_kronecker_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_kronecker_si, typeof(__xmpir_mpz_kronecker_si));
    private static __xmpir_mpz_kronecker_ui xmpir_mpz_kronecker_ui = (__xmpir_mpz_kronecker_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_kronecker_ui, typeof(__xmpir_mpz_kronecker_ui));
    private static __xmpir_mpz_si_kronecker xmpir_mpz_si_kronecker = (__xmpir_mpz_si_kronecker)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_si_kronecker, typeof(__xmpir_mpz_si_kronecker));
    private static __xmpir_mpz_ui_kronecker xmpir_mpz_ui_kronecker = (__xmpir_mpz_ui_kronecker)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_ui_kronecker, typeof(__xmpir_mpz_ui_kronecker));
    private static __xmpir_mpz_remove xmpir_mpz_remove = (__xmpir_mpz_remove)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_remove, typeof(__xmpir_mpz_remove));
    private static __xmpir_mpz_fac_ui xmpir_mpz_fac_ui = (__xmpir_mpz_fac_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fac_ui, typeof(__xmpir_mpz_fac_ui));
    private static __xmpir_mpz_2fac_ui xmpir_mpz_2fac_ui = (__xmpir_mpz_2fac_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_2fac_ui, typeof(__xmpir_mpz_2fac_ui));
    private static __xmpir_mpz_mfac_uiui xmpir_mpz_mfac_uiui = (__xmpir_mpz_mfac_uiui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_mfac_uiui, typeof(__xmpir_mpz_mfac_uiui));
    private static __xmpir_mpz_primorial_ui xmpir_mpz_primorial_ui = (__xmpir_mpz_primorial_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_primorial_ui, typeof(__xmpir_mpz_primorial_ui));
    private static __xmpir_mpz_bin_ui xmpir_mpz_bin_ui = (__xmpir_mpz_bin_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_bin_ui, typeof(__xmpir_mpz_bin_ui));
    private static __xmpir_mpz_bin_uiui xmpir_mpz_bin_uiui = (__xmpir_mpz_bin_uiui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_bin_uiui, typeof(__xmpir_mpz_bin_uiui));
    private static __xmpir_mpz_fib_ui xmpir_mpz_fib_ui = (__xmpir_mpz_fib_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fib_ui, typeof(__xmpir_mpz_fib_ui));
    private static __xmpir_mpz_fib2_ui xmpir_mpz_fib2_ui = (__xmpir_mpz_fib2_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fib2_ui, typeof(__xmpir_mpz_fib2_ui));
    private static __xmpir_mpz_lucnum_ui xmpir_mpz_lucnum_ui = (__xmpir_mpz_lucnum_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_lucnum_ui, typeof(__xmpir_mpz_lucnum_ui));
    private static __xmpir_mpz_lucnum2_ui xmpir_mpz_lucnum2_ui = (__xmpir_mpz_lucnum2_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_lucnum2_ui, typeof(__xmpir_mpz_lucnum2_ui));
    private static __xmpir_mpz_cmp xmpir_mpz_cmp = (__xmpir_mpz_cmp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cmp, typeof(__xmpir_mpz_cmp));
    private static __xmpir_mpz_cmp_d xmpir_mpz_cmp_d = (__xmpir_mpz_cmp_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cmp_d, typeof(__xmpir_mpz_cmp_d));
    private static __xmpir_mpz_cmp_si xmpir_mpz_cmp_si = (__xmpir_mpz_cmp_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cmp_si, typeof(__xmpir_mpz_cmp_si));
    private static __xmpir_mpz_cmp_ui xmpir_mpz_cmp_ui = (__xmpir_mpz_cmp_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cmp_ui, typeof(__xmpir_mpz_cmp_ui));
    private static __xmpir_mpz_cmpabs xmpir_mpz_cmpabs = (__xmpir_mpz_cmpabs)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cmpabs, typeof(__xmpir_mpz_cmpabs));
    private static __xmpir_mpz_cmpabs_d xmpir_mpz_cmpabs_d = (__xmpir_mpz_cmpabs_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cmpabs_d, typeof(__xmpir_mpz_cmpabs_d));
    private static __xmpir_mpz_cmpabs_ui xmpir_mpz_cmpabs_ui = (__xmpir_mpz_cmpabs_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_cmpabs_ui, typeof(__xmpir_mpz_cmpabs_ui));
    private static __xmpir_mpz_sgn xmpir_mpz_sgn = (__xmpir_mpz_sgn)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_sgn, typeof(__xmpir_mpz_sgn));
    private static __xmpir_mpz_and xmpir_mpz_and = (__xmpir_mpz_and)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_and, typeof(__xmpir_mpz_and));
    private static __xmpir_mpz_ior xmpir_mpz_ior = (__xmpir_mpz_ior)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_ior, typeof(__xmpir_mpz_ior));
    private static __xmpir_mpz_xor xmpir_mpz_xor = (__xmpir_mpz_xor)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_xor, typeof(__xmpir_mpz_xor));
    private static __xmpir_mpz_com xmpir_mpz_com = (__xmpir_mpz_com)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_com, typeof(__xmpir_mpz_com));
    private static __xmpir_mpz_popcount xmpir_mpz_popcount = (__xmpir_mpz_popcount)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_popcount, typeof(__xmpir_mpz_popcount));
    private static __xmpir_mpz_hamdist xmpir_mpz_hamdist = (__xmpir_mpz_hamdist)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_hamdist, typeof(__xmpir_mpz_hamdist));
    private static __xmpir_mpz_scan0 xmpir_mpz_scan0 = (__xmpir_mpz_scan0)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_scan0, typeof(__xmpir_mpz_scan0));
    private static __xmpir_mpz_scan1 xmpir_mpz_scan1 = (__xmpir_mpz_scan1)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_scan1, typeof(__xmpir_mpz_scan1));
    private static __xmpir_mpz_setbit xmpir_mpz_setbit = (__xmpir_mpz_setbit)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_setbit, typeof(__xmpir_mpz_setbit));
    private static __xmpir_mpz_clrbit xmpir_mpz_clrbit = (__xmpir_mpz_clrbit)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_clrbit, typeof(__xmpir_mpz_clrbit));
    private static __xmpir_mpz_combit xmpir_mpz_combit = (__xmpir_mpz_combit)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_combit, typeof(__xmpir_mpz_combit));
    private static __xmpir_mpz_tstbit xmpir_mpz_tstbit = (__xmpir_mpz_tstbit)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_tstbit, typeof(__xmpir_mpz_tstbit));
    private static __xmpir_mpz_urandomb xmpir_mpz_urandomb = (__xmpir_mpz_urandomb)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_urandomb, typeof(__xmpir_mpz_urandomb));
    private static __xmpir_mpz_urandomm xmpir_mpz_urandomm = (__xmpir_mpz_urandomm)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_urandomm, typeof(__xmpir_mpz_urandomm));
    private static __xmpir_mpz_rrandomb xmpir_mpz_rrandomb = (__xmpir_mpz_rrandomb)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_rrandomb, typeof(__xmpir_mpz_rrandomb));
    private static __xmpir_mpz_fits_uint_p xmpir_mpz_fits_uint_p = (__xmpir_mpz_fits_uint_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fits_uint_p, typeof(__xmpir_mpz_fits_uint_p));
    private static __xmpir_mpz_fits_sint_p xmpir_mpz_fits_sint_p = (__xmpir_mpz_fits_sint_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fits_sint_p, typeof(__xmpir_mpz_fits_sint_p));
    private static __xmpir_mpz_odd_p xmpir_mpz_odd_p = (__xmpir_mpz_odd_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_odd_p, typeof(__xmpir_mpz_odd_p));
    private static __xmpir_mpz_even_p xmpir_mpz_even_p = (__xmpir_mpz_even_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_even_p, typeof(__xmpir_mpz_even_p));
    private static __xmpir_mpz_sizeinbase xmpir_mpz_sizeinbase = (__xmpir_mpz_sizeinbase)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_sizeinbase, typeof(__xmpir_mpz_sizeinbase));
    private static __xmpir_mpq_canonicalize xmpir_mpq_canonicalize = (__xmpir_mpq_canonicalize)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_canonicalize, typeof(__xmpir_mpq_canonicalize));
    private static __xmpir_mpq_set xmpir_mpq_set = (__xmpir_mpq_set)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_set, typeof(__xmpir_mpq_set));
    private static __xmpir_mpq_set_z xmpir_mpq_set_z = (__xmpir_mpq_set_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_set_z, typeof(__xmpir_mpq_set_z));
    private static __xmpir_mpq_set_ui xmpir_mpq_set_ui = (__xmpir_mpq_set_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_set_ui, typeof(__xmpir_mpq_set_ui));
    private static __xmpir_mpq_set_si xmpir_mpq_set_si = (__xmpir_mpq_set_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_set_si, typeof(__xmpir_mpq_set_si));
    private static __xmpir_mpq_set_str xmpir_mpq_set_str = (__xmpir_mpq_set_str)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_set_str, typeof(__xmpir_mpq_set_str));
    private static __xmpir_mpq_swap xmpir_mpq_swap = (__xmpir_mpq_swap)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_swap, typeof(__xmpir_mpq_swap));
    private static __xmpir_mpq_get_d xmpir_mpq_get_d = (__xmpir_mpq_get_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_get_d, typeof(__xmpir_mpq_get_d));
    private static __xmpir_mpq_set_d xmpir_mpq_set_d = (__xmpir_mpq_set_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_set_d, typeof(__xmpir_mpq_set_d));
    private static __xmpir_mpq_set_f xmpir_mpq_set_f = (__xmpir_mpq_set_f)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_set_f, typeof(__xmpir_mpq_set_f));
    private static __xmpir_mpq_get_string xmpir_mpq_get_string = (__xmpir_mpq_get_string)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_get_string, typeof(__xmpir_mpq_get_string));
    private static __xmpir_mpq_add xmpir_mpq_add = (__xmpir_mpq_add)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_add, typeof(__xmpir_mpq_add));
    private static __xmpir_mpq_sub xmpir_mpq_sub = (__xmpir_mpq_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_sub, typeof(__xmpir_mpq_sub));
    private static __xmpir_mpq_mul xmpir_mpq_mul = (__xmpir_mpq_mul)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_mul, typeof(__xmpir_mpq_mul));
    private static __xmpir_mpq_mul_2exp xmpir_mpq_mul_2exp = (__xmpir_mpq_mul_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_mul_2exp, typeof(__xmpir_mpq_mul_2exp));
    private static __xmpir_mpq_div xmpir_mpq_div = (__xmpir_mpq_div)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_div, typeof(__xmpir_mpq_div));
    private static __xmpir_mpq_div_2exp xmpir_mpq_div_2exp = (__xmpir_mpq_div_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_div_2exp, typeof(__xmpir_mpq_div_2exp));
    private static __xmpir_mpq_neg xmpir_mpq_neg = (__xmpir_mpq_neg)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_neg, typeof(__xmpir_mpq_neg));
    private static __xmpir_mpq_abs xmpir_mpq_abs = (__xmpir_mpq_abs)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_abs, typeof(__xmpir_mpq_abs));
    private static __xmpir_mpq_inv xmpir_mpq_inv = (__xmpir_mpq_inv)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_inv, typeof(__xmpir_mpq_inv));
    private static __xmpir_mpq_cmp xmpir_mpq_cmp = (__xmpir_mpq_cmp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_cmp, typeof(__xmpir_mpq_cmp));
    private static __xmpir_mpq_cmp_ui xmpir_mpq_cmp_ui = (__xmpir_mpq_cmp_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_cmp_ui, typeof(__xmpir_mpq_cmp_ui));
    private static __xmpir_mpq_cmp_si xmpir_mpq_cmp_si = (__xmpir_mpq_cmp_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_cmp_si, typeof(__xmpir_mpq_cmp_si));
    private static __xmpir_mpq_sgn xmpir_mpq_sgn = (__xmpir_mpq_sgn)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_sgn, typeof(__xmpir_mpq_sgn));
    private static __xmpir_mpq_equal xmpir_mpq_equal = (__xmpir_mpq_equal)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_equal, typeof(__xmpir_mpq_equal));
    private static __xmpir_mpq_get_num xmpir_mpq_get_num = (__xmpir_mpq_get_num)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_get_num, typeof(__xmpir_mpq_get_num));
    private static __xmpir_mpq_get_den xmpir_mpq_get_den = (__xmpir_mpq_get_den)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_get_den, typeof(__xmpir_mpq_get_den));
    private static __xmpir_mpq_set_num xmpir_mpq_set_num = (__xmpir_mpq_set_num)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_set_num, typeof(__xmpir_mpq_set_num));
    private static __xmpir_mpq_set_den xmpir_mpq_set_den = (__xmpir_mpq_set_den)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_set_den, typeof(__xmpir_mpq_set_den));
    private static __xmpir_mpf_get_prec xmpir_mpf_get_prec = (__xmpir_mpf_get_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_get_prec, typeof(__xmpir_mpf_get_prec));
    private static __xmpir_mpf_set_prec xmpir_mpf_set_prec = (__xmpir_mpf_set_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set_prec, typeof(__xmpir_mpf_set_prec));
    private static __xmpir_mpf_set xmpir_mpf_set = (__xmpir_mpf_set)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set, typeof(__xmpir_mpf_set));
    private static __xmpir_mpf_set_ui xmpir_mpf_set_ui = (__xmpir_mpf_set_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set_ui, typeof(__xmpir_mpf_set_ui));
    private static __xmpir_mpf_set_si xmpir_mpf_set_si = (__xmpir_mpf_set_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set_si, typeof(__xmpir_mpf_set_si));
    private static __xmpir_mpf_set_d xmpir_mpf_set_d = (__xmpir_mpf_set_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set_d, typeof(__xmpir_mpf_set_d));
    private static __xmpir_mpf_set_z xmpir_mpf_set_z = (__xmpir_mpf_set_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set_z, typeof(__xmpir_mpf_set_z));
    private static __xmpir_mpf_set_q xmpir_mpf_set_q = (__xmpir_mpf_set_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set_q, typeof(__xmpir_mpf_set_q));
    private static __xmpir_mpf_set_str xmpir_mpf_set_str = (__xmpir_mpf_set_str)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set_str, typeof(__xmpir_mpf_set_str));
    private static __xmpir_mpf_swap xmpir_mpf_swap = (__xmpir_mpf_swap)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_swap, typeof(__xmpir_mpf_swap));
    private static __xmpir_mpf_get_d xmpir_mpf_get_d = (__xmpir_mpf_get_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_get_d, typeof(__xmpir_mpf_get_d));
    private static __xmpir_mpf_get_d_2exp xmpir_mpf_get_d_2exp = (__xmpir_mpf_get_d_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_get_d_2exp, typeof(__xmpir_mpf_get_d_2exp));
    private static __xmpir_mpf_get_si xmpir_mpf_get_si = (__xmpir_mpf_get_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_get_si, typeof(__xmpir_mpf_get_si));
    private static __xmpir_mpf_get_ui xmpir_mpf_get_ui = (__xmpir_mpf_get_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_get_ui, typeof(__xmpir_mpf_get_ui));
    private static __xmpir_mpf_get_string xmpir_mpf_get_string = (__xmpir_mpf_get_string)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_get_string, typeof(__xmpir_mpf_get_string));
    private static __xmpir_mpf_add xmpir_mpf_add = (__xmpir_mpf_add)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_add, typeof(__xmpir_mpf_add));
    private static __xmpir_mpf_add_ui xmpir_mpf_add_ui = (__xmpir_mpf_add_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_add_ui, typeof(__xmpir_mpf_add_ui));
    private static __xmpir_mpf_sub xmpir_mpf_sub = (__xmpir_mpf_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_sub, typeof(__xmpir_mpf_sub));
    private static __xmpir_mpf_ui_sub xmpir_mpf_ui_sub = (__xmpir_mpf_ui_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_ui_sub, typeof(__xmpir_mpf_ui_sub));
    private static __xmpir_mpf_sub_ui xmpir_mpf_sub_ui = (__xmpir_mpf_sub_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_sub_ui, typeof(__xmpir_mpf_sub_ui));
    private static __xmpir_mpf_mul xmpir_mpf_mul = (__xmpir_mpf_mul)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_mul, typeof(__xmpir_mpf_mul));
    private static __xmpir_mpf_mul_ui xmpir_mpf_mul_ui = (__xmpir_mpf_mul_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_mul_ui, typeof(__xmpir_mpf_mul_ui));
    private static __xmpir_mpf_div xmpir_mpf_div = (__xmpir_mpf_div)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_div, typeof(__xmpir_mpf_div));
    private static __xmpir_mpf_ui_div xmpir_mpf_ui_div = (__xmpir_mpf_ui_div)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_ui_div, typeof(__xmpir_mpf_ui_div));
    private static __xmpir_mpf_div_ui xmpir_mpf_div_ui = (__xmpir_mpf_div_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_div_ui, typeof(__xmpir_mpf_div_ui));
    private static __xmpir_mpf_sqrt xmpir_mpf_sqrt = (__xmpir_mpf_sqrt)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_sqrt, typeof(__xmpir_mpf_sqrt));
    private static __xmpir_mpf_sqrt_ui xmpir_mpf_sqrt_ui = (__xmpir_mpf_sqrt_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_sqrt_ui, typeof(__xmpir_mpf_sqrt_ui));
    private static __xmpir_mpf_pow_ui xmpir_mpf_pow_ui = (__xmpir_mpf_pow_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_pow_ui, typeof(__xmpir_mpf_pow_ui));
    private static __xmpir_mpf_neg xmpir_mpf_neg = (__xmpir_mpf_neg)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_neg, typeof(__xmpir_mpf_neg));
    private static __xmpir_mpf_abs xmpir_mpf_abs = (__xmpir_mpf_abs)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_abs, typeof(__xmpir_mpf_abs));
    private static __xmpir_mpf_mul_2exp xmpir_mpf_mul_2exp = (__xmpir_mpf_mul_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_mul_2exp, typeof(__xmpir_mpf_mul_2exp));
    private static __xmpir_mpf_div_2exp xmpir_mpf_div_2exp = (__xmpir_mpf_div_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_div_2exp, typeof(__xmpir_mpf_div_2exp));
    private static __xmpir_mpf_cmp xmpir_mpf_cmp = (__xmpir_mpf_cmp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_cmp, typeof(__xmpir_mpf_cmp));
    private static __xmpir_mpf_cmp_d xmpir_mpf_cmp_d = (__xmpir_mpf_cmp_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_cmp_d, typeof(__xmpir_mpf_cmp_d));
    private static __xmpir_mpf_cmp_ui xmpir_mpf_cmp_ui = (__xmpir_mpf_cmp_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_cmp_ui, typeof(__xmpir_mpf_cmp_ui));
    private static __xmpir_mpf_cmp_si xmpir_mpf_cmp_si = (__xmpir_mpf_cmp_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_cmp_si, typeof(__xmpir_mpf_cmp_si));
    private static __xmpir_mpf_eq xmpir_mpf_eq = (__xmpir_mpf_eq)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_eq, typeof(__xmpir_mpf_eq));
    private static __xmpir_mpf_reldiff xmpir_mpf_reldiff = (__xmpir_mpf_reldiff)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_reldiff, typeof(__xmpir_mpf_reldiff));
    private static __xmpir_mpf_sgn xmpir_mpf_sgn = (__xmpir_mpf_sgn)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_sgn, typeof(__xmpir_mpf_sgn));
    private static __xmpir_mpf_ceil xmpir_mpf_ceil = (__xmpir_mpf_ceil)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_ceil, typeof(__xmpir_mpf_ceil));
    private static __xmpir_mpf_floor xmpir_mpf_floor = (__xmpir_mpf_floor)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_floor, typeof(__xmpir_mpf_floor));
    private static __xmpir_mpf_trunc xmpir_mpf_trunc = (__xmpir_mpf_trunc)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_trunc, typeof(__xmpir_mpf_trunc));
    private static __xmpir_mpf_integer_p xmpir_mpf_integer_p = (__xmpir_mpf_integer_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_integer_p, typeof(__xmpir_mpf_integer_p));
    private static __xmpir_mpf_fits_uint_p xmpir_mpf_fits_uint_p = (__xmpir_mpf_fits_uint_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_fits_uint_p, typeof(__xmpir_mpf_fits_uint_p));
    private static __xmpir_mpf_fits_sint_p xmpir_mpf_fits_sint_p = (__xmpir_mpf_fits_sint_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_fits_sint_p, typeof(__xmpir_mpf_fits_sint_p));
    private static __xmpir_mpf_urandomb xmpir_mpf_urandomb = (__xmpir_mpf_urandomb)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_urandomb, typeof(__xmpir_mpf_urandomb));
    private static __xmpir_mpf_rrandomb xmpir_mpf_rrandomb = (__xmpir_mpf_rrandomb)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_rrandomb, typeof(__xmpir_mpf_rrandomb));

    
    
    //
    // Automatically generated code: functions
    //
    public static mpz_intptr mpz_init()
    {
        int __retval;
        mpz_intptr result;
        __retval= xmpir_mpz_init(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpz_intptr mpz_init2(ulong prec)
    {
        int __retval;
        mpz_intptr result;
        __retval= xmpir_mpz_init2(out result, prec);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpz_intptr mpz_init_set(mpz op)
    {
        int __retval;
        mpz_intptr result;
        __retval= xmpir_mpz_init_set(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpz_intptr mpz_init_set_ui(uint op)
    {
        int __retval;
        mpz_intptr result;
        __retval= xmpir_mpz_init_set_ui(out result, op);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpz_intptr mpz_init_set_si(int op)
    {
        int __retval;
        mpz_intptr result;
        __retval= xmpir_mpz_init_set_si(out result, op);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpz_intptr mpz_init_set_d(double op)
    {
        int __retval;
        mpz_intptr result;
        __retval= xmpir_mpz_init_set_d(out result, op);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpz_intptr mpz_init_set_str(string str, uint _base)
    {
        int __retval;
        mpz_intptr result;
        byte[] __ba_str = System.Text.Encoding.UTF8.GetBytes(str+"\0");
        IntPtr __str;
        __retval = xmpir_malloc(out __str, str.Length+1);
        if( __retval!=0 ) HandleError(__retval);
        Marshal.Copy(__ba_str, 0, __str, str.Length+1);
        __retval= xmpir_mpz_init_set_str(out result, __str, _base);
        if( __retval!=0 ) HandleError(__retval);
       __retval = xmpir_free(__str);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpq_intptr mpq_init()
    {
        int __retval;
        mpq_intptr result;
        __retval= xmpir_mpq_init(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpf_intptr mpf_init()
    {
        int __retval;
        mpf_intptr result;
        __retval= xmpir_mpf_init(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpf_intptr mpf_init2(ulong prec)
    {
        int __retval;
        mpf_intptr result;
        __retval= xmpir_mpf_init2(out result, prec);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpf_intptr mpf_init_set(mpf op)
    {
        int __retval;
        mpf_intptr result;
        __retval= xmpir_mpf_init_set(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpf_intptr mpf_init_set_ui(uint op)
    {
        int __retval;
        mpf_intptr result;
        __retval= xmpir_mpf_init_set_ui(out result, op);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpf_intptr mpf_init_set_si(int op)
    {
        int __retval;
        mpf_intptr result;
        __retval= xmpir_mpf_init_set_si(out result, op);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpf_intptr mpf_init_set_d(double op)
    {
        int __retval;
        mpf_intptr result;
        __retval= xmpir_mpf_init_set_d(out result, op);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpf_intptr mpf_init_set_str(string str, uint _base)
    {
        int __retval;
        mpf_intptr result;
        byte[] __ba_str = System.Text.Encoding.UTF8.GetBytes(str+"\0");
        IntPtr __str;
        __retval = xmpir_malloc(out __str, str.Length+1);
        if( __retval!=0 ) HandleError(__retval);
        Marshal.Copy(__ba_str, 0, __str, str.Length+1);
        __retval= xmpir_mpf_init_set_str(out result, __str, _base);
        if( __retval!=0 ) HandleError(__retval);
       __retval = xmpir_free(__str);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_clear(mpz v)
    {
        int __retval;
        __retval= xmpir_mpz_clear(v.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_clear(mpq v)
    {
        int __retval;
        __retval= xmpir_mpq_clear(v.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_clear(mpf v)
    {
        int __retval;
        __retval= xmpir_mpf_clear(v.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void xmpir_dummy()
    {
        int __retval;
        __retval= xmpir_xmpir_dummy();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int xmpir_dummy_add(int a, int b)
    {
        int __retval;
        int result;
        __retval= xmpir_xmpir_dummy_add(out result, a, b);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int xmpir_dummy_3mpz(mpz op0, mpz op1, mpz op2)
    {
        int __retval;
        int result;
        __retval= xmpir_xmpir_dummy_3mpz(out result, op0.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static gmp_randstate_intptr gmp_randinit_default()
    {
        int __retval;
        gmp_randstate_intptr result;
        __retval= xmpir_gmp_randinit_default(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static gmp_randstate_intptr gmp_randinit_mt()
    {
        int __retval;
        gmp_randstate_intptr result;
        __retval= xmpir_gmp_randinit_mt(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static gmp_randstate_intptr gmp_randinit_lc_2exp(mpz a, uint c, ulong m2exp)
    {
        int __retval;
        gmp_randstate_intptr result;
        __retval= xmpir_gmp_randinit_lc_2exp(out result, a.Val, c, m2exp);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static gmp_randstate_intptr gmp_randinit_lc_2exp_size(ulong size)
    {
        int __retval;
        gmp_randstate_intptr result;
        __retval= xmpir_gmp_randinit_lc_2exp_size(out result, size);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static gmp_randstate_intptr gmp_randinit_set(randstate op)
    {
        int __retval;
        gmp_randstate_intptr result;
        __retval= xmpir_gmp_randinit_set(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void gmp_randclear(randstate v)
    {
        int __retval;
        __retval= xmpir_gmp_randclear(v.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void gmp_randseed(randstate state, mpz seed)
    {
        int __retval;
        __retval= xmpir_gmp_randseed(state.Val, seed.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void gmp_randseed_ui(randstate state, uint seed)
    {
        int __retval;
        __retval= xmpir_gmp_randseed_ui(state.Val, seed);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static uint gmp_urandomb_ui(randstate state, uint n)
    {
        int __retval;
        uint result;
        __retval= xmpir_gmp_urandomb_ui(out result, state.Val, n);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint gmp_urandomm_ui(randstate state, uint n)
    {
        int __retval;
        uint result;
        __retval= xmpir_gmp_urandomm_ui(out result, state.Val, n);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_realloc2(mpz x, uint n)
    {
        int __retval;
        __retval= xmpir_mpz_realloc2(x.Val, n);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_set_default_prec(ulong prec)
    {
        int __retval;
        __retval= xmpir_mpf_set_default_prec(prec);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static ulong mpf_get_default_prec()
    {
        int __retval;
        ulong result;
        __retval= xmpir_mpf_get_default_prec(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_set(mpz rop, mpz op)
    {
        int __retval;
        __retval= xmpir_mpz_set(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_set_ui(mpz rop, uint op)
    {
        int __retval;
        __retval= xmpir_mpz_set_ui(rop.Val, op);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_set_si(mpz rop, int op)
    {
        int __retval;
        __retval= xmpir_mpz_set_si(rop.Val, op);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_set_d(mpz rop, double op)
    {
        int __retval;
        __retval= xmpir_mpz_set_d(rop.Val, op);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_set_q(mpz rop, mpq op)
    {
        int __retval;
        __retval= xmpir_mpz_set_q(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_set_f(mpz rop, mpf op)
    {
        int __retval;
        __retval= xmpir_mpz_set_f(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpz_set_str(mpz rop, string str, uint _base)
    {
        int __retval;
        int result;
        byte[] __ba_str = System.Text.Encoding.UTF8.GetBytes(str+"\0");
        IntPtr __str;
        __retval = xmpir_malloc(out __str, str.Length+1);
        if( __retval!=0 ) HandleError(__retval);
        Marshal.Copy(__ba_str, 0, __str, str.Length+1);
        __retval= xmpir_mpz_set_str(out result, rop.Val, __str, _base);
        if( __retval!=0 ) HandleError(__retval);
       __retval = xmpir_free(__str);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_swap(mpz rop1, mpz rop2)
    {
        int __retval;
        __retval= xmpir_mpz_swap(rop1.Val, rop2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static uint mpz_get_ui(mpz op)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_get_ui(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_get_si(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_get_si(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static double mpz_get_d(mpz op)
    {
        int __retval;
        double result;
        __retval= xmpir_mpz_get_d(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static double mpz_get_d_2exp(out int expptr, mpz op)
    {
        int __retval;
        double result;
        __retval= xmpir_mpz_get_d_2exp(out result, out expptr, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static string mpz_get_string(uint _base, mpz op)
    {
        int __retval;
        string result;
        IntPtr __result;
        __retval= xmpir_mpz_get_string(out __result, _base, op.Val);
        if( __retval!=0 ) HandleError(__retval);
       result = Marshal.PtrToStringAnsi(__result);
       __retval = xmpir_free(__result);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_add(mpz rop, mpz op1, mpz op2)
    {
        int __retval;
        __retval= xmpir_mpz_add(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_add_ui(mpz rop, mpz op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpz_add_ui(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_sub(mpz rop, mpz op1, mpz op2)
    {
        int __retval;
        __retval= xmpir_mpz_sub(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_sub_ui(mpz rop, mpz op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpz_sub_ui(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_ui_sub(mpz rop, uint op1, mpz op2)
    {
        int __retval;
        __retval= xmpir_mpz_ui_sub(rop.Val, op1, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_mul(mpz rop, mpz op1, mpz op2)
    {
        int __retval;
        __retval= xmpir_mpz_mul(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_mul_si(mpz rop, mpz op1, int op2)
    {
        int __retval;
        __retval= xmpir_mpz_mul_si(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_mul_ui(mpz rop, mpz op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpz_mul_ui(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_addmul(mpz rop, mpz op1, mpz op2)
    {
        int __retval;
        __retval= xmpir_mpz_addmul(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_addmul_ui(mpz rop, mpz op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpz_addmul_ui(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_submul(mpz rop, mpz op1, mpz op2)
    {
        int __retval;
        __retval= xmpir_mpz_submul(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_submul_ui(mpz rop, mpz op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpz_submul_ui(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_mul_2exp(mpz rop, mpz op1, ulong op2)
    {
        int __retval;
        __retval= xmpir_mpz_mul_2exp(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_neg(mpz rop, mpz op)
    {
        int __retval;
        __retval= xmpir_mpz_neg(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_abs(mpz rop, mpz op)
    {
        int __retval;
        __retval= xmpir_mpz_abs(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_cdiv_q(mpz q, mpz n, mpz d)
    {
        int __retval;
        __retval= xmpir_mpz_cdiv_q(q.Val, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_cdiv_r(mpz r, mpz n, mpz d)
    {
        int __retval;
        __retval= xmpir_mpz_cdiv_r(r.Val, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_cdiv_qr(mpz q, mpz r, mpz n, mpz d)
    {
        int __retval;
        __retval= xmpir_mpz_cdiv_qr(q.Val, r.Val, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static uint mpz_cdiv_q_ui(mpz q, mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_cdiv_q_ui(out result, q.Val, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint mpz_cdiv_r_ui(mpz r, mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_cdiv_r_ui(out result, r.Val, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint mpz_cdiv_qr_ui(mpz q, mpz r, mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_cdiv_qr_ui(out result, q.Val, r.Val, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint mpz_cdiv_ui(mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_cdiv_ui(out result, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_cdiv_q_2exp(mpz q, mpz n, ulong b)
    {
        int __retval;
        __retval= xmpir_mpz_cdiv_q_2exp(q.Val, n.Val, b);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_cdiv_r_2exp(mpz r, mpz n, ulong b)
    {
        int __retval;
        __retval= xmpir_mpz_cdiv_r_2exp(r.Val, n.Val, b);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_fdiv_q(mpz q, mpz n, mpz d)
    {
        int __retval;
        __retval= xmpir_mpz_fdiv_q(q.Val, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_fdiv_r(mpz r, mpz n, mpz d)
    {
        int __retval;
        __retval= xmpir_mpz_fdiv_r(r.Val, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_fdiv_qr(mpz q, mpz r, mpz n, mpz d)
    {
        int __retval;
        __retval= xmpir_mpz_fdiv_qr(q.Val, r.Val, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static uint mpz_fdiv_q_ui(mpz q, mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_fdiv_q_ui(out result, q.Val, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint mpz_fdiv_r_ui(mpz r, mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_fdiv_r_ui(out result, r.Val, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint mpz_fdiv_qr_ui(mpz q, mpz r, mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_fdiv_qr_ui(out result, q.Val, r.Val, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint mpz_fdiv_ui(mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_fdiv_ui(out result, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_fdiv_q_2exp(mpz q, mpz n, ulong b)
    {
        int __retval;
        __retval= xmpir_mpz_fdiv_q_2exp(q.Val, n.Val, b);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_fdiv_r_2exp(mpz r, mpz n, ulong b)
    {
        int __retval;
        __retval= xmpir_mpz_fdiv_r_2exp(r.Val, n.Val, b);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_tdiv_q(mpz q, mpz n, mpz d)
    {
        int __retval;
        __retval= xmpir_mpz_tdiv_q(q.Val, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_tdiv_r(mpz r, mpz n, mpz d)
    {
        int __retval;
        __retval= xmpir_mpz_tdiv_r(r.Val, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_tdiv_qr(mpz q, mpz r, mpz n, mpz d)
    {
        int __retval;
        __retval= xmpir_mpz_tdiv_qr(q.Val, r.Val, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static uint mpz_tdiv_q_ui(mpz q, mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_tdiv_q_ui(out result, q.Val, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint mpz_tdiv_r_ui(mpz r, mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_tdiv_r_ui(out result, r.Val, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint mpz_tdiv_qr_ui(mpz q, mpz r, mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_tdiv_qr_ui(out result, q.Val, r.Val, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint mpz_tdiv_ui(mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_tdiv_ui(out result, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_tdiv_q_2exp(mpz q, mpz n, ulong b)
    {
        int __retval;
        __retval= xmpir_mpz_tdiv_q_2exp(q.Val, n.Val, b);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_tdiv_r_2exp(mpz r, mpz n, ulong b)
    {
        int __retval;
        __retval= xmpir_mpz_tdiv_r_2exp(r.Val, n.Val, b);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_mod(mpz r, mpz n, mpz d)
    {
        int __retval;
        __retval= xmpir_mpz_mod(r.Val, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static uint mpz_mod_ui(mpz r, mpz n, uint d)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_mod_ui(out result, r.Val, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_divexact(mpz q, mpz n, mpz d)
    {
        int __retval;
        __retval= xmpir_mpz_divexact(q.Val, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_divexact_ui(mpz q, mpz n, uint d)
    {
        int __retval;
        __retval= xmpir_mpz_divexact_ui(q.Val, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpz_divisible_p(mpz n, mpz d)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_divisible_p(out result, n.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_divisible_ui_p(mpz n, uint d)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_divisible_ui_p(out result, n.Val, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_divisible_2exp_p(mpz n, ulong b)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_divisible_2exp_p(out result, n.Val, b);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_congruent_p(mpz n, mpz c, mpz d)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_congruent_p(out result, n.Val, c.Val, d.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_congruent_ui_p(mpz n, uint c, uint d)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_congruent_ui_p(out result, n.Val, c, d);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_congruent_2exp_p(mpz n, mpz c, ulong b)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_congruent_2exp_p(out result, n.Val, c.Val, b);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_powm(mpz rop, mpz _base, mpz _exp, mpz _mod)
    {
        int __retval;
        __retval= xmpir_mpz_powm(rop.Val, _base.Val, _exp.Val, _mod.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_powm_ui(mpz rop, mpz _base, uint _exp, mpz _mod)
    {
        int __retval;
        __retval= xmpir_mpz_powm_ui(rop.Val, _base.Val, _exp, _mod.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_pow_ui(mpz rop, mpz _base, uint _exp)
    {
        int __retval;
        __retval= xmpir_mpz_pow_ui(rop.Val, _base.Val, _exp);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_ui_pow_ui(mpz rop, uint _base, uint _exp)
    {
        int __retval;
        __retval= xmpir_mpz_ui_pow_ui(rop.Val, _base, _exp);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpz_root(mpz rop, mpz op, uint n)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_root(out result, rop.Val, op.Val, n);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_nthroot(mpz rop, mpz op, uint n)
    {
        int __retval;
        __retval= xmpir_mpz_nthroot(rop.Val, op.Val, n);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_rootrem(mpz root, mpz rem, mpz u, uint n)
    {
        int __retval;
        __retval= xmpir_mpz_rootrem(root.Val, rem.Val, u.Val, n);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_sqrt(mpz rop, mpz op)
    {
        int __retval;
        __retval= xmpir_mpz_sqrt(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_sqrtrem(mpz rop1, mpz rop2, mpz op)
    {
        int __retval;
        __retval= xmpir_mpz_sqrtrem(rop1.Val, rop2.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpz_perfect_power_p(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_perfect_power_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_perfect_square_p(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_perfect_square_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_probable_prime_p(mpz n, randstate state, int prob, uint div)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_probable_prime_p(out result, n.Val, state.Val, prob, div);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_likely_prime_p(mpz n, randstate state, uint div)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_likely_prime_p(out result, n.Val, state.Val, div);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_probab_prime_p(mpz n, uint reps)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_probab_prime_p(out result, n.Val, reps);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_nextprime(mpz rop, mpz op)
    {
        int __retval;
        __retval= xmpir_mpz_nextprime(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_next_prime_candidate(mpz rop, mpz op, randstate state)
    {
        int __retval;
        __retval= xmpir_mpz_next_prime_candidate(rop.Val, op.Val, state.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_gcd(mpz rop, mpz op1, mpz op2)
    {
        int __retval;
        __retval= xmpir_mpz_gcd(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static uint mpz_gcd_ui(mpz rop, mpz op1, uint op2)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpz_gcd_ui(out result, rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_gcdext(mpz g, mpz s, mpz t, mpz a, mpz b)
    {
        int __retval;
        __retval= xmpir_mpz_gcdext(g.Val, s.Val, t.Val, a.Val, b.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_lcm(mpz rop, mpz op1, mpz op2)
    {
        int __retval;
        __retval= xmpir_mpz_lcm(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_lcm_ui(mpz rop, mpz op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpz_lcm_ui(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpz_invert(mpz rop, mpz op1, mpz op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_invert(out result, rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_jacobi(mpz a, mpz b)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_jacobi(out result, a.Val, b.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_legendre(mpz a, mpz p)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_legendre(out result, a.Val, p.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_kronecker(mpz a, mpz b)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_kronecker(out result, a.Val, b.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_kronecker_si(mpz a, int b)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_kronecker_si(out result, a.Val, b);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_kronecker_ui(mpz a, uint b)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_kronecker_ui(out result, a.Val, b);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_si_kronecker(int a, mpz b)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_si_kronecker(out result, a, b.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_ui_kronecker(uint a, mpz b)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_ui_kronecker(out result, a, b.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static ulong mpz_remove(mpz rop, mpz op, mpz f)
    {
        int __retval;
        ulong result;
        __retval= xmpir_mpz_remove(out result, rop.Val, op.Val, f.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_fac_ui(mpz rop, uint op)
    {
        int __retval;
        __retval= xmpir_mpz_fac_ui(rop.Val, op);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_2fac_ui(mpz rop, uint op)
    {
        int __retval;
        __retval= xmpir_mpz_2fac_ui(rop.Val, op);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_mfac_uiui(mpz rop, uint op, uint m)
    {
        int __retval;
        __retval= xmpir_mpz_mfac_uiui(rop.Val, op, m);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_primorial_ui(mpz rop, uint op)
    {
        int __retval;
        __retval= xmpir_mpz_primorial_ui(rop.Val, op);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_bin_ui(mpz rop, mpz n, uint k)
    {
        int __retval;
        __retval= xmpir_mpz_bin_ui(rop.Val, n.Val, k);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_bin_uiui(mpz rop, uint n, uint k)
    {
        int __retval;
        __retval= xmpir_mpz_bin_uiui(rop.Val, n, k);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_fib_ui(mpz fn, uint n)
    {
        int __retval;
        __retval= xmpir_mpz_fib_ui(fn.Val, n);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_fib2_ui(mpz fn, mpz fnsub1, uint n)
    {
        int __retval;
        __retval= xmpir_mpz_fib2_ui(fn.Val, fnsub1.Val, n);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_lucnum_ui(mpz ln, uint n)
    {
        int __retval;
        __retval= xmpir_mpz_lucnum_ui(ln.Val, n);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_lucnum2_ui(mpz ln, mpz lnsub1, uint n)
    {
        int __retval;
        __retval= xmpir_mpz_lucnum2_ui(ln.Val, lnsub1.Val, n);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpz_cmp(mpz op1, mpz op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_cmp(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_cmp_d(mpz op1, double op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_cmp_d(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_cmp_si(mpz op1, int op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_cmp_si(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_cmp_ui(mpz op1, uint op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_cmp_ui(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_cmpabs(mpz op1, mpz op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_cmpabs(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_cmpabs_d(mpz op1, double op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_cmpabs_d(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_cmpabs_ui(mpz op1, uint op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_cmpabs_ui(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_sgn(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_sgn(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_and(mpz rop, mpz op1, mpz op2)
    {
        int __retval;
        __retval= xmpir_mpz_and(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_ior(mpz rop, mpz op1, mpz op2)
    {
        int __retval;
        __retval= xmpir_mpz_ior(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_xor(mpz rop, mpz op1, mpz op2)
    {
        int __retval;
        __retval= xmpir_mpz_xor(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_com(mpz rop, mpz op)
    {
        int __retval;
        __retval= xmpir_mpz_com(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static ulong mpz_popcount(mpz op)
    {
        int __retval;
        ulong result;
        __retval= xmpir_mpz_popcount(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static ulong mpz_hamdist(mpz op1, mpz op2)
    {
        int __retval;
        ulong result;
        __retval= xmpir_mpz_hamdist(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static ulong mpz_scan0(mpz op, ulong starting_bit)
    {
        int __retval;
        ulong result;
        __retval= xmpir_mpz_scan0(out result, op.Val, starting_bit);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static ulong mpz_scan1(mpz op, ulong starting_bit)
    {
        int __retval;
        ulong result;
        __retval= xmpir_mpz_scan1(out result, op.Val, starting_bit);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_setbit(mpz rop, ulong bit_index)
    {
        int __retval;
        __retval= xmpir_mpz_setbit(rop.Val, bit_index);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_clrbit(mpz rop, ulong bit_index)
    {
        int __retval;
        __retval= xmpir_mpz_clrbit(rop.Val, bit_index);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_combit(mpz rop, ulong bit_index)
    {
        int __retval;
        __retval= xmpir_mpz_combit(rop.Val, bit_index);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpz_tstbit(mpz op, ulong bit_index)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_tstbit(out result, op.Val, bit_index);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpz_urandomb(mpz rop, randstate state, ulong n)
    {
        int __retval;
        __retval= xmpir_mpz_urandomb(rop.Val, state.Val, n);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_urandomm(mpz rop, randstate state, mpz n)
    {
        int __retval;
        __retval= xmpir_mpz_urandomm(rop.Val, state.Val, n.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpz_rrandomb(mpz rop, randstate state, ulong n)
    {
        int __retval;
        __retval= xmpir_mpz_rrandomb(rop.Val, state.Val, n);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpz_fits_uint_p(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_fits_uint_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_fits_sint_p(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_fits_sint_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_odd_p(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_odd_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_even_p(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_even_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static ulong mpz_sizeinbase(mpz op, uint _base)
    {
        int __retval;
        ulong result;
        __retval= xmpir_mpz_sizeinbase(out result, op.Val, _base);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpq_canonicalize(mpq op)
    {
        int __retval;
        __retval= xmpir_mpq_canonicalize(op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_set(mpq rop, mpq op)
    {
        int __retval;
        __retval= xmpir_mpq_set(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_set_z(mpq rop, mpz op)
    {
        int __retval;
        __retval= xmpir_mpq_set_z(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_set_ui(mpq rop, uint op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpq_set_ui(rop.Val, op1, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_set_si(mpq rop, int op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpq_set_si(rop.Val, op1, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpq_set_str(mpq rop, string str, uint _base)
    {
        int __retval;
        int result;
        byte[] __ba_str = System.Text.Encoding.UTF8.GetBytes(str+"\0");
        IntPtr __str;
        __retval = xmpir_malloc(out __str, str.Length+1);
        if( __retval!=0 ) HandleError(__retval);
        Marshal.Copy(__ba_str, 0, __str, str.Length+1);
        __retval= xmpir_mpq_set_str(out result, rop.Val, __str, _base);
        if( __retval!=0 ) HandleError(__retval);
       __retval = xmpir_free(__str);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpq_swap(mpq rop1, mpq rop2)
    {
        int __retval;
        __retval= xmpir_mpq_swap(rop1.Val, rop2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static double mpq_get_d(mpq op)
    {
        int __retval;
        double result;
        __retval= xmpir_mpq_get_d(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpq_set_d(mpq rop, double op)
    {
        int __retval;
        __retval= xmpir_mpq_set_d(rop.Val, op);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_set_f(mpq rop, mpf op)
    {
        int __retval;
        __retval= xmpir_mpq_set_f(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static string mpq_get_string(uint _base, mpq op)
    {
        int __retval;
        string result;
        IntPtr __result;
        __retval= xmpir_mpq_get_string(out __result, _base, op.Val);
        if( __retval!=0 ) HandleError(__retval);
       result = Marshal.PtrToStringAnsi(__result);
       __retval = xmpir_free(__result);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpq_add(mpq sum, mpq addend1, mpq addend2)
    {
        int __retval;
        __retval= xmpir_mpq_add(sum.Val, addend1.Val, addend2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_sub(mpq difference, mpq minuend, mpq subtrahend)
    {
        int __retval;
        __retval= xmpir_mpq_sub(difference.Val, minuend.Val, subtrahend.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_mul(mpq product, mpq multiplier, mpq multiplicand)
    {
        int __retval;
        __retval= xmpir_mpq_mul(product.Val, multiplier.Val, multiplicand.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_mul_2exp(mpq rop, mpq op1, ulong op2)
    {
        int __retval;
        __retval= xmpir_mpq_mul_2exp(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_div(mpq quotient, mpq dividend, mpq divisor)
    {
        int __retval;
        __retval= xmpir_mpq_div(quotient.Val, dividend.Val, divisor.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_div_2exp(mpq rop, mpq op1, ulong op2)
    {
        int __retval;
        __retval= xmpir_mpq_div_2exp(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_neg(mpq negated_operand, mpq operand)
    {
        int __retval;
        __retval= xmpir_mpq_neg(negated_operand.Val, operand.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_abs(mpq rop, mpq op)
    {
        int __retval;
        __retval= xmpir_mpq_abs(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_inv(mpq inverted_number, mpq number)
    {
        int __retval;
        __retval= xmpir_mpq_inv(inverted_number.Val, number.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpq_cmp(mpq op1, mpq op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpq_cmp(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpq_cmp_ui(mpq op1, uint num2, uint den2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpq_cmp_ui(out result, op1.Val, num2, den2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpq_cmp_si(mpq op1, int num2, uint den2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpq_cmp_si(out result, op1.Val, num2, den2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpq_sgn(mpq op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpq_sgn(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpq_equal(mpq op1, mpq op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpq_equal(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpq_get_num(mpz numerator, mpq rational)
    {
        int __retval;
        __retval= xmpir_mpq_get_num(numerator.Val, rational.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_get_den(mpz denominator, mpq rational)
    {
        int __retval;
        __retval= xmpir_mpq_get_den(denominator.Val, rational.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_set_num(mpq rational, mpz numerator)
    {
        int __retval;
        __retval= xmpir_mpq_set_num(rational.Val, numerator.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpq_set_den(mpq rational, mpz denominator)
    {
        int __retval;
        __retval= xmpir_mpq_set_den(rational.Val, denominator.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static ulong mpf_get_prec(mpf op)
    {
        int __retval;
        ulong result;
        __retval= xmpir_mpf_get_prec(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpf_set_prec(mpf rop, ulong prec)
    {
        int __retval;
        __retval= xmpir_mpf_set_prec(rop.Val, prec);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_set(mpf rop, mpf op)
    {
        int __retval;
        __retval= xmpir_mpf_set(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_set_ui(mpf rop, uint op)
    {
        int __retval;
        __retval= xmpir_mpf_set_ui(rop.Val, op);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_set_si(mpf rop, int op)
    {
        int __retval;
        __retval= xmpir_mpf_set_si(rop.Val, op);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_set_d(mpf rop, double op)
    {
        int __retval;
        __retval= xmpir_mpf_set_d(rop.Val, op);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_set_z(mpf rop, mpz op)
    {
        int __retval;
        __retval= xmpir_mpf_set_z(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_set_q(mpf rop, mpq op)
    {
        int __retval;
        __retval= xmpir_mpf_set_q(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpf_set_str(mpf rop, string str, uint _base)
    {
        int __retval;
        int result;
        byte[] __ba_str = System.Text.Encoding.UTF8.GetBytes(str+"\0");
        IntPtr __str;
        __retval = xmpir_malloc(out __str, str.Length+1);
        if( __retval!=0 ) HandleError(__retval);
        Marshal.Copy(__ba_str, 0, __str, str.Length+1);
        __retval= xmpir_mpf_set_str(out result, rop.Val, __str, _base);
        if( __retval!=0 ) HandleError(__retval);
       __retval = xmpir_free(__str);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpf_swap(mpf rop1, mpf rop2)
    {
        int __retval;
        __retval= xmpir_mpf_swap(rop1.Val, rop2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static double mpf_get_d(mpf op)
    {
        int __retval;
        double result;
        __retval= xmpir_mpf_get_d(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static double mpf_get_d_2exp(out int expptr, mpf op)
    {
        int __retval;
        double result;
        __retval= xmpir_mpf_get_d_2exp(out result, out expptr, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpf_get_si(mpf op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_get_si(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint mpf_get_ui(mpf op)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpf_get_ui(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static string mpf_get_string(out long expptr, uint _base, uint n_digits, mpf op)
    {
        int __retval;
        string result;
        IntPtr __result;
        __retval= xmpir_mpf_get_string(out __result, out expptr, _base, n_digits, op.Val);
        if( __retval!=0 ) HandleError(__retval);
       result = Marshal.PtrToStringAnsi(__result);
       __retval = xmpir_free(__result);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpf_add(mpf rop, mpf op1, mpf op2)
    {
        int __retval;
        __retval= xmpir_mpf_add(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_add_ui(mpf rop, mpf op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpf_add_ui(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_sub(mpf rop, mpf op1, mpf op2)
    {
        int __retval;
        __retval= xmpir_mpf_sub(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_ui_sub(mpf rop, uint op1, mpf op2)
    {
        int __retval;
        __retval= xmpir_mpf_ui_sub(rop.Val, op1, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_sub_ui(mpf rop, mpf op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpf_sub_ui(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_mul(mpf rop, mpf op1, mpf op2)
    {
        int __retval;
        __retval= xmpir_mpf_mul(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_mul_ui(mpf rop, mpf op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpf_mul_ui(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_div(mpf rop, mpf op1, mpf op2)
    {
        int __retval;
        __retval= xmpir_mpf_div(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_ui_div(mpf rop, uint op1, mpf op2)
    {
        int __retval;
        __retval= xmpir_mpf_ui_div(rop.Val, op1, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_div_ui(mpf rop, mpf op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpf_div_ui(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_sqrt(mpf rop, mpf op)
    {
        int __retval;
        __retval= xmpir_mpf_sqrt(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_sqrt_ui(mpf rop, uint op)
    {
        int __retval;
        __retval= xmpir_mpf_sqrt_ui(rop.Val, op);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_pow_ui(mpf rop, mpf op1, uint op2)
    {
        int __retval;
        __retval= xmpir_mpf_pow_ui(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_neg(mpf rop, mpf op)
    {
        int __retval;
        __retval= xmpir_mpf_neg(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_abs(mpf rop, mpf op)
    {
        int __retval;
        __retval= xmpir_mpf_abs(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_mul_2exp(mpf rop, mpf op1, ulong op2)
    {
        int __retval;
        __retval= xmpir_mpf_mul_2exp(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_div_2exp(mpf rop, mpf op1, ulong op2)
    {
        int __retval;
        __retval= xmpir_mpf_div_2exp(rop.Val, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpf_cmp(mpf op1, mpf op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_cmp(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpf_cmp_d(mpf op1, double op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_cmp_d(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpf_cmp_ui(mpf op1, uint op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_cmp_ui(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpf_cmp_si(mpf op1, int op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_cmp_si(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpf_eq(mpf op1, mpf op2, ulong op3)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_eq(out result, op1.Val, op2.Val, op3);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpf_reldiff(mpf rop, mpf op1, mpf op2)
    {
        int __retval;
        __retval= xmpir_mpf_reldiff(rop.Val, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpf_sgn(mpf op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_sgn(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpf_ceil(mpf rop, mpf op)
    {
        int __retval;
        __retval= xmpir_mpf_ceil(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_floor(mpf rop, mpf op)
    {
        int __retval;
        __retval= xmpir_mpf_floor(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_trunc(mpf rop, mpf op)
    {
        int __retval;
        __retval= xmpir_mpf_trunc(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpf_integer_p(mpf op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_integer_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpf_fits_uint_p(mpf op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_fits_uint_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpf_fits_sint_p(mpf op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_fits_sint_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpf_urandomb(mpf rop, randstate state, ulong nbits)
    {
        int __retval;
        __retval= xmpir_mpf_urandomb(rop.Val, state.Val, nbits);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpf_rrandomb(mpf rop, randstate state, long max_size, long exp)
    {
        int __retval;
        __retval= xmpir_mpf_rrandomb(rop.Val, state.Val, max_size, exp);
        if( __retval!=0 ) HandleError(__retval);
    }

}
}
