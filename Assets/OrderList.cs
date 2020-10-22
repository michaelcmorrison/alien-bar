using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderList : MonoBehaviour
{
    public int maxOrders;
    public readonly List<DrinkOrder> DrinkOrders = new List<DrinkOrder>();
    [SerializeField] private DrinkList drinkList;

    private void Awake()
    {
        for (int i = 0; i < maxOrders; i++)
        {
            AddRandomOrder();
        }
    }

    private void AddRandomOrder()
    {
        var randomDrink = Random.Range(0, drinkList.drinks.Length);
        DrinkOrders.Add(new DrinkOrder(drinkList.drinks[randomDrink]));
    }

    public void CheckForCompleteOrder(string stackId)
    {
        foreach (var drinkOrder in DrinkOrders)
        {
            if (drinkOrder.Drink.drinkId == stackId)
            {
                DrinkOrders.Remove(drinkOrder);
                break;
            }
        }
    }
}