using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }


    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAltAction;
    public event EventHandler OnPausePressed;

    private PlayerInputAction _playerInputAction;

    private Vector2 _inputVector;
    



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;

        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();

        _playerInputAction.Player.Interact.performed += Interact_performed;
        _playerInputAction.Player.InteractAlt.performed += InteractAlt_performed;
        _playerInputAction.Player.Pause.performed += Pause_Performed;
    }

    private void Update()
    {
        _inputVector = Vector2.zero;

        _inputVector = _playerInputAction.Player.Move.ReadValue<Vector2>();
    }

    private void OnDestroy()
    {
        _playerInputAction.Player.Interact.performed -= Interact_performed;
        _playerInputAction.Player.InteractAlt.performed -= InteractAlt_performed;
        _playerInputAction.Player.Pause.performed -= Pause_Performed;

        _playerInputAction.Dispose();
    }

    // Signal Methods------------------------------------------------------------------------------

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlt_performed(InputAction.CallbackContext obj)
    {
        OnInteractAltAction?.Invoke(this, EventArgs.Empty);
    }

    private void Pause_Performed(InputAction.CallbackContext ctx)
    {
        OnPausePressed?.Invoke(this, EventArgs.Empty);
    }

    // Getters and Setters-------------------------------------------------------------------------

    public Vector2 InputVectorNormalized { get => _inputVector.normalized; }
}
