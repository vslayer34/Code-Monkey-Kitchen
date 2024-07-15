using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{
    //private SO_KitchenObject _kitchenObject;



    // Member Methods------------------------------------------------------------------------------
    public override void Interact(Player player)
    {
        if (!IsKitchenObjectOnCounter())
        {
            // There is no object on top of the counter
            if (player.IsKitchenObjectOnCounter())
            {
                player.KitchenObjectOnCounter.SetParentCounter(this);
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
                // Check if it's a plate
                if (player.KitchenObjectOnCounter.TryGetPlateKitchenObject(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(KitchenObjectOnCounter.KitchenObj))
                    {
                        KitchenObjectOnCounter.DestroySelf();
                    }
                }
                else
                {
                    // The player is carrying something else
                    // Check if there's a plate on the counter to put what the player holding on it
                    if (KitchenObjectOnCounter.TryGetPlateKitchenObject(out plateKitchenObject))
                    {
                        Debug.Log("There's a plate on the counter");
                        // There's a plate on the counter
                        // Check if the plate can take the ingredient or not
                        if (plateKitchenObject.TryAddIngredient(player.KitchenObjectOnCounter.KitchenObj))
                        {
                            Debug.Log("Transform ownership");
                            player.KitchenObjectOnCounter.DestroySelf();
                        }
                    }
                }
            }
            else
            {
                // The player isn't carring anything
                // Give the item on counter to the player
                KitchenObjectOnCounter.SetParentCounter(player);
            }
        }
    }

    // Getters & Setters---------------------------------------------------------------------------
}
