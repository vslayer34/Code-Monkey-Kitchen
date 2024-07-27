using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStaticData : MonoBehaviour
{
    private void Awake()
    {
        BaseCounter.ResetStaticEvents();
        CuttingCounter.ResetStaticEvents();
        TrashCounter.ResetStaticEvents();
    }
}
