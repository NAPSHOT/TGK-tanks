using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
	public Rigidbody m_Shell;                  
	public Transform m_FireTransform;          
	public Slider shootSlider; 
	public float LaunchForce = 100.0f;        
	public float TimeToShoot = 5.0f;


	private string m_FireButton;            
	private float coolDownTimer;
	private bool canFire;  



	private void Start ()
	{
		m_FireButton = "Fire1";
		coolDownTimer = 0;
	}


	private void Update ()
	{
		if (coolDownTimer < TimeToShoot) {
			coolDownTimer += Time.deltaTime;
			if (coolDownTimer > TimeToShoot){
				shootSlider.value = TimeToShoot;
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
		canFire = false;
		coolDownTimer = 0;

		Rigidbody shellInstance =
			Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
		shellInstance.velocity = LaunchForce * m_FireTransform.forward;
	}
}