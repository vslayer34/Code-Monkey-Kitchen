using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[Serializable]
internal struct TutorialKeys
{
    public TextMeshProUGUI Key;
    public KeyBindings keyType;
}


public class UI_Tutorial : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the keys in the tutorial")]
    private List<TutorialKeys> _tutorialKeys;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        GameManager.Instance.OnStateChanged+= GameManager_OnStateChanged;
        GameInput.Instance.OnKeyBindingChanged += GameInput_OnKeyBindingChanged;    

        UpdateKeyBindings();
    }

    // Member Methods------------------------------------------------------------------------------
    private void UpdateKeyBindings()
    {
        foreach (var tutorialKey in _tutorialKeys)
        {
            tutorialKey.Key.text = GameInput.Instance.GetRespondingKeyBinding(tutorialKey.keyType);
        }
    }

    private void Show() => gameObject.SetActive(true);
    private void Hide() => gameObject.SetActive(false);
    // Signal Methods------------------------------------------------------------------------------

    private void GameInput_OnKeyBindingChanged(object sender, EventArgs e)
    {
        UpdateKeyBindings();
    }

    private void GameManager_OnStateChanged(object sender, GameManager.OnStateChangedEventArgs e)
    {
        if (e.state == GameManager.GameState.CountDownToStart)
        {
            Hide();
        }
    }
}
