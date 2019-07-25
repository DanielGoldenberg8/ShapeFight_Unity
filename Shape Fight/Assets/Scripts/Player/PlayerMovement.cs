using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public KeyCode jump;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float jumpHeight = 200f;
	public float movementSpeed = 60f * 10; 

	private Rigidbody2D rb;
	private Vector3 velocity = Vector3.zero;
	private float smoothing = 0.05f;
	private float horizontalMove;
	private bool grounded;
	
	private float jumpRememberTime = 0.05f;
	private float jumpRemember;
	private float groundedRememberTime = 0.15f;
	private float groundedRemember;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		
		movementSpeed *= 10;
	}

	void Update()
	{
		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, rb.velocity.y);
		rb.velocity = Vector3.SmoothDamp(rb.velocity, rb.velocity, ref velocity , smoothing);

		groundedRemember -= Time.deltaTime;

		if (grounded)
		{
			groundedRemember = groundedRememberTime;
		}

		jumpRemember -= Time.deltaTime;

		if (Input.GetButtonDown("Jump"))
		{
			jumpRemember = jumpRememberTime;
		}

		if ((jumpRemember > 0) && (groundedRemember > 0))
		{
			jumpRemember = 0;
			groundedRemember = 0;

			Jump();
		}
	}

	void FixedUpdate()
	{
		grounded = false;
		Collider2D[] collider1 = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, whatIsGround);

		for (int i = 0; i < collider1.Length; i++)
		{
			grounded = true;
		}
	}

	void Jump()
	{
		rb.velocity = new Vector2(0f, jumpHeight);
		AudioManager.instance.Play("Jump");
	}
}
