using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { Ready, Playing};

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Ready;
    public GameObject uiReady;

    void Update()
    {
        bool action = Input.GetKeyDown("space");
        UpdateGameState(action);
    }

    //Method used for changing the game state
    void UpdateGameState(bool action)
    {
        if (gameState == GameState.Ready && action)
        {
            gameState = GameState.Playing;
            uiReady.SetActive(false);
        }
    }
}