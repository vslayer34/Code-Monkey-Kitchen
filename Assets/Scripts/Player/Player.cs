using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    public static Player Instance { get; private set; }


    /// <summary>
    /// Invoked when the selected counter change
    /// </summary>
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }


    [field: Header("Required Components")]
    [field: SerializeField, Tooltip("Reference to the game inout script")]
    public GameInput GameInput { get; private set; }

    [SerializeField, Tooltip("character movement speed")]
    private float moveSpeed = 7.0f;

    private bool _isWalking;

    private const float PLAYER_RADIUS = 0.7f;
    private const float PLAyER_HEIGHT = 2.0f;

    // Interactions
    [Header("Interactables"), SerializeField, Tooltip("Layer mask of interactable objects")]
    private LayerMask _counterLayeerMask;

    private const float INTERACTION_DISTANCE = 2.0f;
    private Vector3 _interactionDirection;
    private Vector3 _lastInteractDirection;

    private BaseCounter _selectedCounter;

    private KitchenObject _kitchenObjInHand;

    [SerializeField, Tooltip("Reference to the placemont point on top of the counter")]
    private Transform _KitchenObjectHoldPoint;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one player in the scen!");
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        GameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    // Member Methods------------------------------------------------------------------------------

    private void HandleInteractions()
    {
        if (_interactionDirection != Vector3.zero)
        {
            _lastInteractDirection = _interactionDirection;
        }

        if (Physics.Raycast(transform.position, _lastInteractDirection, out RaycastHit hit, INTERACTION_DISTANCE, _counterLayeerMask))
        {
            if (hit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                // Check if another counter than previously highlighted one
                if (_selectedCounter != baseCounter)
                {
                    SetClearCounter(baseCounter);
                }
            }
            else
            {
                SetClearCounter(null);
            }
        }
        else
        {
            SetClearCounter(null);
        }
    }

    /// <summary>
    /// Handle the player character movement and collisions
    /// </summary>
    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.InputVectorNormalized;
        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);

        _interactionDirection = moveDirection;

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

    /// <summary>
    /// Set the newly selected counter or reset the counter
    /// Fire the event for visual updates on the counter
    /// </summary>
    /// <param name="baseCounter"></param>
    private void SetClearCounter(BaseCounter baseCounter)
    {
        _selectedCounter = baseCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = baseCounter
        });
    }

    // Signal Methods------------------------------------------------------------------------------

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        //HandleInteractions();
        if (_selectedCounter != null)
        {
            _selectedCounter.Interact(this);
        }
    }

    public Transform GetKitchenObjectPlacementPoint()
    {
        return _KitchenObjectHoldPoint;
    }

    public bool IsKitchenObjectOnCounter() => _kitchenObjInHand != null;

    // Getters and Setters-------------------------------------------------------------------------

    public bool IsWalking { get => _isWalking;  }
    public KitchenObject KitchenObjectOnCounter
    {
        get => _kitchenObjInHand;
        set
        {
            if (!IsKitchenObjectOnCounter() || value == null)
            {
                _kitchenObjInHand = value;
            }
            else
            {
                Debug.LogError("There is an object already on the counter");
            }
        }
    }
}
