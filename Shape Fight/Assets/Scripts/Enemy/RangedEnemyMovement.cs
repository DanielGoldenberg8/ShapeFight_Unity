using UnityEngine;

public class RangedEnemyMovement : MonoBehaviour
{
	public Transform groundCheck;
	public LayerMask whatIsGround;

	public float movementSpeed;
	public float viewDistance;

	private Rigidbody2D rb;
	private Transform player;
	private Vector3 velocity = Vector3.zero;
	private bool grounded;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{	
		Vector3 relativePlayerPos = transform.InverseTransformPoint(player.position);

		float distance = Vector2.Distance(transform.position, player.position);

		if ((distance >= viewDistance) && grounded)
		{
			if (relativePlayerPos.x > 0.0)
			{
				rb.velocity = transform.right * movementSpeed;
			}
			else if (relativePlayerPos.x < 0.0)
			{
				rb.velocity = -transform.right * movementSpeed;
			}
		}
		else if ((distance <= viewDistance) && grounded)
		{
			rb.velocity = transform.right * 0;
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
