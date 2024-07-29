using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PauseMenu : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the resume button")]
    private Button _resumeBtn;

    [SerializeField, Tooltip("Reference to the main menu button")]
    private Button _mainMenuBtn;

    [SerializeField, Tooltip("Reference to the options button")]
    private Button _optionsBtn;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _resumeBtn.onClick.AddListener(() => 
        {
            GameManager.Instance.ToggleGamePause();
        });

        _mainMenuBtn.onClick.AddListener(() =>
        {
            Loader.LoadScene(SceneReference.MAIN_MENU);
        });

        _optionsBtn.onClick.AddListener(() =>
        {
            UI_OptionsMenu.Instance.Show();
        });
    }

    private void Start()
    {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameResumed += GameManager_OnGameResumed;

        Hide();
    }

    // Member Methods------------------------------------------------------------------------------

    /// <summary>
    /// Hide pause menu
    /// </summary>
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Show pause menu
    /// </summary>
    private void Show()
    {
        gameObject.SetActive(true);
    }

    // Signal Methods------------------------------------------------------------------------------

    private void GameManager_OnGamePaused(object sender, EventArgs e)
    {
        Show();
    }

    private void GameManager_OnGameResumed(object sender, EventArgs e)
    {
        Hide();
    }
}
