using System;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
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

            OnProgressBarUpdated?.Invoke(_cuttingProgress / (float)cuttingRecipe.CuttingStepsRequired);
            OnCut?.Invoke();

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
