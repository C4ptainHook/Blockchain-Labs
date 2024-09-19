namespace IP_2102.TB.BBD.CryptoChain;
internal interface IBlockChain
{
    Block? LastBlock { get; }

    string Hash_Boiko(Block block);
    Block NewBlock_Boiko(int proof, string previousHash);
    int NewTransaction_Boiko(string sender, string recipient, int amount);
}