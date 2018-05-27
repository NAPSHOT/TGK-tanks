using UnityEngine;

public class PlayerTurretRotation : MonoBehaviour
{
	private void FixedUpdate ()
	{
		TurnTurret();
	}

	private void TurnTurret()
	{
        RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 1000)) {

			float angle = AngleBetweenPoints (hit.point, transform.position);

			transform.rotation = Quaternion.Euler (new Vector3 (-90f, angle, 0f));
		}
	}
	float AngleBetweenPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.x - b.x, a.z - b.z) * Mathf.Rad2Deg;
	}
}﻿