using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.Xml.Serialization;
using Serialization;
using NewJson = System.Text.Json.JsonSerializer;


List<Person> people = new()
{
    new(3000M)
    {
        FirstName = "Dua",
        LastName = "Lipa",
        DateOfBirth = new DateTime(1995, 07, 22)
    },

    new(1500M)
    {
        FirstName = "Jaeden",
        LastName = "Martell",
        DateOfBirth = new DateTime(2003, 01, 04)
    },

    new(4500M)
    {
        FirstName = "Kendall",
        LastName = "Jenner",
        DateOfBirth = new DateTime(1995, 07, 22),
        Children = new()
        {
            new(0M)
            {
                FirstName = "Ocean",
                LastName = "Jenner",
                DateOfBirth = new(2023, 12, 16)
            }
        }
    }

};

XmlSerializer xs = new(people.GetType());

string path = Combine(CurrentDirectory, "peope.xml");

using (FileStream stream = File.Create(path))
{
    xs.Serialize(stream, people);
}

WriteLine("Written {0:N0} bytes of XML to {1}",
 arg0: new FileInfo(path).Length,
 arg1: path);
WriteLine();

WriteLine(File.ReadAllText(path));

using (FileStream fileLoad = File.Open(path, FileMode.Open))
{
    List<Person>? loadedPeople = xs.Deserialize(fileLoad) as List<Person>;

    if (loadedPeople is not null)
    {
        foreach (Person p in loadedPeople)
        {
            WriteLine("{0} has {1} children.", p.LastName, p.Children?.Count ?? 0);
        }
    }
}


string jsonPath = Combine(CurrentDirectory, "people.json");

using (StreamWriter jsonStream = File.CreateText(jsonPath))
{
    Newtonsoft.Json.JsonSerializer jss = new();

    jss.Serialize(jsonStream, people);
}
WriteLine();
WriteLine("Written {0:N0} bytes of JSON to: {1}",
 arg0: new FileInfo(jsonPath).Length,
 arg1: jsonPath);
WriteLine(File.ReadAllText(jsonPath));

using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
{
    List<Person>? loadedPeople = await NewJson.DeserializeAsync(utf8Json: jsonLoad, returnType: typeof(List<Person>)) as List<Person>;

    if (loadedPeople is not null)
    {
        foreach (Person p in loadedPeople)
        {
            WriteLine("{0} has {1} children.", p.LastName, p.Children?.Count ?? 0);
        }
    }
}