using System.Security.Cryptography;
using System.Text;
using IP_2102.TB.BBD.Configs;
using IP_2102.TB.BBD.RandomWrappers;
using Microsoft.Extensions.Logging;

namespace IP_2102.TB.BBD.ProofOfWork;

internal class BasicProofOfWork(IRandomNumerical<int> random, ProofOfWorkArgs args, ILogger<IProofOfWork> logger) : IProofOfWork
{
    private readonly IRandomNumerical<int> _random = random;
    private readonly ILogger<IProofOfWork> _logger = logger;
    public int GetProofOfWork(in string lastBlockHash)
    {
        _logger.LogInformation("Starting proof of work");
        var nonce = int.Parse(TBConfig.DD + TBConfig.MM);
        var iteration = 0;
        while (!HashWithContainsDifficulty(GetHashFromGuess(nonce, lastBlockHash)))
        {
            nonce = _random.Next(1, args.NonceMaxValue);
            iteration++;
        }
        _logger.LogInformation("Number of iterations: {counter}", iteration);
        _logger.LogInformation("Proof of work found: {nonce}", nonce);
        return nonce;
    }

    public string GetHashFromGuess(in int nonce, in string lastHash)
    {
        var guess = nonce.ToString() + lastHash;
        using var sha256 = SHA256.Create();

        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(guess));
        return BitConverter.ToString(hashBytes);
    }
    public bool HashWithContainsDifficulty(in string hashToCheck)
    {
        return hashToCheck.EndsWith(args.Difficulty);
    }
}
