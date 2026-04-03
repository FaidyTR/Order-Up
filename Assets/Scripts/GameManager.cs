using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver
    }

    private EventHandler OnStateChanged;
    private State state;
    private float timer;
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTimer = 10f;

    private void Awake()
    {
        state = State.WaitingToStart;
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
}
