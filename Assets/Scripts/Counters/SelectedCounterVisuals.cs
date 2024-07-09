using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectedCounterVisuals : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the parent counter")]
    private BaseCounter _parentBaseCounter;

    [SerializeField, Tooltip("Reference to the selected highlight")]
    private GameObject[] _selectedHighlightVisual;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += PlayerInstance_OnSelectedCounterChanged;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void PlayerInstance_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == _parentBaseCounter)
        {
            ShowSelectionHighlight();
        }
        else
        {
            //_selectedHighlight.SetActive(false);
            RemoveSelectionHighlight();
        }
    }

    // Member Methods------------------------------------------------------------------------------

    private void ShowSelectionHighlight()
    {
        foreach (var visual in _selectedHighlightVisual)
        {
            visual.SetActive(true);
        }
    }
    private void RemoveSelectionHighlight()
    {
        foreach (var visual in _selectedHighlightVisual)
        {
            visual.SetActive(false);
        }
    }
}
