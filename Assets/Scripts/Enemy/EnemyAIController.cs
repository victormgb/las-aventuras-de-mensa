using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAIController : MonoBehaviour
{
    AIPath path;
    PlayerMovement player;
    EnemyController Enemy;
    GameObject EnemyChild;

    public float chaseDistance;
    Vector2 movement;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<AIPath>();
        

        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        EnemyChild = gameObject.transform.GetChild(0).gameObject;
        Enemy = EnemyChild.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        Vector3 direction = path.targetDirection;
        float x = direction.x;
        float y = direction.y;
        Enemy.animator.SetFloat("Horizontal", x);
        Enemy.animator.SetFloat("Vertical", y);

        if (distance <= chaseDistance)
        {
            path.canSearch = true;
            Enemy.animator.SetBool("isRunning", true);
            
        } else
        {
            path.canSearch = false;
            if (path.TargetReached)
            {
                Enemy.animator.SetBool("isRunning", false);
            } 
        }
    }
}
