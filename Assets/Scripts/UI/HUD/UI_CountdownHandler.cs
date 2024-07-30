using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_CountdownHandler : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the timer text")]
    private TextMeshProUGUI _countdownText;

    private int _currentCountDownNum;
    private Animator _animator;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        Hide();
    }

    private void Update()
    {
        int countDownNumber = Mathf.CeilToInt(GameManager.Instance.CountdownToStartTimer);
        _countdownText.text = countDownNumber.ToString();

        if (_currentCountDownNum != countDownNumber)
        {
            _currentCountDownNum = countDownNumber;
            _animator.SetTrigger(AnimationParameters.GameUI.UI_COUNT_TIME);
            SoundManager.Instance.PlayWarning();
        }
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
