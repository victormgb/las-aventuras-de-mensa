using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

    public int collectedGem = 0;

    public GameObject obstacledoor;
    TilemapRenderer ostacledoorRenderer;
    Tilemap obstacledoorTile;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.inGame;
        controller = GameObject.Find("Player").GetComponent<PlayerMovement>();
        MenuManager.sharedInstance.HideGameOver();
        //controller.StartGame();

        ostacledoorRenderer = obstacledoor.GetComponent<TilemapRenderer>();
        obstacledoorTile = obstacledoor.GetComponent<Tilemap>();


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
        
        if(collectedGem >= 3)
        {
            obstacledoorTile.enabled = false;
            ostacledoorRenderer.enabled = false;
             
        }
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

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void CollectGem(Collectable collectable)
    {
        collectedGem += collectable.value;
    }


}
