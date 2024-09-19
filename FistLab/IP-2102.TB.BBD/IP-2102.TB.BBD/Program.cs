using IP_2102.TB.BBD.Configs;
using IP_2102.TB.BBD.Mining;
using IP_2102.TB.BBD.ProofOfWork;
using IP_2102.TB.BBD.ProofOfWork.Factories;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace IP_2102.TB.BBD;

internal class Program
{
    static void Main(string[] args)
    {
        var host = AppSetup.GetConfiguration();
        var miner = host.Services.GetRequiredService<Miner>();
        var resultBlockChain = miner.Mine(2);
    }
}
