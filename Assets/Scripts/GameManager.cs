using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        menu,
        inGame,
        gameOver
    }

    public GameState currentGameState;

    public static GameManager sharedInstance;

    private PlayerMovement controller;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.inGame;
        controller = GameObject.Find("Player").GetComponent<PlayerMovement>();
        controller.StartGame();
    }

    void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //MenuManager.sharedInstance.ShowMainMenu();
            //MenuManager.sharedInstance.HideGameOver();
        }
        else if (newGameState == GameState.inGame)
        {
            //LevelManager.sharedInstance.RemoveAllLevelBlocks();
            //LevelManager.sharedInstance.GenerateInitialBlocks();
            //controller.StartGame();
            //MenuManager.sharedInstance.ShowCoinUI();
            //MenuManager.sharedInstance.HideMainMenu();

            // TODO: Hay que preparar la escena para jugar
        }
        else if (newGameState == GameState.gameOver)
        {
            MenuManager.sharedInstance.ShowGameOver();
        }

        this.currentGameState = newGameState;
    }


}
