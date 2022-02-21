using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArrowBehaivour : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;

    GameObject player;

    private float horizontalDirection;
    private float verticalDirection;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        horizontalDirection = player.GetComponent<PlayerMovement>().horizontalDirection;
        verticalDirection = player.GetComponent<PlayerMovement>().verticalDirection;

        if (horizontalDirection == 0 && verticalDirection == -1)
        {
            //rb.velocity = (-1 * transform.up) * speed;
            transform.Rotate(0f, 0f, 180f);

        }
        else if (horizontalDirection == 0 && verticalDirection == 1)
        {
            //rb.velocity = transform.up * speed;
            transform.Rotate(0f, 0f, 0f);
        }
        else if (horizontalDirection == -1 && verticalDirection == 0)
        {
            transform.Rotate(0f, 0f, 90f);
        }
        else if (horizontalDirection == 1 && verticalDirection == 0)
        {
            transform.Rotate(0f, 0f, 270f);
        } else if(horizontalDirection == 0 && verticalDirection == 0)
        {
            transform.Rotate(0f, 0f, 180f);
        }

        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.velocity = transform.up * speed;  
    }
}
