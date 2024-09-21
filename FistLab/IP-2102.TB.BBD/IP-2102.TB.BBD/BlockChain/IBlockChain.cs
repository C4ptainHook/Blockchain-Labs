namespace IP_2102.TB.BBD.CryptoChain;
internal interface IBlockChain : IEnumerable<Block>
{
    Block LastBlock { get; }
    public Block this[int index] { get; }
    public int LastIndex { get; }
    void AddBlock_Boiko(Block newBlock);
    int RegisterTransaction_Boiko(string sender, string recipient, int amount);
}