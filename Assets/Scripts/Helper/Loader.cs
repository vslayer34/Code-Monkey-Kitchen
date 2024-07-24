using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private static int _targetScene;



    // Member Methods------------------------------------------------------------------------------

    public static void LoadScene(int sceneIndex)
    {
        _targetScene = sceneIndex;
        
        SceneManager.LoadScene(SceneReference.LOADING);
    }

    public static void LoaderCallback() => SceneManager.LoadScene(_targetScene);
}
