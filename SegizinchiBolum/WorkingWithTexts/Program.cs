using System.Security.Cryptography;
using static System.Console;

string s1 = "Bishkek";
string s2 = "R, o, Pe, EE, oo,wa, mE";
string[] s3 = s2.Split(",");
WriteLine($"The word {s1} has {s1.Length} chars");

for (int i = 0; i < s1.Length; i++)
{
    WriteLine(s1[i]);
}

foreach (var s in s3)
{
    WriteLine(s);
}