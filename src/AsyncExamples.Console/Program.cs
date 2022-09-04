using AsyncExamples.Parallel;
using System.Diagnostics;

var sw = Stopwatch.StartNew();

var example = new ParallelExample();
var results = await example.RunAsync();

sw.Stop();
Console.WriteLine("Received {0} results", results.Length);
Console.WriteLine("Elapsed time: {0}", sw.Elapsed);
