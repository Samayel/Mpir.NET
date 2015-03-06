
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
Minor modifications by John Reynolds, to provide binary import/export
functions. Use e.g. Kdiff to see exact changes from orginal X-MPIR.
*/    


#include <stdio.h>
#include <stdlib.h>
#include <mpir.h>
#include <mpfr.h>
#include <mpc.h>

#ifdef XMPIR_FOR_WINDOWS
#define DLLEXPORT __declspec(dllexport)
#endif
#ifdef XMPIR_FOR_LINUX
#define DLLEXPORT
#endif
enum
{
    XMPIR_OK = 0,
    XMPIR_MALLOC_ERROR = 1,
    XMPIR_DIV_BY_ZERO_ERROR = 2,
    XMPIR_32_64_ERROR = 3
};
typedef struct { mpz_t val; } mpz_wrapper;
typedef struct { mpq_t val; } mpq_wrapper;
typedef struct { mpf_t val; } mpf_wrapper;
typedef struct { mpfr_t val; } mpfr_wrapper;
typedef struct { mpc_t val; } mpc_wrapper;
typedef struct { gmp_randstate_t val; } gmp_randstate_wrapper;

DLLEXPORT int xmpir_malloc(void **p, int size)
{
    *p = malloc(size);
    return *p ? XMPIR_OK : XMPIR_MALLOC_ERROR;
}
DLLEXPORT int xmpir_free(void *p)
{
    free(p);
    return XMPIR_OK;
}


DLLEXPORT void Mpir_internal_mpz_import(mpz_t rop, size_t count, int order, size_t size, int endian, size_t nails, const void *op)
{
    mpz_import(rop, count, order, size, endian, nails, op);
}
DLLEXPORT void *Mpir_internal_mpz_export(void *rop, size_t *countp, int order, size_t size, int endian, size_t nails, mpz_t op)
{
    return mpz_export(rop, countp, order, size, endian, nails, op);
}


char * mpz_get_string(int base, mpz_srcptr op)
{
    return mpz_get_str(NULL, base, op);
}
char * mpq_get_string(int base, mpq_srcptr op)
{
    return mpq_get_str(NULL, base, op);
}
char * mpf_get_string(mp_exp_t *expptr, int base, size_t n_digits,  mpf_srcptr op)
{
    return mpf_get_str(NULL, expptr, base, n_digits, op);
}
void xmpir_dummy()
{
}
int xmpir_dummy_add(int a, int b)
{
    return a+b;
}
int xmpir_dummy_3mpz(mpz_srcptr op0, mpz_srcptr op1, mpz_srcptr op2)
{
    return 0;
}

DLLEXPORT int xmpir_mpz_init(mpz_wrapper** result)
{
    *result = (mpz_wrapper*)malloc(sizeof(mpz_wrapper));
    mpz_init((*result)->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_init2(mpz_wrapper** result, unsigned long long __prec)
{
    volatile mp_bitcnt_t prec;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    *result = (mpz_wrapper*)malloc(sizeof(mpz_wrapper));
    mpz_init2((*result)->val, prec);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_init_set(mpz_wrapper** result, mpz_wrapper* op)
{
    *result = (mpz_wrapper*)malloc(sizeof(mpz_wrapper));
    mpz_init_set((*result)->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_init_set_ui(mpz_wrapper** result, unsigned int op)
{
    *result = (mpz_wrapper*)malloc(sizeof(mpz_wrapper));
    mpz_init_set_ui((*result)->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_init_set_si(mpz_wrapper** result, signed int op)
{
    *result = (mpz_wrapper*)malloc(sizeof(mpz_wrapper));
    mpz_init_set_si((*result)->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_init_set_d(mpz_wrapper** result, double op)
{
    *result = (mpz_wrapper*)malloc(sizeof(mpz_wrapper));
    mpz_init_set_d((*result)->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_init_set_str(mpz_wrapper** result, char* str, unsigned int _base)
{
    *result = (mpz_wrapper*)malloc(sizeof(mpz_wrapper));
    mpz_init_set_str((*result)->val, str, _base);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_init(mpq_wrapper** result)
{
    *result = (mpq_wrapper*)malloc(sizeof(mpq_wrapper));
    mpq_init((*result)->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_init(mpf_wrapper** result)
{
    *result = (mpf_wrapper*)malloc(sizeof(mpf_wrapper));
    mpf_init((*result)->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_init2(mpf_wrapper** result, unsigned long long __prec)
{
    volatile mp_bitcnt_t prec;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    *result = (mpf_wrapper*)malloc(sizeof(mpf_wrapper));
    mpf_init2((*result)->val, prec);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_init_set(mpf_wrapper** result, mpf_wrapper* op)
{
    *result = (mpf_wrapper*)malloc(sizeof(mpf_wrapper));
    mpf_init_set((*result)->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_init_set_ui(mpf_wrapper** result, unsigned int op)
{
    *result = (mpf_wrapper*)malloc(sizeof(mpf_wrapper));
    mpf_init_set_ui((*result)->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_init_set_si(mpf_wrapper** result, signed int op)
{
    *result = (mpf_wrapper*)malloc(sizeof(mpf_wrapper));
    mpf_init_set_si((*result)->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_init_set_d(mpf_wrapper** result, double op)
{
    *result = (mpf_wrapper*)malloc(sizeof(mpf_wrapper));
    mpf_init_set_d((*result)->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_init_set_str(mpf_wrapper** result, char* str, unsigned int _base)
{
    *result = (mpf_wrapper*)malloc(sizeof(mpf_wrapper));
    mpf_init_set_str((*result)->val, str, _base);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_init(mpfr_wrapper** result)
{
    *result = (mpfr_wrapper*)malloc(sizeof(mpfr_wrapper));
    mpfr_init((*result)->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_init2(mpfr_wrapper** result, signed long long __prec)
{
    volatile mpfr_prec_t prec;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    *result = (mpfr_wrapper*)malloc(sizeof(mpfr_wrapper));
    mpfr_init2((*result)->val, prec);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_init_set(mpfr_wrapper** result, mpfr_wrapper* op, signed int rnd)
{
    *result = (mpfr_wrapper*)malloc(sizeof(mpfr_wrapper));
    mpfr_init_set((*result)->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_init_set_ui(mpfr_wrapper** result, unsigned int op, signed int rnd)
{
    *result = (mpfr_wrapper*)malloc(sizeof(mpfr_wrapper));
    mpfr_init_set_ui((*result)->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_init_set_si(mpfr_wrapper** result, signed int op, signed int rnd)
{
    *result = (mpfr_wrapper*)malloc(sizeof(mpfr_wrapper));
    mpfr_init_set_si((*result)->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_init_set_d(mpfr_wrapper** result, double op, signed int rnd)
{
    *result = (mpfr_wrapper*)malloc(sizeof(mpfr_wrapper));
    mpfr_init_set_d((*result)->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_init_set_z(mpfr_wrapper** result, mpz_wrapper* op, signed int rnd)
{
    *result = (mpfr_wrapper*)malloc(sizeof(mpfr_wrapper));
    mpfr_init_set_z((*result)->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_init_set_q(mpfr_wrapper** result, mpq_wrapper* op, signed int rnd)
{
    *result = (mpfr_wrapper*)malloc(sizeof(mpfr_wrapper));
    mpfr_init_set_q((*result)->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_init_set_f(mpfr_wrapper** result, mpf_wrapper* op, signed int rnd)
{
    *result = (mpfr_wrapper*)malloc(sizeof(mpfr_wrapper));
    mpfr_init_set_f((*result)->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_init_set_str(mpfr_wrapper** result, char* str, unsigned int base, signed int rnd)
{
    *result = (mpfr_wrapper*)malloc(sizeof(mpfr_wrapper));
    mpfr_init_set_str((*result)->val, str, base, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_init2(mpc_wrapper** result, signed long long __prec)
{
    volatile mpfr_prec_t prec;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    *result = (mpc_wrapper*)malloc(sizeof(mpc_wrapper));
    mpc_init2((*result)->val, prec);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_init3(mpc_wrapper** result, signed long long __prec_r, signed long long __prec_i)
{
    volatile mpfr_prec_t prec_i;
    volatile mpfr_prec_t prec_r;
    prec_r = __prec_r;
    if( prec_r!=__prec_r ) return XMPIR_32_64_ERROR;
    prec_i = __prec_i;
    if( prec_i!=__prec_i ) return XMPIR_32_64_ERROR;
    *result = (mpc_wrapper*)malloc(sizeof(mpc_wrapper));
    mpc_init3((*result)->val, prec_r, prec_i);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_clear(mpz_wrapper* _v)
{
    mpz_clear(_v->val);
    free(_v);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_clear(mpq_wrapper* _v)
{
    mpq_clear(_v->val);
    free(_v);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_clear(mpf_wrapper* _v)
{
    mpf_clear(_v->val);
    free(_v);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_clear(mpfr_wrapper* _v)
{
    mpfr_clear(_v->val);
    free(_v);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_clear(mpc_wrapper* _v)
{
    mpc_clear(_v->val);
    free(_v);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_xmpir_dummy()
{
    xmpir_dummy();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_xmpir_dummy_add(signed int* result, signed int a, signed int b)
{
    *result = xmpir_dummy_add(a, b);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_xmpir_dummy_3mpz(signed int* result, mpz_wrapper* op0, mpz_wrapper* op1, mpz_wrapper* op2)
{
    *result = xmpir_dummy_3mpz(op0->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_gmp_randinit_default(gmp_randstate_wrapper** result)
{
    *result = (gmp_randstate_wrapper*)malloc(sizeof(gmp_randstate_wrapper));
    gmp_randinit_default((*result)->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_gmp_randinit_mt(gmp_randstate_wrapper** result)
{
    *result = (gmp_randstate_wrapper*)malloc(sizeof(gmp_randstate_wrapper));
    gmp_randinit_mt((*result)->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_gmp_randinit_lc_2exp(gmp_randstate_wrapper** result, mpz_wrapper* a, unsigned int c, unsigned long long __m2exp)
{
    volatile mp_bitcnt_t m2exp;
    m2exp = __m2exp;
    if( m2exp!=__m2exp ) return XMPIR_32_64_ERROR;
    *result = (gmp_randstate_wrapper*)malloc(sizeof(gmp_randstate_wrapper));
    gmp_randinit_lc_2exp((*result)->val, a->val, c, m2exp);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_gmp_randinit_lc_2exp_size(gmp_randstate_wrapper** result, unsigned long long __size)
{
    volatile mp_bitcnt_t size;
    size = __size;
    if( size!=__size ) return XMPIR_32_64_ERROR;
    *result = (gmp_randstate_wrapper*)malloc(sizeof(gmp_randstate_wrapper));
    gmp_randinit_lc_2exp_size((*result)->val, size);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_gmp_randinit_set(gmp_randstate_wrapper** result, gmp_randstate_wrapper* op)
{
    *result = (gmp_randstate_wrapper*)malloc(sizeof(gmp_randstate_wrapper));
    gmp_randinit_set((*result)->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_gmp_randclear(gmp_randstate_wrapper* _v)
{
    gmp_randclear(_v->val);
    free(_v);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_gmp_randseed(gmp_randstate_wrapper* state, mpz_wrapper* seed)
{
    gmp_randseed(state->val, seed->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_gmp_randseed_ui(gmp_randstate_wrapper* state, unsigned int seed)
{
    gmp_randseed_ui(state->val, seed);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_gmp_urandomb_ui(unsigned int* result, gmp_randstate_wrapper* state, unsigned int n)
{
    *result = gmp_urandomb_ui(state->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_gmp_urandomm_ui(unsigned int* result, gmp_randstate_wrapper* state, unsigned int n)
{
    *result = gmp_urandomm_ui(state->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_realloc2(mpz_wrapper* x, unsigned int n)
{
    mpz_realloc2(x->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_set(mpz_wrapper* rop, mpz_wrapper* op)
{
    mpz_set(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_set_ui(mpz_wrapper* rop, unsigned int op)
{
    mpz_set_ui(rop->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_set_si(mpz_wrapper* rop, signed int op)
{
    mpz_set_si(rop->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_set_d(mpz_wrapper* rop, double op)
{
    mpz_set_d(rop->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_set_q(mpz_wrapper* rop, mpq_wrapper* op)
{
    mpz_set_q(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_set_f(mpz_wrapper* rop, mpf_wrapper* op)
{
    mpz_set_f(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_set_str(signed int* result, mpz_wrapper* rop, char* str, unsigned int _base)
{
    *result = mpz_set_str(rop->val, str, _base);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_swap(mpz_wrapper* rop1, mpz_wrapper* rop2)
{
    mpz_swap(rop1->val, rop2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_get_ui(unsigned int* result, mpz_wrapper* op)
{
    *result = mpz_get_ui(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_get_si(signed int* result, mpz_wrapper* op)
{
    *result = mpz_get_si(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_get_d(double* result, mpz_wrapper* op)
{
    *result = mpz_get_d(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_get_d_2exp(double* result, signed int* expptr, mpz_wrapper* op)
{
    *result = mpz_get_d_2exp(expptr, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_get_string(char** result, unsigned int _base, mpz_wrapper* op)
{
    *result = mpz_get_string(_base, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_add(mpz_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2)
{
    mpz_add(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_add_ui(mpz_wrapper* rop, mpz_wrapper* op1, unsigned int op2)
{
    mpz_add_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_sub(mpz_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2)
{
    mpz_sub(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_sub_ui(mpz_wrapper* rop, mpz_wrapper* op1, unsigned int op2)
{
    mpz_sub_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_ui_sub(mpz_wrapper* rop, unsigned int op1, mpz_wrapper* op2)
{
    mpz_ui_sub(rop->val, op1, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_mul(mpz_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2)
{
    mpz_mul(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_mul_si(mpz_wrapper* rop, mpz_wrapper* op1, signed int op2)
{
    mpz_mul_si(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_mul_ui(mpz_wrapper* rop, mpz_wrapper* op1, unsigned int op2)
{
    mpz_mul_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_addmul(mpz_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2)
{
    mpz_addmul(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_addmul_ui(mpz_wrapper* rop, mpz_wrapper* op1, unsigned int op2)
{
    mpz_addmul_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_submul(mpz_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2)
{
    mpz_submul(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_submul_ui(mpz_wrapper* rop, mpz_wrapper* op1, unsigned int op2)
{
    mpz_submul_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_mul_2exp(mpz_wrapper* rop, mpz_wrapper* op1, unsigned long long __op2)
{
    volatile mp_bitcnt_t op2;
    op2 = __op2;
    if( op2!=__op2 ) return XMPIR_32_64_ERROR;
    mpz_mul_2exp(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_neg(mpz_wrapper* rop, mpz_wrapper* op)
{
    mpz_neg(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_abs(mpz_wrapper* rop, mpz_wrapper* op)
{
    mpz_abs(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cdiv_q(mpz_wrapper* q, mpz_wrapper* n, mpz_wrapper* d)
{
    mpz_cdiv_q(q->val, n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cdiv_r(mpz_wrapper* r, mpz_wrapper* n, mpz_wrapper* d)
{
    mpz_cdiv_r(r->val, n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cdiv_qr(mpz_wrapper* q, mpz_wrapper* r, mpz_wrapper* n, mpz_wrapper* d)
{
    mpz_cdiv_qr(q->val, r->val, n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cdiv_q_ui(unsigned int* result, mpz_wrapper* q, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_cdiv_q_ui(q->val, n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cdiv_r_ui(unsigned int* result, mpz_wrapper* r, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_cdiv_r_ui(r->val, n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cdiv_qr_ui(unsigned int* result, mpz_wrapper* q, mpz_wrapper* r, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_cdiv_qr_ui(q->val, r->val, n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cdiv_ui(unsigned int* result, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_cdiv_ui(n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cdiv_q_2exp(mpz_wrapper* q, mpz_wrapper* n, unsigned long long __b)
{
    volatile mp_bitcnt_t b;
    b = __b;
    if( b!=__b ) return XMPIR_32_64_ERROR;
    mpz_cdiv_q_2exp(q->val, n->val, b);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cdiv_r_2exp(mpz_wrapper* r, mpz_wrapper* n, unsigned long long __b)
{
    volatile mp_bitcnt_t b;
    b = __b;
    if( b!=__b ) return XMPIR_32_64_ERROR;
    mpz_cdiv_r_2exp(r->val, n->val, b);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fdiv_q(mpz_wrapper* q, mpz_wrapper* n, mpz_wrapper* d)
{
    mpz_fdiv_q(q->val, n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fdiv_r(mpz_wrapper* r, mpz_wrapper* n, mpz_wrapper* d)
{
    mpz_fdiv_r(r->val, n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fdiv_qr(mpz_wrapper* q, mpz_wrapper* r, mpz_wrapper* n, mpz_wrapper* d)
{
    mpz_fdiv_qr(q->val, r->val, n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fdiv_q_ui(unsigned int* result, mpz_wrapper* q, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_fdiv_q_ui(q->val, n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fdiv_r_ui(unsigned int* result, mpz_wrapper* r, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_fdiv_r_ui(r->val, n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fdiv_qr_ui(unsigned int* result, mpz_wrapper* q, mpz_wrapper* r, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_fdiv_qr_ui(q->val, r->val, n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fdiv_ui(unsigned int* result, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_fdiv_ui(n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fdiv_q_2exp(mpz_wrapper* q, mpz_wrapper* n, unsigned long long __b)
{
    volatile mp_bitcnt_t b;
    b = __b;
    if( b!=__b ) return XMPIR_32_64_ERROR;
    mpz_fdiv_q_2exp(q->val, n->val, b);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fdiv_r_2exp(mpz_wrapper* r, mpz_wrapper* n, unsigned long long __b)
{
    volatile mp_bitcnt_t b;
    b = __b;
    if( b!=__b ) return XMPIR_32_64_ERROR;
    mpz_fdiv_r_2exp(r->val, n->val, b);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_tdiv_q(mpz_wrapper* q, mpz_wrapper* n, mpz_wrapper* d)
{
    mpz_tdiv_q(q->val, n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_tdiv_r(mpz_wrapper* r, mpz_wrapper* n, mpz_wrapper* d)
{
    mpz_tdiv_r(r->val, n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_tdiv_qr(mpz_wrapper* q, mpz_wrapper* r, mpz_wrapper* n, mpz_wrapper* d)
{
    mpz_tdiv_qr(q->val, r->val, n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_tdiv_q_ui(unsigned int* result, mpz_wrapper* q, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_tdiv_q_ui(q->val, n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_tdiv_r_ui(unsigned int* result, mpz_wrapper* r, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_tdiv_r_ui(r->val, n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_tdiv_qr_ui(unsigned int* result, mpz_wrapper* q, mpz_wrapper* r, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_tdiv_qr_ui(q->val, r->val, n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_tdiv_ui(unsigned int* result, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_tdiv_ui(n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_tdiv_q_2exp(mpz_wrapper* q, mpz_wrapper* n, unsigned long long __b)
{
    volatile mp_bitcnt_t b;
    b = __b;
    if( b!=__b ) return XMPIR_32_64_ERROR;
    mpz_tdiv_q_2exp(q->val, n->val, b);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_tdiv_r_2exp(mpz_wrapper* r, mpz_wrapper* n, unsigned long long __b)
{
    volatile mp_bitcnt_t b;
    b = __b;
    if( b!=__b ) return XMPIR_32_64_ERROR;
    mpz_tdiv_r_2exp(r->val, n->val, b);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_mod(mpz_wrapper* r, mpz_wrapper* n, mpz_wrapper* d)
{
    mpz_mod(r->val, n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_mod_ui(unsigned int* result, mpz_wrapper* r, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_mod_ui(r->val, n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_divexact(mpz_wrapper* q, mpz_wrapper* n, mpz_wrapper* d)
{
    mpz_divexact(q->val, n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_divexact_ui(mpz_wrapper* q, mpz_wrapper* n, unsigned int d)
{
    mpz_divexact_ui(q->val, n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_divisible_p(signed int* result, mpz_wrapper* n, mpz_wrapper* d)
{
    *result = mpz_divisible_p(n->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_divisible_ui_p(signed int* result, mpz_wrapper* n, unsigned int d)
{
    *result = mpz_divisible_ui_p(n->val, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_divisible_2exp_p(signed int* result, mpz_wrapper* n, unsigned long long __b)
{
    volatile mp_bitcnt_t b;
    b = __b;
    if( b!=__b ) return XMPIR_32_64_ERROR;
    *result = mpz_divisible_2exp_p(n->val, b);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_congruent_p(signed int* result, mpz_wrapper* n, mpz_wrapper* c, mpz_wrapper* d)
{
    *result = mpz_congruent_p(n->val, c->val, d->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_congruent_ui_p(signed int* result, mpz_wrapper* n, unsigned int c, unsigned int d)
{
    *result = mpz_congruent_ui_p(n->val, c, d);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_congruent_2exp_p(signed int* result, mpz_wrapper* n, mpz_wrapper* c, unsigned long long __b)
{
    volatile mp_bitcnt_t b;
    b = __b;
    if( b!=__b ) return XMPIR_32_64_ERROR;
    *result = mpz_congruent_2exp_p(n->val, c->val, b);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_powm(mpz_wrapper* rop, mpz_wrapper* base, mpz_wrapper* _exp, mpz_wrapper* _mod)
{
    mpz_powm(rop->val, base->val, _exp->val, _mod->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_powm_ui(mpz_wrapper* rop, mpz_wrapper* base, unsigned int _exp, mpz_wrapper* _mod)
{
    mpz_powm_ui(rop->val, base->val, _exp, _mod->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_pow_ui(mpz_wrapper* rop, mpz_wrapper* base, unsigned int _exp)
{
    mpz_pow_ui(rop->val, base->val, _exp);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_ui_pow_ui(mpz_wrapper* rop, unsigned int base, unsigned int _exp)
{
    mpz_ui_pow_ui(rop->val, base, _exp);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_root(signed int* result, mpz_wrapper* rop, mpz_wrapper* op, unsigned int n)
{
    *result = mpz_root(rop->val, op->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_nthroot(mpz_wrapper* rop, mpz_wrapper* op, unsigned int n)
{
    mpz_nthroot(rop->val, op->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_rootrem(mpz_wrapper* root, mpz_wrapper* rem, mpz_wrapper* u, unsigned int n)
{
    mpz_rootrem(root->val, rem->val, u->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_sqrt(mpz_wrapper* rop, mpz_wrapper* op)
{
    mpz_sqrt(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_sqrtrem(mpz_wrapper* rop1, mpz_wrapper* rop2, mpz_wrapper* op)
{
    mpz_sqrtrem(rop1->val, rop2->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_perfect_power_p(signed int* result, mpz_wrapper* op)
{
    *result = mpz_perfect_power_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_perfect_square_p(signed int* result, mpz_wrapper* op)
{
    *result = mpz_perfect_square_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_probable_prime_p(signed int* result, mpz_wrapper* n, gmp_randstate_wrapper* state, signed int prob, unsigned int div)
{
    *result = mpz_probable_prime_p(n->val, state->val, prob, div);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_likely_prime_p(signed int* result, mpz_wrapper* n, gmp_randstate_wrapper* state, unsigned int div)
{
    *result = mpz_likely_prime_p(n->val, state->val, div);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_probab_prime_p(signed int* result, mpz_wrapper* n, unsigned int reps)
{
    *result = mpz_probab_prime_p(n->val, reps);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_nextprime(mpz_wrapper* rop, mpz_wrapper* op)
{
    mpz_nextprime(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_next_prime_candidate(mpz_wrapper* rop, mpz_wrapper* op, gmp_randstate_wrapper* state)
{
    mpz_next_prime_candidate(rop->val, op->val, state->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_gcd(mpz_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2)
{
    mpz_gcd(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_gcd_ui(unsigned int* result, mpz_wrapper* rop, mpz_wrapper* op1, unsigned int op2)
{
    *result = mpz_gcd_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_gcdext(mpz_wrapper* g, mpz_wrapper* s, mpz_wrapper* t, mpz_wrapper* a, mpz_wrapper* b)
{
    mpz_gcdext(g->val, s->val, t->val, a->val, b->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_lcm(mpz_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2)
{
    mpz_lcm(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_lcm_ui(mpz_wrapper* rop, mpz_wrapper* op1, unsigned int op2)
{
    mpz_lcm_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_invert(signed int* result, mpz_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2)
{
    *result = mpz_invert(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_jacobi(signed int* result, mpz_wrapper* a, mpz_wrapper* b)
{
    *result = mpz_jacobi(a->val, b->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_legendre(signed int* result, mpz_wrapper* a, mpz_wrapper* p)
{
    *result = mpz_legendre(a->val, p->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_kronecker(signed int* result, mpz_wrapper* a, mpz_wrapper* b)
{
    *result = mpz_kronecker(a->val, b->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_kronecker_si(signed int* result, mpz_wrapper* a, signed int b)
{
    *result = mpz_kronecker_si(a->val, b);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_kronecker_ui(signed int* result, mpz_wrapper* a, unsigned int b)
{
    *result = mpz_kronecker_ui(a->val, b);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_si_kronecker(signed int* result, signed int a, mpz_wrapper* b)
{
    *result = mpz_si_kronecker(a, b->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_ui_kronecker(signed int* result, unsigned int a, mpz_wrapper* b)
{
    *result = mpz_ui_kronecker(a, b->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_remove(unsigned long long* __result, mpz_wrapper* rop, mpz_wrapper* op, mpz_wrapper* f)
{
    *__result = mpz_remove(rop->val, op->val, f->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fac_ui(mpz_wrapper* rop, unsigned int op)
{
    mpz_fac_ui(rop->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_2fac_ui(mpz_wrapper* rop, unsigned int op)
{
    mpz_2fac_ui(rop->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_mfac_uiui(mpz_wrapper* rop, unsigned int op, unsigned int m)
{
    mpz_mfac_uiui(rop->val, op, m);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_primorial_ui(mpz_wrapper* rop, unsigned int op)
{
    mpz_primorial_ui(rop->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_bin_ui(mpz_wrapper* rop, mpz_wrapper* n, unsigned int k)
{
    mpz_bin_ui(rop->val, n->val, k);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_bin_uiui(mpz_wrapper* rop, unsigned int n, unsigned int k)
{
    mpz_bin_uiui(rop->val, n, k);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fib_ui(mpz_wrapper* fn, unsigned int n)
{
    mpz_fib_ui(fn->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fib2_ui(mpz_wrapper* fn, mpz_wrapper* fnsub1, unsigned int n)
{
    mpz_fib2_ui(fn->val, fnsub1->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_lucnum_ui(mpz_wrapper* ln, unsigned int n)
{
    mpz_lucnum_ui(ln->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_lucnum2_ui(mpz_wrapper* ln, mpz_wrapper* lnsub1, unsigned int n)
{
    mpz_lucnum2_ui(ln->val, lnsub1->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cmp(signed int* result, mpz_wrapper* op1, mpz_wrapper* op2)
{
    *result = mpz_cmp(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cmp_d(signed int* result, mpz_wrapper* op1, double op2)
{
    *result = mpz_cmp_d(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cmp_si(signed int* result, mpz_wrapper* op1, signed int op2)
{
    *result = mpz_cmp_si(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cmp_ui(signed int* result, mpz_wrapper* op1, unsigned int op2)
{
    *result = mpz_cmp_ui(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cmpabs(signed int* result, mpz_wrapper* op1, mpz_wrapper* op2)
{
    *result = mpz_cmpabs(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cmpabs_d(signed int* result, mpz_wrapper* op1, double op2)
{
    *result = mpz_cmpabs_d(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_cmpabs_ui(signed int* result, mpz_wrapper* op1, unsigned int op2)
{
    *result = mpz_cmpabs_ui(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_sgn(signed int* result, mpz_wrapper* op)
{
    *result = mpz_sgn(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_and(mpz_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2)
{
    mpz_and(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_ior(mpz_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2)
{
    mpz_ior(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_xor(mpz_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2)
{
    mpz_xor(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_com(mpz_wrapper* rop, mpz_wrapper* op)
{
    mpz_com(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_popcount(unsigned long long* __result, mpz_wrapper* op)
{
    *__result = mpz_popcount(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_hamdist(unsigned long long* __result, mpz_wrapper* op1, mpz_wrapper* op2)
{
    *__result = mpz_hamdist(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_scan0(unsigned long long* __result, mpz_wrapper* op, unsigned long long __starting_bit)
{
    volatile mp_bitcnt_t starting_bit;
    starting_bit = __starting_bit;
    if( starting_bit!=__starting_bit ) return XMPIR_32_64_ERROR;
    *__result = mpz_scan0(op->val, starting_bit);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_scan1(unsigned long long* __result, mpz_wrapper* op, unsigned long long __starting_bit)
{
    volatile mp_bitcnt_t starting_bit;
    starting_bit = __starting_bit;
    if( starting_bit!=__starting_bit ) return XMPIR_32_64_ERROR;
    *__result = mpz_scan1(op->val, starting_bit);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_setbit(mpz_wrapper* rop, unsigned long long __bit_index)
{
    volatile mp_bitcnt_t bit_index;
    bit_index = __bit_index;
    if( bit_index!=__bit_index ) return XMPIR_32_64_ERROR;
    mpz_setbit(rop->val, bit_index);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_clrbit(mpz_wrapper* rop, unsigned long long __bit_index)
{
    volatile mp_bitcnt_t bit_index;
    bit_index = __bit_index;
    if( bit_index!=__bit_index ) return XMPIR_32_64_ERROR;
    mpz_clrbit(rop->val, bit_index);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_combit(mpz_wrapper* rop, unsigned long long __bit_index)
{
    volatile mp_bitcnt_t bit_index;
    bit_index = __bit_index;
    if( bit_index!=__bit_index ) return XMPIR_32_64_ERROR;
    mpz_combit(rop->val, bit_index);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_tstbit(signed int* result, mpz_wrapper* op, unsigned long long __bit_index)
{
    volatile mp_bitcnt_t bit_index;
    bit_index = __bit_index;
    if( bit_index!=__bit_index ) return XMPIR_32_64_ERROR;
    *result = mpz_tstbit(op->val, bit_index);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_urandomb(mpz_wrapper* rop, gmp_randstate_wrapper* state, unsigned long long __n)
{
    volatile mp_bitcnt_t n;
    n = __n;
    if( n!=__n ) return XMPIR_32_64_ERROR;
    mpz_urandomb(rop->val, state->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_urandomm(mpz_wrapper* rop, gmp_randstate_wrapper* state, mpz_wrapper* n)
{
    mpz_urandomm(rop->val, state->val, n->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_rrandomb(mpz_wrapper* rop, gmp_randstate_wrapper* state, unsigned long long __n)
{
    volatile mp_bitcnt_t n;
    n = __n;
    if( n!=__n ) return XMPIR_32_64_ERROR;
    mpz_rrandomb(rop->val, state->val, n);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fits_ulong_p(signed int* result, mpz_wrapper* op)
{
    *result = mpz_fits_ulong_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fits_slong_p(signed int* result, mpz_wrapper* op)
{
    *result = mpz_fits_slong_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fits_uint_p(signed int* result, mpz_wrapper* op)
{
    *result = mpz_fits_uint_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fits_sint_p(signed int* result, mpz_wrapper* op)
{
    *result = mpz_fits_sint_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fits_ushort_p(signed int* result, mpz_wrapper* op)
{
    *result = mpz_fits_ushort_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_fits_sshort_p(signed int* result, mpz_wrapper* op)
{
    *result = mpz_fits_sshort_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_odd_p(signed int* result, mpz_wrapper* op)
{
    *result = mpz_odd_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_even_p(signed int* result, mpz_wrapper* op)
{
    *result = mpz_even_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpz_sizeinbase(unsigned long long* result, mpz_wrapper* op, unsigned int base)
{
    *result = mpz_sizeinbase(op->val, base);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_canonicalize(mpq_wrapper* op)
{
    mpq_canonicalize(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_set(mpq_wrapper* rop, mpq_wrapper* op)
{
    mpq_set(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_set_z(mpq_wrapper* rop, mpz_wrapper* op)
{
    mpq_set_z(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_set_ui(mpq_wrapper* rop, unsigned int op1, unsigned int op2)
{
    mpq_set_ui(rop->val, op1, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_set_si(mpq_wrapper* rop, signed int op1, unsigned int op2)
{
    mpq_set_si(rop->val, op1, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_set_str(signed int* result, mpq_wrapper* rop, char* str, unsigned int base)
{
    *result = mpq_set_str(rop->val, str, base);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_swap(mpq_wrapper* rop1, mpq_wrapper* rop2)
{
    mpq_swap(rop1->val, rop2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_get_d(double* result, mpq_wrapper* op)
{
    *result = mpq_get_d(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_set_d(mpq_wrapper* rop, double op)
{
    mpq_set_d(rop->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_set_f(mpq_wrapper* rop, mpf_wrapper* op)
{
    mpq_set_f(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_get_string(char** result, unsigned int base, mpq_wrapper* op)
{
    *result = mpq_get_string(base, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_add(mpq_wrapper* sum, mpq_wrapper* addend1, mpq_wrapper* addend2)
{
    mpq_add(sum->val, addend1->val, addend2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_sub(mpq_wrapper* difference, mpq_wrapper* minuend, mpq_wrapper* subtrahend)
{
    mpq_sub(difference->val, minuend->val, subtrahend->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_mul(mpq_wrapper* product, mpq_wrapper* multiplier, mpq_wrapper* multiplicand)
{
    mpq_mul(product->val, multiplier->val, multiplicand->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_mul_2exp(mpq_wrapper* rop, mpq_wrapper* op1, unsigned long long __op2)
{
    volatile mp_bitcnt_t op2;
    op2 = __op2;
    if( op2!=__op2 ) return XMPIR_32_64_ERROR;
    mpq_mul_2exp(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_div(mpq_wrapper* quotient, mpq_wrapper* dividend, mpq_wrapper* divisor)
{
    mpq_div(quotient->val, dividend->val, divisor->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_div_2exp(mpq_wrapper* rop, mpq_wrapper* op1, unsigned long long __op2)
{
    volatile mp_bitcnt_t op2;
    op2 = __op2;
    if( op2!=__op2 ) return XMPIR_32_64_ERROR;
    mpq_div_2exp(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_neg(mpq_wrapper* negated_operand, mpq_wrapper* operand)
{
    mpq_neg(negated_operand->val, operand->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_abs(mpq_wrapper* rop, mpq_wrapper* op)
{
    mpq_abs(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_inv(mpq_wrapper* inverted_number, mpq_wrapper* number)
{
    mpq_inv(inverted_number->val, number->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_cmp(signed int* result, mpq_wrapper* op1, mpq_wrapper* op2)
{
    *result = mpq_cmp(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_cmp_ui(signed int* result, mpq_wrapper* op1, unsigned int num2, unsigned int den2)
{
    *result = mpq_cmp_ui(op1->val, num2, den2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_cmp_si(signed int* result, mpq_wrapper* op1, signed int num2, unsigned int den2)
{
    *result = mpq_cmp_si(op1->val, num2, den2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_sgn(signed int* result, mpq_wrapper* op)
{
    *result = mpq_sgn(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_equal(signed int* result, mpq_wrapper* op1, mpq_wrapper* op2)
{
    *result = mpq_equal(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_get_num(mpz_wrapper* numerator, mpq_wrapper* rational)
{
    mpq_get_num(numerator->val, rational->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_get_den(mpz_wrapper* denominator, mpq_wrapper* rational)
{
    mpq_get_den(denominator->val, rational->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_set_num(mpq_wrapper* rational, mpz_wrapper* numerator)
{
    mpq_set_num(rational->val, numerator->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpq_set_den(mpq_wrapper* rational, mpz_wrapper* denominator)
{
    mpq_set_den(rational->val, denominator->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_set_default_prec(unsigned long long __prec)
{
    volatile mp_bitcnt_t prec;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    mpf_set_default_prec(prec);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_get_default_prec(unsigned long long* __result)
{
    *__result = mpf_get_default_prec();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_get_prec(unsigned long long* __result, mpf_wrapper* op)
{
    *__result = mpf_get_prec(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_set_prec(mpf_wrapper* rop, unsigned long long __prec)
{
    volatile mp_bitcnt_t prec;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    mpf_set_prec(rop->val, prec);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_set_prec_raw(mpf_wrapper* rop, unsigned long long __prec)
{
    volatile mp_bitcnt_t prec;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    mpf_set_prec_raw(rop->val, prec);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_set(mpf_wrapper* rop, mpf_wrapper* op)
{
    mpf_set(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_set_ui(mpf_wrapper* rop, unsigned int op)
{
    mpf_set_ui(rop->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_set_si(mpf_wrapper* rop, signed int op)
{
    mpf_set_si(rop->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_set_d(mpf_wrapper* rop, double op)
{
    mpf_set_d(rop->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_set_z(mpf_wrapper* rop, mpz_wrapper* op)
{
    mpf_set_z(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_set_q(mpf_wrapper* rop, mpq_wrapper* op)
{
    mpf_set_q(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_set_str(signed int* result, mpf_wrapper* rop, char* str, unsigned int base)
{
    *result = mpf_set_str(rop->val, str, base);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_swap(mpf_wrapper* rop1, mpf_wrapper* rop2)
{
    mpf_swap(rop1->val, rop2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_get_d(double* result, mpf_wrapper* op)
{
    *result = mpf_get_d(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_get_d_2exp(double* result, signed int* expptr, mpf_wrapper* op)
{
    *result = mpf_get_d_2exp(expptr, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_get_si(signed int* result, mpf_wrapper* op)
{
    *result = mpf_get_si(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_get_ui(unsigned int* result, mpf_wrapper* op)
{
    *result = mpf_get_ui(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_get_string(char** result, signed long long* __expptr, unsigned int base, unsigned int n_digits, mpf_wrapper* op)
{
    mp_exp_t expptr;
    *result = mpf_get_string(&expptr, base, n_digits, op->val);
    *__expptr = expptr;
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_add(mpf_wrapper* rop, mpf_wrapper* op1, mpf_wrapper* op2)
{
    mpf_add(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_add_ui(mpf_wrapper* rop, mpf_wrapper* op1, unsigned int op2)
{
    mpf_add_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_sub(mpf_wrapper* rop, mpf_wrapper* op1, mpf_wrapper* op2)
{
    mpf_sub(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_ui_sub(mpf_wrapper* rop, unsigned int op1, mpf_wrapper* op2)
{
    mpf_ui_sub(rop->val, op1, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_sub_ui(mpf_wrapper* rop, mpf_wrapper* op1, unsigned int op2)
{
    mpf_sub_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_mul(mpf_wrapper* rop, mpf_wrapper* op1, mpf_wrapper* op2)
{
    mpf_mul(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_mul_ui(mpf_wrapper* rop, mpf_wrapper* op1, unsigned int op2)
{
    mpf_mul_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_div(mpf_wrapper* rop, mpf_wrapper* op1, mpf_wrapper* op2)
{
    mpf_div(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_ui_div(mpf_wrapper* rop, unsigned int op1, mpf_wrapper* op2)
{
    mpf_ui_div(rop->val, op1, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_div_ui(mpf_wrapper* rop, mpf_wrapper* op1, unsigned int op2)
{
    mpf_div_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_sqrt(mpf_wrapper* rop, mpf_wrapper* op)
{
    mpf_sqrt(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_sqrt_ui(mpf_wrapper* rop, unsigned int op)
{
    mpf_sqrt_ui(rop->val, op);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_pow_ui(mpf_wrapper* rop, mpf_wrapper* op1, unsigned int op2)
{
    mpf_pow_ui(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_neg(mpf_wrapper* rop, mpf_wrapper* op)
{
    mpf_neg(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_abs(mpf_wrapper* rop, mpf_wrapper* op)
{
    mpf_abs(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_mul_2exp(mpf_wrapper* rop, mpf_wrapper* op1, unsigned long long __op2)
{
    volatile mp_bitcnt_t op2;
    op2 = __op2;
    if( op2!=__op2 ) return XMPIR_32_64_ERROR;
    mpf_mul_2exp(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_div_2exp(mpf_wrapper* rop, mpf_wrapper* op1, unsigned long long __op2)
{
    volatile mp_bitcnt_t op2;
    op2 = __op2;
    if( op2!=__op2 ) return XMPIR_32_64_ERROR;
    mpf_div_2exp(rop->val, op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_cmp(signed int* result, mpf_wrapper* op1, mpf_wrapper* op2)
{
    *result = mpf_cmp(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_cmp_d(signed int* result, mpf_wrapper* op1, double op2)
{
    *result = mpf_cmp_d(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_cmp_ui(signed int* result, mpf_wrapper* op1, unsigned int op2)
{
    *result = mpf_cmp_ui(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_cmp_si(signed int* result, mpf_wrapper* op1, signed int op2)
{
    *result = mpf_cmp_si(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_eq(signed int* result, mpf_wrapper* op1, mpf_wrapper* op2, unsigned long long __op3)
{
    volatile mp_bitcnt_t op3;
    op3 = __op3;
    if( op3!=__op3 ) return XMPIR_32_64_ERROR;
    *result = mpf_eq(op1->val, op2->val, op3);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_reldiff(mpf_wrapper* rop, mpf_wrapper* op1, mpf_wrapper* op2)
{
    mpf_reldiff(rop->val, op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_sgn(signed int* result, mpf_wrapper* op)
{
    *result = mpf_sgn(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_ceil(mpf_wrapper* rop, mpf_wrapper* op)
{
    mpf_ceil(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_floor(mpf_wrapper* rop, mpf_wrapper* op)
{
    mpf_floor(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_trunc(mpf_wrapper* rop, mpf_wrapper* op)
{
    mpf_trunc(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_integer_p(signed int* result, mpf_wrapper* op)
{
    *result = mpf_integer_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_fits_ulong_p(signed int* result, mpf_wrapper* op)
{
    *result = mpf_fits_ulong_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_fits_slong_p(signed int* result, mpf_wrapper* op)
{
    *result = mpf_fits_slong_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_fits_uint_p(signed int* result, mpf_wrapper* op)
{
    *result = mpf_fits_uint_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_fits_sint_p(signed int* result, mpf_wrapper* op)
{
    *result = mpf_fits_sint_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_fits_ushort_p(signed int* result, mpf_wrapper* op)
{
    *result = mpf_fits_ushort_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_fits_sshort_p(signed int* result, mpf_wrapper* op)
{
    *result = mpf_fits_sshort_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_urandomb(mpf_wrapper* rop, gmp_randstate_wrapper* state, unsigned long long __nbits)
{
    volatile mp_bitcnt_t nbits;
    nbits = __nbits;
    if( nbits!=__nbits ) return XMPIR_32_64_ERROR;
    mpf_urandomb(rop->val, state->val, nbits);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpf_rrandomb(mpf_wrapper* rop, gmp_randstate_wrapper* state, signed long long __max_size, signed long long __exp)
{
    volatile mp_exp_t exp;
    volatile mp_size_t max_size;
    max_size = __max_size;
    if( max_size!=__max_size ) return XMPIR_32_64_ERROR;
    exp = __exp;
    if( exp!=__exp ) return XMPIR_32_64_ERROR;
    mpf_rrandomb(rop->val, state->val, max_size, exp);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_default_prec(signed long long __prec)
{
    volatile mpfr_prec_t prec;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    mpfr_set_default_prec(prec);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_default_prec(signed long long* __result)
{
    *__result = mpfr_get_default_prec();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_prec(mpfr_wrapper* rop, signed long long __prec)
{
    volatile mpfr_prec_t prec;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    mpfr_set_prec(rop->val, prec);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_prec(signed long long* __result, mpfr_wrapper* op)
{
    *__result = mpfr_get_prec(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_set(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_ui(signed int* result, mpfr_wrapper* rop, unsigned int op, signed int rnd)
{
    *result = mpfr_set_ui(rop->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_si(signed int* result, mpfr_wrapper* rop, signed int op, signed int rnd)
{
    *result = mpfr_set_si(rop->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_d(signed int* result, mpfr_wrapper* rop, double op, signed int rnd)
{
    *result = mpfr_set_d(rop->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_z(signed int* result, mpfr_wrapper* rop, mpz_wrapper* op, signed int rnd)
{
    *result = mpfr_set_z(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_q(signed int* result, mpfr_wrapper* rop, mpq_wrapper* op, signed int rnd)
{
    *result = mpfr_set_q(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_f(signed int* result, mpfr_wrapper* rop, mpf_wrapper* op, signed int rnd)
{
    *result = mpfr_set_f(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_str(signed int* result, mpfr_wrapper* rop, char* str, unsigned int base, signed int rnd)
{
    *result = mpfr_set_str(rop->val, str, base, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_ui_2exp(signed int* result, mpfr_wrapper* rop, unsigned int op, signed long long __e, signed int rnd)
{
    volatile mpfr_exp_t e;
    e = __e;
    if( e!=__e ) return XMPIR_32_64_ERROR;
    *result = mpfr_set_ui_2exp(rop->val, op, e, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_si_2exp(signed int* result, mpfr_wrapper* rop, signed int op, signed long long __e, signed int rnd)
{
    volatile mpfr_exp_t e;
    e = __e;
    if( e!=__e ) return XMPIR_32_64_ERROR;
    *result = mpfr_set_si_2exp(rop->val, op, e, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_z_2exp(signed int* result, mpfr_wrapper* rop, mpz_wrapper* op, signed long long __e, signed int rnd)
{
    volatile mpfr_exp_t e;
    e = __e;
    if( e!=__e ) return XMPIR_32_64_ERROR;
    *result = mpfr_set_z_2exp(rop->val, op->val, e, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_nan(mpfr_wrapper* rop)
{
    mpfr_set_nan(rop->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_inf(mpfr_wrapper* rop, signed int sign)
{
    mpfr_set_inf(rop->val, sign);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_zero(mpfr_wrapper* rop, signed int sign)
{
    mpfr_set_zero(rop->val, sign);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_swap(mpfr_wrapper* rop, mpfr_wrapper* op)
{
    mpfr_swap(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_d(double* result, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_get_d(op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_si(signed int* result, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_get_si(op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_ui(unsigned int* result, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_get_ui(op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_d_2exp(double* result, signed int* expptr, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_get_d_2exp(expptr, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_frexp(signed int* result, signed long long* __expptr, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    mpfr_exp_t expptr;
    *result = mpfr_frexp(&expptr, rop->val, op->val, rnd);
    *__expptr = expptr;
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_z_2exp(signed long long* __result, mpz_wrapper* rop, mpfr_wrapper* op)
{
    *__result = mpfr_get_z_2exp(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_z(signed int* result, mpz_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_get_z(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_f(signed int* result, mpf_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_get_f(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_str(char** result, char* str, signed long long* __expptr, unsigned int base, unsigned int n_digits, mpfr_wrapper* op, signed int rnd)
{
    mpfr_exp_t expptr;
    *result = mpfr_get_str(str, &expptr, base, n_digits, op->val, rnd);
    *__expptr = expptr;
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_fits_ulong_p(signed int* result, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_fits_ulong_p(op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_fits_slong_p(signed int* result, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_fits_slong_p(op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_fits_uint_p(signed int* result, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_fits_uint_p(op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_fits_sint_p(signed int* result, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_fits_sint_p(op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_fits_ushort_p(signed int* result, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_fits_ushort_p(op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_fits_sshort_p(signed int* result, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_fits_sshort_p(op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_add(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_add(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_add_ui(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpfr_add_ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_add_si(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, signed int op2, signed int rnd)
{
    *result = mpfr_add_si(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_add_d(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, double op2, signed int rnd)
{
    *result = mpfr_add_d(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_add_z(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpz_wrapper* op2, signed int rnd)
{
    *result = mpfr_add_z(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_add_q(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpq_wrapper* op2, signed int rnd)
{
    *result = mpfr_add_q(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sub(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_sub(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_ui_sub(signed int* result, mpfr_wrapper* rop, unsigned int op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_ui_sub(rop->val, op1, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sub_ui(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpfr_sub_ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_si_sub(signed int* result, mpfr_wrapper* rop, signed int op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_si_sub(rop->val, op1, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sub_si(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, signed int op2, signed int rnd)
{
    *result = mpfr_sub_si(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_d_sub(signed int* result, mpfr_wrapper* rop, double op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_d_sub(rop->val, op1, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sub_d(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, double op2, signed int rnd)
{
    *result = mpfr_sub_d(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_z_sub(signed int* result, mpfr_wrapper* rop, mpz_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_z_sub(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sub_z(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpz_wrapper* op2, signed int rnd)
{
    *result = mpfr_sub_z(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sub_q(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpq_wrapper* op2, signed int rnd)
{
    *result = mpfr_sub_q(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_mul(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_mul(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_mul_ui(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpfr_mul_ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_mul_si(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, signed int op2, signed int rnd)
{
    *result = mpfr_mul_si(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_mul_d(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, double op2, signed int rnd)
{
    *result = mpfr_mul_d(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_mul_z(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpz_wrapper* op2, signed int rnd)
{
    *result = mpfr_mul_z(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_mul_q(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpq_wrapper* op2, signed int rnd)
{
    *result = mpfr_mul_q(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sqr(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_sqr(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_div(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_div(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_ui_div(signed int* result, mpfr_wrapper* rop, unsigned int op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_ui_div(rop->val, op1, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_div_ui(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpfr_div_ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_si_div(signed int* result, mpfr_wrapper* rop, signed int op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_si_div(rop->val, op1, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_div_si(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, signed int op2, signed int rnd)
{
    *result = mpfr_div_si(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_d_div(signed int* result, mpfr_wrapper* rop, double op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_d_div(rop->val, op1, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_div_d(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, double op2, signed int rnd)
{
    *result = mpfr_div_d(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_div_z(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpz_wrapper* op2, signed int rnd)
{
    *result = mpfr_div_z(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_div_q(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpq_wrapper* op2, signed int rnd)
{
    *result = mpfr_div_q(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sqrt(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_sqrt(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sqrt_ui(signed int* result, mpfr_wrapper* rop, unsigned int op, signed int rnd)
{
    *result = mpfr_sqrt_ui(rop->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_rec_sqrt(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_rec_sqrt(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cbrt(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_cbrt(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_root(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, unsigned int k, signed int rnd)
{
    *result = mpfr_root(rop->val, op->val, k, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_pow(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_pow(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_pow_ui(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpfr_pow_ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_pow_si(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, signed int op2, signed int rnd)
{
    *result = mpfr_pow_si(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_pow_z(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpz_wrapper* op2, signed int rnd)
{
    *result = mpfr_pow_z(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_ui_pow_ui(signed int* result, mpfr_wrapper* rop, unsigned int op1, unsigned int op2, signed int rnd)
{
    *result = mpfr_ui_pow_ui(rop->val, op1, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_ui_pow(signed int* result, mpfr_wrapper* rop, unsigned int op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_ui_pow(rop->val, op1, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_neg(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_neg(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_abs(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_abs(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_dim(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_dim(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_mul_2ui(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpfr_mul_2ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_mul_2si(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, signed int op2, signed int rnd)
{
    *result = mpfr_mul_2si(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_div_2ui(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpfr_div_2ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_div_2si(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, signed int op2, signed int rnd)
{
    *result = mpfr_div_2si(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cmp(signed int* result, mpfr_wrapper* op1, mpfr_wrapper* op2)
{
    *result = mpfr_cmp(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cmp_d(signed int* result, mpfr_wrapper* op1, double op2)
{
    *result = mpfr_cmp_d(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cmp_ui(signed int* result, mpfr_wrapper* op1, unsigned int op2)
{
    *result = mpfr_cmp_ui(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cmp_si(signed int* result, mpfr_wrapper* op1, signed int op2)
{
    *result = mpfr_cmp_si(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cmp_z(signed int* result, mpfr_wrapper* op1, mpz_wrapper* op2)
{
    *result = mpfr_cmp_z(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cmp_q(signed int* result, mpfr_wrapper* op1, mpq_wrapper* op2)
{
    *result = mpfr_cmp_q(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cmp_f(signed int* result, mpfr_wrapper* op1, mpf_wrapper* op2)
{
    *result = mpfr_cmp_f(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cmp_ui_2exp(signed int* result, mpfr_wrapper* op1, unsigned int op2, signed long long __e)
{
    volatile mpfr_exp_t e;
    e = __e;
    if( e!=__e ) return XMPIR_32_64_ERROR;
    *result = mpfr_cmp_ui_2exp(op1->val, op2, e);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cmp_si_2exp(signed int* result, mpfr_wrapper* op1, signed int op2, signed long long __e)
{
    volatile mpfr_exp_t e;
    e = __e;
    if( e!=__e ) return XMPIR_32_64_ERROR;
    *result = mpfr_cmp_si_2exp(op1->val, op2, e);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cmpabs(signed int* result, mpfr_wrapper* op1, mpfr_wrapper* op2)
{
    *result = mpfr_cmpabs(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_nan_p(signed int* result, mpfr_wrapper* op)
{
    *result = mpfr_nan_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_inf_p(signed int* result, mpfr_wrapper* op)
{
    *result = mpfr_inf_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_number_p(signed int* result, mpfr_wrapper* op)
{
    *result = mpfr_number_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_zero_p(signed int* result, mpfr_wrapper* op)
{
    *result = mpfr_zero_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_regular_p(signed int* result, mpfr_wrapper* op)
{
    *result = mpfr_regular_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sgn(signed int* result, mpfr_wrapper* op)
{
    *result = mpfr_sgn(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_greater_p(signed int* result, mpfr_wrapper* op1, mpfr_wrapper* op2)
{
    *result = mpfr_greater_p(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_greaterequal_p(signed int* result, mpfr_wrapper* op1, mpfr_wrapper* op2)
{
    *result = mpfr_greaterequal_p(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_less_p(signed int* result, mpfr_wrapper* op1, mpfr_wrapper* op2)
{
    *result = mpfr_less_p(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_lessequal_p(signed int* result, mpfr_wrapper* op1, mpfr_wrapper* op2)
{
    *result = mpfr_lessequal_p(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_equal_p(signed int* result, mpfr_wrapper* op1, mpfr_wrapper* op2)
{
    *result = mpfr_equal_p(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_lessgreater_p(signed int* result, mpfr_wrapper* op1, mpfr_wrapper* op2)
{
    *result = mpfr_lessgreater_p(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_unordered_p(signed int* result, mpfr_wrapper* op1, mpfr_wrapper* op2)
{
    *result = mpfr_unordered_p(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_log(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_log(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_log2(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_log2(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_log10(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_log10(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_exp(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_exp(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_exp2(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_exp2(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_exp10(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_exp10(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cos(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_cos(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sin(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_sin(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_tan(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_tan(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sin_cos(signed int* result, mpfr_wrapper* sop, mpfr_wrapper* cop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_sin_cos(sop->val, cop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sec(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_sec(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_csc(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_csc(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cot(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_cot(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_acos(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_acos(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_asin(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_asin(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_atan(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_atan(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_atan2(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* y, mpfr_wrapper* x, signed int rnd)
{
    *result = mpfr_atan2(rop->val, y->val, x->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_cosh(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_cosh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sinh(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_sinh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_tanh(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_tanh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sinh_cosh(signed int* result, mpfr_wrapper* sop, mpfr_wrapper* cop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_sinh_cosh(sop->val, cop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_sech(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_sech(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_csch(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_csch(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_coth(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_coth(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_acosh(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_acosh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_asinh(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_asinh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_atanh(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_atanh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_fac_ui(signed int* result, mpfr_wrapper* rop, unsigned int op, signed int rnd)
{
    *result = mpfr_fac_ui(rop->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_log1p(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_log1p(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_expm1(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_expm1(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_eint(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_eint(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_li2(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_li2(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_gamma(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_gamma(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_lngamma(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_lngamma(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_lgamma(signed int* result, mpfr_wrapper* rop, signed int* signp, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_lgamma(rop->val, signp, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_digamma(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_digamma(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_zeta(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_zeta(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_zeta_ui(signed int* result, mpfr_wrapper* rop, unsigned int op, signed int rnd)
{
    *result = mpfr_zeta_ui(rop->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_erf(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_erf(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_erfc(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_erfc(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_j0(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_j0(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_j1(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_j1(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_jn(signed int* result, mpfr_wrapper* rop, signed int n, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_jn(rop->val, n, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_y0(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_y0(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_y1(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_y1(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_yn(signed int* result, mpfr_wrapper* rop, signed int n, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_yn(rop->val, n, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_fma(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, mpfr_wrapper* op3, signed int rnd)
{
    *result = mpfr_fma(rop->val, op1->val, op2->val, op3->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_fms(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, mpfr_wrapper* op3, signed int rnd)
{
    *result = mpfr_fms(rop->val, op1->val, op2->val, op3->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_agm(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_agm(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_hypot(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* x, mpfr_wrapper* y, signed int rnd)
{
    *result = mpfr_hypot(rop->val, x->val, y->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_ai(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* x, signed int rnd)
{
    *result = mpfr_ai(rop->val, x->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_const_log2(signed int* result, mpfr_wrapper* rop, signed int rnd)
{
    *result = mpfr_const_log2(rop->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_const_pi(signed int* result, mpfr_wrapper* rop, signed int rnd)
{
    *result = mpfr_const_pi(rop->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_const_euler(signed int* result, mpfr_wrapper* rop, signed int rnd)
{
    *result = mpfr_const_euler(rop->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_const_catalan(signed int* result, mpfr_wrapper* rop, signed int rnd)
{
    *result = mpfr_const_catalan(rop->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_free_cache()
{
    mpfr_free_cache();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_rint(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_rint(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_ceil(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op)
{
    *result = mpfr_ceil(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_floor(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op)
{
    *result = mpfr_floor(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_round(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op)
{
    *result = mpfr_round(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_trunc(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op)
{
    *result = mpfr_trunc(rop->val, op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_rint_ceil(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_rint_ceil(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_rint_floor(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_rint_floor(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_rint_round(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_rint_round(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_rint_trunc(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_rint_trunc(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_frac(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_frac(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_modf(signed int* result, mpfr_wrapper* iop, mpfr_wrapper* fop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpfr_modf(iop->val, fop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_fmod(signed int* result, mpfr_wrapper* r, mpfr_wrapper* x, mpfr_wrapper* y, signed int rnd)
{
    *result = mpfr_fmod(r->val, x->val, y->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_remainder(signed int* result, mpfr_wrapper* r, mpfr_wrapper* x, mpfr_wrapper* y, signed int rnd)
{
    *result = mpfr_remainder(r->val, x->val, y->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_remquo(signed int* result, mpfr_wrapper* r, signed int* q, mpfr_wrapper* x, mpfr_wrapper* y, signed int rnd)
{
    *result = mpfr_remquo(r->val, q, x->val, y->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_integer_p(signed int* result, mpfr_wrapper* op)
{
    *result = mpfr_integer_p(op->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_default_rounding_mode(signed int rnd)
{
    mpfr_set_default_rounding_mode(rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_default_rounding_mode(signed int* result)
{
    *result = mpfr_get_default_rounding_mode();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_prec_round(signed int* result, mpfr_wrapper* x, signed long long __prec, signed int rnd)
{
    volatile mpfr_prec_t prec;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    *result = mpfr_prec_round(x->val, prec, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_can_round(signed int* result, mpfr_wrapper* b, signed long long __err, signed int rnd1, signed int rnd2, signed long long __prec)
{
    volatile mpfr_prec_t prec;
    volatile mpfr_exp_t err;
    err = __err;
    if( err!=__err ) return XMPIR_32_64_ERROR;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    *result = mpfr_can_round(b->val, err, rnd1, rnd2, prec);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_min_prec(signed long long* __result, mpfr_wrapper* x)
{
    *__result = mpfr_min_prec(x->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_nexttoward(mpfr_wrapper* x, mpfr_wrapper* y)
{
    mpfr_nexttoward(x->val, y->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_nextabove(mpfr_wrapper* x)
{
    mpfr_nextabove(x->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_nextbelow(mpfr_wrapper* x)
{
    mpfr_nextbelow(x->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_min(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_min(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_max(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_max(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_urandomb(signed int* result, mpfr_wrapper* rop, gmp_randstate_wrapper* state)
{
    *result = mpfr_urandomb(rop->val, state->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_urandom(signed int* result, mpfr_wrapper* rop, gmp_randstate_wrapper* state, signed int rnd)
{
    *result = mpfr_urandom(rop->val, state->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_grandom(signed int* result, mpfr_wrapper* rop1, mpfr_wrapper* rop2, gmp_randstate_wrapper* state, signed int rnd)
{
    *result = mpfr_grandom(rop1->val, rop2->val, state->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_exp(signed long long* __result, mpfr_wrapper* x)
{
    *__result = mpfr_get_exp(x->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_exp(signed int* result, mpfr_wrapper* x, signed long long __e)
{
    volatile mpfr_exp_t e;
    e = __e;
    if( e!=__e ) return XMPIR_32_64_ERROR;
    *result = mpfr_set_exp(x->val, e);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_signbit(signed int* result, mpfr_wrapper* x)
{
    *result = mpfr_signbit(x->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_setsign(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op, signed int s, signed int rnd)
{
    *result = mpfr_setsign(rop->val, op->val, s, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_copysign(signed int* result, mpfr_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpfr_copysign(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_buildopt_tls_p(signed int* result)
{
    *result = mpfr_buildopt_tls_p();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_buildopt_decimal_p(signed int* result)
{
    *result = mpfr_buildopt_decimal_p();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_emin(signed long long* __result)
{
    *__result = mpfr_get_emin();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_emax(signed long long* __result)
{
    *__result = mpfr_get_emax();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_emin(signed int* result, signed long long __exp)
{
    volatile mpfr_exp_t exp;
    exp = __exp;
    if( exp!=__exp ) return XMPIR_32_64_ERROR;
    *result = mpfr_set_emin(exp);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_emax(signed int* result, signed long long __exp)
{
    volatile mpfr_exp_t exp;
    exp = __exp;
    if( exp!=__exp ) return XMPIR_32_64_ERROR;
    *result = mpfr_set_emax(exp);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_emin_min(signed long long* __result)
{
    *__result = mpfr_get_emin_min();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_emin_max(signed long long* __result)
{
    *__result = mpfr_get_emin_max();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_emax_min(signed long long* __result)
{
    *__result = mpfr_get_emax_min();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_get_emax_max(signed long long* __result)
{
    *__result = mpfr_get_emax_max();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_check_range(signed int* result, mpfr_wrapper* x, signed int t, signed int rnd)
{
    *result = mpfr_check_range(x->val, t, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_subnormalize(signed int* result, mpfr_wrapper* x, signed int t, signed int rnd)
{
    *result = mpfr_subnormalize(x->val, t, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_clear_underflow()
{
    mpfr_clear_underflow();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_clear_overflow()
{
    mpfr_clear_overflow();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_clear_divby0()
{
    mpfr_clear_divby0();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_clear_nanflag()
{
    mpfr_clear_nanflag();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_clear_inexflag()
{
    mpfr_clear_inexflag();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_clear_erangeflag()
{
    mpfr_clear_erangeflag();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_clear_flags()
{
    mpfr_clear_flags();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_underflow()
{
    mpfr_set_underflow();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_overflow()
{
    mpfr_set_overflow();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_divby0()
{
    mpfr_set_divby0();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_nanflag()
{
    mpfr_set_nanflag();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_inexflag()
{
    mpfr_set_inexflag();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_set_erangeflag()
{
    mpfr_set_erangeflag();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_underflow_p(signed int* result)
{
    *result = mpfr_underflow_p();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_overflow_p(signed int* result)
{
    *result = mpfr_overflow_p();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_divby0_p(signed int* result)
{
    *result = mpfr_divby0_p();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_nanflag_p(signed int* result)
{
    *result = mpfr_nanflag_p();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_inexflag_p(signed int* result)
{
    *result = mpfr_inexflag_p();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpfr_erangeflag_p(signed int* result)
{
    *result = mpfr_erangeflag_p();
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_prec(mpc_wrapper* x, signed long long __prec)
{
    volatile mpfr_prec_t prec;
    prec = __prec;
    if( prec!=__prec ) return XMPIR_32_64_ERROR;
    mpc_set_prec(x->val, prec);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_get_prec(signed long long* __result, mpc_wrapper* x)
{
    *__result = mpc_get_prec(x->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_get_prec2(signed long long* __pr, signed long long* __pi, mpc_wrapper* x)
{
    mpfr_prec_t pi;
    mpfr_prec_t pr;
    mpc_get_prec2(&pr, &pi, x->val);
    *__pr = pr;
    *__pi = pi;
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_set(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_ui(signed int* result, mpc_wrapper* rop, unsigned int op, signed int rnd)
{
    *result = mpc_set_ui(rop->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_si(signed int* result, mpc_wrapper* rop, signed int op, signed int rnd)
{
    *result = mpc_set_si(rop->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_d(signed int* result, mpc_wrapper* rop, double op, signed int rnd)
{
    *result = mpc_set_d(rop->val, op, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_z(signed int* result, mpc_wrapper* rop, mpz_wrapper* op, signed int rnd)
{
    *result = mpc_set_z(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_q(signed int* result, mpc_wrapper* rop, mpq_wrapper* op, signed int rnd)
{
    *result = mpc_set_q(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_f(signed int* result, mpc_wrapper* rop, mpf_wrapper* op, signed int rnd)
{
    *result = mpc_set_f(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_fr(signed int* result, mpc_wrapper* rop, mpfr_wrapper* op, signed int rnd)
{
    *result = mpc_set_fr(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_ui_ui(signed int* result, mpc_wrapper* rop, unsigned int op1, unsigned int op2, signed int rnd)
{
    *result = mpc_set_ui_ui(rop->val, op1, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_si_si(signed int* result, mpc_wrapper* rop, signed int op1, signed int op2, signed int rnd)
{
    *result = mpc_set_si_si(rop->val, op1, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_d_d(signed int* result, mpc_wrapper* rop, double op1, double op2, signed int rnd)
{
    *result = mpc_set_d_d(rop->val, op1, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_z_z(signed int* result, mpc_wrapper* rop, mpz_wrapper* op1, mpz_wrapper* op2, signed int rnd)
{
    *result = mpc_set_z_z(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_q_q(signed int* result, mpc_wrapper* rop, mpq_wrapper* op1, mpq_wrapper* op2, signed int rnd)
{
    *result = mpc_set_q_q(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_f_f(signed int* result, mpc_wrapper* rop, mpf_wrapper* op1, mpf_wrapper* op2, signed int rnd)
{
    *result = mpc_set_f_f(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_fr_fr(signed int* result, mpc_wrapper* rop, mpfr_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpc_set_fr_fr(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_nan(mpc_wrapper* rop)
{
    mpc_set_nan(rop->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_swap(mpc_wrapper* op1, mpc_wrapper* op2)
{
    mpc_swap(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_set_str(signed int* result, mpc_wrapper* rop, char* str, signed int base, signed int rnd)
{
    *result = mpc_set_str(rop->val, str, base, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_get_str(char** result, signed int base, unsigned int n, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_get_str(base, n, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_cmp(signed int* result, mpc_wrapper* op1, mpc_wrapper* op2)
{
    *result = mpc_cmp(op1->val, op2->val);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_cmp_si_si(signed int* result, mpc_wrapper* op1, signed int op2r, signed int op2i)
{
    *result = mpc_cmp_si_si(op1->val, op2r, op2i);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_cmp_si(signed int* result, mpc_wrapper* op1, signed int op2)
{
    *result = mpc_cmp_si(op1->val, op2);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_real(signed int* result, mpfr_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_real(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_imag(signed int* result, mpfr_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_imag(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_arg(signed int* result, mpfr_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_arg(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_proj(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_proj(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_add(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpc_wrapper* op2, signed int rnd)
{
    *result = mpc_add(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_add_ui(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpc_add_ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_add_fr(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpc_add_fr(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_sub(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpc_wrapper* op2, signed int rnd)
{
    *result = mpc_sub(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_sub_fr(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpc_sub_fr(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_fr_sub(signed int* result, mpc_wrapper* rop, mpfr_wrapper* op1, mpc_wrapper* op2, signed int rnd)
{
    *result = mpc_fr_sub(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_sub_ui(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpc_sub_ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_ui_sub(signed int* result, mpc_wrapper* rop, unsigned int op1, mpc_wrapper* op2, signed int rnd)
{
    *result = mpc_ui_sub(rop->val, op1, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_ui_ui_sub(signed int* result, mpc_wrapper* rop, unsigned int re1, unsigned int im1, mpc_wrapper* op2, signed int rnd)
{
    *result = mpc_ui_ui_sub(rop->val, re1, im1, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_neg(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_neg(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_mul(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpc_wrapper* op2, signed int rnd)
{
    *result = mpc_mul(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_mul_ui(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpc_mul_ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_mul_si(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, signed int op2, signed int rnd)
{
    *result = mpc_mul_si(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_mul_fr(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpc_mul_fr(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_mul_i(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int sgn, signed int rnd)
{
    *result = mpc_mul_i(rop->val, op->val, sgn, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_sqr(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_sqr(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_fma(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpc_wrapper* op2, mpc_wrapper* op3, signed int rnd)
{
    *result = mpc_fma(rop->val, op1->val, op2->val, op3->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_div(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpc_wrapper* op2, signed int rnd)
{
    *result = mpc_div(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_div_ui(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpc_div_ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_div_fr(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpc_div_fr(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_ui_div(signed int* result, mpc_wrapper* rop, unsigned int op1, mpc_wrapper* op2, signed int rnd)
{
    *result = mpc_ui_div(rop->val, op1, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_fr_div(signed int* result, mpc_wrapper* rop, mpfr_wrapper* op1, mpc_wrapper* op2, signed int rnd)
{
    *result = mpc_fr_div(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_conj(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_conj(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_abs(signed int* result, mpfr_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_abs(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_norm(signed int* result, mpfr_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_norm(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_mul_2ui(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpc_mul_2ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_mul_2si(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, signed int op2, signed int rnd)
{
    *result = mpc_mul_2si(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_div_2ui(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpc_div_2ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_div_2si(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, signed int op2, signed int rnd)
{
    *result = mpc_div_2si(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_sqrt(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_sqrt(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_pow(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpc_wrapper* op2, signed int rnd)
{
    *result = mpc_pow(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_pow_d(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, double op2, signed int rnd)
{
    *result = mpc_pow_d(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_pow_si(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, signed int op2, signed int rnd)
{
    *result = mpc_pow_si(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_pow_ui(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, unsigned int op2, signed int rnd)
{
    *result = mpc_pow_ui(rop->val, op1->val, op2, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_pow_z(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpz_wrapper* op2, signed int rnd)
{
    *result = mpc_pow_z(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_pow_fr(signed int* result, mpc_wrapper* rop, mpc_wrapper* op1, mpfr_wrapper* op2, signed int rnd)
{
    *result = mpc_pow_fr(rop->val, op1->val, op2->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_exp(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_exp(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_log(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_log(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_log10(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_log10(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_sin(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_sin(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_cos(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_cos(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_sin_cos(signed int* result, mpc_wrapper* rop_sin, mpc_wrapper* rop_cos, mpc_wrapper* op, signed int rnd_sin, signed int rnd_cos)
{
    *result = mpc_sin_cos(rop_sin->val, rop_cos->val, op->val, rnd_sin, rnd_cos);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_tan(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_tan(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_sinh(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_sinh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_cosh(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_cosh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_tanh(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_tanh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_asin(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_asin(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_acos(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_acos(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_atan(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_atan(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_asinh(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_asinh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_acosh(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_acosh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_atanh(signed int* result, mpc_wrapper* rop, mpc_wrapper* op, signed int rnd)
{
    *result = mpc_atanh(rop->val, op->val, rnd);
    return XMPIR_OK;
}
DLLEXPORT int xmpir_mpc_urandom(signed int* result, mpc_wrapper* rop, gmp_randstate_wrapper* state)
{
    *result = mpc_urandom(rop->val, state->val);
    return XMPIR_OK;
}
