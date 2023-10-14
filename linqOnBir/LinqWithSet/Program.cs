using static System.Console;




string[] cohort1 = { "Rachel", "Gareth", "Jonathan", "George" };
string[] cohort2 = { "Jack", "Stephen", "Daniel", "Jack", "Jared" };
string[] cohort3 = { "Declan", "Jack", "Jack", "Jasmine", "Conor" };


Output(cohort1, "Cohort-1");
Output(cohort2, "Cohort-2");
Output(cohort3, "Cohort-3");
Output(cohort3.Distinct(), "Cohort-3.Distinct()");
Output(cohort3.DistinctBy(name => name.Substring(0, 2)), "cohort3.DistinctBy(name => name.Substring(0, 2))");
Output(cohort2.Union(cohort3), "cohort2.Union(cohort3)");
Output(cohort2.Zip(cohort3, (c2, c3) => $"{c2} with {c3}"), "cohort2.Zip(cohort3)");

var v = double.NegativeInfinity;
var v2 = double.NaN;
var v3 = double.PositiveInfinity;
var v4 = double.Epsilon;
Console.WriteLine($"NegativeInfinity: {v}\nNaN: {v2}\nPositiveInfinity: {v3}\nEpsilon: {v4}");

double[] doubles = { 5.0, 5.3, 5.5, 6.0, 6.3, 6.5, 7.0};
for (int i = 0; i<doubles.Length; i++)
{
    // Console.WriteLine(Convert.ToInt32(doubles[i]));
    WriteLine((int)doubles[i]);
}

static void Output(IEnumerable<string> cohort, string description = "")
{
    if (!string.IsNullOrEmpty(description))
    {
        WriteLine(description);
    }
    Write("   ");
    WriteLine(string.Join(", ", cohort.ToArray()));
    WriteLine();
}