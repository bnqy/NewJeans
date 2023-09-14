using static System.Console;


string fullName = "Dua Lipa";

// with Substring method
int firstNameLength = fullName.IndexOf(' ');
int lastNameLength = fullName.Length -  firstNameLength - 1;

string firstName =  fullName.Substring(0, firstNameLength);
string lastName = fullName.Substring(fullName.Length-lastNameLength, lastNameLength);

WriteLine($"First name: {firstName}, Last name: {lastName}");
WriteLine();

// with ranges

ReadOnlySpan<char> nameAsSpan = fullName.AsSpan();
ReadOnlySpan<char> firstNameAsSpan = nameAsSpan[0..firstNameLength];
ReadOnlySpan<char> lastNameAsSpan = nameAsSpan[(firstNameLength + 1)..^0];
WriteLine($"First name: {firstNameAsSpan.ToString()}, Last name: {lastNameAsSpan}");
