mp_constructor<mpz> mpz_init();
mp_constructor<mpz> mpz_init2(in mp_bitcnt_t prec);
mp_constructor<mpz> mpz_init_set(in mpz_handle op);
mp_constructor<mpz> mpz_init_set_ui(in uint32 op);
mp_constructor<mpz> mpz_init_set_si(in sint32 op);
mp_constructor<mpz> mpz_init_set_d(in double op);
mp_constructor<mpz> mpz_init_set_str(in str_pointer str, in uint32 _base);

mp_constructor<mpq> mpq_init();

mp_constructor<mpf> mpf_init();
mp_constructor<mpf> mpf_init2(in mp_bitcnt_t prec);
mp_constructor<mpf> mpf_init_set(in mpf_handle op);
mp_constructor<mpf> mpf_init_set_ui(in uint32 op);
mp_constructor<mpf> mpf_init_set_si(in sint32 op);
mp_constructor<mpf> mpf_init_set_d(in double op);
mp_constructor<mpf> mpf_init_set_str(in str_pointer str, in uint32 _base);

mp_destructor<mpz> mpz_clear();
mp_destructor<mpq> mpq_clear();
mp_destructor<mpf> mpf_clear();

function void xmpir_dummy();
function sint32 xmpir_dummy_add(in sint32 a, in sint32 b);
function sint32 xmpir_dummy_3mpz(in mpz_handle op0, in mpz_handle op1, in mpz_handle op2);

mp_constructor<gmp_randstate> gmp_randinit_default();
mp_constructor<gmp_randstate> gmp_randinit_mt();
mp_constructor<gmp_randstate> gmp_randinit_lc_2exp(in mpz_handle a, in uint32 c, in mp_bitcnt_t m2exp);
mp_constructor<gmp_randstate> gmp_randinit_lc_2exp_size(in mp_bitcnt_t size);
mp_constructor<gmp_randstate> gmp_randinit_set(in gmp_randstate_handle op);
mp_destructor<gmp_randstate>  gmp_randclear();
function void gmp_randseed(in gmp_randstate_handle state, in mpz_handle seed);
function void gmp_randseed_ui(in gmp_randstate_handle state, in uint32 seed);
function uint32 gmp_urandomb_ui(in gmp_randstate_handle state, in uint32 n);
function uint32 gmp_urandomm_ui(in gmp_randstate_handle state, in uint32 n);

function void mpz_realloc2(in mpz_handle x, in uint32 n);
function void mpf_set_default_prec(in mp_bitcnt_t prec);
function mp_bitcnt_t mpf_get_default_prec();
function void mpz_set(in mpz_handle rop, in mpz_handle op);
function void mpz_set_ui(in mpz_handle rop, in uint32 op);
function void mpz_set_si(in mpz_handle rop, in sint32 op);
function void mpz_set_d(in mpz_handle rop, in double op);
function void mpz_set_q(in mpz_handle rop, in mpq_handle op);
function void mpz_set_f(in mpz_handle rop, in mpf_handle op);
function sint32 mpz_set_str(in mpz_handle rop, in str_pointer str, in uint32 _base);
function void mpz_swap(in mpz_handle rop1, in mpz_handle rop2);
function uint32 mpz_get_ui (in mpz_handle op);
function sint32 mpz_get_si (in mpz_handle op);
function double mpz_get_d (in mpz_handle op);
function double mpz_get_d_2exp (out sint32 expptr, in mpz_handle op);
function str_pointer mpz_get_string(in uint32 _base, in mpz_handle op);
function void mpz_add (in mpz_handle rop, in mpz_handle op1, in mpz_handle op2);
function void mpz_add_ui (in mpz_handle rop, in mpz_handle op1, in uint32 op2);
function void mpz_sub (in mpz_handle rop, in mpz_handle op1, in mpz_handle op2);
function void mpz_sub_ui (in mpz_handle rop, in mpz_handle op1, in uint32 op2);
function void mpz_ui_sub (in mpz_handle rop, in uint32 op1, in mpz_handle op2);
function void mpz_mul (in mpz_handle rop, in mpz_handle op1, in mpz_handle op2);
function void mpz_mul_si (in mpz_handle rop, in mpz_handle op1, in sint32 op2);
function void mpz_mul_ui (in mpz_handle rop, in mpz_handle op1, in uint32 op2);
function void mpz_addmul (in mpz_handle rop, in mpz_handle op1, in mpz_handle op2);
function void mpz_addmul_ui (in mpz_handle rop, in mpz_handle op1, in uint32 op2);
function void mpz_submul (in mpz_handle rop, in mpz_handle op1, in mpz_handle op2);
function void mpz_submul_ui (in mpz_handle rop, in mpz_handle op1, in uint32 op2);
function void mpz_mul_2exp (in mpz_handle rop, in mpz_handle op1, in mp_bitcnt_t op2);
function void mpz_neg (in mpz_handle rop, in mpz_handle op);
function void mpz_abs (in mpz_handle rop, in mpz_handle op);
function void mpz_cdiv_q (in mpz_handle q, in mpz_handle n, in mpz_handle d);
function void mpz_cdiv_r (in mpz_handle r, in mpz_handle n, in mpz_handle d);
function void mpz_cdiv_qr (in mpz_handle q, in mpz_handle r, in mpz_handle n, in mpz_handle d);
function uint32 mpz_cdiv_q_ui (in mpz_handle q, in mpz_handle n, in uint32 d);
function uint32 mpz_cdiv_r_ui (in mpz_handle r, in mpz_handle n, in uint32 d);
function uint32 mpz_cdiv_qr_ui (in mpz_handle q, in mpz_handle r, in mpz_handle n, in uint32 d);
function uint32 mpz_cdiv_ui (in mpz_handle n, in uint32 d);
function void mpz_cdiv_q_2exp (in mpz_handle q, in mpz_handle n, in mp_bitcnt_t b);
function void mpz_cdiv_r_2exp (in mpz_handle r, in mpz_handle n, in mp_bitcnt_t b);
function void mpz_fdiv_q (in mpz_handle q, in mpz_handle n, in mpz_handle d);
function void mpz_fdiv_r (in mpz_handle r, in mpz_handle n, in mpz_handle d);
function void mpz_fdiv_qr (in mpz_handle q, in mpz_handle r, in mpz_handle n, in mpz_handle d);
function uint32 mpz_fdiv_q_ui (in mpz_handle q, in mpz_handle n, in uint32 d);
function uint32 mpz_fdiv_r_ui (in mpz_handle r, in mpz_handle n, in uint32 d);
function uint32 mpz_fdiv_qr_ui (in mpz_handle q, in mpz_handle r, in mpz_handle n, in uint32 d);
function uint32 mpz_fdiv_ui (in mpz_handle n, in uint32 d);
function void mpz_fdiv_q_2exp (in mpz_handle q, in mpz_handle n, in mp_bitcnt_t b);
function void mpz_fdiv_r_2exp (in mpz_handle r, in mpz_handle n, in mp_bitcnt_t b);
function void mpz_tdiv_q (in mpz_handle q, in mpz_handle n, in mpz_handle d);
function void mpz_tdiv_r (in mpz_handle r, in mpz_handle n, in mpz_handle d);
function void mpz_tdiv_qr (in mpz_handle q, in mpz_handle r, in mpz_handle n, in mpz_handle d);
function uint32 mpz_tdiv_q_ui (in mpz_handle q, in mpz_handle n, in uint32 d);
function uint32 mpz_tdiv_r_ui (in mpz_handle r, in mpz_handle n, in uint32 d);
function uint32 mpz_tdiv_qr_ui (in mpz_handle q, in mpz_handle r, in mpz_handle n, in uint32 d);
function uint32 mpz_tdiv_ui (in mpz_handle n, in uint32 d);
function void mpz_tdiv_q_2exp (in mpz_handle q, in mpz_handle n, in mp_bitcnt_t b);
function void mpz_tdiv_r_2exp (in mpz_handle r, in mpz_handle n, in mp_bitcnt_t b);
function void mpz_mod (in mpz_handle r, in mpz_handle n, in mpz_handle d);
function uint32 mpz_mod_ui (in mpz_handle r, in mpz_handle n, in uint32 d);
function void mpz_divexact (in mpz_handle q, in mpz_handle n, in mpz_handle d);
function void mpz_divexact_ui (in mpz_handle q, in mpz_handle n, in uint32 d);
function sint32 mpz_divisible_p (in mpz_handle n, in mpz_handle d);
function sint32 mpz_divisible_ui_p (in mpz_handle n, in uint32 d);
function sint32 mpz_divisible_2exp_p (in mpz_handle n, in mp_bitcnt_t b);
function sint32 mpz_congruent_p (in mpz_handle n, in mpz_handle c, in mpz_handle d);
function sint32 mpz_congruent_ui_p (in mpz_handle n, in uint32 c, in uint32 d);
function sint32 mpz_congruent_2exp_p (in mpz_handle n, in mpz_handle c, in mp_bitcnt_t b);
function void mpz_powm (in mpz_handle rop, in mpz_handle base, in mpz_handle _exp, in mpz_handle _mod);
function void mpz_powm_ui (in mpz_handle rop, in mpz_handle base, in uint32 _exp, in mpz_handle _mod);
function void mpz_pow_ui (in mpz_handle rop, in mpz_handle base, in uint32 _exp);
function void mpz_ui_pow_ui (in mpz_handle rop, in uint32 base, in uint32 _exp);
function sint32 mpz_root (in mpz_handle rop, in mpz_handle op, in uint32 n);
function void mpz_nthroot (in mpz_handle rop, in mpz_handle op, in uint32 n);
function void mpz_rootrem (in mpz_handle root, in mpz_handle rem, in mpz_handle u, in uint32 n);
function void mpz_sqrt (in mpz_handle rop, in mpz_handle op);
function void mpz_sqrtrem (in mpz_handle rop1, in mpz_handle rop2, in mpz_handle op);
function sint32 mpz_perfect_power_p (in mpz_handle op);
function sint32 mpz_perfect_square_p (in mpz_handle op);
function sint32 mpz_probable_prime_p (in mpz_handle n, in gmp_randstate_handle state, in sint32 prob, in uint32 div);
function sint32 mpz_likely_prime_p (in mpz_handle n, in gmp_randstate_handle state, in uint32 div);
function sint32 mpz_probab_prime_p (in mpz_handle n, in uint32 reps);
function void mpz_nextprime (in mpz_handle rop, in mpz_handle op);
function void mpz_next_prime_candidate (in mpz_handle rop, in mpz_handle op, in gmp_randstate_handle state);
function void mpz_gcd (in mpz_handle rop, in mpz_handle op1, in mpz_handle op2);
function uint32 mpz_gcd_ui (in mpz_handle rop, in mpz_handle op1, in uint32 op2);
function void mpz_gcdext (in mpz_handle g, in mpz_handle s, in mpz_handle t, in mpz_handle a, in mpz_handle b);
function void mpz_lcm (in mpz_handle rop, in mpz_handle op1, in mpz_handle op2);
function void mpz_lcm_ui (in mpz_handle rop, in mpz_handle op1, in uint32 op2);
function sint32 mpz_invert (in mpz_handle rop, in mpz_handle op1, in mpz_handle op2);
function sint32 mpz_jacobi (in mpz_handle a, in mpz_handle b);
function sint32 mpz_legendre (in mpz_handle a, in mpz_handle p);
function sint32 mpz_kronecker (in mpz_handle a, in mpz_handle b);
function sint32 mpz_kronecker_si (in mpz_handle a, in sint32 b);
function sint32 mpz_kronecker_ui (in mpz_handle a, in uint32 b);
function sint32 mpz_si_kronecker (in sint32 a, in mpz_handle b);
function sint32 mpz_ui_kronecker (in uint32 a, in mpz_handle b);
function mp_bitcnt_t mpz_remove (in mpz_handle rop, in mpz_handle op, in mpz_handle f);
function void mpz_fac_ui (in mpz_handle rop, in uint32 op);
function void mpz_2fac_ui (in mpz_handle rop, in uint32 op);
function void mpz_mfac_uiui (in mpz_handle rop, in uint32 op, in uint32 m);
function void mpz_primorial_ui (in mpz_handle rop, in uint32 op);
function void mpz_bin_ui (in mpz_handle rop, in mpz_handle n, in uint32 k);
function void mpz_bin_uiui (in mpz_handle rop, in uint32 n, in uint32 k);
function void mpz_fib_ui (in mpz_handle fn, in uint32 n);
function void mpz_fib2_ui (in mpz_handle fn, in mpz_handle fnsub1, in uint32 n);
function void mpz_lucnum_ui (in mpz_handle ln, in uint32 n);
function void mpz_lucnum2_ui (in mpz_handle ln, in mpz_handle lnsub1, in uint32 n);
function sint32 mpz_cmp (in mpz_handle op1, in mpz_handle op2);
function sint32 mpz_cmp_d (in mpz_handle op1, in double op2);
function sint32 mpz_cmp_si (in mpz_handle op1, in sint32 op2);
function sint32 mpz_cmp_ui (in mpz_handle op1, in uint32 op2);
function sint32 mpz_cmpabs (in mpz_handle op1, in mpz_handle op2);
function sint32 mpz_cmpabs_d (in mpz_handle op1, in double op2);
function sint32 mpz_cmpabs_ui (in mpz_handle op1, in uint32 op2);
function sint32 mpz_sgn (in mpz_handle op);
function void mpz_and (in mpz_handle rop, in mpz_handle op1, in mpz_handle op2);
function void mpz_ior (in mpz_handle rop, in mpz_handle op1, in mpz_handle op2);
function void mpz_xor (in mpz_handle rop, in mpz_handle op1, in mpz_handle op2);
function void mpz_com (in mpz_handle rop, in mpz_handle op);

function mp_bitcnt_t mpz_popcount (in mpz_handle op);
function mp_bitcnt_t mpz_hamdist (in mpz_handle op1, in mpz_handle op2);
function mp_bitcnt_t mpz_scan0 (in mpz_handle op, in mp_bitcnt_t starting_bit);
function mp_bitcnt_t mpz_scan1 (in mpz_handle op, in mp_bitcnt_t starting_bit);
function void mpz_setbit (in mpz_handle rop, in mp_bitcnt_t bit_index);
function void mpz_clrbit (in mpz_handle rop, in mp_bitcnt_t bit_index);
function void mpz_combit (in mpz_handle rop, in mp_bitcnt_t bit_index);
function sint32 mpz_tstbit(in mpz_handle op, in mp_bitcnt_t bit_index);

function void mpz_urandomb (in mpz_handle rop, in gmp_randstate_handle state, in mp_bitcnt_t n);
function void mpz_urandomm (in mpz_handle rop, in gmp_randstate_handle state, in mpz_handle n);
function void mpz_rrandomb (in mpz_handle rop, in gmp_randstate_handle state, in mp_bitcnt_t n);
function sint32 mpz_fits_uint_p (in mpz_handle op);
function sint32 mpz_fits_sint_p (in mpz_handle op);
function sint32 mpz_odd_p (in mpz_handle op);
function sint32 mpz_even_p (in mpz_handle op);
function mpir_ui mpz_sizeinbase (in mpz_handle op, in uint32 base);
function void mpq_canonicalize (in mpq_handle op);
function void mpq_set (in mpq_handle rop, in mpq_handle op);
function void mpq_set_z (in mpq_handle rop, in mpz_handle op);
function void mpq_set_ui (in mpq_handle rop, in uint32 op1, in uint32 op2);
function void mpq_set_si (in mpq_handle rop, in sint32 op1, in uint32 op2);
function sint32 mpq_set_str (in mpq_handle rop, in str_pointer str, in uint32 base);
function void mpq_swap (in mpq_handle rop1, in mpq_handle rop2);
function double mpq_get_d (in mpq_handle op);
function void mpq_set_d (in mpq_handle rop, in double op);
function void mpq_set_f (in mpq_handle rop, in mpf_handle op);
function str_pointer mpq_get_string (in uint32 base, in mpq_handle op);
function void mpq_add (in mpq_handle sum, in mpq_handle addend1, in mpq_handle addend2);
function void mpq_sub (in mpq_handle difference, in mpq_handle minuend, in mpq_handle subtrahend);
function void mpq_mul (in mpq_handle product, in mpq_handle multiplier, in mpq_handle multiplicand);
function void mpq_mul_2exp (in mpq_handle rop, in mpq_handle op1, in mp_bitcnt_t op2);
function void mpq_div (in mpq_handle quotient, in mpq_handle dividend, in mpq_handle divisor);
function void mpq_div_2exp (in mpq_handle rop, in mpq_handle op1, in mp_bitcnt_t op2);
function void mpq_neg (in mpq_handle negated_operand, in mpq_handle operand);
function void mpq_abs (in mpq_handle rop, in mpq_handle op);
function void mpq_inv (in mpq_handle inverted_number, in mpq_handle number);
function sint32 mpq_cmp (in mpq_handle op1, in mpq_handle op2);
function sint32 mpq_cmp_ui (in mpq_handle op1, in uint32 num2, in uint32 den2);
function sint32 mpq_cmp_si (in mpq_handle op1, in sint32 num2, in uint32 den2);
function sint32 mpq_sgn (in mpq_handle op);
function sint32 mpq_equal (in mpq_handle op1, in mpq_handle op2);
function void mpq_get_num (in mpz_handle numerator, in mpq_handle rational);
function void mpq_get_den (in mpz_handle denominator, in mpq_handle rational);
function void mpq_set_num (in mpq_handle rational, in mpz_handle numerator);
function void mpq_set_den (in mpq_handle rational, in mpz_handle denominator);
function mp_bitcnt_t mpf_get_prec (in mpf_handle op);
function void mpf_set_prec (in mpf_handle rop, in mp_bitcnt_t prec);
function void mpf_set (in mpf_handle rop, in mpf_handle op);
function void mpf_set_ui (in mpf_handle rop, in uint32 op);
function void mpf_set_si (in mpf_handle rop, in sint32 op);
function void mpf_set_d (in mpf_handle rop, in double op);
function void mpf_set_z (in mpf_handle rop, in mpz_handle op);
function void mpf_set_q (in mpf_handle rop, in mpq_handle op);
function sint32 mpf_set_str (in mpf_handle rop, in str_pointer str, in uint32 base);
function void mpf_swap (in mpf_handle rop1, in mpf_handle rop2);
function double mpf_get_d (in mpf_handle op);
function double mpf_get_d_2exp (out sint32 expptr, in mpf_handle op);
function sint32 mpf_get_si (in mpf_handle op);
function uint32 mpf_get_ui (in mpf_handle op);
function str_pointer mpf_get_string(out mp_exp_t expptr, in uint32 base, in uint32 n_digits, in mpf_handle op);
function void mpf_add (in mpf_handle rop, in mpf_handle op1, in mpf_handle op2);
function void mpf_add_ui (in mpf_handle rop, in mpf_handle op1, in uint32 op2);
function void mpf_sub (in mpf_handle rop, in mpf_handle op1, in mpf_handle op2);
function void mpf_ui_sub (in mpf_handle rop, in uint32 op1, in mpf_handle op2);
function void mpf_sub_ui (in mpf_handle rop, in mpf_handle op1, in uint32 op2);
function void mpf_mul (in mpf_handle rop, in mpf_handle op1, in mpf_handle op2);
function void mpf_mul_ui (in mpf_handle rop, in mpf_handle op1, in uint32 op2);
function void mpf_div (in mpf_handle rop, in mpf_handle op1, in mpf_handle op2);
function void mpf_ui_div (in mpf_handle rop, in uint32 op1, in mpf_handle op2);
function void mpf_div_ui (in mpf_handle rop, in mpf_handle op1, in uint32 op2);
function void mpf_sqrt (in mpf_handle rop, in mpf_handle op);
function void mpf_sqrt_ui (in mpf_handle rop, in uint32 op);
function void mpf_pow_ui (in mpf_handle rop, in mpf_handle op1, in uint32 op2);
function void mpf_neg (in mpf_handle rop, in mpf_handle op);
function void mpf_abs (in mpf_handle rop, in mpf_handle op);
function void mpf_mul_2exp (in mpf_handle rop, in mpf_handle op1, in mp_bitcnt_t op2);
function void mpf_div_2exp (in mpf_handle rop, in mpf_handle op1, in mp_bitcnt_t op2);
function sint32 mpf_cmp (in mpf_handle op1, in mpf_handle op2);
function sint32 mpf_cmp_d (in mpf_handle op1, in double op2);
function sint32 mpf_cmp_ui (in mpf_handle op1, in uint32 op2);
function sint32 mpf_cmp_si (in mpf_handle op1, in sint32 op2);
function sint32 mpf_eq (in mpf_handle op1, in mpf_handle op2, in mp_bitcnt_t op3);
function void mpf_reldiff (in mpf_handle rop, in mpf_handle op1, in mpf_handle op2);
function sint32 mpf_sgn (in mpf_handle op);
function void mpf_ceil (in mpf_handle rop, in mpf_handle op);
function void mpf_floor (in mpf_handle rop, in mpf_handle op);
function void mpf_trunc (in mpf_handle rop, in mpf_handle op);
function sint32 mpf_integer_p (in mpf_handle op);
function sint32 mpf_fits_uint_p (in mpf_handle op);
function sint32 mpf_fits_sint_p (in mpf_handle op);
function void mpf_urandomb (in mpf_handle rop, in gmp_randstate_handle state, in mp_bitcnt_t nbits);
function void mpf_rrandomb (in mpf_handle rop, in gmp_randstate_handle state, in mp_size_t max_size, in mp_exp_t exp);
