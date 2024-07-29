using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
internal struct KeyBindingGroup
{
    public KeyBindings respondingAction;
    public Button keyBtn;
    public TextMeshProUGUI keyString;
}

public class UI_KeyBindingGroup : MonoBehaviour
{
    [SerializeField, Tooltip("The list containing button text pair for key bindings")]   
    private List<KeyBindingGroup> _keyBindingGroup;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        // UpdateKeyBindingsUI();
    }
    // Member Methods------------------------------------------------------------------------------

    public void UpdateKeyBindingsUI()
    {
        foreach (var keyBindingPair in _keyBindingGroup)
        {
            // Debug.Log(_keyBindingGroup.Count);
            // Debug.Log(keyBindingPair.respondingAction);
            // Debug.Log(keyBindingPair.keyBtn);
            // Debug.Log(keyBindingPair.keyString);
            keyBindingPair.keyString.text = GameInput.Instance.GetRespondingKeyBinding(keyBindingPair.respondingAction);

            // Debug.Log(GameInput.Instance.GetRespondingKeyBinding(keyBindingPair.respondingAction));
        }
    }

    public void InitializeRebingBtns()
    {
        foreach (var keyPair in _keyBindingGroup)
        {
            keyPair.keyBtn.onClick.AddListener(() =>
            {
                keyPair.keyString.text = "...";
                GameInput.Instance.RebindKey(keyPair.respondingAction);
            });
        }
    }
}