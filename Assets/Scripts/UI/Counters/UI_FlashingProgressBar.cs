using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FlashingProgressBar : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the parent store")]
    private StoveCounter _parentStove;

    private Animator _animator;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void Start()
    {
        _parentStove.OnProgressBarUpdated += StoveCounter_OnProgressBarUpdated;

        _animator.SetBool(AnimationParameters.GameUI.UI_FLASHING_PROGRESS_BAR, false);
    }

    // Member Methods------------------------------------------------------------------------------
    // Signal Methods------------------------------------------------------------------------------

    private void StoveCounter_OnProgressBarUpdated(float progress)
    {
        float warningProgress = 0.5f;
        bool show = (progress >= warningProgress) && _parentStove.IsInFriedState();

        _animator.SetBool(AnimationParameters.GameUI.UI_FLASHING_PROGRESS_BAR, show);
    }
}
