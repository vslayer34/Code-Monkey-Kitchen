using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("Required Components")]
    [field: SerializeField, Tooltip("Reference to the game inout script")]
    public GameInput GameInput { get; private set; }

    [SerializeField, Tooltip("character movement speed")]
    private float moveSpeed = 7.0f;

    private bool _isWalking;



    // Game Loop Methods---------------------------------------------------------------------------
    private void Update()
    {
        Vector2 inputVector = GameInput.InputVectorNormalized;

        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        _isWalking = moveDirection != Vector3.zero;

        float rotationSpeed = 10.0f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }

    // Getters and Setters-------------------------------------------------------------------------

    public bool IsWalking { get => _isWalking;  }
}
