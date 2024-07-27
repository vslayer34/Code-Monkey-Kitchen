using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    private AudioSource _audioSource;
    private float _volumeDegree = 0.4f;



    // Game Loop Methods---------------------------------------------------------------------------
    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }
    // Member Methods------------------------------------------------------------------------------
    public void ChangeVolume()
    {
        _volumeDegree += 0.1f;

        if (_volumeDegree > 1.0f)
        {
            _volumeDegree = 0.0f;
        }

        _audioSource.volume = _volumeDegree;
    }
    // Getters & Setters---------------------------------------------------------------------------

    public float VolumeDegree { get => _volumeDegree; }
}
