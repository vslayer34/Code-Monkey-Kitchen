using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new menu", menuName = "Menu")]
public class SO_RecipeList : ScriptableObject
{
    [field: SerializeField, Tooltip("Valid recipes fo orders")]
    public List<SO_Recipe> RecipeMenu {  get; private set; }
}
