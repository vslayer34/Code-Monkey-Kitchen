using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnKitchenObjectGrabbed;


    [SerializeField, Tooltip("Reference to the tomato")]
    private SO_KitchenObject _kitchenObject;

    //private KitchenObject _kitchenObjOnCounter;



    // Member Methods------------------------------------------------------------------------------
    public override void Interact(Player player)
    {
        //if (_kitchenObjOnCounter == null)
        if (!IsKitchenObjectOnCounter())
        {
            if (!player.IsKitchenObjectOnCounter())
            {
                // if the player hands is empty spawn new kitchen object
                var newKitchenObject = Instantiate(_kitchenObject.Prefab);

                newKitchenObject.GetComponent<KitchenObject>().SetParentCounter(player);
                OnKitchenObjectGrabbed?.Invoke(this, EventArgs.Empty);

            }
        }
    }
}
