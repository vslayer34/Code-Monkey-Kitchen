using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DeliveryManager : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the container object")]
    private Transform _container;


    [SerializeField, Tooltip("Reference to the recipe template")]
    private Transform _recipeTemplate;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        DeliveryManager.Instance.OnNewOrderAdded += DeliveryManager_NewOrderAdded;
        DeliveryManager.Instance.OnOrderCompleted += DeliveryManager_OnOrderCompleted;

        UpdateOrdersUI();
    }

    // Memeber Methods-----------------------------------------------------------------------------

    private void UpdateOrdersUI()
    {
        foreach (Transform item in _container)
        {
            if (item == _recipeTemplate)
            {
                item.gameObject.SetActive(false);
                continue;
            }

            Destroy(item.gameObject);
        }

        foreach (var order in DeliveryManager.Instance.WaitingOrders)
        {
            var newOrderUI = Instantiate(_recipeTemplate, _container);
            newOrderUI.gameObject.SetActive(true);
            newOrderUI.GetComponent<UI_RecipeTemplate>().UpdateTemplateInfo(order);
        }
    }

    // Signal Methods------------------------------------------------------------------------------

    private void DeliveryManager_NewOrderAdded(object sender, EventArgs e)
    {
        UpdateOrdersUI();
    }


    private void DeliveryManager_OnOrderCompleted(object sender, EventArgs e)
    {
        UpdateOrdersUI();
    }
}
