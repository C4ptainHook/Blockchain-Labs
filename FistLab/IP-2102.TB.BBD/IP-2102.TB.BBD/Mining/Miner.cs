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
    public readonly IBlockChain _blockchain;
    public Miner(IBlockChain blockchain, IProofOfWorkFactory<ProofOfWorkArgs> proofOfWorkFactory, ILogger<IMiner> logger)
    {
        _blockchain = blockchain;
        var proofOfWorkArgs = new ProofOfWorkArgs(TBConfig.DD, int.Parse(TBConfig.MMYYYY));
        _proofOfWork = proofOfWorkFactory.CreateProofOfWork(proofOfWorkArgs);
        _logger = logger;
    }
    public Block MineBlock()
    {
        var nonce = int.Parse(TBConfig.DD + TBConfig.MM);
        var minedSuccesfully = false;
        var newBlockIndex = _blockchain.LastIndex + 1;
        var lastBlockHash = _proofOfWork.GetHash(_blockchain.LastBlock);
        var iteration = 0;
        _logger.LogInformation("Start mining block {newBlockIndex}", newBlockIndex);
        while (!minedSuccesfully)
        {
            var blockArgs = new BlockArgs(newBlockIndex, DateTime.Now, nonce, lastBlockHash);
            var newBlock = new Block(new object(), blockArgs);
            if (_proofOfWork.IsHashValid(_proofOfWork.GetHash(newBlock)))
            {
                _blockchain.AddBlock_Boiko(newBlock);
                _logger.LogInformation("Block {newBlockIndex} mined after {iteration} iterations", newBlockIndex, iteration);
                _logger.LogInformation("Proof number: {proof}", nonce);
                var currentHash = _proofOfWork.GetHash(_blockchain.LastBlock);
                _logger.LogInformation("Previous hash: {previousHash} <-> Current hash: {currentHash}", lastBlockHash, currentHash);
                minedSuccesfully = true;
                _logger.LogInformation("Finished mining block {newBlockIndex}", newBlockIndex);
                return newBlock;
            }
            nonce = _proofOfWork.GetNewNonce();
            iteration++;
        }
        throw new InvalidOperationException("Block could not be mined");
    }
}