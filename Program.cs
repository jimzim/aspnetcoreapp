// using System;

// namespace ConsoleApplication
// {
//     public class Program
//     {
//         public static void Main(string[] args)
//         {
//             Console.WriteLine("Hello World!");
//         }
//     }
// }

using System;
using Microsoft.AspNetCore.Hosting;

namespace aspnetcoreapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://*:8080") // Use Port 8080 For OpenShift
                .Build();

            host.Run();

        }
    }
}