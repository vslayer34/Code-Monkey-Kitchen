using System;
using UnityEngine;

public interface IHasProgressBar
{
    event Action<float> OnProgressBarUpdated;
}
