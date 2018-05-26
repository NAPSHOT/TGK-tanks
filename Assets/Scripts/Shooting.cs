using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
	public Rigidbody m_Shell;                   // Prefab of the shell.
	public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
	public Slider shootSlider; 
	public float LaunchForce = 100.0f;        // The force given to the shell if the fire button is held for the max charge time.
	public float timeToShoot = 5.0f;


	private string m_FireButton;                // The input axis that is used for launching shells.
	private float coolDownTimer;
	private bool canFire;                       // Whether or not the shell has been launched with this button press.



	private void Start ()
	{
		// The fire axis is based on the player number.
		m_FireButton = "Fire1";
		coolDownTimer = 0;
	}


	private void Update ()
	{
		if (coolDownTimer < timeToShoot) {
			coolDownTimer += Time.deltaTime;
			if (coolDownTimer > timeToShoot){
				shootSlider.value = timeToShoot;
			} 
			else{
				shootSlider.value = coolDownTimer;
			}
			//set slider
		}
		else{
			canFire = true;
		}

		if (Input.GetButtonDown (m_FireButton) && canFire == true)
		{
			Fire();
		}
	}


	private void Fire ()
	{
		// Set the fired flag so only Fire is only called once.
		canFire = false;
		coolDownTimer = 0;

		// Create an instance of the shell and store a reference to it's rigidbody.
		Rigidbody shellInstance =
			Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

		// Set the shell's velocity to the launch force in the fire position's forward direction.
		shellInstance.velocity = LaunchForce * m_FireTransform.forward;
	}
}