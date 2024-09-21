using IP_2102.TB.BBD.Mining;
using Microsoft.Extensions.DependencyInjection;

namespace IP_2102.TB.BBD;

internal class Program
{
    static void Main(string[] args)
    {
        var host = AppSetup.GetConfiguration();
        var miner = host.Services.GetRequiredService<Miner>();
        for (int i = 0; i < 5; i++)
        {
            miner.MineBlock();
        }
    }
}
