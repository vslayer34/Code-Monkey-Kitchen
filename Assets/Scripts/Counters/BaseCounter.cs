using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    public static event EventHandler OnAnyObjectPlacedOnCounter;

    [SerializeField, Tooltip("Reference to the placemont point on top of the counter")]
    protected Transform _topPlacementPoint;

    private KitchenObject _kitchenObjOnCounter;

    public virtual void Interact(Player player) { }
    public virtual void InteractAlt(Player player) { }



    // Member Methods------------------------------------------------------------------------------
    
    public static void ResetStaticEvents()
    {
        OnAnyObjectPlacedOnCounter = null;
    }

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

                if (_kitchenObjOnCounter != null)
                {
                    OnAnyObjectPlacedOnCounter?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                Debug.LogError("There is an object already on the counter");
            }
        }
    }
}
