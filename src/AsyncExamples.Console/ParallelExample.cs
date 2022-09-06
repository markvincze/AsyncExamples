using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncExamples.Parallel
{
    public class ParallelExample
    {
        public async Task<string[]> RunAsync()
        {
            try
            {
                var response1Task = FailingWork("input1");
                var response2Task = DoWork("input2");
                var response3Task = FailingWork("input3");

                //var response1 = await response1Task;
                //var response2 = await response2Task;
                //var response3 = await response3Task;

                var results = await Task.WhenAll(response1Task, response2Task, response3Task);

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
        }
    }
}
