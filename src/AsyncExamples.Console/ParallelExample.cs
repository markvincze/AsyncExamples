using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncExamples.Cons
{
    public class ParallelExample
    {
        public async Task<string[]> Run()
        {
            Task<string[]> allTask;
            try
            {
                var response1Task = DoWork(1000);
                var response2Task = FailingWork("input2");
                var response3Task = DoWork(3000);

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

        private async Task<string> DoWork(int waitTime)
        {
            await Task.Delay(waitTime);

            return Guid.NewGuid().ToString();
        }

        private async Task<string> FailingWork(string input)
        {
            await Task.Delay(1000);

            throw new InvalidOperationException($"Processing {input} failed.");

            return Guid.NewGuid().ToString();
        }
    }
}
