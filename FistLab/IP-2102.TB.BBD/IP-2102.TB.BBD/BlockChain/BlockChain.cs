using System.Collections;
using System.Security.Cryptography;
using System.Text;
using IP_2102.TB.BBD.Transactions;

namespace IP_2102.TB.BBD.CryptoChain;

internal class BlockChain : IBlockChain
{
    private readonly List<Block> _chain = [];
    private readonly List<Transaction> _currentTransactions = [];
    
    public int LastIndex => _chain.Count - 1;
    public Block LastBlock
    {
        get { return _chain?.Last() ?? 
                throw new InvalidOperationException("No genesis block in the chain"); }
    }

    public Block this[int index]
    {
        get { return _chain[index]; }
    }
    public BlockChain()
    {
        var genesisBlockArgs = new BlockArgs(1, DateTime.Now, 0, null);
        var genesisBlock = new Block(new object(), genesisBlockArgs);
        _chain.Add(genesisBlock);
    }

    public void AddBlock_Boiko(Block newBlock)
    {
        _chain.Add(newBlock);
    }

    public int RegisterTransaction_Boiko(string sender, string recipient, int amount)
    {
        _currentTransactions.Add(new Transaction(sender, recipient, amount));
        return _chain.Count;
    }

    public IEnumerator<Block> GetEnumerator()
    {
        return _chain.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
