using UnityEngine;


[CreateAssetMenu(fileName = "new frying receipe", menuName = "Kitchen Objects/Frying Recipe")]
public class SO_FryingReciepe : ScriptableObject
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
    /// Amount of time need for the ingredient to cook
    /// </summary>
    [field: SerializeField, Tooltip("Amount of time need for the ingredient to cook")]
    public int TimeRequiredToCook { get; private set; }
}