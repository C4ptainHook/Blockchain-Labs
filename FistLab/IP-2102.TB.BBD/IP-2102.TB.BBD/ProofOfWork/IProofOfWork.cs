using IP_2102.TB.BBD.CryptoChain;

namespace IP_2102.TB.BBD.ProofOfWork;

internal interface IProofOfWork
{
    string? GetHash(in Block? blockToProve);
    bool IsHashValid(in string hashToCheck);
    int GetNewNonce();
}
