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
using System.Security;

// Disable warning about missing XML comments.
#pragma warning disable 1591

namespace Mpir.NET 
{

using mpz_intptr = IntPtr;
using mpq_intptr = IntPtr;
using mpf_intptr = IntPtr;
using mpfr_intptr = IntPtr;
using mpc_intptr = IntPtr;
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
    private static IntPtr __ptr__xmpir_mpfr_init = GetProcAddressSafe(hxmpir, "xmpir_mpfr_init");
    private static IntPtr __ptr__xmpir_mpfr_init2 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_init2");
    private static IntPtr __ptr__xmpir_mpfr_init_set = GetProcAddressSafe(hxmpir, "xmpir_mpfr_init_set");
    private static IntPtr __ptr__xmpir_mpfr_init_set_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_init_set_ui");
    private static IntPtr __ptr__xmpir_mpfr_init_set_si = GetProcAddressSafe(hxmpir, "xmpir_mpfr_init_set_si");
    private static IntPtr __ptr__xmpir_mpfr_init_set_d = GetProcAddressSafe(hxmpir, "xmpir_mpfr_init_set_d");
    private static IntPtr __ptr__xmpir_mpfr_init_set_z = GetProcAddressSafe(hxmpir, "xmpir_mpfr_init_set_z");
    private static IntPtr __ptr__xmpir_mpfr_init_set_q = GetProcAddressSafe(hxmpir, "xmpir_mpfr_init_set_q");
    private static IntPtr __ptr__xmpir_mpfr_init_set_f = GetProcAddressSafe(hxmpir, "xmpir_mpfr_init_set_f");
    private static IntPtr __ptr__xmpir_mpfr_init_set_str = GetProcAddressSafe(hxmpir, "xmpir_mpfr_init_set_str");
    private static IntPtr __ptr__xmpir_mpc_init2 = GetProcAddressSafe(hxmpir, "xmpir_mpc_init2");
    private static IntPtr __ptr__xmpir_mpc_init3 = GetProcAddressSafe(hxmpir, "xmpir_mpc_init3");
    private static IntPtr __ptr__xmpir_mpz_clear = GetProcAddressSafe(hxmpir, "xmpir_mpz_clear");
    private static IntPtr __ptr__xmpir_mpq_clear = GetProcAddressSafe(hxmpir, "xmpir_mpq_clear");
    private static IntPtr __ptr__xmpir_mpf_clear = GetProcAddressSafe(hxmpir, "xmpir_mpf_clear");
    private static IntPtr __ptr__xmpir_mpfr_clear = GetProcAddressSafe(hxmpir, "xmpir_mpfr_clear");
    private static IntPtr __ptr__xmpir_mpc_clear = GetProcAddressSafe(hxmpir, "xmpir_mpc_clear");
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
    private static IntPtr __ptr__xmpir_mpz_fits_ulong_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_fits_ulong_p");
    private static IntPtr __ptr__xmpir_mpz_fits_slong_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_fits_slong_p");
    private static IntPtr __ptr__xmpir_mpz_fits_uint_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_fits_uint_p");
    private static IntPtr __ptr__xmpir_mpz_fits_sint_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_fits_sint_p");
    private static IntPtr __ptr__xmpir_mpz_fits_ushort_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_fits_ushort_p");
    private static IntPtr __ptr__xmpir_mpz_fits_sshort_p = GetProcAddressSafe(hxmpir, "xmpir_mpz_fits_sshort_p");
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
    private static IntPtr __ptr__xmpir_mpf_set_default_prec = GetProcAddressSafe(hxmpir, "xmpir_mpf_set_default_prec");
    private static IntPtr __ptr__xmpir_mpf_get_default_prec = GetProcAddressSafe(hxmpir, "xmpir_mpf_get_default_prec");
    private static IntPtr __ptr__xmpir_mpf_get_prec = GetProcAddressSafe(hxmpir, "xmpir_mpf_get_prec");
    private static IntPtr __ptr__xmpir_mpf_set_prec = GetProcAddressSafe(hxmpir, "xmpir_mpf_set_prec");
    private static IntPtr __ptr__xmpir_mpf_set_prec_raw = GetProcAddressSafe(hxmpir, "xmpir_mpf_set_prec_raw");
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
    private static IntPtr __ptr__xmpir_mpf_fits_ulong_p = GetProcAddressSafe(hxmpir, "xmpir_mpf_fits_ulong_p");
    private static IntPtr __ptr__xmpir_mpf_fits_slong_p = GetProcAddressSafe(hxmpir, "xmpir_mpf_fits_slong_p");
    private static IntPtr __ptr__xmpir_mpf_fits_uint_p = GetProcAddressSafe(hxmpir, "xmpir_mpf_fits_uint_p");
    private static IntPtr __ptr__xmpir_mpf_fits_sint_p = GetProcAddressSafe(hxmpir, "xmpir_mpf_fits_sint_p");
    private static IntPtr __ptr__xmpir_mpf_fits_ushort_p = GetProcAddressSafe(hxmpir, "xmpir_mpf_fits_ushort_p");
    private static IntPtr __ptr__xmpir_mpf_fits_sshort_p = GetProcAddressSafe(hxmpir, "xmpir_mpf_fits_sshort_p");
    private static IntPtr __ptr__xmpir_mpf_urandomb = GetProcAddressSafe(hxmpir, "xmpir_mpf_urandomb");
    private static IntPtr __ptr__xmpir_mpf_rrandomb = GetProcAddressSafe(hxmpir, "xmpir_mpf_rrandomb");
    private static IntPtr __ptr__xmpir_mpfr_set_default_prec = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_default_prec");
    private static IntPtr __ptr__xmpir_mpfr_get_default_prec = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_default_prec");
    private static IntPtr __ptr__xmpir_mpfr_set_prec = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_prec");
    private static IntPtr __ptr__xmpir_mpfr_get_prec = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_prec");
    private static IntPtr __ptr__xmpir_mpfr_set = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set");
    private static IntPtr __ptr__xmpir_mpfr_set_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_ui");
    private static IntPtr __ptr__xmpir_mpfr_set_si = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_si");
    private static IntPtr __ptr__xmpir_mpfr_set_d = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_d");
    private static IntPtr __ptr__xmpir_mpfr_set_z = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_z");
    private static IntPtr __ptr__xmpir_mpfr_set_q = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_q");
    private static IntPtr __ptr__xmpir_mpfr_set_f = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_f");
    private static IntPtr __ptr__xmpir_mpfr_set_str = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_str");
    private static IntPtr __ptr__xmpir_mpfr_set_ui_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_ui_2exp");
    private static IntPtr __ptr__xmpir_mpfr_set_si_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_si_2exp");
    private static IntPtr __ptr__xmpir_mpfr_set_z_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_z_2exp");
    private static IntPtr __ptr__xmpir_mpfr_set_nan = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_nan");
    private static IntPtr __ptr__xmpir_mpfr_set_inf = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_inf");
    private static IntPtr __ptr__xmpir_mpfr_set_zero = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_zero");
    private static IntPtr __ptr__xmpir_mpfr_swap = GetProcAddressSafe(hxmpir, "xmpir_mpfr_swap");
    private static IntPtr __ptr__xmpir_mpfr_get_d = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_d");
    private static IntPtr __ptr__xmpir_mpfr_get_si = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_si");
    private static IntPtr __ptr__xmpir_mpfr_get_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_ui");
    private static IntPtr __ptr__xmpir_mpfr_get_d_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_d_2exp");
    private static IntPtr __ptr__xmpir_mpfr_frexp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_frexp");
    private static IntPtr __ptr__xmpir_mpfr_get_z_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_z_2exp");
    private static IntPtr __ptr__xmpir_mpfr_get_z = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_z");
    private static IntPtr __ptr__xmpir_mpfr_get_f = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_f");
    private static IntPtr __ptr__xmpir_mpfr_get_str = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_str");
    private static IntPtr __ptr__xmpir_mpfr_fits_ulong_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_fits_ulong_p");
    private static IntPtr __ptr__xmpir_mpfr_fits_slong_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_fits_slong_p");
    private static IntPtr __ptr__xmpir_mpfr_fits_uint_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_fits_uint_p");
    private static IntPtr __ptr__xmpir_mpfr_fits_sint_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_fits_sint_p");
    private static IntPtr __ptr__xmpir_mpfr_fits_ushort_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_fits_ushort_p");
    private static IntPtr __ptr__xmpir_mpfr_fits_sshort_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_fits_sshort_p");
    private static IntPtr __ptr__xmpir_mpfr_add = GetProcAddressSafe(hxmpir, "xmpir_mpfr_add");
    private static IntPtr __ptr__xmpir_mpfr_add_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_add_ui");
    private static IntPtr __ptr__xmpir_mpfr_add_si = GetProcAddressSafe(hxmpir, "xmpir_mpfr_add_si");
    private static IntPtr __ptr__xmpir_mpfr_add_d = GetProcAddressSafe(hxmpir, "xmpir_mpfr_add_d");
    private static IntPtr __ptr__xmpir_mpfr_add_z = GetProcAddressSafe(hxmpir, "xmpir_mpfr_add_z");
    private static IntPtr __ptr__xmpir_mpfr_add_q = GetProcAddressSafe(hxmpir, "xmpir_mpfr_add_q");
    private static IntPtr __ptr__xmpir_mpfr_sub = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sub");
    private static IntPtr __ptr__xmpir_mpfr_ui_sub = GetProcAddressSafe(hxmpir, "xmpir_mpfr_ui_sub");
    private static IntPtr __ptr__xmpir_mpfr_sub_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sub_ui");
    private static IntPtr __ptr__xmpir_mpfr_si_sub = GetProcAddressSafe(hxmpir, "xmpir_mpfr_si_sub");
    private static IntPtr __ptr__xmpir_mpfr_sub_si = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sub_si");
    private static IntPtr __ptr__xmpir_mpfr_d_sub = GetProcAddressSafe(hxmpir, "xmpir_mpfr_d_sub");
    private static IntPtr __ptr__xmpir_mpfr_sub_d = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sub_d");
    private static IntPtr __ptr__xmpir_mpfr_z_sub = GetProcAddressSafe(hxmpir, "xmpir_mpfr_z_sub");
    private static IntPtr __ptr__xmpir_mpfr_sub_z = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sub_z");
    private static IntPtr __ptr__xmpir_mpfr_sub_q = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sub_q");
    private static IntPtr __ptr__xmpir_mpfr_mul = GetProcAddressSafe(hxmpir, "xmpir_mpfr_mul");
    private static IntPtr __ptr__xmpir_mpfr_mul_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_mul_ui");
    private static IntPtr __ptr__xmpir_mpfr_mul_si = GetProcAddressSafe(hxmpir, "xmpir_mpfr_mul_si");
    private static IntPtr __ptr__xmpir_mpfr_mul_d = GetProcAddressSafe(hxmpir, "xmpir_mpfr_mul_d");
    private static IntPtr __ptr__xmpir_mpfr_mul_z = GetProcAddressSafe(hxmpir, "xmpir_mpfr_mul_z");
    private static IntPtr __ptr__xmpir_mpfr_mul_q = GetProcAddressSafe(hxmpir, "xmpir_mpfr_mul_q");
    private static IntPtr __ptr__xmpir_mpfr_sqr = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sqr");
    private static IntPtr __ptr__xmpir_mpfr_div = GetProcAddressSafe(hxmpir, "xmpir_mpfr_div");
    private static IntPtr __ptr__xmpir_mpfr_ui_div = GetProcAddressSafe(hxmpir, "xmpir_mpfr_ui_div");
    private static IntPtr __ptr__xmpir_mpfr_div_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_div_ui");
    private static IntPtr __ptr__xmpir_mpfr_si_div = GetProcAddressSafe(hxmpir, "xmpir_mpfr_si_div");
    private static IntPtr __ptr__xmpir_mpfr_div_si = GetProcAddressSafe(hxmpir, "xmpir_mpfr_div_si");
    private static IntPtr __ptr__xmpir_mpfr_d_div = GetProcAddressSafe(hxmpir, "xmpir_mpfr_d_div");
    private static IntPtr __ptr__xmpir_mpfr_div_d = GetProcAddressSafe(hxmpir, "xmpir_mpfr_div_d");
    private static IntPtr __ptr__xmpir_mpfr_div_z = GetProcAddressSafe(hxmpir, "xmpir_mpfr_div_z");
    private static IntPtr __ptr__xmpir_mpfr_div_q = GetProcAddressSafe(hxmpir, "xmpir_mpfr_div_q");
    private static IntPtr __ptr__xmpir_mpfr_sqrt = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sqrt");
    private static IntPtr __ptr__xmpir_mpfr_sqrt_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sqrt_ui");
    private static IntPtr __ptr__xmpir_mpfr_rec_sqrt = GetProcAddressSafe(hxmpir, "xmpir_mpfr_rec_sqrt");
    private static IntPtr __ptr__xmpir_mpfr_cbrt = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cbrt");
    private static IntPtr __ptr__xmpir_mpfr_root = GetProcAddressSafe(hxmpir, "xmpir_mpfr_root");
    private static IntPtr __ptr__xmpir_mpfr_pow = GetProcAddressSafe(hxmpir, "xmpir_mpfr_pow");
    private static IntPtr __ptr__xmpir_mpfr_pow_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_pow_ui");
    private static IntPtr __ptr__xmpir_mpfr_pow_si = GetProcAddressSafe(hxmpir, "xmpir_mpfr_pow_si");
    private static IntPtr __ptr__xmpir_mpfr_pow_z = GetProcAddressSafe(hxmpir, "xmpir_mpfr_pow_z");
    private static IntPtr __ptr__xmpir_mpfr_ui_pow_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_ui_pow_ui");
    private static IntPtr __ptr__xmpir_mpfr_ui_pow = GetProcAddressSafe(hxmpir, "xmpir_mpfr_ui_pow");
    private static IntPtr __ptr__xmpir_mpfr_neg = GetProcAddressSafe(hxmpir, "xmpir_mpfr_neg");
    private static IntPtr __ptr__xmpir_mpfr_abs = GetProcAddressSafe(hxmpir, "xmpir_mpfr_abs");
    private static IntPtr __ptr__xmpir_mpfr_dim = GetProcAddressSafe(hxmpir, "xmpir_mpfr_dim");
    private static IntPtr __ptr__xmpir_mpfr_mul_2ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_mul_2ui");
    private static IntPtr __ptr__xmpir_mpfr_mul_2si = GetProcAddressSafe(hxmpir, "xmpir_mpfr_mul_2si");
    private static IntPtr __ptr__xmpir_mpfr_div_2ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_div_2ui");
    private static IntPtr __ptr__xmpir_mpfr_div_2si = GetProcAddressSafe(hxmpir, "xmpir_mpfr_div_2si");
    private static IntPtr __ptr__xmpir_mpfr_cmp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cmp");
    private static IntPtr __ptr__xmpir_mpfr_cmp_d = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cmp_d");
    private static IntPtr __ptr__xmpir_mpfr_cmp_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cmp_ui");
    private static IntPtr __ptr__xmpir_mpfr_cmp_si = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cmp_si");
    private static IntPtr __ptr__xmpir_mpfr_cmp_z = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cmp_z");
    private static IntPtr __ptr__xmpir_mpfr_cmp_q = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cmp_q");
    private static IntPtr __ptr__xmpir_mpfr_cmp_f = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cmp_f");
    private static IntPtr __ptr__xmpir_mpfr_cmp_ui_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cmp_ui_2exp");
    private static IntPtr __ptr__xmpir_mpfr_cmp_si_2exp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cmp_si_2exp");
    private static IntPtr __ptr__xmpir_mpfr_cmpabs = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cmpabs");
    private static IntPtr __ptr__xmpir_mpfr_nan_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_nan_p");
    private static IntPtr __ptr__xmpir_mpfr_inf_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_inf_p");
    private static IntPtr __ptr__xmpir_mpfr_number_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_number_p");
    private static IntPtr __ptr__xmpir_mpfr_zero_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_zero_p");
    private static IntPtr __ptr__xmpir_mpfr_regular_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_regular_p");
    private static IntPtr __ptr__xmpir_mpfr_sgn = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sgn");
    private static IntPtr __ptr__xmpir_mpfr_greater_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_greater_p");
    private static IntPtr __ptr__xmpir_mpfr_greaterequal_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_greaterequal_p");
    private static IntPtr __ptr__xmpir_mpfr_less_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_less_p");
    private static IntPtr __ptr__xmpir_mpfr_lessequal_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_lessequal_p");
    private static IntPtr __ptr__xmpir_mpfr_equal_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_equal_p");
    private static IntPtr __ptr__xmpir_mpfr_lessgreater_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_lessgreater_p");
    private static IntPtr __ptr__xmpir_mpfr_unordered_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_unordered_p");
    private static IntPtr __ptr__xmpir_mpfr_log = GetProcAddressSafe(hxmpir, "xmpir_mpfr_log");
    private static IntPtr __ptr__xmpir_mpfr_log2 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_log2");
    private static IntPtr __ptr__xmpir_mpfr_log10 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_log10");
    private static IntPtr __ptr__xmpir_mpfr_exp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_exp");
    private static IntPtr __ptr__xmpir_mpfr_exp2 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_exp2");
    private static IntPtr __ptr__xmpir_mpfr_exp10 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_exp10");
    private static IntPtr __ptr__xmpir_mpfr_cos = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cos");
    private static IntPtr __ptr__xmpir_mpfr_sin = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sin");
    private static IntPtr __ptr__xmpir_mpfr_tan = GetProcAddressSafe(hxmpir, "xmpir_mpfr_tan");
    private static IntPtr __ptr__xmpir_mpfr_sin_cos = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sin_cos");
    private static IntPtr __ptr__xmpir_mpfr_sec = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sec");
    private static IntPtr __ptr__xmpir_mpfr_csc = GetProcAddressSafe(hxmpir, "xmpir_mpfr_csc");
    private static IntPtr __ptr__xmpir_mpfr_cot = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cot");
    private static IntPtr __ptr__xmpir_mpfr_acos = GetProcAddressSafe(hxmpir, "xmpir_mpfr_acos");
    private static IntPtr __ptr__xmpir_mpfr_asin = GetProcAddressSafe(hxmpir, "xmpir_mpfr_asin");
    private static IntPtr __ptr__xmpir_mpfr_atan = GetProcAddressSafe(hxmpir, "xmpir_mpfr_atan");
    private static IntPtr __ptr__xmpir_mpfr_atan2 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_atan2");
    private static IntPtr __ptr__xmpir_mpfr_cosh = GetProcAddressSafe(hxmpir, "xmpir_mpfr_cosh");
    private static IntPtr __ptr__xmpir_mpfr_sinh = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sinh");
    private static IntPtr __ptr__xmpir_mpfr_tanh = GetProcAddressSafe(hxmpir, "xmpir_mpfr_tanh");
    private static IntPtr __ptr__xmpir_mpfr_sinh_cosh = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sinh_cosh");
    private static IntPtr __ptr__xmpir_mpfr_sech = GetProcAddressSafe(hxmpir, "xmpir_mpfr_sech");
    private static IntPtr __ptr__xmpir_mpfr_csch = GetProcAddressSafe(hxmpir, "xmpir_mpfr_csch");
    private static IntPtr __ptr__xmpir_mpfr_coth = GetProcAddressSafe(hxmpir, "xmpir_mpfr_coth");
    private static IntPtr __ptr__xmpir_mpfr_acosh = GetProcAddressSafe(hxmpir, "xmpir_mpfr_acosh");
    private static IntPtr __ptr__xmpir_mpfr_asinh = GetProcAddressSafe(hxmpir, "xmpir_mpfr_asinh");
    private static IntPtr __ptr__xmpir_mpfr_atanh = GetProcAddressSafe(hxmpir, "xmpir_mpfr_atanh");
    private static IntPtr __ptr__xmpir_mpfr_fac_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_fac_ui");
    private static IntPtr __ptr__xmpir_mpfr_log1p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_log1p");
    private static IntPtr __ptr__xmpir_mpfr_expm1 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_expm1");
    private static IntPtr __ptr__xmpir_mpfr_eint = GetProcAddressSafe(hxmpir, "xmpir_mpfr_eint");
    private static IntPtr __ptr__xmpir_mpfr_li2 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_li2");
    private static IntPtr __ptr__xmpir_mpfr_gamma = GetProcAddressSafe(hxmpir, "xmpir_mpfr_gamma");
    private static IntPtr __ptr__xmpir_mpfr_lngamma = GetProcAddressSafe(hxmpir, "xmpir_mpfr_lngamma");
    private static IntPtr __ptr__xmpir_mpfr_lgamma = GetProcAddressSafe(hxmpir, "xmpir_mpfr_lgamma");
    private static IntPtr __ptr__xmpir_mpfr_digamma = GetProcAddressSafe(hxmpir, "xmpir_mpfr_digamma");
    private static IntPtr __ptr__xmpir_mpfr_zeta = GetProcAddressSafe(hxmpir, "xmpir_mpfr_zeta");
    private static IntPtr __ptr__xmpir_mpfr_zeta_ui = GetProcAddressSafe(hxmpir, "xmpir_mpfr_zeta_ui");
    private static IntPtr __ptr__xmpir_mpfr_erf = GetProcAddressSafe(hxmpir, "xmpir_mpfr_erf");
    private static IntPtr __ptr__xmpir_mpfr_erfc = GetProcAddressSafe(hxmpir, "xmpir_mpfr_erfc");
    private static IntPtr __ptr__xmpir_mpfr_j0 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_j0");
    private static IntPtr __ptr__xmpir_mpfr_j1 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_j1");
    private static IntPtr __ptr__xmpir_mpfr_jn = GetProcAddressSafe(hxmpir, "xmpir_mpfr_jn");
    private static IntPtr __ptr__xmpir_mpfr_y0 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_y0");
    private static IntPtr __ptr__xmpir_mpfr_y1 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_y1");
    private static IntPtr __ptr__xmpir_mpfr_yn = GetProcAddressSafe(hxmpir, "xmpir_mpfr_yn");
    private static IntPtr __ptr__xmpir_mpfr_fma = GetProcAddressSafe(hxmpir, "xmpir_mpfr_fma");
    private static IntPtr __ptr__xmpir_mpfr_fms = GetProcAddressSafe(hxmpir, "xmpir_mpfr_fms");
    private static IntPtr __ptr__xmpir_mpfr_agm = GetProcAddressSafe(hxmpir, "xmpir_mpfr_agm");
    private static IntPtr __ptr__xmpir_mpfr_hypot = GetProcAddressSafe(hxmpir, "xmpir_mpfr_hypot");
    private static IntPtr __ptr__xmpir_mpfr_ai = GetProcAddressSafe(hxmpir, "xmpir_mpfr_ai");
    private static IntPtr __ptr__xmpir_mpfr_const_log2 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_const_log2");
    private static IntPtr __ptr__xmpir_mpfr_const_pi = GetProcAddressSafe(hxmpir, "xmpir_mpfr_const_pi");
    private static IntPtr __ptr__xmpir_mpfr_const_euler = GetProcAddressSafe(hxmpir, "xmpir_mpfr_const_euler");
    private static IntPtr __ptr__xmpir_mpfr_const_catalan = GetProcAddressSafe(hxmpir, "xmpir_mpfr_const_catalan");
    private static IntPtr __ptr__xmpir_mpfr_free_cache = GetProcAddressSafe(hxmpir, "xmpir_mpfr_free_cache");
    private static IntPtr __ptr__xmpir_mpfr_rint = GetProcAddressSafe(hxmpir, "xmpir_mpfr_rint");
    private static IntPtr __ptr__xmpir_mpfr_ceil = GetProcAddressSafe(hxmpir, "xmpir_mpfr_ceil");
    private static IntPtr __ptr__xmpir_mpfr_floor = GetProcAddressSafe(hxmpir, "xmpir_mpfr_floor");
    private static IntPtr __ptr__xmpir_mpfr_round = GetProcAddressSafe(hxmpir, "xmpir_mpfr_round");
    private static IntPtr __ptr__xmpir_mpfr_trunc = GetProcAddressSafe(hxmpir, "xmpir_mpfr_trunc");
    private static IntPtr __ptr__xmpir_mpfr_rint_ceil = GetProcAddressSafe(hxmpir, "xmpir_mpfr_rint_ceil");
    private static IntPtr __ptr__xmpir_mpfr_rint_floor = GetProcAddressSafe(hxmpir, "xmpir_mpfr_rint_floor");
    private static IntPtr __ptr__xmpir_mpfr_rint_round = GetProcAddressSafe(hxmpir, "xmpir_mpfr_rint_round");
    private static IntPtr __ptr__xmpir_mpfr_rint_trunc = GetProcAddressSafe(hxmpir, "xmpir_mpfr_rint_trunc");
    private static IntPtr __ptr__xmpir_mpfr_frac = GetProcAddressSafe(hxmpir, "xmpir_mpfr_frac");
    private static IntPtr __ptr__xmpir_mpfr_modf = GetProcAddressSafe(hxmpir, "xmpir_mpfr_modf");
    private static IntPtr __ptr__xmpir_mpfr_fmod = GetProcAddressSafe(hxmpir, "xmpir_mpfr_fmod");
    private static IntPtr __ptr__xmpir_mpfr_remainder = GetProcAddressSafe(hxmpir, "xmpir_mpfr_remainder");
    private static IntPtr __ptr__xmpir_mpfr_remquo = GetProcAddressSafe(hxmpir, "xmpir_mpfr_remquo");
    private static IntPtr __ptr__xmpir_mpfr_integer_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_integer_p");
    private static IntPtr __ptr__xmpir_mpfr_set_default_rounding_mode = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_default_rounding_mode");
    private static IntPtr __ptr__xmpir_mpfr_get_default_rounding_mode = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_default_rounding_mode");
    private static IntPtr __ptr__xmpir_mpfr_prec_round = GetProcAddressSafe(hxmpir, "xmpir_mpfr_prec_round");
    private static IntPtr __ptr__xmpir_mpfr_can_round = GetProcAddressSafe(hxmpir, "xmpir_mpfr_can_round");
    private static IntPtr __ptr__xmpir_mpfr_min_prec = GetProcAddressSafe(hxmpir, "xmpir_mpfr_min_prec");
    private static IntPtr __ptr__xmpir_mpfr_nexttoward = GetProcAddressSafe(hxmpir, "xmpir_mpfr_nexttoward");
    private static IntPtr __ptr__xmpir_mpfr_nextabove = GetProcAddressSafe(hxmpir, "xmpir_mpfr_nextabove");
    private static IntPtr __ptr__xmpir_mpfr_nextbelow = GetProcAddressSafe(hxmpir, "xmpir_mpfr_nextbelow");
    private static IntPtr __ptr__xmpir_mpfr_min = GetProcAddressSafe(hxmpir, "xmpir_mpfr_min");
    private static IntPtr __ptr__xmpir_mpfr_max = GetProcAddressSafe(hxmpir, "xmpir_mpfr_max");
    private static IntPtr __ptr__xmpir_mpfr_urandomb = GetProcAddressSafe(hxmpir, "xmpir_mpfr_urandomb");
    private static IntPtr __ptr__xmpir_mpfr_urandom = GetProcAddressSafe(hxmpir, "xmpir_mpfr_urandom");
    private static IntPtr __ptr__xmpir_mpfr_grandom = GetProcAddressSafe(hxmpir, "xmpir_mpfr_grandom");
    private static IntPtr __ptr__xmpir_mpfr_get_exp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_exp");
    private static IntPtr __ptr__xmpir_mpfr_set_exp = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_exp");
    private static IntPtr __ptr__xmpir_mpfr_signbit = GetProcAddressSafe(hxmpir, "xmpir_mpfr_signbit");
    private static IntPtr __ptr__xmpir_mpfr_setsign = GetProcAddressSafe(hxmpir, "xmpir_mpfr_setsign");
    private static IntPtr __ptr__xmpir_mpfr_copysign = GetProcAddressSafe(hxmpir, "xmpir_mpfr_copysign");
    private static IntPtr __ptr__xmpir_mpfr_buildopt_tls_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_buildopt_tls_p");
    private static IntPtr __ptr__xmpir_mpfr_buildopt_decimal_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_buildopt_decimal_p");
    private static IntPtr __ptr__xmpir_mpfr_get_emin = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_emin");
    private static IntPtr __ptr__xmpir_mpfr_get_emax = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_emax");
    private static IntPtr __ptr__xmpir_mpfr_set_emin = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_emin");
    private static IntPtr __ptr__xmpir_mpfr_set_emax = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_emax");
    private static IntPtr __ptr__xmpir_mpfr_get_emin_min = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_emin_min");
    private static IntPtr __ptr__xmpir_mpfr_get_emin_max = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_emin_max");
    private static IntPtr __ptr__xmpir_mpfr_get_emax_min = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_emax_min");
    private static IntPtr __ptr__xmpir_mpfr_get_emax_max = GetProcAddressSafe(hxmpir, "xmpir_mpfr_get_emax_max");
    private static IntPtr __ptr__xmpir_mpfr_check_range = GetProcAddressSafe(hxmpir, "xmpir_mpfr_check_range");
    private static IntPtr __ptr__xmpir_mpfr_subnormalize = GetProcAddressSafe(hxmpir, "xmpir_mpfr_subnormalize");
    private static IntPtr __ptr__xmpir_mpfr_clear_underflow = GetProcAddressSafe(hxmpir, "xmpir_mpfr_clear_underflow");
    private static IntPtr __ptr__xmpir_mpfr_clear_overflow = GetProcAddressSafe(hxmpir, "xmpir_mpfr_clear_overflow");
    private static IntPtr __ptr__xmpir_mpfr_clear_divby0 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_clear_divby0");
    private static IntPtr __ptr__xmpir_mpfr_clear_nanflag = GetProcAddressSafe(hxmpir, "xmpir_mpfr_clear_nanflag");
    private static IntPtr __ptr__xmpir_mpfr_clear_inexflag = GetProcAddressSafe(hxmpir, "xmpir_mpfr_clear_inexflag");
    private static IntPtr __ptr__xmpir_mpfr_clear_erangeflag = GetProcAddressSafe(hxmpir, "xmpir_mpfr_clear_erangeflag");
    private static IntPtr __ptr__xmpir_mpfr_clear_flags = GetProcAddressSafe(hxmpir, "xmpir_mpfr_clear_flags");
    private static IntPtr __ptr__xmpir_mpfr_set_underflow = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_underflow");
    private static IntPtr __ptr__xmpir_mpfr_set_overflow = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_overflow");
    private static IntPtr __ptr__xmpir_mpfr_set_divby0 = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_divby0");
    private static IntPtr __ptr__xmpir_mpfr_set_nanflag = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_nanflag");
    private static IntPtr __ptr__xmpir_mpfr_set_inexflag = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_inexflag");
    private static IntPtr __ptr__xmpir_mpfr_set_erangeflag = GetProcAddressSafe(hxmpir, "xmpir_mpfr_set_erangeflag");
    private static IntPtr __ptr__xmpir_mpfr_underflow_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_underflow_p");
    private static IntPtr __ptr__xmpir_mpfr_overflow_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_overflow_p");
    private static IntPtr __ptr__xmpir_mpfr_divby0_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_divby0_p");
    private static IntPtr __ptr__xmpir_mpfr_nanflag_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_nanflag_p");
    private static IntPtr __ptr__xmpir_mpfr_inexflag_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_inexflag_p");
    private static IntPtr __ptr__xmpir_mpfr_erangeflag_p = GetProcAddressSafe(hxmpir, "xmpir_mpfr_erangeflag_p");
    private static IntPtr __ptr__xmpir_mpc_set_prec = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_prec");
    private static IntPtr __ptr__xmpir_mpc_get_prec = GetProcAddressSafe(hxmpir, "xmpir_mpc_get_prec");
    private static IntPtr __ptr__xmpir_mpc_get_prec2 = GetProcAddressSafe(hxmpir, "xmpir_mpc_get_prec2");
    private static IntPtr __ptr__xmpir_mpc_set = GetProcAddressSafe(hxmpir, "xmpir_mpc_set");
    private static IntPtr __ptr__xmpir_mpc_set_ui = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_ui");
    private static IntPtr __ptr__xmpir_mpc_set_si = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_si");
    private static IntPtr __ptr__xmpir_mpc_set_d = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_d");
    private static IntPtr __ptr__xmpir_mpc_set_z = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_z");
    private static IntPtr __ptr__xmpir_mpc_set_q = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_q");
    private static IntPtr __ptr__xmpir_mpc_set_f = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_f");
    private static IntPtr __ptr__xmpir_mpc_set_fr = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_fr");
    private static IntPtr __ptr__xmpir_mpc_set_ui_ui = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_ui_ui");
    private static IntPtr __ptr__xmpir_mpc_set_si_si = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_si_si");
    private static IntPtr __ptr__xmpir_mpc_set_d_d = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_d_d");
    private static IntPtr __ptr__xmpir_mpc_set_z_z = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_z_z");
    private static IntPtr __ptr__xmpir_mpc_set_q_q = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_q_q");
    private static IntPtr __ptr__xmpir_mpc_set_f_f = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_f_f");
    private static IntPtr __ptr__xmpir_mpc_set_fr_fr = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_fr_fr");
    private static IntPtr __ptr__xmpir_mpc_set_nan = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_nan");
    private static IntPtr __ptr__xmpir_mpc_swap = GetProcAddressSafe(hxmpir, "xmpir_mpc_swap");
    private static IntPtr __ptr__xmpir_mpc_set_str = GetProcAddressSafe(hxmpir, "xmpir_mpc_set_str");
    private static IntPtr __ptr__xmpir_mpc_get_str = GetProcAddressSafe(hxmpir, "xmpir_mpc_get_str");
    private static IntPtr __ptr__xmpir_mpc_cmp = GetProcAddressSafe(hxmpir, "xmpir_mpc_cmp");
    private static IntPtr __ptr__xmpir_mpc_cmp_si_si = GetProcAddressSafe(hxmpir, "xmpir_mpc_cmp_si_si");
    private static IntPtr __ptr__xmpir_mpc_cmp_si = GetProcAddressSafe(hxmpir, "xmpir_mpc_cmp_si");
    private static IntPtr __ptr__xmpir_mpc_real = GetProcAddressSafe(hxmpir, "xmpir_mpc_real");
    private static IntPtr __ptr__xmpir_mpc_imag = GetProcAddressSafe(hxmpir, "xmpir_mpc_imag");
    private static IntPtr __ptr__xmpir_mpc_arg = GetProcAddressSafe(hxmpir, "xmpir_mpc_arg");
    private static IntPtr __ptr__xmpir_mpc_proj = GetProcAddressSafe(hxmpir, "xmpir_mpc_proj");
    private static IntPtr __ptr__xmpir_mpc_add = GetProcAddressSafe(hxmpir, "xmpir_mpc_add");
    private static IntPtr __ptr__xmpir_mpc_add_ui = GetProcAddressSafe(hxmpir, "xmpir_mpc_add_ui");
    private static IntPtr __ptr__xmpir_mpc_add_fr = GetProcAddressSafe(hxmpir, "xmpir_mpc_add_fr");
    private static IntPtr __ptr__xmpir_mpc_sub = GetProcAddressSafe(hxmpir, "xmpir_mpc_sub");
    private static IntPtr __ptr__xmpir_mpc_sub_fr = GetProcAddressSafe(hxmpir, "xmpir_mpc_sub_fr");
    private static IntPtr __ptr__xmpir_mpc_fr_sub = GetProcAddressSafe(hxmpir, "xmpir_mpc_fr_sub");
    private static IntPtr __ptr__xmpir_mpc_sub_ui = GetProcAddressSafe(hxmpir, "xmpir_mpc_sub_ui");
    private static IntPtr __ptr__xmpir_mpc_ui_sub = GetProcAddressSafe(hxmpir, "xmpir_mpc_ui_sub");
    private static IntPtr __ptr__xmpir_mpc_ui_ui_sub = GetProcAddressSafe(hxmpir, "xmpir_mpc_ui_ui_sub");
    private static IntPtr __ptr__xmpir_mpc_neg = GetProcAddressSafe(hxmpir, "xmpir_mpc_neg");
    private static IntPtr __ptr__xmpir_mpc_mul = GetProcAddressSafe(hxmpir, "xmpir_mpc_mul");
    private static IntPtr __ptr__xmpir_mpc_mul_ui = GetProcAddressSafe(hxmpir, "xmpir_mpc_mul_ui");
    private static IntPtr __ptr__xmpir_mpc_mul_si = GetProcAddressSafe(hxmpir, "xmpir_mpc_mul_si");
    private static IntPtr __ptr__xmpir_mpc_mul_fr = GetProcAddressSafe(hxmpir, "xmpir_mpc_mul_fr");
    private static IntPtr __ptr__xmpir_mpc_mul_i = GetProcAddressSafe(hxmpir, "xmpir_mpc_mul_i");
    private static IntPtr __ptr__xmpir_mpc_sqr = GetProcAddressSafe(hxmpir, "xmpir_mpc_sqr");
    private static IntPtr __ptr__xmpir_mpc_fma = GetProcAddressSafe(hxmpir, "xmpir_mpc_fma");
    private static IntPtr __ptr__xmpir_mpc_div = GetProcAddressSafe(hxmpir, "xmpir_mpc_div");
    private static IntPtr __ptr__xmpir_mpc_div_ui = GetProcAddressSafe(hxmpir, "xmpir_mpc_div_ui");
    private static IntPtr __ptr__xmpir_mpc_div_fr = GetProcAddressSafe(hxmpir, "xmpir_mpc_div_fr");
    private static IntPtr __ptr__xmpir_mpc_ui_div = GetProcAddressSafe(hxmpir, "xmpir_mpc_ui_div");
    private static IntPtr __ptr__xmpir_mpc_fr_div = GetProcAddressSafe(hxmpir, "xmpir_mpc_fr_div");
    private static IntPtr __ptr__xmpir_mpc_conj = GetProcAddressSafe(hxmpir, "xmpir_mpc_conj");
    private static IntPtr __ptr__xmpir_mpc_abs = GetProcAddressSafe(hxmpir, "xmpir_mpc_abs");
    private static IntPtr __ptr__xmpir_mpc_norm = GetProcAddressSafe(hxmpir, "xmpir_mpc_norm");
    private static IntPtr __ptr__xmpir_mpc_mul_2ui = GetProcAddressSafe(hxmpir, "xmpir_mpc_mul_2ui");
    private static IntPtr __ptr__xmpir_mpc_mul_2si = GetProcAddressSafe(hxmpir, "xmpir_mpc_mul_2si");
    private static IntPtr __ptr__xmpir_mpc_div_2ui = GetProcAddressSafe(hxmpir, "xmpir_mpc_div_2ui");
    private static IntPtr __ptr__xmpir_mpc_div_2si = GetProcAddressSafe(hxmpir, "xmpir_mpc_div_2si");
    private static IntPtr __ptr__xmpir_mpc_sqrt = GetProcAddressSafe(hxmpir, "xmpir_mpc_sqrt");
    private static IntPtr __ptr__xmpir_mpc_pow = GetProcAddressSafe(hxmpir, "xmpir_mpc_pow");
    private static IntPtr __ptr__xmpir_mpc_pow_d = GetProcAddressSafe(hxmpir, "xmpir_mpc_pow_d");
    private static IntPtr __ptr__xmpir_mpc_pow_si = GetProcAddressSafe(hxmpir, "xmpir_mpc_pow_si");
    private static IntPtr __ptr__xmpir_mpc_pow_ui = GetProcAddressSafe(hxmpir, "xmpir_mpc_pow_ui");
    private static IntPtr __ptr__xmpir_mpc_pow_z = GetProcAddressSafe(hxmpir, "xmpir_mpc_pow_z");
    private static IntPtr __ptr__xmpir_mpc_pow_fr = GetProcAddressSafe(hxmpir, "xmpir_mpc_pow_fr");
    private static IntPtr __ptr__xmpir_mpc_exp = GetProcAddressSafe(hxmpir, "xmpir_mpc_exp");
    private static IntPtr __ptr__xmpir_mpc_log = GetProcAddressSafe(hxmpir, "xmpir_mpc_log");
    private static IntPtr __ptr__xmpir_mpc_log10 = GetProcAddressSafe(hxmpir, "xmpir_mpc_log10");
    private static IntPtr __ptr__xmpir_mpc_sin = GetProcAddressSafe(hxmpir, "xmpir_mpc_sin");
    private static IntPtr __ptr__xmpir_mpc_cos = GetProcAddressSafe(hxmpir, "xmpir_mpc_cos");
    private static IntPtr __ptr__xmpir_mpc_sin_cos = GetProcAddressSafe(hxmpir, "xmpir_mpc_sin_cos");
    private static IntPtr __ptr__xmpir_mpc_tan = GetProcAddressSafe(hxmpir, "xmpir_mpc_tan");
    private static IntPtr __ptr__xmpir_mpc_sinh = GetProcAddressSafe(hxmpir, "xmpir_mpc_sinh");
    private static IntPtr __ptr__xmpir_mpc_cosh = GetProcAddressSafe(hxmpir, "xmpir_mpc_cosh");
    private static IntPtr __ptr__xmpir_mpc_tanh = GetProcAddressSafe(hxmpir, "xmpir_mpc_tanh");
    private static IntPtr __ptr__xmpir_mpc_asin = GetProcAddressSafe(hxmpir, "xmpir_mpc_asin");
    private static IntPtr __ptr__xmpir_mpc_acos = GetProcAddressSafe(hxmpir, "xmpir_mpc_acos");
    private static IntPtr __ptr__xmpir_mpc_atan = GetProcAddressSafe(hxmpir, "xmpir_mpc_atan");
    private static IntPtr __ptr__xmpir_mpc_asinh = GetProcAddressSafe(hxmpir, "xmpir_mpc_asinh");
    private static IntPtr __ptr__xmpir_mpc_acosh = GetProcAddressSafe(hxmpir, "xmpir_mpc_acosh");
    private static IntPtr __ptr__xmpir_mpc_atanh = GetProcAddressSafe(hxmpir, "xmpir_mpc_atanh");
    private static IntPtr __ptr__xmpir_mpc_urandom = GetProcAddressSafe(hxmpir, "xmpir_mpc_urandom");



    //
    // Automatically generated code: definitions
    //
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init(out IntPtr result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init2(out IntPtr result, ulong prec);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init_set(out IntPtr result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init_set_ui(out IntPtr result, uint op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init_set_si(out IntPtr result, int op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init_set_d(out IntPtr result, double op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_init_set_str(out IntPtr result, IntPtr str, uint _base);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_init(out IntPtr result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init(out IntPtr result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init2(out IntPtr result, ulong prec);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init_set(out IntPtr result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init_set_ui(out IntPtr result, uint op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init_set_si(out IntPtr result, int op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init_set_d(out IntPtr result, double op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_init_set_str(out IntPtr result, IntPtr str, uint _base);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_init(out IntPtr result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_init2(out IntPtr result, long prec);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_init_set(out IntPtr result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_init_set_ui(out IntPtr result, uint op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_init_set_si(out IntPtr result, int op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_init_set_d(out IntPtr result, double op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_init_set_z(out IntPtr result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_init_set_q(out IntPtr result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_init_set_f(out IntPtr result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_init_set_str(out IntPtr result, IntPtr str, uint _base, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_init2(out IntPtr result, long prec);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_init3(out IntPtr result, long prec_r, long prec_i);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_clear(IntPtr v);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_clear(IntPtr v);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_clear(IntPtr v);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_clear(IntPtr v);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_clear(IntPtr v);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_xmpir_dummy();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_xmpir_dummy_add(out int result, int a, int b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_xmpir_dummy_3mpz(out int result, IntPtr op0, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randinit_default(out IntPtr result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randinit_mt(out IntPtr result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randinit_lc_2exp(out IntPtr result, IntPtr a, uint c, ulong m2exp);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randinit_lc_2exp_size(out IntPtr result, ulong size);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randinit_set(out IntPtr result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randclear(IntPtr v);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randseed(IntPtr state, IntPtr seed);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_randseed_ui(IntPtr state, uint seed);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_urandomb_ui(out uint result, IntPtr state, uint n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_gmp_urandomm_ui(out uint result, IntPtr state, uint n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_realloc2(IntPtr x, uint n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_ui(IntPtr rop, uint op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_si(IntPtr rop, int op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_d(IntPtr rop, double op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_q(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_f(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_set_str(out int result, IntPtr rop, IntPtr str, uint _base);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_swap(IntPtr rop1, IntPtr rop2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_get_ui(out uint result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_get_si(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_get_d(out double result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_get_d_2exp(out double result, out int expptr, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_get_string(out IntPtr result, uint _base, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_add(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_add_ui(IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sub(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sub_ui(IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_ui_sub(IntPtr rop, uint op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mul(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mul_si(IntPtr rop, IntPtr op1, int op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mul_ui(IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_addmul(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_addmul_ui(IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_submul(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_submul_ui(IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mul_2exp(IntPtr rop, IntPtr op1, ulong op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_neg(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_abs(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_q(IntPtr q, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_r(IntPtr r, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_qr(IntPtr q, IntPtr r, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_q_ui(out uint result, IntPtr q, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_r_ui(out uint result, IntPtr r, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_qr_ui(out uint result, IntPtr q, IntPtr r, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_ui(out uint result, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_q_2exp(IntPtr q, IntPtr n, ulong b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cdiv_r_2exp(IntPtr r, IntPtr n, ulong b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_q(IntPtr q, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_r(IntPtr r, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_qr(IntPtr q, IntPtr r, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_q_ui(out uint result, IntPtr q, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_r_ui(out uint result, IntPtr r, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_qr_ui(out uint result, IntPtr q, IntPtr r, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_ui(out uint result, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_q_2exp(IntPtr q, IntPtr n, ulong b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fdiv_r_2exp(IntPtr r, IntPtr n, ulong b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_q(IntPtr q, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_r(IntPtr r, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_qr(IntPtr q, IntPtr r, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_q_ui(out uint result, IntPtr q, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_r_ui(out uint result, IntPtr r, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_qr_ui(out uint result, IntPtr q, IntPtr r, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_ui(out uint result, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_q_2exp(IntPtr q, IntPtr n, ulong b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tdiv_r_2exp(IntPtr r, IntPtr n, ulong b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mod(IntPtr r, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mod_ui(out uint result, IntPtr r, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_divexact(IntPtr q, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_divexact_ui(IntPtr q, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_divisible_p(out int result, IntPtr n, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_divisible_ui_p(out int result, IntPtr n, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_divisible_2exp_p(out int result, IntPtr n, ulong b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_congruent_p(out int result, IntPtr n, IntPtr c, IntPtr d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_congruent_ui_p(out int result, IntPtr n, uint c, uint d);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_congruent_2exp_p(out int result, IntPtr n, IntPtr c, ulong b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_powm(IntPtr rop, IntPtr _base, IntPtr _exp, IntPtr _mod);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_powm_ui(IntPtr rop, IntPtr _base, uint _exp, IntPtr _mod);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_pow_ui(IntPtr rop, IntPtr _base, uint _exp);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_ui_pow_ui(IntPtr rop, uint _base, uint _exp);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_root(out int result, IntPtr rop, IntPtr op, uint n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_nthroot(IntPtr rop, IntPtr op, uint n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_rootrem(IntPtr root, IntPtr rem, IntPtr u, uint n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sqrt(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sqrtrem(IntPtr rop1, IntPtr rop2, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_perfect_power_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_perfect_square_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_probable_prime_p(out int result, IntPtr n, IntPtr state, int prob, uint div);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_likely_prime_p(out int result, IntPtr n, IntPtr state, uint div);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_probab_prime_p(out int result, IntPtr n, uint reps);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_nextprime(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_next_prime_candidate(IntPtr rop, IntPtr op, IntPtr state);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_gcd(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_gcd_ui(out uint result, IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_gcdext(IntPtr g, IntPtr s, IntPtr t, IntPtr a, IntPtr b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_lcm(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_lcm_ui(IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_invert(out int result, IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_jacobi(out int result, IntPtr a, IntPtr b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_legendre(out int result, IntPtr a, IntPtr p);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_kronecker(out int result, IntPtr a, IntPtr b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_kronecker_si(out int result, IntPtr a, int b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_kronecker_ui(out int result, IntPtr a, uint b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_si_kronecker(out int result, int a, IntPtr b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_ui_kronecker(out int result, uint a, IntPtr b);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_remove(out ulong result, IntPtr rop, IntPtr op, IntPtr f);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fac_ui(IntPtr rop, uint op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_2fac_ui(IntPtr rop, uint op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_mfac_uiui(IntPtr rop, uint op, uint m);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_primorial_ui(IntPtr rop, uint op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_bin_ui(IntPtr rop, IntPtr n, uint k);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_bin_uiui(IntPtr rop, uint n, uint k);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fib_ui(IntPtr fn, uint n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fib2_ui(IntPtr fn, IntPtr fnsub1, uint n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_lucnum_ui(IntPtr ln, uint n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_lucnum2_ui(IntPtr ln, IntPtr lnsub1, uint n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmp(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmp_d(out int result, IntPtr op1, double op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmp_si(out int result, IntPtr op1, int op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmp_ui(out int result, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmpabs(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmpabs_d(out int result, IntPtr op1, double op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_cmpabs_ui(out int result, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sgn(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_and(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_ior(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_xor(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_com(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_popcount(out ulong result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_hamdist(out ulong result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_scan0(out ulong result, IntPtr op, ulong starting_bit);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_scan1(out ulong result, IntPtr op, ulong starting_bit);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_setbit(IntPtr rop, ulong bit_index);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_clrbit(IntPtr rop, ulong bit_index);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_combit(IntPtr rop, ulong bit_index);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_tstbit(out int result, IntPtr op, ulong bit_index);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_urandomb(IntPtr rop, IntPtr state, ulong n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_urandomm(IntPtr rop, IntPtr state, IntPtr n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_rrandomb(IntPtr rop, IntPtr state, ulong n);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fits_ulong_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fits_slong_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fits_uint_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fits_sint_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fits_ushort_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_fits_sshort_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_odd_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_even_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpz_sizeinbase(out ulong result, IntPtr op, uint _base);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_canonicalize(IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_z(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_ui(IntPtr rop, uint op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_si(IntPtr rop, int op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_str(out int result, IntPtr rop, IntPtr str, uint _base);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_swap(IntPtr rop1, IntPtr rop2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_get_d(out double result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_d(IntPtr rop, double op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_f(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_get_string(out IntPtr result, uint _base, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_add(IntPtr sum, IntPtr addend1, IntPtr addend2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_sub(IntPtr difference, IntPtr minuend, IntPtr subtrahend);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_mul(IntPtr product, IntPtr multiplier, IntPtr multiplicand);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_mul_2exp(IntPtr rop, IntPtr op1, ulong op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_div(IntPtr quotient, IntPtr dividend, IntPtr divisor);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_div_2exp(IntPtr rop, IntPtr op1, ulong op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_neg(IntPtr negated_operand, IntPtr operand);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_abs(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_inv(IntPtr inverted_number, IntPtr number);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_cmp(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_cmp_ui(out int result, IntPtr op1, uint num2, uint den2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_cmp_si(out int result, IntPtr op1, int num2, uint den2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_sgn(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_equal(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_get_num(IntPtr numerator, IntPtr rational);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_get_den(IntPtr denominator, IntPtr rational);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_num(IntPtr rational, IntPtr numerator);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpq_set_den(IntPtr rational, IntPtr denominator);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_default_prec(ulong prec);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_default_prec(out ulong result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_prec(out ulong result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_prec(IntPtr rop, ulong prec);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_prec_raw(IntPtr rop, ulong prec);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_ui(IntPtr rop, uint op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_si(IntPtr rop, int op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_d(IntPtr rop, double op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_z(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_q(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_set_str(out int result, IntPtr rop, IntPtr str, uint _base);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_swap(IntPtr rop1, IntPtr rop2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_d(out double result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_d_2exp(out double result, out int expptr, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_si(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_ui(out uint result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_get_string(out IntPtr result, out long expptr, uint _base, uint n_digits, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_add(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_add_ui(IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_sub(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_ui_sub(IntPtr rop, uint op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_sub_ui(IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_mul(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_mul_ui(IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_div(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_ui_div(IntPtr rop, uint op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_div_ui(IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_sqrt(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_sqrt_ui(IntPtr rop, uint op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_pow_ui(IntPtr rop, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_neg(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_abs(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_mul_2exp(IntPtr rop, IntPtr op1, ulong op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_div_2exp(IntPtr rop, IntPtr op1, ulong op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_cmp(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_cmp_d(out int result, IntPtr op1, double op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_cmp_ui(out int result, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_cmp_si(out int result, IntPtr op1, int op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_eq(out int result, IntPtr op1, IntPtr op2, ulong op3);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_reldiff(IntPtr rop, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_sgn(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_ceil(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_floor(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_trunc(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_integer_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_fits_ulong_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_fits_slong_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_fits_uint_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_fits_sint_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_fits_ushort_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_fits_sshort_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_urandomb(IntPtr rop, IntPtr state, ulong nbits);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpf_rrandomb(IntPtr rop, IntPtr state, long max_size, long exp);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_default_prec(long prec);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_default_prec(out long result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_prec(IntPtr rop, long prec);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_prec(out long result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_ui(out int result, IntPtr rop, uint op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_si(out int result, IntPtr rop, int op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_d(out int result, IntPtr rop, double op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_z(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_q(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_f(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_str(out int result, IntPtr rop, IntPtr str, uint _base, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_ui_2exp(out int result, IntPtr rop, uint op, long e, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_si_2exp(out int result, IntPtr rop, int op, long e, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_z_2exp(out int result, IntPtr rop, IntPtr op, long e, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_nan(IntPtr rop);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_inf(IntPtr rop, int sign);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_zero(IntPtr rop, int sign);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_swap(IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_d(out double result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_si(out int result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_ui(out uint result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_d_2exp(out double result, out int expptr, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_frexp(out int result, out long expptr, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_z_2exp(out long result, IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_z(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_f(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_str(out IntPtr result, IntPtr str, out long expptr, uint _base, uint n_digits, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_fits_ulong_p(out int result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_fits_slong_p(out int result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_fits_uint_p(out int result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_fits_sint_p(out int result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_fits_ushort_p(out int result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_fits_sshort_p(out int result, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_add(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_add_ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_add_si(out int result, IntPtr rop, IntPtr op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_add_d(out int result, IntPtr rop, IntPtr op1, double op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_add_z(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_add_q(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sub(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_ui_sub(out int result, IntPtr rop, uint op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sub_ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_si_sub(out int result, IntPtr rop, int op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sub_si(out int result, IntPtr rop, IntPtr op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_d_sub(out int result, IntPtr rop, double op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sub_d(out int result, IntPtr rop, IntPtr op1, double op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_z_sub(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sub_z(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sub_q(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_mul(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_mul_ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_mul_si(out int result, IntPtr rop, IntPtr op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_mul_d(out int result, IntPtr rop, IntPtr op1, double op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_mul_z(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_mul_q(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sqr(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_div(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_ui_div(out int result, IntPtr rop, uint op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_div_ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_si_div(out int result, IntPtr rop, int op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_div_si(out int result, IntPtr rop, IntPtr op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_d_div(out int result, IntPtr rop, double op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_div_d(out int result, IntPtr rop, IntPtr op1, double op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_div_z(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_div_q(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sqrt(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sqrt_ui(out int result, IntPtr rop, uint op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_rec_sqrt(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cbrt(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_root(out int result, IntPtr rop, IntPtr op, uint k, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_pow(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_pow_ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_pow_si(out int result, IntPtr rop, IntPtr op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_pow_z(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_ui_pow_ui(out int result, IntPtr rop, uint op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_ui_pow(out int result, IntPtr rop, uint op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_neg(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_abs(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_dim(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_mul_2ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_mul_2si(out int result, IntPtr rop, IntPtr op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_div_2ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_div_2si(out int result, IntPtr rop, IntPtr op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cmp(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cmp_d(out int result, IntPtr op1, double op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cmp_ui(out int result, IntPtr op1, uint op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cmp_si(out int result, IntPtr op1, int op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cmp_z(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cmp_q(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cmp_f(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cmp_ui_2exp(out int result, IntPtr op1, uint op2, long e);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cmp_si_2exp(out int result, IntPtr op1, int op2, long e);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cmpabs(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_nan_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_inf_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_number_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_zero_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_regular_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sgn(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_greater_p(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_greaterequal_p(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_less_p(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_lessequal_p(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_equal_p(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_lessgreater_p(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_unordered_p(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_log(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_log2(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_log10(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_exp(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_exp2(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_exp10(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cos(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sin(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_tan(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sin_cos(out int result, IntPtr sop, IntPtr cop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sec(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_csc(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cot(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_acos(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_asin(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_atan(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_atan2(out int result, IntPtr rop, IntPtr y, IntPtr x, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_cosh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sinh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_tanh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sinh_cosh(out int result, IntPtr sop, IntPtr cop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_sech(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_csch(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_coth(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_acosh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_asinh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_atanh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_fac_ui(out int result, IntPtr rop, uint op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_log1p(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_expm1(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_eint(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_li2(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_gamma(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_lngamma(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_lgamma(out int result, IntPtr rop, out int signp, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_digamma(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_zeta(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_zeta_ui(out int result, IntPtr rop, uint op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_erf(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_erfc(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_j0(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_j1(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_jn(out int result, IntPtr rop, int n, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_y0(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_y1(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_yn(out int result, IntPtr rop, int n, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_fma(out int result, IntPtr rop, IntPtr op1, IntPtr op2, IntPtr op3, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_fms(out int result, IntPtr rop, IntPtr op1, IntPtr op2, IntPtr op3, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_agm(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_hypot(out int result, IntPtr rop, IntPtr x, IntPtr y, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_ai(out int result, IntPtr rop, IntPtr x, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_const_log2(out int result, IntPtr rop, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_const_pi(out int result, IntPtr rop, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_const_euler(out int result, IntPtr rop, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_const_catalan(out int result, IntPtr rop, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_free_cache();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_rint(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_ceil(out int result, IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_floor(out int result, IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_round(out int result, IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_trunc(out int result, IntPtr rop, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_rint_ceil(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_rint_floor(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_rint_round(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_rint_trunc(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_frac(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_modf(out int result, IntPtr iop, IntPtr fop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_fmod(out int result, IntPtr r, IntPtr x, IntPtr y, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_remainder(out int result, IntPtr r, IntPtr x, IntPtr y, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_remquo(out int result, IntPtr r, out int q, IntPtr x, IntPtr y, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_integer_p(out int result, IntPtr op);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_default_rounding_mode(int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_default_rounding_mode(out int result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_prec_round(out int result, IntPtr x, long prec, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_can_round(out int result, IntPtr b, long err, int rnd1, int rnd2, long prec);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_min_prec(out long result, IntPtr x);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_nexttoward(IntPtr x, IntPtr y);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_nextabove(IntPtr x);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_nextbelow(IntPtr x);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_min(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_max(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_urandomb(out int result, IntPtr rop, IntPtr state);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_urandom(out int result, IntPtr rop, IntPtr state, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_grandom(out int result, IntPtr rop1, IntPtr rop2, IntPtr state, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_exp(out long result, IntPtr x);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_exp(out int result, IntPtr x, long e);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_signbit(out int result, IntPtr x);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_setsign(out int result, IntPtr rop, IntPtr op, int s, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_copysign(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_buildopt_tls_p(out int result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_buildopt_decimal_p(out int result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_emin(out long result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_emax(out long result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_emin(out int result, long exp);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_emax(out int result, long exp);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_emin_min(out long result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_emin_max(out long result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_emax_min(out long result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_get_emax_max(out long result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_check_range(out int result, IntPtr x, int t, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_subnormalize(out int result, IntPtr x, int t, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_clear_underflow();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_clear_overflow();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_clear_divby0();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_clear_nanflag();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_clear_inexflag();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_clear_erangeflag();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_clear_flags();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_underflow();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_overflow();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_divby0();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_nanflag();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_inexflag();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_set_erangeflag();
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_underflow_p(out int result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_overflow_p(out int result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_divby0_p(out int result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_nanflag_p(out int result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_inexflag_p(out int result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpfr_erangeflag_p(out int result);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_prec(IntPtr x, long prec);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_get_prec(out long result, IntPtr x);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_get_prec2(out long pr, out long pi, IntPtr x);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_ui(out int result, IntPtr rop, uint op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_si(out int result, IntPtr rop, int op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_d(out int result, IntPtr rop, double op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_z(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_q(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_f(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_fr(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_ui_ui(out int result, IntPtr rop, uint op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_si_si(out int result, IntPtr rop, int op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_d_d(out int result, IntPtr rop, double op1, double op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_z_z(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_q_q(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_f_f(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_fr_fr(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_nan(IntPtr rop);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_swap(IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_set_str(out int result, IntPtr rop, IntPtr str, int _base, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_get_str(out IntPtr result, int _base, uint n, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_cmp(out int result, IntPtr op1, IntPtr op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_cmp_si_si(out int result, IntPtr op1, int op2r, int op2i);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_cmp_si(out int result, IntPtr op1, int op2);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_real(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_imag(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_arg(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_proj(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_add(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_add_ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_add_fr(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_sub(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_sub_fr(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_fr_sub(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_sub_ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_ui_sub(out int result, IntPtr rop, uint op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_ui_ui_sub(out int result, IntPtr rop, uint re1, uint im1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_neg(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_mul(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_mul_ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_mul_si(out int result, IntPtr rop, IntPtr op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_mul_fr(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_mul_i(out int result, IntPtr rop, IntPtr op, int sgn, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_sqr(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_fma(out int result, IntPtr rop, IntPtr op1, IntPtr op2, IntPtr op3, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_div(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_div_ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_div_fr(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_ui_div(out int result, IntPtr rop, uint op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_fr_div(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_conj(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_abs(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_norm(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_mul_2ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_mul_2si(out int result, IntPtr rop, IntPtr op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_div_2ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_div_2si(out int result, IntPtr rop, IntPtr op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_sqrt(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_pow(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_pow_d(out int result, IntPtr rop, IntPtr op1, double op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_pow_si(out int result, IntPtr rop, IntPtr op1, int op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_pow_ui(out int result, IntPtr rop, IntPtr op1, uint op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_pow_z(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_pow_fr(out int result, IntPtr rop, IntPtr op1, IntPtr op2, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_exp(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_log(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_log10(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_sin(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_cos(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_sin_cos(out int result, IntPtr rop_sin, IntPtr rop_cos, IntPtr op, int rnd_sin, int rnd_cos);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_tan(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_sinh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_cosh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_tanh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_asin(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_acos(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_atan(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_asinh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_acosh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_atanh(out int result, IntPtr rop, IntPtr op, int rnd);
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate int __xmpir_mpc_urandom(out int result, IntPtr rop, IntPtr state);



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
    private static __xmpir_mpfr_init xmpir_mpfr_init = (__xmpir_mpfr_init)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_init, typeof(__xmpir_mpfr_init));
    private static __xmpir_mpfr_init2 xmpir_mpfr_init2 = (__xmpir_mpfr_init2)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_init2, typeof(__xmpir_mpfr_init2));
    private static __xmpir_mpfr_init_set xmpir_mpfr_init_set = (__xmpir_mpfr_init_set)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_init_set, typeof(__xmpir_mpfr_init_set));
    private static __xmpir_mpfr_init_set_ui xmpir_mpfr_init_set_ui = (__xmpir_mpfr_init_set_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_init_set_ui, typeof(__xmpir_mpfr_init_set_ui));
    private static __xmpir_mpfr_init_set_si xmpir_mpfr_init_set_si = (__xmpir_mpfr_init_set_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_init_set_si, typeof(__xmpir_mpfr_init_set_si));
    private static __xmpir_mpfr_init_set_d xmpir_mpfr_init_set_d = (__xmpir_mpfr_init_set_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_init_set_d, typeof(__xmpir_mpfr_init_set_d));
    private static __xmpir_mpfr_init_set_z xmpir_mpfr_init_set_z = (__xmpir_mpfr_init_set_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_init_set_z, typeof(__xmpir_mpfr_init_set_z));
    private static __xmpir_mpfr_init_set_q xmpir_mpfr_init_set_q = (__xmpir_mpfr_init_set_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_init_set_q, typeof(__xmpir_mpfr_init_set_q));
    private static __xmpir_mpfr_init_set_f xmpir_mpfr_init_set_f = (__xmpir_mpfr_init_set_f)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_init_set_f, typeof(__xmpir_mpfr_init_set_f));
    private static __xmpir_mpfr_init_set_str xmpir_mpfr_init_set_str = (__xmpir_mpfr_init_set_str)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_init_set_str, typeof(__xmpir_mpfr_init_set_str));
    private static __xmpir_mpc_init2 xmpir_mpc_init2 = (__xmpir_mpc_init2)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_init2, typeof(__xmpir_mpc_init2));
    private static __xmpir_mpc_init3 xmpir_mpc_init3 = (__xmpir_mpc_init3)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_init3, typeof(__xmpir_mpc_init3));
    private static __xmpir_mpz_clear xmpir_mpz_clear = (__xmpir_mpz_clear)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_clear, typeof(__xmpir_mpz_clear));
    private static __xmpir_mpq_clear xmpir_mpq_clear = (__xmpir_mpq_clear)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpq_clear, typeof(__xmpir_mpq_clear));
    private static __xmpir_mpf_clear xmpir_mpf_clear = (__xmpir_mpf_clear)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_clear, typeof(__xmpir_mpf_clear));
    private static __xmpir_mpfr_clear xmpir_mpfr_clear = (__xmpir_mpfr_clear)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_clear, typeof(__xmpir_mpfr_clear));
    private static __xmpir_mpc_clear xmpir_mpc_clear = (__xmpir_mpc_clear)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_clear, typeof(__xmpir_mpc_clear));
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
    private static __xmpir_mpz_fits_ulong_p xmpir_mpz_fits_ulong_p = (__xmpir_mpz_fits_ulong_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fits_ulong_p, typeof(__xmpir_mpz_fits_ulong_p));
    private static __xmpir_mpz_fits_slong_p xmpir_mpz_fits_slong_p = (__xmpir_mpz_fits_slong_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fits_slong_p, typeof(__xmpir_mpz_fits_slong_p));
    private static __xmpir_mpz_fits_uint_p xmpir_mpz_fits_uint_p = (__xmpir_mpz_fits_uint_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fits_uint_p, typeof(__xmpir_mpz_fits_uint_p));
    private static __xmpir_mpz_fits_sint_p xmpir_mpz_fits_sint_p = (__xmpir_mpz_fits_sint_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fits_sint_p, typeof(__xmpir_mpz_fits_sint_p));
    private static __xmpir_mpz_fits_ushort_p xmpir_mpz_fits_ushort_p = (__xmpir_mpz_fits_ushort_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fits_ushort_p, typeof(__xmpir_mpz_fits_ushort_p));
    private static __xmpir_mpz_fits_sshort_p xmpir_mpz_fits_sshort_p = (__xmpir_mpz_fits_sshort_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpz_fits_sshort_p, typeof(__xmpir_mpz_fits_sshort_p));
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
    private static __xmpir_mpf_set_default_prec xmpir_mpf_set_default_prec = (__xmpir_mpf_set_default_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set_default_prec, typeof(__xmpir_mpf_set_default_prec));
    private static __xmpir_mpf_get_default_prec xmpir_mpf_get_default_prec = (__xmpir_mpf_get_default_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_get_default_prec, typeof(__xmpir_mpf_get_default_prec));
    private static __xmpir_mpf_get_prec xmpir_mpf_get_prec = (__xmpir_mpf_get_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_get_prec, typeof(__xmpir_mpf_get_prec));
    private static __xmpir_mpf_set_prec xmpir_mpf_set_prec = (__xmpir_mpf_set_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set_prec, typeof(__xmpir_mpf_set_prec));
    private static __xmpir_mpf_set_prec_raw xmpir_mpf_set_prec_raw = (__xmpir_mpf_set_prec_raw)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_set_prec_raw, typeof(__xmpir_mpf_set_prec_raw));
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
    private static __xmpir_mpf_fits_ulong_p xmpir_mpf_fits_ulong_p = (__xmpir_mpf_fits_ulong_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_fits_ulong_p, typeof(__xmpir_mpf_fits_ulong_p));
    private static __xmpir_mpf_fits_slong_p xmpir_mpf_fits_slong_p = (__xmpir_mpf_fits_slong_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_fits_slong_p, typeof(__xmpir_mpf_fits_slong_p));
    private static __xmpir_mpf_fits_uint_p xmpir_mpf_fits_uint_p = (__xmpir_mpf_fits_uint_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_fits_uint_p, typeof(__xmpir_mpf_fits_uint_p));
    private static __xmpir_mpf_fits_sint_p xmpir_mpf_fits_sint_p = (__xmpir_mpf_fits_sint_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_fits_sint_p, typeof(__xmpir_mpf_fits_sint_p));
    private static __xmpir_mpf_fits_ushort_p xmpir_mpf_fits_ushort_p = (__xmpir_mpf_fits_ushort_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_fits_ushort_p, typeof(__xmpir_mpf_fits_ushort_p));
    private static __xmpir_mpf_fits_sshort_p xmpir_mpf_fits_sshort_p = (__xmpir_mpf_fits_sshort_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_fits_sshort_p, typeof(__xmpir_mpf_fits_sshort_p));
    private static __xmpir_mpf_urandomb xmpir_mpf_urandomb = (__xmpir_mpf_urandomb)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_urandomb, typeof(__xmpir_mpf_urandomb));
    private static __xmpir_mpf_rrandomb xmpir_mpf_rrandomb = (__xmpir_mpf_rrandomb)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpf_rrandomb, typeof(__xmpir_mpf_rrandomb));
    private static __xmpir_mpfr_set_default_prec xmpir_mpfr_set_default_prec = (__xmpir_mpfr_set_default_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_default_prec, typeof(__xmpir_mpfr_set_default_prec));
    private static __xmpir_mpfr_get_default_prec xmpir_mpfr_get_default_prec = (__xmpir_mpfr_get_default_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_default_prec, typeof(__xmpir_mpfr_get_default_prec));
    private static __xmpir_mpfr_set_prec xmpir_mpfr_set_prec = (__xmpir_mpfr_set_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_prec, typeof(__xmpir_mpfr_set_prec));
    private static __xmpir_mpfr_get_prec xmpir_mpfr_get_prec = (__xmpir_mpfr_get_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_prec, typeof(__xmpir_mpfr_get_prec));
    private static __xmpir_mpfr_set xmpir_mpfr_set = (__xmpir_mpfr_set)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set, typeof(__xmpir_mpfr_set));
    private static __xmpir_mpfr_set_ui xmpir_mpfr_set_ui = (__xmpir_mpfr_set_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_ui, typeof(__xmpir_mpfr_set_ui));
    private static __xmpir_mpfr_set_si xmpir_mpfr_set_si = (__xmpir_mpfr_set_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_si, typeof(__xmpir_mpfr_set_si));
    private static __xmpir_mpfr_set_d xmpir_mpfr_set_d = (__xmpir_mpfr_set_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_d, typeof(__xmpir_mpfr_set_d));
    private static __xmpir_mpfr_set_z xmpir_mpfr_set_z = (__xmpir_mpfr_set_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_z, typeof(__xmpir_mpfr_set_z));
    private static __xmpir_mpfr_set_q xmpir_mpfr_set_q = (__xmpir_mpfr_set_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_q, typeof(__xmpir_mpfr_set_q));
    private static __xmpir_mpfr_set_f xmpir_mpfr_set_f = (__xmpir_mpfr_set_f)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_f, typeof(__xmpir_mpfr_set_f));
    private static __xmpir_mpfr_set_str xmpir_mpfr_set_str = (__xmpir_mpfr_set_str)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_str, typeof(__xmpir_mpfr_set_str));
    private static __xmpir_mpfr_set_ui_2exp xmpir_mpfr_set_ui_2exp = (__xmpir_mpfr_set_ui_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_ui_2exp, typeof(__xmpir_mpfr_set_ui_2exp));
    private static __xmpir_mpfr_set_si_2exp xmpir_mpfr_set_si_2exp = (__xmpir_mpfr_set_si_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_si_2exp, typeof(__xmpir_mpfr_set_si_2exp));
    private static __xmpir_mpfr_set_z_2exp xmpir_mpfr_set_z_2exp = (__xmpir_mpfr_set_z_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_z_2exp, typeof(__xmpir_mpfr_set_z_2exp));
    private static __xmpir_mpfr_set_nan xmpir_mpfr_set_nan = (__xmpir_mpfr_set_nan)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_nan, typeof(__xmpir_mpfr_set_nan));
    private static __xmpir_mpfr_set_inf xmpir_mpfr_set_inf = (__xmpir_mpfr_set_inf)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_inf, typeof(__xmpir_mpfr_set_inf));
    private static __xmpir_mpfr_set_zero xmpir_mpfr_set_zero = (__xmpir_mpfr_set_zero)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_zero, typeof(__xmpir_mpfr_set_zero));
    private static __xmpir_mpfr_swap xmpir_mpfr_swap = (__xmpir_mpfr_swap)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_swap, typeof(__xmpir_mpfr_swap));
    private static __xmpir_mpfr_get_d xmpir_mpfr_get_d = (__xmpir_mpfr_get_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_d, typeof(__xmpir_mpfr_get_d));
    private static __xmpir_mpfr_get_si xmpir_mpfr_get_si = (__xmpir_mpfr_get_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_si, typeof(__xmpir_mpfr_get_si));
    private static __xmpir_mpfr_get_ui xmpir_mpfr_get_ui = (__xmpir_mpfr_get_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_ui, typeof(__xmpir_mpfr_get_ui));
    private static __xmpir_mpfr_get_d_2exp xmpir_mpfr_get_d_2exp = (__xmpir_mpfr_get_d_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_d_2exp, typeof(__xmpir_mpfr_get_d_2exp));
    private static __xmpir_mpfr_frexp xmpir_mpfr_frexp = (__xmpir_mpfr_frexp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_frexp, typeof(__xmpir_mpfr_frexp));
    private static __xmpir_mpfr_get_z_2exp xmpir_mpfr_get_z_2exp = (__xmpir_mpfr_get_z_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_z_2exp, typeof(__xmpir_mpfr_get_z_2exp));
    private static __xmpir_mpfr_get_z xmpir_mpfr_get_z = (__xmpir_mpfr_get_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_z, typeof(__xmpir_mpfr_get_z));
    private static __xmpir_mpfr_get_f xmpir_mpfr_get_f = (__xmpir_mpfr_get_f)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_f, typeof(__xmpir_mpfr_get_f));
    private static __xmpir_mpfr_get_str xmpir_mpfr_get_str = (__xmpir_mpfr_get_str)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_str, typeof(__xmpir_mpfr_get_str));
    private static __xmpir_mpfr_fits_ulong_p xmpir_mpfr_fits_ulong_p = (__xmpir_mpfr_fits_ulong_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_fits_ulong_p, typeof(__xmpir_mpfr_fits_ulong_p));
    private static __xmpir_mpfr_fits_slong_p xmpir_mpfr_fits_slong_p = (__xmpir_mpfr_fits_slong_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_fits_slong_p, typeof(__xmpir_mpfr_fits_slong_p));
    private static __xmpir_mpfr_fits_uint_p xmpir_mpfr_fits_uint_p = (__xmpir_mpfr_fits_uint_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_fits_uint_p, typeof(__xmpir_mpfr_fits_uint_p));
    private static __xmpir_mpfr_fits_sint_p xmpir_mpfr_fits_sint_p = (__xmpir_mpfr_fits_sint_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_fits_sint_p, typeof(__xmpir_mpfr_fits_sint_p));
    private static __xmpir_mpfr_fits_ushort_p xmpir_mpfr_fits_ushort_p = (__xmpir_mpfr_fits_ushort_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_fits_ushort_p, typeof(__xmpir_mpfr_fits_ushort_p));
    private static __xmpir_mpfr_fits_sshort_p xmpir_mpfr_fits_sshort_p = (__xmpir_mpfr_fits_sshort_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_fits_sshort_p, typeof(__xmpir_mpfr_fits_sshort_p));
    private static __xmpir_mpfr_add xmpir_mpfr_add = (__xmpir_mpfr_add)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_add, typeof(__xmpir_mpfr_add));
    private static __xmpir_mpfr_add_ui xmpir_mpfr_add_ui = (__xmpir_mpfr_add_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_add_ui, typeof(__xmpir_mpfr_add_ui));
    private static __xmpir_mpfr_add_si xmpir_mpfr_add_si = (__xmpir_mpfr_add_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_add_si, typeof(__xmpir_mpfr_add_si));
    private static __xmpir_mpfr_add_d xmpir_mpfr_add_d = (__xmpir_mpfr_add_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_add_d, typeof(__xmpir_mpfr_add_d));
    private static __xmpir_mpfr_add_z xmpir_mpfr_add_z = (__xmpir_mpfr_add_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_add_z, typeof(__xmpir_mpfr_add_z));
    private static __xmpir_mpfr_add_q xmpir_mpfr_add_q = (__xmpir_mpfr_add_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_add_q, typeof(__xmpir_mpfr_add_q));
    private static __xmpir_mpfr_sub xmpir_mpfr_sub = (__xmpir_mpfr_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sub, typeof(__xmpir_mpfr_sub));
    private static __xmpir_mpfr_ui_sub xmpir_mpfr_ui_sub = (__xmpir_mpfr_ui_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_ui_sub, typeof(__xmpir_mpfr_ui_sub));
    private static __xmpir_mpfr_sub_ui xmpir_mpfr_sub_ui = (__xmpir_mpfr_sub_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sub_ui, typeof(__xmpir_mpfr_sub_ui));
    private static __xmpir_mpfr_si_sub xmpir_mpfr_si_sub = (__xmpir_mpfr_si_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_si_sub, typeof(__xmpir_mpfr_si_sub));
    private static __xmpir_mpfr_sub_si xmpir_mpfr_sub_si = (__xmpir_mpfr_sub_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sub_si, typeof(__xmpir_mpfr_sub_si));
    private static __xmpir_mpfr_d_sub xmpir_mpfr_d_sub = (__xmpir_mpfr_d_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_d_sub, typeof(__xmpir_mpfr_d_sub));
    private static __xmpir_mpfr_sub_d xmpir_mpfr_sub_d = (__xmpir_mpfr_sub_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sub_d, typeof(__xmpir_mpfr_sub_d));
    private static __xmpir_mpfr_z_sub xmpir_mpfr_z_sub = (__xmpir_mpfr_z_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_z_sub, typeof(__xmpir_mpfr_z_sub));
    private static __xmpir_mpfr_sub_z xmpir_mpfr_sub_z = (__xmpir_mpfr_sub_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sub_z, typeof(__xmpir_mpfr_sub_z));
    private static __xmpir_mpfr_sub_q xmpir_mpfr_sub_q = (__xmpir_mpfr_sub_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sub_q, typeof(__xmpir_mpfr_sub_q));
    private static __xmpir_mpfr_mul xmpir_mpfr_mul = (__xmpir_mpfr_mul)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_mul, typeof(__xmpir_mpfr_mul));
    private static __xmpir_mpfr_mul_ui xmpir_mpfr_mul_ui = (__xmpir_mpfr_mul_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_mul_ui, typeof(__xmpir_mpfr_mul_ui));
    private static __xmpir_mpfr_mul_si xmpir_mpfr_mul_si = (__xmpir_mpfr_mul_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_mul_si, typeof(__xmpir_mpfr_mul_si));
    private static __xmpir_mpfr_mul_d xmpir_mpfr_mul_d = (__xmpir_mpfr_mul_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_mul_d, typeof(__xmpir_mpfr_mul_d));
    private static __xmpir_mpfr_mul_z xmpir_mpfr_mul_z = (__xmpir_mpfr_mul_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_mul_z, typeof(__xmpir_mpfr_mul_z));
    private static __xmpir_mpfr_mul_q xmpir_mpfr_mul_q = (__xmpir_mpfr_mul_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_mul_q, typeof(__xmpir_mpfr_mul_q));
    private static __xmpir_mpfr_sqr xmpir_mpfr_sqr = (__xmpir_mpfr_sqr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sqr, typeof(__xmpir_mpfr_sqr));
    private static __xmpir_mpfr_div xmpir_mpfr_div = (__xmpir_mpfr_div)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_div, typeof(__xmpir_mpfr_div));
    private static __xmpir_mpfr_ui_div xmpir_mpfr_ui_div = (__xmpir_mpfr_ui_div)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_ui_div, typeof(__xmpir_mpfr_ui_div));
    private static __xmpir_mpfr_div_ui xmpir_mpfr_div_ui = (__xmpir_mpfr_div_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_div_ui, typeof(__xmpir_mpfr_div_ui));
    private static __xmpir_mpfr_si_div xmpir_mpfr_si_div = (__xmpir_mpfr_si_div)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_si_div, typeof(__xmpir_mpfr_si_div));
    private static __xmpir_mpfr_div_si xmpir_mpfr_div_si = (__xmpir_mpfr_div_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_div_si, typeof(__xmpir_mpfr_div_si));
    private static __xmpir_mpfr_d_div xmpir_mpfr_d_div = (__xmpir_mpfr_d_div)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_d_div, typeof(__xmpir_mpfr_d_div));
    private static __xmpir_mpfr_div_d xmpir_mpfr_div_d = (__xmpir_mpfr_div_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_div_d, typeof(__xmpir_mpfr_div_d));
    private static __xmpir_mpfr_div_z xmpir_mpfr_div_z = (__xmpir_mpfr_div_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_div_z, typeof(__xmpir_mpfr_div_z));
    private static __xmpir_mpfr_div_q xmpir_mpfr_div_q = (__xmpir_mpfr_div_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_div_q, typeof(__xmpir_mpfr_div_q));
    private static __xmpir_mpfr_sqrt xmpir_mpfr_sqrt = (__xmpir_mpfr_sqrt)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sqrt, typeof(__xmpir_mpfr_sqrt));
    private static __xmpir_mpfr_sqrt_ui xmpir_mpfr_sqrt_ui = (__xmpir_mpfr_sqrt_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sqrt_ui, typeof(__xmpir_mpfr_sqrt_ui));
    private static __xmpir_mpfr_rec_sqrt xmpir_mpfr_rec_sqrt = (__xmpir_mpfr_rec_sqrt)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_rec_sqrt, typeof(__xmpir_mpfr_rec_sqrt));
    private static __xmpir_mpfr_cbrt xmpir_mpfr_cbrt = (__xmpir_mpfr_cbrt)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cbrt, typeof(__xmpir_mpfr_cbrt));
    private static __xmpir_mpfr_root xmpir_mpfr_root = (__xmpir_mpfr_root)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_root, typeof(__xmpir_mpfr_root));
    private static __xmpir_mpfr_pow xmpir_mpfr_pow = (__xmpir_mpfr_pow)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_pow, typeof(__xmpir_mpfr_pow));
    private static __xmpir_mpfr_pow_ui xmpir_mpfr_pow_ui = (__xmpir_mpfr_pow_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_pow_ui, typeof(__xmpir_mpfr_pow_ui));
    private static __xmpir_mpfr_pow_si xmpir_mpfr_pow_si = (__xmpir_mpfr_pow_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_pow_si, typeof(__xmpir_mpfr_pow_si));
    private static __xmpir_mpfr_pow_z xmpir_mpfr_pow_z = (__xmpir_mpfr_pow_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_pow_z, typeof(__xmpir_mpfr_pow_z));
    private static __xmpir_mpfr_ui_pow_ui xmpir_mpfr_ui_pow_ui = (__xmpir_mpfr_ui_pow_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_ui_pow_ui, typeof(__xmpir_mpfr_ui_pow_ui));
    private static __xmpir_mpfr_ui_pow xmpir_mpfr_ui_pow = (__xmpir_mpfr_ui_pow)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_ui_pow, typeof(__xmpir_mpfr_ui_pow));
    private static __xmpir_mpfr_neg xmpir_mpfr_neg = (__xmpir_mpfr_neg)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_neg, typeof(__xmpir_mpfr_neg));
    private static __xmpir_mpfr_abs xmpir_mpfr_abs = (__xmpir_mpfr_abs)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_abs, typeof(__xmpir_mpfr_abs));
    private static __xmpir_mpfr_dim xmpir_mpfr_dim = (__xmpir_mpfr_dim)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_dim, typeof(__xmpir_mpfr_dim));
    private static __xmpir_mpfr_mul_2ui xmpir_mpfr_mul_2ui = (__xmpir_mpfr_mul_2ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_mul_2ui, typeof(__xmpir_mpfr_mul_2ui));
    private static __xmpir_mpfr_mul_2si xmpir_mpfr_mul_2si = (__xmpir_mpfr_mul_2si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_mul_2si, typeof(__xmpir_mpfr_mul_2si));
    private static __xmpir_mpfr_div_2ui xmpir_mpfr_div_2ui = (__xmpir_mpfr_div_2ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_div_2ui, typeof(__xmpir_mpfr_div_2ui));
    private static __xmpir_mpfr_div_2si xmpir_mpfr_div_2si = (__xmpir_mpfr_div_2si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_div_2si, typeof(__xmpir_mpfr_div_2si));
    private static __xmpir_mpfr_cmp xmpir_mpfr_cmp = (__xmpir_mpfr_cmp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cmp, typeof(__xmpir_mpfr_cmp));
    private static __xmpir_mpfr_cmp_d xmpir_mpfr_cmp_d = (__xmpir_mpfr_cmp_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cmp_d, typeof(__xmpir_mpfr_cmp_d));
    private static __xmpir_mpfr_cmp_ui xmpir_mpfr_cmp_ui = (__xmpir_mpfr_cmp_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cmp_ui, typeof(__xmpir_mpfr_cmp_ui));
    private static __xmpir_mpfr_cmp_si xmpir_mpfr_cmp_si = (__xmpir_mpfr_cmp_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cmp_si, typeof(__xmpir_mpfr_cmp_si));
    private static __xmpir_mpfr_cmp_z xmpir_mpfr_cmp_z = (__xmpir_mpfr_cmp_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cmp_z, typeof(__xmpir_mpfr_cmp_z));
    private static __xmpir_mpfr_cmp_q xmpir_mpfr_cmp_q = (__xmpir_mpfr_cmp_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cmp_q, typeof(__xmpir_mpfr_cmp_q));
    private static __xmpir_mpfr_cmp_f xmpir_mpfr_cmp_f = (__xmpir_mpfr_cmp_f)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cmp_f, typeof(__xmpir_mpfr_cmp_f));
    private static __xmpir_mpfr_cmp_ui_2exp xmpir_mpfr_cmp_ui_2exp = (__xmpir_mpfr_cmp_ui_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cmp_ui_2exp, typeof(__xmpir_mpfr_cmp_ui_2exp));
    private static __xmpir_mpfr_cmp_si_2exp xmpir_mpfr_cmp_si_2exp = (__xmpir_mpfr_cmp_si_2exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cmp_si_2exp, typeof(__xmpir_mpfr_cmp_si_2exp));
    private static __xmpir_mpfr_cmpabs xmpir_mpfr_cmpabs = (__xmpir_mpfr_cmpabs)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cmpabs, typeof(__xmpir_mpfr_cmpabs));
    private static __xmpir_mpfr_nan_p xmpir_mpfr_nan_p = (__xmpir_mpfr_nan_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_nan_p, typeof(__xmpir_mpfr_nan_p));
    private static __xmpir_mpfr_inf_p xmpir_mpfr_inf_p = (__xmpir_mpfr_inf_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_inf_p, typeof(__xmpir_mpfr_inf_p));
    private static __xmpir_mpfr_number_p xmpir_mpfr_number_p = (__xmpir_mpfr_number_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_number_p, typeof(__xmpir_mpfr_number_p));
    private static __xmpir_mpfr_zero_p xmpir_mpfr_zero_p = (__xmpir_mpfr_zero_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_zero_p, typeof(__xmpir_mpfr_zero_p));
    private static __xmpir_mpfr_regular_p xmpir_mpfr_regular_p = (__xmpir_mpfr_regular_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_regular_p, typeof(__xmpir_mpfr_regular_p));
    private static __xmpir_mpfr_sgn xmpir_mpfr_sgn = (__xmpir_mpfr_sgn)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sgn, typeof(__xmpir_mpfr_sgn));
    private static __xmpir_mpfr_greater_p xmpir_mpfr_greater_p = (__xmpir_mpfr_greater_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_greater_p, typeof(__xmpir_mpfr_greater_p));
    private static __xmpir_mpfr_greaterequal_p xmpir_mpfr_greaterequal_p = (__xmpir_mpfr_greaterequal_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_greaterequal_p, typeof(__xmpir_mpfr_greaterequal_p));
    private static __xmpir_mpfr_less_p xmpir_mpfr_less_p = (__xmpir_mpfr_less_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_less_p, typeof(__xmpir_mpfr_less_p));
    private static __xmpir_mpfr_lessequal_p xmpir_mpfr_lessequal_p = (__xmpir_mpfr_lessequal_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_lessequal_p, typeof(__xmpir_mpfr_lessequal_p));
    private static __xmpir_mpfr_equal_p xmpir_mpfr_equal_p = (__xmpir_mpfr_equal_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_equal_p, typeof(__xmpir_mpfr_equal_p));
    private static __xmpir_mpfr_lessgreater_p xmpir_mpfr_lessgreater_p = (__xmpir_mpfr_lessgreater_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_lessgreater_p, typeof(__xmpir_mpfr_lessgreater_p));
    private static __xmpir_mpfr_unordered_p xmpir_mpfr_unordered_p = (__xmpir_mpfr_unordered_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_unordered_p, typeof(__xmpir_mpfr_unordered_p));
    private static __xmpir_mpfr_log xmpir_mpfr_log = (__xmpir_mpfr_log)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_log, typeof(__xmpir_mpfr_log));
    private static __xmpir_mpfr_log2 xmpir_mpfr_log2 = (__xmpir_mpfr_log2)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_log2, typeof(__xmpir_mpfr_log2));
    private static __xmpir_mpfr_log10 xmpir_mpfr_log10 = (__xmpir_mpfr_log10)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_log10, typeof(__xmpir_mpfr_log10));
    private static __xmpir_mpfr_exp xmpir_mpfr_exp = (__xmpir_mpfr_exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_exp, typeof(__xmpir_mpfr_exp));
    private static __xmpir_mpfr_exp2 xmpir_mpfr_exp2 = (__xmpir_mpfr_exp2)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_exp2, typeof(__xmpir_mpfr_exp2));
    private static __xmpir_mpfr_exp10 xmpir_mpfr_exp10 = (__xmpir_mpfr_exp10)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_exp10, typeof(__xmpir_mpfr_exp10));
    private static __xmpir_mpfr_cos xmpir_mpfr_cos = (__xmpir_mpfr_cos)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cos, typeof(__xmpir_mpfr_cos));
    private static __xmpir_mpfr_sin xmpir_mpfr_sin = (__xmpir_mpfr_sin)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sin, typeof(__xmpir_mpfr_sin));
    private static __xmpir_mpfr_tan xmpir_mpfr_tan = (__xmpir_mpfr_tan)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_tan, typeof(__xmpir_mpfr_tan));
    private static __xmpir_mpfr_sin_cos xmpir_mpfr_sin_cos = (__xmpir_mpfr_sin_cos)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sin_cos, typeof(__xmpir_mpfr_sin_cos));
    private static __xmpir_mpfr_sec xmpir_mpfr_sec = (__xmpir_mpfr_sec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sec, typeof(__xmpir_mpfr_sec));
    private static __xmpir_mpfr_csc xmpir_mpfr_csc = (__xmpir_mpfr_csc)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_csc, typeof(__xmpir_mpfr_csc));
    private static __xmpir_mpfr_cot xmpir_mpfr_cot = (__xmpir_mpfr_cot)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cot, typeof(__xmpir_mpfr_cot));
    private static __xmpir_mpfr_acos xmpir_mpfr_acos = (__xmpir_mpfr_acos)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_acos, typeof(__xmpir_mpfr_acos));
    private static __xmpir_mpfr_asin xmpir_mpfr_asin = (__xmpir_mpfr_asin)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_asin, typeof(__xmpir_mpfr_asin));
    private static __xmpir_mpfr_atan xmpir_mpfr_atan = (__xmpir_mpfr_atan)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_atan, typeof(__xmpir_mpfr_atan));
    private static __xmpir_mpfr_atan2 xmpir_mpfr_atan2 = (__xmpir_mpfr_atan2)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_atan2, typeof(__xmpir_mpfr_atan2));
    private static __xmpir_mpfr_cosh xmpir_mpfr_cosh = (__xmpir_mpfr_cosh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_cosh, typeof(__xmpir_mpfr_cosh));
    private static __xmpir_mpfr_sinh xmpir_mpfr_sinh = (__xmpir_mpfr_sinh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sinh, typeof(__xmpir_mpfr_sinh));
    private static __xmpir_mpfr_tanh xmpir_mpfr_tanh = (__xmpir_mpfr_tanh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_tanh, typeof(__xmpir_mpfr_tanh));
    private static __xmpir_mpfr_sinh_cosh xmpir_mpfr_sinh_cosh = (__xmpir_mpfr_sinh_cosh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sinh_cosh, typeof(__xmpir_mpfr_sinh_cosh));
    private static __xmpir_mpfr_sech xmpir_mpfr_sech = (__xmpir_mpfr_sech)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_sech, typeof(__xmpir_mpfr_sech));
    private static __xmpir_mpfr_csch xmpir_mpfr_csch = (__xmpir_mpfr_csch)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_csch, typeof(__xmpir_mpfr_csch));
    private static __xmpir_mpfr_coth xmpir_mpfr_coth = (__xmpir_mpfr_coth)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_coth, typeof(__xmpir_mpfr_coth));
    private static __xmpir_mpfr_acosh xmpir_mpfr_acosh = (__xmpir_mpfr_acosh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_acosh, typeof(__xmpir_mpfr_acosh));
    private static __xmpir_mpfr_asinh xmpir_mpfr_asinh = (__xmpir_mpfr_asinh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_asinh, typeof(__xmpir_mpfr_asinh));
    private static __xmpir_mpfr_atanh xmpir_mpfr_atanh = (__xmpir_mpfr_atanh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_atanh, typeof(__xmpir_mpfr_atanh));
    private static __xmpir_mpfr_fac_ui xmpir_mpfr_fac_ui = (__xmpir_mpfr_fac_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_fac_ui, typeof(__xmpir_mpfr_fac_ui));
    private static __xmpir_mpfr_log1p xmpir_mpfr_log1p = (__xmpir_mpfr_log1p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_log1p, typeof(__xmpir_mpfr_log1p));
    private static __xmpir_mpfr_expm1 xmpir_mpfr_expm1 = (__xmpir_mpfr_expm1)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_expm1, typeof(__xmpir_mpfr_expm1));
    private static __xmpir_mpfr_eint xmpir_mpfr_eint = (__xmpir_mpfr_eint)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_eint, typeof(__xmpir_mpfr_eint));
    private static __xmpir_mpfr_li2 xmpir_mpfr_li2 = (__xmpir_mpfr_li2)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_li2, typeof(__xmpir_mpfr_li2));
    private static __xmpir_mpfr_gamma xmpir_mpfr_gamma = (__xmpir_mpfr_gamma)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_gamma, typeof(__xmpir_mpfr_gamma));
    private static __xmpir_mpfr_lngamma xmpir_mpfr_lngamma = (__xmpir_mpfr_lngamma)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_lngamma, typeof(__xmpir_mpfr_lngamma));
    private static __xmpir_mpfr_lgamma xmpir_mpfr_lgamma = (__xmpir_mpfr_lgamma)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_lgamma, typeof(__xmpir_mpfr_lgamma));
    private static __xmpir_mpfr_digamma xmpir_mpfr_digamma = (__xmpir_mpfr_digamma)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_digamma, typeof(__xmpir_mpfr_digamma));
    private static __xmpir_mpfr_zeta xmpir_mpfr_zeta = (__xmpir_mpfr_zeta)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_zeta, typeof(__xmpir_mpfr_zeta));
    private static __xmpir_mpfr_zeta_ui xmpir_mpfr_zeta_ui = (__xmpir_mpfr_zeta_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_zeta_ui, typeof(__xmpir_mpfr_zeta_ui));
    private static __xmpir_mpfr_erf xmpir_mpfr_erf = (__xmpir_mpfr_erf)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_erf, typeof(__xmpir_mpfr_erf));
    private static __xmpir_mpfr_erfc xmpir_mpfr_erfc = (__xmpir_mpfr_erfc)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_erfc, typeof(__xmpir_mpfr_erfc));
    private static __xmpir_mpfr_j0 xmpir_mpfr_j0 = (__xmpir_mpfr_j0)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_j0, typeof(__xmpir_mpfr_j0));
    private static __xmpir_mpfr_j1 xmpir_mpfr_j1 = (__xmpir_mpfr_j1)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_j1, typeof(__xmpir_mpfr_j1));
    private static __xmpir_mpfr_jn xmpir_mpfr_jn = (__xmpir_mpfr_jn)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_jn, typeof(__xmpir_mpfr_jn));
    private static __xmpir_mpfr_y0 xmpir_mpfr_y0 = (__xmpir_mpfr_y0)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_y0, typeof(__xmpir_mpfr_y0));
    private static __xmpir_mpfr_y1 xmpir_mpfr_y1 = (__xmpir_mpfr_y1)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_y1, typeof(__xmpir_mpfr_y1));
    private static __xmpir_mpfr_yn xmpir_mpfr_yn = (__xmpir_mpfr_yn)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_yn, typeof(__xmpir_mpfr_yn));
    private static __xmpir_mpfr_fma xmpir_mpfr_fma = (__xmpir_mpfr_fma)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_fma, typeof(__xmpir_mpfr_fma));
    private static __xmpir_mpfr_fms xmpir_mpfr_fms = (__xmpir_mpfr_fms)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_fms, typeof(__xmpir_mpfr_fms));
    private static __xmpir_mpfr_agm xmpir_mpfr_agm = (__xmpir_mpfr_agm)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_agm, typeof(__xmpir_mpfr_agm));
    private static __xmpir_mpfr_hypot xmpir_mpfr_hypot = (__xmpir_mpfr_hypot)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_hypot, typeof(__xmpir_mpfr_hypot));
    private static __xmpir_mpfr_ai xmpir_mpfr_ai = (__xmpir_mpfr_ai)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_ai, typeof(__xmpir_mpfr_ai));
    private static __xmpir_mpfr_const_log2 xmpir_mpfr_const_log2 = (__xmpir_mpfr_const_log2)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_const_log2, typeof(__xmpir_mpfr_const_log2));
    private static __xmpir_mpfr_const_pi xmpir_mpfr_const_pi = (__xmpir_mpfr_const_pi)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_const_pi, typeof(__xmpir_mpfr_const_pi));
    private static __xmpir_mpfr_const_euler xmpir_mpfr_const_euler = (__xmpir_mpfr_const_euler)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_const_euler, typeof(__xmpir_mpfr_const_euler));
    private static __xmpir_mpfr_const_catalan xmpir_mpfr_const_catalan = (__xmpir_mpfr_const_catalan)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_const_catalan, typeof(__xmpir_mpfr_const_catalan));
    private static __xmpir_mpfr_free_cache xmpir_mpfr_free_cache = (__xmpir_mpfr_free_cache)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_free_cache, typeof(__xmpir_mpfr_free_cache));
    private static __xmpir_mpfr_rint xmpir_mpfr_rint = (__xmpir_mpfr_rint)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_rint, typeof(__xmpir_mpfr_rint));
    private static __xmpir_mpfr_ceil xmpir_mpfr_ceil = (__xmpir_mpfr_ceil)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_ceil, typeof(__xmpir_mpfr_ceil));
    private static __xmpir_mpfr_floor xmpir_mpfr_floor = (__xmpir_mpfr_floor)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_floor, typeof(__xmpir_mpfr_floor));
    private static __xmpir_mpfr_round xmpir_mpfr_round = (__xmpir_mpfr_round)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_round, typeof(__xmpir_mpfr_round));
    private static __xmpir_mpfr_trunc xmpir_mpfr_trunc = (__xmpir_mpfr_trunc)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_trunc, typeof(__xmpir_mpfr_trunc));
    private static __xmpir_mpfr_rint_ceil xmpir_mpfr_rint_ceil = (__xmpir_mpfr_rint_ceil)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_rint_ceil, typeof(__xmpir_mpfr_rint_ceil));
    private static __xmpir_mpfr_rint_floor xmpir_mpfr_rint_floor = (__xmpir_mpfr_rint_floor)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_rint_floor, typeof(__xmpir_mpfr_rint_floor));
    private static __xmpir_mpfr_rint_round xmpir_mpfr_rint_round = (__xmpir_mpfr_rint_round)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_rint_round, typeof(__xmpir_mpfr_rint_round));
    private static __xmpir_mpfr_rint_trunc xmpir_mpfr_rint_trunc = (__xmpir_mpfr_rint_trunc)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_rint_trunc, typeof(__xmpir_mpfr_rint_trunc));
    private static __xmpir_mpfr_frac xmpir_mpfr_frac = (__xmpir_mpfr_frac)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_frac, typeof(__xmpir_mpfr_frac));
    private static __xmpir_mpfr_modf xmpir_mpfr_modf = (__xmpir_mpfr_modf)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_modf, typeof(__xmpir_mpfr_modf));
    private static __xmpir_mpfr_fmod xmpir_mpfr_fmod = (__xmpir_mpfr_fmod)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_fmod, typeof(__xmpir_mpfr_fmod));
    private static __xmpir_mpfr_remainder xmpir_mpfr_remainder = (__xmpir_mpfr_remainder)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_remainder, typeof(__xmpir_mpfr_remainder));
    private static __xmpir_mpfr_remquo xmpir_mpfr_remquo = (__xmpir_mpfr_remquo)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_remquo, typeof(__xmpir_mpfr_remquo));
    private static __xmpir_mpfr_integer_p xmpir_mpfr_integer_p = (__xmpir_mpfr_integer_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_integer_p, typeof(__xmpir_mpfr_integer_p));
    private static __xmpir_mpfr_set_default_rounding_mode xmpir_mpfr_set_default_rounding_mode = (__xmpir_mpfr_set_default_rounding_mode)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_default_rounding_mode, typeof(__xmpir_mpfr_set_default_rounding_mode));
    private static __xmpir_mpfr_get_default_rounding_mode xmpir_mpfr_get_default_rounding_mode = (__xmpir_mpfr_get_default_rounding_mode)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_default_rounding_mode, typeof(__xmpir_mpfr_get_default_rounding_mode));
    private static __xmpir_mpfr_prec_round xmpir_mpfr_prec_round = (__xmpir_mpfr_prec_round)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_prec_round, typeof(__xmpir_mpfr_prec_round));
    private static __xmpir_mpfr_can_round xmpir_mpfr_can_round = (__xmpir_mpfr_can_round)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_can_round, typeof(__xmpir_mpfr_can_round));
    private static __xmpir_mpfr_min_prec xmpir_mpfr_min_prec = (__xmpir_mpfr_min_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_min_prec, typeof(__xmpir_mpfr_min_prec));
    private static __xmpir_mpfr_nexttoward xmpir_mpfr_nexttoward = (__xmpir_mpfr_nexttoward)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_nexttoward, typeof(__xmpir_mpfr_nexttoward));
    private static __xmpir_mpfr_nextabove xmpir_mpfr_nextabove = (__xmpir_mpfr_nextabove)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_nextabove, typeof(__xmpir_mpfr_nextabove));
    private static __xmpir_mpfr_nextbelow xmpir_mpfr_nextbelow = (__xmpir_mpfr_nextbelow)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_nextbelow, typeof(__xmpir_mpfr_nextbelow));
    private static __xmpir_mpfr_min xmpir_mpfr_min = (__xmpir_mpfr_min)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_min, typeof(__xmpir_mpfr_min));
    private static __xmpir_mpfr_max xmpir_mpfr_max = (__xmpir_mpfr_max)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_max, typeof(__xmpir_mpfr_max));
    private static __xmpir_mpfr_urandomb xmpir_mpfr_urandomb = (__xmpir_mpfr_urandomb)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_urandomb, typeof(__xmpir_mpfr_urandomb));
    private static __xmpir_mpfr_urandom xmpir_mpfr_urandom = (__xmpir_mpfr_urandom)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_urandom, typeof(__xmpir_mpfr_urandom));
    private static __xmpir_mpfr_grandom xmpir_mpfr_grandom = (__xmpir_mpfr_grandom)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_grandom, typeof(__xmpir_mpfr_grandom));
    private static __xmpir_mpfr_get_exp xmpir_mpfr_get_exp = (__xmpir_mpfr_get_exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_exp, typeof(__xmpir_mpfr_get_exp));
    private static __xmpir_mpfr_set_exp xmpir_mpfr_set_exp = (__xmpir_mpfr_set_exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_exp, typeof(__xmpir_mpfr_set_exp));
    private static __xmpir_mpfr_signbit xmpir_mpfr_signbit = (__xmpir_mpfr_signbit)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_signbit, typeof(__xmpir_mpfr_signbit));
    private static __xmpir_mpfr_setsign xmpir_mpfr_setsign = (__xmpir_mpfr_setsign)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_setsign, typeof(__xmpir_mpfr_setsign));
    private static __xmpir_mpfr_copysign xmpir_mpfr_copysign = (__xmpir_mpfr_copysign)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_copysign, typeof(__xmpir_mpfr_copysign));
    private static __xmpir_mpfr_buildopt_tls_p xmpir_mpfr_buildopt_tls_p = (__xmpir_mpfr_buildopt_tls_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_buildopt_tls_p, typeof(__xmpir_mpfr_buildopt_tls_p));
    private static __xmpir_mpfr_buildopt_decimal_p xmpir_mpfr_buildopt_decimal_p = (__xmpir_mpfr_buildopt_decimal_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_buildopt_decimal_p, typeof(__xmpir_mpfr_buildopt_decimal_p));
    private static __xmpir_mpfr_get_emin xmpir_mpfr_get_emin = (__xmpir_mpfr_get_emin)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_emin, typeof(__xmpir_mpfr_get_emin));
    private static __xmpir_mpfr_get_emax xmpir_mpfr_get_emax = (__xmpir_mpfr_get_emax)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_emax, typeof(__xmpir_mpfr_get_emax));
    private static __xmpir_mpfr_set_emin xmpir_mpfr_set_emin = (__xmpir_mpfr_set_emin)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_emin, typeof(__xmpir_mpfr_set_emin));
    private static __xmpir_mpfr_set_emax xmpir_mpfr_set_emax = (__xmpir_mpfr_set_emax)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_emax, typeof(__xmpir_mpfr_set_emax));
    private static __xmpir_mpfr_get_emin_min xmpir_mpfr_get_emin_min = (__xmpir_mpfr_get_emin_min)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_emin_min, typeof(__xmpir_mpfr_get_emin_min));
    private static __xmpir_mpfr_get_emin_max xmpir_mpfr_get_emin_max = (__xmpir_mpfr_get_emin_max)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_emin_max, typeof(__xmpir_mpfr_get_emin_max));
    private static __xmpir_mpfr_get_emax_min xmpir_mpfr_get_emax_min = (__xmpir_mpfr_get_emax_min)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_emax_min, typeof(__xmpir_mpfr_get_emax_min));
    private static __xmpir_mpfr_get_emax_max xmpir_mpfr_get_emax_max = (__xmpir_mpfr_get_emax_max)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_get_emax_max, typeof(__xmpir_mpfr_get_emax_max));
    private static __xmpir_mpfr_check_range xmpir_mpfr_check_range = (__xmpir_mpfr_check_range)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_check_range, typeof(__xmpir_mpfr_check_range));
    private static __xmpir_mpfr_subnormalize xmpir_mpfr_subnormalize = (__xmpir_mpfr_subnormalize)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_subnormalize, typeof(__xmpir_mpfr_subnormalize));
    private static __xmpir_mpfr_clear_underflow xmpir_mpfr_clear_underflow = (__xmpir_mpfr_clear_underflow)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_clear_underflow, typeof(__xmpir_mpfr_clear_underflow));
    private static __xmpir_mpfr_clear_overflow xmpir_mpfr_clear_overflow = (__xmpir_mpfr_clear_overflow)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_clear_overflow, typeof(__xmpir_mpfr_clear_overflow));
    private static __xmpir_mpfr_clear_divby0 xmpir_mpfr_clear_divby0 = (__xmpir_mpfr_clear_divby0)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_clear_divby0, typeof(__xmpir_mpfr_clear_divby0));
    private static __xmpir_mpfr_clear_nanflag xmpir_mpfr_clear_nanflag = (__xmpir_mpfr_clear_nanflag)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_clear_nanflag, typeof(__xmpir_mpfr_clear_nanflag));
    private static __xmpir_mpfr_clear_inexflag xmpir_mpfr_clear_inexflag = (__xmpir_mpfr_clear_inexflag)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_clear_inexflag, typeof(__xmpir_mpfr_clear_inexflag));
    private static __xmpir_mpfr_clear_erangeflag xmpir_mpfr_clear_erangeflag = (__xmpir_mpfr_clear_erangeflag)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_clear_erangeflag, typeof(__xmpir_mpfr_clear_erangeflag));
    private static __xmpir_mpfr_clear_flags xmpir_mpfr_clear_flags = (__xmpir_mpfr_clear_flags)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_clear_flags, typeof(__xmpir_mpfr_clear_flags));
    private static __xmpir_mpfr_set_underflow xmpir_mpfr_set_underflow = (__xmpir_mpfr_set_underflow)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_underflow, typeof(__xmpir_mpfr_set_underflow));
    private static __xmpir_mpfr_set_overflow xmpir_mpfr_set_overflow = (__xmpir_mpfr_set_overflow)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_overflow, typeof(__xmpir_mpfr_set_overflow));
    private static __xmpir_mpfr_set_divby0 xmpir_mpfr_set_divby0 = (__xmpir_mpfr_set_divby0)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_divby0, typeof(__xmpir_mpfr_set_divby0));
    private static __xmpir_mpfr_set_nanflag xmpir_mpfr_set_nanflag = (__xmpir_mpfr_set_nanflag)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_nanflag, typeof(__xmpir_mpfr_set_nanflag));
    private static __xmpir_mpfr_set_inexflag xmpir_mpfr_set_inexflag = (__xmpir_mpfr_set_inexflag)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_inexflag, typeof(__xmpir_mpfr_set_inexflag));
    private static __xmpir_mpfr_set_erangeflag xmpir_mpfr_set_erangeflag = (__xmpir_mpfr_set_erangeflag)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_set_erangeflag, typeof(__xmpir_mpfr_set_erangeflag));
    private static __xmpir_mpfr_underflow_p xmpir_mpfr_underflow_p = (__xmpir_mpfr_underflow_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_underflow_p, typeof(__xmpir_mpfr_underflow_p));
    private static __xmpir_mpfr_overflow_p xmpir_mpfr_overflow_p = (__xmpir_mpfr_overflow_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_overflow_p, typeof(__xmpir_mpfr_overflow_p));
    private static __xmpir_mpfr_divby0_p xmpir_mpfr_divby0_p = (__xmpir_mpfr_divby0_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_divby0_p, typeof(__xmpir_mpfr_divby0_p));
    private static __xmpir_mpfr_nanflag_p xmpir_mpfr_nanflag_p = (__xmpir_mpfr_nanflag_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_nanflag_p, typeof(__xmpir_mpfr_nanflag_p));
    private static __xmpir_mpfr_inexflag_p xmpir_mpfr_inexflag_p = (__xmpir_mpfr_inexflag_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_inexflag_p, typeof(__xmpir_mpfr_inexflag_p));
    private static __xmpir_mpfr_erangeflag_p xmpir_mpfr_erangeflag_p = (__xmpir_mpfr_erangeflag_p)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpfr_erangeflag_p, typeof(__xmpir_mpfr_erangeflag_p));
    private static __xmpir_mpc_set_prec xmpir_mpc_set_prec = (__xmpir_mpc_set_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_prec, typeof(__xmpir_mpc_set_prec));
    private static __xmpir_mpc_get_prec xmpir_mpc_get_prec = (__xmpir_mpc_get_prec)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_get_prec, typeof(__xmpir_mpc_get_prec));
    private static __xmpir_mpc_get_prec2 xmpir_mpc_get_prec2 = (__xmpir_mpc_get_prec2)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_get_prec2, typeof(__xmpir_mpc_get_prec2));
    private static __xmpir_mpc_set xmpir_mpc_set = (__xmpir_mpc_set)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set, typeof(__xmpir_mpc_set));
    private static __xmpir_mpc_set_ui xmpir_mpc_set_ui = (__xmpir_mpc_set_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_ui, typeof(__xmpir_mpc_set_ui));
    private static __xmpir_mpc_set_si xmpir_mpc_set_si = (__xmpir_mpc_set_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_si, typeof(__xmpir_mpc_set_si));
    private static __xmpir_mpc_set_d xmpir_mpc_set_d = (__xmpir_mpc_set_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_d, typeof(__xmpir_mpc_set_d));
    private static __xmpir_mpc_set_z xmpir_mpc_set_z = (__xmpir_mpc_set_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_z, typeof(__xmpir_mpc_set_z));
    private static __xmpir_mpc_set_q xmpir_mpc_set_q = (__xmpir_mpc_set_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_q, typeof(__xmpir_mpc_set_q));
    private static __xmpir_mpc_set_f xmpir_mpc_set_f = (__xmpir_mpc_set_f)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_f, typeof(__xmpir_mpc_set_f));
    private static __xmpir_mpc_set_fr xmpir_mpc_set_fr = (__xmpir_mpc_set_fr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_fr, typeof(__xmpir_mpc_set_fr));
    private static __xmpir_mpc_set_ui_ui xmpir_mpc_set_ui_ui = (__xmpir_mpc_set_ui_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_ui_ui, typeof(__xmpir_mpc_set_ui_ui));
    private static __xmpir_mpc_set_si_si xmpir_mpc_set_si_si = (__xmpir_mpc_set_si_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_si_si, typeof(__xmpir_mpc_set_si_si));
    private static __xmpir_mpc_set_d_d xmpir_mpc_set_d_d = (__xmpir_mpc_set_d_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_d_d, typeof(__xmpir_mpc_set_d_d));
    private static __xmpir_mpc_set_z_z xmpir_mpc_set_z_z = (__xmpir_mpc_set_z_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_z_z, typeof(__xmpir_mpc_set_z_z));
    private static __xmpir_mpc_set_q_q xmpir_mpc_set_q_q = (__xmpir_mpc_set_q_q)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_q_q, typeof(__xmpir_mpc_set_q_q));
    private static __xmpir_mpc_set_f_f xmpir_mpc_set_f_f = (__xmpir_mpc_set_f_f)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_f_f, typeof(__xmpir_mpc_set_f_f));
    private static __xmpir_mpc_set_fr_fr xmpir_mpc_set_fr_fr = (__xmpir_mpc_set_fr_fr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_fr_fr, typeof(__xmpir_mpc_set_fr_fr));
    private static __xmpir_mpc_set_nan xmpir_mpc_set_nan = (__xmpir_mpc_set_nan)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_nan, typeof(__xmpir_mpc_set_nan));
    private static __xmpir_mpc_swap xmpir_mpc_swap = (__xmpir_mpc_swap)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_swap, typeof(__xmpir_mpc_swap));
    private static __xmpir_mpc_set_str xmpir_mpc_set_str = (__xmpir_mpc_set_str)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_set_str, typeof(__xmpir_mpc_set_str));
    private static __xmpir_mpc_get_str xmpir_mpc_get_str = (__xmpir_mpc_get_str)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_get_str, typeof(__xmpir_mpc_get_str));
    private static __xmpir_mpc_cmp xmpir_mpc_cmp = (__xmpir_mpc_cmp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_cmp, typeof(__xmpir_mpc_cmp));
    private static __xmpir_mpc_cmp_si_si xmpir_mpc_cmp_si_si = (__xmpir_mpc_cmp_si_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_cmp_si_si, typeof(__xmpir_mpc_cmp_si_si));
    private static __xmpir_mpc_cmp_si xmpir_mpc_cmp_si = (__xmpir_mpc_cmp_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_cmp_si, typeof(__xmpir_mpc_cmp_si));
    private static __xmpir_mpc_real xmpir_mpc_real = (__xmpir_mpc_real)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_real, typeof(__xmpir_mpc_real));
    private static __xmpir_mpc_imag xmpir_mpc_imag = (__xmpir_mpc_imag)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_imag, typeof(__xmpir_mpc_imag));
    private static __xmpir_mpc_arg xmpir_mpc_arg = (__xmpir_mpc_arg)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_arg, typeof(__xmpir_mpc_arg));
    private static __xmpir_mpc_proj xmpir_mpc_proj = (__xmpir_mpc_proj)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_proj, typeof(__xmpir_mpc_proj));
    private static __xmpir_mpc_add xmpir_mpc_add = (__xmpir_mpc_add)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_add, typeof(__xmpir_mpc_add));
    private static __xmpir_mpc_add_ui xmpir_mpc_add_ui = (__xmpir_mpc_add_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_add_ui, typeof(__xmpir_mpc_add_ui));
    private static __xmpir_mpc_add_fr xmpir_mpc_add_fr = (__xmpir_mpc_add_fr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_add_fr, typeof(__xmpir_mpc_add_fr));
    private static __xmpir_mpc_sub xmpir_mpc_sub = (__xmpir_mpc_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_sub, typeof(__xmpir_mpc_sub));
    private static __xmpir_mpc_sub_fr xmpir_mpc_sub_fr = (__xmpir_mpc_sub_fr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_sub_fr, typeof(__xmpir_mpc_sub_fr));
    private static __xmpir_mpc_fr_sub xmpir_mpc_fr_sub = (__xmpir_mpc_fr_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_fr_sub, typeof(__xmpir_mpc_fr_sub));
    private static __xmpir_mpc_sub_ui xmpir_mpc_sub_ui = (__xmpir_mpc_sub_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_sub_ui, typeof(__xmpir_mpc_sub_ui));
    private static __xmpir_mpc_ui_sub xmpir_mpc_ui_sub = (__xmpir_mpc_ui_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_ui_sub, typeof(__xmpir_mpc_ui_sub));
    private static __xmpir_mpc_ui_ui_sub xmpir_mpc_ui_ui_sub = (__xmpir_mpc_ui_ui_sub)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_ui_ui_sub, typeof(__xmpir_mpc_ui_ui_sub));
    private static __xmpir_mpc_neg xmpir_mpc_neg = (__xmpir_mpc_neg)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_neg, typeof(__xmpir_mpc_neg));
    private static __xmpir_mpc_mul xmpir_mpc_mul = (__xmpir_mpc_mul)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_mul, typeof(__xmpir_mpc_mul));
    private static __xmpir_mpc_mul_ui xmpir_mpc_mul_ui = (__xmpir_mpc_mul_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_mul_ui, typeof(__xmpir_mpc_mul_ui));
    private static __xmpir_mpc_mul_si xmpir_mpc_mul_si = (__xmpir_mpc_mul_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_mul_si, typeof(__xmpir_mpc_mul_si));
    private static __xmpir_mpc_mul_fr xmpir_mpc_mul_fr = (__xmpir_mpc_mul_fr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_mul_fr, typeof(__xmpir_mpc_mul_fr));
    private static __xmpir_mpc_mul_i xmpir_mpc_mul_i = (__xmpir_mpc_mul_i)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_mul_i, typeof(__xmpir_mpc_mul_i));
    private static __xmpir_mpc_sqr xmpir_mpc_sqr = (__xmpir_mpc_sqr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_sqr, typeof(__xmpir_mpc_sqr));
    private static __xmpir_mpc_fma xmpir_mpc_fma = (__xmpir_mpc_fma)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_fma, typeof(__xmpir_mpc_fma));
    private static __xmpir_mpc_div xmpir_mpc_div = (__xmpir_mpc_div)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_div, typeof(__xmpir_mpc_div));
    private static __xmpir_mpc_div_ui xmpir_mpc_div_ui = (__xmpir_mpc_div_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_div_ui, typeof(__xmpir_mpc_div_ui));
    private static __xmpir_mpc_div_fr xmpir_mpc_div_fr = (__xmpir_mpc_div_fr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_div_fr, typeof(__xmpir_mpc_div_fr));
    private static __xmpir_mpc_ui_div xmpir_mpc_ui_div = (__xmpir_mpc_ui_div)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_ui_div, typeof(__xmpir_mpc_ui_div));
    private static __xmpir_mpc_fr_div xmpir_mpc_fr_div = (__xmpir_mpc_fr_div)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_fr_div, typeof(__xmpir_mpc_fr_div));
    private static __xmpir_mpc_conj xmpir_mpc_conj = (__xmpir_mpc_conj)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_conj, typeof(__xmpir_mpc_conj));
    private static __xmpir_mpc_abs xmpir_mpc_abs = (__xmpir_mpc_abs)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_abs, typeof(__xmpir_mpc_abs));
    private static __xmpir_mpc_norm xmpir_mpc_norm = (__xmpir_mpc_norm)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_norm, typeof(__xmpir_mpc_norm));
    private static __xmpir_mpc_mul_2ui xmpir_mpc_mul_2ui = (__xmpir_mpc_mul_2ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_mul_2ui, typeof(__xmpir_mpc_mul_2ui));
    private static __xmpir_mpc_mul_2si xmpir_mpc_mul_2si = (__xmpir_mpc_mul_2si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_mul_2si, typeof(__xmpir_mpc_mul_2si));
    private static __xmpir_mpc_div_2ui xmpir_mpc_div_2ui = (__xmpir_mpc_div_2ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_div_2ui, typeof(__xmpir_mpc_div_2ui));
    private static __xmpir_mpc_div_2si xmpir_mpc_div_2si = (__xmpir_mpc_div_2si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_div_2si, typeof(__xmpir_mpc_div_2si));
    private static __xmpir_mpc_sqrt xmpir_mpc_sqrt = (__xmpir_mpc_sqrt)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_sqrt, typeof(__xmpir_mpc_sqrt));
    private static __xmpir_mpc_pow xmpir_mpc_pow = (__xmpir_mpc_pow)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_pow, typeof(__xmpir_mpc_pow));
    private static __xmpir_mpc_pow_d xmpir_mpc_pow_d = (__xmpir_mpc_pow_d)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_pow_d, typeof(__xmpir_mpc_pow_d));
    private static __xmpir_mpc_pow_si xmpir_mpc_pow_si = (__xmpir_mpc_pow_si)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_pow_si, typeof(__xmpir_mpc_pow_si));
    private static __xmpir_mpc_pow_ui xmpir_mpc_pow_ui = (__xmpir_mpc_pow_ui)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_pow_ui, typeof(__xmpir_mpc_pow_ui));
    private static __xmpir_mpc_pow_z xmpir_mpc_pow_z = (__xmpir_mpc_pow_z)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_pow_z, typeof(__xmpir_mpc_pow_z));
    private static __xmpir_mpc_pow_fr xmpir_mpc_pow_fr = (__xmpir_mpc_pow_fr)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_pow_fr, typeof(__xmpir_mpc_pow_fr));
    private static __xmpir_mpc_exp xmpir_mpc_exp = (__xmpir_mpc_exp)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_exp, typeof(__xmpir_mpc_exp));
    private static __xmpir_mpc_log xmpir_mpc_log = (__xmpir_mpc_log)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_log, typeof(__xmpir_mpc_log));
    private static __xmpir_mpc_log10 xmpir_mpc_log10 = (__xmpir_mpc_log10)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_log10, typeof(__xmpir_mpc_log10));
    private static __xmpir_mpc_sin xmpir_mpc_sin = (__xmpir_mpc_sin)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_sin, typeof(__xmpir_mpc_sin));
    private static __xmpir_mpc_cos xmpir_mpc_cos = (__xmpir_mpc_cos)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_cos, typeof(__xmpir_mpc_cos));
    private static __xmpir_mpc_sin_cos xmpir_mpc_sin_cos = (__xmpir_mpc_sin_cos)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_sin_cos, typeof(__xmpir_mpc_sin_cos));
    private static __xmpir_mpc_tan xmpir_mpc_tan = (__xmpir_mpc_tan)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_tan, typeof(__xmpir_mpc_tan));
    private static __xmpir_mpc_sinh xmpir_mpc_sinh = (__xmpir_mpc_sinh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_sinh, typeof(__xmpir_mpc_sinh));
    private static __xmpir_mpc_cosh xmpir_mpc_cosh = (__xmpir_mpc_cosh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_cosh, typeof(__xmpir_mpc_cosh));
    private static __xmpir_mpc_tanh xmpir_mpc_tanh = (__xmpir_mpc_tanh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_tanh, typeof(__xmpir_mpc_tanh));
    private static __xmpir_mpc_asin xmpir_mpc_asin = (__xmpir_mpc_asin)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_asin, typeof(__xmpir_mpc_asin));
    private static __xmpir_mpc_acos xmpir_mpc_acos = (__xmpir_mpc_acos)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_acos, typeof(__xmpir_mpc_acos));
    private static __xmpir_mpc_atan xmpir_mpc_atan = (__xmpir_mpc_atan)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_atan, typeof(__xmpir_mpc_atan));
    private static __xmpir_mpc_asinh xmpir_mpc_asinh = (__xmpir_mpc_asinh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_asinh, typeof(__xmpir_mpc_asinh));
    private static __xmpir_mpc_acosh xmpir_mpc_acosh = (__xmpir_mpc_acosh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_acosh, typeof(__xmpir_mpc_acosh));
    private static __xmpir_mpc_atanh xmpir_mpc_atanh = (__xmpir_mpc_atanh)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_atanh, typeof(__xmpir_mpc_atanh));
    private static __xmpir_mpc_urandom xmpir_mpc_urandom = (__xmpir_mpc_urandom)Marshal.GetDelegateForFunctionPointer(__ptr__xmpir_mpc_urandom, typeof(__xmpir_mpc_urandom));

    
    
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
    public static mpfr_intptr mpfr_init()
    {
        int __retval;
        mpfr_intptr result;
        __retval= xmpir_mpfr_init(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpfr_intptr mpfr_init2(long prec)
    {
        int __retval;
        mpfr_intptr result;
        __retval= xmpir_mpfr_init2(out result, prec);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpfr_intptr mpfr_init_set(mpfr op, int rnd)
    {
        int __retval;
        mpfr_intptr result;
        __retval= xmpir_mpfr_init_set(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpfr_intptr mpfr_init_set_ui(uint op, int rnd)
    {
        int __retval;
        mpfr_intptr result;
        __retval= xmpir_mpfr_init_set_ui(out result, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpfr_intptr mpfr_init_set_si(int op, int rnd)
    {
        int __retval;
        mpfr_intptr result;
        __retval= xmpir_mpfr_init_set_si(out result, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpfr_intptr mpfr_init_set_d(double op, int rnd)
    {
        int __retval;
        mpfr_intptr result;
        __retval= xmpir_mpfr_init_set_d(out result, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpfr_intptr mpfr_init_set_z(mpz op, int rnd)
    {
        int __retval;
        mpfr_intptr result;
        __retval= xmpir_mpfr_init_set_z(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpfr_intptr mpfr_init_set_q(mpq op, int rnd)
    {
        int __retval;
        mpfr_intptr result;
        __retval= xmpir_mpfr_init_set_q(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpfr_intptr mpfr_init_set_f(mpf op, int rnd)
    {
        int __retval;
        mpfr_intptr result;
        __retval= xmpir_mpfr_init_set_f(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpfr_intptr mpfr_init_set_str(string str, uint _base, int rnd)
    {
        int __retval;
        mpfr_intptr result;
        byte[] __ba_str = System.Text.Encoding.UTF8.GetBytes(str+"\0");
        IntPtr __str;
        __retval = xmpir_malloc(out __str, str.Length+1);
        if( __retval!=0 ) HandleError(__retval);
        Marshal.Copy(__ba_str, 0, __str, str.Length+1);
        __retval= xmpir_mpfr_init_set_str(out result, __str, _base, rnd);
        if( __retval!=0 ) HandleError(__retval);
       __retval = xmpir_free(__str);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpc_intptr mpc_init2(long prec)
    {
        int __retval;
        mpc_intptr result;
        __retval= xmpir_mpc_init2(out result, prec);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static mpc_intptr mpc_init3(long prec_r, long prec_i)
    {
        int __retval;
        mpc_intptr result;
        __retval= xmpir_mpc_init3(out result, prec_r, prec_i);
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
    public static void mpfr_clear(mpfr v)
    {
        int __retval;
        __retval= xmpir_mpfr_clear(v.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpc_clear(mpc v)
    {
        int __retval;
        __retval= xmpir_mpc_clear(v.Val);
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
    public static int mpz_fits_ulong_p(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_fits_ulong_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_fits_slong_p(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_fits_slong_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
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
    public static int mpz_fits_ushort_p(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_fits_ushort_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpz_fits_sshort_p(mpz op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpz_fits_sshort_p(out result, op.Val);
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
    public static void mpf_set_prec_raw(mpf rop, ulong prec)
    {
        int __retval;
        __retval= xmpir_mpf_set_prec_raw(rop.Val, prec);
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
    public static int mpf_fits_ulong_p(mpf op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_fits_ulong_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpf_fits_slong_p(mpf op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_fits_slong_p(out result, op.Val);
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
    public static int mpf_fits_ushort_p(mpf op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_fits_ushort_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpf_fits_sshort_p(mpf op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpf_fits_sshort_p(out result, op.Val);
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
    public static void mpfr_set_default_prec(long prec)
    {
        int __retval;
        __retval= xmpir_mpfr_set_default_prec(prec);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static long mpfr_get_default_prec()
    {
        int __retval;
        long result;
        __retval= xmpir_mpfr_get_default_prec(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpfr_set_prec(mpfr rop, long prec)
    {
        int __retval;
        __retval= xmpir_mpfr_set_prec(rop.Val, prec);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static long mpfr_get_prec(mpfr op)
    {
        int __retval;
        long result;
        __retval= xmpir_mpfr_get_prec(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_ui(mpfr rop, uint op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_ui(out result, rop.Val, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_si(mpfr rop, int op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_si(out result, rop.Val, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_d(mpfr rop, double op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_d(out result, rop.Val, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_z(mpfr rop, mpz op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_z(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_q(mpfr rop, mpq op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_q(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_f(mpfr rop, mpf op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_f(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_str(mpfr rop, string str, uint _base, int rnd)
    {
        int __retval;
        int result;
        byte[] __ba_str = System.Text.Encoding.UTF8.GetBytes(str+"\0");
        IntPtr __str;
        __retval = xmpir_malloc(out __str, str.Length+1);
        if( __retval!=0 ) HandleError(__retval);
        Marshal.Copy(__ba_str, 0, __str, str.Length+1);
        __retval= xmpir_mpfr_set_str(out result, rop.Val, __str, _base, rnd);
        if( __retval!=0 ) HandleError(__retval);
       __retval = xmpir_free(__str);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_ui_2exp(mpfr rop, uint op, long e, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_ui_2exp(out result, rop.Val, op, e, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_si_2exp(mpfr rop, int op, long e, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_si_2exp(out result, rop.Val, op, e, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_z_2exp(mpfr rop, mpz op, long e, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_z_2exp(out result, rop.Val, op.Val, e, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpfr_set_nan(mpfr rop)
    {
        int __retval;
        __retval= xmpir_mpfr_set_nan(rop.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_set_inf(mpfr rop, int sign)
    {
        int __retval;
        __retval= xmpir_mpfr_set_inf(rop.Val, sign);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_set_zero(mpfr rop, int sign)
    {
        int __retval;
        __retval= xmpir_mpfr_set_zero(rop.Val, sign);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_swap(mpfr rop, mpfr op)
    {
        int __retval;
        __retval= xmpir_mpfr_swap(rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static double mpfr_get_d(mpfr op, int rnd)
    {
        int __retval;
        double result;
        __retval= xmpir_mpfr_get_d(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_get_si(mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_get_si(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static uint mpfr_get_ui(mpfr op, int rnd)
    {
        int __retval;
        uint result;
        __retval= xmpir_mpfr_get_ui(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static double mpfr_get_d_2exp(out int expptr, mpfr op, int rnd)
    {
        int __retval;
        double result;
        __retval= xmpir_mpfr_get_d_2exp(out result, out expptr, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_frexp(out long expptr, mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_frexp(out result, out expptr, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static long mpfr_get_z_2exp(mpz rop, mpfr op)
    {
        int __retval;
        long result;
        __retval= xmpir_mpfr_get_z_2exp(out result, rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_get_z(mpz rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_get_z(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_get_f(mpf rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_get_f(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static string mpfr_get_str(string str, out long expptr, uint _base, uint n_digits, mpfr op, int rnd)
    {
        int __retval;
        string result;
        IntPtr __result;
        IntPtr __str = IntPtr.Zero;
        __retval= xmpir_mpfr_get_str(out __result, __str, out expptr, _base, n_digits, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
       result = Marshal.PtrToStringAnsi(__result);
       __retval = xmpir_free(__result);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_fits_ulong_p(mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_fits_ulong_p(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_fits_slong_p(mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_fits_slong_p(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_fits_uint_p(mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_fits_uint_p(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_fits_sint_p(mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_fits_sint_p(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_fits_ushort_p(mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_fits_ushort_p(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_fits_sshort_p(mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_fits_sshort_p(out result, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_add(mpfr rop, mpfr op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_add(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_add_ui(mpfr rop, mpfr op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_add_ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_add_si(mpfr rop, mpfr op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_add_si(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_add_d(mpfr rop, mpfr op1, double op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_add_d(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_add_z(mpfr rop, mpfr op1, mpz op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_add_z(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_add_q(mpfr rop, mpfr op1, mpq op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_add_q(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sub(mpfr rop, mpfr op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sub(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_ui_sub(mpfr rop, uint op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_ui_sub(out result, rop.Val, op1, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sub_ui(mpfr rop, mpfr op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sub_ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_si_sub(mpfr rop, int op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_si_sub(out result, rop.Val, op1, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sub_si(mpfr rop, mpfr op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sub_si(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_d_sub(mpfr rop, double op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_d_sub(out result, rop.Val, op1, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sub_d(mpfr rop, mpfr op1, double op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sub_d(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_z_sub(mpfr rop, mpz op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_z_sub(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sub_z(mpfr rop, mpfr op1, mpz op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sub_z(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sub_q(mpfr rop, mpfr op1, mpq op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sub_q(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_mul(mpfr rop, mpfr op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_mul(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_mul_ui(mpfr rop, mpfr op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_mul_ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_mul_si(mpfr rop, mpfr op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_mul_si(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_mul_d(mpfr rop, mpfr op1, double op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_mul_d(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_mul_z(mpfr rop, mpfr op1, mpz op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_mul_z(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_mul_q(mpfr rop, mpfr op1, mpq op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_mul_q(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sqr(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sqr(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_div(mpfr rop, mpfr op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_div(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_ui_div(mpfr rop, uint op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_ui_div(out result, rop.Val, op1, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_div_ui(mpfr rop, mpfr op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_div_ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_si_div(mpfr rop, int op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_si_div(out result, rop.Val, op1, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_div_si(mpfr rop, mpfr op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_div_si(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_d_div(mpfr rop, double op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_d_div(out result, rop.Val, op1, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_div_d(mpfr rop, mpfr op1, double op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_div_d(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_div_z(mpfr rop, mpfr op1, mpz op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_div_z(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_div_q(mpfr rop, mpfr op1, mpq op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_div_q(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sqrt(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sqrt(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sqrt_ui(mpfr rop, uint op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sqrt_ui(out result, rop.Val, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_rec_sqrt(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_rec_sqrt(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cbrt(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cbrt(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_root(mpfr rop, mpfr op, uint k, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_root(out result, rop.Val, op.Val, k, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_pow(mpfr rop, mpfr op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_pow(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_pow_ui(mpfr rop, mpfr op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_pow_ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_pow_si(mpfr rop, mpfr op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_pow_si(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_pow_z(mpfr rop, mpfr op1, mpz op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_pow_z(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_ui_pow_ui(mpfr rop, uint op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_ui_pow_ui(out result, rop.Val, op1, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_ui_pow(mpfr rop, uint op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_ui_pow(out result, rop.Val, op1, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_neg(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_neg(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_abs(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_abs(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_dim(mpfr rop, mpfr op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_dim(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_mul_2ui(mpfr rop, mpfr op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_mul_2ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_mul_2si(mpfr rop, mpfr op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_mul_2si(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_div_2ui(mpfr rop, mpfr op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_div_2ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_div_2si(mpfr rop, mpfr op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_div_2si(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cmp(mpfr op1, mpfr op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cmp(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cmp_d(mpfr op1, double op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cmp_d(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cmp_ui(mpfr op1, uint op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cmp_ui(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cmp_si(mpfr op1, int op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cmp_si(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cmp_z(mpfr op1, mpz op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cmp_z(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cmp_q(mpfr op1, mpq op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cmp_q(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cmp_f(mpfr op1, mpf op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cmp_f(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cmp_ui_2exp(mpfr op1, uint op2, long e)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cmp_ui_2exp(out result, op1.Val, op2, e);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cmp_si_2exp(mpfr op1, int op2, long e)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cmp_si_2exp(out result, op1.Val, op2, e);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cmpabs(mpfr op1, mpfr op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cmpabs(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_nan_p(mpfr op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_nan_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_inf_p(mpfr op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_inf_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_number_p(mpfr op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_number_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_zero_p(mpfr op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_zero_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_regular_p(mpfr op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_regular_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sgn(mpfr op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sgn(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_greater_p(mpfr op1, mpfr op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_greater_p(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_greaterequal_p(mpfr op1, mpfr op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_greaterequal_p(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_less_p(mpfr op1, mpfr op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_less_p(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_lessequal_p(mpfr op1, mpfr op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_lessequal_p(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_equal_p(mpfr op1, mpfr op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_equal_p(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_lessgreater_p(mpfr op1, mpfr op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_lessgreater_p(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_unordered_p(mpfr op1, mpfr op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_unordered_p(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_log(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_log(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_log2(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_log2(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_log10(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_log10(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_exp(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_exp(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_exp2(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_exp2(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_exp10(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_exp10(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cos(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cos(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sin(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sin(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_tan(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_tan(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sin_cos(mpfr sop, mpfr cop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sin_cos(out result, sop.Val, cop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sec(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sec(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_csc(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_csc(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cot(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cot(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_acos(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_acos(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_asin(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_asin(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_atan(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_atan(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_atan2(mpfr rop, mpfr y, mpfr x, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_atan2(out result, rop.Val, y.Val, x.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_cosh(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_cosh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sinh(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sinh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_tanh(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_tanh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sinh_cosh(mpfr sop, mpfr cop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sinh_cosh(out result, sop.Val, cop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_sech(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_sech(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_csch(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_csch(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_coth(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_coth(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_acosh(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_acosh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_asinh(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_asinh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_atanh(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_atanh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_fac_ui(mpfr rop, uint op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_fac_ui(out result, rop.Val, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_log1p(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_log1p(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_expm1(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_expm1(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_eint(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_eint(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_li2(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_li2(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_gamma(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_gamma(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_lngamma(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_lngamma(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_lgamma(mpfr rop, out int signp, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_lgamma(out result, rop.Val, out signp, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_digamma(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_digamma(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_zeta(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_zeta(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_zeta_ui(mpfr rop, uint op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_zeta_ui(out result, rop.Val, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_erf(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_erf(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_erfc(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_erfc(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_j0(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_j0(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_j1(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_j1(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_jn(mpfr rop, int n, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_jn(out result, rop.Val, n, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_y0(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_y0(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_y1(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_y1(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_yn(mpfr rop, int n, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_yn(out result, rop.Val, n, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_fma(mpfr rop, mpfr op1, mpfr op2, mpfr op3, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_fma(out result, rop.Val, op1.Val, op2.Val, op3.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_fms(mpfr rop, mpfr op1, mpfr op2, mpfr op3, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_fms(out result, rop.Val, op1.Val, op2.Val, op3.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_agm(mpfr rop, mpfr op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_agm(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_hypot(mpfr rop, mpfr x, mpfr y, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_hypot(out result, rop.Val, x.Val, y.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_ai(mpfr rop, mpfr x, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_ai(out result, rop.Val, x.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_const_log2(mpfr rop, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_const_log2(out result, rop.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_const_pi(mpfr rop, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_const_pi(out result, rop.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_const_euler(mpfr rop, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_const_euler(out result, rop.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_const_catalan(mpfr rop, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_const_catalan(out result, rop.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpfr_free_cache()
    {
        int __retval;
        __retval= xmpir_mpfr_free_cache();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpfr_rint(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_rint(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_ceil(mpfr rop, mpfr op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_ceil(out result, rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_floor(mpfr rop, mpfr op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_floor(out result, rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_round(mpfr rop, mpfr op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_round(out result, rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_trunc(mpfr rop, mpfr op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_trunc(out result, rop.Val, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_rint_ceil(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_rint_ceil(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_rint_floor(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_rint_floor(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_rint_round(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_rint_round(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_rint_trunc(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_rint_trunc(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_frac(mpfr rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_frac(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_modf(mpfr iop, mpfr fop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_modf(out result, iop.Val, fop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_fmod(mpfr r, mpfr x, mpfr y, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_fmod(out result, r.Val, x.Val, y.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_remainder(mpfr r, mpfr x, mpfr y, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_remainder(out result, r.Val, x.Val, y.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_remquo(mpfr r, out int q, mpfr x, mpfr y, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_remquo(out result, r.Val, out q, x.Val, y.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_integer_p(mpfr op)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_integer_p(out result, op.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpfr_set_default_rounding_mode(int rnd)
    {
        int __retval;
        __retval= xmpir_mpfr_set_default_rounding_mode(rnd);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpfr_get_default_rounding_mode()
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_get_default_rounding_mode(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_prec_round(mpfr x, long prec, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_prec_round(out result, x.Val, prec, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_can_round(mpfr b, long err, int rnd1, int rnd2, long prec)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_can_round(out result, b.Val, err, rnd1, rnd2, prec);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static long mpfr_min_prec(mpfr x)
    {
        int __retval;
        long result;
        __retval= xmpir_mpfr_min_prec(out result, x.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpfr_nexttoward(mpfr x, mpfr y)
    {
        int __retval;
        __retval= xmpir_mpfr_nexttoward(x.Val, y.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_nextabove(mpfr x)
    {
        int __retval;
        __retval= xmpir_mpfr_nextabove(x.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_nextbelow(mpfr x)
    {
        int __retval;
        __retval= xmpir_mpfr_nextbelow(x.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpfr_min(mpfr rop, mpfr op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_min(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_max(mpfr rop, mpfr op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_max(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_urandomb(mpfr rop, randstate state)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_urandomb(out result, rop.Val, state.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_urandom(mpfr rop, randstate state, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_urandom(out result, rop.Val, state.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_grandom(mpfr rop1, mpfr rop2, randstate state, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_grandom(out result, rop1.Val, rop2.Val, state.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static long mpfr_get_exp(mpfr x)
    {
        int __retval;
        long result;
        __retval= xmpir_mpfr_get_exp(out result, x.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_exp(mpfr x, long e)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_exp(out result, x.Val, e);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_signbit(mpfr x)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_signbit(out result, x.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_setsign(mpfr rop, mpfr op, int s, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_setsign(out result, rop.Val, op.Val, s, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_copysign(mpfr rop, mpfr op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_copysign(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_buildopt_tls_p()
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_buildopt_tls_p(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_buildopt_decimal_p()
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_buildopt_decimal_p(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static long mpfr_get_emin()
    {
        int __retval;
        long result;
        __retval= xmpir_mpfr_get_emin(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static long mpfr_get_emax()
    {
        int __retval;
        long result;
        __retval= xmpir_mpfr_get_emax(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_emin(long exp)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_emin(out result, exp);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_set_emax(long exp)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_set_emax(out result, exp);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static long mpfr_get_emin_min()
    {
        int __retval;
        long result;
        __retval= xmpir_mpfr_get_emin_min(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static long mpfr_get_emin_max()
    {
        int __retval;
        long result;
        __retval= xmpir_mpfr_get_emin_max(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static long mpfr_get_emax_min()
    {
        int __retval;
        long result;
        __retval= xmpir_mpfr_get_emax_min(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static long mpfr_get_emax_max()
    {
        int __retval;
        long result;
        __retval= xmpir_mpfr_get_emax_max(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_check_range(mpfr x, int t, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_check_range(out result, x.Val, t, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_subnormalize(mpfr x, int t, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_subnormalize(out result, x.Val, t, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpfr_clear_underflow()
    {
        int __retval;
        __retval= xmpir_mpfr_clear_underflow();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_clear_overflow()
    {
        int __retval;
        __retval= xmpir_mpfr_clear_overflow();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_clear_divby0()
    {
        int __retval;
        __retval= xmpir_mpfr_clear_divby0();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_clear_nanflag()
    {
        int __retval;
        __retval= xmpir_mpfr_clear_nanflag();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_clear_inexflag()
    {
        int __retval;
        __retval= xmpir_mpfr_clear_inexflag();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_clear_erangeflag()
    {
        int __retval;
        __retval= xmpir_mpfr_clear_erangeflag();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_clear_flags()
    {
        int __retval;
        __retval= xmpir_mpfr_clear_flags();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_set_underflow()
    {
        int __retval;
        __retval= xmpir_mpfr_set_underflow();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_set_overflow()
    {
        int __retval;
        __retval= xmpir_mpfr_set_overflow();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_set_divby0()
    {
        int __retval;
        __retval= xmpir_mpfr_set_divby0();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_set_nanflag()
    {
        int __retval;
        __retval= xmpir_mpfr_set_nanflag();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_set_inexflag()
    {
        int __retval;
        __retval= xmpir_mpfr_set_inexflag();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpfr_set_erangeflag()
    {
        int __retval;
        __retval= xmpir_mpfr_set_erangeflag();
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpfr_underflow_p()
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_underflow_p(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_overflow_p()
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_overflow_p(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_divby0_p()
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_divby0_p(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_nanflag_p()
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_nanflag_p(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_inexflag_p()
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_inexflag_p(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpfr_erangeflag_p()
    {
        int __retval;
        int result;
        __retval= xmpir_mpfr_erangeflag_p(out result);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpc_set_prec(mpc x, long prec)
    {
        int __retval;
        __retval= xmpir_mpc_set_prec(x.Val, prec);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static long mpc_get_prec(mpc x)
    {
        int __retval;
        long result;
        __retval= xmpir_mpc_get_prec(out result, x.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpc_get_prec2(out long pr, out long pi, mpc x)
    {
        int __retval;
        __retval= xmpir_mpc_get_prec2(out pr, out pi, x.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpc_set(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_ui(mpc rop, uint op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_ui(out result, rop.Val, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_si(mpc rop, int op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_si(out result, rop.Val, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_d(mpc rop, double op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_d(out result, rop.Val, op, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_z(mpc rop, mpz op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_z(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_q(mpc rop, mpq op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_q(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_f(mpc rop, mpf op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_f(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_fr(mpc rop, mpfr op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_fr(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_ui_ui(mpc rop, uint op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_ui_ui(out result, rop.Val, op1, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_si_si(mpc rop, int op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_si_si(out result, rop.Val, op1, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_d_d(mpc rop, double op1, double op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_d_d(out result, rop.Val, op1, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_z_z(mpc rop, mpz op1, mpz op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_z_z(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_q_q(mpc rop, mpq op1, mpq op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_q_q(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_f_f(mpc rop, mpf op1, mpf op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_f_f(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_set_fr_fr(mpc rop, mpfr op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_set_fr_fr(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static void mpc_set_nan(mpc rop)
    {
        int __retval;
        __retval= xmpir_mpc_set_nan(rop.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static void mpc_swap(mpc op1, mpc op2)
    {
        int __retval;
        __retval= xmpir_mpc_swap(op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
    }
    public static int mpc_set_str(mpc rop, string str, int _base, int rnd)
    {
        int __retval;
        int result;
        byte[] __ba_str = System.Text.Encoding.UTF8.GetBytes(str+"\0");
        IntPtr __str;
        __retval = xmpir_malloc(out __str, str.Length+1);
        if( __retval!=0 ) HandleError(__retval);
        Marshal.Copy(__ba_str, 0, __str, str.Length+1);
        __retval= xmpir_mpc_set_str(out result, rop.Val, __str, _base, rnd);
        if( __retval!=0 ) HandleError(__retval);
       __retval = xmpir_free(__str);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static string mpc_get_str(int _base, uint n, mpc op, int rnd)
    {
        int __retval;
        string result;
        IntPtr __result;
        __retval= xmpir_mpc_get_str(out __result, _base, n, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
       result = Marshal.PtrToStringAnsi(__result);
       __retval = xmpir_free(__result);
       if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_cmp(mpc op1, mpc op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_cmp(out result, op1.Val, op2.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_cmp_si_si(mpc op1, int op2r, int op2i)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_cmp_si_si(out result, op1.Val, op2r, op2i);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_cmp_si(mpc op1, int op2)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_cmp_si(out result, op1.Val, op2);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_real(mpfr rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_real(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_imag(mpfr rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_imag(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_arg(mpfr rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_arg(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_proj(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_proj(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_add(mpc rop, mpc op1, mpc op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_add(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_add_ui(mpc rop, mpc op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_add_ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_add_fr(mpc rop, mpc op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_add_fr(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_sub(mpc rop, mpc op1, mpc op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_sub(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_sub_fr(mpc rop, mpc op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_sub_fr(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_fr_sub(mpc rop, mpfr op1, mpc op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_fr_sub(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_sub_ui(mpc rop, mpc op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_sub_ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_ui_sub(mpc rop, uint op1, mpc op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_ui_sub(out result, rop.Val, op1, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_ui_ui_sub(mpc rop, uint re1, uint im1, mpc op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_ui_ui_sub(out result, rop.Val, re1, im1, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_neg(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_neg(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_mul(mpc rop, mpc op1, mpc op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_mul(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_mul_ui(mpc rop, mpc op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_mul_ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_mul_si(mpc rop, mpc op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_mul_si(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_mul_fr(mpc rop, mpc op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_mul_fr(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_mul_i(mpc rop, mpc op, int sgn, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_mul_i(out result, rop.Val, op.Val, sgn, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_sqr(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_sqr(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_fma(mpc rop, mpc op1, mpc op2, mpc op3, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_fma(out result, rop.Val, op1.Val, op2.Val, op3.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_div(mpc rop, mpc op1, mpc op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_div(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_div_ui(mpc rop, mpc op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_div_ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_div_fr(mpc rop, mpc op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_div_fr(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_ui_div(mpc rop, uint op1, mpc op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_ui_div(out result, rop.Val, op1, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_fr_div(mpc rop, mpfr op1, mpc op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_fr_div(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_conj(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_conj(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_abs(mpfr rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_abs(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_norm(mpfr rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_norm(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_mul_2ui(mpc rop, mpc op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_mul_2ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_mul_2si(mpc rop, mpc op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_mul_2si(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_div_2ui(mpc rop, mpc op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_div_2ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_div_2si(mpc rop, mpc op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_div_2si(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_sqrt(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_sqrt(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_pow(mpc rop, mpc op1, mpc op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_pow(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_pow_d(mpc rop, mpc op1, double op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_pow_d(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_pow_si(mpc rop, mpc op1, int op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_pow_si(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_pow_ui(mpc rop, mpc op1, uint op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_pow_ui(out result, rop.Val, op1.Val, op2, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_pow_z(mpc rop, mpc op1, mpz op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_pow_z(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_pow_fr(mpc rop, mpc op1, mpfr op2, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_pow_fr(out result, rop.Val, op1.Val, op2.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_exp(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_exp(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_log(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_log(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_log10(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_log10(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_sin(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_sin(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_cos(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_cos(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_sin_cos(mpc rop_sin, mpc rop_cos, mpc op, int rnd_sin, int rnd_cos)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_sin_cos(out result, rop_sin.Val, rop_cos.Val, op.Val, rnd_sin, rnd_cos);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_tan(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_tan(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_sinh(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_sinh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_cosh(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_cosh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_tanh(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_tanh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_asin(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_asin(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_acos(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_acos(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_atan(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_atan(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_asinh(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_asinh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_acosh(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_acosh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_atanh(mpc rop, mpc op, int rnd)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_atanh(out result, rop.Val, op.Val, rnd);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }
    public static int mpc_urandom(mpc rop, randstate state)
    {
        int __retval;
        int result;
        __retval= xmpir_mpc_urandom(out result, rop.Val, state.Val);
        if( __retval!=0 ) HandleError(__retval);
        return result;
    }

}
}
