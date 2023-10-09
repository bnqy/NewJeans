//using System.Linq;
using static System.Console;


// IEnumerable<T> realises
string[] names = new[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };

var query1 = names.Where(name => name.EndsWith('m'));

var query2 = from name in names where name.EndsWith('m') select name;


/*string[] q1 =  query1.ToArray();
List<string> q2 = query2.ToList();*/

/*foreach (string n in query1)
{
    WriteLine(n);
    names[2] = "Dua";
}*/


//var q = names.Where(new Func<string, bool>());

static bool NameLongerThanFour(string name)
{
    return name.Length > 4;
}

//var q = names.Where(new Func<string, bool>(NameLongerThanFour));

//var q = names.Where(NameLongerThanFour);

var q = names.Where(name => name.Length > 4);

/*foreach (string n in q)
{
    WriteLine(n);
}*/



var q1 = names
         .Where(name => name.Length > 4)
         .OrderBy(name => name.Length);

/*foreach (string n in q1)
{
    WriteLine(n);
}*/

IOrderedEnumerable<string> q2 = names.Where(name => name.Length > 4)
          .OrderBy(name => name.Length)
          .ThenBy(name => name);

/*foreach (string n in q2)
{
    WriteLine(n);
}*/

List<Exception> exceptions = new()
{
     new ArgumentException(),
     new SystemException(),
     new IndexOutOfRangeException(),
     new InvalidOperationException(),
     new NullReferenceException(),
     new InvalidCastException(),
     new OverflowException(),
     new DivideByZeroException(),
     new ApplicationException()
};

var aEQs= exceptions.OfType<ArithmeticException>();

/*foreach (ArithmeticException aeq in aEQs)
{
    WriteLine(aeq);
}
*/

/*object[] obj = {"Asad", 23, 1, "Hasan", 3.2, 's', 23.1f};
var obj2 = obj.OfType < char>();
foreach (var w in obj2)
{
    WriteLine(w);
}*/