namespace IP_2102.TB.BBD.ProofOfWork;

internal interface IProofOfWork
{
    int GetProofOfWork(in string lastHash);
    string GetHashFromGuess(in int nonce, in string lastHash);
    bool HashWithContainsDifficulty(in string hashToCheck);
}
