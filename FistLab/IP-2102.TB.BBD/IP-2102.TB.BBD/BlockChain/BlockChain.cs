using System.Security.Cryptography;
using System.Text;
using IP_2102.TB.BBD.Transactions;

namespace IP_2102.TB.BBD.CryptoChain;

internal class BlockChain : IBlockChain
{
    private readonly List<Block> _chain = [];
    private readonly List<Transaction> _currentTransactions = [];

    public Block LastBlock
    {
        get { return _chain?.Last() ?? throw new InvalidOperationException("No genesis block in the chain"); }
    }

    public BlockChain()
    {
        NewBlock_Boiko(100, "0");
    }

    public Block NewBlock_Boiko(int proof, string previousHash)
    {
        var transactionsCopy = new List<Transaction>(_currentTransactions);
        var resultBlock = new Block(_chain.Count, transactionsCopy, proof, previousHash);
        _currentTransactions.Clear();
        _chain.Add(resultBlock);
        return resultBlock;
    }

    public int NewTransaction_Boiko(string sender, string recipient, int amount)
    {
        _currentTransactions.Add(new Transaction(sender, recipient, amount));
        return _chain.Count;
    }

    public string Hash_Boiko(Block block)
    {
        var hashingInputBuilder = new StringBuilder();

        hashingInputBuilder.Append(block.Index)
                           .Append(block.TimeStamp)
                           .Append(block.Proof)
                           .Append(block.PreviousHash);

        var hashingInput = hashingInputBuilder.ToString();

        using var sha256 = SHA256.Create();

        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashingInput));
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
}
