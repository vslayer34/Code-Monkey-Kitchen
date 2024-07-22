using UnityEngine;

[CreateAssetMenu(fileName = "new auido clip reference", menuName = "Assets References/New Audio Reference")]
public class SO_AudioclipReferences : ScriptableObject
{
    /// <summary>
    /// Reference to chop sound
    /// </summary>
    [field: SerializeField, Tooltip("Reference to chop sound")]
    public AudioClip[] ChopSFX { get; private set; }


    /// <summary>
    /// Reference to failed delivery sound
    /// </summary>
    [field: SerializeField, Tooltip("Reference to failed delivery sound")]
    public AudioClip[] FailedDeliverySFX { get; private set; }


    /// <summary>
    /// Reference to successful delivery sound
    /// </summary>
    [field: SerializeField, Tooltip("Reference to successful delivery sound")]
    public AudioClip[] SuccessfullDeliverySFX { get; private set; }


    /// <summary>
    /// Reference to footstep sound
    /// </summary>
    [field: SerializeField, Tooltip("Reference to footstep sound")]
    public AudioClip[] FootStepSFX { get; private set; }


    /// <summary>
    /// Reference to dropped object sound
    /// </summary>
    [field: SerializeField, Tooltip("Reference to dropped object sound")]
    public AudioClip[] DroppedObjectSFX { get; private set; }


    /// <summary>
    /// Reference to picked up object sound
    /// </summary>
    [field: SerializeField, Tooltip("Reference to picked up object sound")]
    public AudioClip[] PickedUpObjectSFX { get; private set; }


    /// <summary>
    /// Reference to pan sizzle sound
    /// </summary>
    [field: SerializeField, Tooltip("Reference to pan sizzle sound")]
    public AudioClip PanSizzleSFX { get; private set; }


    /// <summary>
    /// Reference to trash interaction sound
    /// </summary>
    [field: SerializeField, Tooltip("Reference to trash interaction sound")]
    public AudioClip[] TrashedObjectSFX { get; private set; }
    

    /// <summary>
    /// Reference to warning sound
    /// </summary>
    [field: SerializeField, Tooltip("Reference to warning sound")]
    public AudioClip[] WarnningSFX { get; private set; }
}
