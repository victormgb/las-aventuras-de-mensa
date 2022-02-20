using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource audioObject; 

    // Start is called before the first frame update
    void Start()
    {
        audioObject = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        { // only an object tagged Player stops the sound
            
            Debug.Log("Player entered!");
            audioObject.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    //use ontriggerexit 2D instead of no 2D because of collider

    {
        if (other.tag == "Player")
        { // only an object tagged Player restarts the sound
            //audioObject.clip = nextMusic;  // select the next music
            
            Debug.Log("Player exit!");
            audioObject.Stop();
        }
    }
}
