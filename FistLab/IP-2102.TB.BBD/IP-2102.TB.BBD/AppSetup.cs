using IP_2102.TB.BBD.ProofOfWork.Factories;
using IP_2102.TB.BBD.RandomWrappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace IP_2102.TB.BBD
{
    internal static class AppSetup
    {
        public static IHost GetConfiguration()
        {
            var configuration = new ConfigurationBuilder().
               AddJsonFile("appsettings.json")
               .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IRandomNumerical<int>, RandomWrapper>();
                    services.AddTransient<BasicProofOfWorkFactory>();
                })
                .UseSerilog()
                .Build();
        }
    }
}
