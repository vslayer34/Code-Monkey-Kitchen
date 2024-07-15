using System;
using UnityEngine;

public class PlateCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlatePickedUp;


    [SerializeField, Tooltip("Reference to the plate so")]
    private SO_KitchenObject _plateSO;
    private const float PLATE_SPAWN_TIME_INTERVAL = 4.0f;

    private float _spawnTimer = 0.0f;

    private int _currentSpawnedPLates = 0;
    public const int MAX_AMOUNT_OF_PLATES = 4;



    // Game Loop Methods---------------------------------------------------------------------------
    private void Update()
    {
        _spawnTimer += Time.deltaTime;


        if (_spawnTimer >= PLATE_SPAWN_TIME_INTERVAL)
        {
            _spawnTimer = 0.0f;

            if (_currentSpawnedPLates < MAX_AMOUNT_OF_PLATES)
            {
                _currentSpawnedPLates++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    // Memeber Methods-----------------------------------------------------------------------------

    public override void Interact(Player player)
    {
        if (!player.KitchenObjectOnCounter && _currentSpawnedPLates > 0)
        {
            _currentSpawnedPLates--;

            KitchenObject.SpawnNewKitchenObject(_plateSO, player);

            OnPlatePickedUp?.Invoke(this, EventArgs.Empty);
        }
    }
}
