using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Transform targetBF;
	public Transform targetEnemy;
	public Transform target;
	public bool FollowBF;
	private float smoothSpeed = 2f;

	private void Update()
	{
		if (!FollowBF)
		{
			target = targetEnemy;
		}
		else if (FollowBF)
		{
			target = targetBF;
		}
		Vector2 b = target.position;
		Vector2 vector = Vector2.Lerp(base.transform.position, b, smoothSpeed * Time.deltaTime);
		base.transform.position = new Vector3(vector.x, vector.y, -10f);
	}
}