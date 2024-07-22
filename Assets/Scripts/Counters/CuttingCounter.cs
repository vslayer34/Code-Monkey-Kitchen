using System;
using UnityEngine;

public class CuttingCounter : BaseCounter, IHasProgressBar
{
    public static event EventHandler OnAnyCutting;
    public event Action<float> OnProgressBarUpdated;
    public event Action OnCut;


    [SerializeField, Tooltip("Referecne to the produced ingredient")]
    private SO_CuttingReciepe[] _cuttingReciepes;

    private int _cuttingProgress;



    // Member Methods------------------------------------------------------------------------------
    public override void Interact(Player player)
    {
        if (!IsKitchenObjectOnCounter())
        {
            // There is no object on top of the counter
            if (player.IsKitchenObjectOnCounter())
            {
                if (IsIngredientCuttable(player.KitchenObjectOnCounter.KitchenObj))
                {
                    // Drop the item if its cuttable
                    player.KitchenObjectOnCounter.SetParentCounter(this);
                    _cuttingProgress = 0;

                    // Update the UI
                    SO_CuttingReciepe cuttingRecipe = GetCuttingReciepe(KitchenObjectOnCounter.KitchenObj);
                    OnProgressBarUpdated?.Invoke(_cuttingProgress / (float)cuttingRecipe.CuttingStepsRequired);
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
                // Check if it's a plate
                if (player.KitchenObjectOnCounter.TryGetPlateKitchenObject(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(KitchenObjectOnCounter.KitchenObj))
                    {
                        KitchenObjectOnCounter.DestroySelf();
                    }
                }
            }
            else
            {
                // The player isn't carring anything
                // Give the item on counter to the player
                KitchenObjectOnCounter.SetParentCounter(player);
            }
        }
    }

    public override void InteractAlt(Player player)
    {
        // Only cut if there's in a kitchen object and is cuttable
        if (IsKitchenObjectOnCounter() && IsIngredientCuttable(KitchenObjectOnCounter.KitchenObj))
        {
            _cuttingProgress++;
            SO_CuttingReciepe cuttingRecipe = GetCuttingReciepe(KitchenObjectOnCounter.KitchenObj);

            // Update the UI and animations
            OnProgressBarUpdated?.Invoke(_cuttingProgress / (float)cuttingRecipe.CuttingStepsRequired);
            OnCut?.Invoke();
            OnAnyCutting?.Invoke(this, EventArgs.Empty);

            // Create the cut ingredients and destroy the raw one
            if (_cuttingProgress >= cuttingRecipe.CuttingStepsRequired)
            {
                SO_KitchenObject ingredient = GetRelatingOutput(KitchenObjectOnCounter.KitchenObj);
                KitchenObjectOnCounter.DestroySelf();

                KitchenObject.SpawnNewKitchenObject(ingredient, this);
            }
        }
    }

    
    private bool IsIngredientCuttable(SO_KitchenObject ingredient)
    {
        SO_CuttingReciepe cuttingRecipe = GetCuttingReciepe(ingredient);

        return cuttingRecipe != null;
    }


    private SO_KitchenObject GetRelatingOutput(SO_KitchenObject ingredient)
    {
        SO_CuttingReciepe cuttingRecipe = GetCuttingReciepe(ingredient);

        if (cuttingRecipe != null)
        {
            return cuttingRecipe.Output;
        }
        else
        {
            return null;
        }
    }

    private SO_CuttingReciepe GetCuttingReciepe(SO_KitchenObject ingredient)
    {
        foreach (var cuttingReciepe in _cuttingReciepes)
        {
            if (cuttingReciepe.Input == ingredient)
            {
                return cuttingReciepe;
            }
        }

        return null;
    }
}
