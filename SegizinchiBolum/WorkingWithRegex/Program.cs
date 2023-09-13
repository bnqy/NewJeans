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