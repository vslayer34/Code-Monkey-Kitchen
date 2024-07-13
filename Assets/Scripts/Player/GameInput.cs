using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAltAction;

    private PlayerInputAction _playerInputAction;

    private Vector2 _inputVector;
    



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();

        _playerInputAction.Player.Interact.performed += Interact_performed;
        _playerInputAction.Player.InteractAlt.performed += InteractAlt_performed;
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

    private void InteractAlt_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAltAction?.Invoke(this, EventArgs.Empty);
    }

    // Getters and Setters-------------------------------------------------------------------------

    public Vector2 InputVectorNormalized { get => _inputVector.normalized; }
}
