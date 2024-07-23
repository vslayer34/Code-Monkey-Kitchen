using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameClock : MonoBehaviour
{
    [SerializeField, Tooltip("The radial clock image")]
    private Image _radialTimer;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        _radialTimer.fillAmount = 1.0f;
    }

    private void Update()
    {
        _radialTimer.fillAmount = GameManager.Instance.PlayingTimeNormalized;
    }
}
