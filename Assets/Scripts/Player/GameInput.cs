using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputAction _playerInputAction;

    private Vector2 _inputVector;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();
    }

    private void Update()
    {
        _inputVector = Vector2.zero;

        _inputVector = _playerInputAction.Player.Move.ReadValue<Vector2>();
    }

    // Getters and Setters-------------------------------------------------------------------------

    public Vector2 InputVectorNormalized { get => _inputVector.normalized; }
}
