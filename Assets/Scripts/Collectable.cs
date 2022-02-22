using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    gem,
    health
}

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    public CollectableType type;

    private SpriteRenderer sprite;
    private CircleCollider2D itemCollider;

    bool hasBeenCollected = false;

    GameObject player;

    AudioSource doorOpen;


    public int value = 1;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<CircleCollider2D>();


    }
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hide()
    {
        sprite.enabled = false;
        itemCollider.enabled = false;
    }

    void Collect()
    {
        Hide();
        hasBeenCollected = true;

        switch (this.type)
        {
            case CollectableType.gem:
                GameManager.sharedInstance.CollectGem(this);
                GetComponent<AudioSource>().Play();
                if(GameManager.sharedInstance.collectedGem == 3)
                {
                    doorOpen = GameObject.Find("DoorOpen").GetComponent<AudioSource>();
                    doorOpen.Play();
                }

                

                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Collect();
        }
    }
}
