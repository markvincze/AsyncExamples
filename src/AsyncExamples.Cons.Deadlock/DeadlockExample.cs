using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncExamples.Cons.Deadlock
{
    public class DeadlockExample
    {
        public string Run()
        {
            DoWork().Wait();
            var result = DoWork().Result;

            return result;
        }

        private async Task<string> DoWork()
        {
            await Task.Delay(1000);

            return "Work result";
        }
    }
}
