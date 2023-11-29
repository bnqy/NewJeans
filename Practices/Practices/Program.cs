using Practices;
using static System.Console;

Graph graph = new Graph();

graph.AddNode("A");
graph.AddNode("B");
graph.AddNode("C");
graph.AddNode("D");

graph.AddEdges("A", "B");
graph.AddEdges("B", "C");
graph.AddEdges("C", "D");
graph.AddEdges("D", "A");

graph.Display();