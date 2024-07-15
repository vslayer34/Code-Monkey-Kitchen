using System;
using UnityEngine;

public enum State
{
    Idle,
    Frying,
    Fried,
    Burned
}

public class StoveCounter : BaseCounter, IHasProgressBar
{
    public event EventHandler<OnStoveStateChangedEventArgs> OnStoveStateChanged;
    public event Action<float> OnProgressBarUpdated;

    public class OnStoveStateChangedEventArgs : EventArgs
    {
        public State state;
    }

    [SerializeField, Tooltip("Reference to the frying recipes")]
    private SO_FryingReciepe[] _fryingRecipes;

    [SerializeField, Tooltip("Reference to the frying recipes")]
    private SO_BurningReciepe[] _burningRecipes;

    private SO_FryingReciepe _fryingRecipe;
    private SO_BurningReciepe _burningRecipe;

    private float _fryingTimer;
    private float _burningTimer;

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

                    OnProgressBarUpdated?.Invoke(_fryingTimer / _fryingRecipe.TimeRequiredToCook);
            
                    // Frying the meat
                    if (_fryingTimer >= _fryingRecipe.TimeRequiredToCook)
                    {
                        _fryingTimer = 0.0f;

                        KitchenObjectOnCounter.DestroySelf();

                        KitchenObject.SpawnNewKitchenObject(_fryingRecipe.Output, this);

                        _state = State.Fried;

                        OnStoveStateChanged?.Invoke(this, new OnStoveStateChangedEventArgs
                        {
                            state = _state
                        });

                        _burningRecipe = GetBurningReciepe(_fryingRecipe.Output);
                    }
                    break;

                case State.Fried:

                    _burningTimer += Time.deltaTime;

                    OnProgressBarUpdated?.Invoke(_burningTimer / _burningRecipe.TimeRequiredToBurn);
            
                    // Frying the meat
                    if (_burningTimer >= _burningRecipe.TimeRequiredToBurn)
                    {
                        _burningTimer = 0.0f;

                        KitchenObjectOnCounter.DestroySelf();

                        KitchenObject.SpawnNewKitchenObject(_burningRecipe.Output, this);

                        _state = State.Burned;

                        OnStoveStateChanged?.Invoke(this, new OnStoveStateChangedEventArgs
                        {
                            state = _state
                        });
                    }

                    break;

                
                case State.Burned:
                    OnProgressBarUpdated?.Invoke(0.0f);
                    break;
                
                default:
                    Debug.LogError("There's no such state for the stove");
                    break;
            }
        }
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

                    OnStoveStateChanged?.Invoke(this, new OnStoveStateChangedEventArgs
                    {
                        state = _state
                    });

                    OnProgressBarUpdated?.Invoke(_fryingTimer / _fryingRecipe.TimeRequiredToCook);
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

                _state = State.Idle;

                OnStoveStateChanged?.Invoke(this, new OnStoveStateChangedEventArgs
                {
                    state = _state
                });

                OnProgressBarUpdated?.Invoke(0.0f);
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


    private SO_BurningReciepe GetBurningReciepe(SO_KitchenObject ingredient)
    {
        foreach (var burningReciepe in _burningRecipes)
        {
            if (burningReciepe.Input == ingredient)
            {
                return burningReciepe;
            }
        }

        return null;
    }
}