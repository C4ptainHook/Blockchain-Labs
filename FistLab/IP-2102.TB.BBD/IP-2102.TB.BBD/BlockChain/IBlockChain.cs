namespace IP_2102.TB.BBD.CryptoChain;
internal interface IBlockChain : IEnumerable<Block>
{
    Block? LastBlock { get; }
    public Block this[int index] { get; }
    string Hash_Boiko(Block block);
    Block NewBlock_Boiko(int proof, string previousHash);
    int NewTransaction_Boiko(string sender, string recipient, int amount);
}