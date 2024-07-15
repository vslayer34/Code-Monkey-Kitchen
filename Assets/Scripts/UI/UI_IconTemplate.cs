using UnityEngine;
using UnityEngine.UI;

public class UI_IconTemplate : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the image component in the icon")]
    private Image _iconImage;


    // Getters and Setters-------------------------------------------------------------------------
    public Sprite IconImage
    {
        get => _iconImage.sprite;
        
        set
        {
            _iconImage.sprite = value;
        }
    }
}
