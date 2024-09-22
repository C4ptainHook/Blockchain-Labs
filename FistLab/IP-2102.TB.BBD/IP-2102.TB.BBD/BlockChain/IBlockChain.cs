namespace IP_2102.TB.BBD.CryptoChain;
internal interface IBlockChain : IEnumerable<Block>
{
    Block? LastBlock { get; }
    public Block this[int index] { get; }
    public int LastIndex { get; }
    void AddBlock(Block newBlock);
    int RegisterValue(object value);
}