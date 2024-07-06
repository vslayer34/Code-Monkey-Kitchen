using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private Vector2 _inputVector;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Update()
    {
        _inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _inputVector.y += 1.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _inputVector.y -= 1.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _inputVector.x += 1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _inputVector.x -= 1.0f;
        }
    }

    // Getters and Setters-------------------------------------------------------------------------

    public Vector2 InputVectorNormalized { get => _inputVector.normalized; }
}
