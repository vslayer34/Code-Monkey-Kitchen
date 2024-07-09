using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisuals : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the parent counter")]
    private ClearCounter _parentClearCounter;

    [SerializeField, Tooltip("Reference to the selected highlight")]
    private GameObject _selectedHighlight;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += PlayerInstance_OnSelectedCounterChanged;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void PlayerInstance_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == _parentClearCounter)
        {
            _selectedHighlight.SetActive(true);
        }
        else
        {
            _selectedHighlight.SetActive(false);
        }
    }

    // Member Methods------------------------------------------------------------------------------

    private void ShowSelectionHighlight() => _selectedHighlight.SetActive(true);
    private void RemoveSelectionHighlight() => _selectedHighlight.SetActive(false);
}
