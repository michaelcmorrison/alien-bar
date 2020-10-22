using System;
using System.Collections.Generic;
using UnityEngine;

public class StackProcessor : MonoBehaviour
{
    public static string GetId(List<Orb> orbStack)
    {
        var id = "";
        foreach (var orb in orbStack)
        {
            id += (int) orb.OrbType;
        }
        var cArr = id.ToCharArray();
        Array.Sort(cArr);
        return new string(cArr);
    }
}