using UnityEngine;

public class FollowTarget : MonoBehaviour 
{
	public GameObject target;
	public float speed = 60;

	public float leftBoundary;
	public float rightBoundary;
	
	public Vector3 offset = new Vector3(0, 2, 0);

	private Vector3 targetPos;
	private float interpVelocity;

	void Start() 
	{
		targetPos = transform.position;
	}
	
	void FixedUpdate() 
	{
		if (target != null)
		{
			if ((target.transform.position.x > leftBoundary) && (target.transform.position.x < rightBoundary))
			{
				Vector3 posNoZ = transform.position;

				posNoZ.z = target.transform.position.z;

				Vector3 targetDirection = (target.transform.position - posNoZ);

				interpVelocity = targetDirection.magnitude * speed;

				targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

				transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
			}
		}
	}
}