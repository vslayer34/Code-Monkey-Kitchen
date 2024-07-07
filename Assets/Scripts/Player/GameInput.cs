using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputAction _playerInputAction;

    private Vector2 _inputVector;
    public event EventHandler OnInteractAction;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();

        _playerInputAction.Player.Interact.performed += Interact_performed;
    }

    private void Update()
    {
        _inputVector = Vector2.zero;

        _inputVector = _playerInputAction.Player.Move.ReadValue<Vector2>();
    }

    // Signal Methods------------------------------------------------------------------------------

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    // Getters and Setters-------------------------------------------------------------------------

    public Vector2 InputVectorNormalized { get => _inputVector.normalized; }
}
