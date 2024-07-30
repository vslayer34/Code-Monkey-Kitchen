using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameResumed;

    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public GameState state;
    }

    public static GameManager Instance { get; private set; }
    public enum GameState
    {
        WaitingToStart,
        CountDownToStart,
        Playing,
        GameOver
    }

    private GameState _currentGameState;

    // Timers for the game state
    private float _waitingToStartTimer = 1.0f;
    private float _countDownToStartTimer = 3.0f;
    private float _playingTimer;
    private const float ROUND_TIME = 20.0f;


    // Pause game
    private bool _gamePaused = false;



    // Game Lopp Methods---------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;
        _currentGameState = GameState.WaitingToStart;
    }

    private void Start()
    {
        GameInput.Instance.OnPausePressed += GameInput_OnPausePressed;
        GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
    }

    private void Update()
    {
        switch (_currentGameState)
        {
            case GameState.WaitingToStart:
                
                // _waitingToStartTimer -= Time.deltaTime;
                // _playingTimer = ROUND_TIME;

                // if (_waitingToStartTimer <= 0.0f)
                // {
                //     _playingTimer = ROUND_TIME;
                //     _currentGameState = GameState.CountDownToStart;
                // }

                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs{ state = _currentGameState });
                break;
            
            case GameState.CountDownToStart:

                _countDownToStartTimer -= Time.deltaTime;

                if (_countDownToStartTimer <= 0.0f)
                {
                    _currentGameState = GameState.Playing;
                }
                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs{ state = _currentGameState });

                break;
            
            case GameState.Playing:

                _playingTimer -= Time.deltaTime;

                if (_playingTimer <= 0.0f)
                {
                    _currentGameState = GameState.GameOver;
                }
                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs{ state = _currentGameState });

                break;
            
            case GameState.GameOver:

                Debug.Log("Game Over");
                Time.timeScale = 0.0f;
                break;
            
            default:
                Debug.LogError("There's no such state for the game", this);
                break;
        }
    }

    // Member Methods------------------------------------------------------------------------------

    public bool IsGamePlaying() => _currentGameState == GameState.Playing;
    public void ToggleGamePause()
    {
        _gamePaused = !_gamePaused;

        if (_gamePaused)
        {
            OnGamePaused?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 0.0f;
        }
        else
        {
            OnGameResumed?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 1.0f;
        }
    }

    // Signal Methods------------------------------------------------------------------------------
    private void GameInput_OnPausePressed(object sender, EventArgs e)
    {
        ToggleGamePause();
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        _playingTimer = ROUND_TIME;
        _currentGameState = GameState.CountDownToStart;
    }
    // Getters & Setters---------------------------------------------------------------------------

    public float CountdownToStartTimer { get => _countDownToStartTimer; }

    public float PlayingTimeNormalized { get => _playingTimer / ROUND_TIME; }
}
