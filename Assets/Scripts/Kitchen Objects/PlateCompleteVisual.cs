using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct IngredientGameobjectPair
{
    /// <summary>
    /// The ingredient data
    /// </summary>
    public SO_KitchenObject ingredient;

    /// <summary>
    /// The ingredient representation on the plate
    /// </summary>
    public GameObject ingredientPlateVisual;
}

public class PlateCompleteVisual : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the parent plate")]
    private PlateKitchenObject _parentPlate;

    [SerializeField, Tooltip("Reference to each ingredient and the relating gameobject on the plate")]
    private List<IngredientGameobjectPair> _ingredientPlateVisuals;



    // Game Loop Methods---------------------------------------------------------------------------
    
    private void Start()
    {
        _parentPlate.OnIngredientAdded += ParentPlate_OnIngredientAdded;   

        foreach (var pair in _ingredientPlateVisuals)
        {
            pair.ingredientPlateVisual.SetActive(false);
        }
    }

    // Signal Methods------------------------------------------------------------------------------
    
    private void ParentPlate_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (var pair in _ingredientPlateVisuals)
        {
            if (e.kitchenObjectSO == pair.ingredient)
            {
                pair.ingredientPlateVisual.SetActive(true);
            }
        }
    }
}
