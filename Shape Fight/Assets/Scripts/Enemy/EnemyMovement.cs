using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private Transform groundCheck;
	public LayerMask whatIsGround;

	public float movementSpeed;
	public float maxDistance;

	private Rigidbody2D rb;
	private Transform player;
	private Vector3 velocity = Vector3.zero;
	private bool grounded;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		groundCheck = transform.Find("groundCheck");

		movementSpeed = movementSpeed * 10;

		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{	
		if (player != null)
		{
			Vector3 relativePlayerPos = transform.InverseTransformPoint(player.position);

			float distance = Vector2.Distance(transform.position, player.position);

			if ((distance >= maxDistance) && grounded)
			{
				if (relativePlayerPos.x > 0.0)
				{
					rb.velocity = transform.right * movementSpeed * Time.deltaTime;
				}
				else if (relativePlayerPos.x < 0.0)
				{
					rb.velocity = -transform.right * movementSpeed * Time.deltaTime;
				}
			}
			else if ((distance <= maxDistance) && grounded)
			{
				rb.velocity = transform.right * 0;
			}
		}
	}

	void FixedUpdate()
	{
		grounded = false;
		Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, whatIsGround);

		for (int i = 0; i < collider.Length; i++)
		{
			grounded = true;
		}
	}
}
