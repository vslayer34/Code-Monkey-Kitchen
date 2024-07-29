using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public enum KeyBindings
{
    MoveUp,
    MoveDown,
    MoveLeft,
    MoveRight,
    Interact,
    InteractAlt,
    Pause
}

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }


    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAltAction;
    public event EventHandler OnPausePressed;
    public event EventHandler OnKeyBindingChanged;

    private PlayerInputAction _playerInputAction;

    private Vector2 _inputVector;
    



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;

        _playerInputAction = new PlayerInputAction();

        if (PlayerPrefs.HasKey(PlayPrefConsts.KEY_BINDINGS_JSON))
        {
            _playerInputAction.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PlayPrefConsts.KEY_BINDINGS_JSON));
        }

        _playerInputAction.Player.Enable();

        _playerInputAction.Player.Interact.performed += Interact_performed;
        _playerInputAction.Player.InteractAlt.performed += InteractAlt_performed;
        _playerInputAction.Player.Pause.performed += Pause_Performed;
    }

    private void Update()
    {
        _inputVector = Vector2.zero;

        _inputVector = _playerInputAction.Player.Move.ReadValue<Vector2>();
    }

    private void OnDestroy()
    {
        _playerInputAction.Player.Interact.performed -= Interact_performed;
        _playerInputAction.Player.InteractAlt.performed -= InteractAlt_performed;
        _playerInputAction.Player.Pause.performed -= Pause_Performed;

        _playerInputAction.Dispose();
    }

    // Member Methods------------------------------------------------------------------------------

    public string GetRespondingKeyBinding(KeyBindings bindings)
    {
        switch (bindings)
        {
            case KeyBindings.MoveUp:
                return _playerInputAction.Player.Move.bindings[1].ToDisplayString();

            case KeyBindings.MoveDown:
                return _playerInputAction.Player.Move.bindings[2].ToDisplayString();
            
            case KeyBindings.MoveLeft:
                return _playerInputAction.Player.Move.bindings[3].ToDisplayString();
            
            case KeyBindings.MoveRight:
                return _playerInputAction.Player.Move.bindings[4].ToDisplayString();
            
            case KeyBindings.Interact:
                return _playerInputAction.Player.Interact.bindings[0].ToDisplayString();
            
            case KeyBindings.InteractAlt:
                return _playerInputAction.Player.InteractAlt.bindings[0].ToDisplayString();
            
            case KeyBindings.Pause:
                string displayString = _playerInputAction.Player.Pause.bindings[0].ToDisplayString();
                
                if (displayString == "Escape")
                {
                    return "Esc";
                }
                return displayString;
            
            default:
                return "Something Worng";
        }
    }

    public void RebindKey(KeyBindings bindings)
    {
        _playerInputAction.Disable();

        switch (bindings)
        {
            case KeyBindings.MoveUp:
                _playerInputAction.Player.Move.PerformInteractiveRebinding(1)
                .OnComplete((callback) => 
                {
                    callback.Dispose();
                    _playerInputAction.Enable();
                    OnKeyBindingChanged?.Invoke(this, EventArgs.Empty);

                    PlayerPrefs.SetString(PlayPrefConsts.KEY_BINDINGS_JSON, _playerInputAction.SaveBindingOverridesAsJson());
                    PlayerPrefs.Save();
                }).Start();
                break;

            case KeyBindings.MoveDown:
                _playerInputAction.Player.Move.PerformInteractiveRebinding(2)
                .OnComplete((callback) => 
                {
                    callback.Dispose();
                    _playerInputAction.Enable();
                    OnKeyBindingChanged?.Invoke(this, EventArgs.Empty);

                    PlayerPrefs.SetString(PlayPrefConsts.KEY_BINDINGS_JSON, _playerInputAction.SaveBindingOverridesAsJson());
                    PlayerPrefs.Save();
                }).Start();
                break;
            
            case KeyBindings.MoveLeft:
                _playerInputAction.Player.Move.PerformInteractiveRebinding(3)
                .OnComplete((callback) => 
                {
                    callback.Dispose();
                    _playerInputAction.Enable();
                    OnKeyBindingChanged?.Invoke(this, EventArgs.Empty);

                    PlayerPrefs.SetString(PlayPrefConsts.KEY_BINDINGS_JSON, _playerInputAction.SaveBindingOverridesAsJson());
                    PlayerPrefs.Save();
                }).Start();
                break;
            
            case KeyBindings.MoveRight:
                _playerInputAction.Player.Move.PerformInteractiveRebinding(4)
                .OnComplete((callback) => 
                {
                    callback.Dispose();
                    _playerInputAction.Enable();
                    OnKeyBindingChanged?.Invoke(this, EventArgs.Empty);

                    PlayerPrefs.SetString(PlayPrefConsts.KEY_BINDINGS_JSON, _playerInputAction.SaveBindingOverridesAsJson());
                    PlayerPrefs.Save();
                }).Start();
                break;
            
            case KeyBindings.Interact:
                _playerInputAction.Player.Interact.PerformInteractiveRebinding(0)
                .OnComplete((callback) => 
                {
                    callback.Dispose();
                    _playerInputAction.Enable();
                    OnKeyBindingChanged?.Invoke(this, EventArgs.Empty);

                    PlayerPrefs.SetString(PlayPrefConsts.KEY_BINDINGS_JSON, _playerInputAction.SaveBindingOverridesAsJson());
                    PlayerPrefs.Save();
                }).Start();
                break;
            
            case KeyBindings.InteractAlt:
                _playerInputAction.Player.InteractAlt.PerformInteractiveRebinding(0)
                .OnComplete((callback) => 
                {
                    callback.Dispose();
                    _playerInputAction.Enable();
                    OnKeyBindingChanged?.Invoke(this, EventArgs.Empty);

                    PlayerPrefs.SetString(PlayPrefConsts.KEY_BINDINGS_JSON, _playerInputAction.SaveBindingOverridesAsJson());
                    PlayerPrefs.Save();
                }).Start();
                break;
            
            case KeyBindings.Pause:
                _playerInputAction.Player.Pause.PerformInteractiveRebinding(0)
                .OnComplete((callback) => 
                {
                    callback.Dispose();
                    _playerInputAction.Enable();
                    OnKeyBindingChanged?.Invoke(this, EventArgs.Empty);

                    PlayerPrefs.SetString(PlayPrefConsts.KEY_BINDINGS_JSON, _playerInputAction.SaveBindingOverridesAsJson());
                    PlayerPrefs.Save();
                }).Start();
                break;
            
            default:
                Debug.LogError("Something Worng");
                break;
        }
    }

    // Signal Methods------------------------------------------------------------------------------

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlt_performed(InputAction.CallbackContext obj)
    {
        OnInteractAltAction?.Invoke(this, EventArgs.Empty);
    }

    private void Pause_Performed(InputAction.CallbackContext ctx)
    {
        OnPausePressed?.Invoke(this, EventArgs.Empty);
    }

    // Getters and Setters-------------------------------------------------------------------------

    public Vector2 InputVectorNormalized { get => _inputVector.normalized; }
}
