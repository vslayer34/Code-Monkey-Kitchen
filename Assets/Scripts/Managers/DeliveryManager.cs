using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance { get; private set; }

    [field: SerializeField, Tooltip("all recipes for meals")]
    public SO_RecipeList DaysMenu { get; private set; }

    private List<SO_Recipe> _waitingOrders;

    // Timer
    private float _newOrderTimer;
    private const float NEW_ORDER_TIME_INTERVAL = 4.0f;

    private const int MAX_NUMBER_OF_ORDERS = 4;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;
        _waitingOrders = new List<SO_Recipe>();
    }

    private void Update()
    {
        _newOrderTimer -= Time.deltaTime;

        if ( _newOrderTimer <= NEW_ORDER_TIME_INTERVAL)
        {
            _newOrderTimer = NEW_ORDER_TIME_INTERVAL;

            if (_waitingOrders.Count <= MAX_NUMBER_OF_ORDERS)
            {
                var newOrder = DaysMenu.RecipeMenu[Random.Range(0, DaysMenu.RecipeMenu.Count)];
                _waitingOrders.Add(newOrder);

                Debug.Log(newOrder.RecipeName);
            }
        }
    }

    // Member Methods------------------------------------------------------------------------------

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        SO_Recipe order;

        for (int i = 0; i < _waitingOrders.Count; i++)
        {
            order = _waitingOrders[i];

            if (order.RecipeIngredients.Count == plateKitchenObject.PlateContents.Count)
            {
                // Has same number of ingredients
                bool plateContentMatchRecipe = true;

                foreach (var recipeIngredient in order.RecipeIngredients)
                {
                    // Cycling through the ingredients of the recipe
                    bool ingredientFound = false;
                    foreach (var plateIngredient in plateKitchenObject.PlateContents)
                    {
                        // Cycling through the ingredients of the plate
                        if (plateIngredient == recipeIngredient)
                        {
                            // ingredient matches
                            ingredientFound = true;
                            break;
                        }
                    }

                    if (!ingredientFound)
                    {
                        // The recipe ingredients wasn't found on the plate
                        plateContentMatchRecipe = false;
                    }
                }

                if (plateContentMatchRecipe)
                {
                    // Player delivered correct recipe
                    Debug.Log("Player delivered correct recipe");
                    _waitingOrders.RemoveAt(i);
                    return;
                }
            }
        }

        // No matches found
        Debug.Log("The recipe being delivered is incorrect");
    }
}
