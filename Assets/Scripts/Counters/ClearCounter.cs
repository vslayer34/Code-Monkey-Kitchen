using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the placemont point on top of the counter")]
    private Transform _topPlacementPoint;

    [SerializeField, Tooltip("Reference to the tomato")]
    private SO_KitchenObject _kitchenObject;

    private KitchenObject _kitchenObjOnCounter;

    // Testing
    [SerializeField]
    private bool _testMode;

    [SerializeField]
    private ClearCounter _testCounter;



    // Member Methods------------------------------------------------------------------------------

    private void Update()
    {
        if (_testMode && Input.GetKeyDown(KeyCode.T))
        {
            if (_kitchenObjOnCounter != null)
            {
                _kitchenObjOnCounter.SetParentCounter(_testCounter);
            }
        }
    }

    public void Interact()
    {
        if (_kitchenObjOnCounter == null)
        {
            var newKitchenObject = Instantiate(_kitchenObject.Prefab, _topPlacementPoint);

            newKitchenObject.GetComponent<KitchenObject>().SetParentCounter(this);
        }
        else
        {
            Debug.Log(_kitchenObjOnCounter.GetParentCounter());
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
