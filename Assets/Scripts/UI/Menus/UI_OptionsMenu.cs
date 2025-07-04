using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_OptionsMenu : MonoBehaviour
{
    public Action OnOptionsMenuShowing;
    public static UI_OptionsMenu Instance { get; private set; }


    [SerializeField, Tooltip("Reference to the sound effects volume button")]
    private Button _sfxVolumeBtn;

    [SerializeField, Tooltip("Reference to the sound effects button text")]
    private TextMeshProUGUI _sfxVolumeBtnText;


    [SerializeField, Tooltip("Reference to the music volume button"), Space(10)]
    private Button _musicVolumeBtn;

    [SerializeField, Tooltip("Reference to the music button text")]
    private TextMeshProUGUI _musicVolumeBtnText;


    [SerializeField, Tooltip("Reference to the close button"), Space(10)]
    private Button _closeBtn;

    [SerializeField, Tooltip("Reference to the key binding ui"), Space(10)]
    private UI_KeyBindingGroup _keyBindingGroup;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;


        _sfxVolumeBtn.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateUI();
        });

        _musicVolumeBtn.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateUI();
        });

        _closeBtn.onClick.AddListener(() =>
        {
            Hide();
        });

        GameInput.Instance.OnPausePressed += GameInput_OnPausePressed;
        GameInput.Instance.OnKeyBindingChanged += GameInput_OnKeyBindingChanged;
    }

    private void Start()
    {
        UpdateUI();

        Hide();
    }

    // Memeber Methods-----------------------------------------------------------------------------

    public void Show(Action callback)
    {
        gameObject.SetActive(true);
        _sfxVolumeBtn.Select();
    }
    public void Hide() => gameObject.SetActive(false);

    private void UpdateUI()
    {
        _musicVolumeBtnText.text = $"Music: {Mathf.Ceil(MusicManager.Instance.VolumeDegree * 10.0f)}";
        _sfxVolumeBtnText.text = $"Sound Effects: {Mathf.Ceil(SoundManager.Instance.VolumeDegree * 10.0f)}";

        _keyBindingGroup.UpdateKeyBindingsUI();
        _keyBindingGroup.InitializeRebingBtns();
    }

    // Signal Methods------------------------------------------------------------------------------

    private void GameInput_OnPausePressed(object sender, EventArgs e)
    {
        Hide();
    }

    private void GameInput_OnKeyBindingChanged(object sender, EventArgs e)
    {
        UpdateUI();
    }
}
