using System.Collections.Generic;
using UnityEngine;

public class OrbQueue : MonoBehaviour
{
    private readonly int _queueSize = 5;
    private Queue<Orb> _orbQueue;
    private OrbStack _orbStack;
    private OrbGenerator _orbGenerator;

    private void Awake()
    {
        _orbGenerator = GetComponent<OrbGenerator>();
        _orbStack = GetComponent<OrbStack>();
    }
    
    public void InitializeQueue()
    {
        _orbQueue = new Queue<Orb>();
        for (int i = 0; i < _queueSize; i++)
        {
            QueueOrb(_orbGenerator.GenerateRandomOrb());
        }
    }

    public void UseOrb()
    {
        SoundManager.Instance.PlayClip(SoundManager.Instance.orbUse);
        _orbStack.AddToStack(DequeueOrb());
        QueueOrb(_orbGenerator.GenerateRandomOrb());
    }

    public void ThrowOrb()
    {
        SoundManager.Instance.PlayClip(SoundManager.Instance.orbThrow);
        DequeueOrb();
        QueueOrb(_orbGenerator.GenerateRandomOrb());
    }

    public Orb[] GetQueue()
    {
        return _orbQueue.ToArray();
    }

    private Orb DequeueOrb()
    {
        return _orbQueue.Dequeue();
    }

    private void QueueOrb(Orb orb)
    {
        _orbQueue.Enqueue(orb);
    }
}