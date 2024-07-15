using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisuals : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the parent stove counter")]
    private StoveCounter _stoveCounter;

    [SerializeField, Tooltip("Reference to the particle gameobject")]
    private GameObject _particleVFX;

    [SerializeField, Tooltip("Reference to the stove heat effect gameobject")]
    private GameObject _heatVFX;



    // Game Loop Methods---------------------------------------------------------------------------
    private void Start()
    {
        _stoveCounter.OnStoveStateChanged += StoveCounter_OnStoveStateChanged;
    }
    // Signal Methods------------------------------------------------------------------------------

    private void StoveCounter_OnStoveStateChanged(object sender, StoveCounter.OnStoveStateChangedEventArgs e)
    {
        bool showVisuals = e.state == State.Frying || e.state == State.Fried;

        _particleVFX.SetActive(showVisuals);
        _heatVFX.SetActive(showVisuals);

        if (e.state == State.Burned)
        {
            _particleVFX.SetActive(false);
            _heatVFX.SetActive(true);
        }
    }
}
