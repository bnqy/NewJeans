//using System.Linq;
using static System.Console;


// IEnumerable<T> realises
string[] names = new[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };

var query1 = names.Where(name => name.EndsWith('m'));

var query2 = from name in names where name.EndsWith('m') select name;


string[] q1 =  query1.ToArray();
List<string> q2 = query2.ToList();

foreach (string n in query1)
{
    WriteLine(n);
    names[2] = "Dua";
}


//var q = names.Where(new Func<string, bool>());

static bool NameLongerThanFour(string name)
{
    return name.Length > 4;
}

var q = names.Where(new Func<string, bool>(NameLongerThanFour));

foreach (string n in q)
{
    WriteLine(n);
}