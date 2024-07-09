using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField, Tooltip("Reference to the placemont point on top of the counter")]
    private Transform _topPlacementPoint;

    [SerializeField, Tooltip("Reference to the tomato")]
    private SO_KitchenObject _kitchenObject;

    private KitchenObject _kitchenObjOnCounter;



    // Member Methods------------------------------------------------------------------------------
    public void Interact(Player player)
    {
        if (_kitchenObjOnCounter == null)
        {
            var newKitchenObject = Instantiate(_kitchenObject.Prefab, _topPlacementPoint);

            newKitchenObject.GetComponent<KitchenObject>().SetParentCounter(this);
        }
        else
        {
            _kitchenObjOnCounter.GetComponent<KitchenObject>().SetParentCounter(player);
        }
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
            }
            else
            {
                Debug.LogError("There is an object already on the counter");
            }
        }
    }
}
