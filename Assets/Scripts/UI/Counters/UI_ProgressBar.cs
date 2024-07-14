using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ProgressBar : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the progress bar")]
    private Image _progressBar;


    [SerializeField, Tooltip("Reference to the parent cutting counter")]
    private CuttingCounter _cuttingCounter;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        _cuttingCounter.OnProgressBarUpdated += CuttingCounter_OnProgressBarUpdated;
        _progressBar.fillAmount = 0.0f;

        HideBar();
    }

    // Member Methods------------------------------------------------------------------------------
    private void ShowBar() => gameObject.SetActive(true);
    private void HideBar() => gameObject.SetActive(false);
    // Signal Methods------------------------------------------------------------------------------
    private void CuttingCounter_OnProgressBarUpdated(float progressAmount)
    {
        _progressBar.fillAmount = progressAmount;

        if (_progressBar.fillAmount == 0.0f || _progressBar.fillAmount == 1.0f)
        {
            HideBar();
        }
        else
        {
            ShowBar();
        }
    }
}
