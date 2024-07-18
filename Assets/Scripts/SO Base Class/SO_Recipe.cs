using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new recipe", menuName = "Final Recipes/Recipe")]
public class SO_Recipe : ScriptableObject
{
    /// <summary>
    /// The name of the recipe
    /// </summary>
    [field: SerializeField, Tooltip("The name of the recipe")]
    public string RecipeName { get; private set; }



    /// <summary>
    /// List of the ingredients used to make said recipe
    /// </summary>
    [field: SerializeField, Tooltip("List of the ingredients used to make said recipe")]
    public List<SO_KitchenObject> RecipeIngredients { get; private set; }
}
