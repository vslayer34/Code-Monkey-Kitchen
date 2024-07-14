using UnityEngine;


[CreateAssetMenu(fileName = "new burning receipe", menuName = "Kitchen Objects/Burning Recipe")]
public class SO_BurningReciepe : ScriptableObject
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



    /// <summary>
    /// Amount of time need for the ingredient to burn
    /// </summary>
    [field: SerializeField, Tooltip("Amount of time need for the ingredient to burn")]
    public int TimeRequiredToBurn { get; private set; }
}