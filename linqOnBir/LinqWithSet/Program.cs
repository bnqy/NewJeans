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
Output(cohort2.Zip(cohort3, (c2, c3) => $"{c2} with {c3}"));


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