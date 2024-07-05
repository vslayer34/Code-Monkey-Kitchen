using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("character movement speed")]
    private float moveSpeed = 7.0f;



    // Game Loop Methods---------------------------------------------------------------------------
    private void Update()
    {
        Vector2 inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1.0f;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float rotationSpeed = 10.0f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }
}
