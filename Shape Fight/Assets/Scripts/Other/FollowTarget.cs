using UnityEngine;

public class FollowTarget : MonoBehaviour 
{
	private Vector3 targetPos;
	private float interpVelocity;
	public GameObject target;
	public float speed = 60;
	
	public Vector3 offset = new Vector3(0, 2, 0);

	void Start() 
	{
		targetPos = transform.position;
	}
	
	void FixedUpdate() 
	{
		if (target)
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