using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public static DeliveryCounter Instance { get; private set; }



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;
    }
    
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
