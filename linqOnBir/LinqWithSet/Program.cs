using static System.Console;




string[] cohort1 = { "Rachel", "Gareth", "Jonathan", "George" };
string[] cohort2 = { "Jack", "Stephen", "Daniel", "Jack", "Jared" };
string[] cohort3 = { "Declan", "Jack", "Jack", "Jasmine", "Conor" };


Output(cohort1, "Cohort-1");
Output(cohort2, "Cohort-2");
Output(cohort3, "Cohort-3");


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