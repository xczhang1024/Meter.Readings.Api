namespace Meter.Readings.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Blog API";

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message + " Web Host terminated unexpectedly");
            }
        }
        
        /// <summary>
        /// Create a host builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}