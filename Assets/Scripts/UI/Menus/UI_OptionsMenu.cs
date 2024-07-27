using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OptionsMenu : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the sound effects volume button")]
    private Button _sfxVolumeBtn;

    [SerializeField, Tooltip("Reference to the sound effects button text")]
    private TextMeshProUGUI _sfxVolumeBtnText;

    [SerializeField, Tooltip("Reference to the music volume button"), Space(10)]
    private Button _musicVolumeBtn;

    [SerializeField, Tooltip("Reference to the music button text")]
    private TextMeshProUGUI _musicVolumeBtnText;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
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
    }

    private void Start()
    {
        UpdateUI();
    }

    // Memeber Methods-----------------------------------------------------------------------------

    private void UpdateUI()
    {
        _musicVolumeBtnText.text = $"Music: {Mathf.Ceil(MusicManager.Instance.VolumeDegree * 10.0f)}";
        _sfxVolumeBtnText.text = $"Sound Effects: {Mathf.Ceil(SoundManager.Instance.VolumeDegree * 10.0f)}";
    }
}
