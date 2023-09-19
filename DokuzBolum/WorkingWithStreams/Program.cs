using static System.Console;
using System.Xml;
using static System.Environment;
using static System.IO.Path;

WorkWithText();

static void WorkWithText()
{
    string txtFile = Combine(CurrentDirectory, "streams.txt");
    StreamWriter streamWriter = File.CreateText(txtFile);

    foreach (string str in Viper.Callsighns)
    {
        streamWriter.WriteLine(str);
    }
    streamWriter.Close();

    WriteLine($"{GetFileName(txtFile)} contains {new FileInfo(txtFile).Length}");

    WriteLine($"{File.ReadAllText(txtFile)}");
    WriteLine(txtFile);
}



static class Viper
{
    public static string[] Callsighns = new[] 
    {
        "Husker", "Starbuck", "Apollo", "Boomer",
        "Bulldog", "Athena", "Helo", "Racetrack"
    };
}