// Starting parallel example
public class ParallelExample
{
    public async Task<string[]> RunAsync()
    {
        var response1 = await DoWork("input1");
        var response2 = await DoWork("input2");
        var response3 = await DoWork("input3");

        return new[] { response1, response2, response3 };
    }

    private async Task<string> DoWork(string input)
    {
        await Task.Delay(1000);

        return Guid.NewGuid().ToString();
    }

    private async Task<string> FailingWork(string input)
    {
        await Task.Delay(1000);

        throw new InvalidOperationException($"Processing {input} failed.");

        return Guid.NewGuid().ToString();
    }
}

// Separate awaits
var response1Task = DoWork("input1");
var response2Task = DoWork("input2");
var response3Task = DoWork("input3");

var response1 = await response1Task;
var response2 = await response2Task;
var response3 = await response3Task;

// Exception basic
        try
        {
            var response1Task = FailingWork("input1");
            var response2Task = DoWork("input2");
            var response3Task = FailingWork("input3");

            var response1 = await response1Task;
            var response2 = await response2Task;
            var response3 = await response3Task;

            return new[] { response1, response2, response3 };
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: {0}", ex.ToString());
            return Array.Empty<string>();
        }

// Exception with WhenAll
public class ParallelExample
{
    public async Task<string[]> RunAsync()
    {
        Task<string[]> allTask;
        try
        {
            var response1Task = FailingWork("input1");
            var response2Task = DoWork("input2");
            var response3Task = FailingWork("input3");

            allTask = Task.WhenAll(response1Task, response2Task, response3Task);

            var results = await allTask;

            //var response1 = await response1Task;
            //var response2 = await response2Task;
            //var response3 = await response3Task;

            return new[] { results[0], results[1], results[2] };
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: {0}", ex.ToString());
            return Array.Empty<string>();
        }
    }

    private async Task<string> DoWork(string input)
    {
        await Task.Delay(1000);

        return Guid.NewGuid().ToString();
    }

    private async Task<string> FailingWork(string input)
    {
        await Task.Delay(1000);

        throw new InvalidOperationException($"Processing {input} failed.");

        return Guid.NewGuid().ToString();
    }
}

