using System.Net;
namespace dal
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseUrls("http://localhost:5000", "https://localhost:5005");

                webBuilder.ConfigureKestrel(serverOptions =>
                {
                    serverOptions.Limits.MaxRequestBodySize = 52428800; // 50MB
                    serverOptions.Limits.MaxConcurrentConnections = 100;
                    serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;
                    serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);;
                });
            });
  }
}
