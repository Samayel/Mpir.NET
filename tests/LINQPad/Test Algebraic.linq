<Query Kind="Statements">
  <Namespace>Mpir.NET</Namespace>
</Query>

string FILENAME = Path.GetDirectoryName(Util.CurrentQueryPath) + "\\Algebraic_{0}_1e{1}.txt";

for (int digits = 1; digits <= 9; digits++)
{
	var sqrt2 = Mpir.NET.Algebraic.SqrtZ(2, mpz.Ten.Power(digits));
	File.WriteAllText(String.Format(FILENAME, "Sqrt2", digits), sqrt2.ToString());
}
