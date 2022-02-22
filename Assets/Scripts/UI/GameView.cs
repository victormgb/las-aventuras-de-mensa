using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    // Start is called before the first frame update
    public Text gemText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameManager.GameState.inGame)
        {
            int gems = GameManager.sharedInstance.collectedGem;
            gemText.text = gems.ToString();
        }
    }
}
