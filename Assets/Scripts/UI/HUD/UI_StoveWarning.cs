using System;
using UnityEngine;

public class UI_StoveWarning : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the parent store")]
    private StoveCounter _parentStove;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        _parentStove.OnProgressBarUpdated += StoveCounter_OnProgressBarUpdated;

        Hide();
    }

    // Member Methods------------------------------------------------------------------------------
    private void Hide() => gameObject.SetActive(false);
    private void Show() => gameObject.SetActive(true);
    // Signal Methods------------------------------------------------------------------------------

    private void StoveCounter_OnProgressBarUpdated(float progress)
    {
        float warningProgress = 0.5f;
        bool show = (progress >= warningProgress) && _parentStove.IsInFriedState();

        if (show)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
}