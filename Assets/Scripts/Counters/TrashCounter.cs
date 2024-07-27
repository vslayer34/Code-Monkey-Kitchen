using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnAnyKitchenObjectTrashed;
    public override void Interact(Player player)
    {
        player.KitchenObjectOnCounter?.DestroySelf();
        OnAnyKitchenObjectTrashed?.Invoke(this, EventArgs.Empty);
    }

    new public static void ResetStaticEvents()
    {
        OnAnyKitchenObjectTrashed = null;
    }
}
