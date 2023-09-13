using static System.Console;

WorkingWithDict();
static void WorkingWithDict()
{
    Dictionary<string, string> types = new Dictionary<string, string>();
    types.Add("int", "32-bit");
    types.Add("long", "64-bit");
    Output("Dict keys: ", types.Keys);
    Output("Dict values: ", types.Values);
    foreach (KeyValuePair<string, string> kvp in types)
    {
        WriteLine($"{kvp.Key}: {kvp.Value}");
    }
}

static void Output(string title, IEnumerable<string> collection)
{
    WriteLine(title);
    foreach (string item in collection)
    {
        WriteLine($" {item}");
    }
}
