
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform player;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;


	void FixedUpdate ()
	{
		Vector3 desirePosition =  player.position + offset;
		Vector3 smoothPosition = Vector3.Lerp (transform.position, desirePosition, smoothSpeed);
		transform.position = smoothPosition;

		transform.LookAt (player);
	}
}
