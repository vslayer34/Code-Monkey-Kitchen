using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the placemont point on top of the counter")]
    private Transform _topPlacementPoint;

    [SerializeField, Tooltip("Reference to the tomato")]
    private SO_KitchenObject _kitchenObject;



    // Member Methods------------------------------------------------------------------------------
    public void Interact()
    {
        var newKitchenObject = Instantiate(_kitchenObject.Prefab, _topPlacementPoint);
        newKitchenObject.localPosition = Vector3.zero;

        Debug.Log($"Spawned {newKitchenObject.GetComponent<KitchenObject>().KitchenObj.name}");
    }
}
