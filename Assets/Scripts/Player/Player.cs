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

    private const float PLAYER_RADIUS = 0.7f;
    private const float PLAyER_HEIGHT = 2.0f;



    // Game Loop Methods---------------------------------------------------------------------------
    private void Update()
    {
        Vector2 inputVector = GameInput.InputVectorNormalized;
        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(
            transform.position, 
            transform.position + Vector3.up * PLAyER_HEIGHT, 
            PLAYER_RADIUS, 
            moveDirection, 
            moveDistance
        );

        if (!canMove)
        {
            // Cannot move in that direction
            // Attempt moving in the x drection
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0.0f, 0.0f);

            canMove = !Physics.CapsuleCast(
                transform.position,
                transform.position + Vector3.up * PLAyER_HEIGHT,
                PLAYER_RADIUS,
                moveDirectionX,
                moveDistance
            );

            if (canMove)
            {
                // move along the x axis
                moveDirection = moveDirectionX;
            }
            else
            {
                // can't move in the x axis
                // Attempt moving in the z axis
                Vector3 moveDirectionZ = new Vector3(0.0f, 0.0f, moveDirection.z);

                canMove = !Physics.CapsuleCast(
                    transform.position,
                    transform.position + Vector3.up * PLAyER_HEIGHT,
                    PLAYER_RADIUS,
                    moveDirectionZ,
                    moveDistance
                );

                if (canMove)
                {
                    // Move along the z axis
                    moveDirection = moveDirectionZ;
                }
                else
                {
                    // Can't move at all
                }
            }

        }

        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        // For animations
        _isWalking = moveDirection != Vector3.zero;

        float rotationSpeed = 10.0f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }

    // Getters and Setters-------------------------------------------------------------------------

    public bool IsWalking { get => _isWalking;  }
}
