using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [field: SerializeField, Tooltip("Reference to the this object stats")]
    public SO_KitchenObject KitchenObj { get; private set; }


    private IKitchenObjectParent _parentCounter;



    // Member Methods------------------------------------------------------------------------------

    public void SetParentCounter(IKitchenObjectParent clearCounter)
    {
        // Remove the old parent
        if (_parentCounter != null)
        {
            _parentCounter.KitchenObjectOnCounter = null;
        }

        // Make the new counter the new parent
        _parentCounter = clearCounter;
        _parentCounter.KitchenObjectOnCounter = this;

        transform.parent = _parentCounter.GetKitchenObjectPlacementPoint();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent GetParentCounter() => _parentCounter;

    public void DestroySelf()
    {
        GetParentCounter().KitchenObjectOnCounter = null;
        Destroy(gameObject);
    }

    public static KitchenObject SpawnNewKitchenObject(SO_KitchenObject kitchenObject, IKitchenObjectParent parent)
    {
        Transform newKitchenObjectTransform = Instantiate(kitchenObject.Prefab);
        KitchenObject createdKitchenObject = newKitchenObjectTransform.GetComponent<KitchenObject>();
        createdKitchenObject.SetParentCounter(parent);

        return createdKitchenObject;
    }

    public bool TryGetPlateKitchenObject(out PlateKitchenObject plate)
    {
        if (this is PlateKitchenObject)
        {
            plate = this as PlateKitchenObject;
            return true;
        }
        else
        {
            plate = null;
            return false;
        }
    }
}
