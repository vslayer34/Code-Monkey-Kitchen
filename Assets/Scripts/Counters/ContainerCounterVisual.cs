using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to ContainerCounterVisual")]
    private ContainerCounter _containerCounter;

    private Animator _animator;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _containerCounter.OnKitchenObjectGrabbed += ContainerCounter_OnKitchenObjectGrabbed;
    }

    private void ContainerCounter_OnKitchenObjectGrabbed(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(AnimationParameters.ContainerCounter.OPEN_CLOSE);
    }
}
