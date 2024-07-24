using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool _firstUpdate = true;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Update()
    {
        if (_firstUpdate)
        {
            _firstUpdate = false;

            Loader.LoaderCallback();
        }
    }
}
