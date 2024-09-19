namespace IP_2102.TB.BBD.ProofOfWork
{
    internal readonly struct ProofOfWorkArgs(string difficulty, int nonceMaxValue)
    {
        public string Difficulty { get; init; } = difficulty;
        public int NonceMaxValue { get; init; } = nonceMaxValue;
    }
}