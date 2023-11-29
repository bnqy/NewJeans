using Practices;
using static System.Console;

Graph graph = new Graph();

graph.AddNode("you");
graph.AddNodes("you", new List<string> {"Alice", "Bob", "Claire"});

graph.AddNode("Bob");
graph.AddNodes("Bob", new List<string> { "Peggy", "Anuj"});
graph.AddNode("Alice");
graph.AddNodes("Alice", new List<string> { "Peggy"});

graph.AddNode("Claire");
graph.AddNodes("Claire", new List<string> { "Thom", "Jonny" });

graph.AddNode("Peggy");
graph.AddNodes("Peggy", new List<string> {});

graph.AddNode("Anuj");
graph.AddNodes("Anuj", new List<string> { });

graph.AddNode("Thom");
graph.AddNodes("Thom", new List<string> { });

graph.AddNode("Jonny");
graph.AddNodes("Jonny", new List<string> { });

graph.Display();

WriteLine();
WriteLine("BFS: ");
graph.BFS("you");

