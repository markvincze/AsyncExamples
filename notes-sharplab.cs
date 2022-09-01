using System;
using System.IO;
using System.Threading.Tasks;

public class C {
    public void M() {
        Console.WriteLine("Before waiting");
        
        Task.Delay(500).Wait();
        
        Console.WriteLine("Before waiting");
    }
}

// More complicated
using System;
using System.IO;
using System.Threading.Tasks;

public class C {
    public async Task M() {
        Console.WriteLine("Before waiting");
        
        using(var fs = new FileStream("test.txt", FileMode.Open))
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    await Task.Delay(500);
                }
            }
            catch(Exception ex)
            {
                await Task.Delay(20);
            }

            Console.WriteLine("Before waiting");
        }
    }
}