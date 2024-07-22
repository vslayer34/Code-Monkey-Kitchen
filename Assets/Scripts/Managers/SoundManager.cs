using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the audio sfx reference SO")]
    private SO_AudioclipReferences _audioClipRef;



    // Game Loop Methods---------------------------------------------------------------------------
    private void Start()
    {
        DeliveryManager.Instance.OnOrderDelivered += DeliveryManager_OnOrderDelivered;
        DeliveryManager.Instance.OnOrderRejected += DeliveryManager_OnOrderRejected;
    }

    // Member Methods------------------------------------------------------------------------------

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1.0f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    private void PlaySound(AudioClip[] audioClipsList, Vector3 position, float volume = 1.0f)
    {
        PlaySound(audioClipsList[Random.Range(0, audioClipsList.Length)], position, volume);
    }

    // Signal Methods------------------------------------------------------------------------------

    private void DeliveryManager_OnOrderDelivered(object sender, EventArgs e)
    {
        PlaySound(_audioClipRef.SuccessfullDeliverySFX, DeliveryCounter.Instance.transform.position);       
    }

    private void DeliveryManager_OnOrderRejected(object sender, EventArgs e)
    {
        PlaySound(_audioClipRef.FailedDeliverySFX, DeliveryCounter.Instance.transform.position);
    }
}