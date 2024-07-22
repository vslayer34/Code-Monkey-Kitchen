using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_CountdownHandler : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the timer text")]
    private TextMeshProUGUI _countdownText;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        Hide();
    }

    private void Update()
    {
        _countdownText.text = Mathf.Ceil(GameManager.Instance.CountdownToStartTimer).ToString("0");
    }

    // Member Methods------------------------------------------------------------------------------

    private void Show() => gameObject.SetActive(true);
    private void Hide() => gameObject.SetActive(false);

    // Signal Methods------------------------------------------------------------------------------

    private void GameManager_OnStateChanged(object sender, GameManager.OnStateChangedEventArgs e)
    {
        if (e.state == GameManager.GameState.CountDownToStart)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
}
