using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [field: SerializeField, Tooltip("Reference to the player controller")]
    public Player PlayerScript { get; private set; }

    private Animator _animator;



    // Game Loop Methods---------------------------------------------------------------------------


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(AnimationParameters.Player.IS_WALKING, PlayerScript.IsWalking);
    }
}
