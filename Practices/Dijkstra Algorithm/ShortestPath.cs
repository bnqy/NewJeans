using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_Algorithm;

public class ShortestPath
{
	static int V = 9;

	int minDist(int[] dist, bool[] sptSet)
	{
		int min = int.MaxValue, min_index = -1;

		for (int v = 0; v < V; v++)
			if (sptSet[v] == false && dist[v] <= min)
			{
				min = dist[v];
				min_index = v;
			}

		return min_index;
	}
	public void dijkstra(int[,] graph, int source)
	{
		int[] dist = new int[V]; //will hold shortest path from source to i
		bool[] proccesed = new bool[V];

		for (int i = 0; i < V; i++)
		{
			dist[i] = int.MaxValue;
			proccesed[i] = false;
		}

		dist[source] = 0;

		for (int count = 0; count < V - 1; count++) //shortest path for all vertices
		{
			int u = minDist(dist, proccesed);

			proccesed[u] = true; //proccesed

			// Update dist value of the adjacent
			// vertices of the picked vertex.
			for (int v = 0; v < V; v++)
				if (!proccesed[v] && graph[u, v] != 0 
					&& dist[u] != int.MaxValue
					&& dist[u] + graph[u, v] < dist[v])

					dist[v] = dist[u] + graph[u, v];
		}

		printSolution(dist);
	}

	void printSolution(int[] dist)
	{
		Console.Write("Vertex \t\t Distance " + "from Source\n");
		for (int i = 0; i < V; i++)
			Console.Write(i + " \t\t " + dist[i] + "\n");
	}
}
