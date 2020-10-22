using System.Collections.Generic;
using UnityEngine;

public class OrbStack : MonoBehaviour
{
    public StackEvent stackFull;
    
    private List<Orb> _orbStack = new List<Orb>();
    private readonly int _stackSize = 3;

    private void Update()
    {
        CheckStack();
    }

    public void AddToStack(Orb orb)
    {
        if (_orbStack.Count < _stackSize)
        {
            _orbStack.Add(orb);
        }
    }

    public Orb[] GetStack()
    {
        return _orbStack.ToArray();
    }
    
    private void CheckStack()
    {
        if (_orbStack.Count == _stackSize)
        {
            stackFull.Invoke(StackProcessor.GetId(_orbStack));
            _orbStack.Clear();
        }
    }

#if UNITY_EDITOR
    [ContextMenu("AddFruit")]
    public void AddFruit()
    {
        AddToStack(new Orb(OrbType.Fruit));
        Debug.Log("Added Fruit");
    }

    [ContextMenu("AddSpice")]
    public void AddSpice()
    {
        AddToStack(new Orb(OrbType.Spice));
        Debug.Log("Added Spice");
    }

    [ContextMenu("AddHerb")]
    public void AddHerb()
    {
        AddToStack(new Orb(OrbType.Herb));
        Debug.Log("Added Herb");
    }

    [ContextMenu("AddBerry")]
    public void AddBerry()
    {
        AddToStack(new Orb(OrbType.Berry));
        Debug.Log("AddBerry");
    }
#endif
}