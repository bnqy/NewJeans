using System.Text.RegularExpressions;
using static System.Console;

Write("Write your age: ");
string? age = ReadLine();

Regex ageChecker = new(@"^\d+$");

if (ageChecker.IsMatch(age))
{
    WriteLine("GRAAAPE");
}
else
{
    WriteLine("Wrong");
}
WriteLine();

// str with regex

string names = "\"Monsters, Inc.\",\"I, Tonya\",\"Lock, Stock and Two Smoking Barrels\"";
WriteLine($"Names: {names}");
string[] namesArr = names.Split(',');
WriteLine("Names splited with Split Method: ");
foreach (string name in namesArr)
{
    WriteLine(name);
}
WriteLine();

Regex namesCheck = new("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");
MatchCollection namesRegex = namesCheck.Matches(names);
WriteLine("Spliting with Regex: ");
foreach (Match name in namesRegex)
{
    WriteLine(name.Groups[2].Value);
}