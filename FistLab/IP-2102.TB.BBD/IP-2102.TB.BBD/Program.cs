using IP_2102.TB.BBD.Configs;
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
        var proofOfWorkFactory = host.Services.GetRequiredService< BasicProofOfWorkFactory>();
        var proofOfWorkArgs = new ProofOfWorkArgs(TBConfig.DD, int.Parse(TBConfig.MMYYYY));
        var proofOfWork = proofOfWorkFactory.CreateProofOfWork(proofOfWorkArgs);
        var miner = new Miner(proofOfWork);
        var resultBlockChain = miner.Mine(2);
    }
}
