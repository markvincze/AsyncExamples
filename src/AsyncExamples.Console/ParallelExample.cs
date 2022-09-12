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
        }
    }
}
