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
