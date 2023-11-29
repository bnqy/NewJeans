using static System.Console;
namespace Practices;

public class Graph
{
	private Dictionary<string, List<string>> graph;

	public Graph()
	{
		graph = new Dictionary<string, List<string>>();
	}

	public void AddNode(string node)
	{
		if (!graph.ContainsKey(node))
		{
			graph[node] = new List<string>();
		}
	}

	public void AddEdges(string node1, string node2)
	{
		if (graph.ContainsKey(node1) && graph.ContainsKey(node2))
		{
			graph[node1].Add(node2);
			graph[node2].Add(node1);
		}
	}

	public void Display()
	{
		foreach (var node in graph)
		{
			WriteLine($"Node: {node.Key}");
			WriteLine($" {string.Join(", ", node.Value)}");
		}
	}
}
