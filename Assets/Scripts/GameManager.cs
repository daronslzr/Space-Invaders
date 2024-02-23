using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState { Ready, Playing, Ended};

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState gameState = GameState.Ready;
    public GameObject uiReady, uiGameOver, uiWin;

    void Awake()
    {
        Instance = this;   
    }

    void Update()
    {
        bool action = Input.GetKeyDown("space");
        HandleCollissions();
        UpdateGameState(action);
    }

    //Method used for changing the game state
    void UpdateGameState(bool action)
    {
        if (gameState == GameState.Ready && action)
        {
            gameState = GameState.Playing;
            uiReady.SetActive(false);
            SpawnManager.Instance.StartSpawn();
        }
        else if (gameState == GameState.Ended && action)
        {
            HandleRestart();
        }
    }

    void HandleRestart()
    {
        SceneManager.LoadScene("Main");
    }

    void HandleCollissions()
    {
        if (gameState == GameState.Playing && (PlayerManager.Instance.enemyCollission || EnemyManager.Instance.enemyCollission))
        {
            gameState = GameState.Ended;
            SpawnManager.Instance.StopSpawn();
            if (PlayerManager.Instance.enemyCollission)
            {
                uiGameOver.SetActive(true);
            }
            else if (EnemyManager.Instance.enemyCollission)
            {
                uiWin.SetActive(true);
            }
        }
    }
}
