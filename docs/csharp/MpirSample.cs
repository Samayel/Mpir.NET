using System;
using System.Text;

// [intro-sample]
using Mpir.NET;

class MpirSample
{
    static void MpirCalcs()
    {
        mpz a = new mpz(12345678901234567890);
        mpz b = new mpz(9876543210987654321);
        mpz c = a * b;
        System.Console.WriteLine("{0}", c);
    }
}
// [/intro-sample]

class Foo
{
    static void Bar()
    {
        // [using-sample]
        using (mpz a = new mpz(12345678901234567890))
        using (mpz b = new mpz(9876543210987654321)) 
        using (mpz c = a * b)
        {
            System.Console.WriteLine("{0}", c.ToString());
        }
        // [/using-sample]
    }
}
