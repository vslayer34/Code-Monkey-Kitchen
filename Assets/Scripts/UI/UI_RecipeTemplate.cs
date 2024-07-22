using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_RecipeTemplate : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the recipe title text")]
    private TextMeshProUGUI _recipeName;

    [SerializeField, Tooltip("Reference to the icon container")]
    private Transform _ingredientIconContainer;

    [SerializeField, Tooltip("Reference to the ingredient icon template")]
    private Image _ingredientIconTemplate;



    // Game Loop Methods---------------------------------------------------------------------------
    // Member Methods------------------------------------------------------------------------------

    public void UpdateTemplateInfo(SO_Recipe recipe)
    {
        foreach (Transform icon in _ingredientIconContainer)
        {
            if (icon == _ingredientIconTemplate.transform)
            {
                icon.gameObject.SetActive(false);
                continue;
            }

            Destroy(icon.gameObject);
        }

        _recipeName.text = recipe.RecipeName;

        foreach (var ingredient in recipe.RecipeIngredients)
        {
            var newIcon = Instantiate(_ingredientIconTemplate, _ingredientIconContainer);
            newIcon.gameObject.SetActive(true);
            newIcon.sprite = ingredient.Sprite;
        }
    }
}