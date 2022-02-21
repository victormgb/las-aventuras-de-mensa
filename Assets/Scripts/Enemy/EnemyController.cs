using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    Vector3 startPosition;

    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
        startPosition = parent.transform.position;
        
        if (parent.tag == "Respawn")
        {
            Debug.Log(parent.tag);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        //GameObject go = Instantiate(explosion, transform);
    //        //go.transform.position = transform.position;
    //        //Deactivate();

    //        //Instantiate(explosion, transform.position, Quaternion.identity);

    //        //Destroy(this.gameObject);
    //        Debug.Log("Entrando Player");
    //    }

    //    if (collision.CompareTag("Arrow"))
    //    {
    //        //1. Se puede destruir pero no habria mucha optimizacion
    //        //Destroy(gameObject);
    //        Debug.Log("Entrando flecha");
    //        Deactivate();
    //    }


    //}

    void OnCollisionEnter(Collision other)
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            Deactivate();
        }
    }

    private void Deactivate()
    {
        //destroy
        gameObject.SetActive(false);

        Invoke("Respawn", 5f);
    }

    private void Respawn()
    {
        parent.transform.position = startPosition;
        gameObject.SetActive(true);
    }
}
