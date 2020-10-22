using System.Collections.Generic;
using UnityEngine;

public class OrdersUI : MonoBehaviour
{
    public List<OrderPanel> orderPanels;
    [SerializeField] private OrderList orderList;

    private void Update()
    {
        UpdateOrders();
    }

    private void UpdateOrders()
    {
        for (int i = 0; i < orderPanels.Count; i++)
        {
            if (i < orderList.DrinkOrders.Count)
            {
                orderPanels[i].gameObject.SetActive(true);
                orderPanels[i].FillPanel(orderList.DrinkOrders[i]);
            }
            else
            {
                orderPanels[i].gameObject.SetActive(false);
            }
        }
    }
}