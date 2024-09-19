using IP_2102.TB.BBD.Transactions;
namespace IP_2102.TB.BBD.CryptoChain;

internal record Block
{
    public int Index { get; init; }
    public DateTime TimeStamp { get; init; }
    public List<Transaction> Transactions { get; init; }
    public int Proof { get; init; }
    public string PreviousHash { get; init; }

    public Block(int index, List<Transaction> transactions, int proof, string previousHash)
    {
        Index = index;
        TimeStamp = DateTime.Now;
        Transactions = transactions;
        Proof = proof;
        PreviousHash = previousHash;
    }
}
