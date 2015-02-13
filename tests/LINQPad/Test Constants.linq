<Query Kind="Statements">
  <Namespace>Mpir.NET</Namespace>
</Query>

string FILENAME = Path.GetDirectoryName(Util.CurrentQueryPath) + "\\Constant_{0}_1e{1}.txt";

for (int digits = 1; digits <= 9; digits++)
{
	var pi = Mpir.NET.Constant.PiZ(mpz.Ten.Power(digits));
	File.WriteAllText(String.Format(FILENAME, "Pi", digits), pi.ToString());

	var e = Mpir.NET.Constant.eZ(mpz.Ten.Power(digits));
	File.WriteAllText(String.Format(FILENAME, "e", digits), e.ToString());

	var ln2 = Mpir.NET.Constant.Ln2Z(mpz.Ten.Power(digits));
	File.WriteAllText(String.Format(FILENAME, "ln2", digits), ln2.ToString());
}
