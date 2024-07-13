using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new cutting receipe", menuName = "Kitchen Objects/Cutting Ingredient")]
public class SO_CuttingReciepe : ScriptableObject
{
    /// <summary>
    /// Input ingredient
    /// </summary>
    [field: SerializeField, Tooltip("Input ingredient")]
    public SO_KitchenObject Input { get; private set; }



    /// <summary>
    /// Produced ingredient
    /// </summary>
    [field: SerializeField, Tooltip("Produced ingredient")]
    public SO_KitchenObject Output { get; private set; }

}
