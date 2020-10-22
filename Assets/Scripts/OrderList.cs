using System.Collections.Generic;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    public int maxOrders;
    public readonly List<DrinkOrder> DrinkOrders = new List<DrinkOrder>();
    
    public void CheckForCompleteOrder(string stackId)
    {
        var foundOrder = false;
        
        foreach (var drinkOrder in DrinkOrders)
        {
            if (drinkOrder.Drink.drinkId == stackId)
            {
                foundOrder = true;
                CompleteOrder(drinkOrder);
                break;
            }
        }

        if (!foundOrder)
        {
            WastedStack();
        }
    }

    private void WastedStack()
    {
        SoundManager.Instance.PlayClip(SoundManager.Instance.stackWasted);
        GameManager.Instance.playerMoney -= 5;
    }

    private void CompleteOrder(DrinkOrder order)
    {
        SoundManager.Instance.PlayClip(SoundManager.Instance.orderComplete);
        GameManager.Instance.playerMoney += order.Drink.drinkPrice;
        DrinkOrders.Remove(order);
    }
}