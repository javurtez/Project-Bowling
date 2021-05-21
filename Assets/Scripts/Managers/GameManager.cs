using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameState gameState;

    public Material[] colorMaterials;

    public int level = 1;
    public int score = 0;

    public delegate void StateAction();
    public StateAction startAction;
    public StateAction endAction;
    public StateAction countAction;
    public delegate void ScoreAction(int score);
    public ScoreAction scoreAction;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += UpdateScene;
    }
//    private void Update()
//    {
//        switch (gameState)
//        {
//            case GameState.End:
//#if UNITY_EDITOR
//                if (Input.anyKeyDown)
//                {
//                    level++;
//                    SceneManager.LoadScene(0);
//                }
//#elif UNITY_ANDROID
//                if (Input.touchCount > 0)
//                {
//                    level++;
//                    SceneManager.LoadScene(0);
//                }
//#endif
//                break;
//        }
//    }

    private void UpdateScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        GameStart();
        score = 0;

        //null action because it will get a missing ref exception if it is not cleared
        scoreAction = null;
        startAction = null;
        countAction = null;
        endAction = null;
    }

    public void IncreaseScore(int add)
    {
        score += add;
        scoreAction?.Invoke(score);
    }

    public void GameStart()
    {
        gameState = GameState.Start;
    }
    public void GameLoop()
    {
        gameState = GameState.Looping;
        startAction?.Invoke();
    }
    public void GameCount()
    {
        TimeManager.Instance.ResetEndTimer();
        gameState = GameState.Counting;
        countAction?.Invoke();
    }
    public void GameEnd()
    {
        gameState = GameState.End;
        endAction?.Invoke();
    }
    public void GameNext()
    {
        level++;
        SceneManager.LoadScene(0);
    }
}