using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;
    private Vector3 moveToPosition;

    public Animator animator;

    public Tilemap obstacles;

    [HideInInspector]
    public float horizontalDirection;
    [HideInInspector]
    public float verticalDirection;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.y != 0 || movement.x != 0)
        {
            horizontalDirection = movement.x;
            verticalDirection = movement.y;
            animator.SetFloat("Horizontal2", horizontalDirection);
            animator.SetFloat("Vertical2", verticalDirection);
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }


    }

    private void FixedUpdate()
    {
        moveToPosition = transform.position + new Vector3(movement.x, movement.y, 0);
        Vector3Int obstacleMapTile = obstacles.WorldToCell(moveToPosition);
        if (obstacles.GetTile(obstacleMapTile) == null)
        {
            // Movement
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage Them
        //foreach (Collider2D enemy in hitEnemies)
        //{
        //    Debug.Log("We hit " + enemy);
        //}

        GameObject go = ObjectPool.instance.GetPoolObject("Arrow");
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
        go.SetActive(true);
    }
}
