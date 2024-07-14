using UnityEngine;

internal enum State
{
    Idle,
    Frying,
    Fried,
    Burned
}

public class StoveCounter : BaseCounter
{
    [SerializeField, Tooltip("Reference to the frying recipes")]
    private SO_FryingReciepe[] _fryingRecipes;

    private SO_FryingReciepe _fryingRecipe;
    private float _fryingTimer;

    private State _state;



    // Game Loop Methods---------------------------------------------------------------------------
    
    private void Start()
    {
        _state = State.Idle;
    }
    
    private void Update()
    {
        if (IsKitchenObjectOnCounter())
        {
            switch (_state)
            {
                case State.Idle:
                    break;
                
                case State.Frying:
                    _fryingTimer += Time.deltaTime;
            
                    // Frying the meat
                    if (_fryingTimer >= _fryingRecipe.TimeRequiredToCook)
                    {
                        _fryingTimer = 0.0f;

                        KitchenObjectOnCounter.DestroySelf();

                        KitchenObject.SpawnNewKitchenObject(_fryingRecipe.Output, this);

                        _state = State.Fried;
                    }
                    break;

                case State.Fried:
                    break;
                
                case State.Burned:
                    break;
                
                default:
                    Debug.LogError("There's no such state for the stove");
                    break;
            }
        }
        Debug.Log($"Current stove state: {_state}");
    }
    // Member Methods------------------------------------------------------------------------------

    public override void Interact(Player player)
    {
        if (!IsKitchenObjectOnCounter())
        {
            // There is no object on top of the counter
            if (player.IsKitchenObjectOnCounter())
            {
                if (IsIngredientFryable(player.KitchenObjectOnCounter.KitchenObj))
                {
                    // Drop the item if its cuttable
                    player.KitchenObjectOnCounter.SetParentCounter(this);

                    _fryingRecipe = GetFryingReciepe(KitchenObjectOnCounter.KitchenObj);

                    _fryingTimer = 0.0f;
                    _state = State.Frying;
                }
            }
            else
            {
                // The player isn't carring anything
            }
        }
        else
        {
            // There is a kitchen object on top of the counter
            if (player.IsKitchenObjectOnCounter())
            {
                // The player is carring something
            }
            else
            {
                // The player isn't carring anything
                // Give the item on counter to the player
                KitchenObjectOnCounter.SetParentCounter(player);
            }
        }
    }


    private bool IsIngredientFryable(SO_KitchenObject ingredient)
    {
        SO_FryingReciepe fryingRecipe = GetFryingReciepe(ingredient);

        return fryingRecipe != null;
    }


    private SO_KitchenObject GetRelatingOutput(SO_KitchenObject ingredient)
    {
        SO_FryingReciepe fryingRecipe = GetFryingReciepe(ingredient);

        if (fryingRecipe != null)
        {
            return fryingRecipe.Output;
        }
        else
        {
            return null;
        }
    }

    private SO_FryingReciepe GetFryingReciepe(SO_KitchenObject ingredient)
    {
        foreach (var fryingReciepe in _fryingRecipes)
        {
            if (fryingReciepe.Input == ingredient)
            {
                return fryingReciepe;
            }
        }

        return null;
    }
}