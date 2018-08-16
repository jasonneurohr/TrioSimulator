using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;

namespace TrioSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //            CreateWebHostBuilder(args).Build().Run();

            BuildWebHost(args).Run();
        }

        //        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //            WebHost.CreateDefaultBuilder(args)
        //                .UseKestrel(c => c.AddServerHeader = false)
        //                .UseStartup<Startup>();

        public static IWebHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddCommandLine(args)
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseKestrel(c => c.AddServerHeader = false)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
