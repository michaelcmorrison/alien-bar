using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrbGenerator : MonoBehaviour
{
    private OrbQueue _orbQueue;
    private readonly Dictionary<OrbType, GenerationProbability> _generationProbabilities = new Dictionary<OrbType, GenerationProbability>();

    private void Awake()
    {
        _orbQueue = GetComponent<OrbQueue>();
    }

    private void Start()
    {
        InitializeGenerationProbabilities();
        _orbQueue.InitializeQueue();
    }

    public Orb GenerateRandomOrb()
    {
        var i = Random.Range(1, 101);

        foreach (var orbType in _generationProbabilities)
        {
            if (i >= orbType.Value.MinProbabilityRange && i <= orbType.Value.MaxProbabilityRange)
            {
                return new Orb(orbType.Key);
            }
        }

        return default;
    }

    private void InitializeGenerationProbabilities()
    {
        int i = 1;
        OrbType[] orbTypes = (OrbType[]) Enum.GetValues(typeof(OrbType)).Cast<OrbType>();
        
        foreach (var orbType in orbTypes)
        {
            var minValue = i;
            var maxValue = minValue + (100 / orbTypes.Length - 1);
            _generationProbabilities.Add(orbType, new GenerationProbability(minValue, maxValue));
            i = maxValue + 1;
        }
    }
}