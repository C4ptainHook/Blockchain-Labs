using IP_2102.TB.BBD.Configs;
using IP_2102.TB.BBD.CryptoChain;
using IP_2102.TB.BBD.ProofOfWork;
using IP_2102.TB.BBD.ProofOfWork.Factories;
using Microsoft.Extensions.Logging;

namespace IP_2102.TB.BBD.Mining;

internal class Miner : IMiner
{
    private readonly IProofOfWork _proofOfWork;
    private readonly ILogger<IMiner> _logger;
    public Miner(IProofOfWorkFactory<ProofOfWorkArgs> proofOfWorkFactory, ILogger<IMiner> logger)
    {
        var proofOfWorkArgs = new ProofOfWorkArgs(TBConfig.DD, int.Parse(TBConfig.MMYYYY));
        _proofOfWork = proofOfWorkFactory.CreateProofOfWork(proofOfWorkArgs);
        _logger = logger;
    }
    public IBlockChain Mine(int numberOfBlocks)
    {
        var blockChain = new BlockChain();
        for (var i = 0; i < numberOfBlocks; i++)
        {
            var previousHash = blockChain.Hash_Boiko(blockChain.LastBlock);
            var newProof = _proofOfWork.GetProofOfWork(previousHash);
            _logger.LogInformation("Previous hash: {hash}", previousHash);
            blockChain.NewBlock_Boiko(newProof, previousHash);
            _logger.LogInformation("Current hash: {hash}", blockChain.Hash_Boiko(blockChain.LastBlock));
        }
        return blockChain;
    }
}