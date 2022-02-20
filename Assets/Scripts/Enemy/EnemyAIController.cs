using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAIController : MonoBehaviour
{
    AIPath path;
    PlayerMovement player;

    public float chaseDistance;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<AIPath>();
        

        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance <= chaseDistance)
        {
            path.canSearch = true;
        } else
        {
            path.canSearch = false;
        }
    }
}
