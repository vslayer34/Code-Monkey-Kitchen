using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    KitchenObject KitchenObjectOnCounter {  get; set; }

    bool IsKitchenObjectOnCounter();
    Transform GetKitchenObjectPlacementPoint();
}
