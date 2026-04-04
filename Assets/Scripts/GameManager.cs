using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver
    }

    public EventHandler OnStateChanged;
    private State state;
    private float timer;
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    [SerializeField] private float gamePlayingTimer = 30f;
    private bool isGamePaused = false;
    private void Awake()
    {
        state = State.WaitingToStart;

        Instance = this;
    }
    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                    TimerCountDown(waitingToStartTimer, State.CountdownToStart);
                        OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            case State.CountdownToStart:
                    TimerCountDown(countdownToStartTimer, State.GamePlaying);
                        OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            case State.GamePlaying:
                    TimerCountDown(gamePlayingTimer, State.GameOver);
                        OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            case State.GameOver:
                break;
        }

    }
    private void TimerCountDown(float timerMax, State nextState)
    {
        timer += Time.deltaTime;
        if (timer > timerMax)
        {
            timer = 0f;
            state = nextState;
        }
    }
    public bool GetStateIsCountdownToStart()
    {
        return state == State.CountdownToStart;
    }
    public bool GetStateIsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public float GetCountDownToStartTimer()
    {
        if (state != State.CountdownToStart) return 0f;
        return ( timer );
    }
    public float GetGamePlayingTimer()
    {
        if (state != State.GamePlaying) return 0f;
        return ( timer / gamePlayingTimer);
    }
    public bool GetStateIsGameOver()
    {
        return state == State.GameOver;
    }
    public void PauseUnPauseGame()
    {
        if(state != State.GamePlaying) return;
        if(isGamePaused)
        {
            isGamePaused = false;
            Time.timeScale = 1f;
            return;
        }
        isGamePaused = true;
        Time.timeScale = 0f;
    }
    public bool GetIsGamePaused()
    {
        return isGamePaused;
    }
}
