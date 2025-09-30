using System;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnObjectTrashed;

    new public static void ResetStaticData()
    {
        OnObjectTrashed = null;
    }
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();

            OnObjectTrashed?.Invoke(this, EventArgs.Empty);
        }
    }
}
