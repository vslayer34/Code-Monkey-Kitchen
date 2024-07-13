using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField, Tooltip("Referecne to the produced ingredient")]
    private SO_CuttingReciepe[] _CuttingReciepes;



    // Member Methods------------------------------------------------------------------------------
    public override void Interact(Player player)
    {
        if (!IsKitchenObjectOnCounter())
        {
            // There is no object on top of the counter
            if (player.IsKitchenObjectOnCounter())
            {
                if (IsIngredientCuttable(player.KitchenObjectOnCounter.KitchenObj))
                {
                    // Drop the item if its cuttable
                    player.KitchenObjectOnCounter.SetParentCounter(this);
                }
            }
            else
            {
                // The player isn't carring anything
            }
        }
        else
        {
            // There is a kitchen object on top of the counter
            if (player.IsKitchenObjectOnCounter())
            {
                // The player is carring something
            }
            else
            {
                // The player isn't carring anything
                // Give the item on counter to the player
                KitchenObjectOnCounter.SetParentCounter(player);
            }
        }
    }

    public override void InteractAlt(Player player)
    {
        // Only cut if there's in a kitchen object and is cuttable
        if (IsKitchenObjectOnCounter() && IsIngredientCuttable(KitchenObjectOnCounter.KitchenObj))
        {
            SO_KitchenObject ingredient = GetRelatingOutput(KitchenObjectOnCounter.KitchenObj);
            KitchenObjectOnCounter.DestroySelf();

            KitchenObject.SpawnNewKitchenObject(ingredient, this);
        }
    }

    
    private bool IsIngredientCuttable(SO_KitchenObject ingredient)
    {
        foreach (var cuttingReciepe in _CuttingReciepes)
        {
            if (cuttingReciepe.Input == ingredient)
            {
                return true;
            }
        }

        return false;
    }


    private SO_KitchenObject GetRelatingOutput(SO_KitchenObject ingredient)
    {
        foreach (var cuttingReciepe in _CuttingReciepes)
        {
            if (cuttingReciepe.Input == ingredient)
            {
                return cuttingReciepe.Output;
            }
        }

        return null;
    }
}
