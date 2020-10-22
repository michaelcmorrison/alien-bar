public readonly struct GenerationProbability
{
    public readonly int MinProbabilityRange;
    public readonly int MaxProbabilityRange;

    public GenerationProbability(int minProbabilityRange, int maxProbabilityRange)
    {
        MinProbabilityRange = minProbabilityRange;
        MaxProbabilityRange = maxProbabilityRange;
    }
}