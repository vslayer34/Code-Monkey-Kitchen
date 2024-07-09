using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField, Tooltip("Reference to the placemont point on top of the counter")]
    protected Transform _topPlacementPoint;

    private KitchenObject _kitchenObjOnCounter;

    public virtual void Interact(Player player) { }



    public Transform GetKitchenObjectPlacementPoint()
    {
        return _topPlacementPoint;
    }

    public bool IsKitchenObjectOnCounter() => _kitchenObjOnCounter != null;

    // Getters & Setters---------------------------------------------------------------------------

    public KitchenObject KitchenObjectOnCounter
    {
        get => _kitchenObjOnCounter;
        set
        {
            if (!IsKitchenObjectOnCounter() || value == null)
            {
                _kitchenObjOnCounter = value;
            }
            else
            {
                Debug.LogError("There is an object already on the counter");
            }
        }
    }
}
