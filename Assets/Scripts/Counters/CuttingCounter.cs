using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField, Tooltip("Referecne to the produced ingredient")]
    private SO_KitchenObject _tomatoSlices;



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
        if (IsKitchenObjectOnCounter())
        {
            KitchenObjectOnCounter.DestroySelf();

            KitchenObject.SpawnNewKitchenObject(_tomatoSlices, this);
        }
    }
}
