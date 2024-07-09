using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new kitchen object", menuName = "Kitchen Objects")]
public class SO_KitchenObject : ScriptableObject
{
    /// <summary>
    /// The object prefab
    /// </summary>
    [field: SerializeField, Tooltip("The object prefab")]
    public Transform Prefab { get; private set; }


    /// <summary>
    /// The object UI sprite
    /// </summary>
    [field: SerializeField, Tooltip("The object UI sprite")]
    public Sprite Sprite { get; private set; }


    /// <summary>
    /// The object name
    /// </summary>
    [field: SerializeField, Tooltip("The object name")]
    public string Name { get; private set; }
}
