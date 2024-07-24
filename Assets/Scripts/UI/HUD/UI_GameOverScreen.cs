using TMPro;
using UnityEngine;

public class UI_GameOverScreen : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the recipe amount text")]
    private TextMeshProUGUI _recipeAmount;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        GameManager.Instance.OnStateChanged += DeliveryManager_OnStateChanged;
        Hide();
    }

    // Member Methods------------------------------------------------------------------------------

    private void Show() => gameObject.SetActive(true);
    private void Hide() => gameObject.SetActive(false);

    // Signal Methods------------------------------------------------------------------------------

    private void DeliveryManager_OnStateChanged(object sender, GameManager.OnStateChangedEventArgs e)
    {
        if (e.state == GameManager.GameState.GameOver)
        {
            Show();
            _recipeAmount.text = DeliveryManager.Instance.OrderedDelivered.ToString();
        }
        else
        {
            Hide();
        }
    }
}
