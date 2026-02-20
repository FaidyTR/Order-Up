using System;
using UnityEngine;

public class PlateCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private float SpawnTimer = 0f;
    private float SpawnTimeMax = 4f; 
    private int PlatesSpawned  = 0;
    private int PlatesSpawnedMax = 4;

    public event EventHandler OnPlateSpawned; 
    public event EventHandler OnPlateRemoved;
    

    private void Update()
    {


        if (PlatesSpawned < PlatesSpawnedMax)
        {
            SpawnTimer += Time.deltaTime;
            if (SpawnTimer > SpawnTimeMax)
            {
                SpawnTimer = 0f;
                PlatesSpawned++;
                if (OnPlateSpawned != null)
                {
                    OnPlateSpawned(this, EventArgs.Empty);
                }
            }

        }
    }
    public override void Interact(IKitchenObjectParent player)
    {
        if (PlatesSpawned > 0)
        {
            if (!player.HasKitchenObject())
            {
                KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
                PlatesSpawned --;
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
