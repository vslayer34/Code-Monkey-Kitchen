using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField, Tooltip("The valid ingredients for the final recipe")]
    private List<SO_KitchenObject> _validIngredients;

    private List<SO_KitchenObject> _plateContents;



    // Game Loop Methods---------------------------------------------------------------------------
    
    private void Awake()
    {
        _plateContents = new List<SO_KitchenObject>();        
    }

    // Member Methods------------------------------------------------------------------------------
    public bool TryAddIngredient(SO_KitchenObject ingredient)
    {
        if (!_validIngredients.Contains(ingredient))
        {
            return false;
        }

        if (_plateContents.Contains(ingredient))
        {
            return false;
        }
        else
        {
            _plateContents.Add(ingredient);
            return true;
        }
    }
}
