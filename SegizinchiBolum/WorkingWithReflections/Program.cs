using System.Reflection;
using static System.Console;

WriteLine("Assembly metadata: ");
Assembly? assembly = Assembly.GetEntryAssembly();
if (assembly == null)
{
    WriteLine("Failed");
}

WriteLine($"Name: {assembly.FullName}");
WriteLine($"Location: {assembly.Location}");

IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();
WriteLine("Assembly-level attributes");
foreach (Attribute attribute in attributes)
{
    WriteLine($" {attribute.GetType()}");
}