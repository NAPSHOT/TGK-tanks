using UnityEngine;
using UnityEngine.UI;

public class EnemyShooting : MonoBehaviour
{
	public Rigidbody m_Shell;                  
	public Transform m_FireTransform;          
	public float LaunchForce = 100.0f;        
	public float TimeToShoot = 5.0f;

        
	private float coolDownTimer;
	private bool canFire;  



	private void Start ()
	{
		coolDownTimer = 0;
	}


	private void Update ()
	{
		if (coolDownTimer < TimeToShoot) {
			coolDownTimer += Time.deltaTime;
		}
		else{
			canFire = true;
		}

		if (canFire == true)
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