<Query Kind="Statements">
  <Namespace>Mpir.NET</Namespace>
</Query>

string FILENAME = Path.GetDirectoryName(Util.CurrentQueryPath) + "\\Primes_1e{0}.txt";

for (int digits = 1; digits <= 9; digits++)
{
	var primeCount = Mpir.NET.Prime.SieveOfEratosthenes((int) mpz.Ten.Power(digits)).CountOnes();
	File.WriteAllText(String.Format(FILENAME, digits), primeCount.ToString());
}