using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the parent cutting counter")]
    private CuttingCounter _cuttingCounter;

    private Animator _animator;



    // Game Loop Methods---------------------------------------------------------------------------
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _cuttingCounter.OnCut += CuttingCounter_OnCut;
    }
    // Signal Methods------------------------------------------------------------------------------

    private void CuttingCounter_OnCut()
    {
        _animator.SetTrigger(AnimationParameters.CuttingCounter.CUT);
    }
}
