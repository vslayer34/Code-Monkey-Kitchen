using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    // Game Loop Methods---------------------------------------------------------------------------
    // Member Methods------------------------------------------------------------------------------
    
    public override void Interact(Player player)
    {
        if (player.KitchenObjectOnCounter)
        {
            if (player.KitchenObjectOnCounter.TryGetPlateKitchenObject(out PlateKitchenObject platerKitchenObject))
            {
                DeliveryManager.Instance.DeliverRecipe(platerKitchenObject);
                player.KitchenObjectOnCounter.DestroySelf();
            }
        }
    }
}
