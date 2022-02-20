using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager sharedInstance;
    public Canvas gameOverCanvas;
    public Canvas inforUICanvas;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Canvas Hearth1 = GameObject.FindWithTag("Hearth").GetComponent<Canvas>();
        Debug.Log(Hearth1);
    }

    public void ShowGameOver()
    {
        gameOverCanvas.enabled = true;
    }

    public void HideGameOver()
    {
        Debug.Log("PASA X ACA");
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HearthManager(bool enable, int hearthIndex)
    {

    }
}
