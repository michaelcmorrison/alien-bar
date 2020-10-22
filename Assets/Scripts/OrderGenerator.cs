using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderGenerator : MonoBehaviour
{
    private OrderList _orderList;
    [SerializeField] private DrinkList drinkList;

    private void Awake()
    {
        _orderList = GetComponent<OrderList>();
    }

    private void Start()
    {
        for (int i = 0; i < Mathf.Floor( _orderList.maxOrders / 2); i++)
        {
            AddRandomOrder();
        }
    }

    public void AddRandomOrder()
    {
        if (_orderList.DrinkOrders.Count >= _orderList.maxOrders) return;
        
        var randomDrink = Random.Range(0, drinkList.drinks.Length);
        _orderList.DrinkOrders.Add(new DrinkOrder(drinkList.drinks[randomDrink]));
    }
}
