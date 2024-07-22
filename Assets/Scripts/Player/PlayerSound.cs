using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public static event EventHandler OnPlayerWaliking;


    
    // Member Methods------------------------------------------------------------------------------

    public void PlaySound()
    {
        OnPlayerWaliking?.Invoke(this, EventArgs.Empty);
    }
}
