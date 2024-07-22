using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSFX : MonoBehaviour
{
    private AudioSource _audioSource;
    private StoveCounter _parentStoveCounter;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _parentStoveCounter = GetComponentInParent<StoveCounter>();
    }

    private void Start()
    {
        _parentStoveCounter.OnStoveStateChanged += ParentStove_OnStoveStateChanged;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void ParentStove_OnStoveStateChanged(object sender, StoveCounter.OnStoveStateChangedEventArgs e)
    {
        bool playSound = e.state == State.Frying || e.state == State.Fried || e.state == State.Burned;

        if (playSound)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Pause();
        }
    }
}
