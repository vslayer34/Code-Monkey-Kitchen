using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [field: SerializeField, Tooltip("Reference to the this object stats")]
    public SO_KitchenObject KitchenObj { get; private set; }
}
