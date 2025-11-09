using System.Collections;
//using System.Numerics;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{

    public Transform waypointParent;
    public float moveSpeed = 1.5f;
    public float waitTime = 2f;
    public bool loopWaypoints = true;
    public Animator animator;

    private Transform[] waypoints;
    private int currentWaypointIndex;
    private bool isWaiting;
    private float direction;
    private UnityEngine.Vector3 previousPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        previousPosition = transform.position;
        waypoints = new Transform[waypointParent.childCount];
        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float speed = (transform.position - previousPosition).magnitude / Time.deltaTime;
        animator.SetFloat("speed", speed);
        previousPosition = transform.position;
        if (PauseMenu.GameIsPaused == true || isWaiting)
        {
            return;
        }
        
        MoveToWaypoint();
    
    }
    void MoveToWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        
        direction = transform.position.x - target.position.x;
        if (direction <= 0f)
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }
        else if (direction >= 0f)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
        

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
        
        
    }
        
    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentWaypointIndex = loopWaypoints ? (currentWaypointIndex + 1) % waypoints.Length : Mathf.Min(currentWaypointIndex + 1, waypoints.Length - 1);
        isWaiting = false;
    }
}
