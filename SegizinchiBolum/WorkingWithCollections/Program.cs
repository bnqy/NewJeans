using static System.Console;
using System.Collections.Immutable;

WorkingWithLists();
//WorkingWithQueue();
static void Output(string title, IEnumerable<string> collection)
{
    WriteLine(title);
    foreach (string item in collection)
    {
        WriteLine($" {item}");
    }
}

static void WorkingWithLists()
{
    List<string> cities = new();
    cities.Add("London");
    cities.Add("Paris");
    cities.Add("Milan");
    /*
    List<string> cities = new()
    { "London", "Paris", "Milan" };
    */
    
    /*
    List<string> cities = new();
    cities.AddRange(new[] { "London", "Paris", "Milan" });
    */
    Output("Initial list", cities);
    WriteLine($"The first city is {cities[0]}.");
    WriteLine($"The last city is {cities[cities.Count - 1]}.");
    cities.Insert(0, "Sydney");
    Output("After inserting Sydney at index 0", cities);
    cities.RemoveAt(1);
    cities.Remove("Milan");
    Output("After removing two cities", cities);

    ImmutableList<string> immutableCities = cities.ToImmutableList();
    ImmutableList<string> newList = immutableCities.Add("Bishkek");

    Output("immutableCities: ", immutableCities);
    Output("newImmutableList: ", newList);
}


static void WorkingWithQueue()
{
    Queue<string> queue = new();
    queue.Enqueue("Dua Lipa");
    queue.Enqueue("Sia");
    queue.Enqueue("Bebe");
    queue.Enqueue("The Neighborhood");
    queue.Enqueue("Adele");

    Output("People in line: ", queue);

    string passed = queue.Dequeue();
    WriteLine($"Served: {passed}");

    passed = queue.Dequeue();
    WriteLine($"Served: {passed}");
    Output("People in line: ", queue);

    WriteLine($"{queue.Peek()} is next in line");
}