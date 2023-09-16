using System.Globalization;
using System.Security;
using static System.Console;

CultureInfo globalization = CultureInfo.CurrentCulture;
CultureInfo localization = CultureInfo.CurrentUICulture;

WriteLine($"Current globalization culture is {globalization.Name}: {globalization.DisplayName}");
WriteLine($"Current localization culture is {localization.Name}: {localization.DisplayName}");

WriteLine();
WriteLine("en-US: English (United States)");
WriteLine("da-DK: Danish (Denmark)");
WriteLine("fr-CA: French (Canada)");

Write("Enter an ISO culture code: ");
string? newCulture = ReadLine();

if (!string.IsNullOrEmpty(newCulture))
{
    CultureInfo ci = new(newCulture);

    CultureInfo.CurrentCulture = ci;

    CultureInfo.CurrentUICulture = ci;
}
    WriteLine();
    Write("Enter your name: ");
    string? name = ReadLine();
    Write("Enter your date of birth: ");
    string? dob = ReadLine();
    Write("Enter your salary: ");
    string? salary = ReadLine();


DateTime date = DateTime.Parse(dob);
decimal salary1 = decimal.Parse(salary);
int age = (int) DateTime.Now.Year - date.Year;

WriteLine($"{name} was born on a {date:dddd} is {age} years old and earns {salary1:C}");