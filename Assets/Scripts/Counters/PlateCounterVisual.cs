using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounterVisual : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the parent plate counter")]
    private PlateCounter _platerCounter;

    [SerializeField, Tooltip("Reference to the counter top point")]
    private Transform _counterTopPoint;

    [SerializeField, Tooltip("Reference to the plate visuals prefab")]
    private Transform _plateVisual;


    // Keep track of the spawned plates visuals
    private List<Transform> _spawnedPlates;



    // Game Loop Methods---------------------------------------------------------------------------
    
    private void Start()
    {
        _spawnedPlates = new List<Transform>(PlateCounter.MAX_AMOUNT_OF_PLATES);

        _platerCounter.OnPlateSpawned += PlateCounter_OnPlateSpawned;
        _platerCounter.OnPlatePickedUp += PlateCounter_OnPlatePickedUp;
    }

    // Signal Methods------------------------------------------------------------------------------
    
    private void PlateCounter_OnPlateSpawned(object sender, EventArgs e)
    {
        Transform _newlySpawnedPlate = Instantiate(_plateVisual, _counterTopPoint);

        const float PLATE_OFFSET_Y = 0.1f;
        _newlySpawnedPlate.localPosition = new Vector3(0.0f, PLATE_OFFSET_Y * _spawnedPlates.Count, 0.0f);

        _spawnedPlates.Add(_newlySpawnedPlate);
    }

    private void PlateCounter_OnPlatePickedUp(object sender, EventArgs e)
    {
        Transform plate = _spawnedPlates[_spawnedPlates.Count - 1];
        _spawnedPlates.Remove(plate);

        Destroy(plate.gameObject);
    }
}
