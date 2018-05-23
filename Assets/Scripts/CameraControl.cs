using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform lookAt;
	private Transform camTransform;
    public float distance = 10.0f;
	public float heigh = 4.0f;
	public float angle = 0.0f;

    private float currentX = 0.0f;


    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
    }

    private void LateUpdate()
    {
		Vector3 dir = new Vector3(0, heigh, -distance);
		Quaternion rotation = Quaternion.Euler(angle, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
