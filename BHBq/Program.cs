using ElectronNET.API;
using ElectronNET.API.Entities;

public class Program
{
    public Program()
    {
    }
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseElectron(args);
            webBuilder.UseStartup<Startup>();
            webBuilder.UseEnvironment("Development");
        });
}
