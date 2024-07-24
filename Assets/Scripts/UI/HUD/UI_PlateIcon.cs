using UnityEngine;

public class UI_PlateIcon : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the parent plate")]
    private PlateKitchenObject _parentPlate;

    [SerializeField, Tooltip("Reference to the icon template")]
    private Transform _iconTemplate;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        _iconTemplate.gameObject.SetActive(false);
        _parentPlate.OnIngredientAdded += ParentPlate_OnIngredientAdded;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void ParentPlate_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        foreach (Transform child in transform)
        {
            if (child == _iconTemplate)
            {
                continue;
            }

            Destroy(child.gameObject);
        }


        foreach (var kitchenObjectSO in _parentPlate.PlateContents)
        {
            Transform iconTransform = Instantiate(_iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);

            iconTransform.GetComponent<UI_IconTemplate>().IconImage = kitchenObjectSO.Sprite;
        }
    }
}