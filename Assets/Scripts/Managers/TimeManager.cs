using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float countdown = 3;

    public static TimeManager Instance;

    public delegate void CountdownAction(float count);
    public CountdownAction countdownAction;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        countdown -= Time.deltaTime;
        countdownAction?.Invoke(countdown);
        if (countdown <= 0)
        {
            switch (GameManager.Instance.gameState)
            {
                case GameState.Start:
                    GameStart();
                    break;
                case GameState.Looping:
                    countdown = 25;
                    break;
                case GameState.Counting:
                    GameEnd();
                    break;
            }
        }
    }

    private void GameStart()
    {
        GameManager.Instance.GameLoop();
    }
    private void GameEnd()
    {
        GameManager.Instance.GameEnd();
    }

    public void ResetEndTimer()
    {
        countdown = 3f;
    }
}