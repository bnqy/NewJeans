using System.Security.Cryptography;
using static System.Console;

string s1 = "Bishkek";
string s2 = "R,o,Pe,EE,oo,wa,mE";
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

WriteLine();

// IndexOf and Sunstring

string fullName = "Dua Lipa";
int indexOfSpace = fullName.IndexOf(' ');
string firstName = fullName.Substring(startIndex: 0, length: indexOfSpace);
string lastName = fullName.Substring(startIndex: indexOfSpace + 1);
WriteLine($"Full Name: {fullName}");
WriteLine($"First Name: {firstName} - Last Name: {lastName}");
WriteLine();

//StartsWith EndWith Contains

string name = "Jaeden";
bool b1 = name.Contains("A");
bool b2 = name.StartsWith("Ja");
WriteLine($"{name} contains A ({b1}) and starts with J ({b2})");
WriteLine();

// join

string joined = string.Join(" -> ", s3);
WriteLine(joined);

