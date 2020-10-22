using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Drink", fileName = "New Drink")]
public class Drink : ScriptableObject
{
    public Sprite drinkSprite;
    public string drinkId;
    public float drinkPrice;

    private void OnValidate()
    {
        drinkId = name;
    }
}