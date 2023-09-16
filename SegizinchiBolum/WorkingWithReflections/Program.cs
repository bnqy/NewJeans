using System.Reflection;
using static System.Console;
using WorkingWithReflections;
using System.Runtime.CompilerServices;

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
WriteLine();

AssemblyInformationalVersionAttribute? version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
WriteLine($"Version: {version?.InformationalVersion}");

AssemblyCompanyAttribute? company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
WriteLine($"Company: {company?.Company}");


WriteLine();

WriteLine("Types: ");
Type[] types = assembly.GetTypes();
foreach (Type type in types)
{
    WriteLine();
    WriteLine($"Type: {type.FullName}");
    MemberInfo[] members = type.GetMembers();

    foreach (MemberInfo member in members)
    {
        WriteLine($"{member.MemberType}: {member.Name} ({member.DeclaringType?.Name})");

        IOrderedEnumerable<CoderAttribute> coders = member.GetCustomAttribute<CoderAttribute>().OrderByDescending(c => c.LastModified);

        foreach (CoderAttribute coder in coders)
        {
            WriteLine($"-> Bodified by {coder.Coder} on {coder.LastModified.ToShortDateString()}");
        }
    }
}
class Animal
{
    [Coder("Beneq", "15 September 2023")]
    [Coder("MainB", "23 September 2023")]

    public void Speak()
    {
        WriteLine("Meow...");
    }
}



