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

	public void AddNodes(string node1, List<string> nodes)
	{
		if (graph.ContainsKey(node1))
		{
			graph[node1] = nodes;
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

	public void BFS(string startNode)
	{
		Queue<string> queue = new Queue<string>();
		HashSet<string> visited = new HashSet<string>();

		queue.Enqueue(startNode);
		visited.Add(startNode);

		while (queue.Count > 0)
		{
			var node = queue.Dequeue();
			WriteLine($"Current node: {node}");
			
			foreach (var n in graph[node])
			{
				if (!visited.Contains(n))
				{
					queue.Enqueue(n);
					visited.Add(n);
				}
			}
		}
	}
}
