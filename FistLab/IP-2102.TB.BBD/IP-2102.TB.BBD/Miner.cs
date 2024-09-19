using IP_2102.TB.BBD.CryptoChain;
using IP_2102.TB.BBD.ProofOfWork;

namespace IP_2102.TB.BBD;

internal class Miner
{
    private readonly IProofOfWork _proofOfWork;
    public Miner(IProofOfWork proofOfWork)
    {
        _proofOfWork = proofOfWork;
    }
    public IBlockChain Mine(int numberOfBlocks)
    {
        var blockChain = new BlockChain();
        for (var i = 0; i < numberOfBlocks; i++)
        {
            var newProof = _proofOfWork.GetProofOfWork(blockChain.Hash_Boiko(blockChain.LastBlock));
            var previousHash = _proofOfWork.GetCurrentHash(newProof, blockChain.Hash_Boiko(blockChain.LastBlock));
            blockChain.NewBlock_Boiko(newProof, previousHash);
        }
        return blockChain;
    }
}