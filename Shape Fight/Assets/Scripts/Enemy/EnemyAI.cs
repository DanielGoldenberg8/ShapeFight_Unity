using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public LayerMask whatIsGround;
    private Transform groundCheck;
    private Transform target;

    public float movementSpeed = 60f;
    public float nextWaypointDistance = 3f;
    public float maxDistance;

    private Rigidbody2D rb;
    private Seeker seeker;
    private Path path;

    private Vector2 force;
    
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;
    public bool grounded;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        groundCheck = transform.Find("groundCheck");

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        movementSpeed = movementSpeed * 10f;

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void FixedUpdate()
    {
        float distanceFromTarget = Vector2.Distance(transform.position, target.position);

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            
            return;
        }
        else 
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        force = direction * movementSpeed * Time.deltaTime;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (grounded)
        {
            rb.velocity = transform.right * force;
        }

        grounded = false;
		Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheck.position, 0.3f, whatIsGround);

		for (int i = 0; i < collider.Length; i++)
		{
			grounded = true;
		}
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
}
