using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSFX : MonoBehaviour
{
    private AudioSource _audioSource;
    private StoveCounter _parentStoveCounter;


    private const float MAX_WARNING_TIMER = 0.2f;
    private float _warningTimer = 0;
    private bool _playWarningSound;


    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _parentStoveCounter = GetComponentInParent<StoveCounter>();
    }

    private void Start()
    {
        _parentStoveCounter.OnStoveStateChanged += ParentStove_OnStoveStateChanged;
        _parentStoveCounter.OnProgressBarUpdated += ParentStove_OnProgressBarUpdated;
    }

    private void Update()
    {
        if (_playWarningSound)
        {
            _warningTimer -= Time.deltaTime;

            if (_warningTimer <= 0.0f)
            {
                _warningTimer = MAX_WARNING_TIMER;

                SoundManager.Instance.PlayWarning(_parentStoveCounter.transform.position);
            }
        }
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

    private void ParentStove_OnProgressBarUpdated(float barProgress)
    {
        float burningPrgressThreshold = 0.5f;
        _playWarningSound = _parentStoveCounter.IsInFriedState() && barProgress >= burningPrgressThreshold;
    }
}
