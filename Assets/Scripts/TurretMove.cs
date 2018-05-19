using UnityEngine;

public class TurretMove : MonoBehaviour
{
	public float t_TurnSpeed = 180f;            // How fast the tank turns in degrees per second.


	private Rigidbody t_Rigidbody;              
	private float t_TurnInputValue;             // The current value of the turn input.


	private void Awake ()
	{
	//	t_Rigidbody = GetComponent<Rigidbody> ();
	}


	private void OnEnable ()
	{
		// When the tank is turned on, make sure it's not kinematic.
		//t_Rigidbody.isKinematic = false;

		t_TurnInputValue = 0f;
	}


	private void OnDisable ()
	{
		// When the tank is turned off, set it to kinematic so it stops moving.
		//t_Rigidbody.isKinematic = true;
	}


	private void Start ()
	{

	}


	private void Update ()
	{
		t_TurnInputValue = Input.GetAxis ("Mouse X");
	}



	private void FixedUpdate ()
	{
		TurnTurret();
	}

	private void TurnTurret()
	{
		// Determine the number of degrees to be turned based on the input, speed and time between frames.
		float turn = t_TurnInputValue * t_TurnSpeed * Time.deltaTime;
		// Apply this rotation to the rigidbody's rotation.
		transform.Rotate (0f, 0f, turn);
	}
}﻿