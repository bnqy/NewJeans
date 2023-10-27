using static System.Console;
using System.Diagnostics;



OutCurrentThread();
Stopwatch timer = Stopwatch.StartNew();
/*WriteLine("Running methods synchronously on one thread.");
MethodA();
MethodB();
MethodC();*/
/*WriteLine("Running methods asynchronously on multiple threads.");

Task taskA = new(MethodA);
taskA.Start();

Task taskB = Task.Factory.StartNew(MethodB);

Task taskC = Task.Run(MethodC);

Task[] tasks = { taskA, taskB, taskC};
Task.WaitAll(tasks);*/

WriteLine("Passing the result of one task as an input into another.");
Task<string> taskServiceThenSProc = Task.Factory
 .StartNew(CallWebService) // returns Task<decimal>
 .ContinueWith(previousTask => // returns Task<string>
 CallStoredProcedure(previousTask.Result));
WriteLine($"Result: {taskServiceThenSProc.Result}");

WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");


static void OutCurrentThread()
{
    Thread t = Thread.CurrentThread;

    WriteLine("Thread Id: {0}, Priority: {1}, Background: {2}, Name: {3}",
        t.ManagedThreadId, 
        t.Priority,
        t.IsBackground, 
        t.Name ?? "null");
}


static void MethodA()
{
    WriteLine("Starting method A: ");
    OutCurrentThread();
    Thread.Sleep(3000);
    WriteLine("Finishing method A");
}

static void MethodB()
{
    WriteLine("Starting method B: ");
    OutCurrentThread();
    Thread.Sleep(2000);
    WriteLine("Finishing method B");
}

static void MethodC()
{
    WriteLine("Starting method C: ");
    OutCurrentThread();
    Thread.Sleep(1000);
    WriteLine("Finishing method C");
}


static decimal CallWebService()
{
    WriteLine("Starting call to web service...");
    OutCurrentThread();
    Thread.Sleep((new Random()).Next(2000, 4000));
    WriteLine("Finished call to web service.");
    return 89.99M;
}

static string CallStoredProcedure(decimal amount)
{
    WriteLine("Starting call to stored procedure...");
    OutCurrentThread();
    Thread.Sleep((new Random()).Next(2000, 4000));
    WriteLine("Finished call to stored procedure.");
    return $"12 products cost more than {amount:C}.";
}