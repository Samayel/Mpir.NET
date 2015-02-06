namespace Mpir.NET

[<AutoOpen>]
module NumericLiteralZ =
    let FromZero () = new mpz(0)
    let FromOne ()  = new mpz(1)
    let FromInt32 (n : int32)   = new mpz(n)
    let FromInt64 (n : int64)   = new mpz(n)
    let FromString (s : string) = new mpz(s)
