using UnityEngine;
using Pathfinding;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 8f;

    private Vector3 spawnPoint;
    private AIDestinationSetter setter;

    void Start()
    {
        spawnPoint = transform.position; // save starting spawn location
        setter = GetComponent<AIDestinationSetter>();
    }

    void Update()
    {
        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= chaseRange)
        {
            // Chase player
            setter.target = player;
        }
        else
        {
            // Return to spawn
            // we need a temporary target object for A* to use
            setter.target = null;
            GetComponent<AIPath>().destination = spawnPoint;
        }
    }
}

